using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Panel3 : UserControl
    {
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;
        login login;
        public Panel3(login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();

            //login lgn = new login();
            login.ShowDialog();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            login.line_assy = comboBox3.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            login.assy_laoding = comboBox1.Text;
        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login.spv = rjTextBox1.Texts;
                cnn = new SqlConnection(connetionString);
                SqlDataReader dataReader2;

                cnn.Close();

                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                SqlCommand cmd2 = new SqlCommand("select count(*) as jumlah, nama, level, ext from db_pegawai where noreg = @zip and(tgl_resign is null or tgl_resign >= getdate()) group by nama, level, ext", cnn);
                cmd2.Parameters.AddWithValue("@zip", login.spv);
                dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //hasil = String.Format("{0}", dataReader["jumlah"]);


                    label1.Text = String.Format("{0}", dataReader2["nama"]);
                   
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
        }
    }
}
