using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.RJControls;

namespace WindowsFormsApp2
{

    public partial class ScanWOS : Form
    {
        SF_CNC fgrid;
        SF_CRP fcrp;
        //SF_CNC sfCNC;

       
        public static string terminala,terminalb,koderphmesin, Shift;
        public static double cha,iha,cwa,iwa, chb, ihb, cwb, iwb;
        String wire;
        Form1 form1 = new Form1();
        int qty = 0;

        
        public ScanWOS(SF_CNC sfcnc_, SF_CRP sfcrp_)
        {
            InitializeComponent();
            rjTextBox1.Focus(); 
            this.fgrid= sfcnc_;
            this.fcrp= sfcrp_;

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true || login.machine == "KMX01" || login.machine == "KMX02" || login.machine == "KMX03" || login.machine == "KMX04" || login.machine == "KMX05" || login.machine == "KMX06" || login.machine == "KMX07")
            {
                
                if ((fgrid.scan_term_stats == true || login.machine == "KMX01" || login.machine == "KMX02" || login.machine == "KMX03" || login.machine == "KMX04" || login.machine == "KMX05" || login.machine == "KMX06" || login.machine == "KMX07") && fgrid.scan_wire_stats == true)
                {
                  //  if (fgrid.labelwire.Text == wire && fgrid.labelterminal.Text == terminala && fgrid.labelterminalB.Text == terminalb)
                   // {
                        fgrid.timer1.Enabled = true;
                        DateTime localDate = DateTime.Now;

                        var culture = new CultureInfo("en-GB");
                        String datenow = localDate.ToString(culture);
                        string[] subs = datenow.Split(' ');

                        fgrid.label47.Text = subs[1];
                        fgrid.rjButton2.Text = "INPUT N1";

                        fgrid.label40.BackColor = Color.Transparent;
                        fgrid.label41.BackColor = Color.Transparent;
                        fgrid.label54.BackColor = Color.Transparent;
                        fgrid.label55.BackColor = Color.Transparent;
                        fgrid.label58.BackColor = Color.Transparent;
                        fgrid.label59.BackColor = Color.Transparent;

                        fgrid.label68.BackColor = Color.Transparent;
                        fgrid.label69.BackColor = Color.Transparent;

                        fgrid.label72.BackColor = Color.Transparent;
                        fgrid.label73.BackColor = Color.Transparent;

                        fgrid.label76.BackColor = Color.Transparent;
                        fgrid.label77.BackColor = Color.Transparent;

                        fgrid.lenght_n1.BackColor = Color.Transparent;
                        fgrid.lenght_n2.BackColor = Color.Transparent;
                        fgrid.lenght_n3.BackColor = Color.Transparent;

                        fgrid.label42.BackColor = Color.Transparent;
                        fgrid.label85.BackColor = Color.Transparent;

                        //-----------------------------------------

                        


                        fgrid.label40.Text = "0";
                        fgrid.label41.Text = "0";
                        fgrid.label54.Text = "0";
                        fgrid.label55.Text = "0";
                        fgrid.label58.Text = "0";
                        fgrid.label59.Text = "0";

                        fgrid.label68.Text = "0";
                        fgrid.label69.Text = "0";

                        fgrid.label72.Text = "0";
                        fgrid.label73.Text = "0";

                        fgrid.label76.Text = "0";
                        fgrid.label77.Text = "0";

                        fgrid.lenght_n1.Text = "0";
                        fgrid.lenght_n2.Text = "0";
                        fgrid.lenght_n3.Text = "0";

                        fgrid.label42.Text = "0";
                        fgrid.label85.Text = "0";
                        this.Hide();
                  //  }
                  //  else
                    //    MessageBox.Show("WRONG MATERIAL!");
                }
                else
                    MessageBox.Show("SCAN MATERIAL FIRST!");

            }
            else if (checkBox1.Checked == true || checkBox2.Checked == true || login.machine == "KMX01" || login.machine == "KMX02" || login.machine == "KMX03" || login.machine == "KMX04" || login.machine == "KMX05" || login.machine == "KMX06" || login.machine == "KMX07")
            {
                
                if ((fgrid.scan_term_stats || login.machine == "KMX01" || login.machine == "KMX02" || login.machine == "KMX03" || login.machine == "KMX04" || login.machine == "KMX05" || login.machine == "KMX06" || login.machine == "KMX07") == true && fgrid.scan_wire_stats == true)
                {
                   // if (fgrid.labelwire.Text == wire && (fgrid.labelterminal.Text == terminala || fgrid.labelterminalB.Text == terminalb))
                    //{
                        fgrid.timer1.Enabled = true;
                        DateTime localDate = DateTime.Now;

                        var culture = new CultureInfo("en-GB");
                        String datenow = localDate.ToString(culture);
                        string[] subs = datenow.Split(' ');

                        fgrid.label47.Text = subs[1];
                        fgrid.rjButton2.Text = "INPUT N1";

                        fgrid.label40.BackColor = Color.Transparent;
                        fgrid.label41.BackColor = Color.Transparent;
                        fgrid.label54.BackColor = Color.Transparent;
                        fgrid.label55.BackColor = Color.Transparent;
                        fgrid.label58.BackColor = Color.Transparent;
                        fgrid.label59.BackColor = Color.Transparent;

                        fgrid.label68.BackColor = Color.Transparent;
                        fgrid.label69.BackColor = Color.Transparent;

                        fgrid.label72.BackColor = Color.Transparent;
                        fgrid.label73.BackColor = Color.Transparent;

                        fgrid.label76.BackColor = Color.Transparent;
                        fgrid.label77.BackColor = Color.Transparent;

                        fgrid.lenght_n1.BackColor = Color.Transparent;
                        fgrid.lenght_n2.BackColor = Color.Transparent;
                        fgrid.lenght_n3.BackColor = Color.Transparent;

                        fgrid.label42.BackColor = Color.Transparent;
                        fgrid.label85.BackColor = Color.Transparent;

                        //-----------------------------------------
                        fgrid.label40.Text = "0";
                        fgrid.label41.Text = "0";
                        fgrid.label54.Text = "0";
                        fgrid.label55.Text = "0";
                        fgrid.label58.Text = "0";
                        fgrid.label59.Text = "0";
                        

                        fgrid.label68.Text = "0";
                        fgrid.label69.Text = "0";

                        fgrid.label72.Text = "0";
                        fgrid.label73.Text = "0";

                        fgrid.label76.Text = "0";
                        fgrid.label77.Text = "0";

                        fgrid.lenght_n1.Text = "0";
                        fgrid.lenght_n2.Text = "0";
                        fgrid.lenght_n3.Text = "0";

                        fgrid.label42.Text = "0";
                        fgrid.label85.Text = "0";
                        this.Hide();
                  //  }
                   // else
                     //   MessageBox.Show("WRONG MATERIAL!");
                }
                else
                    MessageBox.Show("SCAN MATERIAL FIRST!");

            }
            else
            MessageBox.Show("PICK TERMINAL FIRST!");
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            fgrid.terminala_stats = true;
            else
            fgrid.terminala_stats = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                fgrid.terminalb_stats = true;
            else
                fgrid.terminalb_stats = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public ScanWOS(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void rjTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string barcode;
            int cell_qty = 0;
            int cell_lot = 0;
            int cell_pn = 0;
            int cell_skm = 0;
            int cell_cha = 0;
            int cell_iha = 0;
            int cell_chb = 0;
            int cell_ihb = 0;
            int cell_terma = 0;
            int cell_termb = 0;
            int cell_ct = 0;
            int cell_wire = 0;
            int cell_koderphmesin = 0;
            int cell_shift = 0;
            int cell_panjang = 0;
            int cell_barcode=0;

            fgrid.label44.Text = "-";
            fgrid.label45.Text = "-";
            fgrid.label46.Text = "-";
            fgrid.label43.Text = "0";
            fgrid.label47.Text = "-";
            fgrid.label48.Text = "-";



            //  Console.WriteLine("tes");
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    for (int i = 0; i < 35; i++)
                    {

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "sift")
                        {
                            cell_shift = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "panjang")
                        {
                            cell_panjang = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "barcode")
                        {
                            cell_barcode = i;


                        }



                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "LOTNO")
                        {
                            cell_lot = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "KodeRPHMeisn")
                        {
                            cell_koderphmesin = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "QTY")
                        {
                            cell_qty = i;


                        }
                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "PART NAME")
                        {
                            cell_pn = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "SKEMA")
                        {
                            cell_skm = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "CH/A")
                        {
                            cell_cha = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "IH/A")
                        {
                            cell_iha = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "CH/B")
                        {
                            cell_chb = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "IH/B")
                        {
                            cell_ihb = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "TERMINALA")
                        {
                            cell_terma = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "TERMINALB")
                        {
                            cell_termb = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "CT")
                        {
                            cell_ct = i;


                        }

