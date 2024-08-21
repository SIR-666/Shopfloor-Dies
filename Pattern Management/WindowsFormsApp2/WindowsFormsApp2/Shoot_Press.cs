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
    public partial class Shoot_Press : Form
    {
        APLIKATOR_SCAN AS;       
        public Shoot_Press(APLIKATOR_SCAN aS)
        {
            InitializeComponent();
            this.AS = aS;            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            AS.Show();
            //AS.rjTextBox1.ResetText();
            AS.rjTextBox1.Texts = "";
            AS.rjTextBox2.Texts = "";
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            AS.Hide();
            this.Hide();
        }
        
    }
}
