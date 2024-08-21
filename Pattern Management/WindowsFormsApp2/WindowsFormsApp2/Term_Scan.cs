using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Term_Scan : Form
    {
        SF_CNC fcnc;
        SF_CRP fcrp;
        Boolean status_terma = false;
        Boolean status_termb = false;
        
        public Term_Scan(SF_CNC sfcnc_, SF_CRP sfcrp_)
        {
            InitializeComponent();
            this.fcnc = sfcnc_;
            this.fcrp = sfcrp_;            
        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                // if (rjTextBox1.Texts == fcnc.label33.Text)
                // {
                string namaterm = rjTextBox1.Texts;
                Console.WriteLine(namaterm);
                if (status_terma == false)
                {
                    fcnc.get_terminal_a(namaterm);
                    //fcnc.labelterminal.Text = ": " + rjTextBox1.Texts;
                    //this.Hide();
                    fcnc.terminal_stats = true;
                    fcnc.scan_term_stats = true;
                }
                else if (status_terma == true)
                {
                    fcnc.labelterminal.Text = namaterm;
                    //MessageBox.Show(rjTextBox1.Text);
                    fcnc.terminal_stats = true;
                    fcnc.scan_term_stats = true;
                }

            } 
            
        }

        private void rjTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string namaterm = rjTextBox2.Texts;
                Console.WriteLine(namaterm);
                if (status_termb == false)
                {
                    fcnc.get_terminal_b(namaterm);
                    //fcnc.labelterminalB.Text = ": " + rjTextBox2.Texts;
                    // this.Hide();
                    fcnc.terminal_stats = true;
                    fcnc.scan_term_stats = true;
                }
                else if (status_termb == true)
                {
                    fcnc.labelterminalB.Text = namaterm;

                    fcnc.terminal_stats = true;
                    fcnc.scan_term_stats = true;
                }
            } 
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
                
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            if (checkBox1.Checked == true)
            {
                status_terma = true;
                //System.Diagnostics.Process.Start("osk.exe");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //SendKeys.Send(btn.Text);

            if (checkBox2.Checked == true)
            {
                status_termb = true;
                //System.Diagnostics.Process.Start("osk.exe");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                rjTextBox1.Enabled = false;
                rjTextBox2.Enabled = false;
                status_termb = true;
                status_terma = true;
                fcnc.terminal_stats = true;
                fcnc.scan_term_stats = true;
                fcnc.terminal_stats = true;
                fcnc.scan_term_stats = true;
            }
            else
            {
                rjTextBox1.Enabled = true;
                rjTextBox2.Enabled = true;
               
            }
        }
    }
}
