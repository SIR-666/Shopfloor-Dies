using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class RPH_ASSY : UserControl
    {
        int year, month;
        public bool[] shift1_loading_stats = { false, false, false, false, false, false, false, false };
        public bool[] shift2_loading_stats = { false, false, false, false, false, false, false, false };
        public string DN_QTY,DN_TGL,FGSID;
        string connetionString = "Data Source=192.168.5.4;Initial Catalog=KUJNAGN;User ID=nganjuk;Password=Excited2020";
        SqlConnection cnn;

        public struct value_loading
        {
            public string listnama;
            public int qty;
        }
        public value_loading[] loading_shif1 = new[]
        {
         new value_loading {listnama="",qty=0 },
         new value_loading {listnama="",qty=0 },
         new value_loading {listnama="",qty=0 },
         new value_loading {listnama="",qty=0 },
        };

        public value_loading[] loading_shif2 = new[]
        {
         new value_loading {listnama="",qty=0 },
         new value_loading {listnama="",qty=0 },
         new value_loading {listnama="",qty=0 },
         new value_loading {listnama="",qty=0 },
        };

        public RPH_ASSY()
        {
            InitializeComponent();
        }

        private void RPH_ASSY_Load(object sender, EventArgs e)
        {
            display_dated();
            
        }

        public void load_DN()
        {
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            SqlDataReader dataReader2;
            SqlDataAdapter adapter = new SqlDataAdapter();


            try
            {
                SqlCommand cmd2 = new SqlCommand("exec MPP_DN @fgsid", cnn);
                cmd2.Parameters.AddWithValue("@fgsid", FGSID);
                dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    // Console.WriteLine(dataReader.GetString(0));

                    //hasil = String.Format("{0}", dataReader["jumlah"]);


                    DN_QTY = String.Format("{0}", dataReader2["qty"]);
                    DN_TGL = String.Format("{0}", dataReader2["tgl"]);
                    label20.Text = DN_TGL;
                    label21.Text = DN_QTY;

                    Console.WriteLine(DN_QTY);
                    Console.WriteLine(DN_TGL);
                    //label2.Text = user_name;
                    // Console.WriteLine(String.Format("{0}", dataReader["jumlah"]));
                    //data2txt.Text = dataReader.GetString("jumlah");
                }
            }
            catch { MessageBox.Show("Cant Connect Database"); }



        }

        void display_dated()
        {

            
            DateTime now = DateTime.Now;
            year = now.Year;
            month = now.Month;
            int daynow = now.Day;
            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            labelmonth.Text = DateTime.Now.ToString("MMMM yyyy");
            Console.Write("dayoftheweek : ");
            Console.WriteLine(dayoftheweek);

            for (int i = 1; i < dayoftheweek; i++)
            { 
                UserControlBlank userControlBlank = new UserControlBlank();
                dayconatiner.Controls.Add(userControlBlank);

            }

            for (int i = 1; i < days; i++)
            {
                //UserControlBlank userControlBlank = new UserControlBlank();
                ucDays ucDays = new ucDays(this);
                ucDays.day_show(i);
                dayconatiner.Controls.Add(ucDays);

                if (daynow == i)
                { 
                    
                }
                Console.WriteLine(i);
            }

        }

        void next_month()
        {

            dayconatiner.Controls.Clear();
            DateTime now = DateTime.Now;
            //year = now.Year;
            month++;
            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labelmonth.Text = monthname + " " + year;
            Console.Write("dayoftheweek : ");
            Console.WriteLine(dayoftheweek);

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank userControlBlank = new UserControlBlank();
                dayconatiner.Controls.Add(userControlBlank);

            }

            for (int i = 1; i < days; i++)
            {
                //UserControlBlank userControlBlank = new UserControlBlank();
                ucDays ucDays = new ucDays(this);
                ucDays.day_show(i);

               

                dayconatiner.Controls.Add(ucDays);
                Console.WriteLine(i);
            }

        }

        void back_month()
        {

            dayconatiner.Controls.Clear();
            DateTime now = DateTime.Now;
            //year = now.Year;
            month--;
            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labelmonth.Text = monthname + " " + year;
            Console.Write("dayoftheweek : ");
            Console.WriteLine(dayoftheweek);

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank userControlBlank = new UserControlBlank();
                dayconatiner.Controls.Add(userControlBlank);

            }

            for (int i = 1; i < days; i++)
            {
                //UserControlBlank userControlBlank = new UserControlBlank();
                ucDays ucDays = new ucDays(this);
                ucDays.day_show(i);
                dayconatiner.Controls.Add(ucDays);
                Console.WriteLine(i);
            }

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            back_month();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            next_month();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
