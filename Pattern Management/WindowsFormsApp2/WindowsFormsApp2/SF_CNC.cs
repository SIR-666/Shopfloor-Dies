using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.RJControls;



namespace WindowsFormsApp2
{
    public partial class SF_CNC : UserControl
    {
        String DebugHex;
        char before;
        int indextclick = 0;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;
        bool hide_SB = false;
        bool show_SB = true;
        bool show_menu1 = false, show_menu2 = false;
        bool form_max = false;
        public string barcode;
        public string jenis_wire;

        public bool N1_stats = false, N2_stats = false, N3_stats = false;

        public string jenis_problem, sub_jenis_problem, keterangan_problem, durasi_problem,start_problem, finish_problem;
        public String panjang_wire;
        public bool terminal_stats = false;
        public bool wire_stats = false;
        public int cycle_time=0;
        public bool scan_aplikator_stats =false;
        public int count_time = 0;
        public string terminal_used;    

        public bool scan_wire_stats = false;
        public bool scan_term_stats = false;

        public int countWOS = 0;
        public int countimer = 0;
        int countCrimp = 0;
        public int qty = 0;

        public bool terminala_stats=false;
        public bool terminalb_stats=false;

        public string data_bardoce;

        Form1 form1;
       // private Form1 form1_;

        public SF_CNC(Form1 form1_)
        {
            InitializeComponent();
          //  rjTextBox1.Focus();
            this.form1 = form1_;

            if (timer1 != null)
            {
                //inputN1 n1 = new inputN1();
                //n1.ShowDialog();
            }

            

            
        }

        private void SF_CNC_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void WOS_ScanButt_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("oke");

