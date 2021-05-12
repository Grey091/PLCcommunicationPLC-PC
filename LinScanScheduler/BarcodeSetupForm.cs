using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Cognex.VisionPro;

namespace LinScanScheduler
{
    public partial class BarcodeSetupForm : Form
    {
        public bool m_bLeftButtonDown = false;
        private Point m_ClickPoint = new Point();
        private Point m_CurrentTopLeft = new Point();
        private Point m_CurrentBottomRight = new Point();
        private Pen m_MyPen;
        private Pen m_RectPen;
        public Point[] m_GroupTopLeft = new Point[6];
        public Point[] m_GroupBottomRight = new Point[6];
        public Rectangle[] m_BarcodeGroupRect = new Rectangle[6];
        public int m_nSelectGroup = 1;
        private Graphics g;
        public LineScanSchedulerForm ParentForm = new LineScanSchedulerForm();
        private Pen RectPen;
        public bool m_bBarcodeRead = false;
        public string m_strModelFile = "";
        public int m_nMode = 1;

        public BarcodeSetupForm()
        {
            InitializeComponent();
        }

        public BarcodeSetupForm(LineScanSchedulerForm PForm)
        {
            InitializeComponent();
            ParentForm = PForm;
        }

        private void ScanDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            string strPoint;
            if (chkEditMode.Checked == true)
            {
                m_bLeftButtonDown = false;
                this.Cursor = Cursors.Default;

                double dZoom = ScanDisplay.Zoom;
                double dDx = ScanDisplay.Width;
                double dDy = ScanDisplay.Height;
                double dIx = ScanDisplay.Width; //ScanDisplay.Image.Width;
                double dIy = ScanDisplay.Height; //ScanDisplay.Image.Height;



                m_GroupTopLeft[m_nSelectGroup - 1].X = (int)((m_CurrentTopLeft.X - (dDx - dIx * dZoom) / 2) / dZoom);
                m_GroupTopLeft[m_nSelectGroup - 1].Y = (int)((m_CurrentTopLeft.Y - (dDy - dIy * dZoom) / 2) / dZoom);
                m_GroupBottomRight[m_nSelectGroup - 1].X = (int)((m_CurrentBottomRight.X - (dDx - dIx * dZoom) / 2) / dZoom);
                m_GroupBottomRight[m_nSelectGroup - 1].Y = (int)((m_CurrentBottomRight.Y - (dDy - dIy * dZoom) / 2) / dZoom);

                m_BarcodeGroupRect[m_nSelectGroup - 1].X = m_GroupTopLeft[m_nSelectGroup - 1].X;
                m_BarcodeGroupRect[m_nSelectGroup - 1].Y = m_GroupTopLeft[m_nSelectGroup - 1].Y;
                m_BarcodeGroupRect[m_nSelectGroup - 1].Width = m_GroupBottomRight[m_nSelectGroup - 1].X - m_GroupTopLeft[m_nSelectGroup - 1].X;
                m_BarcodeGroupRect[m_nSelectGroup - 1].Height = m_GroupBottomRight[m_nSelectGroup - 1].Y - m_GroupTopLeft[m_nSelectGroup - 1].Y;

                strPoint = m_GroupTopLeft[m_nSelectGroup - 1].X.ToString() + ", " + m_GroupTopLeft[m_nSelectGroup - 1].Y.ToString() + ", " + m_GroupBottomRight[m_nSelectGroup - 1].X.ToString() + ", " + m_GroupBottomRight[m_nSelectGroup - 1].Y.ToString();
                gridRectList.Rows[m_nSelectGroup - 1].Cells[0].Value = strPoint;
                gridRectList.Invalidate();
                /*     switch (m_nSelectGroup)
                     {
                         case 1:
                             GroupPoint1.Text = strPoint;
                             break;
                         case 2:
                             GroupPoint2.Text = strPoint;
                             break;
                         case 3:
                             GroupPoint3.Text = strPoint;
                             break;
                         case 4:
                             GroupPoint4.Text = strPoint;
                             break;
                         case 5:
                             GroupPoint5.Text = strPoint;
                             break;
                         case 6:
                             GroupPoint6.Text = strPoint;
                             break;

                     }*/

                m_CurrentTopLeft.X = 0;
                m_CurrentTopLeft.Y = 0;
                m_CurrentBottomRight.X = 0;
                m_CurrentBottomRight.Y = 0;
            }
        }

