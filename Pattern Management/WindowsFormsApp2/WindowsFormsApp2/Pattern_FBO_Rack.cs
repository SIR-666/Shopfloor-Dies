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
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using System.Threading.Tasks;
using Modbus.Data;
using Guna.UI2.WinForms;
using Org.BouncyCastle.Asn1.Pkcs;

namespace WindowsFormsApp2
{
    public partial class Pattern_FBO_Rack : UserControl
    {
        MqttClient mqttClient;
        string connetionString = "Data Source=192.168.2.1;Initial Catalog=Plant5;User ID=roni@ipg;Password=AutoCasting";

        //string connetionString = "Data Source=192.168.5.4;Initial Catalog=DMS;User ID=dimas;Password=Satusampai9";
        SqlConnection cnn;
        public int qty_ng = 0;
        int timer_toreload=0;
        public Pattern_FBO_Rack()
        {
            InitializeComponent();
            Random random = new Random();
            int randomNumber = random.Next();
            mqttClient = new MqttClient("192.168.0.10");
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            mqttClient.Subscribe(new string[] { "/Dash/SHOT/PATTERN" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            mqttClient.Connect("FBO-SHOTRECORD" + randomNumber.ToString());
            if (mqttClient.IsConnected)
            {
                //label1.Text = "Connected OK";
            }
            container.WrapContents = false;
            displayED();
            datagridget();
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            // listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(message)));
            //  listView1.Invoke((MethodI nvoker)(() => listView1.Items.Add(message)));
            // listView.Items.Add(subStrings[3]);
            //  listBox2.Invoke((MethodInvoker)(() => listBox2.Items.Add(message)));

            String datareceive = message;
            Console.WriteLine(message);
            PROCESSDATA(message);

        }

        void PROCESSDATA(string message)
        {

            if (label8.IsHandleCreated)
            {
                label8.Invoke((MethodInvoker)delegate
                {
                    label8.Invoke((MethodInvoker)(() => label8.Text = message));
                    //label27.Invoke((MethodInvoker)(() => label27.Text = DataReceive[2]));
                    //label28.Invoke((MethodInvoker)(() => label28.Text = DataReceive[3]));
                });
            }
        }

        public void UpdateRowSource_shoot(string partname, int no_urut, int ng_mould)
        {
            cnn.Close();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            SqlCommand cmd = new SqlCommand("EXEC UpdateShot  @Pattern_Name, @no_urut, @ng_mould;", cnn); // "list aplikator" ("select id,hobby from table 1", conn)


            cmd.Parameters.AddWithValue("@Pattern_Name", partname);
            cmd.Parameters.AddWithValue("@no_urut", no_urut);
            cmd.Parameters.AddWithValue("@ng_mould", ng_mould);




            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void get_qtyrph(String pattern_name)
        {
            

                cnn.Close();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            String user_name = "Hi  " + login.user_name;


            SqlDataReader dataReader;
            try
            {
                //SqlCommand cmd = new SqlCommand("select * from historical_pattern_basepattern_transactions where pattern_name = @pattern", cnn);
                SqlCommand cmd = new SqlCommand("EXEC GetQtyMold @inputpatternname;", cnn);
                cmd.Parameters.AddWithValue("@inputpatternname", pattern_name);
               // cmd.Parameters.AddWithValue("@no_urut", no_urut);
                //cmd.ExecuteNonQuery();

                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    String qty = String.Format("{0}", dataReader["qty_mould"]);
                    String prodname = String.Format("{0}", dataReader["partname"]);
                    label28.Text = String.Format("{0}", dataReader["material"]);
                    label27.Text = String.Format("{0}", dataReader["total_pcs"]);

                    label23.Text = String.Format("{0}", dataReader["mould_qty_ladle"]);
                    label22.Text = String.Format("{0}", dataReader["cav_pcs"]);

                    label24.Text = String.Format("{0}", dataReader["ladle_qty"]);
                    label25.Text = String.Format("{0}", dataReader["volume"]);
                    label26.Text = String.Format("{0}", dataReader["tot_cairan"]);

                    label5.Text = prodname;
                    label6.Text = qty;
                    //MessageBox.Show("Process Success");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


        }

        public void insertPartname(String partname, int no_urut)
        {
            cnn.Close();
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            SqlCommand cmd = new SqlCommand("exec UpdatePatternShotRecordAndRphs @Pattern_Name, @no_urut;", cnn); // "list aplikator" ("select id,hobby from table 1", conn)

            cmd.Parameters.AddWithValue("@Pattern_Name", partname);
            cmd.Parameters.AddWithValue("@no_urut", no_urut);



            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }


        void displayED()
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
            //int berat_net = Convert.ToInt32(label6.Text) - Convert.ToInt32(guna2TextBox2.Text);

            //SqlCommand cmd = new SqlCommand("SELECT patern_name FROM historical_pattern_basepatterns WHERE lokasi_id = 1;", cnn);
            SqlCommand cmd = new SqlCommand("SELECT partname,pattern_name,no_urut FROM rphs where tgl_pouring = CONVERT(VARCHAR, GETDATE(), 23) and machine='FBO' and jam_finish is null order by no_urut asc;", cnn);
            //cmd.Parameters.AddWithValue("@lotno", guna2TextBox3.Text);
            //cmd.Parameters.AddWithValue("@value", berat_net.ToString());
            SqlDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(da);

            dataGridView1.DataSource = dt;

        }

        private void datagridget()
        {

            int numRows = dataGridView1.Rows.Count;
            int nomerRPH = 0;
            //string[] Datavalue = new string[numRows];
            //foreach (DataGridViewRow row in SF_CNC.dataGridView1.Rows)
            string datavalue, productname,no_urut;
            container.Controls.Clear();
            for (int j = 0; j < numRows-1; j++)
            {
                try
                {
                    datavalue = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value);
                    no_urut = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value);
                    productname = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value);
                    Console.WriteLine(datavalue);
                    if (datavalue != null)
                    {
                        nomerRPH++;
                        PatternTransc patternTransc = new PatternTransc(this);
                        //ucDays.day_show(i);
                        container.Controls.Add(patternTransc);
                        container.ScrollControlIntoView(patternTransc);
                        patternTransc.label2.Text = datavalue;
                        patternTransc.label5.Text = productname;
                        patternTransc.label1.Text = no_urut;

                    }
                        //comboBox1.Items.Add(datavalue);
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PatternTransc patternTransc = new PatternTransc();
            //ucDays.day_show(i);
            container.Controls.Add(patternTransc);
            container.ScrollControlIntoView(patternTransc);
            */
        }

        public class SlaveConfig
        {
            public int SlaveId { get; set; }
            public string IpAddress { get; set; }
            public int Port { get; set; }
        }
        private SlaveConfig _slaveConfig = new SlaveConfig
        {
            SlaveId = 1, // Replace with your slave ID
            IpAddress = "127.0.0.1", // Replace with master's IP address
            Port = 502 // Replace with master's port (default Modbus TCP port)
        };


        public void start_pattern()
        {
            byte[] modbusMessage = new byte[] { 0x02, 0x06, 0x00, 0x00, 0x00, 0x0A, 0x09, 0xFE };
            //02 06 00 00 00 00 89 F9

            // Send the Modbus message
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(modbusMessage, 0, modbusMessage.Length);
                    MessageBox.Show("Modbus message sent successfully!");
                }
                else
                {
                    MessageBox.Show("Serial port is not open.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send Modbus message: {ex.Message}");
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            qty_ng++;
            rjButton1.Text = qty_ng.ToString();
            // Define the Modbus message
            byte[] modbusMessage = new byte[] { 0x02, 0x06, 0x00, 0x00, 0x00, 0x01, 0x09, 0xFE };
            //02 06 00 00 00 00 89 F9

            // Send the Modbus message
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(modbusMessage, 0, modbusMessage.Length);
                    MessageBox.Show("Modbus message sent successfully!");
                }
                else
                {
                    MessageBox.Show("Serial port is not open.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send Modbus message: {ex.Message}");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int current_qty = Convert.ToInt32(label8.Text)- Convert.ToInt32(rjButton1.Text);
            int qty_rph = Convert.ToInt32(label6.Text);

            timer_toreload++;
            label11.Text = current_qty.ToString();
            Console.WriteLine(timer_toreload);
            if (timer_toreload > 10)
            {
                displayED();
                datagridget();
                timer_toreload = 0;
            }
            if (current_qty > qty_rph)
            {
                // Define the Modbus message -- STOP FBO
                byte[] modbusMessage = new byte[] { 0x02, 0x06, 0x00, 0x00, 0x00, 0x02, 0x09, 0xFE };
                //02 06 00 00 00 00 89 F9

                // Send the Modbus message
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(modbusMessage, 0, modbusMessage.Length);
                        MessageBox.Show("Modbus message sent successfully!");
                    }
                    else
                    {
                      //  MessageBox.Show("Serial port is not open.");
                    }
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show($"Failed to send Modbus message: {ex.Message}");
                }
            }
        }

        private void container_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                container.VerticalScroll.Value = 0;
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (label27.Text != "0")
            {
                int no_urut = Convert.ToInt32(label36.Text);
                int qty_ng = Convert.ToInt32(rjButton1.Text);
                UpdateRowSource_shoot(label4.Text,no_urut, qty_ng);

                label28.Text = "-";
                label27.Text = "0";

                label23.Text = "0";
                label22.Text = "0";

                label24.Text = "0";
                label25.Text = "0";
                label26.Text = "0";

                label5.Text = "-";
                label4.Text = "-";
                label6.Text = "0";
                label36.Text = "0";
            }
            else
                MessageBox.Show("Pilih Pattern Dulu!!");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
