namespace LinScanScheduler
{
    partial class BarcodeSetupForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeSetupForm));
            this.ScanDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsertGroup = new System.Windows.Forms.Button();
            this.cbGroupList = new System.Windows.Forms.ComboBox();
            this.gridRectList = new System.Windows.Forms.DataGridView();
            this.BarcodeRect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image_Timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.txtZPos = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReadPosition = new System.Windows.Forms.Button();
            this.BarcodeReadTimer = new System.Windows.Forms.Timer(this.components);
            this.btnICT = new System.Windows.Forms.Button();
            this.btnFCT = new System.Windows.Forms.Button();
            this.cogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSetZPos = new System.Windows.Forms.TextBox();
            this.txtSetXPos = new System.Windows.Forms.TextBox();
            this.btnSetPos = new System.Windows.Forms.Button();
            this.chkEditMode = new System.Windows.Forms.CheckBox();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.txtSetYPos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScanDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRectList)).BeginInit();
            this.SuspendLayout();
            // 
            // ScanDisplay
            // 
            this.ScanDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.ScanDisplay.ColorMapLowerRoiLimit = 0D;
            this.ScanDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.ScanDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.ScanDisplay.ColorMapUpperRoiLimit = 1D;
            this.ScanDisplay.DoubleTapZoomCycleLength = 2;
            this.ScanDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.ScanDisplay.Location = new System.Drawing.Point(612, 12);
            this.ScanDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.ScanDisplay.MouseWheelSensitivity = 1D;
            this.ScanDisplay.Name = "ScanDisplay";
            this.ScanDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ScanDisplay.OcxState")));
            this.ScanDisplay.Size = new System.Drawing.Size(1280, 930);
            this.ScanDisplay.TabIndex = 12;
            this.ScanDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScanDisplay_MouseDown);
            this.ScanDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScanDisplay_MouseUp);
            this.ScanDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScanDisplay_MouseMove);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(308, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(290, 125);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsertGroup
            // 
            this.btnInsertGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertGroup.Location = new System.Drawing.Point(308, 144);
            this.btnInsertGroup.Name = "btnInsertGroup";
            this.btnInsertGroup.Size = new System.Drawing.Size(142, 43);
            this.btnInsertGroup.TabIndex = 14;
            this.btnInsertGroup.Text = "Insert Group";
            this.btnInsertGroup.UseVisualStyleBackColor = true;
            this.btnInsertGroup.Click += new System.EventHandler(this.btnInsertGroup_Click);
            // 
            // cbGroupList
            // 
            this.cbGroupList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGroupList.FormattingEnabled = true;
            this.cbGroupList.Location = new System.Drawing.Point(251, 149);
            this.cbGroupList.Name = "cbGroupList";
            this.cbGroupList.Size = new System.Drawing.Size(51, 32);
            this.cbGroupList.TabIndex = 15;
            this.cbGroupList.DropDownClosed += new System.EventHandler(this.cbGroupList_DropDownClosed);
            // 
            // gridRectList
            // 
            this.gridRectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRectList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BarcodeRect,
            this.Barcode});
            this.gridRectList.Location = new System.Drawing.Point(12, 194);
            this.gridRectList.Name = "gridRectList";
            this.gridRectList.RowHeadersWidth = 30;
            this.gridRectList.RowTemplate.Height = 23;
            this.gridRectList.Size = new System.Drawing.Size(586, 119);
            this.gridRectList.TabIndex = 16;
            this.gridRectList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRectList_CellContentClick);
            // 
            // BarcodeRect
            // 
            this.BarcodeRect.HeaderText = "Rect";
            this.BarcodeRect.Name = "BarcodeRect";
            this.BarcodeRect.Width = 200;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.Width = 350;
            // 
            // Image_Timer
            // 
            this.Image_Timer.Enabled = true;
            this.Image_Timer.Tick += new System.EventHandler(this.Image_Timer_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Setting File(*.stf)|*.stf|All Files (*.*)|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Group Index :";
            // 
            // btnBarcode
            // 
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.Location = new System.Drawing.Point(12, 320);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(586, 60);
            this.btnBarcode.TabIndex = 18;
            this.btnBarcode.Text = "Barcode Read Start";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // txtXPos
            // 
            this.txtXPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtXPos.Location = new System.Drawing.Point(158, 457);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.ReadOnly = true;
            this.txtXPos.Size = new System.Drawing.Size(140, 38);
            this.txtXPos.TabIndex = 19;
            // 
            // txtZPos
            // 
            this.txtZPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtZPos.Location = new System.Drawing.Point(158, 546);
            this.txtZPos.Name = "txtZPos";
            this.txtZPos.ReadOnly = true;
            this.txtZPos.Size = new System.Drawing.Size(140, 38);
            this.txtZPos.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(12, 872);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(586, 97);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.Location = new System.Drawing.Point(12, 13);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(290, 125);
            this.btnSaveAs.TabIndex = 20;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(62, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "X Pos :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(62, 551);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Z Pos :";
            // 
            // btnReadPosition
            // 
            this.btnReadPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadPosition.Location = new System.Drawing.Point(12, 386);
            this.btnReadPosition.Name = "btnReadPosition";
            this.btnReadPosition.Size = new System.Drawing.Size(586, 60);
            this.btnReadPosition.TabIndex = 18;
            this.btnReadPosition.Text = "Read Position";
            this.btnReadPosition.UseVisualStyleBackColor = true;
            this.btnReadPosition.Click += new System.EventHandler(this.btnReadPosition_Click);
            // 
            // BarcodeReadTimer
            // 
            this.BarcodeReadTimer.Interval = 250;
            this.BarcodeReadTimer.Tick += new System.EventHandler(this.BarcodeReadTimer_Tick);
            // 
            // btnICT
            // 
            this.btnICT.Location = new System.Drawing.Point(12, 799);
            this.btnICT.Name = "btnICT";
            this.btnICT.Size = new System.Drawing.Size(290, 67);
            this.btnICT.TabIndex = 22;
            this.btnICT.Text = "ICT";
            this.btnICT.UseVisualStyleBackColor = true;
            this.btnICT.Visible = false;
            this.btnICT.Click += new System.EventHandler(this.btnICT_Click);
            // 
            // btnFCT
            // 
            this.btnFCT.Location = new System.Drawing.Point(308, 799);
            this.btnFCT.Name = "btnFCT";
            this.btnFCT.Size = new System.Drawing.Size(290, 67);
            this.btnFCT.TabIndex = 22;
            this.btnFCT.Text = "FCT";
            this.btnFCT.UseVisualStyleBackColor = true;
            this.btnFCT.Visible = false;
            this.btnFCT.Click += new System.EventHandler(this.btnFCT_Click);
            // 
            // cogDisplayStatusBarV21
            // 
            this.cogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarV21.Location = new System.Drawing.Point(612, 950);
            this.cogDisplayStatusBarV21.Name = "cogDisplayStatusBarV21";
            this.cogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarV21.Size = new System.Drawing.Size(1280, 24);
            this.cogDisplayStatusBarV21.TabIndex = 24;
            this.cogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(62, 754);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "Z Pos :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(62, 666);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "X Pos :";
            // 
            // txtSetZPos
            // 
            this.txtSetZPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSetZPos.Location = new System.Drawing.Point(157, 748);
            this.txtSetZPos.Name = "txtSetZPos";
            this.txtSetZPos.Size = new System.Drawing.Size(140, 38);
            this.txtSetZPos.TabIndex = 27;
            // 
            // txtSetXPos
            // 
            this.txtSetXPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSetXPos.Location = new System.Drawing.Point(157, 660);
            this.txtSetXPos.Name = "txtSetXPos";
            this.txtSetXPos.Size = new System.Drawing.Size(140, 38);
            this.txtSetXPos.TabIndex = 26;
            // 
            // btnSetPos
            // 
            this.btnSetPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPos.Location = new System.Drawing.Point(12, 590);
            this.btnSetPos.Name = "btnSetPos";
            this.btnSetPos.Size = new System.Drawing.Size(586, 60);
            this.btnSetPos.TabIndex = 25;
            this.btnSetPos.Text = "Set Position";
            this.btnSetPos.UseVisualStyleBackColor = true;
            this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
            // 
            // chkEditMode
            // 
            this.chkEditMode.AutoSize = true;
            this.chkEditMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEditMode.Location = new System.Drawing.Point(12, 152);
            this.chkEditMode.Name = "chkEditMode";
            this.chkEditMode.Size = new System.Drawing.Size(100, 24);
            this.chkEditMode.TabIndex = 30;
            this.chkEditMode.Text = "Edit Mode";
            this.chkEditMode.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGroup.Location = new System.Drawing.Point(456, 143);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(142, 43);
            this.btnDeleteGroup.TabIndex = 31;
            this.btnDeleteGroup.Text = "Delete Group";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // txtSetYPos
            // 
            this.txtSetYPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSetYPos.Location = new System.Drawing.Point(157, 704);
            this.txtSetYPos.Name = "txtSetYPos";
            this.txtSetYPos.Size = new System.Drawing.Size(140, 38);
            this.txtSetYPos.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(62, 710);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 29);
            this.label6.TabIndex = 28;
            this.label6.Text = "Y Pos :";
            // 
            // txtYPos
            // 
            this.txtYPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtYPos.Location = new System.Drawing.Point(158, 501);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.ReadOnly = true;
            this.txtYPos.Size = new System.Drawing.Size(140, 38);
            this.txtYPos.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(62, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 29);
            this.label7.TabIndex = 21;
            this.label7.Text = "Y Pos :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(304, 510);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 25);
            this.label12.TabIndex = 35;
            this.label12.Text = "mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(304, 554);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 25);
            this.label11.TabIndex = 34;
            this.label11.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(304, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(304, 713);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 25);
            this.label8.TabIndex = 38;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(303, 757);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 25);
            this.label9.TabIndex = 37;
            this.label9.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(304, 669);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 25);
            this.label13.TabIndex = 36;
            this.label13.Text = "mm";
            // 
            // BarcodeSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1904, 981);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDeleteGroup);
            this.Controls.Add(this.chkEditMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSetYPos);
            this.Controls.Add(this.txtSetZPos);
            this.Controls.Add(this.txtSetXPos);
            this.Controls.Add(this.btnSetPos);
            this.Controls.Add(this.cogDisplayStatusBarV21);
            this.Controls.Add(this.btnFCT);
            this.Controls.Add(this.btnICT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.txtYPos);
            this.Controls.Add(this.txtZPos);
            this.Controls.Add(this.txtXPos);
            this.Controls.Add(this.btnReadPosition);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridRectList);
            this.Controls.Add(this.cbGroupList);
            this.Controls.Add(this.btnInsertGroup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ScanDisplay);
            this.Name = "BarcodeSetupForm";
            this.Text = "BarcodeSetupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeSetupForm_FormClosing);
            this.Load += new System.EventHandler(this.BarcodeSetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScanDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.Display.CogDisplay ScanDisplay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsertGroup;
        private System.Windows.Forms.ComboBox cbGroupList;
        private System.Windows.Forms.DataGridView gridRectList;
        private System.Windows.Forms.Timer Image_Timer;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.TextBox txtZPos;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReadPosition;
        private System.Windows.Forms.Timer BarcodeReadTimer;
        private System.Windows.Forms.Button btnICT;
        private System.Windows.Forms.Button btnFCT;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarV21;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeRect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSetZPos;
        private System.Windows.Forms.TextBox txtSetXPos;
        private System.Windows.Forms.Button btnSetPos;
        private System.Windows.Forms.CheckBox chkEditMode;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.TextBox txtSetYPos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
    }
}