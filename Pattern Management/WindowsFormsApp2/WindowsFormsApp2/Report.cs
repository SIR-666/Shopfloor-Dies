using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;

namespace WindowsFormsApp2
{
    public partial class Report : Form
    {
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;       
        


        public Report()
        {
            InitializeComponent();
            //Report report = new Report();
            //report.StartPosition = FormStartPosition.CenterScreen;
        }        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            //SF_CNC sf = new SF_CNC();
            //String sKodemesin = sf.label31.Text;            
            //String url = ;            
            /*
            string sift = "2";
            if (DateTime.Now.Hour > 7 && DateTime.Now.Hour <= 16)
            {
                sift = "1";
            }
            */

            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");

            System.Diagnostics.Process.Start("http://192.168.5.7:8080/produksi/public/export?kodemesin=" + global.sKodemesin + "&noreg="+login.NoReg+"&tanggal="+ tanggal);
            
        }
    }
}
