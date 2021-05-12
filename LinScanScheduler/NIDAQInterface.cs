using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.DAQmx;

namespace LinScanScheduler
{
    public class NIDAQInterface
    {
        public int[] m_nWritePort = new int[16];
        public int[] m_nReadPort = new int[8];
        
        public NIDAQInterface()
        {
            for (int i = 0; i < 8; i++)
            {
                m_nReadPort[i] = 1;
                m_nWritePort[i] = 1;
                m_nWritePort[i + 8] = 1;
            }
        }

        public void WriteDOut(int nDev, int nPort, int nStartLine, int nEndLine, int nLines)
        {
            string strDev = "Dev" + string.Format("{0:d}", nDev) + "/port" +                
                            string.Format("{0:d}", nPort) + "/line" + 
                            string.Format("{0:d}", nStartLine) + 
                            ":" + string.Format("{0:d}", nEndLine);

            try
            {
                using (Task digitalWriteTask = new Task())
                {
                    digitalWriteTask.DOChannels.CreateChannel(strDev, "",
                        ChannelLineGrouping.OneChannelForAllLines);
                    bool[] dataArray = new bool[8];
                    int nTemp = nLines;
                    bool bTemp;
                    for (int i = nStartLine; i <= nEndLine; i++)
                    {
                        if ((nTemp & 1) == 1)
                            bTemp = true;
                        else
                            bTemp = false;

                        dataArray[nEndLine - nStartLine - (i - nStartLine)] = bTemp;
                        nTemp = nTemp >> 1;
                    }

                    DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
                    if (nStartLine != nEndLine)
                        writer.WriteSingleSampleMultiLine(true, dataArray);
                    else
                        writer.WriteSingleSampleSingleLine(true, dataArray[0]);
                }
            }
            catch (DaqException ex)
            {
              //  MessageBox.Show(ex.Message);
            }
            finally
            {
             //   Cursor.Current = Cursors.Default;
            }

        }

        public int ReadDIN(int nDev, int nPort, int nStartLine, int nEndLine)
        {

            int nResult = 0;
            string strDev = "Dev" + string.Format("{0:d}", nDev) + "/port" + string.Format("{0:d}", nPort) + "/line" + string.Format("{0:d}", nStartLine) + ":" + string.Format("{0:d}", nEndLine);
            try
            {
                using (Task digitalReadTask = new Task())
                {
                    digitalReadTask.DIChannels.CreateChannel(strDev, "",
                        ChannelLineGrouping.OneChannelForAllLines);

                    DigitalSingleChannelReader reader = new DigitalSingleChannelReader(digitalReadTask.Stream);
                    UInt32 data = reader.ReadSingleSamplePortUInt32();
                    nResult = int.Parse(data.ToString());

                    //Update the Data Read box
                    //     hexData.Text = String.Format("0x{0:X}", data);
                }
            }
            catch (DaqException ex)
            {
             //   MessageBox.Show(ex.Message);
            }
            finally
            {
             //   Cursor.Current = Cursors.Default;
            }
            return nResult;
        }

        public void ReadDIN(int nDev, int nPort)
        {
            int nResult;

            nResult = ReadDIN(nDev, nPort, 0, 7);
            int nTemp = nResult;
            for (int i = 0; i < 8; i++)
            {
                if (nTemp % 2 == 1)
                    m_nReadPort[i] = 1;
                else
                    m_nReadPort[i] = 0;
                nTemp = nTemp >> 1;
            }

        }
    }
}