        private void ScanDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (chkEditMode.Checked == true)
            {
                if (m_bLeftButtonDown)
                {
                    //X좌표 계산
                    if (e.X < m_ClickPoint.X)
                    {
                        m_CurrentTopLeft.X = e.X;
                        m_CurrentBottomRight.X = m_ClickPoint.X;
                    }
                    else
                    {
                        m_CurrentTopLeft.X = m_ClickPoint.X;
                        m_CurrentBottomRight.X = e.X;
                    }
                    //Y좌표계산
                    if (e.Y < m_ClickPoint.Y)
                    {
                        m_CurrentTopLeft.Y = e.Y;
                        m_CurrentBottomRight.Y = m_ClickPoint.Y;
                    }
                    else
                    {
                        m_CurrentTopLeft.Y = m_ClickPoint.Y;
                        m_CurrentBottomRight.Y = e.Y;
                    }

                    //화면초기화
                    ScanDisplay.Refresh();
                    //사각형 그리기
                    g.DrawRectangle(m_MyPen, m_CurrentTopLeft.X, m_CurrentTopLeft.Y, m_CurrentBottomRight.X - m_CurrentTopLeft.X, m_CurrentBottomRight.Y - m_CurrentTopLeft.Y);
                    //Console.WriteLine("그리기 {0} {1} {2} {3} ", CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);
                }
            }
        }

        private void ScanDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (chkEditMode.Checked == true)
            {
                m_bLeftButtonDown = true;
                this.Cursor = Cursors.Cross;
                m_ClickPoint = new Point(e.X, e.Y);

            }
            //화면초기화
            ScanDisplay.Refresh();
        }

        private void BarcodeSetupForm_Load(object sender, EventArgs e)
        {
       //     cbGroupList.SelectedIndex = 0;
            g = this.ScanDisplay.CreateGraphics();
            m_MyPen = new Pen(Color.Red, 2);
            m_MyPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            m_RectPen = new Pen(Color.Blue, 2);
            m_RectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
    //        gridRectList.Rows.Add();
            RectPen = new Pen(Color.Blue, 2);
            RectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Image_Timer.Enabled = true;
            m_nMode = 1;
            btnICT.BackColor = Color.LightGreen;
            btnFCT.BackColor = Color.LightPink;
            m_strModelFile = ParentForm.m_strModelFileName;
            if (m_strModelFile != null && m_strModelFile != "")
            {

                LoadData();
            }
            BarcodeReadTimer.Enabled = false;
            btnBarcode.Text = "Barcode Read Start";
            cogDisplayStatusBarV21.Display = ScanDisplay;
         //   gridRectList.Rows[0].Cells[0].Value = "1";
        }

        public void LoadData()
        {
            StringBuilder temp = new StringBuilder(255);
            int i, j;
            string strSection;
            string strData;
            int nData;



            strSection = "Rect";
            i = INI.GetPrivateProfileString(strSection, "Group Count", "0", temp, 255, m_strModelFile);
            strData = temp.ToString();
            nData = int.Parse(strData);
            
            for (j = 0; j < nData; j++)
            {
                cbGroupList.Items.Add(j + 1);
                i = INI.GetPrivateProfileString(strSection, "Group"+(j+1).ToString(), ",,,,,,", temp, 255, m_strModelFile);
                strData = temp.ToString();
                gridRectList.Rows.Add();
                gridRectList.Rows[j].Cells[0].Value = strData;
            }
            strSection = "Position";
            i = INI.GetPrivateProfileString(strSection, "X-Pos", "0", temp, 255, m_strModelFile);
            txtXPos.Text = (int.Parse(temp.ToString())/100).ToString();
            i = INI.GetPrivateProfileString(strSection, "Y-Pos", "0", temp, 255, m_strModelFile);
            txtYPos.Text = (int.Parse(temp.ToString())/100).ToString();
            i = INI.GetPrivateProfileString(strSection, "Z-Pos", "0", temp, 255, m_strModelFile);
            txtZPos.Text = (int.Parse(temp.ToString()) / 100).ToString();
            
            i = INI.GetPrivateProfileString("Setup", "Mode", "1", temp, 255, m_strModelFile);

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
        }


        public void SaveData()
        {
            string strSection = "Rect";
            string strData = "";
            string strKey = "";
            strKey = "Group Count";
            strData = (gridRectList.Rows.Count-1).ToString();

            INI.WritePrivateProfileString(strSection, strKey, strData, m_strModelFile);
            for (int i = 0; i < gridRectList.Rows.Count-1; i++)
            {
                strData = "";
                if (gridRectList.Rows[i].Cells[0].Value != null)
                {
                    strData = gridRectList.Rows[i].Cells[0].Value.ToString();
                }
                strKey = "Group" + (i + 1).ToString();

                INI.WritePrivateProfileString(strSection, strKey, strData, m_strModelFile);

            }
            strSection = "Position";
            strKey = "X-Pos";
            INI.WritePrivateProfileString(strSection, strKey, txtXPos.Text + "00", m_strModelFile);
            strKey = "Y-Pos";
            INI.WritePrivateProfileString(strSection, strKey, txtYPos.Text + "00", m_strModelFile);
            strKey = "Z-Pos";
            INI.WritePrivateProfileString(strSection, strKey, txtZPos.Text + "00", m_strModelFile);
            INI.WritePrivateProfileString("Setup", "Mode", m_nMode.ToString(), m_strModelFile);
        }

        private void btnInsertGroup_Click(object sender, EventArgs e)
        {
            int nGroupCount = 0;
            nGroupCount = cbGroupList.Items.Count;

            cbGroupList.Items.Add((nGroupCount + 1).ToString());
            gridRectList.Rows.Add();
          //  gridRectList.Rows[nGroupCount].Cells[0].Value = (nGroupCount + 1).ToString();
        }

        private void cbGroupList_DropDownClosed(object sender, EventArgs e)
        {
            m_nSelectGroup = cbGroupList.SelectedIndex + 1;
        }

        private void Image_Timer_Tick(object sender, EventArgs e)
        {
            ICogAcqFifo AcqFifo = null;
            ICogImage cogImage = null;
            AcqFifo = ParentForm._acqFifo1;
            
            if (AcqFifo != null)
            {

                // Acquire an image
                int trigNum;
                //      Cognex.VisionPro.ICogImage image;
                try
                {

                    cogImage = AcqFifo.Acquire(out trigNum);
                }
                catch (Exception ex)
                {

                }


                ScanDisplay.Image = cogImage;
/*
                if (CurrentTopLeft.X >= 0 && CurrentTopLeft.Y >= 0 && CurrentTopLeft.X < ScanDisplay.Width && CurrentTopLeft.Y < ScanDisplay.Height &&
                    CurrentBottomRight.X >= 0 && CurrentBottomRight.Y >= 0 && CurrentBottomRight.X < ScanDisplay.Width && CurrentBottomRight.Y < ScanDisplay.Height)
                    g.DrawRectangle(MyPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);
*/
                Point TPointLT = new Point();
                Point TPointRB = new Point();
                double dZoom;
                double dDx = 0;
                double dDy = 0;
                double dIx = 0;
                double dIy = 0;
                if (ScanDisplay != null)
                {
                    dDx = ScanDisplay.Width;
                    dDy = ScanDisplay.Height;
                    if (ScanDisplay.Image != null)
                    {
                        dIx = ScanDisplay.Image.Width;
                        dIy = ScanDisplay.Image.Height;
                    }
                }
                dZoom = ScanDisplay.Zoom;
                string strData;
                string [] strArray;
                for (int i = 0; i < gridRectList.Rows.Count ; i++)
                {
                    if (gridRectList.Rows[i].Cells[0].Value != null)
                    {
                        strData = gridRectList.Rows[i].Cells[0].Value.ToString();
                        strArray = (strData + ",,,,,").Split(',');
                        TPointLT.X = int.Parse(strArray[0]);
                        TPointLT.Y = int.Parse(strArray[1]);
                        TPointRB.X = int.Parse(strArray[2]);
                        TPointRB.Y = int.Parse(strArray[3]);


                        if (TPointLT.X >= 0 && TPointLT.Y >= 0 && TPointLT.X < ScanDisplay.Width && TPointLT.Y < ScanDisplay.Height &&
                            TPointRB.X >= 0 && TPointRB.Y >= 0 && TPointRB.X < ScanDisplay.Width && TPointRB.Y < ScanDisplay.Height)
                            g.DrawRectangle(RectPen, TPointLT.X, TPointLT.Y, TPointRB.X - TPointLT.X, TPointRB.Y - TPointLT.Y);
                    }
                }
              //  BarcodeScan();
            }

            GC.Collect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_strModelFile != null && m_strModelFile != "")
                SaveData();
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    m_strModelFile = saveFileDialog1.FileName;
                    ParentForm.m_strModelFileName = m_strModelFile;
                    SaveData();
                }
            }
        }

        private void BarcodeSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Image_Timer.Enabled = false;
            System.Threading.Thread.Sleep(200);
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (m_bBarcodeRead)
            {
                m_bBarcodeRead = false;
                BarcodeReadTimer.Enabled = false;
                btnBarcode.Text = "Barcode Read Start";
            }
            else
            {
                m_bBarcodeRead = true;
                BarcodeReadTimer.Enabled = true;
                btnBarcode.Text = "Barcode Read Stop";
            }
            
        }

        public void BarcodeScan()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            BarcodeRead BarcodeScan = new BarcodeRead();
            Rectangle Rect = new Rectangle();
            int nSize, i;
            string[] strtemp;
            nSize = gridRectList.Rows.Count - 1;
            for (i = 0; i < nSize; i++)
            {
                if (gridRectList.Rows[i].Cells[0].Value != null)
                {
                    strtemp = (gridRectList.Rows[i].Cells[0].Value.ToString() + ",,,,,").Split(',');
                    Rect.X = int.Parse(strtemp[0]);
                    Rect.Y = int.Parse(strtemp[1]);
                    Rect.Width = int.Parse(strtemp[2]) - Rect.X;
                    Rect.Height = int.Parse(strtemp[3]) - Rect.Y;
                    BarcodeScan.SetRect(Rect);
                    BarcodeScan.m_imgScreenShot = ScanDisplay.Image;
                    sw.Reset();
                    sw.Start();
                    for (int j = 0; j < 3; j++)
                    {
                        gridRectList.Rows[i].Cells[1].Value = ParentForm.ConvertBarcode(BarcodeScan.ReadBarcode(j));

                        if (gridRectList.Rows[i].Cells[1].Value.ToString() != "")
                        {
                            Trace.WriteLine("Read Barcode :" + gridRectList.Rows[i].Cells[1].Value.ToString() );
 
                            break;
                        }
                        else
                        {
                            Trace.WriteLine("Read Barcode :" + gridRectList.Rows[i].Cells[1].Value.ToString() + " Try Count :" + (j+1).ToString());

                        }
//                            gridRectList.Rows[i].Cells[1].Value = BarcodeScan.ReadBarcode(1);

                    }
                    sw.Stop();
                    Trace.WriteLine("Read Barcode :" + gridRectList.Rows[i].Cells[1].Value.ToString() + " " + sw.ElapsedMilliseconds.ToString());
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

 

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_strModelFile = saveFileDialog1.FileName;
                ParentForm.m_strModelFileName = m_strModelFile;
                SaveData();
            }
        }

        private void BarcodeReadTimer_Tick(object sender, EventArgs e)
        {
            BarcodeScan();
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

        private void btnReadPosition_Click(object sender, EventArgs e)
        {
            ParentForm.ReadPostion();
            txtXPos.Text = (int.Parse(ParentForm.m_strCurrXPos) /100).ToString();
            txtYPos.Text = (int.Parse( ParentForm.m_strCurrYPos) /100).ToString();
            txtZPos.Text = (int.Parse(ParentForm.m_strCurrZPos) / 100).ToString();
            txtSetXPos.Text = txtXPos.Text;
            txtSetYPos.Text = txtYPos.Text;
            txtSetZPos.Text = txtZPos.Text;
        }

        private void btnSetPos_Click(object sender, EventArgs e)
        {
            int nXPos, nYPos, nZPos;

            int.TryParse(txtSetXPos.Text, out nXPos);
            int.TryParse(txtSetYPos.Text, out nYPos);
            int.TryParse(txtSetZPos.Text, out nZPos);

            ParentForm.SetPostion(nXPos*100, nYPos*100, nZPos*100);
        }

        private void gridRectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            int nGroupCount;
            nGroupCount = cbGroupList.Items.Count;
            if (nGroupCount > 0)
            {
                cbGroupList.Items.RemoveAt(nGroupCount - 1);

                gridRectList.Rows.RemoveAt(nGroupCount - 1);
            }
        }
    }
}
