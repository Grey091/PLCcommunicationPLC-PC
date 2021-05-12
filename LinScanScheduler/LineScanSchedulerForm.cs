using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.IO.Ports;
using System.Collections;
using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.FGGigE.Implementation.Internal;
using System.Net;
using System.Net.Sockets;
using AsyncSocket;
using System.Data.OleDb;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;


namespace LinScanScheduler
{


    public partial class LineScanSchedulerForm : Form
    {
        #region fields
        public string m_strLightPort = "COM4";
        public int m_nScanIndex = 0;
        public bool m_bWritePLCData = false;
        public string m_strSendPLCDReadCMD = "";
        public string m_strSendPLCMReadCMD = "";
        public string m_strSendPLCDWriteCMD = "";
        public string m_strSendPLCMWriteCMD = ""; 
        public string m_strPLCReadMAddress = "1000";
        public string m_strPLCReadDAddress = "1000";
        public string m_strPLCWriteMAddress = "1100";
        public string m_strPLCWriteDAddress = "1100";
        public string m_strSetupINIFile = "";
        public string m_strPLCPort = "COM1";
        public string m_strPLCBaudrate = "9600";
        public string m_strPLCChannel = "01";
        public int m_nPLCSendSeq = 0;
        public bool m_bExit = false;
        public string m_strReceiveString = "";
        public string m_strAck= "";
        public ArrayList m_PLCQueue = new ArrayList();
        public static EventWaitHandle _WaitPLCResponseHandle;
        public string m_strModelFileName = "";
        public Cognex.VisionPro.ICogAcqFifo _acqFifo1 = null;
        public string[] m_strBarcode = null;// = new string[6];
        public PLCInterface m_PLC = new PLCInterface();
        public string m_strXPos = "";
        public string m_strYPos = "";
        public string m_strZPos = "";
        public string m_strCurrXPos = "";
        public string m_strCurrYPos = "";
        public string m_strCurrZPos = "";
        public ModelData m_ModelData = new ModelData();
        public NIDAQInterface m_NiDaq = new NIDAQInterface();
        private AsyncSocketServer server;
        private List<AsyncSocketClient> clientList;
        private int m_nid;
        public int m_nMode;
        public int[] m_arrBufferStatus = new int[3];
        public string m_strQuery1 = "";
        public string m_strQuery2 = "";
        public string m_strDBID = "sa";
        public string m_strDBPassword = "pws";
        public string m_strDBIPAddress = "";
        public string m_strDBProvider = "Provider=SQLOLEDB.1;Password=_PW;Persist Security Info=True;User ID=_ID;Data Source=_IP;Initial Catalog=PWSDB";
        public bool m_bCheckDB1 = false;
        public bool m_bCheckDB2 = false;
        public bool m_bNoLabelPass = false;
        public bool m_bSaveImage = false;
        public int m_nSendIndex = 0;
        public int m_nSendMaxIndex = 3;

        public string[] m_strSendedBarcode = null;
        public bool m_bStation2Using = false;
        #endregion

        #region OnEvent
        private void OnAccept(object sender, AsyncSocketAcceptEventArgs e)
        {
            AsyncSocketClient worker = new AsyncSocketClient(m_nid++, e.Worker);

            // 데이터 수신을 대기한다.
            worker.Receive();

            worker.OnConnet += new AsyncSocketConnectEventHandler(OnConnet);
            worker.OnClose += new AsyncSocketCloseEventHandler(OnClose);
            worker.OnError += new AsyncSocketErrorEventHandler(OnError);
            worker.OnSend += new AsyncSocketSendEventHandler(OnSend);
            worker.OnReceive += new AsyncSocketReceiveEventHandler(OnReceive);

            // 접속한 클라이언트를 List에 포함한다.
            clientList.Add(worker);

    //        UpdateTextFunc(txtMessage, "HOST -> PC: Accepted\n");
        }

        private void OnError(object sender, AsyncSocketErrorEventArgs e)
        {
   //         UpdateTextFunc(txtMessage, "HOST -> PC: Error ID: " + e.ID.ToString() + "Error Message: " + e.AsyncSocketException.ToString() + "\n");

            for (int i = 0; i < clientList.Count; i++)
            {
                if (clientList[i].ID == e.ID)
                {
                    if (clientList[i].m_nIndex <= 3 && clientList[i].m_nIndex > 0)
                        m_arrBufferStatus[clientList[i].m_nIndex - 1] =0; 
                    
                    clientList.Remove(clientList[i]);

                    break;
                }
            }
        }

        private void OnReceive(object sender, AsyncSocketReceiveEventArgs e)
        {
      //      UpdateTextFunc(txtMessage, "HOST -> PC: Receive ID: " + e.ID.ToString() + " -Bytes received: " + e.ReceiveBytes.ToString() + "\n");
            for (int i = 0; i < clientList.Count; i++)
            {
                if (clientList[i].ID == e.ID)
                {
                    //clientList.Remove(clientList[i]);
                    clientList[i].m_nIndex = int.Parse(e.ReceiveData[0].ToString());
                    if (clientList[i].m_nIndex <= 3 && clientList[i].m_nIndex > 0)
                        m_arrBufferStatus[clientList[i].m_nIndex - 1] = 1;
                    break;
                }
            }
            if( m_arrBufferStatus[0] == 0 )
                btnStatusM1.BackColor = Color.LightPink;
            else
                btnStatusM1.BackColor = Color.LightGreen;

            if (m_nMode != 1)
            {
                if (m_arrBufferStatus[1] == 0)
                    btnStatusM2.BackColor = Color.LightPink;
                else
                    btnStatusM2.BackColor = Color.LightGreen;
            }

            if (m_arrBufferStatus[2] == 0) 
                btnStatusM3.BackColor = Color.LightPink;
            else
                btnStatusM3.BackColor = Color.LightGreen;

        }

        private void OnSend(object sender, AsyncSocketSendEventArgs e)
        {
      //      UpdateTextFunc(txtMessage, "PC -> HOST: Send ID: " + e.ID.ToString() + " -Bytes sent: " + e.SendBytes.ToString() + "\n");
        }

        private void OnClose(object sender, AsyncSocketConnectionEventArgs e)
        {
     //       UpdateTextFunc(txtMessage, "HOST -> PC: Closed ID: " + e.ID.ToString() + "\n");
            for (int i = 0; i < clientList.Count; i++)
            {
                if (clientList[i].ID == e.ID)
                {
                    if (clientList[i].m_nIndex <= 3 && clientList[i].m_nIndex > 0)
                        m_arrBufferStatus[clientList[i].m_nIndex - 1]--;
                    clientList.Remove(clientList[i]);
                    break;
                }
            }   
        }

        private void OnConnet(object sender, AsyncSocketConnectionEventArgs e)
        {
       //     UpdateTextFunc(txtMessage, "HOST -> PC: Connected ID: " + e.ID.ToString() + "\n");
        }
        #endregion

        public LineScanSchedulerForm()
        {
            InitializeComponent();
            m_nid = 0;
        }

        public void SendPLC(PLCCmd pCmd)
        {
            if (pCmd != null)
            {
               /* if (!PLCPort.IsOpen)
                {
                    PLCPort.PortName = m_strPLCPort;
                    PLCPort.BaudRate = int.Parse(m_strPLCBaudrate);
                    PLCPort.Open();
                }*/
                if (!PLCPort.IsOpen)
                {
                    PLCPort.PortName = m_PLC.m_strPLCPortName;
                    PLCPort.BaudRate = int.Parse(m_PLC.m_strPLCBaudrate);
                    PLCPort.Open();
                }

                if (PLCPort.IsOpen)
                {
                    m_bWritePLCData = false;
                    m_strReceiveString = "";
                    _WaitPLCResponseHandle.Reset();

                    PLCPort.Write(pCmd.m_strCommand);

                    PLCTimeoutTimer.Enabled = true;

                    _WaitPLCResponseHandle.WaitOne();

                    //m_PLCQueue.Add(pCmd);
           //         m_PLC.AddQueue(pCmd);
                    _WaitPLCResponseHandle.Reset();
                }


            }

        }
       
