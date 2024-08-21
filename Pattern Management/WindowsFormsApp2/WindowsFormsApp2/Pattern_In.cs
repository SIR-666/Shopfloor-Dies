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
    public partial class Pattern_In : Form
    {
        Pattern_Center pattern_center;
        public Pattern_In(Pattern_Center pattern_center)
        {
            InitializeComponent();
            this.pattern_center = pattern_center;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pattern_center.update_location(2,textBox1.Text);
                MessageBox.Show("Transaksi In Sukses");
                this.Close();
            }
            
        }
    }
}
