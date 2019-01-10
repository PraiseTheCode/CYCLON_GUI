using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPlot;

namespace CYCLON
{
    public partial class Form1 : Form
    {
        const double const_c = 2.99792458e10, const_e = 4.8032e-10, const_me = 9.10953e-28, const_k = 1.38064853e-16, eV_to_erg = 1.60218e-12;
        static Spline32D spline_o, spline_e;
        static double[] ww, thetas, temps;
        static double[][][] ac_o, ac_e;
        static int iT;

        static double[][] results;
        static double[] norms, scale_par_mas;

        static double[] lambda_obs, intens_obs, std;
        static double[] lambda_obs_graph, intens_obs_graph;
        static double scale_par;

        static double[] lambdas, intens;
        static double[] lambdas_graph, intens_graph;

        static double ave_mod, ave_obs;
        static int[] iters;
        static bool[] emerges; 
        static double[] ave_mod_mas;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadSpec_Click(object sender, EventArgs e) 
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(path);
            string[] s = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] mmm;
            lambda_obs = new double[s.Length];
            intens_obs = new double[s.Length];
            lambda_obs_graph = new double[s.Length];
            intens_obs_graph = new double[s.Length];
            std = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                mmm = s[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                lambda_obs[i] = Convert.ToDouble(mmm[0].Replace(".", ",")) * 1e-8;
                intens_obs[i] = Convert.ToDouble(mmm[1].Replace(".", ","));
                //std[i] = Convert.ToDouble(mmm[2].Replace(".", ","));
                std[i] = 1;
                lambda_obs_graph[i] = Convert.ToDouble(mmm[0].Replace(".", ","));
                intens_obs_graph[i] = Convert.ToDouble(mmm[1].Replace(".", ",")) * 1e15;
            }
            sr.Close();

