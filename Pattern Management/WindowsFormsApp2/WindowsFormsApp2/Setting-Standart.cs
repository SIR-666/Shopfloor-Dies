using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsApp2
{
    public partial class Setting_Standart : Form
    {

        int a1 = 0;
        int a2 = 0;

        public static string L_wire = "";
        public static string F_strip = "";
        public static string R_strip = "";
        public static string Cutter = "";
        public static string Wayback = "";
        public static string F_CH = "";
        public static string R_CH = "";
        public static string F_posY = "";
        public static string R_posY = "";
        public static string No_apl = "";
        public static string No_data = "";
        public static string item_id = "";

        String hasil = "0";
        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;


        Form1 form1 = new Form1();
        SF_CNC sf_cnc;
         public Setting_Standart(SF_CNC sf_cnc)
        {
            InitializeComponent();
            this.sf_cnc = sf_cnc;
            rjButton5.Visible = false;
            label19.Visible = false; 
            button11.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button14.Visible = false;
            button13.Visible = false;
            button12.Visible = false;
            button10.Visible = false;
            button9.Visible = false;
            button8.Visible = false;
            button20.Visible = false;
            button19.Visible = false;
            button18.Visible = false;
            button17.Visible = false;
            button16.Visible = false;
            button15.Visible = false;

        }

        private void Setting_Standart_Load(object sender, EventArgs e)
        {

            rjTextBox1.Texts = sf_cnc.data_bardoce;

    

        }

            
        public Setting_Standart(string text)
        {
            Text = text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            a1++;
            
            label7.Text = a1.ToString(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //a1 -= 0.1;  
            a1--;
            label7.Text = a1.ToString();
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            // usersetting UserSetting = new usersetting(this);
            // UserSetting.Show();
            button11.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button14.Visible = true;
            button13.Visible = true;
            button12.Visible = true;
            button10.Visible = true;
            button9.Visible = true;
            button8.Visible = true;
            button20.Visible = true;
            button19.Visible = true;
            button18.Visible = true;
            button17.Visible = true;
            button16.Visible = true;
            button15.Visible = true;


            //pindah posisi -- geser ke kanan
            label6.Location = new Point(label6.Location.X+20, label6.Location.Y);
            label7.Location = new Point(label7.Location.X+20, label7.Location.Y);
            label8.Location = new Point(label8.Location.X + 20, label8.Location.Y);
            label9.Location = new Point(label9.Location.X + 20, label9.Location.Y);
            label10.Location = new Point(label10.Location.X + 20, label10.Location.Y);
            label11.Location = new Point(label11.Location.X + 20, label11.Location.Y);
            label12.Location = new Point(label12.Location.X + 20, label12.Location.Y);
            label13.Location = new Point(label13.Location.X + 20, label13.Location.Y);
            label14.Location = new Point(label14.Location.X + 20, label14.Location.Y);
            label15.Location = new Point(label15.Location.X + 20, label15.Location.Y);
            label16.Location = new Point(label16.Location.X + 20, label16.Location.Y);
            label17.Location = new Point(label17.Location.X + 20, label17.Location.Y);
            label20.Location = new Point(label20.Location.X + 20, label20.Location.Y);
            label21.Location = new Point(label21.Location.X + 20, label21.Location.Y);
            label22.Location = new Point(label22.Location.X + 20, label22.Location.Y);
            label23.Location = new Point(label23.Location.X + 20, label23.Location.Y);
            label24.Location = new Point(label24.Location.X + 20, label24.Location.Y);
            label25.Location = new Point(label25.Location.X + 20, label25.Location.Y);
        }

        private void rjButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjButton10_Click(object sender, EventArgs e)
        {
            String user;
            user = textBox1.Text;

            if (user == "261201")
            {
                rjButton5.Visible = true;
                label19.Visible = false;
            }
            else
            {
                
                label19.Visible=true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a2++;
            label8.Text = a2.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a2--;
            label8.Text = a2.ToString();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            rjButton5.Visible = false;
            label19.Visible = false;
            button11.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button14.Visible = false;
            button13.Visible = false;
            button12.Visible = false;
            button10.Visible = false;
            button9.Visible = false;
            button8.Visible = false;
            button20.Visible = false;
            button19.Visible = false;
            button18.Visible = false;
            button17.Visible = false;
            button16.Visible = false;
            button15.Visible = false;

            label6.Location = new Point(label6.Location.X - 20, label6.Location.Y);
            label7.Location = new Point(label7.Location.X - 20, label7.Location.Y);
            label8.Location = new Point(label8.Location.X - 20, label8.Location.Y);
            label9.Location = new Point(label9.Location.X - 20, label9.Location.Y);
            label10.Location = new Point(label10.Location.X - 20, label10.Location.Y);
            label11.Location = new Point(label11.Location.X - 20, label11.Location.Y);
            label12.Location = new Point(label12.Location.X - 20, label12.Location.Y);
            label13.Location = new Point(label13.Location.X - 20, label13.Location.Y);
            label14.Location = new Point(label14.Location.X - 20, label14.Location.Y);
            label15.Location = new Point(label15.Location.X - 20, label15.Location.Y);
            label16.Location = new Point(label16.Location.X - 20, label16.Location.Y);
            label17.Location = new Point(label17.Location.X - 20, label17.Location.Y);
            label20.Location = new Point(label20.Location.X - 20, label20.Location.Y);
            label21.Location = new Point(label21.Location.X - 20, label21.Location.Y);
            label22.Location = new Point(label22.Location.X - 20, label22.Location.Y);
            label23.Location = new Point(label23.Location.X - 20, label23.Location.Y);
            label24.Location = new Point(label24.Location.X - 20, label24.Location.Y);
            label25.Location = new Point(label25.Location.X - 20, label25.Location.Y);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        public void load_data(string terma, string termb)
        {
            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader2;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Close();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            //Console.WriteLine(rjTextBox1.Texts);

            //MessageBox.Show(sf_cnc.label45.Text);
            //MessageBox.Show(sf_cnc.label44.Text);

            
            
            string size_wire = sf_cnc.labelwire_rph.Text;

            string[] wire_size = size_wire.Split('-');

            string[] wire_size2 = wire_size[1].Split(' ');
            string query = "null";

            Console.WriteLine(wire_size2[0]);

            if (terma != "null" && termb != "null")
            {
                query = "SELECT TOP(1) * from SFC_masterterminal where terminal_a ='";
                query = query + terma + "' and size ='";
                query = query + wire_size2[0] + "' and terminal_b ='";
                query = query + termb + "'";
            }

            else if (terma == "null")
            {
                query = "SELECT TOP(1) * from SFC_masterterminal where terminal_b ='";
                query = query + termb + "' and size ='";
                query = query + wire_size2[0] + "'";
            }

            else if (termb == "null")
            {
                query = "SELECT TOP(1) * from SFC_masterterminal where terminal_a ='";
                query = query + terma + "' and size ='";
                query = query + wire_size2[0] + "'";
            }


            MessageBox.Show(query);
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@barcode", sf_cnc.label45.Text);
            cmd.Parameters.AddWithValue("@apli", sf_cnc.label44.Text);
            dataReader2 = cmd.ExecuteReader();
            Console.WriteLine("coba");
                while (dataReader2.Read())
                {

                    //variabel VB ---- nama coloum database

                   
                    No_data = String.Format("{0}", dataReader2["data"]);

                   
                    Console.WriteLine(No_data);
                    Console.WriteLine("tes");

                   
                    label3.Text = (No_data);

                }
           
        }

        private void rjTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //load_data(rjTextBox2.Texts);
            }
        }

        private void rjTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // load_data(rjTextBox3.Texts);
            }
        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
