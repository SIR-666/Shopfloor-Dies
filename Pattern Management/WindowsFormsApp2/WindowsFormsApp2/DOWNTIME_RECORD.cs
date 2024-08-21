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

namespace WindowsFormsApp2
{
    public partial class DOWNTIME_RECORD : Form
    {
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;
        public DOWNTIME_RECORD()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Console.WriteLine(theDate);
            Console.WriteLine(login.machine);
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            string noreg = login.SetValueForText1;
            if (comboBox1.Text == "All")
            {
                SqlCommand cmd2 = new SqlCommand("select tanggal,SIFT,KodeMesin,KETERANGAN1,jammulai,jamselesai,LAMA,KETERANGAN2,TERMINAL,KETERANGAN from TrRPHMesinSetup and KodeMesin=@mc and tanggal=@tgl", cnn);
                cmd2.Parameters.AddWithValue("@tgl", theDate);
                cmd2.Parameters.AddWithValue("@mc", login.machine);
                DataTable dt = new DataTable();
                var reader = cmd2.ExecuteReader();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("select tanggal,SIFT,KodeMesin,KETERANGAN1,jammulai,jamselesai,LAMA,KETERANGAN2,TERMINAL,KETERANGAN from TrRPHMesinSetup where SIFT=@shift and KodeMesin=@mc and tanggal=@tgl", cnn);
                cmd2.Parameters.AddWithValue("@tgl", theDate);
                cmd2.Parameters.AddWithValue("@mc", login.machine);
                cmd2.Parameters.AddWithValue("@shift", comboBox1.Text);
                DataTable dt = new DataTable();
                var reader = cmd2.ExecuteReader();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            
            //MessageBox.Show(cmd2.ToString());
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 2] = "TANGGAL";
            xlWorkSheet.Cells[1, 3] = "SHIFT";
            xlWorkSheet.Cells[1, 4] = "KODE MESIN";
            xlWorkSheet.Cells[1, 5] = "JENIS DOWNTIME";
            xlWorkSheet.Cells[1, 6] = "JAM MULAI";
            xlWorkSheet.Cells[1, 7] = "JAM SELESAI";
            xlWorkSheet.Cells[1, 8] = "LAMA";
            xlWorkSheet.Cells[1, 9] = "DETAIL DOWNTIME";
            xlWorkSheet.Cells[1, 10] = "TERMINAL";
            xlWorkSheet.Cells[1, 11] = "KETERANGAN";
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
       
    }
}