            terminala_stats = false;
            terminalb_stats = false;
            if (scan_aplikator_stats == true || label31.Text == "KMX01" || label31.Text == "KMX02" || label31.Text == "KMX03" || label31.Text == "KMX04" || label31.Text == "KMX05" || label31.Text == "KMX06" || label31.Text == "KMX07")
            {
                ScanWOS scanWOS = new ScanWOS(this, null);
                scanWOS.TopMost = true;
                scanWOS.Show();
            }
            else
            {
                MessageBox.Show("SCAN APLIKATOR!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countimer++;
            count_time++;
            label49.Text = count_time.ToString();
            
            if (countimer == 2)
            {
                //System.Diagnostics.Process.Start("osk.exe");
                inputpokayoke inputpokayoke = new inputpokayoke(this);
                inputpokayoke.TopMost = true;
                inputpokayoke.Show();
                N1_stats = true;
                inputpokayoke.rjTextBox11.Texts = panjang_wire.ToString();

                //AUTO POPUP SETTING STANDART
                //Setting_Standart standart = new Setting_Standart();
                //standart.Show();


                // TERM A
                inputpokayoke.rjTextBox1.Texts = label36.Text;
                inputpokayoke.rjTextBox2.Texts = label37.Text;
                inputpokayoke.rjTextBox3.Texts = label34.Text;
                inputpokayoke.rjTextBox4.Texts = label35.Text;

                inputpokayoke.ch_std = Convert.ToDouble(label36.Text);
                inputpokayoke.ih_std = Convert.ToDouble(label37.Text);
                inputpokayoke.ch = Convert.ToDouble(inputpokayoke.rjTextBox1.Texts);
                inputpokayoke.ih = Convert.ToDouble(inputpokayoke.rjTextBox2.Texts);
                inputpokayoke.cw = Convert.ToDouble(inputpokayoke.rjTextBox3.Texts);
                inputpokayoke.iw = Convert.ToDouble(inputpokayoke.rjTextBox4.Texts);

                // TERM B
                inputpokayoke.rjTextBox8.Texts = label62.Text;
                inputpokayoke.rjTextBox9.Texts = label63.Text;
                inputpokayoke.rjTextBox6.Texts = label64.Text;
                inputpokayoke.rjTextBox7.Texts = label65.Text;

                inputpokayoke.chb_std = Convert.ToDouble(label64.Text);
                inputpokayoke.ihb_std = Convert.ToDouble(label65.Text);
                inputpokayoke.chb = Convert.ToDouble(inputpokayoke.rjTextBox6.Texts);
                inputpokayoke.ihb = Convert.ToDouble(inputpokayoke.rjTextBox7.Texts);
                inputpokayoke.cwb = Convert.ToDouble(inputpokayoke.rjTextBox8.Texts);
                inputpokayoke.iwb = Convert.ToDouble(inputpokayoke.rjTextBox9.Texts);
            }
            /*
            else if (countimer == (cycle_time/2) && N1_stats == false)
            {
                //N1_stats = false;
                System.Diagnostics.Process.Start("osk.exe");
                inputpokayoke inputpokayoke = new inputpokayoke(this);
                inputpokayoke.TopMost = true;
                inputpokayoke.Show();
                Console.WriteLine("cek N2");
                inputpokayoke.label6.Text = "INPUT N2";
                rjButton2.Text = "INPUT N2";
                N2_stats = true;
                inputpokayoke.rjTextBox11.Texts = panjang_wire.ToString();
                // TERM A
                inputpokayoke.rjTextBox1.Texts = label36.Text;
                inputpokayoke.rjTextBox2.Texts = label37.Text;
                inputpokayoke.rjTextBox3.Texts = label34.Text;
                inputpokayoke.rjTextBox4.Texts = label35.Text;

                inputpokayoke.ch_std = Convert.ToDouble(label36.Text);
                inputpokayoke.ih_std = Convert.ToDouble(label37.Text);
                inputpokayoke.ch = Convert.ToDouble(inputpokayoke.rjTextBox1.Texts);
                inputpokayoke.ih = Convert.ToDouble(inputpokayoke.rjTextBox2.Texts);
                inputpokayoke.cw = Convert.ToDouble(inputpokayoke.rjTextBox3.Texts);
                inputpokayoke.iw = Convert.ToDouble(inputpokayoke.rjTextBox4.Texts);

                // TERM B
                inputpokayoke.rjTextBox8.Texts = label62.Text;
                inputpokayoke.rjTextBox9.Texts = label63.Text;
                inputpokayoke.rjTextBox6.Texts = label64.Text;
                inputpokayoke.rjTextBox7.Texts = label65.Text;

                inputpokayoke.chb_std = Convert.ToDouble(label64.Text);
                inputpokayoke.ihb_std = Convert.ToDouble(label65.Text);
                inputpokayoke.chb = Convert.ToDouble(inputpokayoke.rjTextBox6.Texts);
                inputpokayoke.ihb = Convert.ToDouble(inputpokayoke.rjTextBox7.Texts);
                inputpokayoke.cwb = Convert.ToDouble(inputpokayoke.rjTextBox8.Texts);
                inputpokayoke.iwb = Convert.ToDouble(inputpokayoke.rjTextBox9.Texts);
            }

            else if (countimer == (cycle_time - 5) && N2_stats == false)
            {
                //N1_stats = false;
                System.Diagnostics.Process.Start("osk.exe");
                inputpokayoke inputpokayoke = new inputpokayoke(this);
                inputpokayoke.TopMost = true;
                inputpokayoke.Show();
                Console.WriteLine("cek N3");
                inputpokayoke.label6.Text = "INPUT N3";
                rjButton2.Text = "INPUT N3";
                N3_stats = true;
                countimer = 0;
                inputpokayoke.rjTextBox11.Texts = panjang_wire.ToString();
                //count_time = 0;
                timer1.Enabled = false;
                // TERM A
                inputpokayoke.rjTextBox1.Texts = label36.Text;
                inputpokayoke.rjTextBox2.Texts = label37.Text;
                inputpokayoke.rjTextBox3.Texts = label34.Text;
                inputpokayoke.rjTextBox4.Texts = label35.Text;

                inputpokayoke.ch_std = Convert.ToDouble(label36.Text);
                inputpokayoke.ih_std = Convert.ToDouble(label37.Text);
                inputpokayoke.ch = Convert.ToDouble(inputpokayoke.rjTextBox1.Texts);
                inputpokayoke.ih = Convert.ToDouble(inputpokayoke.rjTextBox2.Texts);
                inputpokayoke.cw = Convert.ToDouble(inputpokayoke.rjTextBox3.Texts);
                inputpokayoke.iw = Convert.ToDouble(inputpokayoke.rjTextBox4.Texts);

                // TERM B
                inputpokayoke.rjTextBox8.Texts = label62.Text;
                inputpokayoke.rjTextBox9.Texts = label63.Text;
                inputpokayoke.rjTextBox6.Texts = label64.Text;
                inputpokayoke.rjTextBox7.Texts = label65.Text;

                inputpokayoke.chb_std = Convert.ToDouble(label64.Text);
                inputpokayoke.ihb_std = Convert.ToDouble(label65.Text);
                inputpokayoke.chb = Convert.ToDouble(inputpokayoke.rjTextBox6.Texts);
                inputpokayoke.ihb = Convert.ToDouble(inputpokayoke.rjTextBox7.Texts);
                inputpokayoke.cwb = Convert.ToDouble(inputpokayoke.rjTextBox8.Texts);
                inputpokayoke.iwb = Convert.ToDouble(inputpokayoke.rjTextBox9.Texts);
            }
            */
            //Console.WriteLine(countimer);

        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MTC_CALL mtc_CALL = new MTC_CALL(this);
            mtc_CALL.TopMost = true;
            mtc_CALL.Show();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("osk.exe");
            if (rjButton2.Text == "INPUT N1")
            {
                inputpokayoke inputpokayoke = new inputpokayoke(this);
                inputpokayoke.TopMost = true;
                inputpokayoke.Show();
                N1_stats = true;
                inputpokayoke.rjTextBox11.Texts = panjang_wire.ToString();
                // TERM A
                inputpokayoke.rjTextBox1.Texts = label36.Text;
                inputpokayoke.rjTextBox2.Texts = label37.Text;
                inputpokayoke.rjTextBox3.Texts = label34.Text;
                inputpokayoke.rjTextBox4.Texts = label35.Text;

                inputpokayoke.ch_std = Convert.ToDouble(label36.Text);
                inputpokayoke.ih_std = Convert.ToDouble(label37.Text);
                inputpokayoke.ch = Convert.ToDouble(inputpokayoke.rjTextBox1.Texts);
                inputpokayoke.ih = Convert.ToDouble(inputpokayoke.rjTextBox2.Texts);
                inputpokayoke.cw = Convert.ToDouble(inputpokayoke.rjTextBox3.Texts);
                inputpokayoke.iw = Convert.ToDouble(inputpokayoke.rjTextBox4.Texts);

                // TERM B
                inputpokayoke.rjTextBox8.Texts = label62.Text;
                inputpokayoke.rjTextBox9.Texts = label63.Text;
                inputpokayoke.rjTextBox6.Texts = label64.Text;
                inputpokayoke.rjTextBox7.Texts = label65.Text;

                inputpokayoke.chb_std = Convert.ToDouble(label64.Text);
                inputpokayoke.ihb_std = Convert.ToDouble(label65.Text);
                inputpokayoke.chb = Convert.ToDouble(inputpokayoke.rjTextBox6.Texts);
                inputpokayoke.ihb = Convert.ToDouble(inputpokayoke.rjTextBox7.Texts);
                inputpokayoke.cwb = Convert.ToDouble(inputpokayoke.rjTextBox8.Texts);
                inputpokayoke.iwb = Convert.ToDouble(inputpokayoke.rjTextBox9.Texts);
            }
            else if (rjButton2.Text == "INPUT N2" && N1_stats == false)
            {
                //N1_stats = false;
                inputpokayoke inputpokayoke = new inputpokayoke(this);
                inputpokayoke.TopMost = true;
                inputpokayoke.Show();
                Console.WriteLine("cek N2");
                inputpokayoke.label6.Text = "INPUT N2";
                rjButton2.Text = "INPUT N2";
                N2_stats = true;
                inputpokayoke.rjTextBox11.Text = panjang_wire.ToString();
                // TERM A
                

                inputpokayoke.rjTextBox1.Texts = label36.Text;
                inputpokayoke.rjTextBox2.Texts = label37.Text;
                inputpokayoke.rjTextBox3.Texts = label34.Text;
                inputpokayoke.rjTextBox4.Texts = label35.Text;

                inputpokayoke.ch_std = Convert.ToDouble(label36.Text);
                inputpokayoke.ih_std = Convert.ToDouble(label37.Text);
                inputpokayoke.ch = Convert.ToDouble(inputpokayoke.rjTextBox1.Texts);
                inputpokayoke.ih = Convert.ToDouble(inputpokayoke.rjTextBox2.Texts);
                inputpokayoke.cw = Convert.ToDouble(inputpokayoke.rjTextBox3.Texts);
                inputpokayoke.iw = Convert.ToDouble(inputpokayoke.rjTextBox4.Texts);

                // TERM B
                inputpokayoke.rjTextBox8.Texts = label62.Text;
                inputpokayoke.rjTextBox9.Texts = label63.Text;
                inputpokayoke.rjTextBox6.Texts = label64.Text;
                inputpokayoke.rjTextBox7.Texts = label65.Text;

                inputpokayoke.chb_std = Convert.ToDouble(label64.Text);
                inputpokayoke.ihb_std = Convert.ToDouble(label65.Text);
                inputpokayoke.chb = Convert.ToDouble(inputpokayoke.rjTextBox6.Texts);
                inputpokayoke.ihb = Convert.ToDouble(inputpokayoke.rjTextBox7.Texts);
                inputpokayoke.cwb = Convert.ToDouble(inputpokayoke.rjTextBox8.Texts);
                inputpokayoke.iwb = Convert.ToDouble(inputpokayoke.rjTextBox9.Texts);
            }

            else if (rjButton2.Text == "INPUT N3" && N2_stats == false)
            {
                //N1_stats = false;
                inputpokayoke inputpokayoke = new inputpokayoke(this);
                inputpokayoke.TopMost = true;
                inputpokayoke.Show();
                Console.WriteLine("cek N3");
                inputpokayoke.label6.Text = "INPUT N3";
                rjButton2.Text = "INPUT N3";
                N3_stats = true;
                countimer = 0;
                //count_time = 0;
                timer1.Enabled = false;
                inputpokayoke.rjTextBox11.Text = panjang_wire.ToString();
                // TERM A
                inputpokayoke.rjTextBox1.Texts = label36.Text;
                inputpokayoke.rjTextBox2.Texts = label37.Text;
                inputpokayoke.rjTextBox3.Texts = label34.Text;
                inputpokayoke.rjTextBox4.Texts = label35.Text;

                inputpokayoke.ch_std = Convert.ToDouble(label36.Text);
                inputpokayoke.ih_std = Convert.ToDouble(label37.Text);
                inputpokayoke.ch = Convert.ToDouble(inputpokayoke.rjTextBox1.Texts);
                inputpokayoke.ih = Convert.ToDouble(inputpokayoke.rjTextBox2.Texts);
                inputpokayoke.cw = Convert.ToDouble(inputpokayoke.rjTextBox3.Texts);
                inputpokayoke.iw = Convert.ToDouble(inputpokayoke.rjTextBox4.Texts);

                // TERM B
                inputpokayoke.rjTextBox8.Texts = label62.Text;
                inputpokayoke.rjTextBox9.Texts = label63.Text;
                inputpokayoke.rjTextBox6.Texts = label64.Text;
                inputpokayoke.rjTextBox7.Texts = label65.Text;

                inputpokayoke.chb_std = Convert.ToDouble(label64.Text);
                inputpokayoke.ihb_std = Convert.ToDouble(label65.Text);
                inputpokayoke.chb = Convert.ToDouble(inputpokayoke.rjTextBox6.Texts);
                inputpokayoke.ihb = Convert.ToDouble(inputpokayoke.rjTextBox7.Texts);
                inputpokayoke.cwb = Convert.ToDouble(inputpokayoke.rjTextBox8.Texts);
                inputpokayoke.iwb = Convert.ToDouble(inputpokayoke.rjTextBox9.Texts);
            }
        }

        public SF_CNC()
        {
            InitializeComponent();
           


        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            Setting_Standart standart = new Setting_Standart(this);
            standart.Show();
            standart.rjTextBox1.Texts = label45.Text;
            standart.rjTextBox2.Texts = label33.Text;
            standart.rjTextBox3.Texts = label87.Text;
           
            
            string[] terma_parse = label33.Text.Split(' ');
            string[]  termb_parse = label87.Text.Split(' ');

            Console.WriteLine(terminala_stats);
            Console.WriteLine(terminalb_stats);

            if (terminala_stats==true && terminalb_stats==true)
                standart.load_data(terma_parse[1], termb_parse[1]);
            else if(terminala_stats == true && terminalb_stats == false)
                standart.load_data(terma_parse[1], "null");
            else if (terminala_stats == false && terminalb_stats == true)
                standart.load_data("null", termb_parse[1]);

        }

        private void rjButton10_Click(object sender, EventArgs e)
        {
            Scan_Wire scan_Wire = new Scan_Wire(this,null);
            scan_Wire.TopMost = true;
            scan_Wire.Show();            
        }

        private void rjButton13_Click(object sender, EventArgs e)
        {
            APLIKATOR_SCAN aplikator_scan = new APLIKATOR_SCAN(this);
            aplikator_scan.TopMost = true;
            aplikator_scan.Show();
            aplikator_scan.rjTextBox1.Focus();            
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            //Setting_CNC setting_CNC = new Setting_CNC(this,null);
            //setting_CNC.Show();

            Wire_Req wire_Req = new Wire_Req(this);
            //wire_Req.TopMost = true;
            wire_Req.Show();
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        //start 
        private void rjButton3_Click(object sender, EventArgs e)
        {
            if (terminal_stats == true && wire_stats == true)
            {
                try
                {
                    serialPort1.Write("STRT#");
                }
                catch (Exception er)
                {
                    MessageBox.Show("PORT CLOSED");
                }
            }
            else
            {
                MessageBox.Show("Material tidak sesuai");
            }
        }

        private void rjButton9_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
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
            report.dataGridView1.EnableHeadersVisualStyles = false;
            report.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            report.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            string datenow = localDate.ToString(culture);
            Console.WriteLine(datenow);
            string[] words2 = datenow.Split(' ');
            words2 = words2[0].Split('/');
            datenow = words2[2] + "-" + words2[1] + "-" + words2[0];
            Console.WriteLine(datenow);

            /*
            string sift = "2";
            if (DateTime.Now.Hour > 7 && DateTime.Now.Hour <= 16)
            {
                sift = "1";
            }
            */
            string noreg = login.SetValueForText1;
            //SqlCommand cmd2 = new SqlCommand("Exec RPH_CetakHasilCutting '" + login.machine + "', '" + datenow + "', '" + sift + "'", cnn);
            SqlCommand cmd2 = new SqlCommand("Exec [SFC_CETAKHASILCNC] '" + login.machine + "', '" + datenow + "', '" + login.NoReg + "'", cnn);

            cmd2.Parameters.AddWithValue("@noreg", login.NoReg);
            cmd2.Parameters.AddWithValue("@dt", datenow);
            cmd2.Parameters.AddWithValue("@mc", login.machine);
            SqlDataReader da = cmd2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);
            report.dataGridView1.DataSource = dt;

            // hide columns
            report.dataGridView1.Columns["KodeMesin"].Visible = false;
            report.dataGridView1.Columns["ItemFGS"].Visible = false;
            report.dataGridView1.Columns["KodeRPHMeisn"].Visible = false;
            report.dataGridView1.Columns["Urutan"].Visible = false;
            report.dataGridView1.Columns["nomer"].Visible = false;
            report.dataGridView1.Columns["WIRE"].Visible = false;
            report.dataGridView1.Columns["tanggalhasil"].Visible = false;
            report.dataGridView1.Columns["SIFThasil"].Visible = false;
            report.dataGridView1.Columns["jammulai"].Visible = false;
            report.dataGridView1.Columns["jamselesai"].Visible = false;
            report.dataGridView1.Columns["LAMA"].Visible = false;
            report.dataGridView1.Columns["operator"].Visible = false;
            report.dataGridView1.Columns["panjang"].Visible = false;
            report.dataGridView1.Columns["KodeRPHMeisn"].Visible = false;
            report.dataGridView1.Columns["bukakulita"].Visible = false;
            report.dataGridView1.Columns["bukakulitb"].Visible = false;
            report.dataGridView1.Columns["cha"].Visible = false;
            report.dataGridView1.Columns["chb"].Visible = false;
            report.dataGridView1.Columns["iha"].Visible = false;
            report.dataGridView1.Columns["ihb"].Visible = false;
            report.dataGridView1.Columns["cwa"].Visible = false;
            report.dataGridView1.Columns["cwb"].Visible = false;
            report.dataGridView1.Columns["iwa"].Visible = false;
            report.dataGridView1.Columns["iwb"].Visible = false;
            report.dataGridView1.Columns["barcode"].Visible = false;
            report.dataGridView1.Columns["aksesorisA"].Visible = false;
            report.dataGridView1.Columns["aksesorisB"].Visible = false;
            report.dataGridView1.Columns["doublewireA"].Visible = false;
            report.dataGridView1.Columns["doublewireB"].Visible = false;
            report.dataGridView1.Columns["WA"].Visible = false;
            report.dataGridView1.Columns["WB"].Visible = false;
            report.dataGridView1.Columns["GS"].Visible = false;
            report.dataGridView1.Columns["GJ"].Visible = false;
            report.dataGridView1.Columns["QtyCR"].Visible = false;
            report.dataGridView1.Columns["tanggalCR"].Visible = false;
            report.dataGridView1.Columns["SIFTCr"].Visible = false;
            report.dataGridView1.Columns["tanggalRPH"].Visible = false;
            report.dataGridView1.Columns["SIFTRph"].Visible = false;
            report.dataGridView1.Columns["jam"].Visible = false;
            report.dataGridView1.Columns["QtyJT"].Visible = false;
            report.dataGridView1.Columns["tanggalJT"].Visible = false;
            report.dataGridView1.Columns["SIFTJT"].Visible = false;
            report.dataGridView1.Columns["WIPIDJT"].Visible = false;
            report.dataGridView1.Columns["KETJT"].Visible = false;
            report.dataGridView1.Columns["QtySA"].Visible = false;
            report.dataGridView1.Columns["tanggalSA"].Visible = false;
            report.dataGridView1.Columns["SIFTSA"].Visible = false;
            report.dataGridView1.Columns["WIPIDSA"].Visible = false;
            report.dataGridView1.Columns["WIPID"].Visible = false;
            report.dataGridView1.Columns["KETSA"].Visible = false;
            report.dataGridView1.Columns["M1"].Visible = false;
            report.dataGridView1.Columns["M2"].Visible = false;
            report.dataGridView1.Columns["M3"].Visible = false;
            report.dataGridView1.Columns["S3"].Visible = false;
            report.dataGridView1.Columns["TERMINALAX"].Visible = false;
            report.dataGridView1.Columns["TERMINALBX"].Visible = false;
            report.dataGridView1.Columns["noregQC"].Visible = false;
            report.dataGridView1.Columns["QCOK"].Visible = false;
            report.dataGridView1.Columns["QTYASSY"].Visible = false;
            report.dataGridView1.Columns["tanggalcutting"].Visible = false;
            report.dataGridView1.Columns["SIFTCutting"].Visible = false;
            report.dataGridView1.Columns["KodeMesinKomax"].Visible = false;
            report.dataGridView1.Columns["APLIKATORA"].Visible = false;
            report.dataGridView1.Columns["APLIKATORB"].Visible = false;
            report.dataGridView1.Columns["KABEL"].Visible = false;
            report.dataGridView1.Columns["LOTWIRE"].Visible = false;
            report.dataGridView1.Columns["tanggalpilah"].Visible = false;
            report.dataGridView1.Columns["SIFTPilah"].Visible = false;
            report.dataGridView1.Columns["jampilah"].Visible = false;
            report.dataGridView1.Columns["urutpilah"].Visible = false;
            report.dataGridView1.Columns["WireWire"].Visible = false;
            report.dataGridView1.Columns["POSITIONA"].Visible = false;
            report.dataGridView1.Columns["POSITIONB"].Visible = false;
            report.dataGridView1.Columns["LABELWIRE"].Visible = false;
            report.dataGridView1.Columns["CATATAN"].Visible = false;
            report.dataGridView1.Columns["POSITION"].Visible = false;
            report.dataGridView1.Columns["tanggalcrimping"].Visible = false;
            report.dataGridView1.Columns["SIFTCrimping"].Visible = false;
            report.dataGridView1.Columns["jamcrimping"].Visible = false;
            report.dataGridView1.Columns["siapTrf"].Visible = false;
            report.dataGridView1.Columns["RmiTermA"].Visible = false;
            report.dataGridView1.Columns["RmiTermB"].Visible = false;
            report.dataGridView1.Columns["RmiWire"].Visible = false;
            report.dataGridView1.Columns["KodeMesinTemp"].Visible = false;
            report.dataGridView1.Columns["TESTARIK"].Visible = false;
            report.dataGridView1.Columns["tanggalrelease"].Visible = false;
            report.dataGridView1.Columns["LABELTERMINALA"].Visible = false;
            report.dataGridView1.Columns["LABELTERMINALB"].Visible = false;
            report.dataGridView1.Columns["axstatus"].Visible = false;
            report.dataGridView1.Columns["jamkerja"].Visible = false;
            report.dataGridView1.Columns["l1"].Visible = false;
            report.dataGridView1.Columns["l2"].Visible = false;
            report.dataGridView1.Columns["l3"].Visible = false;
            report.dataGridView1.Columns["A1"].Visible = false;
            report.dataGridView1.Columns["A2"].Visible = false;
            report.dataGridView1.Columns["A3"].Visible = false;
            report.dataGridView1.Columns["B1"].Visible = false;
            report.dataGridView1.Columns["B2"].Visible = false;
            report.dataGridView1.Columns["B3"].Visible = false;
            report.dataGridView1.Columns["T1"].Visible = false;
            report.dataGridView1.Columns["T2"].Visible = false;
            report.dataGridView1.Columns["W1"].Visible = false;
            report.dataGridView1.Columns["W2"].Visible = false;
            report.dataGridView1.Columns["W3"].Visible = false;
            report.dataGridView1.Columns["S1"].Visible = false;
         //   report.dataGridView1.Columns["QtyLot"].Visible = false;
            report.dataGridView1.Columns["SIFT"].Visible = false;

           // MessageBox.Show(sift, datenow);
        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            DOWNTIME_RECORD DOWNTIME_RECORD_ = new DOWNTIME_RECORD();
            DOWNTIME_RECORD_.Show();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                indextclick = e.RowIndex;
                //dataGridView1.CurrentCell = dataGridView1.Rows[indextclick].Cells[1];
                this.contextMenuStrip1.Show(dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void requestWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            int cell_wire = 0, jamcut = 0,tglcut=0 ;
            string wire_name, jamcutting, tglcutting_;
            for (int j = 0; j < 35; j++)
            {

                

                if (dataGridView1.Columns[j].HeaderText.ToString() == "WIRE")
                {
                    cell_wire = j;


                }

                if (dataGridView1.Columns[j].HeaderText.ToString() == "jamcutting")
                {
                    jamcut = j;


                }

                if (dataGridView1.Columns[j].HeaderText.ToString() == "tanggalrph1")
                {
                    tglcut = j;

                }

                

            }

            wire_name = dataGridView1.Rows[indextclick].Cells[cell_wire].Value.ToString();
            jamcutting = dataGridView1.Rows[indextclick].Cells[jamcut].Value.ToString();
            tglcutting_ = dataGridView1.Rows[indextclick].Cells[tglcut].Value.ToString();
            MessageBox.Show(dataGridView1.Rows[indextclick].Cells[cell_wire].Value.ToString());
            // Console.WriteLine

            
            cnn = new SqlConnection(connetionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            //String query = "exec HasilCNC '50','1','07:30:00','07:45:00','3800','3800','3800','1.05','1.05','1.05','1.35','1.35','1.35','0','0','8','81860BSS/7116-1473','YSWP-M-0.3','1554723-1 (A09)','1554723-1 (A09)','TA23051497.0091'";
            //String query = "update TrRPHRMIPesan set jampesan = convert(varchar(8), getdate(), 108), tanggalpesan = convert(varchar(10), getdate(), 120) where KodeMesin = @kodemesin and jamwire = @jamcutting and tanggal = @tanggalcutting";
            string tglcuttingnew_ = tglcutting_.Replace("/", "-");
            string[] tglparse = tglcuttingnew_.Split(' ');
            string[] tglparse2 = tglparse[0].Split('-');
            tglcutting_ = tglparse2[2] + "-" + tglparse2[1] + "-" + tglparse2[0];
            string jamcuttingnew = jamcutting.Replace(",", ".");
            String query = "update TrRPHRMIPesan set jampesan = convert(varchar(8), getdate(), 108), tanggalpesan = convert(varchar(10), getdate(), 120) where KodeMesin = ";
            query = query + "'" + label31.Text + "' and ";
            query = query + "jamwire = '" + jamcuttingnew + "' and ";
            query = query + "tanggal = '" + tglcuttingnew_ + "' ";
            MessageBox.Show(query);
            try
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                // cmd.Parameters.AddWithValue("@Kode_Mesin", "CSM02");

              
                //cmd.Parameters.AddWithValue("@jamselesai", label48.Text);
              //  MessageBox.Show(dataGridView1.Rows[indextclick].Cells[jamcut].Value.ToString());
                //MessageBox.Show(tglcutting_);

                cmd.ExecuteNonQuery();

               // MessageBox.Show(query);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void rjButton11_Click(object sender, EventArgs e)
        {
            Term_Scan term_Scan = new Term_Scan(this, null);
            term_Scan.TopMost = true;
            term_Scan.Show();            
        }

        public string ReadData()
        {
            byte tmpByte;
            string rxString = "";

            tmpByte = (byte)serialPort1.ReadByte();
            rxString += ((char)tmpByte);
            Console.WriteLine(tmpByte.ToString());



            try
            {

                rxString += ((char)tmpByte);
                tmpByte = (byte)serialPort1.ReadByte();
                Console.WriteLine(tmpByte.ToString());

            }
            catch (TimeoutException)
            {

            }

            return rxString;
        }

        public void save_current_rph()
        {

            cnn = new SqlConnection(connetionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


            /*
            
            
           
            W1 = '', W2 = '', W3 = '', iha

            M1 = '', M2 = '', M3 = '', ihb
            


            TERMINALAX = '', TERMINALBX = '',
            
            
                */
            /*
            String query = "update trrphmesin set QTYHASIL = @qtyhasil, tanggalhasil = convert(varchar(10), getdate(), 120), SIFThasil = @shift, jammulai = @jammulai, jamselesai = @jamselesai,";
            query += "L1 = @panjang1, L2 = @panjang2, L3 = @panjang3,";
            query += "A1 = @cha1, A2 = @cha2, A3 = @cha3,";
            query += "B1 = @chb1, B2 = @chb2, B3 = @chb3,";
            query += "T1 = @tentiona, T2 = @tentionb, lama = @durasi,";
            query += "TERMINALAX = @terminala, TERMINALBX = @terminalb,";
            query += "APLIKATORA = @aplia, APLIKATORB = @aplib ";
            query += "where barcode = @barcode";
            */

            //String query = "exec HasilCNC '50','1','07:30:00','07:45:00','3800','3800','3800','1.05','1.05','1.05','1.35','1.35','1.35','0','0','8','81860BSS/7116-1473','YSWP-M-0.3','1554723-1 (A09)','1554723-1 (A09)','TA23051497.0091'";
            String query = "exec HasilCNC '"+label43.Text+"','"+ScanWOS.Shift+"','"+label47.Text+"','"+label48.Text+"','"+lenght_n1.Text+"','"+lenght_n2.Text+"','"+lenght_n3.Text+"','"+label40.Text.Replace(',', '.')+"','"+label54.Text.Replace(',', '.')+"','"+label58.Text.Replace(',', '.') + "','"+label68.Text.Replace(',', '.') + "','"+label72.Text.Replace(',', '.')+"','"+label76.Text.Replace(',', '.')+"','"+label42.Text.Replace(',', '.')+"','"+label85.Text.Replace(',', '.')+"','"+label49.Text+"','"+label33.Text+"','"+label87.Text+"','"+label32.Text+"','"+label90.Text+"','"+barcode+"', '"+global.sNoreg+"'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                // cmd.Parameters.AddWithValue("@Kode_Mesin", "CSM02");
                
                cmd.Parameters.AddWithValue("@qtyhasil", label43.Text);
                cmd.Parameters.AddWithValue("@shift", login.shift);
                cmd.Parameters.AddWithValue("@jammulai", label47.Text);
                cmd.Parameters.AddWithValue("@jamselesai", label48.Text);

                cmd.Parameters.AddWithValue("@panjang1", lenght_n1.Text);
                cmd.Parameters.AddWithValue("@panjang2", lenght_n2.Text);
                cmd.Parameters.AddWithValue("@panjang3", lenght_n3.Text);


                cmd.Parameters.AddWithValue("@cha1", Double.Parse(label40.Text.Replace(',', '.')));
                cmd.Parameters.AddWithValue("@cha2", Double.Parse(label54.Text.Replace(',', '.')));
                cmd.Parameters.AddWithValue("@cha3", Double.Parse(label58.Text.Replace(',', '.')));

                cmd.Parameters.AddWithValue("@chb1", Double.Parse(label68.Text.Replace(',', '.')));
                cmd.Parameters.AddWithValue("@chb2", Double.Parse(label72.Text.Replace(',', '.')));
                cmd.Parameters.AddWithValue("@chb3", Double.Parse(label76.Text.Replace(',', '.')));

                cmd.Parameters.AddWithValue("@tentiona", Double.Parse(label42.Text.Replace(',', '.')));
                cmd.Parameters.AddWithValue("@tentionb", Double.Parse(label85.Text.Replace(',', '.')));
                cmd.Parameters.AddWithValue("@durasi", label49.Text);

                cmd.Parameters.AddWithValue("@terminala", label33.Text);
                cmd.Parameters.AddWithValue("@terminalb", label87.Text);

                cmd.Parameters.AddWithValue("@aplia", label32.Text);
                cmd.Parameters.AddWithValue("@aplib", label90.Text);

                
                cmd.Parameters.AddWithValue("@barcode", barcode);
                cmd.ExecuteNonQuery();

                MessageBox.Show(query);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void downtime_save()
        {
            cnn = new SqlConnection(connetionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            String query = "insert into TrRPHMesinSetup(KodeMesin,tanggal,sift,jammulai,jamselesai,keterangan1,keterangan2,lama,keterangan) values(";
            query = query + "'" + login.machine + "'" + ",convert(varchar(10), getdate(), 120)";
            query = query + ",'" + login.shift + "'";
            query = query + ",'" + start_problem + "'";
            query = query + ",'" + finish_problem + "'";
            query = query + ",'" + jenis_problem + "'";
            query = query + ",'" + sub_jenis_problem + "'";
            query = query + ",'" + durasi_problem + "'";
            query = query + ",'" + keterangan_problem + "')";
            
            try
                {
                SqlCommand cmd = new SqlCommand(query, cnn);
               // cmd.Parameters.AddWithValue("@Kode_Mesin", "CSM02");
                /*
                cmd.Parameters.AddWithValue("@KodeRPHMesin", ScanWOS.koderphmesin);
                cmd.Parameters.AddWithValue("@Sift", ScanWOS.Shift);

                cmd.Parameters.AddWithValue("@JamMulai", start_problem);
                cmd.Parameters.AddWithValue("@JamSelesai", finish_problem);

                cmd.Parameters.AddWithValue("@Keterangan", jenis_problem);
                cmd.Parameters.AddWithValue("@Jenis_Downtime", sub_jenis_problem);
                cmd.Parameters.AddWithValue("@Lama", durasi_problem);
                cmd.Parameters.AddWithValue("@Keterangan2", keterangan_problem);
                cmd.Parameters.AddWithValue("@Terminal", null);
                */
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            start_problem = "";
            finish_problem = "";
            jenis_problem = "";
            sub_jenis_problem = "";
            durasi_problem = "";
            keterangan_problem = "";
        }

        public void get_wirebobin(String datatextbox)
        {
            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader;
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
                SqlCommand cmd = new SqlCommand("exec stock_substore @bobin,'OUT'", cnn);
                cmd.Parameters.AddWithValue("@bobin", datatextbox);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    jenis_wire = String.Format("{0}", dataReader["partname"]);



                    Console.WriteLine(jenis_wire);
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
            catch { }
        }

        public void get_terminal_a(String datatextbox)
        {
            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader;
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
                SqlCommand cmd = new SqlCommand("SELECT a.tlotid,b.tiid,b.tipartname,b.tipartnumber,b.tialias,b.tiproductname,b.tiunit FROM dbInventory2..tblFifo a LEFT JOIN dbInventory2..tblItem b ON b.tiid = a.tiid where a.tlotid = @nostiker", cnn);
                cmd.Parameters.AddWithValue("@nostiker", datatextbox);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //jenis_wire = String.Format("{0}", dataReader["partname"]);


                    string partname_term_a = String.Format("{0}", dataReader["tiproductname"]);
                    //Console.WriteLine(jenis_wire);
                    labelterminal.Text = partname_term_a;
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
            catch { }
        }

        public void get_terminal_b(String datatextbox)
        {
            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader;
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
                SqlCommand cmd = new SqlCommand("SELECT a.tlotid,b.tiid,b.tipartname,b.tipartnumber,b.tialias,b.tiproductname,b.tiunit FROM dbInventory2..tblFifo a LEFT JOIN dbInventory2..tblItem b ON b.tiid = a.tiid where a.tlotid = @nostiker", cnn);
                cmd.Parameters.AddWithValue("@nostiker", datatextbox);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //jenis_wire = String.Format("{0}", dataReader["partname"]);

                    string partname_term_b = String.Format("{0}", dataReader["tiproductname"]);

                    labelterminalB.Text = partname_term_b;
                    //Console.WriteLine(jenis_wire);
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
              catch { }
        }

        public void reload_datagridview()
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            string datenow = localDate.ToString(culture);
            Console.WriteLine(datenow);
            string[] words2 = datenow.Split(' ');
            words2 = words2[0].Split('/');
            datenow = words2[2] + "-" + words2[1] + "-" + words2[0];
            Console.WriteLine(datenow);

            string noreg = login.SetValueForText1;
            try
            {
                SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESIN @dt, @mc", cnn);
                cmd2.Parameters.AddWithValue("@dt", datenow);
                cmd2.Parameters.AddWithValue("@mc", login.machine);
                DataTable dt = new DataTable();
                var reader = cmd2.ExecuteReader();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                int numRows = dataGridView1.Rows.Count;
                label29.Text = countWOS.ToString() + " / " + numRows.ToString();
            }
            catch { MessageBox.Show("Cant Connect Database"); }

            
        }









    }
}
