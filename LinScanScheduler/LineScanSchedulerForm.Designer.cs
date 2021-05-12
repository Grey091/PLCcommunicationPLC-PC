namespace LinScanScheduler
{
    partial class LineScanSchedulerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineScanSchedulerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PLCPort = new System.IO.Ports.SerialPort(this.components);
            this.PLCTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.ScanDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.btnStatus1 = new System.Windows.Forms.Button();
            this.btnStatus2 = new System.Windows.Forms.Button();
            this.btnStatus3 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.GridBarcode = new System.Windows.Forms.DataGridView();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSetup = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ScanTimer = new System.Windows.Forms.Timer(this.components);
            this.DIOTimer = new System.Windows.Forms.Timer(this.components);
            this.btnOption = new System.Windows.Forms.Button();
            this.txtZPosition = new System.Windows.Forms.TextBox();
            this.txtXPosition = new System.Windows.Forms.TextBox();
            this.PLCGroup = new System.Windows.Forms.GroupBox();
            this.btnSetTrgOff = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.btnSetPosition = new System.Windows.Forms.Button();
            this.txtZSetPos = new System.Windows.Forms.TextBox();
            this.txtXSetPos = new System.Windows.Forms.TextBox();
            this.txtAck = new System.Windows.Forms.TextBox();
            this.txtSendCmd = new System.Windows.Forms.TextBox();
            this.txtReceiveData = new System.Windows.Forms.TextBox();
            this.txtPLCChannel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStartM = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnStatusM1 = new System.Windows.Forms.Button();
            this.btnStatusM2 = new System.Windows.Forms.Button();
            this.btnStatusM3 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtYPosition = new System.Windows.Forms.TextBox();
            this.LightComm = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ScanDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBarcode)).BeginInit();
            this.PLCGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // PLCPort
            // 
            this.PLCPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.PLCPort_DataReceived);
            // 
            // PLCTimeoutTimer
            // 
            this.PLCTimeoutTimer.Interval = 700;
            this.PLCTimeoutTimer.Tick += new System.EventHandler(this.PLCTimeoutTimer_Tick);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 1000;
            this.RefreshTimer.Tick += new System.EventHandler(this.Refresh_Tick);
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
            this.ScanDisplay.TabIndex = 11;
            // 
            // txtModelName
            // 
            this.txtModelName.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(10, 147);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(594, 81);
            this.txtModelName.TabIndex = 12;
            this.txtModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStatus1
            // 
            this.btnStatus1.Location = new System.Drawing.Point(10, 234);
            this.btnStatus1.Name = "btnStatus1";
            this.btnStatus1.Size = new System.Drawing.Size(189, 53);
            this.btnStatus1.TabIndex = 13;
            this.btnStatus1.Text = "PLC 1";
            this.btnStatus1.UseVisualStyleBackColor = true;
            this.btnStatus1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStatus2
            // 
            this.btnStatus2.Location = new System.Drawing.Point(212, 234);
            this.btnStatus2.Name = "btnStatus2";
            this.btnStatus2.Size = new System.Drawing.Size(189, 53);
            this.btnStatus2.TabIndex = 13;
            this.btnStatus2.Text = "PLC 2";
            this.btnStatus2.UseVisualStyleBackColor = true;
            this.btnStatus2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStatus3
            // 
            this.btnStatus3.Location = new System.Drawing.Point(415, 234);
            this.btnStatus3.Name = "btnStatus3";
            this.btnStatus3.Size = new System.Drawing.Size(189, 53);
            this.btnStatus3.TabIndex = 13;
            this.btnStatus3.Text = "PLC 3";
            this.btnStatus3.UseVisualStyleBackColor = true;
            this.btnStatus3.Click += new System.EventHandler(this.btnStatus3_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(10, 13);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(594, 128);
            this.btnOpen.TabIndex = 14;
            this.btnOpen.Text = "Load";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(12, 845);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(591, 124);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GridBarcode
            // 
            this.GridBarcode.ColumnHeadersHeight = 45;
            this.GridBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group,
            this.Barcode});
            this.GridBarcode.Location = new System.Drawing.Point(12, 436);
            this.GridBarcode.Name = "GridBarcode";
            this.GridBarcode.RowHeadersWidth = 20;
            this.GridBarcode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GridBarcode.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridBarcode.RowTemplate.Height = 23;
            this.GridBarcode.Size = new System.Drawing.Size(593, 124);
            this.GridBarcode.TabIndex = 15;
            this.GridBarcode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridBarcode_CellContentClick);
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Group.Width = 120;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Barcode.Width = 410;
            // 
            // btnSetup
            // 
            this.btnSetup.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.Location = new System.Drawing.Point(12, 744);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(295, 90);
            this.btnSetup.TabIndex = 16;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Setting File(*.stf)|*.stf|All Files (*.*)|*.*";
            // 
            // ScanTimer
            // 
            this.ScanTimer.Interval = 200;
            this.ScanTimer.Tick += new System.EventHandler(this.ScanTimer_Tick);
            // 
            // DIOTimer
            // 
            this.DIOTimer.Interval = 300;
            this.DIOTimer.Tick += new System.EventHandler(this.DIOTimer_Tick);
            // 
            // btnOption
            // 
            this.btnOption.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOption.Location = new System.Drawing.Point(309, 744);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(295, 90);
            this.btnOption.TabIndex = 17;
            this.btnOption.Text = "Option";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // txtZPosition
            // 
            this.txtZPosition.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZPosition.Location = new System.Drawing.Point(267, 679);
            this.txtZPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtZPosition.Name = "txtZPosition";
            this.txtZPosition.Size = new System.Drawing.Size(82, 39);
            this.txtZPosition.TabIndex = 19;
            // 
            // txtXPosition
            // 
            this.txtXPosition.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXPosition.Location = new System.Drawing.Point(267, 586);
            this.txtXPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXPosition.Name = "txtXPosition";
            this.txtXPosition.Size = new System.Drawing.Size(82, 39);
            this.txtXPosition.TabIndex = 18;
            this.txtXPosition.TextChanged += new System.EventHandler(this.txtXPosition_TextChanged);
            // 
            // PLCGroup
            // 
            this.PLCGroup.Controls.Add(this.btnSetTrgOff);
            this.PLCGroup.Controls.Add(this.btnTrigger);
            this.PLCGroup.Controls.Add(this.btnSetPosition);
            this.PLCGroup.Controls.Add(this.txtZSetPos);
            this.PLCGroup.Controls.Add(this.txtXSetPos);
            this.PLCGroup.Controls.Add(this.txtAck);
            this.PLCGroup.Controls.Add(this.txtSendCmd);
            this.PLCGroup.Controls.Add(this.txtReceiveData);
            this.PLCGroup.Controls.Add(this.txtPLCChannel);
            this.PLCGroup.Controls.Add(this.label7);
            this.PLCGroup.Controls.Add(this.btnSave);
            this.PLCGroup.Controls.Add(this.btnStartM);
            this.PLCGroup.Controls.Add(this.btnStart);
            this.PLCGroup.Controls.Add(this.txtDWriteAddr);
            this.PLCGroup.Controls.Add(this.txtMWriteAddr);
            this.PLCGroup.Controls.Add(this.txtMReadAddr);
            this.PLCGroup.Controls.Add(this.txtDReadAddr);
            this.PLCGroup.Controls.Add(this.label5);
            this.PLCGroup.Controls.Add(this.label6);
            this.PLCGroup.Controls.Add(this.label4);
            this.PLCGroup.Controls.Add(this.label3);
            this.PLCGroup.Controls.Add(this.txtBaudRate);
            this.PLCGroup.Controls.Add(this.label2);
            this.PLCGroup.Controls.Add(this.txtPLCPort);
            this.PLCGroup.Controls.Add(this.label1);
            this.PLCGroup.Location = new System.Drawing.Point(630, 328);
            this.PLCGroup.Name = "PLCGroup";
            this.PLCGroup.Size = new System.Drawing.Size(364, 387);
            this.PLCGroup.TabIndex = 20;
            this.PLCGroup.TabStop = false;
            this.PLCGroup.Text = "PLC";
            this.PLCGroup.Visible = false;
            // 
            // btnSetTrgOff
            // 
            this.btnSetTrgOff.Location = new System.Drawing.Point(255, 282);
            this.btnSetTrgOff.Name = "btnSetTrgOff";
            this.btnSetTrgOff.Size = new System.Drawing.Size(72, 25);
            this.btnSetTrgOff.TabIndex = 19;
            this.btnSetTrgOff.Text = "Set Trg";
            this.btnSetTrgOff.UseVisualStyleBackColor = true;
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(255, 249);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(72, 25);
            this.btnTrigger.TabIndex = 19;
            this.btnTrigger.Text = "Set Trg";
            this.btnTrigger.UseVisualStyleBackColor = true;
            // 
            // btnSetPosition
            // 
            this.btnSetPosition.Location = new System.Drawing.Point(177, 249);
            this.btnSetPosition.Name = "btnSetPosition";
            this.btnSetPosition.Size = new System.Drawing.Size(72, 25);
            this.btnSetPosition.TabIndex = 19;
            this.btnSetPosition.Text = "Set Position";
            this.btnSetPosition.UseVisualStyleBackColor = true;
            // 
            // txtZSetPos
            // 
            this.txtZSetPos.Location = new System.Drawing.Point(99, 249);
            this.txtZSetPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtZSetPos.Name = "txtZSetPos";
            this.txtZSetPos.Size = new System.Drawing.Size(76, 20);
            this.txtZSetPos.TabIndex = 18;
            // 
            // txtXSetPos
            // 
            this.txtXSetPos.Location = new System.Drawing.Point(15, 249);
            this.txtXSetPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXSetPos.Name = "txtXSetPos";
            this.txtXSetPos.Size = new System.Drawing.Size(76, 20);
            this.txtXSetPos.TabIndex = 17;
            // 
            // txtAck
            // 
            this.txtAck.Location = new System.Drawing.Point(15, 174);
            this.txtAck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAck.Name = "txtAck";
            this.txtAck.Size = new System.Drawing.Size(25, 20);
            this.txtAck.TabIndex = 14;
            // 
            // txtSendCmd
            // 
            this.txtSendCmd.Location = new System.Drawing.Point(15, 147);
            this.txtSendCmd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSendCmd.Name = "txtSendCmd";
            this.txtSendCmd.Size = new System.Drawing.Size(335, 20);
            this.txtSendCmd.TabIndex = 13;
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.Location = new System.Drawing.Point(42, 174);
            this.txtReceiveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.Size = new System.Drawing.Size(308, 20);
            this.txtReceiveData.TabIndex = 13;
            // 
            // txtPLCChannel
            // 
            this.txtPLCChannel.Location = new System.Drawing.Point(87, 116);
            this.txtPLCChannel.Name = "txtPLCChannel";
            this.txtPLCChannel.Size = new System.Drawing.Size(84, 20);
            this.txtPLCChannel.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "PLC Channel";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(201, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 25);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStartM
            // 
            this.btnStartM.Location = new System.Drawing.Point(278, 116);
            this.btnStartM.Name = "btnStartM";
            this.btnStartM.Size = new System.Drawing.Size(72, 25);
            this.btnStartM.TabIndex = 9;
            this.btnStartM.Text = "Start M";
            this.btnStartM.UseVisualStyleBackColor = true;
            this.btnStartM.Click += new System.EventHandler(this.btnStartM_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(279, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 25);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "c";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtDWriteAddr
            // 
            this.txtDWriteAddr.Location = new System.Drawing.Point(99, 85);
            this.txtDWriteAddr.Name = "txtDWriteAddr";
            this.txtDWriteAddr.Size = new System.Drawing.Size(73, 20);
            this.txtDWriteAddr.TabIndex = 8;
            // 
            // txtMWriteAddr
            // 
            this.txtMWriteAddr.Location = new System.Drawing.Point(279, 85);
            this.txtMWriteAddr.Name = "txtMWriteAddr";
            this.txtMWriteAddr.Size = new System.Drawing.Size(73, 20);
            this.txtMWriteAddr.TabIndex = 8;
            // 
            // txtMReadAddr
            // 
            this.txtMReadAddr.Location = new System.Drawing.Point(279, 54);
            this.txtMReadAddr.Name = "txtMReadAddr";
            this.txtMReadAddr.Size = new System.Drawing.Size(73, 20);
            this.txtMReadAddr.TabIndex = 8;
            // 
            // txtDReadAddr
            // 
            this.txtDReadAddr.Location = new System.Drawing.Point(99, 54);
            this.txtDReadAddr.Name = "txtDReadAddr";
            this.txtDReadAddr.Size = new System.Drawing.Size(73, 20);
            this.txtDReadAddr.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "M 영역 쓰기주소";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "M 영역 읽기주소";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "D 영역 쓰기주소";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "D 영역 읽기주소";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(139, 22);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(55, 20);
            this.txtBaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BaudRate";
            // 
            // txtPLCPort
            // 
            this.txtPLCPort.Location = new System.Drawing.Point(42, 22);
            this.txtPLCPort.Name = "txtPLCPort";
            this.txtPLCPort.Size = new System.Drawing.Size(34, 20);
            this.txtPLCPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(176, 688);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Z Pos. :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(174, 595);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "X Pos. :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // cogDisplayStatusBarV21
            // 
            this.cogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarV21.Location = new System.Drawing.Point(612, 948);
            this.cogDisplayStatusBarV21.Name = "cogDisplayStatusBarV21";
            this.cogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarV21.Size = new System.Drawing.Size(1280, 27);
            this.cogDisplayStatusBarV21.TabIndex = 23;
            this.cogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(354, 596);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "mm";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(354, 688);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 25);
            this.label11.TabIndex = 25;
            this.label11.Text = "mm";
            // 
            // btnResult
            // 
            this.btnResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.Location = new System.Drawing.Point(10, 352);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(594, 78);
            this.btnResult.TabIndex = 26;
            this.btnResult.UseVisualStyleBackColor = true;
            // 
            // btnStatusM1
            // 
            this.btnStatusM1.Location = new System.Drawing.Point(10, 293);
            this.btnStatusM1.Name = "btnStatusM1";
            this.btnStatusM1.Size = new System.Drawing.Size(189, 53);
            this.btnStatusM1.TabIndex = 27;
            this.btnStatusM1.Text = "PC 1";
            this.btnStatusM1.UseVisualStyleBackColor = true;
            this.btnStatusM1.Click += new System.EventHandler(this.btnStatusM1_Click);
            // 
            // btnStatusM2
            // 
            this.btnStatusM2.Location = new System.Drawing.Point(212, 293);
            this.btnStatusM2.Name = "btnStatusM2";
            this.btnStatusM2.Size = new System.Drawing.Size(189, 53);
            this.btnStatusM2.TabIndex = 28;
            this.btnStatusM2.Text = "PC 2";
            this.btnStatusM2.UseVisualStyleBackColor = true;
            // 
            // btnStatusM3
            // 
            this.btnStatusM3.Location = new System.Drawing.Point(415, 293);
            this.btnStatusM3.Name = "btnStatusM3";
            this.btnStatusM3.Size = new System.Drawing.Size(189, 53);
            this.btnStatusM3.TabIndex = 29;
            this.btnStatusM3.Text = "PC 3";
            this.btnStatusM3.UseVisualStyleBackColor = true;
            this.btnStatusM3.Click += new System.EventHandler(this.btnStatusM3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(354, 641);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 25);
            this.label12.TabIndex = 32;
            this.label12.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(174, 641);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 25);
            this.label13.TabIndex = 31;
            this.label13.Text = "Y Pos. :";
            // 
            // txtYPosition
            // 
            this.txtYPosition.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYPosition.Location = new System.Drawing.Point(267, 632);
            this.txtYPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtYPosition.Name = "txtYPosition";
            this.txtYPosition.Size = new System.Drawing.Size(82, 39);
            this.txtYPosition.TabIndex = 30;
            // 
            // LightComm
            // 
            this.LightComm.BaudRate = 19200;
            // 
            // LineScanSchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1904, 981);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtYPosition);
            this.Controls.Add(this.btnStatusM3);
            this.Controls.Add(this.btnStatusM2);
            this.Controls.Add(this.btnStatusM1);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cogDisplayStatusBarV21);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PLCGroup);
            this.Controls.Add(this.txtZPosition);
            this.Controls.Add(this.txtXPosition);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.GridBarcode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnStatus3);
            this.Controls.Add(this.btnStatus2);
            this.Controls.Add(this.btnStatus1);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.ScanDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LineScanSchedulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line Scan Scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineScanSchedulerForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LineScanSchedulerForm_FormClosed);
            this.Load += new System.EventHandler(this.LineScanSchedulerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScanDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBarcode)).EndInit();
            this.PLCGroup.ResumeLayout(false);
            this.PLCGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort PLCPort;
        private System.Windows.Forms.Timer PLCTimeoutTimer;
        private System.Windows.Forms.Timer RefreshTimer;
        private Cognex.VisionPro.Display.CogDisplay ScanDisplay;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Button btnStatus1;
        private System.Windows.Forms.Button btnStatus2;
        private System.Windows.Forms.Button btnStatus3;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView GridBarcode;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer ScanTimer;
        private System.Windows.Forms.Timer DIOTimer;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.TextBox txtZPosition;
        private System.Windows.Forms.TextBox txtXPosition;
        private System.Windows.Forms.GroupBox PLCGroup;
        private System.Windows.Forms.Button btnSetTrgOff;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Button btnSetPosition;
        private System.Windows.Forms.TextBox txtZSetPos;
        private System.Windows.Forms.TextBox txtXSetPos;
        private System.Windows.Forms.TextBox txtAck;
        private System.Windows.Forms.TextBox txtSendCmd;
        private System.Windows.Forms.TextBox txtReceiveData;
        private System.Windows.Forms.TextBox txtPLCChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStartM;
        private System.Windows.Forms.Button btnStart;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarV21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnStatusM1;
        private System.Windows.Forms.Button btnStatusM2;
        private System.Windows.Forms.Button btnStatusM3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtYPosition;
        private System.IO.Ports.SerialPort LightComm;
    }
}

