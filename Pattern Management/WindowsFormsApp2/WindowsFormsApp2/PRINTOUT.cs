using Microsoft.Reporting.WinForms;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PrinterUtility;
using QRCoder;

namespace WindowsFormsApp2
{
    public partial class PRINTOUT : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public PRINTOUT()
        {
            InitializeComponent();

            PrintDocument printDocument = new PrintDocument();
         //   printDocument.PrinterSettings.PrinterName = "RONGTA-2"; // Set your printer name here

            //printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            //printDocument.Print();
        }

        public string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                return Convert.ToBase64String(imageBytes);
            }
        }

        private void printqrcode()
        { 
            PrinterUtility.EscPosControlId.EscPosControlId obj = new PrinterUtility.EscPosControlId.EscPosControlId();
            var ByteValue = 0;
         //   ByteValue = PrintExtensions.AddBytes(ByteValue, obj.Separator());



           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullPath = Path.Combine(path, @"..\..\Report\ReportMemo.rdlc");
            report.ReportPath = fullPath;

            
            report.EnableExternalImages = true;

            QRCoder.QRCodeGenerator qRCodeGenerator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(textBox2.Text, QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
            Bitmap bitmap = qRCode.GetGraphic(5);
            pictureBox1.Image = bitmap;

            this.appData1.Clear();

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Bmp);
                AppData1 appdata = new AppData1();    
                AppData1.QRCodeRow qrcoderow = appdata.QRCode.NewQRCodeRow();
                qrcoderow.Image = ms.ToArray();
                appdata.QRCode.AddQRCodeRow(qrcoderow);



                //ReportDataSource ds = new ReportDataSource("AppData1", appdata.Barcode);
                ReportDataSource ds = new ReportDataSource();
                ds.Name = "ReportData";
                ds.Value = appdata.QRCode;
                report.DataSources.Clear();
                report.DataSources.Add(ds);
                report.Refresh();
            }
            

            PrintToPrinter(report);
            
        }

        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);
        }

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>5.8cm</PageWidth>
                <PageHeight>327.6cm</PageHeight>
                <MarginTop>0cm</MarginTop>
                <MarginLeft>0cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0cm</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }

        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            /*
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
            */
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left ,
                ev.PageBounds.Top ,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }
}
