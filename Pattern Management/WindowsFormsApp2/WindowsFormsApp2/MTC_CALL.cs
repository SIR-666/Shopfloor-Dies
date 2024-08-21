using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using WindowsFormsControlLibrary1;
using System.Runtime.Remoting.Messaging;
using System.Windows.Media;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Diagnostics.Metrics;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp2
{
    public partial class MTC_CALL : Form
    {
        SF_CNC SF_CNC;
        int countimer = 0;
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string connectionString;
        private string sslM;

        public static string SetValueForText1 = "";
        String hasil = "0";
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;

        public MTC_CALL(SF_CNC sf_CNC)

        {
            InitializeComponent();
           this.SF_CNC = sf_CNC;
            server = "192.168.5.194";
            database = "ipg_andon_cm";
            user = "root";
            password = "123123123";
            port = "3306";
            sslM = "none";

            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
            label2.Text = cal_datenow();
            label3.Text = cal_datenow();

            //comboBox2.Items.Add("Problem Mesin");
            //comboBox2.Items.Add("Problem Aplikator");
            //comboBox2.Items.Add("Problem Wire Seal");
            comboBox2.Items.Add("Problem Supply");
            comboBox2.Items.Add("Ganti Aplikator");
            comboBox2.Items.Add("Ganti Terminal");
            comboBox2.Items.Add("Ganti Wire");
            comboBox2.Items.Add("Connect Wire");
            comboBox2.Items.Add("5R");
            comboBox2.Items.Add("Tunggu Aplikator");
            comboBox2.Items.Add("Setting Aplikator");
            comboBox2.Items.Add("Problem Wire");
            comboBox2.Items.Add("Menguras Drumfeeder");

            label7.Visible = false;

            //comboBox1.Enabled = false;
            //comboBox2.Enabled = false;
            //rjTextBox1.Enabled = false;
                       
                
        }

        String cal_datenow()
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            string datenow = localDate.ToString(culture);
            string[] words2 = datenow.Split(' ');
            //    words2 = words2[0].Split('/');
            datenow = words2[1];

           return datenow;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            label3.Text = cal_datenow();

            countimer++;
            label1.Text = countimer.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                        
            comboBox1.ResetText();
            comboBox1.Items.Clear();
            if (comboBox2.Text == "Problem Mesin")
            {

                comboBox1.Items.Add("CLAMP F");
                comboBox1.Items.Add("CLAMP R");
                comboBox1.Items.Add("DISCHARGE");
                comboBox1.Items.Add("SENSOR STRIPPING");
                comboBox1.Items.Add("CUTTER");
                comboBox1.Items.Add("MEASURING");
                comboBox1.Items.Add("SENSOR CRIMPING");
                comboBox1.Items.Add("SOLENOID VALVE");
                comboBox1.Items.Add("AMP SERVO");
                comboBox1.Items.Add("STRIPPING TIDAK STABIL");
                comboBox1.Items.Add("PANJANG TIDAK STABIL");
                comboBox1.Items.Add("PREFEEDER");
                comboBox1.Items.Add("KELEBIHAN BATAS SENSOR");
                comboBox1.Items.Add("AYUNAN PREFEEDER");
                comboBox1.Items.Add("PC ERROR");
                comboBox1.Items.Add("BELT PUTUS");
                comboBox1.Items.Add("TEKANAN UDARA RENDAH");
                comboBox1.Items.Add("CONVEYOR");
                comboBox1.Items.Add("SENSOR COVER");

                comboBox1.ResetText();


            }
            else if (comboBox2.Text == "Problem Aplikator")
            {
                comboBox1.Items.Add("Aplicator Unlock");
                comboBox1.Items.Add("Barel Insulation Cacat");
                comboBox1.Items.Add("Barel Insulation Terbuka");
                comboBox1.Items.Add("Barel Wire Cacat");
                comboBox1.Items.Add("Bellmouth Besar Atas");
                comboBox1.Items.Add("Bellmouth Besar Bawah");
                comboBox1.Items.Add("Crimp High Naik");
                comboBox1.Items.Add("Crimp High Turun");
                comboBox1.Items.Add("Crimper Pecah");
                comboBox1.Items.Add("Cutter Pecah");
                comboBox1.Items.Add("Kepala Terminal Cacat");
                comboBox1.Items.Add("Kepala Terminal Terpotong");
                comboBox1.Items.Add("Kertas Masuk Aplikator");
                comboBox1.Items.Add("Lock Terminal Cacat");
                comboBox1.Items.Add("Lock Terminal Naik");

                comboBox1.Items.Add("Lock Terminal Naik/ Terbalik");
                comboBox1.Items.Add("Lock Terminal Turun");
                comboBox1.Items.Add("Punggung Terminal Kasar");
                comboBox1.Items.Add("Tabs Atas Terminal Kasar");
                comboBox1.Items.Add("Tabs Atas Terminal Panjang");
                comboBox1.Items.Add("Tabs Bawah Terminal Kasar");
                comboBox1.Items.Add("Tabs Bawah Terminal Panjang");
                comboBox1.Items.Add("Tembaga Crimping Kepanjangan");
                comboBox1.Items.Add("Tembaga Keluar Dari Barel Wire");
                comboBox1.Items.Add("Tembaga Tidak Kelihatan");
                comboBox1.Items.Add("Terminal Bend Down");
                comboBox1.Items.Add("Terminal Bend Up");
                comboBox1.Items.Add("Terminal Cacat");
                comboBox1.Items.Add("Terminal Karat / Kusam");
                comboBox1.Items.Add("Terminal Kusut");
                comboBox1.Items.Add("Terminal Lengket");
                comboBox1.Items.Add("Terminal Meluntir");
                comboBox1.Items.Add("Terminal Numpuk");
                comboBox1.Items.Add("Terminal Numpuk");
                comboBox1.Items.Add("Terminal Numpuk di Bobin");
                comboBox1.Items.Add("Terminal Numpuk di Rell Aplikator");
                comboBox1.Items.Add("Terminal Salah Type");
                comboBox1.Items.Add("Terminal Tidak Tercrimping");
                comboBox1.Items.Add("Tidak Ada Bellmouth Bawah");
                comboBox1.Items.Add("Vinyl Mundur Dari Barel Insulation");
                comboBox1.Items.Add("Vinyl Terjepit Barel Wire");

                comboBox1.ResetText();
            }
            else if (comboBox2.Text == "Problem Wire Seal")
            {
                comboBox1.Items.Add("PROBLEM TIMING BELT");
                comboBox1.Items.Add("DRUMFEEDER");
                comboBox1.Items.Add("ESCAPE SEAL");
                comboBox1.Items.Add("GUIDE SEAL");
                comboBox1.Items.Add("HOLDER SEAL");
                comboBox1.Items.Add("INSERT PIN SEAL");
                comboBox1.Items.Add("INSERT SEAL TERTEKUK");
                comboBox1.Items.Add("KURAS / GANTI WIRE SEAL");
                comboBox1.Items.Add("POSISI WIRE SEAL TIDAK STABIL");
                comboBox1.Items.Add("SEAL SOBEK");
                comboBox1.Items.Add("SENSOR SEAL");
                comboBox1.Items.Add("ESCAPE DRUMFEEDER");
                comboBox1.Items.Add("SELANG TRANSFER SEAL");

                comboBox1.ResetText();
            }
            else
            {
                comboBox1.ResetText();
                comboBox1.Items.Clear();
            }

            SF_CNC.jenis_problem = comboBox2.Text;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SF_CNC.sub_jenis_problem = comboBox1.Text;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();                
                String mcname = null;
                if (SF_CNC.label31.Text == "CSM01")
                {
                    mcname = "201";
                }
                else if (SF_CNC.label31.Text == "CSM02")
                {
                    mcname = "202";
                }
                else if (SF_CNC.label31.Text == "CSM03")
                {
                    mcname = "203";
                }
                else if (SF_CNC.label31.Text == "CSM04")
                {
                    mcname = "204";
                }
                else if (SF_CNC.label31.Text == "CSM05")
                {
                    mcname = "205";
                }                
                else if (SF_CNC.label31.Text == "CSM06")
                {
                    mcname = "206";
                }
                else if (SF_CNC.label31.Text == "CSM07")
                {
                    mcname = "207";
                }
                else if (SF_CNC.label31.Text == "CSM08")
                {
                    mcname = "208";
                }
                else if (SF_CNC.label31.Text == "CSM09")
                {
                    mcname = "209";
                }
                else if (SF_CNC.label31.Text == "CSM10")
                {
                    mcname = "210";
                }
                else if (SF_CNC.label31.Text == "CSM11")
                {
                    mcname = "211";
                }
                else if (SF_CNC.label31.Text == "CSM12")
                {
                    mcname = "212";
                }
                else if (SF_CNC.label31.Text == "CSM13")
                {
                    mcname = "213";
                }
                else if (SF_CNC.label31.Text == "CSM14")
                {
                    mcname = "214";
                }
                else if (SF_CNC.label31.Text == "CSM15")
                {
                    mcname = "215";
                }
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO ActivityLog(MchID, CallID, StatusID, TimeCall) VALUES(?mesin, '1', '1', NOW())";
                cmd.Parameters.Add("?mesin", MySqlDbType.VarChar).Value = mcname;
                //cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = "myaddress";
                cmd.ExecuteNonQuery();                
                MessageBox.Show(mcname);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            label7.Visible = true;
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            //if (rjTextBox2.Texts == "2112W09")
            //{
            //    comboBox2.Enabled = true;
            //    comboBox1.Enabled = true;
            //    rjTextBox1.Enabled = true;
            //}
            //else {
            //    comboBox2.Enabled = false;
            //    comboBox1.Enabled = false;
            //    rjTextBox1.Enabled = false;

            //}


            save_downtime();



        }

        private void save_downtime()
        {

            Console.WriteLine(rjTextBox2.Texts);


            if (rjTextBox2.Texts == "2112W09")
            {
                countimer = 0;
                SetValueForText1 = rjTextBox2.Texts;

                comboBox2.Items.Add("Problem Mesin");
                comboBox2.Items.Add("Problem Aplikator");
                comboBox2.Items.Add("Problem Wire Seal");

                //comboBox2.Enabled = true;
                //comboBox1.Enabled = true;
                rjTextBox1.Enabled = true;

                connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    String mcname = null;
                    if (SF_CNC.label31.Text == "CSM01")
                    {
                        mcname = "201";
                    }
                    else if (SF_CNC.label31.Text == "CSM02")
                    {
                        mcname = "202";
                    }
                    else if (SF_CNC.label31.Text == "CSM03")
                    {
                        mcname = "203";
                    }
                    else if (SF_CNC.label31.Text == "CSM04")
                    {
                        mcname = "204";
                    }
                    else if (SF_CNC.label31.Text == "CSM05")
                    {
                        mcname = "205";
                    }
                    else if (SF_CNC.label31.Text == "CSM06")
                    {
                        mcname = "206";
                    }
                    else if (SF_CNC.label31.Text == "CSM07")
                    {
                        mcname = "207";
                    }
                    else if (SF_CNC.label31.Text == "CSM08")
                    {
                        mcname = "208";
                    }
                    else if (SF_CNC.label31.Text == "CSM09")
                    {
                        mcname = "209";
                    }
                    else if (SF_CNC.label31.Text == "CSM10")
                    {
                        mcname = "210";
                    }
                    else if (SF_CNC.label31.Text == "CSM11")
                    {
                        mcname = "211";
                    }
                    else if (SF_CNC.label31.Text == "CSM12")
                    {
                        mcname = "212";
                    }
                    else if (SF_CNC.label31.Text == "CSM13")
                    {
                        mcname = "213";
                    }
                    else if (SF_CNC.label31.Text == "CSM14")
                    {
                        mcname = "214";
                    }
                    else if (SF_CNC.label31.Text == "CSM15")
                    {
                        mcname = "215";
                    }
                    cmd.CommandText = "update ActivityLog set TimeWaiting = Now(), StatusID= '2' where MchID = ?mesin and TimeWaiting is null and StatusID = '1'";
                    cmd.Parameters.Add("?mesin", MySqlDbType.VarChar).Value = mcname;
                    //  cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = "myaddress";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

            }
            else
            {
                comboBox2.Enabled = false;
                comboBox1.Enabled = false;
                //rjTextBox1.Enabled = false;

                MessageBox.Show("TUNGGU MAINTENANCE");

            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            SF_CNC.keterangan_problem = rjTextBox1.Texts;
            SF_CNC.durasi_problem = label1.Text;
            SF_CNC.start_problem = label2.Text;
            SF_CNC.finish_problem = label3.Text;

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                String mcname = null;
                if (SF_CNC.label31.Text == "CSM01")
                {
                    mcname = "201";
                }
                else if (SF_CNC.label31.Text == "CSM02")
                {
                    mcname = "202";
                }
                else if (SF_CNC.label31.Text == "CSM03")
                {
                    mcname = "203";
                }
                else if (SF_CNC.label31.Text == "CSM04")
                {
                    mcname = "204";
                }
                else if (SF_CNC.label31.Text == "CSM05")
                {
                    mcname = "205";
                }
                else if (SF_CNC.label31.Text == "CSM06")
                {
                    mcname = "206";
                }
                else if (SF_CNC.label31.Text == "CSM07")
                {
                    mcname = "207";
                }
                else if (SF_CNC.label31.Text == "CSM08")
                {
                    mcname = "208";
                }
                else if (SF_CNC.label31.Text == "CSM09")
                {
                    mcname = "209";
                }
                else if (SF_CNC.label31.Text == "CSM10")
                {
                    mcname = "210";
                }
                else if (SF_CNC.label31.Text == "CSM11")
                {
                    mcname = "211";
                }
                else if (SF_CNC.label31.Text == "CSM12")
                {
                    mcname = "212";
                }
                else if (SF_CNC.label31.Text == "CSM13")
                {
                    mcname = "213";
                }
                else if (SF_CNC.label31.Text == "CSM14")
                {
                    mcname = "214";
                }
                else if (SF_CNC.label31.Text == "CSM15")
                {
                    mcname = "215";
                }                
                cmd.Connection = connection;
                cmd.CommandText = "update ActivityLog set TimeFinish = Now(), StatusID= '3' where MchID = ?mesin and TimeFinish is null and StatusID = '2'";
                cmd.Parameters.Add("?mesin", MySqlDbType.VarChar).Value = mcname;
                //String machinename = SF_CNC.label31.ToString;
                //cmd.CommandText = "update ActivityLog set TimeFinish = Now(), StatusID= '3' where MchID = '?mcname' and TimeFinish is null and StatusID = '2'";
                //cmd.Parameters.Add("?mcname", MySqlDbType.VarChar).Value = machinename;
                //cmd.Parameters.Add("?person", MySqlDbType.VarChar).Value = "myname";
                //cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = "myaddress";
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            SF_CNC.downtime_save();

            if (SF_CNC.countimer > 0)
                SF_CNC.timer1.Enabled = true;
            else
                SF_CNC.timer1.Enabled = false;
            this.Close();
        }

        private void MTC_CALL_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(SF_CNC.countimer > 0)
                SF_CNC.timer1.Enabled = true;
            else
                SF_CNC.timer1.Enabled = false;
        }

        private void rjTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_downtime();
            }
        }
    }
}
