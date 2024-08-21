using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.RJControls;

namespace WindowsFormsApp2
{
    public partial class inputpokayoke : Form
    {
        Form1 form_1;
        SF_CNC sf_CNC;
        public double ch_std, ih_std, chb_std, ihb_std;
        public double ch, ih, cw, iw;
        public double chb, ihb, cwb, iwb;
        bool pokayoke_terma = true, pokayoke_termb = true;
        System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");


        // TERM A
        private void button1_Click(object sender, EventArgs e)
        {
            ch = ch - 0.01;
            rjTextBox1.Texts = string.Format("{0:0.00##}", ch.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ih = ih + 0.01;
            rjTextBox2.Texts = string.Format("{0:0.00##}", ih.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ih = ih - 0.01;
            rjTextBox2.Texts = string.Format("{0:0.00##}", ih.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            chb = chb + 0.01;
            rjTextBox6.Texts = string.Format("{0:0.00##}", chb.ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            cwb = cwb + 0.01;
            rjTextBox8.Texts = string.Format("{0:0.00##}", cwb.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            cwb = cwb - 0.01;
            rjTextBox8.Texts = string.Format("{0:0.00##}", cwb.ToString());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            iwb = iwb + 0.01;
            rjTextBox9.Texts = string.Format("{0:0.00##}", iwb.ToString());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            rjTextBox11.Texts = (Convert.ToDouble(rjTextBox11.Texts) + 10).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            rjTextBox11.Texts = (Convert.ToDouble(rjTextBox11.Texts) - 10).ToString();
        }

        private void rjTextBox5__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            //if (e.KeyChar == 46)
            //{
            //      if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
            //       e.Handled = true;
            //}

        }

        private void rjTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void rjTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void rjTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            ch = Convert.ToDouble(rjTextBox1.Texts);
            ih = Convert.ToDouble(rjTextBox2.Texts);
            cw = Convert.ToDouble(rjTextBox3.Texts);
            iw = Convert.ToDouble(rjTextBox4.Texts);

            chb = Convert.ToDouble(rjTextBox6.Texts);
            ihb = Convert.ToDouble(rjTextBox7.Texts);
            cwb = Convert.ToDouble(rjTextBox8.Texts);
            iwb = Convert.ToDouble(rjTextBox9.Texts);

            //--------------TERM A--------------------------------------------------------------------------------------
            if (((ch - ch_std <= 0.06) && (ch - ch_std >= -0.06)) && ((ih - ih_std <= 0.6) && (ih - ih_std >= -0.6)))
            {
                pokayoke_terma = true;
                if (sf_CNC.rjButton2.Text == "INPUT N1")
                {
                    sf_CNC.label40.BackColor = Color.Green;
                    sf_CNC.label41.BackColor = Color.Green;
                    sf_CNC.label40.Text = ch.ToString();
                    sf_CNC.label41.Text = ih.ToString();
                    try
                    {
                        sf_CNC.serialPort1.Write("N1#");
                        sf_CNC.serialPort1.Write("N1#");
                        sf_CNC.serialPort1.Write("N1#");
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N2")
                {
                    sf_CNC.label54.BackColor = Color.Green;
                    sf_CNC.label55.BackColor = Color.Green;
                    sf_CNC.label54.Text = ch.ToString();
                    sf_CNC.label55.Text = ih.ToString();
                    try
                    {
                        sf_CNC.serialPort1.Write("N2#");
                        sf_CNC.serialPort1.Write("N2#");
                        sf_CNC.serialPort1.Write("N2#");
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N3")
                {
                    sf_CNC.label58.BackColor = Color.Green;
                    sf_CNC.label59.BackColor = Color.Green;
                    sf_CNC.label58.Text = ch.ToString();
                    sf_CNC.label59.Text = ih.ToString();

                    try
                    {
                        sf_CNC.serialPort1.Write("N3#");
                        sf_CNC.serialPort1.Write("N3#");
                        sf_CNC.serialPort1.Write("N3#");
                    }
                    catch { }
                    sf_CNC.count_time = 0;
                    DateTime localDate = DateTime.Now;
                    var culture = new CultureInfo("en-GB");
                    String datenow = localDate.ToString(culture);
                    string[] subs = datenow.Split(' ');

                    sf_CNC.label48.Text = subs[1];
                    sf_CNC.timer1.Enabled = false;
                }


            }
            else
            {

                pokayoke_terma = false;
                if (sf_CNC.rjButton2.Text == "INPUT N1" || sf_CNC.N1_stats == true)
                {
                    //sf_CNC.N1_stats = false;
                    sf_CNC.label40.BackColor = Color.Red;
                    sf_CNC.label41.BackColor = Color.Red;
                    sf_CNC.label40.Text = ch.ToString();
                    sf_CNC.label41.Text = ih.ToString();
                    try
                    {
                        try
                        {
                            sf_CNC.serialPort1.Write("NG1#");
                        }
                        catch { }

                        try
                        {
                            sf_CNC.serialPort1.Write("NG1#");
                        }
                        catch { }

                        try
                        {
                            sf_CNC.serialPort1.Write("NG1#");
                        }
                        catch { }
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N2" || sf_CNC.N2_stats == true)
                {
                    // sf_CNC.N2_stats = false;
                    sf_CNC.label54.BackColor = Color.Red;
                    sf_CNC.label55.BackColor = Color.Red;
                    sf_CNC.label54.Text = ch.ToString();
                    sf_CNC.label55.Text = ih.ToString();
                    try
                    {
                        sf_CNC.serialPort1.Write("NG2#");
                        sf_CNC.serialPort1.Write("NG2#");
                        sf_CNC.serialPort1.Write("NG2#");
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N3" || sf_CNC.N3_stats == true)
                {
                    //sf_CNC.N3_stats = false;
                    sf_CNC.label58.BackColor = Color.Red;
                    sf_CNC.label59.BackColor = Color.Red;
                    sf_CNC.label58.Text = ch.ToString();
                    sf_CNC.label59.Text = ih.ToString();

                    DateTime localDate = DateTime.Now;

                    var culture = new CultureInfo("en-GB");
                    String datenow = localDate.ToString(culture);
                    string[] subs1 = datenow.Split(' ');

                    sf_CNC.label48.Text = subs1[1];
                    try
                    {
                        sf_CNC.serialPort1.Write("NG3#");
                        sf_CNC.serialPort1.Write("NG3#");
                        sf_CNC.serialPort1.Write("NG3#");
                    }
                    catch { }
                }

                MessageBox.Show("NG Measurement");
            }
            //--------------TERM A--------------------------------------------------------------------------------------

            //--------------TERM B--------------------------------------------------------------------------------------
            if (((chb - chb_std <= 0.06) && (chb - chb_std >= -0.06)) && ((ihb - ihb_std <= 0.6) && (ihb - ihb_std >= -0.6)))
            {
                pokayoke_termb = true;
                if (sf_CNC.rjButton2.Text == "INPUT N1")
                {
                    sf_CNC.label68.BackColor = Color.Green;
                    sf_CNC.label69.BackColor = Color.Green;
                    sf_CNC.label68.Text = chb.ToString();
                    sf_CNC.label69.Text = ihb.ToString();
                    try
                    {
                        sf_CNC.serialPort1.Write("N1#");
                        sf_CNC.serialPort1.Write("N1#");
                        sf_CNC.serialPort1.Write("N1#");
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N2")
                {
                    sf_CNC.label72.BackColor = Color.Green;
                    sf_CNC.label73.BackColor = Color.Green;
                    sf_CNC.label72.Text = chb.ToString();
                    sf_CNC.label73.Text = ihb.ToString();
                    try
                    {
                        sf_CNC.serialPort1.Write("N2#");
                        sf_CNC.serialPort1.Write("N2#");
                        sf_CNC.serialPort1.Write("N2#");
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N3")
                {
                    sf_CNC.label76.BackColor = Color.Green;
                    sf_CNC.label77.BackColor = Color.Green;
                    sf_CNC.label76.Text = chb.ToString();
                    sf_CNC.label77.Text = ihb.ToString();

                    try
                    {
                        sf_CNC.serialPort1.Write("N3#");
                        sf_CNC.serialPort1.Write("N3#");
                        sf_CNC.serialPort1.Write("N3#");
                    }
                    catch { }
                    sf_CNC.count_time = 0;
                    DateTime localDate = DateTime.Now;
                    var culture = new CultureInfo("en-GB");
                    String datenow = localDate.ToString(culture);
                    string[] subs = datenow.Split(' ');

                    sf_CNC.label48.Text = subs[1];
                    sf_CNC.timer1.Enabled = false;
                }


            }
            else
            {

                pokayoke_termb = false;
                if (sf_CNC.rjButton2.Text == "INPUT N1" || sf_CNC.N1_stats == true)
                {
                    // sf_CNC.N1_stats = false;
                    sf_CNC.label68.BackColor = Color.Red;
                    sf_CNC.label69.BackColor = Color.Red;
                    sf_CNC.label68.Text = chb.ToString();
                    sf_CNC.label69.Text = ihb.ToString();
                    try
                    {
                        try
                        {
                            sf_CNC.serialPort1.Write("NG1#");
                        }
                        catch { }

                        try
                        {
                            sf_CNC.serialPort1.Write("NG1#");
                        }
                        catch { }

                        try
                        {
                            sf_CNC.serialPort1.Write("NG1#");
                        }
                        catch { }
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N2" || sf_CNC.N2_stats == true)
                {
                    //sf_CNC.N2_stats = false;
                    sf_CNC.label72.BackColor = Color.Red;
                    sf_CNC.label73.BackColor = Color.Red;
                    sf_CNC.label72.Text = chb.ToString();
                    sf_CNC.label73.Text = ihb.ToString();
                    try
                    {
                        sf_CNC.serialPort1.Write("NG2#");
                        sf_CNC.serialPort1.Write("NG2#");
                        sf_CNC.serialPort1.Write("NG2#");
                    }
                    catch { }
                }
                else if (sf_CNC.rjButton2.Text == "INPUT N3" || sf_CNC.N3_stats == true)
                {
                    //  sf_CNC.N3_stats = false;
                    sf_CNC.label76.BackColor = Color.Red;
                    sf_CNC.label77.BackColor = Color.Red;
                    sf_CNC.label76.Text = chb.ToString();
                    sf_CNC.label77.Text = ihb.ToString();

                    DateTime localDate = DateTime.Now;

                    var culture = new CultureInfo("en-GB");
                    String datenow = localDate.ToString(culture);
                    string[] subs1 = datenow.Split(' ');

                    sf_CNC.label48.Text = subs1[1];
                    try
                    {
                        sf_CNC.serialPort1.Write("NG3#");
                        sf_CNC.serialPort1.Write("NG3#");
                        sf_CNC.serialPort1.Write("NG3#");
                    }
                    catch { }
                }

                MessageBox.Show("NG Measurement");
            }

            if (sf_CNC.rjButton2.Text == "INPUT N1")
            {
                sf_CNC.lenght_n1.Text = rjTextBox11.Texts;
            }
            else if (sf_CNC.rjButton2.Text == "INPUT N2")
            {
                sf_CNC.lenght_n2.Text = rjTextBox11.Texts;
            }
            else if (sf_CNC.rjButton2.Text == "INPUT N3")
            {
                sf_CNC.lenght_n3.Text = rjTextBox11.Texts;
            }

            if (pokayoke_terma == true && pokayoke_termb == true)
            {
                if (sf_CNC.N1_stats == true)
                {
                    sf_CNC.N1_stats = false;
                    sf_CNC.rjButton2.Text = "INPUT N2";
                }
                else if (sf_CNC.N2_stats == true)
                {
                    sf_CNC.N2_stats = false;
                    sf_CNC.rjButton2.Text = "INPUT N3";
                }
                else if (sf_CNC.N3_stats == true)
                {
                    sf_CNC.count_time = 0;
                    sf_CNC.label42.Text = rjTextBox5.Texts;
                    sf_CNC.label85.Text = rjTextBox10.Texts;
                    sf_CNC.N3_stats = false;
                    sf_CNC.rjButton2.Text = "INPUT N1";
                    sf_CNC.save_current_rph();
                    sf_CNC.reload_datagridview();
                    sf_CNC.count_time = 0;
                }
                this.Hide();
            }


        }

        public inputpokayoke(SF_CNC sf_CNC_)
        {
            InitializeComponent();
            //  ch_std = Convert.ToDouble(form_1.label36.Text);
            // ih_std = Convert.ToDouble(form_1.label37.Text);
            this.sf_CNC = sf_CNC_;
            rjTextBox1.Texts = sf_CNC.label36.Text;
            rjTextBox2.Texts = sf_CNC.label37.Text;
            rjTextBox3.Texts = sf_CNC.label34.Text;
            rjTextBox4.Texts = sf_CNC.label35.Text;

            ch_std = Convert.ToDouble(sf_CNC.label36.Text);
            ih_std = Convert.ToDouble(sf_CNC.label37.Text);
            ch = Convert.ToDouble(rjTextBox1.Texts);
            ih = Convert.ToDouble(rjTextBox2.Texts);
            cw = Convert.ToDouble(rjTextBox3.Texts);
            iw = Convert.ToDouble(rjTextBox4.Texts);

          
        }

        private void button16_Click(object sender, EventArgs e)
        {
            iwb = iwb - 0.01;
            rjTextBox9.Texts = string.Format("{0:0.00##}", iwb.ToString());
        }

        // TERM B
        private void button11_Click(object sender, EventArgs e)
        {
            chb = chb - 0.01;
            rjTextBox6.Texts = string.Format("{0:0.00##}", chb.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ihb = ihb + 0.01;
            rjTextBox7.Texts = string.Format("{0:0.00##}", ihb.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ihb = ihb - 0.01;
            rjTextBox7.Texts = string.Format("{0:000##}", ihb.ToString());
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }        

                
           
        

   

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ch = ch + 0.01;
            rjTextBox1.Texts = string.Format("{0:0.00##}", ch.ToString());
        }
    }
}
