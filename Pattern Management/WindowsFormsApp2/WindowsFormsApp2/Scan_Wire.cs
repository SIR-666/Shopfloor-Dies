using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp2
{
    public partial class Scan_Wire : Form
    {
        SF_CNC fcnc;
        SF_CRP fcrp;
        Boolean status = false;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;
        public Scan_Wire(SF_CNC sfcnc_, SF_CRP sfcrp_)
        {
            InitializeComponent();
            this.fcnc = sfcnc_;
            this.fcrp = sfcrp_;

           
        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string namawire = rjTextBox1.Texts;
                if (status == false)
                {
                    fcnc.get_wirebobin(namawire);
                    fcnc.labelwire.Text = fcnc.jenis_wire;
                    if (fcnc.jenis_wire != "")
                    {
                        this.Hide();
                        fcnc.wire_stats = true;
                        fcnc.scan_wire_stats = true;
                    }
                } else if (status == true)
                {
                    fcnc.labelwire.Text = namawire;
                    if (fcnc.jenis_wire != "")
                    {
                        this.Hide();
                        fcnc.wire_stats = true;
                        fcnc.scan_wire_stats = true;
                    }
                }
                
               
            }
        }

        private void rjTextBox1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("osk.exe");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                status = true;
                //System.Diagnostics.Process.Start("osk.exe");
            }
        }
    }
}
