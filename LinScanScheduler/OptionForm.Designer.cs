namespace LinScanScheduler
{
    partial class OptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLightCommPort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDBCheck2 = new System.Windows.Forms.CheckBox();
            this.chkDBCheck1 = new System.Windows.Forms.CheckBox();
            this.txtDBIPAddress = new System.Windows.Forms.TextBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.txtDBID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPLCChannel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDWriteAddr = new System.Windows.Forms.TextBox();
            this.txtMWriteAddr = new System.Windows.Forms.TextBox();
            this.txtMReadAddr = new System.Windows.Forms.TextBox();
            this.txtDReadAddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPLCPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkSaveImage = new System.Windows.Forms.CheckBox();
            this.chkNoLabel = new System.Windows.Forms.CheckBox();
            this.btnFCT = new System.Windows.Forms.Button();
            this.btnICT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 605);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(272, 37);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLightCommPort);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 59);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light";
            // 
            // txtLightCommPort
            // 
            this.txtLightCommPort.Location = new System.Drawing.Point(139, 22);
            this.txtLightCommPort.Name = "txtLightCommPort";
            this.txtLightCommPort.Size = new System.Drawing.Size(111, 20);
            this.txtLightCommPort.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Light Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDBCheck2);
            this.groupBox2.Controls.Add(this.chkDBCheck1);
            this.groupBox2.Controls.Add(this.txtDBIPAddress);
            this.groupBox2.Controls.Add(this.txtDBPassword);
            this.groupBox2.Controls.Add(this.txtDBID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(10, 431);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 156);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Watching Server";
            // 
            // chkDBCheck2
            // 
            this.chkDBCheck2.AutoSize = true;
            this.chkDBCheck2.Location = new System.Drawing.Point(141, 119);
            this.chkDBCheck2.Name = "chkDBCheck2";
            this.chkDBCheck2.Size = new System.Drawing.Size(91, 17);
            this.chkDBCheck2.TabIndex = 54;
            this.chkDBCheck2.Text = "Repair Check";
            this.chkDBCheck2.UseVisualStyleBackColor = true;
            // 
            // chkDBCheck1
            // 
            this.chkDBCheck1.AutoSize = true;
            this.chkDBCheck1.Location = new System.Drawing.Point(18, 119);
            this.chkDBCheck1.Name = "chkDBCheck1";
            this.chkDBCheck1.Size = new System.Drawing.Size(117, 17);
            this.chkDBCheck1.TabIndex = 53;
            this.chkDBCheck1.Text = "Pre Process Check";
            this.chkDBCheck1.UseVisualStyleBackColor = true;
            // 
            // txtDBIPAddress
            // 
            this.txtDBIPAddress.Location = new System.Drawing.Point(141, 79);
            this.txtDBIPAddress.Name = "txtDBIPAddress";
            this.txtDBIPAddress.Size = new System.Drawing.Size(111, 20);
            this.txtDBIPAddress.TabIndex = 52;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(141, 53);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(111, 20);
            this.txtDBPassword.TabIndex = 51;
            // 
            // txtDBID
            // 
            this.txtDBID.Location = new System.Drawing.Point(141, 27);
            this.txtDBID.Name = "txtDBID";
            this.txtDBID.Size = new System.Drawing.Size(111, 20);
            this.txtDBID.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "DB Server IP Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "DB Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "DB ID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPLCChannel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtDWriteAddr);
            this.groupBox3.Controls.Add(this.txtMWriteAddr);
            this.groupBox3.Controls.Add(this.txtMReadAddr);
            this.groupBox3.Controls.Add(this.txtDReadAddr);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBaudRate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtPLCPort);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(10, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 237);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PLC";
            // 
            // txtPLCChannel
            // 
            this.txtPLCChannel.Location = new System.Drawing.Point(141, 78);
            this.txtPLCChannel.Name = "txtPLCChannel";
            this.txtPLCChannel.Size = new System.Drawing.Size(111, 20);
            this.txtPLCChannel.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "PLC Channel";
            // 
            // txtDWriteAddr
            // 
            this.txtDWriteAddr.Location = new System.Drawing.Point(141, 138);
            this.txtDWriteAddr.Name = "txtDWriteAddr";
            this.txtDWriteAddr.Size = new System.Drawing.Size(111, 20);
            this.txtDWriteAddr.TabIndex = 46;
            // 
            // txtMWriteAddr
            // 
            this.txtMWriteAddr.Location = new System.Drawing.Point(141, 199);
            this.txtMWriteAddr.Name = "txtMWriteAddr";
            this.txtMWriteAddr.Size = new System.Drawing.Size(111, 20);
            this.txtMWriteAddr.TabIndex = 45;
            // 
            // txtMReadAddr
            // 
            this.txtMReadAddr.Location = new System.Drawing.Point(141, 167);
            this.txtMReadAddr.Name = "txtMReadAddr";
            this.txtMReadAddr.Size = new System.Drawing.Size(111, 20);
            this.txtMReadAddr.TabIndex = 48;
            // 
            // txtDReadAddr
            // 
            this.txtDReadAddr.Location = new System.Drawing.Point(141, 107);
            this.txtDReadAddr.Name = "txtDReadAddr";
            this.txtDReadAddr.Size = new System.Drawing.Size(111, 20);
            this.txtDReadAddr.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "M Area Write Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "M Area Read Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "D Area Write Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "D Area Read Address";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(141, 49);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(111, 20);
            this.txtBaudRate.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "BaudRate";
            // 
            // txtPLCPort
            // 
            this.txtPLCPort.Location = new System.Drawing.Point(141, 20);
            this.txtPLCPort.Name = "txtPLCPort";
            this.txtPLCPort.Size = new System.Drawing.Size(111, 20);
            this.txtPLCPort.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "PLC Port";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkSaveImage);
            this.groupBox4.Controls.Add(this.chkNoLabel);
            this.groupBox4.Controls.Add(this.btnFCT);
            this.groupBox4.Controls.Add(this.btnICT);
            this.groupBox4.Location = new System.Drawing.Point(10, 322);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 103);
            this.groupBox4.TabIndex = 52;
            this.groupBox4.TabStop = false;
            // 
            // chkSaveImage
            // 
            this.chkSaveImage.AutoSize = true;
            this.chkSaveImage.Location = new System.Drawing.Point(141, 77);
            this.chkSaveImage.Name = "chkSaveImage";
            this.chkSaveImage.Size = new System.Drawing.Size(130, 17);
            this.chkSaveImage.TabIndex = 52;
            this.chkSaveImage.Text = "Save Scan Fail Image";
            this.chkSaveImage.UseVisualStyleBackColor = true;
            // 
            // chkNoLabel
            // 
            this.chkNoLabel.AutoSize = true;
            this.chkNoLabel.Location = new System.Drawing.Point(18, 77);
            this.chkNoLabel.Name = "chkNoLabel";
            this.chkNoLabel.Size = new System.Drawing.Size(95, 17);
            this.chkNoLabel.TabIndex = 51;
            this.chkNoLabel.Text = "No Label Pass";
            this.chkNoLabel.UseVisualStyleBackColor = true;
            // 
            // btnFCT
            // 
            this.btnFCT.Location = new System.Drawing.Point(141, 22);
            this.btnFCT.Name = "btnFCT";
            this.btnFCT.Size = new System.Drawing.Size(111, 49);
            this.btnFCT.TabIndex = 50;
            this.btnFCT.Text = "FCT";
            this.btnFCT.UseVisualStyleBackColor = true;
            this.btnFCT.Click += new System.EventHandler(this.btnFCT_Click);
            // 
            // btnICT
            // 
            this.btnICT.Location = new System.Drawing.Point(18, 22);
            this.btnICT.Name = "btnICT";
            this.btnICT.Size = new System.Drawing.Size(111, 49);
            this.btnICT.TabIndex = 49;
            this.btnICT.Text = "ICT";
            this.btnICT.UseVisualStyleBackColor = true;
            this.btnICT.Click += new System.EventHandler(this.btnICT_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(292, 651);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Name = "OptionForm";
            this.Text = "OptionForm";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLightCommPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDBCheck2;
        private System.Windows.Forms.CheckBox chkDBCheck1;
        private System.Windows.Forms.TextBox txtDBIPAddress;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.TextBox txtDBID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPLCChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDWriteAddr;
        private System.Windows.Forms.TextBox txtMWriteAddr;
        private System.Windows.Forms.TextBox txtMReadAddr;
        private System.Windows.Forms.TextBox txtDReadAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPLCPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkSaveImage;
        private System.Windows.Forms.CheckBox chkNoLabel;
        private System.Windows.Forms.Button btnFCT;
        private System.Windows.Forms.Button btnICT;
    }
}