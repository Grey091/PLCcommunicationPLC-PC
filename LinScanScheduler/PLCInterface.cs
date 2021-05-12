using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace LinScanScheduler
{
    public class PLCCmd
    {
        public string m_strCommand;
        public int m_nType;
    }   

    public class PLCInterface
    {
        public string m_strSendPLCDReadCMD = "";
        public string m_strSendPLCMReadCMD = "";
        public string m_strSendPLCDWriteCMD = "";
        public string m_strSendPLCMWriteCMD = "";
        public string m_strPLCReadMAddress = "1000";
        public string m_strPLCReadDAddress = "1000";
        public string m_strPLCWriteMAddress = "1100";
        public string m_strPLCWriteDAddress = "1100";
        
        public string m_strPLCPortName = "COM1";        
        public string m_strPLCBaudrate = "9600";
        public string m_strPLCChannel = "00";
        public ArrayList m_PLCQueue = new ArrayList();

        public int AddQueue(string strCmd, int nType)
        {
            PLCCmd pCmd = new PLCCmd();
            
            pCmd.m_strCommand = strCmd;
            pCmd.m_nType = nType;

            return AddQueue(pCmd);
        }
        public int AddQueue(PLCCmd pCmd)
        {
            m_PLCQueue.Add(pCmd);
           
            return m_PLCQueue.Count;
        }

        public PLCCmd GetQueue()
        {
            if (m_PLCQueue.Count <= 0)
                return null;

            PLCCmd pCmd = new PLCCmd();

            pCmd = (PLCCmd)m_PLCQueue[0];

            m_PLCQueue.RemoveAt(0);

            return pCmd;
        }

        public int GetCount()
        {
            if (m_PLCQueue == null)
                return 0;
            return m_PLCQueue.Count;
        }

        public void SetPLCSetting(string strPLCPort, string strPLCBaudrate, string strPLCChannel)
        {
            m_strPLCPortName = strPLCPort;
            m_strPLCBaudrate = strPLCBaudrate;
            m_strPLCChannel = strPLCChannel;
        }

        public void SetReadAddress(string strReadDAddr, string strReadMAddr)
        {
            m_strPLCReadDAddress = strReadDAddr;
            m_strPLCReadMAddress = strReadMAddr;
            SetReadString(strReadDAddr, strReadMAddr);
        }

        public void SetWriteAddress(string strWriteDAddr, string strWriteMAddr)
        {
            m_strPLCWriteDAddress = strWriteDAddr;
            m_strPLCWriteMAddress = strWriteMAddr;
        }



        public void SetReadString(string strPLCReadDAddress, string strPLCReadMAddress)
        {
            m_strPLCReadDAddress = strPLCReadDAddress;
            m_strPLCReadMAddress = strPLCReadMAddress;
            m_strSendPLCMReadCMD = "";
            char cCh = (char)0x5;
            m_strSendPLCMReadCMD += cCh;
            m_strSendPLCMReadCMD += m_strPLCChannel.Substring(0, 2);
            m_strSendPLCMReadCMD += "RSB0" + (3 + m_strPLCReadMAddress.Length).ToString() + "%MW";
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
            m_strSendPLCDReadCMD += "04";
            cCh = (char)0x04;
            m_strSendPLCDReadCMD += cCh;
            cCh = (char)0x00;
            for (int i = 0; i < m_strSendPLCDReadCMD.Length; i++)
            {
                cCh += m_strSendPLCDReadCMD[i];
            }
            m_strSendPLCDReadCMD += cCh;
        }

        public void SetWriteTrigger(int nMode)
        {
            m_strPLCWriteMAddress = m_strSendPLCMWriteCMD;
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
        }

        public void SetWritePosition(string strXPos, string strZPos)
        {
            int nXPos = 0;
            int nZPos = 0;

            nXPos = (int)(double.Parse(strXPos) * 100);
            nZPos = (int)(double.Parse(strZPos) * 100);
            string strData = "";
            string strTemp = "";
            strTemp = String.Format("{0:X4}", nXPos) + "0000";
            strData += strTemp;
            strTemp = String.Format("{0:X4}", nZPos) + "0000";
            strData += strTemp;
            m_strPLCWriteDAddress = m_strSendPLCDWriteCMD;
            char cCh = (char)0x5;

            m_strSendPLCDWriteCMD = "";
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
            m_strSendPLCDWriteCMD += cCh;
        }
    }
}
