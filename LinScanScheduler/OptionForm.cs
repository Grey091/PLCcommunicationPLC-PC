using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LinScanScheduler
{
    public partial class OptionForm : Form
    {
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
        public int m_nMode = 1;
        
        public OptionForm()
        {
            InitializeComponent();
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

            string strdata;


            INI.WritePrivateProfileString("Setup", "Light Comm Port", txtLightCommPort.Text, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Read D Address", m_strPLCReadDAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Read M Address", m_strPLCReadMAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Write D Address", m_strPLCWriteDAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Write M Address", m_strPLCWriteMAddress, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Port", m_strPLCPort, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Baudrate", m_strPLCBaudrate, m_strSetupINIFile);
            INI.WritePrivateProfileString("PLC", "Channel", m_strPLCChannel, m_strSetupINIFile);
            INI.WritePrivateProfileString("Setup", "Mode", m_nMode.ToString(), m_strSetupINIFile);
            INI.WritePrivateProfileString("DB", "User ID", txtDBID.Text, m_strSetupINIFile);
            INI.WritePrivateProfileString("DB", "Password", txtDBPassword.Text, m_strSetupINIFile);
            INI.WritePrivateProfileString("DB", "IP Address", txtDBIPAddress.Text, m_strSetupINIFile);
            if (chkDBCheck1.Checked)
                strdata = "1";
            else
                strdata = "0";

            INI.WritePrivateProfileString("DB", "Check DB1", strdata, m_strSetupINIFile);
            if (chkDBCheck2.Checked)
                strdata = "1";
            else
                strdata = "0";
            INI.WritePrivateProfileString("DB", "Check DB2", strdata, m_strSetupINIFile);
            if (chkNoLabel.Checked)
                strdata = "1";
            else
                strdata = "0";
            INI.WritePrivateProfileString("Setup", "No Label Pass", strdata, m_strSetupINIFile);
            if (chkSaveImage.Checked)
                strdata = "1";
            else
                strdata = "0";
            INI.WritePrivateProfileString("Setup", "Save Image", strdata, m_strSetupINIFile);


        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            FileInfo fileinfo = new FileInfo(Application.ExecutablePath);
            m_strSetupINIFile = fileinfo.Directory.FullName + @"\\Setup.ini";
            LoadOption();
        }

        public void LoadOption()
        {
            StringBuilder temp = new StringBuilder(255);
            int i;
            i = INI.GetPrivateProfileString("Setup", "Light Comm Port", "COM4", temp, 255, m_strSetupINIFile);
            txtLightCommPort.Text = temp.ToString();
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
            i = INI.GetPrivateProfileString("Setup", "Mode", "1", temp, 255, m_strSetupINIFile);

            int.TryParse(temp.ToString(), out m_nMode);
            if (m_nMode == 1)
            {
                btnICT.BackColor = Color.LightGreen;
                btnFCT.BackColor = Color.LightPink;
            }
            else
            {
                m_nMode = 2;
                btnFCT.BackColor = Color.LightGreen;
                btnICT.BackColor = Color.LightPink;

            }
            i = INI.GetPrivateProfileString("DB", "User ID","", temp, 255, m_strSetupINIFile);
            txtDBID.Text = temp.ToString();
            i = INI.GetPrivateProfileString("DB", "Password", "", temp, 255, m_strSetupINIFile);
            txtDBPassword.Text = temp.ToString();
            i = INI.GetPrivateProfileString("DB", "IP Address", "", temp, 255, m_strSetupINIFile);
            txtDBIPAddress.Text = temp.ToString();
            string strdata;
            i = INI.GetPrivateProfileString("DB", "Check DB1", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();

            if (strdata == "1" )
                chkDBCheck1.Checked =true;
            else
                chkDBCheck1.Checked =false;

            i = INI.GetPrivateProfileString("DB", "Check DB2", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();
            if (strdata == "1" )
                chkDBCheck2.Checked =true;
            else
                chkDBCheck2.Checked =false;
            
            i = INI.GetPrivateProfileString("Setup", "No Label Pass", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();
            if (strdata == "1")
                chkNoLabel.Checked = true;
            else
                chkNoLabel.Checked = false;

            i = INI.GetPrivateProfileString("Setup", "Save Image", "0", temp, 255, m_strSetupINIFile);
            strdata = temp.ToString();
            if (strdata == "1")
                chkSaveImage.Checked = true;
            else
                chkSaveImage.Checked = false;

            txtDReadAddr.Text = m_strPLCReadDAddress;
            txtMReadAddr.Text = m_strPLCReadMAddress;
            txtDWriteAddr.Text = m_strPLCWriteDAddress;
            txtMWriteAddr.Text = m_strPLCWriteMAddress;
            txtPLCPort.Text = m_strPLCPort;
            txtBaudRate.Text = m_strPLCBaudrate;
            txtPLCChannel.Text = m_strPLCChannel;
        }

        private void btnICT_Click(object sender, EventArgs e)
        {
            m_nMode = 1;
            btnICT.BackColor = Color.LightGreen;
            btnFCT.BackColor = Color.LightPink;

        }

        private void btnFCT_Click(object sender, EventArgs e)
        {
            m_nMode = 2;
            btnFCT.BackColor = Color.LightGreen;
            btnICT.BackColor = Color.LightPink;

        }
    }
}
