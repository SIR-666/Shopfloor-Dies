using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using WindowsFormsApp2.RJControls;

namespace WindowsFormsApp2
{
    public partial class Pattern_Center : UserControl
    {
        string connetionString = "Data Source=192.168.2.1;Initial Catalog=Plant5;User ID=roni@ipg;Password=AutoCasting";

        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;
        public Pattern_Center()
        {
            InitializeComponent();
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
            searchmenu_Load();
            //checkBox2.Checked = false;
            datagridget();
            RPH_Load();
        }

        public DataTable dt_tabel ()
        {
            //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESIN @dt, @mc", cnn);
            SqlCommand cmd = new SqlCommand("select * from historical_pattern_basepatterns", cnn); // "list aplikator" ("select id,hobby from table 1", conn)
            //cmd.Parameters.AddWithValue("@apli", rjTextBox1.Texts);
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);

            return dt;
            //comboBox1.DataSource = dt;
            //listBox1.DisplayMember = ""; //list aplikator

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pattern_Measurement pattern_Measurement = new Pattern_Measurement(this);
            pattern_Measurement.Show();
        }

        private void RPH_Load()
        {
            //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESIN @dt, @mc", cnn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM RPH_P5 WHERE DATEPART(year, tgl_pouring) = DATEPART(year, GETDATE()) AND DATEPART(month, tgl_pouring) = DATEPART(month, GETDATE()) AND DATEPART(day, tgl_pouring) = DATEPART(day, GETDATE());", cnn); // "list aplikator" ("select id,hobby from table 1", conn)
            //cmd.Parameters.AddWithValue("@apli", rjTextBox1.Texts);
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);

