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
using WindowsFormsApp2.RJControls;

namespace WindowsFormsApp2
{
    public partial class RPH_ASSY_HOME : UserControl
    {
        public static string Part_Number,Production_Plan,Buffer_,Stock_Awal,fgsid;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;
        int indextclick = 0;
        String qty, tgl;
        public RPH_ASSY_HOME()
        {
            
            InitializeComponent();

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

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            try
            {
                SqlCommand cmd2 = new SqlCommand("exec MPP_PRODPLAN", cnn);
                DataTable dt = new DataTable();
                var reader = cmd2.ExecuteReader();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                int numRows = dataGridView1.Rows.Count;
            }
            catch { MessageBox.Show("Cant Connect Database"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            /*
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                Part_Number = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Production_Plan = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                //Form1.open_rph_assy();
                RPH_ASSY rph_ASSY = new RPH_ASSY();
                addusercontrol(rph_ASSY);

                rph_ASSY.label6.Text = Part_Number;
                rph_ASSY.label7.Text = Production_Plan;


            }
            */

           // indextclick = e.RowIndex;
        }

        private void ceLearningButtonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("OK");
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("OK");
            }
        }

        private void celearningTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("OK");
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("OK");
            }
        }

        private void ceLearningButtonEdit1_btnClick(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
            
        }

        private void processRPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            MessageBox.Show(dataGridView1.Rows[this.indextclick].Cells[1].Value.ToString());

            fgsid = dataGridView1.Rows[this.indextclick].Cells[0].Value.ToString();
            Part_Number = dataGridView1.Rows[this.indextclick].Cells[1].Value.ToString();
            Production_Plan = dataGridView1.Rows[this.indextclick].Cells[5].Value.ToString();
            Buffer_ = dataGridView1.Rows[this.indextclick].Cells[3].Value.ToString();
            Stock_Awal = dataGridView1.Rows[this.indextclick].Cells[2].Value.ToString();
            //Form1.open_rph_assy();
            RPH_ASSY rph_ASSY = new RPH_ASSY();
            addusercontrol(rph_ASSY);

            rph_ASSY.label6.Text = Part_Number;
            rph_ASSY.label7.Text = Production_Plan;
            rph_ASSY.label9.Text = Buffer_;
            rph_ASSY.label10.Text = Stock_Awal;

            load_DN();
            rph_ASSY.DN_QTY = qty;
            rph_ASSY.label20.Text = tgl;
            rph_ASSY.label21.Text = qty;
            rph_ASSY.DN_QTY = qty;
            rph_ASSY.DN_TGL = tgl;
            rph_ASSY.FGSID = fgsid;


        }

        public void load_DN()
        {
            SqlDataReader dataReader, dataReader2;
            SqlDataAdapter adapter = new SqlDataAdapter();
            

            try
            {
                SqlCommand cmd2 = new SqlCommand("exec MPP_DN @fgsid", cnn);
                cmd2.Parameters.AddWithValue("@fgsid", fgsid);
                dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //hasil = String.Format("{0}", dataReader["jumlah"]);


                    qty = String.Format("{0}", dataReader2["qty"]);
                    tgl = String.Format("{0}", dataReader2["tgl"]);
                    
                    Console.WriteLine(qty);
                    Console.WriteLine(tgl);
                    //label2.Text = user_name;
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
            catch { MessageBox.Show("Cant Connect Database"); }



        }

        private void dataGridView1_MouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                indextclick = e.RowIndex;
                dataGridView1.CurrentCell = dataGridView1.Rows[indextclick].Cells[0];
                this.contextMenuStrip1.Show(dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void addusercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_home.Controls.Clear();
            panel_home.Controls.Add(userControl);
            userControl.BringToFront();
        }
    }
}