            lbTes.Items.Clear();
            lbRes.Items.Clear();
        }

        private void btn_loadgrid_Click(object sender, EventArgs e) 
        {
            lbTes.Items.Clear();
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;

            StreamReader sr = new StreamReader(path);
            string s = "ssss";

            s = sr.ReadLine();
            s = sr.ReadLine();
            string[] mas = s.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            double ww1 = Convert.ToDouble(mas[0].Replace(".", ","));
            double step = Convert.ToDouble(mas[1].Replace(".", ","));
            ww = new double[Convert.ToInt32(mas[2])];
            for (int i = 0; i < ww.Length; i++)
                ww[i] = ww1 + i * step;

            s = sr.ReadLine();
            mas = s.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            temps = new double[Convert.ToInt32(mas[0])];
            for (int i = 0; i < temps.Length; i++)
                temps[i] = Convert.ToDouble(mas[i + 1].Replace(".", ","));

            s = sr.ReadLine();
            mas = s.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            thetas = new double[Convert.ToInt32(mas[0])];
            for (int i = 0; i < thetas.Length; i++)
                thetas[i] = Convert.ToDouble(mas[i + 1].Replace(".", ","));

            ac_o = new double[temps.Length][][];
            ac_e = new double[temps.Length][][];
            for (int i = 0; i < temps.Length; i++)
            {
                ac_o[i] = new double[thetas.Length][];
                ac_e[i] = new double[thetas.Length][];
                for (int j = 0; j < thetas.Length; j++)
                {
                    ac_o[i][j] = new double[ww.Length];
                    ac_e[i][j] = new double[ww.Length];
                }
            }

            for (int i = 0; i < temps.Length; i++)
            {
                for (int j = 0; j < ww.Length; j++)
                {
                    s = sr.ReadLine();
                    mas = s.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < thetas.Length; k++)
                    {
                        ac_o[i][k][j] = Convert.ToDouble(mas[k + 1].Replace(".", ","));
                        ac_e[i][k][j] = Convert.ToDouble(mas[k + 1 + thetas.Length].Replace(".", ","));

                        ac_o[i][k][j] = (ac_o[i][k][j] > 0) ? Math.Log(ac_o[i][k][j]) : 1e-200;
                        ac_e[i][k][j] = (ac_e[i][k][j] > 0) ? Math.Log(ac_e[i][k][j]) : 1e-200;
                    }
                }
            }
            sr.Close();

            for (int i = 0; i < temps.Length; i++)
                lbTes.Items.Add("Te " + temps[i].ToString() + " keV");
        }

        private void btnShSpec_Click(object sender, EventArgs e) 
        {
            LinePlot lp = new LinePlot();

            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

            lp.AbscissaData = lambda_obs_graph;
            lp.OrdinateData = intens_obs_graph;

            plot.Add(lp);
            plot.XAxis1.Label = "Wavelength, A";
            plot.YAxis1.Label = "Flux, erg/(s*A*cm^2)*10^15";
            plot.Refresh();
            plot.Show();
        }

        private void btn_PlCl_Click(object sender, EventArgs e)
        {
            plot.Clear();
            plot.Refresh();
        }

        private double[] Resid(double[] x) 
        {
            double[] resid = new double[lambda_obs.Length];
            double ang_tet = x[1];
            double B = x[0] * 1e6;
            double size_par = Math.Pow(10, x[2]);
            double Io, Ie, pe_e, pe_o, Irj, w, wc;
            double eV_to_erg = 1.60218e-12;
            wc = const_e * B / const_me / const_c;
            double intens_const = const_k * temps[iT] * 1e3 * eV_to_erg / (const_k * 8 * Math.Pow(Math.PI, 3) * Math.Pow(const_c, 2));
            for (int i = 0; i < lambda_obs.Length; i++)
            {
                w = 2 * Math.PI * const_c / lambda_obs[i];
                double ao = spline_o.Interp(ang_tet, w / wc);
                double ae = spline_e.Interp(ang_tet, w / wc);
                Irj = intens_const * Math.Pow(w, 2);
                pe_o = -1 * Math.Exp(ao) * size_par;
                pe_e = -1 * Math.Exp(ae) * size_par;
                Io = Irj * (1 - Math.Exp(pe_o));
                Ie = Irj * (1 - Math.Exp(pe_e));
                resid[i] = Io + Ie;
            }

            if (rbToAn.Checked)
            {
                for (int i = 0; i < lambda_obs.Length; i++)
                    resid[i] *= const_c / Math.Pow(lambda_obs[i], 2);
            }

            double stF = 0, stI = 0;
            for (int i = 0; i < lambda_obs.Length; i++)
            {
                stF = stF + intens_obs[i] / std[i];
                stI = stI + resid[i] / std[i];
            }
            scale_par = stF / stI;

            for (int i = 0; i < lambda_obs.Length; i++)
            {
                resid[i] = scale_par * resid[i] - intens_obs[i];
                resid[i] = resid[i] / std[i];
            }
            return resid;
        }

        private double[] SumMas(double[] x, double[] dx)
        {
            double[] sm = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
                sm[i] = x[i] + dx[i];
            return sm;
        }

        private void Sort(ref double[] norms, ref double[][] xx, ref double[] scales, ref int[] iters, ref bool[] emerges) 
        {
            byte count = 0;
            double norms_buff = 0, scale_buff = 0;
            int iters_buff = 0;
            bool emerges_buff = false;
            double[] xx_buff = new double[3];
            for (int i = 0; i < norms.GetUpperBound(0); i++)
                for (int j = 0; j < norms.GetUpperBound(0); j++)
                {
                    count++;
                    if (norms[j] > norms[j + 1])
                    {
                        norms_buff = norms[j];
                        norms[j] = norms[j + 1];
                        norms[j + 1] = norms_buff;

                        scale_buff = scales[j];
                        scales[j] = scales[j + 1];
                        scales[j + 1] = scale_buff;

                        xx_buff = xx[j];
                        xx[j] = xx[j + 1];
                        xx[j + 1] = xx_buff;

                        iters_buff = iters[j];
                        iters[j] = iters[j + 1];
                        iters[j + 1] = iters_buff;

                        emerges_buff = emerges[j];
                        emerges[j] = emerges[j + 1];
                        emerges[j + 1] = emerges_buff;
                    }
                }
        }

        private void btnCalc_Click(object sender, EventArgs e)  
        {
            lbRes.Items.Clear();

            double lB = 0, rB = 0, lTheta = 0, rTheta = 0, llogL = 0, rlogL = 0;
            double dB = 0, dTheta = 0, dlogL = 0;
            int max_iter = 0; 
            double crit = 0;
            
            try
            {
                lB = Convert.ToDouble(txtB1.Text);
                rB = Convert.ToDouble(txtBN.Text);
                dB = Convert.ToDouble(txtStepB.Text);
                lTheta = Convert.ToDouble(txtTh1.Text) * Math.PI / 180;
                rTheta = Convert.ToDouble(txtThN.Text) * Math.PI / 180;
                dTheta = Convert.ToDouble(txtThStep.Text) * Math.PI / 180;
                llogL = Convert.ToDouble(txtSP1.Text);
                rlogL = Convert.ToDouble(txtSPN.Text);
                dlogL = Convert.ToDouble(txtSPStep.Text);
                iT = lbTes.SelectedIndex;
                max_iter = Convert.ToInt32(txtMaxIt.Text);
                crit = Convert.ToDouble(txtKrit.Text);
            }
            catch
            {
                MessageBox.Show("Something wrong with input data", "Error...");
                return;
            }

            try
            {
                spline_o = new Spline32D(thetas, ww, ac_o[iT]);
                spline_e = new Spline32D(thetas, ww, ac_e[iT]);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Choose T", "Error...");
                return;
            }
            catch
            {
                MessageBox.Show("Something wrong with grid", "Error...");
                return;
            }

            int n_B = dB == 0 ? 1 : (int)((rB - lB) / dB);
            int n_theta = (int)((rTheta - lTheta) / dTheta);
            int n_logL = (int)((rlogL - llogL) / dlogL);
            int nn = n_B * n_theta * n_logL;
            double[][] ini = new double[nn][];
            for (int i = 0; i < nn; i++)
                ini[i] = new double[3];
            int p = 0;
            for (int i = 0; i < n_B; i++)
            {
                for (int j = 0; j < n_theta; j++)
                {
                    for (int s = 0; s < n_logL; s++)
                    {
                        ini[p][0] = lB + i * dB;
                        ini[p][1] = lTheta + j * dTheta;
                        ini[p][2] = llogL + s * dlogL;
                        p++;
                    }
                }
            }

            results = new double[nn][];
            for (int i = 0; i < nn; i++)
                results[i] = new double[3];

            norms = new double[nn];
            double norm = 0;

            double[] x = new double[3];
            double dxv = 0.001;
            double[][] dx = new double[3][];
            dx[0] = new double[3] { dxv, 0, 0 };
            dx[1] = new double[3] { 0, dxv, 0 };
            dx[2] = new double[3] { 0, 0, dxv };
            scale_par_mas = new double[nn];
            iters = new int[nn]; 
            emerges = new bool[nn];
            ave_mod_mas = new double[nn];

            prb.Maximum = nn;
            for (int ii = 0; ii < nn; ii++)
            {
                x = ini[ii];
                int n = 0;
                bool div_by_zero = false;
                for (n = 0; n < max_iter; n++)
                {
                    double[][] J = new double[lambda_obs.Length][];
                    for (int i = 0; i < lambda_obs.Length; i++)
                        J[i] = new double[3];

                    double[] res = new double[lambda_obs.Length];
                    double[] resI = new double[lambda_obs.Length];
                    res = Resid(x);

                    norm = 0;
                    for (int i = 0; i < res.Length; i++)
                        norm += res[i] * res[i];
                    norm = Math.Sqrt(norm);

                    for (int i = 0; i < 3; i++)
                    {
                        resI = Resid((SumMas(x, dx[i])));
                        for (int k = 0; k < lambda_obs.Length; k++)
                            J[k][i] = (resI[k] - res[k]) / dxv;
                    }

                    double[][] Jtr = new double[3][];
                    for (int k = 0; k < 3; k++)
                        Jtr[k] = new double[lambda_obs.Length];
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i = 0; i < lambda_obs.Length; i++)
                            Jtr[k][i] = J[i][k];
                    }

                    double[][] JtrJ = new double[3][];
                    for (int i = 0; i < 3; i++)
                        JtrJ[i] = new double[3];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            JtrJ[i][k] = 0;
                            for (int l = 0; l < lambda_obs.Length; l++)
                                JtrJ[i][k] += Jtr[i][l] * J[l][k];
                        }
                    }

                    double[] Jtrres = new double[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Jtrres[i] = 0;
                        for (int k = 0; k < lambda_obs.Length; k++)
                        {
                            Jtrres[i] += Jtr[i][k] * res[k];
                        }
                        Jtrres[i] = -Jtrres[i];
                    }

                    double[] delx;
                    div_by_zero = false;
                    delx = LES_Solver.SolveWithGaussMethod(JtrJ, Jtrres, ref div_by_zero);
                    if (div_by_zero == true)
                        break;
                    
                    double[] xI = new double[3];
                    for (int i = 0; i < 3; i++)
                    {
                        xI[i] = x[i];
                        x[i] += delx[i];
                    }
                    x[0] = (x[0] < lB) ? lB : x[0];
                    x[0] = (x[0] > rB) ? rB : x[0];
                    x[1] = (x[1] < lTheta) ? lTheta : x[1];
                    x[1] = (x[1] > rTheta) ? rTheta : x[1];
                    x[2] = (x[2] < llogL) ? llogL : x[2];
                    x[2] = (x[2] > rlogL) ? rlogL : x[2];

                    double[] xxI = new double[3];
                    for (int i = 0; i < 3; i++)
                        xxI[i] = x[i] - xI[i];
                    double normXXI = Math.Sqrt(xxI[0] * xxI[0] + xxI[1] * xxI[1] + xxI[2] * xxI[2]);
                    double normX = Math.Sqrt(x[0] * x[0] + x[1] * x[1] + x[2] * x[2]);

                    if (Math.Abs(normXXI / normX) <= crit)
                    {
                        res = Resid(x);
                        break;
                    }
                }
                scale_par_mas[ii] = scale_par;
                results[ii] = x;
                norms[ii] = norm;
                iters[ii] = ii;
                emerges[ii] = div_by_zero;
                ave_mod_mas[ii] = ave_mod;

                prb.Value = ii+1;
                prb.Refresh();
            }

            try
            {
                double min_norm = norms.Min();
                int index_min_norm = Array.IndexOf(norms, min_norm);
                x = results[index_min_norm];
                Sort(ref norms, ref results, ref scale_par_mas, ref iters, ref emerges);
                min_norm = norms[0];
                x = results[0];
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Step is too large", "Error...");
                return;
            }

            for (int i = 0; i < nn; i++)
                lbRes.Items.Add(string.Format("{0}  B={1:0.000}  Theta={2:0.000}  logL={3:0.000}  Chi2={4:0.000E00}  Scale={5:0.000E000}  NIter={6}  Emerg={7}", 
                    i, results[i][0], results[i][1], results[i][2], norms[i], scale_par_mas[i], iters[i], emerges[i]));
        }

        private void btnShMod_Click(object sender, EventArgs e)
        {
            double wc, w, Irj, Io, Ie, pe_o, pe_e;
            double left_wl = lambda_obs.Min();
            double right_wl = lambda_obs.Max();
            double step_wl = 10 * 1e-8;
            lambdas = new double[Convert.ToInt32(1 + (right_wl - left_wl) / step_wl)];
            intens = new double[lambdas.Length];
            lambdas_graph = new double[lambdas.Length];
            intens_graph = new double[intens.Length];
            int solut = lbRes.SelectedIndex;
            if (solut == -1)
                return;
            double B = results[solut][0] * 1e6;
            double ang_tet = results[solut][1];
            double size_par = Math.Pow(10, results[solut][2]);

            double intens_const = const_k * temps[iT] * 1e3 * eV_to_erg / (const_k * 8 * Math.Pow(Math.PI, 3) * Math.Pow(const_c, 2));
            wc = const_e * B / const_me / const_c;
            for (int i = 0; i < lambdas.Length; i++)
            {
                lambdas[i] = left_wl + step_wl * i;
                w = 2 * Math.PI * const_c / lambdas[i];
                double ao = spline_o.Interp(ang_tet, w / wc);
                double ae = spline_e.Interp(ang_tet, w / wc);
                Irj = intens_const * Math.Pow(w, 2);
                pe_o = -1 * Math.Exp(ao) * size_par;
                pe_e = -1 * Math.Exp(ae) * size_par;
                Io = Irj * (1 - Math.Exp(pe_o));
                Ie = Irj * (1 - Math.Exp(pe_e));
                intens[i] = Io + Ie;
            }

            if (rbToAn.Checked) 
            {
                for (int i = 0; i < lambdas.Length; i++)
                    intens[i] *= const_c / Math.Pow(lambdas[i], 2); 
            }

            double[] intensMO = new double[lambda_obs.Length];
            for (int i = 0; i < lambda_obs.Length; i++)
            {
                wc = const_e * B / const_me / const_c;
                w = 2 * Math.PI * const_c / lambda_obs[i];
                double ao = spline_o.Interp(ang_tet, w / wc);
                double ae = spline_e.Interp(ang_tet, w / wc);
                Irj = intens_const * Math.Pow(w, 2);
                pe_o = -1 * Math.Exp(ao) * size_par;
                pe_e = -1 * Math.Exp(ae) * size_par;
                Io = Irj * (1 - Math.Exp(pe_o));
                Ie = Irj * (1 - Math.Exp(pe_e));
                intensMO[i] = Io + Ie;
            }

            if (rbToAn.Checked) 
            {
                for (int i = 0; i < lambda_obs.Length; i++)
                    intensMO[i] *= const_c / Math.Pow(lambda_obs[i], 2); 
            }

            double stF = 0, stI = 0;
            for (int i = 0; i < lambda_obs.Length; i++)
            {
                stF += intens_obs[i] / std[i];
                stI += intensMO[i] / std[i];
            }
            scale_par = stF / stI;

            for (int i = 0; i < lambdas.Length; i++)
            {
                intens[i] *= scale_par;
                intens_graph[i] = intens[i] * 1e15;
                lambdas_graph[i] = lambdas[i] * 1e8;
            }

            LinePlot lp = new LinePlot();

            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

            lp.AbscissaData = lambdas_graph;
            lp.OrdinateData = intens_graph;
            lp.Pen = new Pen(Color.Red, 3);

            plot.Add(lp);
            plot.XAxis1.Label = "Wavelength, A";
            plot.YAxis1.Label = "Flux, erg/(s*A*cm^2)*10^15";
            plot.Refresh();
            plot.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;
            StreamWriter sw = new StreamWriter(path);
            double sB = results[lbRes.SelectedIndex][0];
            double sth = results[lbRes.SelectedIndex][1] * 180 / Math.PI;
            double slam = results[lbRes.SelectedIndex][2];
            sw.WriteLine("B = " + sB.ToString().Replace(",", ".") + "MG \t theta = " + sth.ToString().Replace(",", ".") + "\t lg sizepar = " + slam.ToString().Replace(",", "."));
            for (int i = 0; i < lambdas.Length; i++)
            {
                lambdas[i] *= 1e8;
                intens[i] *= scale_par;
                sw.WriteLine(lambdas[i].ToString().Replace(",", ".") + "\t" + intens[i].ToString().Replace(",", "."));
            }
            sw.Close();
        }
    }
}