        public bool DBCheck(int nMode, string strBarcode)
        {
            bool bResult = false;
            OleDbConnection m_dbConn = new OleDbConnection();
            try
            {
                if (m_dbConn.State != ConnectionState.Open)
                    m_dbConn.Open();
                if (m_dbConn.State == ConnectionState.Open)
                {
                    string strQurey = "";
                    if (nMode == 1)
                        strQurey = m_strQuery1;
                    else
                        strQurey = m_strQuery2;

                    strQurey.Replace("V_BARCODE", strBarcode);

                    //strQurey = "insert into T_ICT_LOG select '" + m_strEquip_no + "', '" + m_strProd_Parts_no + "', convert(datetime, '" + m_strStart_date + "') , null, null, null, null, null, null";

                    OleDbCommand _dbCommand = new OleDbCommand(strQurey, m_dbConn);
                    _dbCommand.CommandTimeout = 600;
                    bResult = false;
 
                    object[] data = null;

                        OleDbDataReader _dbReader = null;
                        _dbReader = _dbCommand.ExecuteReader();
                        _dbCommand.ExecuteNonQuery();
                        if (_dbReader.HasRows)
                        {
                            data = new object[10];
                            if (_dbReader.Read())
                            {
                                _dbReader.GetValues(data);
                                if (data[0].ToString() == "OK")
                                    bResult = true;
                            }

                        }
                        m_dbConn.Close();
                    //    txtSQLLog.Text += strQurey + "\r\n";
               
                }
            }
            catch (Exception ex)
            {
               // txtExcpMsg.Text = ex.Message.ToString();
                //txtSQLLog.Text += ex.Message.ToString() + "\r\n";
                bResult = false;
            }


            return bResult;


        }

        public void CommunicationPLC()
        {
            _WaitPLCResponseHandle = new AutoResetEvent(true);

            while (!m_bExit)
            {
/*                if (m_PLCQueue.Count > 0)
                {
                    PLCCmd pCmd = (PLCCmd)m_PLCQueue[0];
                    SendPLC(pCmd);
                    m_PLCQueue.RemoveAt(0);
                }
                SendPLC(null);
                System.Threading.Thread.Sleep(1000);*/

                if (m_PLC.GetCount() > 0)
                {
                    SendPLC(m_PLC.GetQueue());
                }
                SendPLC(null);
                System.Threading.Thread.Sleep(1000);



            }
        }

        public void MakeSendString()
        {
            m_strSendPLCMReadCMD = "";
            char cCh = (char)0x5;
            m_strSendPLCMReadCMD += cCh;
            m_strSendPLCMReadCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCMReadCMD += "RSB0" + (3+m_strPLCReadMAddress.Length).ToString() + "%MW";
            m_strSendPLCMReadCMD += m_strPLCReadMAddress;
            m_strSendPLCMReadCMD += "04";
            cCh = (char)0x04;
            m_strSendPLCMReadCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCMReadCMD.Length; i++)
            {
                cCh += m_strSendPLCMReadCMD[i];
            }
            m_strSendPLCMReadCMD += cCh;

