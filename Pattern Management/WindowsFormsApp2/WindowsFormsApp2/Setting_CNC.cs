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
    public partial class Setting_CNC : Form
    {
        SF_CNC sf_CNC;
        SF_CRP sf_CRP;
        public Setting_CNC(SF_CNC sf_CNC_, SF_CRP sf_CRP_)
        {
            InitializeComponent();
            this.sf_CNC = sf_CNC_;
            this.sf_CRP = sf_CRP_;
        }

        private void rjTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            } 

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt16(rjTextBox1.Texts);
            rjTextBox1.Texts= Convert.ToString(data - 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt16(rjTextBox1.Texts);
            rjTextBox1.Texts = Convert.ToString(data + 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt16(rjTextBox2.Texts);
            rjTextBox2.Texts = Convert.ToString(data - 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt16(rjTextBox2.Texts);
            rjTextBox2.Texts = Convert.ToString(data + 10);
        }
    }
}