                        if (fgrid.dataGridView1.Columns[i].HeaderText.ToString() == "WIRE")
                        {
                            cell_wire = i;


                        }



                    }
                    int numRows = fgrid.dataGridView1.Rows.Count;
                    barcode = rjTextBox1.Texts;
                    fgrid.data_bardoce = barcode;
                    int count = 0;
                    //  txtTotalItem.Text = numRows.ToString();
                    string upperbarcode = barcode.ToUpper();
                    string[] words = {"char1","char2" };
                    
                    //error jika string tidak ada char -> '.'
                    words = upperbarcode.Split('.');



                    if (words[1] != "char2" && words[1] != "")
                    {
                        for (int i = 0; i < numRows; i++)
                        {
                            try
                            {
                                // string datagrifview = Convert.ToString(fgrid.dataGridView1.Rows[i].Cells[47].Value);
                                // if (fgrid.dataGridView1.Rows.Count > 0 && fgrid.dataGridView1.Rows[i].Cells[47] != null)
                                Console.WriteLine(Convert.ToInt32(words[1]));
                                Console.WriteLine(Convert.ToInt32(fgrid.dataGridView1.Rows[i].Cells[cell_skm].Value));

                                if (words[0] == Convert.ToString(fgrid.dataGridView1.Rows[i].Cells[cell_lot].Value) && Convert.ToInt32(words[1]) == Convert.ToInt32(fgrid.dataGridView1.Rows[i].Cells[cell_skm].Value))
                                {
                                    // MessageBox.Show(fgrid.dataGridView1.Rows[i].Cells[cell_terma].Value.ToString());
                                    terminala = fgrid.dataGridView1.Rows[i].Cells[cell_terma].Value.ToString();
                                    terminalb = fgrid.dataGridView1.Rows[i].Cells[cell_termb].Value.ToString();

                                    koderphmesin = fgrid.dataGridView1.Rows[i].Cells[cell_koderphmesin].Value.ToString();
                                    Shift = fgrid.dataGridView1.Rows[i].Cells[cell_shift].Value.ToString();

                                    label3.Text = terminala;
                                    label4.Text = terminalb;
                                    
                                    if (fgrid.dataGridView1.Rows[i].Cells[cell_cha].Value != DBNull.Value)
                                        cha = Convert.ToDouble(fgrid.dataGridView1.Rows[i].Cells[cell_cha].Value);
                                    else
                                        cha = 0;
                                    if (fgrid.dataGridView1.Rows[i].Cells[cell_iha].Value != DBNull.Value)
                                        iha = Convert.ToDouble(fgrid.dataGridView1.Rows[i].Cells[cell_iha].Value);
                                    else
                                        iha = 0;

                                    if (fgrid.dataGridView1.Rows[i].Cells[cell_chb].Value != DBNull.Value)
                                        chb = Convert.ToDouble(fgrid.dataGridView1.Rows[i].Cells[cell_chb].Value);
                                    else
                                        chb = 0;
                                    if (fgrid.dataGridView1.Rows[i].Cells[cell_ihb].Value != DBNull.Value)
                                        ihb = Convert.ToDouble(fgrid.dataGridView1.Rows[i].Cells[cell_ihb].Value);
                                    else
                                        ihb = 0;
                                    

                                    qty = Convert.ToInt32(fgrid.dataGridView1.Rows[i].Cells[cell_qty].Value);
                                    fgrid.cycle_time = Convert.ToInt32(fgrid.dataGridView1.Rows[i].Cells[cell_ct].Value);

                                    wire = fgrid.dataGridView1.Rows[i].Cells[cell_wire].Value.ToString();
                                    // MessageBox.Show(wire);

                                    fgrid.barcode = fgrid.dataGridView1.Rows[i].Cells[cell_barcode].Value.ToString();

                                    String panjang_wire = fgrid.dataGridView1.Rows[i].Cells[cell_panjang].Value.ToString();
                                    //  MessageBox.Show(fgrid.barcode);
                                    fgrid.panjang_wire = string.Format("{0:0##}", panjang_wire);

                                    fgrid.label33.Text = terminala;
                                    fgrid.label87.Text = terminalb;
                                    /*
                                    fgrid.label36.Text = string.Format("{0:0.00##}", cha);
                                    fgrid.label37.Text = string.Format("{0:0.00##}", iha);
                                    fgrid.label64.Text = string.Format("{0:0.00##}", chb);
                                    fgrid.label65.Text = string.Format("{0:0.00##}", ihb);
                                    */
                                    string cha_ =  cha.ToString().Replace(",",".");
                                    string iha_ = iha.ToString().Replace(",", ".");
                                    string chb_ = chb.ToString().Replace(",", ".");
                                    string ihb_ = ihb.ToString().Replace(",", ".");
                                    fgrid.label36.Text = cha_;
                                    fgrid.label37.Text = iha_;
                                    fgrid.label64.Text = chb_;
                                    fgrid.label65.Text = ihb_;
                                    fgrid.labelwire_rph.Text = wire;
                                    //dataGridView1.Columns["NamaMesin"]

                                    // fgrid.label44.Text = fgrid.dataGridView1.Rows[i].c;

                                    fgrid.label44.Text = fgrid.dataGridView1.Rows[i].Cells[cell_skm].Value.ToString();
                                    fgrid.label45.Text = fgrid.dataGridView1.Rows[i].Cells[cell_pn].Value.ToString();
                                    fgrid.label46.Text = fgrid.dataGridView1.Rows[i].Cells[cell_lot].Value.ToString();
                                    fgrid.label43.Text = qty.ToString();
                                    form1.qty = qty;

                                    count++;

                                }

                            }
                            catch (Exception er)
                            {
                                MessageBox.Show(er.Message);
                            }




                        }
                    }
                    if (count == 0)
                    {
                        MessageBox.Show("KOSONG");
                    }
                    rjTextBox1.Texts = "";
                    /*
                    try
                    {
                        String string1ty = "qty="+qty.ToString()+"#";
                        Console.WriteLine(string1ty);
                        fgrid.serialPort1.Write(string1ty);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("PORT CLOSED");
                    }

                    */
                    /*
                    try
                    {
                        fgrid.serialPort1.Write("STRT#");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("PORT CLOSED");
                    }
                    */
                    /*
                    try
                    {
                        String string1ty = "qty=" + qty.ToString() + "#";
                        Console.WriteLine(string1ty);
                        form1.serialPort1.Write(string1ty);

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("PORT CLOSED");
                    }


                    try
                    {
                        form1.serialPort1.Write("STRT#");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("PORT CLOSED");
                    }

                    try
                    {
                        form1.serialPort1.Write("STRT#");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("PORT CLOSED");
                    }
                    */





                }
            }
            catch { }
        }
    }
}
