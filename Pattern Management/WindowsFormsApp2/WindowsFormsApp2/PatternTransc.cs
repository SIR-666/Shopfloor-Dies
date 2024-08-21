using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class PatternTransc : UserControl
    {
        Pattern_FBO_Rack PFR;
        public PatternTransc(Pattern_FBO_Rack PFR)
        {
            InitializeComponent();
            this.PFR = PFR;
        }
        
        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (PFR.label27.Text == "0")
            {
                PFR.label4.Text = label2.Text;
                int no_urut = Convert.ToInt32(label1.Text);
                PFR.insertPartname(label2.Text, no_urut);
                PFR.timer1.Enabled = true;
                PFR.label11.Text = "0";
                PFR.rjButton1.Text = "0";
                PFR.label36.Text = label1.Text;
                PFR.qty_ng = 0;


                PFR.get_qtyrph(label2.Text);
            }
            else
                MessageBox.Show("Finish terlebih dahulu");


        }
    }
}
