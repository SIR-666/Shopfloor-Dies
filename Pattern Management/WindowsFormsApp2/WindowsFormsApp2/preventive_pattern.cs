using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;
using AForge.Imaging;
using AForge.Imaging.Filters;
//using WindowsFormsApp2.Media.Devices;
//using SharpDX.Direct3D11;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data.SqlClient;
using System.Threading;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Org.BouncyCastle.Asn1.X509;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Web;

namespace WindowsFormsApp2
{
    public partial class preventive_pattern : UserControl
    {
        private VideoCapture _capture;
        //private Timer _timer;
        private FilterInfoCollection videoDeviceList, videoDeviceList2;
        private VideoCaptureDevice FinalFrame, FinalFrame2;
        private IVideoSource videoSource, videoSource2;
        public Graphics grap, grap1, grap2, grap3, grap4, grap5, grap6, grap7, grap8;
        string connetionString = "Data Source=192.168.2.1;Initial Catalog=Plant5;User ID=roni@ipg;Password=AutoCasting";

        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;
        String pattern_name;

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                cells_area[1] = 2;
            }
            else
                cells_area[1] = 0;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                cells_area[2] = 3;
            }
            else
                cells_area[2] = 0;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                cells_area[3] = 4;
            }
            else
                cells_area[3] = 0;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                cells_area[4] = 5;
            }
            else
                cells_area[4] = 0;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                cells_area[5] = 6;
            }
            else
                cells_area[5] = 0;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                cells_area[6] = 7;
            }
            else
                cells_area[6] = 0;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                cells_area[7] = 8;
            }
            else
                cells_area[7] = 0;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                cells_area[8] = 9;
            }
            else
                cells_area[8] = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cells_area[0] = 1;
            }
            else
                cells_area[0] = 0;
        }

        private int selectedCellNumber = -1; // No cell selected by default

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pattern_name = comboBox2.Text;
        }

        Bitmap video;

        private void preventive_pattern_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StartVideoSource();
            StartCamera();
           // webBrowser1.Url = new Uri(@"C:\tes.html");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void StartCamera()
        {
            if (_capture != null)
            {
                _capture.Stop();
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _capture = new VideoCapture(); // Default camera
            _capture.ImageGrabbed += ProcessFrame;
            _capture.Start();
        }
        /*
        private void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame, 0);
                if (!frame.IsEmpty)
                {
                    Image<Bgr, Byte> image = frame.ToImage<Bgr, Byte>(); // Convert Mat to Image
                    pictureBox1.Image = image.Bitmap; // Set the PictureBox's Image property to the Bitmap
                    DrawGrid(image.Bitmap);
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
        }
        */
        private void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                Mat frame = new Mat();
                _capture.Retrieve(frame, 0);
                if (!frame.IsEmpty)
                {
                    Image<Bgr, Byte> image = frame.ToImage<Bgr, Byte>(); // Convert Mat to Image
                    UpdatePictureBox(image.Bitmap);
                    DrawGrid(image.Bitmap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdatePictureBox(Bitmap bitmap)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke((Action)delegate
                {
                    UpdatePictureBox(bitmap);
                });
            }
            else
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = bitmap;
            }
        }

        Form1 form;
        int[] cells_area = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private void captureButton_Click_1(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                //timer1.Stop();
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
                pictureBox1.Image = null;
            }
        }

        string item_preven;
        public preventive_pattern(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            videoDeviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoDevice in videoDeviceList)
            {
                comboBox1.Items.Add(videoDevice.Name);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                AutoClosingMessageBox.Show("No video sources found", "Error", 1000);
                return; // Exit if no video sources found
            }

            StartCamera();
            //StartVideoSource();
            /*
            videoSource = new VideoCaptureDevice(videoDeviceList[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set the PictureBox to stretch mode

            try
            {
                videoSource.Start();
            }
            catch (Exception error)
            {
                Console.WriteLine("{0} Exception caught.", error);
            }
            finally
            {
                Console.WriteLine("worked");
            }
            */
            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            SqlCommand cmd = new SqlCommand("select * from historical_pattern_basepatterns", cnn); // "list aplikator" ("select id,hobby from table 1", conn)
            //cmd.Parameters.AddWithValue("@apli", rjTextBox1.Texts);
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);
            dataGridView1.DataSource = dt;
            //return dt;
            datagridget();
        }



        private void datagridget()
        {

            int numRows = dataGridView1.Rows.Count;
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue;
            for (int j = 1; j < numRows; j++)
            {
                try
                {
                    datavalue = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value);
                    Console.WriteLine(datavalue);
                    if (datavalue != null)
                        comboBox2.Items.Add(datavalue);
                }
                catch { }
            }
        }

        private void SelectVideoResolution(VideoCaptureDevice device)
        {
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Width == 1920 && cap.FrameSize.Height == 1080) // HD resolution
                {
                    device.VideoResolution = cap;
                    break;
                }
            }
        }
        private void StartVideoSource()
        {

            try
            {
                videoSource = new VideoCaptureDevice(videoDeviceList[comboBox1.SelectedIndex].MonikerString);
                  //  SelectVideoResolution(videoSource);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                
                videoSource.Start();
                //videoSource.VideoResolution = videoSource.VideoCapabilities(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting video source: {ex.Message}");
            }
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            DrawGrid(bitmap);
            //pictureBox1.BackgroundImage = bitmap;
            SetImageThreadSafe(pictureBox1, bitmap);
        }

        public void SetImageThreadSafe(PictureBox pb, Bitmap bitmap)
        {
            if (pb.InvokeRequired)
            {
                pb.Invoke((Action)delegate
                {
                    SetImageThreadSafe(pb, bitmap);
                });
            }
            else
            {
                pb.Image?.Dispose();
                pb.Image = bitmap;
            }
        }


        
        private void DrawGrid(Bitmap bitmap)
        {
            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                int numCells = 3; // Number of cells in the grid
                int cellWidth = bitmap.Width / numCells;
                int cellHeight = bitmap.Height / numCells;
                Pen pen = new Pen(Color.Red);
                Pen highlightPen = new Pen(Color.DarkGreen, 3); // Pen for highlighting selected cell
                Font font = new Font("Arial", 12);
                Brush brush = new SolidBrush(Color.Red);

                
                for (int x = 0; x <= bitmap.Width; x += cellWidth)
                {
                    g.DrawLine(pen, x, 0, x, bitmap.Height);
                }
                for (int y = 0; y <= bitmap.Height; y += cellHeight)
                {
                    g.DrawLine(pen, 0, y, bitmap.Width, y);
                }
                
                for (int i = 0; i < numCells; i++)
                {
                    for (int j = 0; j < numCells; j++)
                    {
                        int cellNumber = i * numCells + j + 1;
                        

                        for (int m = 0; m < 9; m++)
                        if (cellNumber == cells_area[m])
                        {
                                // Highlight the selected cell
                                PointF point = new PointF(j * cellWidth + 5, i * cellHeight + 5); // Adjust the position for text inside the cell
                                g.DrawString(cellNumber.ToString(), font, brush, point);
                                g.DrawRectangle(highlightPen, j * cellWidth, i * cellHeight, cellWidth, cellHeight);
                        }
                    }
                }
            }
        }

        private async Task<bool> UploadFileAsync(string url, string filePath)
        {
            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    var fileBytes = File.ReadAllBytes(filePath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                    form.Add(fileContent, "file", Path.GetFileName(filePath));

                    var response = await httpClient.PostAsync(url, form);

                    return response.IsSuccessStatusCode;
                }
            }
        }


        private async void captureButton_Click(object sender, EventArgs e)
        {
            // Capture the current frame from the PictureBox
            Bitmap currentFrame = new Bitmap(pictureBox1.Image);

            // Save the captured frame to a JPEG file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg",
                Title = "Save an Image File"
            };

            string filePath = null;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                currentFrame.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            currentFrame.Dispose();
            
            if (filePath != null)
            {
                // Upload the saved file
                //labelStatus.Text = "Uploading...";
                bool uploadSuccess = await UploadFileAsync("http://ixp1.indoprimagemilang.com:81/historical-pattern/public/api/upload-file/" + pattern_name, filePath);
                //labelStatus.Text = uploadSuccess ? "File uploaded successfully!" : "File upload failed.";
            }

            cnn.Close();

            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            SqlCommand cmd = new SqlCommand("EXEC PreventivePattern2 @NamaPattern, @ItemPreventif, @Keterangan;", cnn); // "list aplikator" ("select id,hobby from table 1", conn)

            item_preven = "";
            for (int i = 0; i < 9; i++)
            {
                if(cells_area[i]!=0)
                item_preven += cells_area[i].ToString()+",";
            }

            cmd.Parameters.AddWithValue("@NamaPattern", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ItemPreventif", item_preven);
            cmd.Parameters.AddWithValue("@Keterangan", textBox1.Text);



            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

       

    }
}
