using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Globalization;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;

namespace WindowsFormsApp2
{
    public partial class login : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string machine = "";
        public static string machine_name = "";
        public static string aplikator = "";        
        public static string level = "";
        public static string format_pic = "";
        public static string user_name = "";
        public static string NoReg = "";
        public static string shift;
        public static string spv;
        public static bool stats_rph = false;
        public String hasil = "0";
        bool sf_assy=false;
        public static string line_assy, assy_laoding;
        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        string connetionString = "Data Source=192.168.2.1;Initial Catalog=Plant5;User ID=roni@ipg;Password=AutoCasting";
        SqlConnection cnn;

        public login()
        {
            InitializeComponent();
           // label3.Visible = false;
            Panel1 panel = new Panel1();

            // if (string.IsNullOrEmpty(rjTextBox1.Text))
            //{
              //  checkBox1.Enabled = false;
                //checkBox3.Enabled = false;
                //checkBox4.Enabled = false;
                //Console.WriteLine("Checkboxes disabled");
            //}
            //else
            //{
              //  checkBox1.Enabled = true;
                //checkBox3.Enabled = true;
                //checkBox4.Enabled = true;
                //Console.WriteLine("Checkboxes enabled");
            //}

            // Set to no text.
            //  rjTextBox2.Text = "";
            // The password character is an asterisk.
            //  rjTextBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            // rjTextBox2.MaxLength = 14;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread( );
            this.Close();
        }


        

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            

            //  Console.WriteLine(rjTextBox1.Texts);

            if (Convert.ToInt16(hasil) > 0)
            {
                SetValueForText1 = NoReg;

                
                    this.Hide();

                    var form1 = new Form1();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
               

            }
            else
            {
               // label3.Visible = true;
               // label3.Text = "wrong NIK, please enter valid NIK";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string phrase = comboBox1.Text;
            // string[] words = phrase.Split('-');
            // Console.WriteLine(words[1]);
            // machine = words[1];
            // machine_name = phrase;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sf_assy = false;
            tableLayoutPanel3.Hide();
            Panel1 pnl1  = new Panel1();
            addusercontrol(pnl1);
            
        }

        private void addusercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            main_pnl.Controls.Clear();
            main_pnl.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            sf_assy = false;
            tableLayoutPanel3.Hide();
            Panel2 pnl2 = new Panel2(this);
            addusercontrol(pnl2);
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            sf_assy = true;
            
            
        }

        private void main_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cnn = new SqlConnection(connetionString);
                SqlDataReader dataReader, dataReader2;
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

                

                if (sf_assy == false)
                {
                    Console.WriteLine(rjTextBox1.Texts);
                    int lenght = rjTextBox1.Texts.Length;
                    string noreg = rjTextBox1.Texts.Remove(7);
                    Console.WriteLine(noreg);
                    string pass = rjTextBox1.Texts.Remove(0, 7);
                    Console.WriteLine(pass);
                    NoReg = noreg;
                    global.sNoreg = noreg;

                    SqlCommand cmd = new SqlCommand("SELECT count(*) as jumlah from [UsersP5] where Noreg=@noreg and Pass = @pass", cnn);
                    cmd.Parameters.AddWithValue("@noreg", noreg);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Console.WriteLine(dataReader.GetString(0));

                        hasil = String.Format("{0}", dataReader["jumlah"]);



                        Console.WriteLine(hasil);
                        // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                        //data2txt.Text = dataReader.GetString("jumlah");
                    }
                }

                if (Convert.ToInt16(hasil) > 0)
                {
                    SetValueForText1 = NoReg;


                    this.Hide();

                    var form1 = new Form1();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();


                }
                else
                {
                    // label3.Visible = true;
                    // label3.Text = "wrong NIK, please enter valid NIK";
                }
            }
        }

        private void rjTextBox1__TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.Hide();
            login_rph login_Rph = new login_rph();
            addusercontrol(login_Rph);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stats_rph = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

