using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class login_rph : UserControl
    {
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;
        String hasil;
        public login_rph()
        {
            InitializeComponent();
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

                Console.WriteLine(rjTextBox1.Texts);
                int lenght = rjTextBox1.Texts.Length;
                string noreg = rjTextBox1.Texts.Remove(7);
                Console.WriteLine(noreg);
                string pass = rjTextBox1.Texts.Remove(0, 7);
                Console.WriteLine(pass);
                login.NoReg = noreg;
                global.sNoreg = noreg;


                SqlCommand cmd = new SqlCommand("SELECT count(*) as jumlah from [MSQCOK] where Noreg=@noreg and Password = @pass", cnn);
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
                    if (Convert.ToInt16(hasil) > 0)
                    {
                        login.stats_rph = true;
                    }
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

                SqlCommand cmd2 = new SqlCommand("select count(*) as jumlah, nama, level, ext from db_pegawai where noreg = @zip and(tgl_resign is null or tgl_resign >= getdate()) group by nama, level, ext", cnn);
                cmd2.Parameters.AddWithValue("@zip", login.NoReg);
                dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //hasil = String.Format("{0}", dataReader["jumlah"]);


                    login.user_name = String.Format("{0}", dataReader2["nama"]);
                    login.level = String.Format("{0}", dataReader2["level"]);
                    login.format_pic = String.Format("{0}", dataReader2["ext"]);
                    Console.WriteLine(login.user_name);
                    Console.WriteLine(login.level);
                    Console.WriteLine(login.format_pic);
                    label2.Text = login.user_name;
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }

            }
        }
    }
}
