using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Panel2 : UserControl
    {
        login login;
        public Panel2( login login_)
        {
            InitializeComponent(); 
            this.login = login_;
            comboBox2.Items.Add("CSM01");
            comboBox2.Items.Add("CSM02");
            comboBox2.Items.Add("CSM03");
            comboBox2.Items.Add("CSM04");
            comboBox2.Items.Add("CSM05");
            comboBox2.Items.Add("CSM06");
            comboBox2.Items.Add("CSM07");
            comboBox2.Items.Add("CSM08");
            comboBox2.Items.Add("CSM09");
            comboBox2.Items.Add("CSM10");
            comboBox2.Items.Add("CSM11");
            comboBox2.Items.Add("CSM12");
            comboBox2.Items.Add("CSM13");
            comboBox2.Items.Add("CSM14");
            comboBox2.Items.Add("CSM15");
            comboBox2.Items.Add("KMX01");
            comboBox2.Items.Add("KMX02");
            comboBox2.Items.Add("KMX03");
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();

            login lgn = new login();
            lgn.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            login.machine = comboBox2.Text;

            global.sKodemesin = comboBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            login.shift = comboBox1.Text;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            login.shift = comboBox1.Text;
            Console.WriteLine(login.shift);
        }
    }
}