            m_strSendPLCDReadCMD = "";
            cCh = (char)0x5;
            m_strSendPLCDReadCMD += cCh;
            m_strSendPLCDReadCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCDReadCMD += "RSB0" + (3 + m_strPLCReadDAddress.Length).ToString() + "%DW";
            m_strSendPLCDReadCMD += m_strPLCReadDAddress; 
            m_strSendPLCDReadCMD += "06";
            cCh = (char)0x04;
            m_strSendPLCDReadCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCDReadCMD.Length; i++)
            {
                cCh += m_strSendPLCDReadCMD[i];
            }
            m_strSendPLCDReadCMD += cCh;
        }

        public void MakeWriteString(int nMode)
        {
            int nXPos = 0;
            int nYPos = 0;
            int nZPos = 0;       
    
            nXPos = (int)(double.Parse(m_ModelData.m_strXPos));
            nYPos = (int)(double.Parse(m_ModelData.m_strYPos));
            nZPos = (int)(double.Parse(m_ModelData.m_strZPos));

            MakeWriteString(nMode, nXPos, nYPos, nZPos);
            /*
            string strData = "";
            string strTemp = "";
            strTemp = String.Format("{0:X4}", nXPos) + "0000";
            strData += strTemp;
            strTemp = String.Format("{0:X4}", nZPos) + "0000";
            strData += strTemp;
   //         m_strPLCWriteDAddress = txtDWriteAddr.Text;
     //       m_strPLCWriteMAddress = txtMWriteAddr.Text;
            m_strSendPLCMWriteCMD = "";
            char cCh = (char)0x5;
            m_strSendPLCMWriteCMD += cCh;
            m_strSendPLCMWriteCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCMWriteCMD += "WSB0" + (3 + m_strPLCWriteMAddress.Length).ToString() + "%MW";
            m_strSendPLCMWriteCMD += m_strPLCWriteMAddress;
            m_strSendPLCMWriteCMD += "04";
            if( nMode == 1 )
                m_strSendPLCMWriteCMD += "0001000000000000";
            else
                m_strSendPLCMWriteCMD += "0000000000000000";
            cCh = (char)0x04;
            m_strSendPLCMWriteCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCMWriteCMD.Length; i++)
            {
                cCh += m_strSendPLCMWriteCMD[i];
            }
            m_strSendPLCMWriteCMD += cCh;

            m_strSendPLCDWriteCMD = "";
            cCh = (char)0x5;
            m_strSendPLCDWriteCMD += cCh;
            m_strSendPLCDWriteCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCDWriteCMD += "WSB0" + (3 + m_strPLCWriteDAddress.Length).ToString() + "%DW";
            m_strSendPLCDWriteCMD += m_strPLCWriteDAddress;
            m_strSendPLCDWriteCMD += "04";
            m_strSendPLCDWriteCMD += strData;
            cCh = (char)0x04;
            m_strSendPLCDWriteCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCDWriteCMD.Length; i++)
            {
                cCh += m_strSendPLCDWriteCMD[i];
            }
            m_strSendPLCDWriteCMD += cCh;*/
        }

        public void MakeWriteString(int nMode, int nXPos, int nYPos, int nZPos)
        {
            string strData = "";
            string strTemp = "";
            strTemp = String.Format("{0:X4}", nXPos) + "0000";
            strData += strTemp;
            strTemp = String.Format("{0:X4}", nYPos) + "0000";
            strData += strTemp;
            strTemp = String.Format("{0:X4}", nZPos) + "0000";
            strData += strTemp;
            //         m_strPLCWriteDAddress = txtDWriteAddr.Text;
            //       m_strPLCWriteMAddress = txtMWriteAddr.Text;
            m_strSendPLCMWriteCMD = "";
            char cCh = (char)0x5;
            m_strSendPLCMWriteCMD += cCh;
            m_strSendPLCMWriteCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCMWriteCMD += "WSB0" + (3 + m_strPLCWriteMAddress.Length).ToString() + "%MW";
            m_strSendPLCMWriteCMD += m_strPLCWriteMAddress;
            m_strSendPLCMWriteCMD += "04";
            if (nMode == 1)
                m_strSendPLCMWriteCMD += "0001000000000000";
            else
                m_strSendPLCMWriteCMD += "0000000000000000";
            cCh = (char)0x04;
            m_strSendPLCMWriteCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCMWriteCMD.Length; i++)
            {
                cCh += m_strSendPLCMWriteCMD[i];
            }
            m_strSendPLCMWriteCMD += cCh;

            m_strSendPLCDWriteCMD = "";
            cCh = (char)0x5;
            m_strSendPLCDWriteCMD += cCh;
            m_strSendPLCDWriteCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCDWriteCMD += "WSB0" + (3 + m_strPLCWriteDAddress.Length).ToString() + "%DW";
            m_strSendPLCDWriteCMD += m_strPLCWriteDAddress;
            m_strSendPLCDWriteCMD += "06";
            m_strSendPLCDWriteCMD += strData;
            cCh = (char)0x04;
            m_strSendPLCDWriteCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCDWriteCMD.Length; i++)
            {
                cCh += m_strSendPLCDWriteCMD[i];
            }
            m_strSendPLCDWriteCMD += cCh;
        }

        public void SendPLCCommand()
        {
            if (PLCPort.IsOpen)
            {
                string strSendCmd = "";

                if (m_bWritePLCData)
                {
                    if (m_nPLCSendSeq == 0)
                        strSendCmd = m_strSendPLCDWriteCMD;
                    else
                        strSendCmd = m_strSendPLCMWriteCMD;
                }
                else
                {
                    if (m_nPLCSendSeq == 0)
                        strSendCmd = m_strSendPLCDReadCMD;
                    else
                        strSendCmd = m_strSendPLCMReadCMD;
                    m_nPLCSendSeq++;
                    m_nPLCSendSeq %= 2;
                }

                PLCPort.Write(strSendCmd);

                PLCTimeoutTimer.Enabled = true;
            }
        }

        private void PLCPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            PLCTimeoutTimer.Enabled = false;
            if (PLCPort.IsOpen)
            {
                SerialPort sp = (SerialPort)sender;
                System.Threading.Thread.Sleep(50);
                string indata = sp.ReadExisting();
                m_strReceiveString = indata;
                _WaitPLCResponseHandle.Set();
                if (indata.Length > 0 && indata[0] == (char)0x06)
                    m_strAck = "A";
                else if (indata.Length > 0 && indata[0] == (char)0x15)
                    m_strAck = "N";
                else
                    m_strAck = "-";
            }
         //   SendPLCCommand();
        }

        private void PLCTimeoutTimer_Tick(object sender, EventArgs e)
        {
            _WaitPLCResponseHandle.Set();
       //     SendPLCCommand();
        }

        public void ImageGrabOn()
        {
            CogFrameGrabberGigEs fgs = new CogFrameGrabberGigEs();
            
            try
            {
                if (fgs.Count > 0)
                {
                    if (!ScanDisplay.LiveDisplayRunning)
                    {

                        _acqFifo1 = fgs[0].CreateAcqFifo(fgs[0].AvailableVideoFormats[0], CogAcqFifoPixelFormatConstants.Format8Grey, 0, false);
                        //_acqFifo1.OwnedWhiteBalanceParams.AutoWhiteBalance();
                        //_acqFifo1.OwnedExposureParams.Exposure = 5;

                        ScanDisplay.StartLiveDisplay(_acqFifo1);
                        //_acqFifo1.OwnedWhiteBalanceParams.AutoWhiteBalance();
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
   /*         if (PLCPort.IsOpen)
            {
                PLCPort.Close();
        //        btnStart.Text = "Start";
                PLCTimeoutTimer.Enabled = false;
            }
     //       else
            {
                m_bWritePLCData = false;
                m_nPLCSendSeq = 0;
                m_strReceiveString = "";
                PLCPort.PortName = txtPLCPort.Text;
                PLCPort.BaudRate = int.Parse(txtBaudRate.Text);
                PLCPort.Open();
          //      btnStart.Text = "Stop";
                MakeSendString();
                txtSendCmd.Text = m_strSendPLCDReadCMD;
                SendPLCCommand();
            }*/
            if (!PLCPort.IsOpen)
            {
                PLCPort.PortName = m_strPLCPort;
                PLCPort.BaudRate = int.Parse(m_strPLCBaudrate);
                try
                {
                    PLCPort.Open();
                }
                catch
                {

                }
            }
            Thread PLCThread = new Thread(CommunicationPLC);
            PLCThread.Start();
        }

        public void LoadOption()
        {
            StringBuilder temp = new StringBuilder(255);
            int i;
            i = INI.GetPrivateProfileString("Setup", "Light Comm Port", "COM4", temp, 255, m_strSetupINIFile);
            m_strLightPort = temp.ToString();

            i = INI.GetPrivateProfileString("PLC", "Read D Address", "1000", temp, 255, m_strSetupINIFile);
            m_strPLCReadDAddress = temp.ToString();
            i = INI.GetPrivateProfileString("PLC", "Read M Address", "1000", temp, 255, m_strSetupINIFile);
            m_strPLCReadMAddress = temp.ToString();
            i = INI.GetPrivateProfileString("PLC", "Write D Address", "1100", temp, 255, m_strSetupINIFile);
            m_strPLCWriteDAddress = temp.ToString();
            i = INI.GetPrivateProfileString("PLC", "Write M Address", "1100", temp, 255, m_strSetupINIFile);
            m_strPLCWriteMAddress = temp.ToString();
            i = INI.GetPrivateProfileString("PLC", "Port", "COM1", temp, 255, m_strSetupINIFile);
            m_strPLCPort = temp.ToString();
            i = INI.GetPrivateProfileString("PLC", "Baudrate", "9600", temp, 255, m_strSetupINIFile);
            m_strPLCBaudrate = temp.ToString();
            i = INI.GetPrivateProfileString("PLC", "Channel", "01", temp, 255, m_strSetupINIFile);
            m_strPLCChannel = temp.ToString();

            i = INI.GetPrivateProfileString("DB", "Query1", "select [DBO].[fn_get_insprslt]('ICT','V_BARCODE')", temp, 255, m_strSetupINIFile);
            m_strQuery1 = temp.ToString();
            i = INI.GetPrivateProfileString("DB", "Query2", "select [dbo].[fn_get_repairinfo]('ICT','V_BARCODE')", temp, 255, m_strSetupINIFile);
            m_strQuery2 = temp.ToString();
            i = INI.GetPrivateProfileString("Setup", "Mode", "1", temp, 255, m_strSetupINIFile);

            int.TryParse(temp.ToString(), out m_nMode);
            i = INI.GetPrivateProfileString("DB", "User ID", "", temp, 255, m_strSetupINIFile);
            m_strDBID = temp.ToString();
            i = INI.GetPrivateProfileString("DB", "Password", "", temp, 255, m_strSetupINIFile);
            m_strDBPassword = temp.ToString();
            i = INI.GetPrivateProfileString("DB", "IP Address", "", temp, 255, m_strSetupINIFile);
            m_strDBIPAddress = temp.ToString();
            string strdata;
            i = INI.GetPrivateProfileString("DB", "Check DB1", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();



            if (strdata == "1")
                m_bCheckDB1 = true;
            else
                m_bCheckDB1 = false;

            i = INI.GetPrivateProfileString("DB", "Check DB2", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();
            if (strdata == "1")
                m_bCheckDB2 = true;
            else
                m_bCheckDB2 = false;

            i = INI.GetPrivateProfileString("Setup", "No Label Pass", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();
            if (strdata == "1")
                m_bNoLabelPass = true;
            else
                m_bNoLabelPass = false;

            i = INI.GetPrivateProfileString("Setup", "Save Image", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();
            if (strdata == "1")
                m_bSaveImage = true;
            else
                m_bSaveImage = false;

            
            m_PLC.SetPLCSetting(m_strPLCPort, m_strPLCBaudrate, m_strPLCChannel);
            txtDReadAddr.Text = m_strPLCReadDAddress;
            txtMReadAddr.Text = m_strPLCReadMAddress;
            txtDWriteAddr.Text = m_strPLCWriteDAddress;
            txtMWriteAddr.Text = m_strPLCWriteMAddress;
            txtPLCPort.Text = m_strPLCPort;
            txtBaudRate.Text = m_strPLCBaudrate;
            txtPLCChannel.Text = m_strPLCChannel;
            btnStatusM1.BackColor = Color.LightPink;
            if (m_nMode != 1)
            {
                btnStatusM2.BackColor = Color.LightPink;
                btnStatusM2.Enabled = true;
                btnStatusM2.Text = "PC 2";
                btnStatusM3.Text = "PC 3";
            }
            else
            {
                btnStatusM2.Enabled = false;
                btnStatusM2.Text = "Buffer";
                btnStatusM3.Text = "PC 2";
            }
            btnStatusM3.BackColor = Color.LightPink;
        }

        private void LineScanSchedulerForm_Load(object sender, EventArgs e)
        {
            FileInfo fileinfo = new FileInfo(Application.ExecutablePath);
            m_strSetupINIFile = fileinfo.Directory.FullName + @"\\Setup.ini";
            LoadOption();
            for (int i = 0; i < 3; i++)
            {
                m_arrBufferStatus[i] = 0;
                
            }
            LightOn(3);
            ImageGrabOn();
    //        Thread PLCThread = new Thread(CommunicationPLC);
      //      PLCThread.Start();
            server = new AsyncSocketServer(9600);
            server.OnAccept += new AsyncSocketAcceptEventHandler(OnAccept);
            server.OnError += new AsyncSocketErrorEventHandler(OnError);

            clientList = new List<AsyncSocketClient>(100);
            server.Listen();
            DIOTimer.Enabled = true;
            _WaitPLCResponseHandle = new AutoResetEvent(true);
            cogDisplayStatusBarV21.Display = ScanDisplay;

            DataGridViewCellStyle GridStyle = new DataGridViewCellStyle();
            
            GridStyle.Font = new Font("굴림", 20, FontStyle.Regular);
            
            GridBarcode.ColumnHeadersDefaultCellStyle = GridStyle;
            GridBarcode.RowsDefaultCellStyle = GridStyle;

            //m_nMode = 1;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_strPLCPort = txtPLCPort.Text;
            m_strPLCBaudrate = txtBaudRate.Text;

            m_strPLCReadDAddress = txtDReadAddr.Text;
            m_strPLCReadMAddress = txtMReadAddr.Text;
            m_strPLCWriteDAddress = txtDWriteAddr.Text;
            m_strPLCWriteMAddress = txtMWriteAddr.Text;
            m_strPLCChannel = txtPLCChannel.Text;

            INI.WritePrivateProfileString("PLC", "Read D Address", m_strPLCReadDAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Read M Address", m_strPLCReadMAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Write D Address", m_strPLCWriteDAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Write M Address", m_strPLCWriteMAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Port", m_strPLCPort, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Baudrate", m_strPLCBaudrate, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Channel", m_strPLCChannel, m_strSetupINIFile);
            m_ModelData.m_nGroupCount = 0;

        }
        #region
        private void Refresh_Tick(object sender, EventArgs e)
        {
            /*
            txtReceiveData.Text = m_strReceiveString;
            txtAck.Text = m_strAck;


            if (!m_bWritePLCData && m_nPLCSendSeq == 1 && m_strReceiveString != "")
            {
                string strTemp = "";
                int nLenght;
                nLenght = int.Parse(m_strReceiveString.Substring(8, 2));
                strTemp = m_strReceiveString.Substring(10, nLenght);

                int nX = Convert.ToInt32(strTemp.Substring(0, 4), 16);
                if (strTemp[0] == 'F' || strTemp[0] == 'f')
                {
                    nX = nX - 0xffff - 1;
                }               
                strTemp = m_strReceiveString.Substring(10 +nLenght, nLenght);
                int nZ = Convert.ToInt32(strTemp.Substring(0, 4), 16);
                if (strTemp[0] == 'F' || strTemp[0] == 'f')
                {
                    nZ = nZ - 0xffff -1;
                } 
                txtXPosition.Text = ((double)nX/100).ToString();
                txtZPosition.Text = ((double)nZ/100).ToString();
            }*/
            ReadPostion();
        }

        private void btnStartM_Click(object sender, EventArgs e)
        {
            if (PLCPort.IsOpen)
            {
                PLCPort.Close();
                //        btnStart.Text = "Start";
                PLCTimeoutTimer.Enabled = false;
            }
            //       else
            {
                m_bWritePLCData = false;
                m_nPLCSendSeq = 1;
                m_strReceiveString = "";
                PLCPort.PortName = txtPLCPort.Text;
                PLCPort.BaudRate = int.Parse(txtBaudRate.Text);
                PLCPort.Open();
                //      btnStart.Text = "Stop";
                txtSendCmd.Text = m_strSendPLCMReadCMD;
                MakeSendString();
                SendPLCCommand();
            }
        }

        private void btnSetPosition_Click(object sender, EventArgs e)
        {
            if (PLCPort.IsOpen)
            {
                PLCPort.Close();
                //        btnStart.Text = "Start";
                PLCTimeoutTimer.Enabled = false;
            }
            //       else
            
            m_nPLCSendSeq = 0;
            m_strReceiveString = "";
            PLCPort.PortName = txtPLCPort.Text;
            PLCPort.BaudRate = int.Parse(txtBaudRate.Text);
            PLCPort.Open();
            m_bWritePLCData = true;
            MakeWriteString(0);
            txtSendCmd.Text = m_strSendPLCDWriteCMD;
            SendPLCCommand();
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            if (PLCPort.IsOpen)
            {
                PLCPort.Close();
                //        btnStart.Text = "Start";
                PLCTimeoutTimer.Enabled = false;
            }
            //       else

            m_nPLCSendSeq = 1;
            m_strReceiveString = "";
            PLCPort.PortName = txtPLCPort.Text;
            PLCPort.BaudRate = int.Parse(txtBaudRate.Text);
            PLCPort.Open();
            m_bWritePLCData = true;
            MakeWriteString(1);
            txtSendCmd.Text = m_strSendPLCMWriteCMD;
            SendPLCCommand();
        }

        private void btnSetTrgOff_Click(object sender, EventArgs e)
        {
       /*     if (PLCPort.IsOpen)
            {
                PLCPort.Close();
                //        btnStart.Text = "Start";
                PLCTimeoutTimer.Enabled = false;
            }
            //       else

            m_nPLCSendSeq = 1;
            m_strReceiveString = "";
            PLCPort.PortName = txtPLCPort.Text;
            PLCPort.BaudRate = int.Parse(txtBaudRate.Text);
            PLCPort.Open();
            m_bWritePLCData = true;
            MakeWriteString(0);
            txtSendCmd.Text = m_strSendPLCMWriteCMD;
            SendPLCCommand();*/
            SendBacode(1, false);
        }

        public void LightOn(int nLightControl)
        {
            LightComm.PortName = m_strLightPort;
            LightComm.Open();
            if (nLightControl % 2 == 1)
            {
                LightComm.WriteLine("L1255\r\n");
                LightComm.WriteLine("#CH01BW0255E\r\n");
            }
            if (nLightControl > 1)
            {
                LightComm.WriteLine("L2255\r\n");
                LightComm.WriteLine("#CH02BW0255E\r\n");
            }
            LightComm.Close();
        }

        public void LightOff()
        {
            LightComm.PortName = m_strLightPort;
            LightComm.Open();
            LightComm.WriteLine("E1\r\n");
            LightComm.WriteLine("E2\r\n");
            LightComm.WriteLine("#CH01FW0000E\r\n");
            LightComm.WriteLine("#CH02FW0000E\r\n");
            LightComm.Close();
        }

        public void BarcodeScan(int nMode)
        {
            ICogAcqFifo AcqFifo = null;
            ICogImage cogImage;

            LightOn(3);
       
            AcqFifo = _acqFifo1;
                  
            if (AcqFifo != null)
            {
                int trigNum;
                //Cognex.VisionPro.ICogImage image;
                try
                {
                    cogImage = AcqFifo.Acquire(out trigNum);
                    string strBarcode = "";
                    BarcodeRead ReadBarcode = new BarcodeRead();
                    ReadBarcode.m_imgScreenShot = cogImage;
                    for (int i = 0; i < m_ModelData.m_nGroupCount; i++)
                    {

                        ReadBarcode.SetRect(m_ModelData.m_rGroupRect[i]);
                        for (int j = 0; j < 3; j++)
                        {
                            strBarcode = ConvertBarcode(ReadBarcode.ReadBarcode(j));
                            if (strBarcode != "")
                                break;
                        }
                        if (m_bCheckDB1)
                        {
                            if (!DBCheck(1, strBarcode))
                            {
                                DisplayResult("DB Check1 Error!", Color.LightPink);
                                strBarcode = "";
                            }
                        }
                        if (m_bCheckDB2)
                        {
                            if (!DBCheck(2, strBarcode))
                            {
                                DisplayResult("DB Check2 Error!", Color.LightPink);
                                strBarcode = "";
                            }
                        }
                        if (strBarcode != "")
                        {
                            if (m_strBarcode != null && m_strSendedBarcode != null && m_strSendedBarcode[i] != strBarcode)
                            {
                                m_strBarcode[i] = strBarcode;
                                //    m_strBarcode[i] = strBarcode;
                                GridBarcode.Rows[i].Cells[0].Value = (i + 1).ToString();
                                GridBarcode.Rows[i].Cells[1].Value = strBarcode;
                            }
                        }
                    }
                }
                catch
                {
                }  
                GC.Collect();
            }                
        }

        public Rectangle GetRect(string strRect)
        {
            Rectangle rRect = new Rectangle();

            string[] strRectToken = new string[4];
            strRect = strRect + ",,,";
            strRectToken = strRect.Split(',');
            if (strRectToken[0] != null && strRectToken[0] != "")
                rRect.X = int.Parse(strRectToken[0]);
            if (strRectToken[1] != null && strRectToken[1] != "")
                rRect.Y = int.Parse(strRectToken[1]);
            if (strRectToken[2] != null && strRectToken[2] != "")
                rRect.Width = int.Parse(strRectToken[2]) - rRect.X;
            if (strRectToken[3] != null && strRectToken[3] != "")
                rRect.Height = int.Parse(strRectToken[3]) - rRect.Y;


            return rRect;
        }

        private void LineScanSchedulerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LightOff();
            server.Stop();
            m_bExit = true;
            DIOTimer.Enabled = false;
            if (_WaitPLCResponseHandle != null)
                _WaitPLCResponseHandle.Set();


            ScanTimer.Enabled = false;
            if (ScanDisplay.LiveDisplayRunning)
            {
                ScanDisplay.StopLiveDisplay();
                System.Threading.Thread.Sleep(500);
            }
            GC.Collect();

        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            BarcodeSetupForm barForm = new BarcodeSetupForm(this);
            RefreshTimer.Enabled = false;
            barForm.ShowDialog();
            RefreshTimer.Enabled = true;
        }

        private void LineScanSchedulerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
                fg.Disconnect(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
          //  string strSnapImg;
            RefreshTimer.Enabled = false;
            ScanTimer.Enabled = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_strModelFileName = openFileDialog1.FileName;
                txtModelName.Text = openFileDialog1.SafeFileName;
                LoadData();
                GridBarcode.Rows.Clear();
                for (int i = 0; i < m_ModelData.m_nGroupCount; i++)
                {
                    GridBarcode.Rows.Add();
                    
                }
                m_strBarcode = new string[m_ModelData.m_nGroupCount];
                m_strSendedBarcode = new string[m_ModelData.m_nGroupCount];
                //ScanTimer.Enabled = true;
                SetPostion();
             /*   if (LoadData())
                {
                    m_nStatus = WAIT;
                    if (m_pModelData[0].m_nGroupIndex == 0)
                        PreResultButton.Text = m_pModelData[0].m_strStepName;
                    else
                        PreResultButton.Text = m_pModelData[0].m_nGroupIndex.ToString() + "Group " + m_pModelData[0].m_strStepName;
                    //PreResultButton.Text = m_pModelData[0].m_strStepName;
                    ResultButton.Text = "검사 준비";
                    PostResultButton.Text = "-";
                    Press_Timer.Enabled = true;
                    Steps_progressBar.Value = 0;
                    strSnapImg = ModelFileName;
                    strSnapImg = strSnapImg.ToLower();
                    strSnapImg = strSnapImg.Replace(".ftd", ".bmp");
                    if (System.IO.File.Exists(strSnapImg))
                    {
                        SnapImage.Operator.Open(strSnapImg, CogImageFileModeConstants.Read);
                        SnapImage.Run();
                        ModelSnap.Image = SnapImage.OutputImage;
                        ModelSnap.AutoFit = true;
                    }
                }
                else
                    m_nStatus = PreStatus;*/
            }
           // if( m_ModelData.m_nGroupCount > 0 )
                //ScanTimer.Enabled = true;
            RefreshTimer.Enabled = true;
        }

        public void SetPostion()
        {

            PLCCmd pCmd = new PLCCmd();
            MakeWriteString(0);

            pCmd.m_strCommand = m_strSendPLCDWriteCMD;
            SendPLC(pCmd);

            MakeWriteString(1);
            pCmd.m_strCommand = m_strSendPLCMWriteCMD;
            SendPLC(pCmd);
        }

        public void SetPostion(int nXPos, int nYPos, int nZPos)
        {

            PLCCmd pCmd = new PLCCmd();
            MakeWriteString(0, nXPos, nYPos, nZPos);

            pCmd.m_strCommand = m_strSendPLCDWriteCMD;
            SendPLC(pCmd);

            MakeWriteString(1, nXPos, nYPos, nZPos);
            pCmd.m_strCommand = m_strSendPLCMWriteCMD;
            SendPLC(pCmd);
        }

        public void ReadPostion()
        {
            MakeSendString();
            PLCCmd pCmd = new PLCCmd();
            pCmd.m_strCommand = m_strSendPLCDReadCMD;
            SendPLC(pCmd);

            if ( m_strReceiveString != "")
            {
                string strTemp = "";
                int nLenght;
                strTemp = m_strReceiveString.Substring(8, 2);
                nLenght = Convert.ToInt32(m_strReceiveString.Substring(8, 2),16);
                strTemp = m_strReceiveString.Substring(10, nLenght*2);

                int nX = Convert.ToInt32(strTemp.Substring(0, 4), 16);
                if (strTemp[0] == 'F' || strTemp[0] == 'f')
                {
                    nX = nX - 0xffff - 1;
                }               
              //  strTemp = m_strReceiveString.Substring(10 +nLenght, nLenght);
                int nY = Convert.ToInt32(strTemp.Substring(0+8, 4), 16);
                if (strTemp[0] == 'F' || strTemp[0] == 'f')
                {
                    nY = nY - 0xffff - 1;
                }
                int nZ = Convert.ToInt32(strTemp.Substring(0+16, 4), 16);
                if (strTemp[0] == 'F' || strTemp[0] == 'f')
                {
                    nZ = nZ - 0xffff -1;
                } 
                txtXPosition.Text = (nX/100).ToString();
                txtYPosition.Text = (nY / 100).ToString();
                txtZPosition.Text = (nZ/100).ToString();
                m_strCurrXPos = nX.ToString();
                m_strCurrYPos = nY.ToString();
                m_strCurrZPos = nZ.ToString();
            }

        }

        public void LoadData()
        {
            StringBuilder temp = new StringBuilder(255);
            int i, j;
            string strSection;
            string strData;
            int nData;



            strSection = "Rect";
            i = INI.GetPrivateProfileString(strSection, "Group Count", "0", temp, 255, m_strModelFileName);
            strData = temp.ToString();
            nData = int.Parse(strData);
            m_ModelData.m_nGroupCount = nData;
            m_ModelData.m_rGroupRect = new Rectangle[m_ModelData.m_nGroupCount];

            for (j = 0; j < nData; j++)
            {
                i = INI.GetPrivateProfileString(strSection, "Group" + (j + 1).ToString(), ",,,,,,", temp, 255, m_strModelFileName);
                strData = temp.ToString();
                m_ModelData.m_rGroupRect[j] = GetRect(strData);
 
            }
            strSection = "Position";
            i = INI.GetPrivateProfileString(strSection, "X-Pos", "0", temp, 255, m_strModelFileName);
            m_ModelData.m_strXPos = temp.ToString();
            i = INI.GetPrivateProfileString(strSection, "Y-Pos", "0", temp, 255, m_strModelFileName);
            m_ModelData.m_strYPos = temp.ToString();
            i = INI.GetPrivateProfileString(strSection, "Z-Pos", "0", temp, 255, m_strModelFileName);
            m_ModelData.m_strZPos = temp.ToString();

  
        }
        #endregion
        private void ScanTimer_Tick(object sender, EventArgs e)
        {
            BarcodeScan(m_nScanIndex % 3);
            m_nScanIndex++;
            m_nScanIndex = m_nScanIndex % 3;
 
        }
        public void Scheduling()
        {
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];

            for (int i = 0; i < 8; i++)
                arrLines[i] = 1;
            BarcodeScan(0);
            System.Threading.Thread.Sleep(100);
            //kiem tra may 3 san sang
            if (m_NiDaq.m_nReadPort[3] == 0)//3번 장비 Ready
            {
                if (m_bStation2Using && m_NiDaq.m_nReadPort[2] != 0 && m_NiDaq.m_nReadPort[1] == 0)
                {

                    if (SendBacode(1, false))
                    {
                        nLines = 0;
                        arrLines[2] = 0;
                        arrLines[4] = 0;
                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                        System.Threading.Thread.Sleep(1500);

                        nLines = 0;
                        arrLines[2] = 1;
                        arrLines[4] = 1;
                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                        DisplayResult("#1 Send Barcode", Color.LightGreen);

                    }
                    else
                    {
                        nLines = 0;
                        arrLines[3] = 0;

                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                        System.Threading.Thread.Sleep(1500);

                        nLines = 0;
                        arrLines[3] = 1;

                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                    }

                }
                else
                {
                    if (SendBacode(3, false))
                    {
                        nLines = 0;
                        arrLines[2] = 0;
                        arrLines[0] = 0;
                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                        System.Threading.Thread.Sleep(1500);

                        nLines = 0;
                        arrLines[2] = 1;
                        arrLines[0] = 1;
                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                        DisplayResult("#3 Send Barcode", Color.LightGreen);

                    }
                    else
                    {
                        nLines = 0;
                        arrLines[3] = 0;

                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                        System.Threading.Thread.Sleep(1500);

                        nLines = 0;
                        arrLines[3] = 1;

                        for (int nLine = 0; nLine < 8; nLine++)
                        {
                            nLines = nLines << 1;

                            nLines = nLines + arrLines[nLine];
                        }
                        m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    }
                }
            }
            //kiem tra may 2 san sang
            else if (m_NiDaq.m_nReadPort[2] == 0)//2번 장비 Ready
            {
                if (m_nMode == 1)
                    nIndex = 3;
                else
                    nIndex = 2;
                if (SendBacode(nIndex, false))
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    /*               if( m_nMode == 1 )
                                        arrLines[0] = 0;
                                    else*/
                    arrLines[1] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[1] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    DisplayResult("#" + nIndex.ToString() + " Send Barcode", Color.LightGreen);
                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                }
            }
            //kiem tra may 1 san sang
            else if (m_NiDaq.m_nReadPort[1] == 0)//1번 장비 Ready
            {
                if (SendBacode(1, false))
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[4] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[4] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                    DisplayResult("#1 Send Barcode", Color.LightGreen);

                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                }
            }
        }

        public void Scheduling_Seq()
        {
           
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];

            for (int i = 0; i < 8; i++)
                arrLines[i] = 1;
            BarcodeScan(0);
            //System.Threading.Thread.Sleep(100);
            if (m_NiDaq.m_nReadPort[2] == 0 && m_NiDaq.m_nReadPort[1] == 0)
            {
                m_nSendMaxIndex = 3;
                nIndex = m_nSendMaxIndex - m_nSendIndex;
                if (nIndex == 2)
                    nIndex = 3;

            }
            else if (m_NiDaq.m_nReadPort[2] != 0 && m_NiDaq.m_nReadPort[1] == 0)
            {
                m_nSendMaxIndex = 1;
                m_nScanIndex = 0;
                nIndex = 1;
            }
            else if (m_NiDaq.m_nReadPort[2] == 0 && m_NiDaq.m_nReadPort[1] != 0)
            {
                m_nSendMaxIndex = 0;
                m_nScanIndex = 0;
                nIndex = 3;
            }
            //cho nay !!!
            if (nIndex >= 2)
            {
                nIndex = 3;
                if (SendBacode(3, false))  //3호기로 전송
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[0] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[0] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                    DisplayResult("#2 Send Barcode", Color.LightGreen);

                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                }

            }
            else
            {
                nIndex = 1;
                if (SendBacode(1, false))  //1호기로 전송
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[4] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[4] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                    DisplayResult("#1 Send Barcode", Color.LightGreen);

                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                }
            }

            m_nSendIndex++;
            if (m_nSendIndex > m_nSendMaxIndex)
                m_nSendIndex = 0;

        }

        public void Scheduling_FCT()
        {
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];
            int i;

            for (i = 0; i < 8; i++)
                arrLines[i] = 1;
            BarcodeScan(0);
            //System.Threading.Thread.Sleep(100);
            m_nSendMaxIndex = 0;
            for (i = 1; i <= 3; i++)
            {
                if (m_NiDaq.m_nReadPort[i] == 0)
                    m_nSendMaxIndex++;
            }
            if (m_nSendMaxIndex == 3)
                nIndex = m_nSendMaxIndex - m_nSendIndex;
            else if (m_nSendMaxIndex == 2)
            {
                if (m_NiDaq.m_nReadPort[1] == 1)
                {
                    nIndex = m_nSendMaxIndex - m_nSendIndex + 1;
                }
                else if (m_NiDaq.m_nReadPort[2] == 1)
                {
                    nIndex = m_nSendMaxIndex - m_nSendIndex;
                    if (nIndex == 2)
                        nIndex = 3;
                }
                else if (m_NiDaq.m_nReadPort[3] == 1)
                {
                    nIndex = m_nSendMaxIndex - m_nSendIndex;
                }
            }
            else if (m_nSendMaxIndex == 1)
            {
                if (m_NiDaq.m_nReadPort[1] == 0)
                {
                    nIndex = 1;
                }
                else if (m_NiDaq.m_nReadPort[2] == 0)
                {
                    nIndex = 2;
                }
                else if (m_NiDaq.m_nReadPort[3] == 0)
                {
                    nIndex = 3;
                }
            }
            else
            {

            }

            /*
            if (m_NiDaq.m_nReadPort[3] == 0 && m_NiDaq.m_nReadPort[2] == 0 && m_NiDaq.m_nReadPort[1] == 0)
            {
                m_nSendMaxIndex = 2;
                nIndex = m_nSendMaxIndex - m_nSendIndex;

            }
            else if (m_NiDaq.m_nReadPort[3] == 0 && m_NiDaq.m_nReadPort[2] != 0 && m_NiDaq.m_nReadPort[1] == 0)
            {
                m_nSendMaxIndex = 1;
                m_nScanIndex = 0;
                nIndex = 1;
            }
            else if (m_NiDaq.m_nReadPort[2] == 0 && m_NiDaq.m_nReadPort[1] != 0)
            {
                m_nSendMaxIndex = 0;
                m_nScanIndex = 0;
                nIndex = 3;
            }*/

            if (nIndex == 3)
            {
                if (SendBacode(3, false))  //3호기로 전송
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[0] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[0] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                    DisplayResult("#3 Send Barcode", Color.LightGreen);

                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                }

            }
            else if (nIndex == 2)
            {
                if (SendBacode(2, false))
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    /*               if( m_nMode == 1 )
                                        arrLines[0] = 0;
                                    else*/
                    arrLines[1] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[1] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    DisplayResult("#2 Send Barcode", Color.LightGreen);
                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                }
            }
            else
            {
                nIndex = 1;
                if (SendBacode(1, false))  //1호기로 전송
                {
                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[4] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[4] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                    DisplayResult("#1 Send Barcode", Color.LightGreen);

                }
                else
                {
                    nLines = 0;
                    arrLines[3] = 0;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[3] = 1;

                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
                }
            }

            m_nSendIndex++;
            if (m_nSendIndex > m_nSendMaxIndex)
                m_nSendIndex = 0;

        }   

        public bool SendBacode(int nIndex, bool bRetest)
        {
            bool bResult = false;
            string strData = "";
            byte [] byteSendData = new byte[256];
            int i = 0;
            int j = 0;
            bool [] bReadResult = new bool[m_ModelData.m_nGroupCount] ;
            BarcodeScan(0);
            System.Threading.Thread.Sleep(100);
            CogImageFileTool SaveImageFile = new CogImageFileTool();
            CogImageConvertTool imgCov = new CogImageConvertTool();
            if (m_bSaveImage)
            {
                imgCov.InputImage = ScanDisplay.Image;
                imgCov.Run();
                SaveImageFile.InputImage = imgCov.OutputImage;
            }
            
            for (i = 0; i < clientList.Count; i++)
            {
                if (clientList[i].m_nIndex == nIndex)
                {
               //     strData = "2\r\n12345678\r\n23456789\r\n";
                    strData = m_ModelData.m_nGroupCount.ToString() + "\r\n";

                    for (j = 0; j < m_ModelData.m_nGroupCount; j++)
                    {
                        bReadResult[j] = true;
                        if (m_strBarcode[j] != "" && m_strBarcode[j] != null)
                        {
                            strData += m_strBarcode[j] + "\r\n";
                        }
                        else
                        {             
                            BarcodeScan(0);
                            if (m_strBarcode[j] == "")
                            {
                                BarcodeScan(1);
                                if (m_strBarcode[j] == "")
                                {
                                    BarcodeScan(2);
                                }
                            }
                            if (m_strBarcode[j] == "")
                            {
                                System.Threading.Thread.Sleep(100);
                                BarcodeScan(0);
                                if (m_strBarcode[j] == "")
                                {
                                   // System.Threading.Thread.Sleep(100);
                                    BarcodeScan(1);
                                    if (m_strBarcode[j] == "")
                                    {
                                     //   System.Threading.Thread.Sleep(100);
                                        BarcodeScan(2);
                                    }
                                }
                            }
                            if (m_bNoLabelPass && m_strBarcode[j] == "")
                            {
                                bReadResult[j] = false;
                                m_strBarcode[j] = "NO_Barcode_" + j.ToString();
                            }
                            if (m_strBarcode[j] != "" && m_strBarcode[j] != null)
                            {
                                strData += m_strBarcode[j] + "\r\n";
                            }
                            else
                            {
                                strData = "";
                                break;
                            }
                        }
                    }
                    if (strData != "")
                    {
                        byteSendData = Encoding.Default.GetBytes(strData);
                        if (m_ModelData.m_nGroupCount > 0)
                        {
                            bResult = clientList[i].Send(byteSendData);
                            if (!bResult)
                            {
                                System.Threading.Thread.Sleep(10);
                                bResult = clientList[i].Send(byteSendData);
                            }
                            if (bRetest)
                                DisplayResult("#" + nIndex.ToString() + " Barcode Send Fail ", Color.LightPink);
                        }
                        else
                            bResult = true;
                    }
                    else
                    {
                        if (bRetest)
                            DisplayResult("Barcode Scan Fail ", Color.LightPink);
                    }
                    break;
                }
            }
            bool bScanResult = true;
            for (j = 0; j < m_ModelData.m_nGroupCount; j++)
            {
                bScanResult = bScanResult && bReadResult[j];
            }
            if (m_bSaveImage && !bScanResult)
            {
                if (!System.IO.Directory.Exists("C:\\img"))
                    System.IO.Directory.CreateDirectory("c:\\img");
                DateTime now = new DateTime();
                now = DateTime.Now;
                CogRectangleAffine SegRegion = new CogRectangleAffine();
                if (!System.IO.Directory.Exists("C:\\img\\" + string.Format("{0:0000}", now.Year) + string.Format("{0:00}", now.Month) + string.Format("{0:00}", now.Day)))
                    System.IO.Directory.CreateDirectory("c:\\img\\" + string.Format("{0:0000}", now.Year) + string.Format("{0:00}", now.Month) + string.Format("{0:00}", now.Day));

                string strSaveImgFileName = "c:\\img\\" + string.Format("{0:0000}", now.Year) + string.Format("{0:00}", now.Month) + string.Format("{0:00}", now.Day) + "\\Image_" + string.Format("{0:0000}", now.Year) + string.Format("{0:00}", now.Month) + string.Format("{0:00}", now.Day) + "_" + string.Format("{0:00}", now.Hour) + string.Format("{0:00}", now.Minute) + string.Format("{0:00}", now.Second) + ".bmp";

                SaveImageFile.Operator.Open(strSaveImgFileName, CogImageFileModeConstants.Write);


                ICogAcqFifo AcqFifo = null;

                //int nCaptureIndex = 0;
                int trigNum;
                AcqFifo = _acqFifo1;

                SaveImageFile.Operator.Append(AcqFifo.Acquire(out trigNum));

                SaveImageFile.Operator.Close();

            }

            if (!bResult && !bRetest)
            {
                System.Threading.Thread.Sleep(100);
                bResult  = SendBacode(nIndex, true);
            }
            ScanTimer.Enabled = false;
            for (j = 0; j < m_ModelData.m_nGroupCount; j++)
            {
                m_strSendedBarcode[j] = m_strBarcode[j]; 
                m_strBarcode[j] = "";
                //GridBarcode.Rows[j].Cells[1].Value = "";
            }
                // if (!bResult)
                  //   MessageBox.Show("Send Barcode Fail");
                // GridBarcode.Rows.Clear();
            if (bResult)
            {
                System.Threading.Thread.Sleep(500);
                for (j = 0; j < m_ModelData.m_nGroupCount; j++)
                {
                    m_strBarcode[j] = "";
                    //GridBarcode.Rows[j].Cells[1].Value = "";
                }
                if (nIndex == 2)
                    m_bStation2Using = true;
            }
             //ScanTimer.Enabled = true;
            return bResult;
        }

        private void DIOTimer_Tick(object sender, EventArgs e)
        {
            m_NiDaq.ReadDIN(1, 2);
            if (m_NiDaq.m_nReadPort[0] == 0) // 바코드 리드 신호
            {
                DIOTimer.Enabled = false;
                if (m_nMode == 1)
                    Scheduling_Seq();
                else
                    Scheduling_FCT();

                DIOTimer.Enabled = true;
            }
            else
            {

            }
            if (m_NiDaq.m_nReadPort[1] == 0) //1번 장비 Ready
            {
                btnStatus1.BackColor = Color.LightGreen;
            }
            else
            {
                btnStatus1.BackColor = Color.LightPink;
            }
            if (m_NiDaq.m_nReadPort[2] == 0)//2번 장비 Ready
            {
                btnStatus2.BackColor = Color.LightGreen;
                m_bStation2Using = false;
            }
            else
            {
                btnStatus2.BackColor = Color.LightPink;
            }
            if (m_NiDaq.m_nReadPort[3] == 0)//3번 장비 Ready
            {
                btnStatus3.BackColor = Color.LightGreen;
            }
            else
            {
                btnStatus3.BackColor = Color.LightPink;
            }
            if (m_NiDaq.m_nReadPort[4] == 0)
            {

            }
            else
            {

 
            }
            if (m_NiDaq.m_nReadPort[5] == 0)
            {

            }
            else
            {

            }
            if (m_NiDaq.m_nReadPort[6] == 0)
            {

            }
            else
            {

            }
            if (m_NiDaq.m_nReadPort[7] == 0)
            {

            }
            else
            {

            }
            btnStatus1.Invalidate();
            btnStatus2.Invalidate();
            btnStatus3.Invalidate();
            string strData = "";
            byte[] byteSendData = new byte[256];
            bool bResult;
            for (int i = 0; i < clientList.Count; i++)
            {


                strData = "P";


                byteSendData = Encoding.Default.GetBytes(strData);
                bResult = clientList[i].Send(byteSendData);
            }      
            if (m_arrBufferStatus[0] == 0)
                btnStatusM1.BackColor = Color.LightPink;
            else
                btnStatusM1.BackColor = Color.LightGreen;

            if (m_nMode != 1)
            {
                if (m_arrBufferStatus[1] == 0)
                    btnStatusM2.BackColor = Color.LightPink;
                else
                    btnStatusM2.BackColor = Color.LightGreen;
            }

            if (m_arrBufferStatus[2] == 0)
                btnStatusM3.BackColor = Color.LightPink;
            else
                btnStatusM3.BackColor = Color.LightGreen;
            
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            OptionForm OForm = new OptionForm();
            RefreshTimer.Enabled = false;
            OForm.ShowDialog();
            LoadOption();
            RefreshTimer.Enabled = true;
        }

        public string Conver36to10(string strData)
        {
            int nDecimal = 0;

            int i, j;
            char c;
            string strDecimal = "";
            j = 0;
            strData = strData.ToLower();
            nDecimal = 0;
            for (i = 0; i < strData.Length; i++)
            {
                nDecimal *= 36;
                c = strData[i];
                if (c >= '0' && c <= '9')
                    j = c - '0';
                else if (c >= 'a' && c <= 'z')
                    j = c - 'a' + 10;
                nDecimal += j;
            }
            //strDecimal.Format("%d", nDecimal);
            strDecimal = string.Format("{0:d}", nDecimal);
            return strDecimal;
        }

        public string ConvertDate(string strDate)
        {
            string strOldDate;

            string strYear, strMonth, strDay;

            strYear = strMonth = strDay = "";
            strDate = strDate.ToLower();

            //	strYear.Format("%02d", atoi((LPSTR)(LPCTSTR)(Conver36to10(strDate.GetAt(0)))));
            strYear = string.Format("{0:00}", int.Parse(Conver36to10(strDate.Substring(0, 1))));
            //strMonth.Format("%02d", atoi((LPSTR)(LPCTSTR)(Conver36to10(strDate.GetAt(1)))));
            strMonth = string.Format("{0:00}", int.Parse(Conver36to10(strDate.Substring(1, 1))));
            //strDay.Format("%02d", atoi((LPSTR)(LPCTSTR)(Conver36to10(strDate.GetAt(2)))));
            strDay = string.Format("{0:00}", int.Parse(Conver36to10(strDate.Substring(2, 1))));
            strOldDate = strYear + strMonth + strDay;
            return strOldDate;
        }

        public string ConvertBarcode(string strBarcode)
        {
            string strOldBarcode = "";
            string strData = "";

            if (strBarcode.Length == 23) return strBarcode;
            if (strBarcode.Length != 23 && strBarcode.Length != 15) return "";

            if (strBarcode.Substring(0, 1) == "1")
            {
                strOldBarcode += "EBR";

                strData = string.Format("{0:0000}", int.Parse(Conver36to10(strBarcode.Substring(1, 3))));	    //	strData.Format("%04d", atoi((LPSTR)(LPCTSTR)Conver36to10(strBarcode.Mid(1,3))));
                strOldBarcode += strData;

                //	strData.Format("%04d", atoi((LPSTR)(LPCTSTR)Conver36to10(strBarcode.Mid(4,3))));
                strData = string.Format("{0:0000}", int.Parse(Conver36to10(strBarcode.Substring(4, 3))));
                strOldBarcode += strData;

                strOldBarcode += strBarcode.Substring(7, 2);

                strData = strBarcode.Substring(9, 3);
                strOldBarcode += ConvertDate(strData);

                //strData.Format("%04d", atoi((LPSTR)(LPCTSTR)Conver36to10(strBarcode.Right(3))));
                strData = string.Format("{0:0000}", int.Parse(Conver36to10(strBarcode.Substring(strBarcode.Length - 3, 3))));
                strOldBarcode += strData;
            }
            else if (strBarcode.Substring(0, 1) == "2")
            {
                strOldBarcode += "6871";

                strOldBarcode += strBarcode.Substring(1, 3);

                //strData.Format("%03d", atoi((LPSTR)(LPCTSTR)Conver36to10(strBarcode.Mid(4,2))));
                strData = string.Format("{0:0000}", int.Parse(Conver36to10(strBarcode.Substring(4, 3))));
                strOldBarcode += strData;

                strOldBarcode += strBarcode.Substring(6, 1);

                strOldBarcode += strBarcode.Substring(7, 2);

                strData = strBarcode.Substring(9, 3);
                //	strOldBarcode += ConvertDate(strData);

                //	strData.Format("%04d", atoi((LPSTR)(LPCTSTR)Conver36to10(strBarcode.Right(3))));
                strData = string.Format("{0:0000}", int.Parse(Conver36to10(strBarcode.Substring(strBarcode.Length - 4, 3))));
                strOldBarcode += strData;
            }
            /*
                    if (m_bUsingWatchingCheck)
                    {
                        string cnnStr;

                        cnnStr = "Server=(local);DataBase=testDataBase;uid=sa;pwd=testPwd";



                        Watching PreCheck = new Watching();

                        PreCheck.connection(cnnStr);
                    }*/
            return strOldBarcode;
        }

        private void btnStatus3_Click(object sender, EventArgs e)
        {
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];
           // SendBacode(3, false);
            for (int i = 0; i < 8; i++)
                arrLines[i] = 1;

                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[0] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[0] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];

            //SendBacode(2, false);
            for (int i = 0; i < 8; i++)
                arrLines[i] = 1;

           
                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[1] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[1] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];

           // SendBacode(1, false);
            for (int i = 0; i < 8; i++)
                arrLines[i] = 1;

                    nLines = 0;
                    arrLines[2] = 0;
                    arrLines[4] = 0;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

                    System.Threading.Thread.Sleep(1500);

                    nLines = 0;
                    arrLines[2] = 1;
                    arrLines[4] = 1;
                    for (int nLine = 0; nLine < 8; nLine++)
                    {
                        nLines = nLines << 1;

                        nLines = nLines + arrLines[nLine];
                    }
                    m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);


        }

        public void DisplayResult(string strResult, Color pColor)
        {
            btnResult.Text = strResult;
            btnResult.BackColor = pColor;
        }

        #region EmptyEvent
        private void txtXPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void GridBarcode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStatusM3_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void btnStatusM1_Click(object sender, EventArgs e)
        {
            int nLines = 0;
            int nIndex = 0;
            int[] arrLines = new int[8];

            for (int i = 0; i < 8; i++)
                arrLines[i] = 1;
            nLines = 0;
            arrLines[2] = 0;
            arrLines[4] = 0;
            for (int nLine = 0; nLine < 8; nLine++)
            {
                nLines = nLines << 1;

                nLines = nLines + arrLines[nLine];
            }
            m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);

            System.Threading.Thread.Sleep(1500);

            nLines = 0;
            arrLines[2] = 1;
            arrLines[4] = 1;
            for (int nLine = 0; nLine < 8; nLine++)
            {
                nLines = nLines << 1;

                nLines = nLines + arrLines[nLine];
            }
            m_NiDaq.WriteDOut(1, 0, 0, 7, nLines);
        }
    }

    public class ModelData
    {
        public string m_strXPos = "";
        public string m_strYPos = "";
        public string m_strZPos = "";

        public Rectangle[] m_rGroupRect = null;
        public int m_nGroupCount = 0;
    }
    public class INI
    {
        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);



        public string GetIniValue(string section, string key, string filePath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, filePath);
            return temp.ToString();
        }

        public void SetIniValue(string section, string key, string val, string filePath)
        {
            WritePrivateProfileString(section, key, val, filePath);
        }
    }
}
