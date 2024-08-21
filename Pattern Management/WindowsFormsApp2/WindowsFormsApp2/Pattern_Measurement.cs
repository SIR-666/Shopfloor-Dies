using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Pattern_Measurement : Form
    { Pattern_Center pc;
        bool visual = false;
        bool baseplate = false;
        public Pattern_Measurement(Pattern_Center pc)
        {
            InitializeComponent();
            this.pc = pc;
            datagridget2();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridget2()
        {

            int numRows = pc.dataGridView2.Rows.Count;
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue;
            for (int j = 0; j < numRows; j++)
            {
                try
                {
                    datavalue = Convert.ToString(pc.dataGridView2.Rows[j].Cells[1].Value);
                    Console.WriteLine(datavalue);
                    if (datavalue != null)
                        comboBox1.Items.Add(datavalue);
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked) && checkBox1.Text != "")
            {
                pc.update_partnameshot(comboBox1.Text);
                pc.store_measurement_pattern(visual, baseplate, tb_panjang.Text, tb_lebar.Text, tb_tinggi.Text, tb_diameter.Text, tb_ingate_lebar.Text, tb_ingate_tinggi.Text, textBox7.Text);
                pc.label26.Text = tb_panjang.Text;
                pc.label25.Text = tb_lebar.Text;
                pc.label24.Text = tb_tinggi.Text;
                pc.label29.Text = tb_diameter.Text;
                pc.label28.Text = tb_ingate_lebar.Text;
                pc.label27.Text = tb_ingate_tinggi.Text;

                if (visual == false || baseplate == false)
                    pc.label18.Text = "NG";
                else
                    pc.label18.Text = "OK";

                this.Close();
            }
            else
            {
                MessageBox.Show("Fill all measurement data");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { 
                visual = true;
                checkBox2.Checked = false;
            }
            else
            
                visual = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                visual = false;
                checkBox1.Checked = false;
            }
            else
                visual = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                baseplate = true;
                checkBox3.Checked = false;
            }
            else

                baseplate = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                baseplate = false;
                checkBox4.Checked = false;
            }
            else

                baseplate = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pattern_Measurement_Load(object sender, EventArgs e)
        {
            int radius = 10; // Change this value to adjust the corner radius
            SetRoundedCorners(radius);
        }

        private void SetRoundedCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddLine(radius, 0, this.Width - radius, 0);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), -90, 90);
            path.AddLine(this.Width, radius, this.Width, this.Height - radius);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddLine(this.Width - radius, this.Height, radius, this.Height);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
