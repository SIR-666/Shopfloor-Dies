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
    public partial class Wire_Req : Form
    {
        SF_CNC SF_CNC;
        AutoCompleteStringCollection data = new AutoCompleteStringCollection();
        public Wire_Req(SF_CNC sf_CNC)
        {
            InitializeComponent();
            this.SF_CNC = sf_CNC;
            //comboBox1.AutoCompleteCustomSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            int cell_wire = 0;
            for (int j = 0; j < 35; j++)
            {



                if (SF_CNC.dataGridView1.Columns[j].HeaderText.ToString() == "WIRE")
                {
                    cell_wire = j;


                }



            }

            int numRows = SF_CNC.dataGridView1.Rows.Count;
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue;
            for (int j = 1; j < numRows; j++)
            {
                try
                {
                    datavalue = Convert.ToString(SF_CNC.dataGridView1.Rows[j].Cells[cell_wire].Value);
                    Console.WriteLine(datavalue);
                    if (datavalue != null)
                        comboBox1.Items.Add(datavalue);
                }
                catch { }
            }

            /*
            int i = 0;
            foreach (string ss in Datavalue)
            { 
                comboBox1.Items.Add(ss);
                i++;
            }
            */
        }

        private void Wire_Req_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
