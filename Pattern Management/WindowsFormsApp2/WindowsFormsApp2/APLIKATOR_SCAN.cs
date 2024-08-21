using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp2
{
    public partial class APLIKATOR_SCAN : Form
    {
        SF_CNC SF_CNC;
        SqlConnection cnn;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";

        public APLIKATOR_SCAN(SF_CNC sF_CNC)
        {
            InitializeComponent();
            this.SF_CNC = sF_CNC;
            /*
            if (SF_CNC.terminala_stats == true)
            {
                rjTextBox1.Enabled = true;
            }
            else
            {
                rjTextBox1.Enabled = false;
            }

            if (SF_CNC.terminalb_stats == true)
            {
                rjTextBox2.Enabled = true;
            }
            else
            {
                rjTextBox2.Enabled = false;
            }
            */

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {            
            SF_CNC.scan_aplikator_stats = true;
            SF_CNC.label32.Text = rjTextBox1.Texts;
            SF_CNC.label90.Text = rjTextBox2.Texts;
            this.Hide();
        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                

                SqlCommand sql = new SqlCommand("select shoot from msaplikator where KodeAplikator = @kodeaplikator", cnn);
                Shoot_Press sp = new Shoot_Press(this);
                sql.Parameters.AddWithValue("@kodeaplikator", rjTextBox1.Texts);
                
                SqlDataReader dt = sql.ExecuteReader();
                int shoot = 0;
                //MessageBox.Show(rjTextBox1);
                while (dt.Read())
                {
                    shoot = int.Parse(String.Format("{0}", dt["shoot"]));
                    if (shoot > 250000)
                    {                        
                        getDataAplikator(rjTextBox1.Texts);                        
                        //sp.Show();
                        this.Hide();
                    }
                }
                
                rjTextBox2.Focus();



            }
        }

        private void getDataAplikator(String sAplikator)
        {
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            
            Shoot_Press sp = new Shoot_Press(this);

            String nm = sAplikator;
            String[] cari = nm.Split('(');
            SqlCommand nama = new SqlCommand("select kodeaplikator from msaplikator where KodeAplikator like '" + cari[0] +"%' and kodeaplikator != '"+nm+"'", cnn);
            SqlDataReader da = nama.ExecuteReader();
            String rekomendasi = "";
            while (da.Read())
            {

                rekomendasi += String.Format("{0}", da["kodeaplikator"]);
                rekomendasi += "\n";
            }

            if (rekomendasi.Equals(""))
            {
                rekomendasi = "Tidak ada aplikator serupa";
            }

            sp.label2.Text = sAplikator;
            sp.label4.Text = rekomendasi;
            sp.Show();
        }

        private void rjTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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


                SqlCommand sql = new SqlCommand("select shoot from msaplikator where KodeAplikator = @kodeaplikator", cnn);
                Shoot_Press sp = new Shoot_Press(this);
                sql.Parameters.AddWithValue("@kodeaplikator", rjTextBox2.Texts);

                SqlDataReader dt = sql.ExecuteReader();
                int shoot = 0;
                //MessageBox.Show(rjTextBox1);
                while (dt.Read())
                {
                    shoot = int.Parse(String.Format("{0}", dt["shoot"]));
                    if (shoot > 2500)
                    {
                        getDataAplikator(rjTextBox2.Texts);
                        //sp.Show();
                        this.Hide();
                    }
                }

                rjTextBox2.Focus();



            }
        }
    }
}
