using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
//using Cognex.VisionPro.TwoDSymbol;
//using Cognex.VisionPro.Barcode
using Cognex.VisionPro.ID;
using Cognex.VisionPro.ImageFile;

namespace LinScanScheduler
{
    class BarcodeRead
    {
        public ICogImage m_imgScreenShot = null;
        public Rectangle BarcodeRect = new Rectangle();

        public void SetRect( Rectangle gRect)
        {
            BarcodeRect = gRect;
        }

        public string ReadBarcode(int nMode)
        {
            
            ICogImage cogOutputImage;
            CogImageConvertTool ConvertTool = new CogImageConvertTool();
//            Cog2DSymbolTool cog2DSymbol = new Cog2DSymbolTool();
  //          CogBarcodeTool cog1dSymbol = new CogBarcodeTool();
            CogIDTool cogIDTool = new CogIDTool();
            CogImageFileTool SaveImage = new CogImageFileTool();
            CogIPOneImageTool oneTool = new CogIPOneImageTool();

            CogRectangle cogRect = new CogRectangle();


            CogIPOneImageEqualize EqulParam = new CogIPOneImageEqualize();
            CogIPOneImageMultiplyConstant MultiplyConstant = new CogIPOneImageMultiplyConstant();
            MultiplyConstant.ConstantValue = 2;

            string strReadBarcode = "";
            if( BarcodeRect.Width <= 0 )
                return strReadBarcode;
            if (m_imgScreenShot == null)
                return "";
            ConvertTool.InputImage = m_imgScreenShot;
            ConvertTool.Run();

            if (nMode == 1)
            {
                oneTool.InputImage = ConvertTool.OutputImage;
                //oneTool.Operators.Add(EqulParam);
                oneTool.Operators.Add(MultiplyConstant);
                oneTool.Run();
                cogOutputImage = oneTool.OutputImage;// ConvertTool.OutputImage;
            }
            else if (nMode == 2)
            {
                oneTool.InputImage = ConvertTool.OutputImage;
                oneTool.Operators.Add(EqulParam);
                //oneTool.Operators.Add(MultiplyConstant);
                oneTool.Run();
                cogOutputImage = oneTool.OutputImage;// ConvertTool.OutputImage;
            }
            else
            {
                cogOutputImage = ConvertTool.OutputImage;
            }
            if (BarcodeRect.Width > 0 && BarcodeRect.Height > 0)
            {
                cogRect.SetXYWidthHeight(BarcodeRect.X, BarcodeRect.Y, BarcodeRect.Width, BarcodeRect.Height);
                try
                {
                    ICogRegion cogRegion;
                    cogRegion = new CogRectangle();
                    cogRegion.FitToBoundingBox(cogRect);
                    
                    cogIDTool.InputImage = (CogImage8Grey)cogOutputImage;
                    cogIDTool.RunParams.DisableAllCodes();
                    cogIDTool.RunParams.DataMatrix.Enabled = true;

                    cogIDTool.RunParams.DataMatrix.ProcessControlMetrics = CogIDDataMatrixProcessControlMetricsConstants.None;
                    cogIDTool.Region = cogRegion;

                    cogIDTool.Run();

                    if (cogIDTool.Results != null && cogIDTool.Results.Count == 1)
                        strReadBarcode = cogIDTool.Results[0].DecodedData.DecodedString;
                    /*
                    if (cog2DSymbol.Pattern.Trained)
                        cog2DSymbol.Pattern.Untrain();
                    cog2DSymbol.InputImage = (CogImage8Grey)cogOutputImage;
                    cog2DSymbol.Pattern.TrainImage = (CogImage8Grey)cogOutputImage;
                    cog2DSymbol.SearchRegion = cogRegion;// barcodeRegion;
                    cog2DSymbol.Pattern.Train();
                    if (cog2DSymbol.Pattern.Trained)
                    {
                        try
                        {
                            cog2DSymbol.SearchRegion = cogRegion;// barcodeRegion;
                            cog2DSymbol.Run();
                            if (cog2DSymbol.Result != null)
                                strReadBarcode = cog2DSymbol.Result.DecodedString;

                        }
                        catch (Cognex.VisionPro.Exceptions.CogException)
                        {

                        }
                    }
                    if (strReadBarcode == "")
                    {
                        cog1dSymbol.InputImage = (CogImage8Grey)cogOutputImage;
                        cog1dSymbol.Region = cogRegion;
                        cog1dSymbol.Run();
                        strReadBarcode = cog1dSymbol.Results.ToString();
                    }*/
                    
                }
                catch (Cognex.VisionPro.Exceptions.CogException)
                {

                }
            }
            return strReadBarcode;
        }

      
    }
}
