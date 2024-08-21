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
    
    public partial class ucDays : UserControl
    {
        RPH_ASSY rph_ASSY;
        bool[] loading_shift1 = { false, false, false, false };
        bool[] loading_shift2 = { false, false, false, false };
        public ucDays(RPH_ASSY rph_assy)
        {
            InitializeComponent();
            rph_ASSY = rph_assy;
            comboBox1.Items.Add("MITA - 300");
            comboBox1.Items.Add("SEPTI - 300");
            comboBox1.Items.Add("NISA - 300");
            comboBox1.Items.Add("FATI - 300");
            comboBox1.Items.Add("ARHA- 300");

            comboBox2.Items.Add("MITA - 300");
            comboBox2.Items.Add("SEPTI - 300");
            comboBox2.Items.Add("NISA - 300");
            comboBox2.Items.Add("FATI - 300");
            comboBox2.Items.Add("ARHA- 300");

            comboBox3.Items.Add("MITA - 300");
            comboBox3.Items.Add("SEPTI - 300");
            comboBox3.Items.Add("NISA - 300");
            comboBox3.Items.Add("FATI - 300");
            comboBox3.Items.Add("ARHA- 300");

            comboBox4.Items.Add("MITA - 300");
            comboBox4.Items.Add("SEPTI - 300");
            comboBox4.Items.Add("NISA - 300");
            comboBox4.Items.Add("FATI - 300");
            comboBox4.Items.Add("ARHA- 300");
        }

        public void day_show(int numbday)
        { 
            days.Text = numbday.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel_pick1.Visible != true)
            {
                panel_pick1.Visible = true;
                loading_shift1[0]= true;


            }
            else if (panel_pick2.Visible != true)
            {
                panel_pick2.Visible = true;
                loading_shift1[1] = true;

            }
            else if (panel_pick3.Visible != true)
            {
                panel_pick3.Visible = true;
                loading_shift1[2] = true;

            }
            else if (panel_pick4.Visible != true)
            { 
                panel_pick4.Visible = true;
                loading_shift1[3] = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_pick1.Visible = false;
            loading_shift1[0] = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_pick4.Visible = false;
            loading_shift1[3] = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel_pick2.Visible = false;
            loading_shift1[1] = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel_pick3.Visible = false;
            loading_shift1[2] = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            panel_pick1.Visible = rph_ASSY.shift1_loading_stats[0];
            panel_pick2.Visible = rph_ASSY.shift1_loading_stats[1];
            panel_pick3.Visible = rph_ASSY.shift1_loading_stats[2];
            panel_pick4.Visible = rph_ASSY.shift1_loading_stats[3];
            
            comboBox1.Text = rph_ASSY.loading_shif1[0].listnama;
            comboBox2.Text = rph_ASSY.loading_shif1[1].listnama;
            comboBox3.Text = rph_ASSY.loading_shif1[2].listnama;
            comboBox4.Text = rph_ASSY.loading_shif1[3].listnama;
            textBox1.Text = rph_ASSY.loading_shif1[0].qty.ToString();
            textBox2.Text = rph_ASSY.loading_shif1[1].qty.ToString();
            textBox3.Text = rph_ASSY.loading_shif1[2].qty.ToString();
            textBox4.Text = rph_ASSY.loading_shif1[3].qty.ToString();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

            for (int i = 0; i > 4; i++)
            {
                rph_ASSY.shift1_loading_stats[i] = false;
            }

            rph_ASSY.shift1_loading_stats[0] = panel_pick1.Visible;
            rph_ASSY.shift1_loading_stats[1] = panel_pick2.Visible;
            rph_ASSY.shift1_loading_stats[2] = panel_pick3.Visible;
            rph_ASSY.shift1_loading_stats[3] = panel_pick4.Visible;

            if (loading_shift1[0] == true)
            {
                try
                {
                    rph_ASSY.loading_shif1[0].listnama = comboBox1.Text;
                    rph_ASSY.loading_shif1[0].qty = Convert.ToInt32(textBox1.Text);
                }
                catch { MessageBox.Show("error"); }
            }
            if (loading_shift1[1] == true)
            {
                try
                {
                    rph_ASSY.loading_shif1[1].listnama = comboBox2.Text;
                    rph_ASSY.loading_shif1[1].qty = Convert.ToInt32(textBox2.Text);
                }
                catch { MessageBox.Show("error"); }
            }
            if (loading_shift1[2] == true)
            {
                try
                {
                    rph_ASSY.loading_shif1[2].listnama = comboBox3.Text;
                    rph_ASSY.loading_shif1[2].qty = Convert.ToInt32(textBox3.Text);
                }
                catch { MessageBox.Show("error"); }
            }
            if (loading_shift1[3] == true)
            {
                try
                {
                    rph_ASSY.loading_shif1[3].listnama = comboBox4.Text;
                    rph_ASSY.loading_shif1[3].qty = Convert.ToInt32(textBox4.Text);
                }
                catch { MessageBox.Show("error"); }
            }

            
            
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1_shift2.Visible != true)
            {
                panel1_shift2.Visible = true;
                loading_shift2[0] = true;


            }
            else if (panel2__shift2.Visible != true)
            {
                panel2__shift2.Visible = true;
                loading_shift2[1] = true;

            }
            else if (panel3__shift2.Visible != true)
            {
                panel3__shift2.Visible = true;
                loading_shift2[2] = true;

            }
            else if (panel4__shift2.Visible != true)
            {
                panel4__shift2.Visible = true;
                loading_shift2[3] = true;

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i > 4; i++)
            {
                rph_ASSY.shift2_loading_stats[i] = false;
            }

            rph_ASSY.shift2_loading_stats[0] = panel1_shift2.Visible;
            rph_ASSY.shift2_loading_stats[1] = panel2__shift2.Visible;
            rph_ASSY.shift2_loading_stats[2] = panel3__shift2.Visible;
            rph_ASSY.shift2_loading_stats[3] = panel4__shift2.Visible;

            if (loading_shift2[0] == true)
            {
                try
                {
                    rph_ASSY.loading_shif2[0].listnama = comboBox5.Text;
                    rph_ASSY.loading_shif2[0].qty = Convert.ToInt32(textBox5.Text);
                }
                catch { MessageBox.Show("error"); }
            }
            if (loading_shift2[1] == true)
            {
                try
                {
                    rph_ASSY.loading_shif2[1].listnama = comboBox6.Text;
                    rph_ASSY.loading_shif2[1].qty = Convert.ToInt32(textBox6.Text);
                }
                catch { MessageBox.Show("error"); }
            }
            if (loading_shift2[2] == true)
            {
                try
                {
                    rph_ASSY.loading_shif2[2].listnama = comboBox7.Text;
                    rph_ASSY.loading_shif2[2].qty = Convert.ToInt32(textBox7.Text);
                }
                catch { MessageBox.Show("error"); }
            }
            if (loading_shift2[3] == true)
            {
                try
                {
                    rph_ASSY.loading_shif2[3].listnama = comboBox8.Text;
                    rph_ASSY.loading_shif2[3].qty = Convert.ToInt32(textBox8.Text);
                }
                catch { MessageBox.Show("error"); }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel1_shift2.Visible = rph_ASSY.shift2_loading_stats[0];
            panel2__shift2.Visible = rph_ASSY.shift2_loading_stats[1];
            panel3__shift2.Visible = rph_ASSY.shift2_loading_stats[2];
            panel4__shift2.Visible = rph_ASSY.shift2_loading_stats[3];

            comboBox5.Text = rph_ASSY.loading_shif2[0].listnama;
            comboBox6.Text = rph_ASSY.loading_shif2[1].listnama;
            comboBox7.Text = rph_ASSY.loading_shif2[2].listnama;
            comboBox8.Text = rph_ASSY.loading_shif2[3].listnama;
            textBox5.Text = rph_ASSY.loading_shif2[0].qty.ToString();
            textBox6.Text = rph_ASSY.loading_shif2[1].qty.ToString();
            textBox7.Text = rph_ASSY.loading_shif2[2].qty.ToString();
            textBox8.Text = rph_ASSY.loading_shif2[3].qty.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1_shift2.Visible = false;
            loading_shift2[0] = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2__shift2.Visible = false;
            loading_shift2[1] = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel_pick3.Visible = false;
            loading_shift2[2] = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4__shift2.Visible = false;
            loading_shift2[3] = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button15_Click(object sender, EventArgs e)
        {

            
            int dnqty = Convert.ToInt16(rph_ASSY.label21.Text);
            //Console.WriteLine(rph_ASSY.DN_QTY);
            if (panel_pick1.Visible == true)
            {
                
                dnqty = dnqty - Convert.ToInt16(textBox1.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }
            if (panel_pick2.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox2.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }
            if (panel_pick3.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox3.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }
            if (panel_pick4.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox4.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }

            //------shift 2---------------------------------------------//
            if (panel1_shift2.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox5.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }
            if (panel2__shift2.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox6.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }
            if (panel3__shift2.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox7.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }
            if (panel4__shift2.Visible == true)
            {

                dnqty = dnqty - Convert.ToInt16(textBox8.Text);
                rph_ASSY.label21.Text = dnqty.ToString();
                button15.Enabled = false;
            }


            if (dnqty == 0)
            {
                rph_ASSY.load_DN();
            }


        }
    }
}
