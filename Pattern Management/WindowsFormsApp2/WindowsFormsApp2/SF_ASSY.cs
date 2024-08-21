using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTextSharp.text.pdf.hyphenation.TernaryTree;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WindowsFormsApp2
{
    public partial class SF_ASSY : UserControl
    {
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;
        int target = 0;
        Form1 form1;
        public SF_ASSY(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

            cnn = new SqlConnection(connetionString);
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
                SqlCommand cmd2 = new SqlCommand("SELECT lot,jammulai FROM TRRPHASSYScan WHERE kodemesin = @kodemesin AND tanggal = CONVERT(VARCHAR(10), GETDATE(), 120) AND jamselesai is null", cnn);
                cmd2.Parameters.AddWithValue("@kodemesin", login.assy_laoding);
                //cmd2.Parameters.AddWithValue("@mc", login.machine);
                DataTable dt = new DataTable();
                var reader = cmd2.ExecuteReader();
                dt.Load(reader);
                dataGridView3.DataSource = dt;
            }
            catch { }

            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT lot,jamselesai FROM TRRPHASSYScan WHERE kodemesin = @kodemesin AND tanggal = CONVERT(VARCHAR(10), GETDATE(), 120) AND jamselesai is not null", cnn);
                cmd2.Parameters.AddWithValue("@kodemesin", login.assy_laoding);
                //cmd2.Parameters.AddWithValue("@mc", login.machine);
                DataTable dt = new DataTable();
                var reader = cmd2.ExecuteReader();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            catch { }


        }

        private void ceLearningButtonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void celearningTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show(guna2TextBox1.Text);

                string[] lotno = guna2TextBox1.Text.Split('.');
               


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



                int noseries = Convert.ToInt32(lotno[1]);
                string query = "EXEC insertToAssy @lot = '";
                query = query + lotno[0] + "',";
                //query = query + "@noseri = " + noseries + ",@shift = 1,";
                query = query + "@noseri = " + noseries + ",";
                query = query + "@operator = '" + global.sNoreg + "', @kodemesin = '";
                query = query + login.assy_laoding + "',@state = 0,@keteranganerr = '\n',@supervisor = '";
                query = query + login.spv + "'";

                MessageBox.Show(query);

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

                cnn.Close();
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
                    SqlCommand cmd2 = new SqlCommand("SELECT lot,jammulai FROM TRRPHASSYScan WHERE kodemesin = @kodemesin AND tanggal = CONVERT(VARCHAR(10), GETDATE(), 120) AND jamselesai is null", cnn);
                    cmd2.Parameters.AddWithValue("@kodemesin", login.assy_laoding);
                    //cmd2.Parameters.AddWithValue("@mc", login.machine);
                    DataTable dt = new DataTable();
                    var reader = cmd2.ExecuteReader();
                    dt.Load(reader);
                    dataGridView3.DataSource = dt;
                }
                catch { }

                try
                {
                    SqlCommand cmd2 = new SqlCommand("SELECT lot,jamselesai FROM TRRPHASSYScan WHERE kodemesin = @kodemesin AND tanggal = CONVERT(VARCHAR(10), GETDATE(), 120) AND jamselesai is not null", cnn);
                    cmd2.Parameters.AddWithValue("@kodemesin", login.assy_laoding);
                    //cmd2.Parameters.AddWithValue("@mc", login.machine);
                    DataTable dt = new DataTable();
                    var reader = cmd2.ExecuteReader();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
                catch { }

                SqlDataReader dataReader;
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT TOP(1) PartNameFG FROM TrRPHMesin WHERE LotNo = @lot", cnn);
                    cmd.Parameters.AddWithValue("@lot", lotno[0]);
                   // cmd.Parameters.AddWithValue("@pass", pass);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Console.WriteLine(dataReader.GetString(0));

                        label12.Text = String.Format("{0}", dataReader["PartNameFG"]);



                       // Console.WriteLine(hasil);
                        // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                        //data2txt.Text = dataReader.GetString("jumlah");
                    }
                }
                catch { }
                label13.Text = lotno[0];
                //SELECT TOP(1) PartNameFG FROM TrRPHMesin WHERE LotNo = 'BE23070348'


                //@shift = 1,  2010017, @kodemesin = 'LAS10', @state = 0, @keteranganerr = '\N', @supervisor = '2108w05'";
            }
        }
    }
}
