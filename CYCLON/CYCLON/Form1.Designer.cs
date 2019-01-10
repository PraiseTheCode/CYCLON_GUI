namespace CYCLON
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoadSpec = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtB1 = new System.Windows.Forms.TextBox();
            this.btn_loadgrid = new System.Windows.Forms.Button();
            this.txtBN = new System.Windows.Forms.TextBox();
            this.txtStepB = new System.Windows.Forms.TextBox();
            this.txtTh1 = new System.Windows.Forms.TextBox();
            this.txtThN = new System.Windows.Forms.TextBox();
            this.txtThStep = new System.Windows.Forms.TextBox();
            this.txtSP1 = new System.Windows.Forms.TextBox();
            this.txtSPN = new System.Windows.Forms.TextBox();
            this.txtSPStep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.plot = new NPlot.Windows.PlotSurface2D();
            this.btnShSpec = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnShMod = new System.Windows.Forms.Button();
            this.lbTes = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbRes = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_PlCl = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.txtKrit = new System.Windows.Forms.TextBox();
            this.txtMaxIt = new System.Windows.Forms.TextBox();
            this.rbToHz = new System.Windows.Forms.RadioButton();
            this.rbToAn = new System.Windows.Forms.RadioButton();
            this.prb = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadSpec
            // 
            this.btnLoadSpec.Location = new System.Drawing.Point(12, 12);
            this.btnLoadSpec.Name = "btnLoadSpec";
            this.btnLoadSpec.Size = new System.Drawing.Size(140, 27);
            this.btnLoadSpec.TabIndex = 0;
            this.btnLoadSpec.Text = "Load spectrum";
            this.btnLoadSpec.UseVisualStyleBackColor = true;
            this.btnLoadSpec.Click += new System.EventHandler(this.btnLoadSpec_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtB1
            // 
            this.txtB1.Location = new System.Drawing.Point(31, 19);
            this.txtB1.Name = "txtB1";
            this.txtB1.Size = new System.Drawing.Size(64, 20);
            this.txtB1.TabIndex = 1;
            this.txtB1.Text = "20";
            // 
            // btn_loadgrid
            // 
            this.btn_loadgrid.Location = new System.Drawing.Point(12, 119);
            this.btn_loadgrid.Name = "btn_loadgrid";
            this.btn_loadgrid.Size = new System.Drawing.Size(140, 27);
            this.btn_loadgrid.TabIndex = 3;
            this.btn_loadgrid.Text = "Load grid";
            this.btn_loadgrid.UseVisualStyleBackColor = true;
            this.btn_loadgrid.Click += new System.EventHandler(this.btn_loadgrid_Click);
            // 
            // txtBN
            // 
            this.txtBN.Location = new System.Drawing.Point(136, 19);
            this.txtBN.Name = "txtBN";
            this.txtBN.Size = new System.Drawing.Size(64, 20);
            this.txtBN.TabIndex = 4;
            this.txtBN.Text = "50";
            // 
            // txtStepB
            // 
            this.txtStepB.Location = new System.Drawing.Point(242, 19);
            this.txtStepB.Name = "txtStepB";
            this.txtStepB.Size = new System.Drawing.Size(64, 20);
            this.txtStepB.TabIndex = 5;
            this.txtStepB.Text = "1";
            // 
            // txtTh1
            // 
            this.txtTh1.Location = new System.Drawing.Point(31, 50);
            this.txtTh1.Name = "txtTh1";
            this.txtTh1.Size = new System.Drawing.Size(64, 20);
            this.txtTh1.TabIndex = 7;
            this.txtTh1.Text = "30";
            // 
            // txtThN
            // 
            this.txtThN.Location = new System.Drawing.Point(136, 50);
            this.txtThN.Name = "txtThN";
            this.txtThN.Size = new System.Drawing.Size(64, 20);
            this.txtThN.TabIndex = 8;
            this.txtThN.Text = "90";
            // 
            // txtThStep
            // 
            this.txtThStep.Location = new System.Drawing.Point(242, 50);
            this.txtThStep.Name = "txtThStep";
            this.txtThStep.Size = new System.Drawing.Size(64, 20);
            this.txtThStep.TabIndex = 9;
            this.txtThStep.Text = "10";
            // 
            // txtSP1
            // 
            this.txtSP1.Location = new System.Drawing.Point(31, 83);
            this.txtSP1.Name = "txtSP1";
            this.txtSP1.Size = new System.Drawing.Size(64, 20);
            this.txtSP1.TabIndex = 10;
            this.txtSP1.Text = "2";
            // 
            // txtSPN
            // 
            this.txtSPN.Location = new System.Drawing.Point(136, 83);
            this.txtSPN.Name = "txtSPN";
            this.txtSPN.Size = new System.Drawing.Size(64, 20);
            this.txtSPN.TabIndex = 11;
            this.txtSPN.Text = "7";
            // 
            // txtSPStep
            // 
            this.txtSPStep.Location = new System.Drawing.Point(242, 83);
            this.txtSPStep.Name = "txtSPStep";
            this.txtSPStep.Size = new System.Drawing.Size(64, 20);
            this.txtSPStep.TabIndex = 12;
            this.txtSPStep.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 17;
            // 
            // plot
            // 
            this.plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plot.AutoScaleAutoGeneratedAxes = false;
            this.plot.AutoScaleTitle = false;
            this.plot.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plot.DateTimeToolTip = false;
            this.plot.Legend = null;
            this.plot.LegendZOrder = -1;
            this.plot.Location = new System.Drawing.Point(338, 12);
            this.plot.Name = "plot";
            this.plot.RightMenu = null;
            this.plot.ShowCoordinates = true;
            this.plot.Size = new System.Drawing.Size(676, 560);
            this.plot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plot.TabIndex = 20;
            this.plot.Text = "plotSurface2D1";
            this.plot.Title = "";
            this.plot.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plot.XAxis1 = null;
            this.plot.XAxis2 = null;
            this.plot.YAxis1 = null;
            this.plot.YAxis2 = null;
            // 
            // btnShSpec
            // 
            this.btnShSpec.Location = new System.Drawing.Point(12, 48);
            this.btnShSpec.Name = "btnShSpec";
            this.btnShSpec.Size = new System.Drawing.Size(140, 27);
            this.btnShSpec.TabIndex = 21;
            this.btnShSpec.Text = "Show observed spectrum";
            this.btnShSpec.UseVisualStyleBackColor = true;
            this.btnShSpec.Click += new System.EventHandler(this.btnShSpec_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(12, 330);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(312, 28);
            this.btnCalc.TabIndex = 22;
            this.btnCalc.Text = "Geronimo!";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnShMod
            // 
            this.btnShMod.Location = new System.Drawing.Point(12, 547);
            this.btnShMod.Name = "btnShMod";
            this.btnShMod.Size = new System.Drawing.Size(146, 28);
            this.btnShMod.TabIndex = 25;
            this.btnShMod.Text = "Show model spectrum";
            this.btnShMod.UseVisualStyleBackColor = true;
            this.btnShMod.Click += new System.EventHandler(this.btnShMod_Click);
            // 
            // lbTes
            // 
            this.lbTes.FormattingEnabled = true;
            this.lbTes.Location = new System.Drawing.Point(176, 12);
            this.lbTes.Name = "lbTes";
            this.lbTes.Size = new System.Drawing.Size(148, 108);
            this.lbTes.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(176, 547);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 28);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbRes
            // 
            this.lbRes.FormattingEnabled = true;
            this.lbRes.HorizontalScrollbar = true;
            this.lbRes.Location = new System.Drawing.Point(12, 400);
            this.lbRes.Name = "lbRes";
            this.lbRes.Size = new System.Drawing.Size(312, 134);
            this.lbRes.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 22);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(117, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 21);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(215, 50);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 23);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(215, 83);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 23);
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(215, 19);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 23);
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(1, 83);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(29, 25);
            this.pictureBox6.TabIndex = 34;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(103, 83);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(33, 20);
            this.pictureBox7.TabIndex = 35;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(14, 19);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(15, 25);
            this.pictureBox8.TabIndex = 36;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(116, 19);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(20, 27);
            this.pictureBox9.TabIndex = 37;
            this.pictureBox9.TabStop = false;
            // 
            // btn_PlCl
            // 
            this.btn_PlCl.Location = new System.Drawing.Point(12, 83);
            this.btn_PlCl.Name = "btn_PlCl";
            this.btn_PlCl.Size = new System.Drawing.Size(140, 27);
            this.btn_PlCl.TabIndex = 38;
            this.btn_PlCl.Text = "Clear plot";
            this.btn_PlCl.UseVisualStyleBackColor = true;
            this.btn_PlCl.Click += new System.EventHandler(this.btn_PlCl_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox11);
            this.groupBox1.Controls.Add(this.pictureBox10);
            this.groupBox1.Controls.Add(this.txtKrit);
            this.groupBox1.Controls.Add(this.txtMaxIt);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.txtB1);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtTh1);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.txtSPStep);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.txtSP1);
            this.groupBox1.Controls.Add(this.txtBN);
            this.groupBox1.Controls.Add(this.txtThStep);
            this.groupBox1.Controls.Add(this.txtThN);
            this.groupBox1.Controls.Add(this.txtSPN);
            this.groupBox1.Controls.Add(this.txtStepB);
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 169);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial parameters and optimization settings";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(26, 146);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(166, 22);
            this.pictureBox11.TabIndex = 41;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(55, 118);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(138, 20);
            this.pictureBox10.TabIndex = 40;
            this.pictureBox10.TabStop = false;
            // 
            // txtKrit
            // 
            this.txtKrit.Location = new System.Drawing.Point(194, 143);
            this.txtKrit.Name = "txtKrit";
            this.txtKrit.Size = new System.Drawing.Size(64, 20);
            this.txtKrit.TabIndex = 39;
            this.txtKrit.Text = "0,001";
            // 
            // txtMaxIt
            // 
            this.txtMaxIt.Location = new System.Drawing.Point(194, 115);
            this.txtMaxIt.Name = "txtMaxIt";
            this.txtMaxIt.Size = new System.Drawing.Size(64, 20);
            this.txtMaxIt.TabIndex = 38;
            this.txtMaxIt.Text = "50";
            // 
            // rbToHz
            // 
            this.rbToHz.AutoSize = true;
            this.rbToHz.Location = new System.Drawing.Point(254, 129);
            this.rbToHz.Name = "rbToHz";
            this.rbToHz.Size = new System.Drawing.Size(43, 17);
            this.rbToHz.TabIndex = 43;
            this.rbToHz.TabStop = true;
            this.rbToHz.Text = "/Hz";
            this.rbToHz.UseVisualStyleBackColor = true;
            // 
            // rbToAn
            // 
            this.rbToAn.AutoSize = true;
            this.rbToAn.Location = new System.Drawing.Point(198, 129);
            this.rbToAn.Name = "rbToAn";
            this.rbToAn.Size = new System.Drawing.Size(37, 17);
            this.rbToAn.TabIndex = 42;
            this.rbToAn.TabStop = true;
            this.rbToAn.Text = "/A";
            this.rbToAn.UseVisualStyleBackColor = true;
            // 
            // prb
            // 
            this.prb.Location = new System.Drawing.Point(12, 367);
            this.prb.Name = "prb";
            this.prb.Size = new System.Drawing.Size(312, 21);
            this.prb.TabIndex = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 584);
            this.Controls.Add(this.rbToHz);
            this.Controls.Add(this.prb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_PlCl);
            this.Controls.Add(this.rbToAn);
            this.Controls.Add(this.lbRes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTes);
            this.Controls.Add(this.btnShMod);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnShSpec);
            this.Controls.Add(this.plot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_loadgrid);
            this.Controls.Add(this.btnLoadSpec);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CYCLON";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadSpec;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtB1;
        private System.Windows.Forms.Button btn_loadgrid;
        private System.Windows.Forms.TextBox txtBN;
        private System.Windows.Forms.TextBox txtStepB;
        private System.Windows.Forms.TextBox txtTh1;
        private System.Windows.Forms.TextBox txtThN;
        private System.Windows.Forms.TextBox txtThStep;
        private System.Windows.Forms.TextBox txtSP1;
        private System.Windows.Forms.TextBox txtSPN;
        private System.Windows.Forms.TextBox txtSPStep;
        private System.Windows.Forms.Label label7;
        private NPlot.Windows.PlotSurface2D plot;
        private System.Windows.Forms.Button btnShSpec;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnShMod;
        private System.Windows.Forms.ListBox lbTes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lbRes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_PlCl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar prb;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox txtKrit;
        private System.Windows.Forms.TextBox txtMaxIt;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.RadioButton rbToHz;
        private System.Windows.Forms.RadioButton rbToAn;
    }
}

