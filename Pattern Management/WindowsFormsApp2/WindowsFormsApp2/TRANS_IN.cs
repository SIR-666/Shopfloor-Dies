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
using System.IO.Ports;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp2
{
    public partial class TRANS_IN : UserControl
    {
        static readonly string textFile = "Port_Set.txt";
        string port_name = "COM3";
        string weight_string;
        int coint_weight = 0;
        string lotno;
        private List<Item> items;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=dbInventory2;User ID=nganjuk;Password=Excited2020";
        string partnum;
        bool return_mat = false;
        
        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;

        Form1 form1;

        public TRANS_IN(Form1 form1)
        {
            InitializeComponent();

            this.form1 = form1;
            items = new List<Item>();
            

            cnn = new SqlConnection(connetionString);
            SqlDataReader dataReader;
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
                label12.Text = "Com : Connected";
            }
            else
            {
                label12.Text = "Com : Not Connected";
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
                SqlCommand cmd2 = new SqlCommand("exec CEK_HISTORY_IN @date = @currentdate", cnn);
                //SqlCommand cmd2 = new SqlCommand("exec RPH_PERMESINCNC @dt,@mc", cnn);
                cmd2.Parameters.AddWithValue("@currentdate", datenow);
                // cmd2.Parameters.AddWithValue("@mc", login.machine);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch { MessageBox.Show("Cant Connect Database"); }

            //form1.serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialport_recieve);

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





        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
                checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000003";
                lblPartname.Text = "Return Scrap FC";
                partnum = "Return Scrap FC";
                checkBox1.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000004";
                lblPartname.Text = "Return Scrap FD";
                partnum = "Return Scrap FCD";
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
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
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000044";
                partnum = "Starting Block FC";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
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
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox6.Checked = false; checkBox5.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
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
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox8.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
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
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox9.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
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
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox6.Checked = false; checkBox11.Checked = false; checkBox10.Checked = false;
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
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox6.Checked = false; checkBox11.Checked = false; checkBox9.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                return_mat = true;
                label8.Text = "RMI.CT.FN.00000050";
                partnum = "Return Scrap FC HIGH CHROME";
                lblPartname.Text = partnum;
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; checkBox5.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox6.Checked = false; checkBox10.Checked = false; checkBox9.Checked = false;
            }
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

        private void UpdateLabelSafe(string text)
        {
            // Check if the control's handle has been created
            if (label1.IsHandleCreated)
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
            //PRINTOUT print = new PRINTOUT();
            //print.Show();
            //THERMAL_PRINT termprint = new THERMAL_PRINT();
            //termprint.Show();
            cnn = new SqlConnection(connetionString);
           // if ((guna2TextBox2.Text != "0" && return_mat == true) || return_mat == false)
           // {
                if (label6.Text != "0")
                {
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

                    try
                    {
                        SqlCommand cmd = new SqlCommand("exec CREATE_SALDO_WMS @itemcode = @rmi, @qty = @value;", cnn);
                        cmd.Parameters.AddWithValue("@rmi", label8.Text);
                        cmd.Parameters.AddWithValue("@value", berat_net.ToString());
                        dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            // Console.WriteLine(dataReader.GetString(0));

                            lotno = String.Format("{0}", dataReader["nolot"]);


                            guna2TextBox1.Text = lotno;
                            Console.WriteLine(lotno);
                            // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                            //data2txt.Text = dataReader.GetString("jumlah");
                            MessageBox.Show("Process Success");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Data Error");
                    }
                    //exec CREATE_SALDO_WMS @itemcode = 'SMI.CT.GS.00000014', @qty = '10';
                    print_receipt();
                }
                else
                {
                    MessageBox.Show("TIMBANG MATERIAL");
                }
          //  }
          //  else
          //  {
          //      MessageBox.Show("INPUT TAR");
          //  }
        }

        private void print_receipt()
        {

            try
            {
                Printer printer = new Printer(form1.printer_name);
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
                items.Clear();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  label6.Text = form1.label1.Text;
            //int net_value = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);
            //label14.Text = net_value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            // Menggambar bayangan
            int shadowSize = 10; // Ukuran bayangan
            Rectangle rect = this.tableLayoutPanel2.ClientRectangle;

            using (LinearGradientBrush brushRight = new LinearGradientBrush(
                new Rectangle(rect.Right, rect.Top, shadowSize, rect.Height),
                Color.FromArgb(128, Color.Black),
                Color.Transparent,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brushRight, new Rectangle(rect.Right, rect.Top, shadowSize, rect.Height));
            }

            using (LinearGradientBrush brushBottom = new LinearGradientBrush(
                new Rectangle(rect.Left, rect.Bottom, rect.Width, shadowSize),
                Color.FromArgb(128, Color.Black),
                Color.Transparent,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brushBottom, new Rectangle(rect.Left, rect.Bottom, rect.Width, shadowSize));
            }
        }
    }

   
}
