using ESC_POS_USB_NET.Printer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
//using ESC_POS_USB_NET.Printer;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Windows.Media;
using System.IO.Ports;

namespace WindowsFormsApp2
{
    public partial class TRANS_OUT : UserControl
    {
        static readonly string textFile = "Port_Set.txt";
        string port_name = "COM3";
        string partnum;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=dbInventory2;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;
        string lotno;
        string sisa;
        string RMI;
        string noGFS;
        string weight_string;
        int coint_weight = 0;
        string printer_name;
        Form1 form1;
        string[] days = { "A", "B", "C", "D", "E", "F", "G", "H", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "W", "X", "Y", "Z"};
        bool return_mat = false;
        public TRANS_OUT(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            

            
            //panel1.Controls.Add(verticalLine);
            /*
            string[] lines = File.ReadAllLines(textFile);
            port_name = lines[0];
            printer_name = lines[1];
            Console.WriteLine(port_name);
            Console.WriteLine(printer_name);
            serialPort1.PortName = port_name;

            //if (serialPort1.IsOpen)
            serialPort1.Close();

            try
            {
                serialPort1.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            */

            cnn = new SqlConnection(connetionString);
            //SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            

            if (form1.serialPort1.IsOpen)
            {
                label15.Text = "Com : Connected";
            }
            else
            {
                label15.Text = "Com : Not Connected";
            }

            //   sf_CNC.dataGridView1.ColumnHeadersHeight = 23;
            //   sf_CNC.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // autosize column             
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            string datenow = localDate.ToString(culture);
            //Console.WriteLine(datenow);
            string[] words2 = datenow.Split(' ');
            words2 = words2[0].Split('/');
            datenow = words2[2] + "-" + words2[1] + "-" + words2[0];

            string noreg = login.SetValueForText1;
            try
            {
                SqlCommand cmd2 = new SqlCommand("exec CEK_HISTORY_OUT @date = @currentdate", cnn);
                //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESINCNC @dt,@mc", cnn);
                cmd2.Parameters.AddWithValue("@currentdate", datenow);
               // cmd2.Parameters.AddWithValue("@mc", login.machine);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch { MessageBox.Show("Cant Connect Database"); }

            try
            {
                SqlCommand cmd3 = new SqlCommand("EXEC CEK_PRODUCT", cnn);
                //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESINCNC @dt,@mc", cnn);
               // cmd2.Parameters.AddWithValue("@currentdate", datenow);
                // cmd2.Parameters.AddWithValue("@mc", login.machine);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }

            catch { MessageBox.Show("Cant Connect Database"); }
            //form1.serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialport_recieve);

            //datagridget();

        }

        private void serialport_recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            char data_weight = (char)form1.serialPort1.ReadChar();

            if (data_weight == '#')
            {


                if (weight_string == "0")
                    coint_weight++;
                else
                    coint_weight = 0;

                if (coint_weight <= 2)
                {
                    //label6.Invoke((MethodInvoker)(() => label6.Text = weight_string));
                    UpdateLabelSafe(weight_string);
                    Console.WriteLine(weight_string);
                }
                weight_string = "";
            }
            else
                weight_string += data_weight;

            /*
            try
            {
                string[] subs = data_weight.Split('\n');
                Console.WriteLine(subs[0]);
                weight_string = subs[0];
                //label6.Text = subs[0];
            }
            catch { }
            // label6.Text = weight_string;
            String string_weight = weight_string.Replace('\n', ' ');
            label6.Invoke((MethodInvoker)(() => label6.Text = string_weight));
            */
        }

        /*
        private void datagridget()
        {

            int numRows = dataGridView2.Rows.Count;
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue;
            for (int j = 1; j < numRows; j++)
            {
                try
                {
                    datavalue = Convert.ToString(dataGridView2.Rows[j].Cells[1].Value);
                    Console.WriteLine(datavalue);
                    if (datavalue != null)
                        comboBox1.Items.Add(datavalue);
                }
                catch { }
            }
        }
        */

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000044";
                partnum = "Starting Block FC";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false; checkBox12.Checked = false;
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                return_mat = false;
                label8.Text = "RMI.CT.FN.00000047";
                partnum = "SCRAP HIGH MANGANESE";
                lblPartname.Text = partnum;
                checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false;  checkBox12.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000003";
                partnum = "Return Scrap FC";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false;  checkBox12.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000004";
                partnum = "Return Scrap FCD";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false;  checkBox12.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000005";
                partnum = "Return Scrap Steel";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false;  checkBox12.Checked = false;
            } 
        }

     



        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000045";
                partnum = "Starting Block FCD";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox6.Checked = false; checkBox5.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false;  checkBox12.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000046";
                partnum = "Starting Block Steel";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox10.Checked = false;  checkBox12.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                return_mat = false;
                label8.Text = "RMI.CT.FN.00000048";
                partnum = "SCRAP LOW MANGANESE";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox10.Checked = false; checkBox12.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                return_mat = false;
                label8.Text = "RMI.CT.FN.00000049";
                partnum = "SCRAP HIGH CHROME";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox6.Checked = false; checkBox12.Checked = false; checkBox10.Checked = false; 
            }
        }

      

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                return_mat = false;
                label8.Text = "RMI.CT.FN.00000036";
                partnum = "SCRAP ALUMUNIUM";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox6.Checked = false; checkBox12.Checked = false; checkBox9.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000050";
                partnum = "Return Scrap FC HIGH CHROME";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox6.Checked = false; checkBox10.Checked = false; checkBox9.Checked = false;
            }
        }

        private void guna2TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cnn = new SqlConnection(connetionString);
                SqlDataReader dataReader, dataReader2;
                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                int berat_net = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);

                SqlCommand cmd = new SqlCommand("exec CEK_LOT @nolot = @lotno;", cnn);
                cmd.Parameters.AddWithValue("@lotno", guna2TextBox3.Text);
                //cmd.Parameters.AddWithValue("@value", berat_net.ToString());
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    sisa = String.Format("{0}", dataReader["sisa"]);
                    
                    label12.Text = sisa;


                    Console.WriteLine(sisa);
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
                ;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            char data_weight = (char)serialPort1.ReadChar();

            if (data_weight == '#')
            {


                if (weight_string == "0")
                    coint_weight++;
                else
                    coint_weight = 0;

                if (coint_weight <= 2)
                {
                    //label6.Invoke((MethodInvoker)(() => label6.Text = weight_string));
                    UpdateLabelSafe(weight_string);
                    Console.WriteLine(weight_string);
                }
                weight_string = "";
            }
            else
                weight_string += data_weight;
        }

        private void UpdateLabelSafe(string text)
        {
            // Check if the control's handle has been created
            if (label6.IsHandleCreated)
            {
                // Use Invoke or BeginInvoke to update the UI control
                label6.BeginInvoke(new Action(() =>
                {
                    label6.Text = text;
                }));
            }
            else
            {
                // Optionally handle the case when the handle is not created
                // For example, you could queue the update to be executed later
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            int current_mes = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);
            if (guna2TextBox1.Text != "")
            {
                cnn = new SqlConnection(connetionString);
                SqlDataReader dataReader, dataReader2;
                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                string[] data_ahir = label12.Text.Split('.');
                int berat_net = Convert.ToInt32(data_ahir[0]) - Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);

                label12.Text = label6.Text;

                try
                {
                    SqlCommand cmd = new SqlCommand("exec CREATE_TRANS @nolot = @lotno, @qty = @value, @product = @prod", cnn);
                    cmd.Parameters.AddWithValue("@lotno", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@value", berat_net.ToString());
                    cmd.Parameters.AddWithValue("@prod", guna2TextBox1.Text);
                    //cmd.ExecuteNonQuery();
                    
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Console.WriteLine(dataReader.GetString(0));

                        lotno = String.Format("{0}", dataReader["nolot"]);



                        Console.WriteLine(lotno);
                        // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                        //data2txt.Text = dataReader.GetString("jumlah");
                        MessageBox.Show("Process Success");
                    }
                    
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                //exec CREATE_SALDO_WMS @itemcode = 'SMI.CT.GS.00000014', @qty = '10';
                //print_receipt();
            }
        }

        private void print_receipt()
        {

            try
            {
                Printer printer = new Printer(printer_name);
                printer.AlignCenter();
                SetFontSize(printer, "Small");
                printer.Append("PENERIMAAN MATERIAL");
                printer.NewLine();
                //printer.Separator();
                printer.AlignLeft();
                SetFontSize(printer, "Small");
                string print_rmi = "RMI  : " + label8.Text;
                printer.Append(print_rmi);
                string print_pn = "PN   : " + partnum;
                printer.Append(print_pn);
                string print_lot = "LOT  : " + lotno;
                printer.Append(print_lot);
                DateTime now = DateTime.Now;

                // Format the date and time into a single string
                string dateTimeString = now.ToString("yyyy-MM-dd");
                string print_date = "Date : " + dateTimeString;
                printer.Append(print_date);
                //  printer.Separator();

                /*
                foreach (var item in items)
                {
                    printer.Append($"{item.Name}\t\t{item.Price:C}");
                }
                */

                //printer.Separator();
                int berat_net = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);
                printer.NewLine();
                printer.AlignCenter();
                string print_weight = $"Weight =";
                print_weight = print_weight + " " + berat_net.ToString();
                printer.Append(print_weight);

                // Add barcode

                string barcode = lotno;
                if (!string.IsNullOrEmpty(barcode))
                {
                    printer.Append("Scan the barcode below:");
                    //PrintQRCode(printer, barcode, 5);
                    //printer.Code39(barcode);
                    //SetFontSize(printer, "Medium");
                    PrintQRCode(printer, barcode, 5);
                    // printer.QrCode(barcode);
                }

                //  printer.Append("Thank you for shopping!");
                //  printer.NewLine();
                printer.NewLine();
                printer.NewLine();

                printer.PrintDocument();
                //items.Clear();
                //  dataGridView1.DataSource = null;
                //   txtBarcode.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing receipt: " + ex.Message);
            }
        }

        private void SetFontSize(Printer printer, string fontSize)
        {
            byte[] command;
            switch (fontSize)
            {
                case "Small":
                    command = new byte[] { 0x1D, 0x21, 0x00 }; // Normal size
                    break;
                case "Medium":
                    command = new byte[] { 0x1D, 0x21, 0x11 }; // Double height and width
                    break;
                case "Large":
                    command = new byte[] { 0x1D, 0x21, 0x22 }; // Quadruple height and width
                    break;
                default:
                    command = new byte[] { 0x1D, 0x21, 0x00 }; // Default to normal size
                    break;
            }
            printer.Append(command);
        }

        private void PrintQRCode(Printer printer, string qrCodeText, int moduleSize)
        {
            // Prepare ESC/POS commands for QR code
            List<byte> commandList = new List<byte>();

            // Set QR code model
            commandList.AddRange(new byte[] { 0x1D, 0x28, 0x6B, 0x04, 0x00, 0x31, 0x41, 0x32, 0x00 });

            // Set QR code module size
            commandList.AddRange(new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x43, (byte)moduleSize });

            // Store QR code data
            int qrCodeDataLength = qrCodeText.Length + 3;
            byte pL = (byte)(qrCodeDataLength % 256);
            byte pH = (byte)(qrCodeDataLength / 256);
            commandList.AddRange(new byte[] { 0x1D, 0x28, 0x6B, pL, pH, 0x31, 0x50, 0x30 });
            commandList.AddRange(Encoding.ASCII.GetBytes(qrCodeText));

            // Print QR code
            commandList.AddRange(new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x51, 0x30 });

            // Send commands to printer
            printer.Append(commandList.ToArray());
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            int current_mes = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);
            if (current_mes >= 0.5)
            {
                cnn = new SqlConnection(connetionString);
                SqlDataReader dataReader, dataReader2;
                try
                {
                    cnn.Open();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                int berat_net = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);


                SqlCommand cmd = new SqlCommand("exec CEK_LOT @nolot = @lotno;", cnn);
                cmd.Parameters.AddWithValue("@lotno", guna2TextBox3.Text);
                //cmd.Parameters.AddWithValue("@value", berat_net.ToString());
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    sisa = String.Format("{0}", dataReader["sisa"]);

                    label12.Text = sisa;


                    Console.WriteLine(sisa);
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
                MessageBox.Show("Process Success");
                /*
                SqlCommand cmd = new SqlCommand("exec CREATE_SALDO_WMS @itemcode = @rmi, @qty = @value;", cnn);
                cmd.Parameters.AddWithValue("@rmi", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@value", berat_net.ToString());
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    lotno = String.Format("{0}", dataReader["nolot"]);



                    Console.WriteLine(lotno);
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
                */
                //exec CREATE_SALDO_WMS @itemcode = 'SMI.CT.GS.00000014', @qty = '10';
                print_receipt();
            }
        }

        /*
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != null)
            {
                noGFS = getRMI(comboBox1.Text);
                Console.WriteLine(noGFS);
            }
        }
        */

        private string getRMI(string partname)
        {

            int numRows = dataGridView2.Rows.Count;
            string nofgs="";
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            //string datavalue;
            for (int j = 1; j < numRows; j++)
            {
                
                try
                {
                    if (partname == Convert.ToString(dataGridView2.Rows[j].Cells[1].Value))
                    {
                        nofgs = Convert.ToString(dataGridView2.Rows[j].Cells[0].Value);
                        break;
                    }
                    //    datavalue = Convert.ToString(dataGridView2.Rows[j].Cells[1].Value);
                   // Console.WriteLine(datavalue);
                   // if (datavalue != null)
                   //     comboBox1.Items.Add(datavalue);
                }
                catch { }
            }

            return nofgs;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // label6.Text = form1.label1.Text;
           // int net_value = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);
          //  label16.Text = net_value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            // Get the current year, month, and day separately
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            string month_s;
            string day_s;
            year = year % 2020;

            if (month == 10)
                month_s = "X";
            else if (month == 11)
                month_s = "Y";
            else if (month == 12)
                month_s = "Z";
            else
            {
                month_s = month.ToString();
            }

            if (day > 9)
            {
                day_s = days[day-10];
            }
            else
                day_s = day.ToString();
            
            guna2TextBox1.Text = year.ToString() + month_s + day_s;

        }

        
    }
}