            dataGridView2.DataSource = dt;
            //listBox1.DisplayMember = ""; //list aplikator

        }

        private void searchmenu_Load()
        {
            //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESIN @dt, @mc", cnn);
            SqlCommand cmd = new SqlCommand("select * from historical_pattern_basepatterns", cnn); // "list aplikator" ("select id,hobby from table 1", conn)
            //cmd.Parameters.AddWithValue("@apli", rjTextBox1.Texts);
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);

            dataGridView1.DataSource = dt;
            //listBox1.DisplayMember = ""; //list aplikator

        }

        private void datagridget()
        {

            int numRows = dataGridView1.Rows.Count;
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue;
            for (int j = 0; j < numRows; j++)
            {
                try
                {
                    datavalue = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value);
                    Console.WriteLine(datavalue);
                    if (datavalue != null)
                        comboBox1.Items.Add(datavalue);
                }
                catch { }
            }
        }

        


        public void store_measurement_pattern(bool kondisi, bool baseplate, String dimensi_panjang, String dimensi_lebar, String dimensi_tinggi, String dimensi_diameter, String area_lebar, String area_tinggi, String keterangan)
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
            SqlCommand cmd = new SqlCommand("EXEC upsert_historical_pattern_basepattern_transaction @noreg, @pattern_name, @kondisi_visual, @level_baseplate, @actual_dimensi_panjang, @actual_dimensi_lebar, @actual_dimensi_tinggi, @actual_dimensi_diameter, @actual_area_lebar, @actual_area_tinggi, @keterangan;", cnn); // "list aplikator" ("select id,hobby from table 1", conn)
            
            cmd.Parameters.AddWithValue("@noreg", global.sNoreg);
            cmd.Parameters.AddWithValue("@pattern_name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@kondisi_visual", kondisi);

            cmd.Parameters.AddWithValue("@level_baseplate", baseplate);
            cmd.Parameters.AddWithValue("@actual_dimensi_panjang", dimensi_panjang);
            cmd.Parameters.AddWithValue("@actual_dimensi_lebar", dimensi_lebar);

            cmd.Parameters.AddWithValue("@actual_dimensi_tinggi", dimensi_tinggi);
            cmd.Parameters.AddWithValue("@actual_dimensi_diameter", dimensi_diameter);
            cmd.Parameters.AddWithValue("@actual_area_lebar", area_lebar);

            cmd.Parameters.AddWithValue("@actual_area_tinggi", area_tinggi);
            cmd.Parameters.AddWithValue("@keterangan", keterangan);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            update_location(1, "");

        }


        public void update_partnameshot(String partname)
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
            SqlCommand cmd = new SqlCommand("exec UpdatePatternName @pattern_name, @prod_Name;", cnn); // "list aplikator" ("select id,hobby from table 1", conn)

            cmd.Parameters.AddWithValue("@prod_Name", partname);
            cmd.Parameters.AddWithValue("@pattern_name", comboBox1.Text);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            update_location(1, "");

        }



        void LoadimagefromUrl(string url)
        {
            var request = WebRequest.Create(url);
            try
            {
                using (var respone = request.GetResponse())
                using (var stream = respone.GetResponseStream())
                {
                    button3.BackgroundImage = Bitmap.FromStream(stream);
                }
            }
            catch { }
        }
        public void update_location(int id, string loc)
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

            //[UpdatePatternBasePatterns]
            SqlCommand cmd = new SqlCommand("exec UpdatePatternBasePatterns @loc_id,@lokasi,@pattern_name;", cnn); // "list aplikator" ("select id,hobby from table 1", conn)

            cmd.Parameters.AddWithValue("@loc_id", id);
            cmd.Parameters.AddWithValue("@pattern_name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@lokasi", loc);

            

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            String user_name = "Hi  " + login.user_name;

            //string urlphoto = "http://192.168.5.7:8080/indoprima_gemilang/public/img/" + noreg + "." + login.format_pic;
            string urlphoto = "http://192.168.5.4:8080/historical-pattern/public/uploads/basepattern_tr/"+comboBox1.Text+".jpg";
            LoadimagefromUrl(urlphoto);
            //label2.Text = comboBox1.Text;
            String partname = comboBox1.Text;
            
            SqlDataReader dataReader, dataReader2;
            try
            {
                //SqlCommand cmd = new SqlCommand("select * from historical_pattern_basepattern_transactions where pattern_name = @pattern", cnn);
                SqlCommand cmd = new SqlCommand("exec GetCombinedPatternData @pattern = @patternname", cnn);
                cmd.Parameters.AddWithValue("@patternname", comboBox1.Text);
                //cmd.ExecuteNonQuery();

                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    String tanngal_pakai = String.Format("{0}", dataReader["tanggal_pemakaian"]);
                    String[] tgl_pakai = tanngal_pakai.Split(' ');
                    label5.Text = tgl_pakai[0];

                    String kondisi = String.Format("{0}", dataReader["kondisi_visual"]);
                    //label18.Text = String.Format("{0}", dataReader["kondisi_visual"]);
                    if (kondisi == "True")
                    {
                        label18.Text = "OK";
                    }
                    else
                        label18.Text = "NG";

                    label39.Text = String.Format("{0}", dataReader["qty_shoot"]);

                    label26.Text = String.Format("{0}", dataReader["actual_dimensi_panjang"]);
                    label25.Text = String.Format("{0}", dataReader["actual_dimensi_lebar"]);
                    label24.Text = String.Format("{0}", dataReader["actual_dimensi_tinggi"]);
                    label29.Text = String.Format("{0}", dataReader["actual_dimensi_diameter"]);

                    label28.Text = String.Format("{0}", dataReader["actual_area_lebar"]);
                    label27.Text = String.Format("{0}", dataReader["actual_area_tinggi"]);
                    label6.Text = String.Format("{0}", dataReader["tanggal_preventif"]);
                    textBox1.Text = String.Format("{0}", dataReader["keterangan"]);
                    /*
                    string loc_id = String.Format("{0}", dataReader["lokasi_id"]);
                    string lokasi_rack = String.Format("{0}", dataReader["lokasi_rack"]);

                    if (loc_id == "1")
                        label3.Text = lokasi_rack;
                    else
                        label3.Text = "FBO";
                    */
                    // label5.Text = String.Format("{0}", dataReader["tanggal_pemakaian"]);



                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                    MessageBox.Show("Process Success");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            int numRows = dataGridView1.Rows.Count;
            Console.WriteLine(numRows);
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue;
            
            for (int j = 0; j < numRows; j++)
            {
                datavalue = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value);
                int lengt = comboBox1.Text.Length;
                //Console.WriteLine(lengt);
                if (datavalue.ToString() == partname)
                {
                    try
                    { 
                    lbl_Panjang.Text = dataGridView1.Rows[j].Cells[7].Value.ToString();
                    lbl_Lebal.Text = dataGridView1.Rows[j].Cells[8].Value.ToString();
                    lbl_Tinggi.Text = dataGridView1.Rows[j].Cells[9].Value.ToString();
                    lbl_Diamter.Text = dataGridView1.Rows[j].Cells[10].Value.ToString();
                    lbl_Igt_Lebar.Text = dataGridView1.Rows[j].Cells[11].Value.ToString();
                    lbl_Igt_Tinggi.Text = dataGridView1.Rows[j].Cells[12].Value.ToString();
                    int id_loc = Convert.ToInt16(dataGridView1.Rows[j].Cells[15].Value);
                        if (id_loc == 2)
                        { 
                            label3.Text = dataGridView1.Rows[j].Cells[17].Value.ToString();
                            //MessageBox.Show(dataGridView1.Rows[j].Cells[17].Value.ToString());
                        }
                        else
                        {
                            label3.Text = "FBO";
                        }
                    }
                    catch ( Exception er )
                    {
                        MessageBox.Show(er.ToString());
                    }
                    /*
                    shootpress = Convert.ToInt32(dataGridView1.Rows[j].Cells[6].Value);
                    MessageBox.Show(shootpress.ToString());
                    dashb.rjTextBox2.Texts = datavalue;
                    dashb.rjTextBox3.Texts = shootpress.ToString();
                    Console.WriteLine(datavalue);
                    */

                    j = numRows;
                    break;





                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pattern_In pattern_In = new Pattern_In(this);
            pattern_In.Show();
        }
    }
}
