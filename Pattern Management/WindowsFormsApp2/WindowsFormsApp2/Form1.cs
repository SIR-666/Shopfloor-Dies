using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        
        String DebugHex;
        char before;
        static readonly string textFile = "Port_Set.txt";
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;
        bool hide_SB = false;
        bool show_SB = true;
        bool show_menu1 = false, show_menu2 = false;
        bool form_max = false;
        public static string WOS = "";
        public string terminal_used;
        public String ACTIVED_MENU = "KOSONG";
        public string printer_name;
        string port_name = "CSM04";
        public int qty = 0;
        string weight_string;
        int coint_weight = 0;
        string status_form;

        public Form1()
        {
            InitializeComponent();
        
            before = '-';
            
            String datare;
            //  serialPort1.PortName = "COM3";


            //serialPort1.ReadTimeout = 1000;



            string noreg = login.SetValueForText1;
       
            
            // label31.Text login.machine_name;
            /*
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 200;

            */

            // dataGridView1.Columns["QtyLot"].ValueType = typeof(Int32);

            /*
            dataGridView1.Columns["LotNo"].DisplayIndex = 0;
            dataGridView1.Columns["PartNameFG"].DisplayIndex = 1;
            dataGridView1.Columns["seqnoint"].DisplayIndex = 2;
            dataGridView1.Columns["QtyLot"].DisplayIndex = 3;
            dataGridView1.Columns["TERMINALA"].DisplayIndex = 4;
            dataGridView1.Columns["WIRE"].DisplayIndex = 5;
            dataGridView1.Columns["NamaMesin"].DisplayIndex = 6;
            //LotNo
            */

            String user_name = "Hi  " + login.user_name;
          
            string urlphoto = "http://192.168.5.7:8080/indoprima_gemilang/public/img/" + noreg + "." + login.format_pic;
            LoadimagefromUrl(urlphoto);
            //label_noreg.Text = noreg;

            this.WindowState = FormWindowState.Maximized;

            //SF_CNC sf_CNC =  new SF_CNC();
            //  sf_CNC.Click += new EventHandler(WOS_ScanButt_Click);
            //  sf_CNC.WOS_ScanButt.MouseDown += new MouseEventHandler(WOS_ScanButt_Click);
            //   sf_CNC.WOS_ScanButt.MouseDown += new MouseEventHandler(WOS_ScanButt_Click);
            //addusercontrol(sf_CNC);

            string[] lines = File.ReadAllLines(textFile);
            port_name = lines[0];
            printer_name = lines[1];
            Console.WriteLine(port_name);
            Console.WriteLine(printer_name);

            serialPort1.PortName = port_name;

            /*
            // if (serialPort1.IsOpen)
            serialPort1.Close();


            try
            {
                serialPort1.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            */

        }

    

        private void addusercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public Form1 main
        {
            get
            {
                var parent = Parent;
                while (parent != null && (parent as Form1) == null)
                {
                    parent = parent.Parent;
                }
                return parent as Form1;
            }
        }

     //   public void WOS_ScanButt_Click(object sender, EventArgs e)
      //  {
            /*
            SF_CNC sf_CNC = new SF_CNC();
            timer1.Enabled = true;
            int numRows = sf_CNC.dataGridView1.Rows.Count;
            Console.WriteLine(numRows);
            */

          //  MessageBox.Show("OK");
            /*
            ScanWOS newMDIChild = new ScanWOS(this);
            newMDIChild.TopLevel = true;
            newMDIChild.MdiParent = main;
            newMDIChild.Show();
            */

          
    //    }
        

        void LoadimagefromUrl(string url)
        { 
            var request = WebRequest.Create(url);
            try
            {
                using (var respone = request.GetResponse())
                using (var stream = respone.GetResponseStream())
                {
                    //rjButton1.BackgroundImage = Bitmap.FromStream(stream);
                }
            }
            catch { }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           // String datarec = serialPort1.ReadExisting();

          //  MessageBox.Show(datarec);
           // label1.Invoke((MethodInvoker)(() => label1.Text = datarec));
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }

        private void tableLayoutPanel3_Click(object sender, EventArgs e)
        {
            //sidebar.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sidebar.Width = 110;
            if (show_SB == true)
            {
                hide_SB = true;
                show_SB = false;
                showhide_SB();
            }
            else
            {
                show_SB = true;
                hide_SB = false;
                showhide_SB();
            }
            

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        void showhide_SB()
        {
            if (hide_SB == true)
            {
                sidebar.Width = 40;
               
                    //    hide_SB = false;
                    label_noreg.Visible = false;
                    //rjButton1.Visible = false;
                    //flow_menu1.Visible = false;
                    panel_photo.Visible = false;

                
            }

            if (show_SB == true)
            {
                sidebar.Width = 220;

                
                    //  show_SB = false;
                    label_noreg.Visible = true;
                    //rjButton1.Visible = true;
                    panel_photo.Visible = true;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (show_menu1 == false)
            {
                show_menu1 = true;
                flow_menu1.Height = 87;
            }
            else
            {
                show_menu1 = false;
                flow_menu1.Height = 29;
            }
        }

        private void tableLayoutPanel3_DoubleClick(object sender, EventArgs e)
        {

            if (form_max == false)
            {
                this.WindowState = FormWindowState.Maximized;
                this.MaximizeBox = false;
                form_max = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.MaximizeBox = true;
                form_max = false;
            }

        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
           
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            /*
            if (serialPort1.IsOpen)
            {

                try
                {
                    serialPort1.Write("STRT#");
                }
                catch (Exception ex)
                {
                    serialPort1.RtsEnable = false;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.WriteBufferSize = 512;
                    serialPort1.DtrEnable = true;
                    serialPort1.ReadTimeout = 10;
                    serialPort1.WriteTimeout = 1000;
                    serialPort1.Handshake = Handshake.None;
                    try
                    {


                        serialPort1.Open();


                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Port Not Exist");
                        Console.WriteLine("Port Not Exist");
                    }
                   
                }
            }
            else
            {

                serialPort1.Close();
                try
                {


                    serialPort1.Open();


                }
                catch (Exception ex)
                {   MessageBox.Show("Port Not Exist"); 
                    Console.WriteLine("Port Not Exist");
                }
            }
            */
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
         //   inputpokayoke pokayoke = new inputpokayoke(this);
         //   pokayoke.Show();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
         //   serialPort1.Write("RST#");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flow_menu2.Height = 33;
            show_menu2 = false;

            if (show_menu1 == false)
            {
                show_menu1 = true;
                flow_menu1.Height = 110;
            }
            else
            {
                show_menu1 = false;
                flow_menu1.Height = 33;
            }
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
          //  MTC_CALL call_mtc = new MTC_CALL(this);
          //  call_mtc.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void button13_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
            
        }

        private void rjButton11_Click(object sender, EventArgs e)
        {

        }

        //CMC sf

        private void button7_Click(object sender, EventArgs e)
        {
            ACTIVED_MENU = "CNC";
            SF_CNC sf_CNC = new SF_CNC();
            addusercontrol(sf_CNC);

            /*
            if (sf_CNC.serialPort1 != null)
                if (sf_CNC.serialPort1.IsOpen)
                    sf_CNC.serialPort1.Close();

            //  serialPort1.PortName = "/dev/ttyACM0";
            sf_CNC.serialPort1.PortName = "/dev/ttyUSB_DEVICE1";
            //  serialPort1.PortName = "COM3";
            sf_CNC.serialPort1.BaudRate = 9600;
            sf_CNC.serialPort1.Encoding = Encoding.UTF8;
            */
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            string datenow = localDate.ToString(culture);
            Console.WriteLine(datenow);
            string[] words2 = datenow.Split(' ');
            words2 = words2[0].Split('/');
            datenow = words2[2] +"-"+ words2[1] + "-" + words2[0];
            Console.WriteLine(datenow);
            Console.WriteLine(login.machine);
            sf_CNC.label24.Text = "Hi " + login.user_name;

            

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
            sf_CNC.dataGridView1.EnableHeadersVisualStyles = false;
            sf_CNC.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            sf_CNC.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
         //   sf_CNC.dataGridView1.ColumnHeadersHeight = 23;
         //   sf_CNC.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // autosize column             


            string noreg = login.SetValueForText1;
            try
            {
                SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESIN @dt,@mc", cnn);
                //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESINCNC @dt,@mc", cnn);
                cmd2.Parameters.AddWithValue("@dt", datenow);
                cmd2.Parameters.AddWithValue("@mc", login.machine);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sf_CNC.dataGridView1.DataSource = dt;
                int numRows = sf_CNC.dataGridView1.Rows.Count;
                sf_CNC.label29.Text = sf_CNC.countWOS.ToString() + " / " + numRows.ToString();
                sf_CNC.label32.Text = login.aplikator;
                sf_CNC.label31.Text = login.machine_name;
                sf_CNC.dataGridView1.Columns["sift"].Visible = false;
                sf_CNC.dataGridView1.Columns["tanggal"].Visible = false;
            }
            catch { MessageBox.Show("Cant Connect Database"); }
            

            /*
            try
            {

                sf_CNC.serialPort1.RtsEnable = false;
                sf_CNC.serialPort1.Handshake = Handshake.None;
                sf_CNC.serialPort1.WriteBufferSize = 512;
                sf_CNC.serialPort1.DtrEnable = true;
                sf_CNC.serialPort1.ReadTimeout = 10;
                sf_CNC.serialPort1.WriteTimeout = 1000;
                sf_CNC.serialPort1.Handshake = Handshake.None;
                sf_CNC.serialPort1.Open();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            */
            sf_CNC.label31.Text = login.machine;

        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int target = 0, act = 0 ;
            //SF ASSY
            ACTIVED_MENU = "assy";
            //SF_CNC sf_CNC = new SF_CNC();
            SF_ASSY sf_ASSY = new SF_ASSY(this);
            addusercontrol(sf_ASSY);
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            string datenow = localDate.ToString(culture);
            //Console.WriteLine(datenow);
            string[] words2 = datenow.Split(' ');
            words2 = words2[0].Split('/');
            datenow = words2[2] + "-" + words2[1] + "-" + words2[0];
            
            Console.WriteLine(datenow);
            Console.WriteLine(login.line_assy);
            Console.WriteLine(login.assy_laoding);
            //sf_CNC.label24.Text = "Hi " + login.user_name;



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

            try
            {
                SqlCommand cmd2 = new SqlCommand("EXEC Display_Assy @dt, @loading, '1', @mc", cnn);
                //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESINCNC @dt,@mc", cnn);
                cmd2.Parameters.AddWithValue("@dt", datenow);
                cmd2.Parameters.AddWithValue("@mc", login.assy_laoding);
                cmd2.Parameters.AddWithValue("@loading", login.line_assy);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sf_ASSY.dataGridView2.DataSource = dt;
                /*
                int numRows = sf_CNC.dataGridView1.Rows.Count;
                sf_CNC.label29.Text = sf_CNC.countWOS.ToString() + " / " + numRows.ToString();
                sf_CNC.label32.Text = login.aplikator;
                sf_CNC.label31.Text = login.machine_name;
                */
                sf_ASSY.dataGridView2.Columns["ct"].Visible = false;
                //sf_CNC.dataGridView1.Columns["tanggal"].Visible = false;
            }
            catch { MessageBox.Show("Cant Connect Database"); }

            int numRows = sf_ASSY.dataGridView2.Rows.Count;
            int cell_target = 0,cell_current=0;
            for (int i = 0; i < 3; i++)
            {

                if (sf_ASSY.dataGridView2.Columns[i].HeaderText.ToString() == "TARGET")
                {
                    cell_target = i;


                }

                if (sf_ASSY.dataGridView2.Columns[i].HeaderText.ToString() == "ACTUAL")
                {
                    cell_current = i;


                }
            }
                for (int i = 0; i < numRows; i++)
            {
                target = target + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[i].Cells[cell_target].Value);
                act = act + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[i].Cells[cell_current].Value);
            }
                var date = DateTime.Now;
                int hour = date.Hour;
                int minute = date.Minute;
                int totaltime = ((hour * 60) + minute)/60; 
                sf_ASSY.label2.Text = target.ToString();
            //sf_ASSY.label5.Text = act.ToString();
            int current_ = 0;
            int act_out = 0;
            if (totaltime >= 7.5 && totaltime < 8.5)
            {
                for (int j = 0; j < 1; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 8.5 && totaltime < 9.5)
            {
                for (int j = 0; j < 2; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 9.5 && totaltime < 10.5)
            {
                for (int j = 0; j < 3; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 10.5 && totaltime < 11.5)
            {
                for (int j = 0; j < 4; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 11.5 && totaltime < 12.5)
            {
                for (int j = 0; j < 5; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 12.5 && totaltime < 13.5)
            {
                for (int j = 0; j < 6; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 13.5 && totaltime < 14.5)
            {
                for (int j = 0; j < 7; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 14.5 && totaltime < 15.5)
            {
                for (int j = 0; j < 8; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 15.5 && totaltime < 19.5)
            {
                for (int j = 0; j < 9; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text =act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 19.5 && totaltime < 20.5)
            {
                for (int j = 0; j < 1; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 20.5 && totaltime < 21.5)
            {
                for (int j = 0; j < 2; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 21.5 && totaltime < 22.5)
            {
                for (int j = 0; j < 3; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 22.5 && totaltime < 23.5)
            {
                for (int j = 0; j < 4; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 23.5 && totaltime < 0.5)
            {
                for (int j = 0; j < 5; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 0.5 && totaltime < 1.5)
            {
                for (int j = 0; j < 6; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 1.5 && totaltime < 2.5)
            {
                for (int j = 0; j < 7; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 2.5 && totaltime < 3.5)
            {
                for (int j = 0; j < 8; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            else if (totaltime >= 3.5 && totaltime < 7.5)
            {
                for (int j = 0; j < 9; j++)
                {
                    current_ = current_ + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_target].Value);
                    act_out = act_out + Convert.ToInt32(sf_ASSY.dataGridView2.Rows[j].Cells[cell_current].Value);
                }

                sf_ASSY.label7.Text = act_out.ToString();
                sf_ASSY.label5.Text = current_.ToString();
            }
            //int hourMinute = DateTime.Now.ToString("HH:mm");
            Console.WriteLine(totaltime);



        }

        public void load_data_wip()
        {
            cnn.Close();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            /*
            try
            {
                SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESIN @dt,@mc", cnn);
                //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESINCNC @dt,@mc", cnn);
                cmd2.Parameters.AddWithValue("@dt", datenow);
                cmd2.Parameters.AddWithValue("@mc", login.machine);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sf_CNC.dataGridView1.DataSource = dt;
            }
            catch { }
            */

        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            //rph assy
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ACTIVED_MENU = "RPH_ASSY";
            //SF_CNC sf_CNC = new SF_CNC();
            //RPH_ASSY rph_ASSY = new RPH_ASSY();
            RPH_ASSY_HOME rph_ASSY = new RPH_ASSY_HOME();
            addusercontrol(rph_ASSY);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //TRANS_IN transaksi_input = new TRANS_IN(this);
            Pattern_Center pattern_Center = new Pattern_Center();
            addusercontrol(pattern_Center);
            status_form = "IN";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            /*TRANS_OUT transaksi_out = new TRANS_OUT(this);
            addusercontrol(transaksi_out);
            status_form = "OUT";
            */
            Pattern_FBO_Rack PFR = new Pattern_FBO_Rack();
            addusercontrol(PFR); 
        }

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {

            string data_in = serialPort1.ReadLine();
            
            string[] data_parse = data_in.Split('#');
            Console.WriteLine(data_parse[0]);
            UpdateLabelSafe(data_parse[0]);

            /*
            char data_weight = (char)serialPort1.ReadChar();

            if (data_weight == '#')
            {


                if (weight_string == "0")
                    coint_weight++;
                else
                    coint_weight = 0;

                if (coint_weight <= 2)
                {
                    //label6.Invoke((MethodInvoker)(() => label6.Text = weight_string));
                    UpdateLabelSafe(weight_string);
                    Console.WriteLine(weight_string);
                    
                }
                weight_string = "";
            }
            else
                weight_string += data_weight;
            */
        }

        private void UpdateLabelSafe(string text)
        {
            // Check if the control's handle has been created
            /*
            if (label1.IsHandleCreated)
            {
                // Use Invoke or BeginInvoke to update the UI control
                label1.BeginInvoke(new Action(() =>
                {
                    label1.Text = text;
                }));
            }
            else
            {
                // Optionally handle the case when the handle is not created
                // For example, you could queue the update to be executed later
            }
            */
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            preventive_pattern preventive_Pattern = new preventive_pattern(this);
            addusercontrol(preventive_Pattern);
            //preventive_Pattern.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flow_menu1.Height = 33;
            show_menu1 = false;

            if (show_menu2 == false)
            {
                show_menu2 = true;
                flow_menu2.Height = 122;
            }
            else
            {
                show_menu2 = false;
                flow_menu2.Height = 33;
            }
        }




    }
}
