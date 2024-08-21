using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ESC_POS_USB_NET.Printer;


namespace WindowsFormsApp2
{
    public partial class THERMAL_PRINT : Form
    {
        private List<Item> items;

        public THERMAL_PRINT()
        {
            InitializeComponent();
            items = new List<Item>();
           // dataGridView1.DataSource = items;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(txtItemName.Text) && !string.IsNullOrEmpty(txtItemPrice.Text) && decimal.TryParse(txtItemPrice.Text, out decimal price))
            {
                items.Add(new Item { Name = txtItemName.Text, Price = price });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = items;
                txtItemName.Clear();
                txtItemPrice.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid item name and price.");
            }
            */
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                Printer printer = new Printer("RONGTA-RPP02");
                printer.AlignCenter();
                printer.Append("Store Name");
                printer.Append("Address Line 1");
                printer.Append("Address Line 2");
              //  printer.Separator();

                foreach (var item in items)
                {
                    printer.Append($"{item.Name}\t\t{item.Price:C}");
                }

                printer.Separator();
                printer.Append($"Total:\t\t = 500");

                // Add barcode
                string barcode = "LOT12345";
                if (!string.IsNullOrEmpty(barcode))
                {
                    printer.Append("Scan the barcode below:");
                    //PrintQRCode(printer, barcode, 5);
                    printer.Code39(barcode);
                }

                printer.Append("Thank you for shopping!");
                printer.NewLine();
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

        /*
        public void PrintQRCode2(string printerName, string qrCodeText)
        {
            // Create printer instance
            Printer printer = new Printer(printerName);

            // Command to set QR code module size (1-16)
            byte moduleSize = 8; // Adjust size here
            byte[] moduleSizeCommand = new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x43, moduleSize };

            // Command to store QR code data
            byte model = 49;
            byte sizeOfQRCodeData = (byte)qrCodeText.Length;
            byte[] storeQRCodeDataCommand = new byte[] { 0x1D, 0x28, 0x6B, (byte)(3 + sizeOfQRCodeData), 0x00, 0x31, 0x50, 0x30 };
            storeQRCodeDataCommand = storeQRCodeDataCommand.Concat(Encoding.ASCII.GetBytes(qrCodeText)).ToArray();

            // Command to print QR code
            byte errorCorrectionLevel = 48;
            byte[] printQRCodeCommand = new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x51, errorCorrectionLevel };

            // Send commands to printer
            printer.Write(moduleSizeCommand);
            printer.Write(storeQRCodeDataCommand);
            printer.Write(printQRCodeCommand);

            // Print and cut
            printer.NewLine();
            printer.NewLine();
            printer.NewLine();
            printer.CutPaper();

            // Print document
            printer.PrintDocument();
        }
        */

        private void PrintQRCode(Printer printer, string qrCodeText, int moduleSize)
        {
            // Command to set QR code module size (1-16)
            byte[] moduleSizeCommand = new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x43, (byte)moduleSize };

            // Command to store QR code data
            byte[] storeQRCodeDataCommand = new byte[] { 0x1D, 0x28, 0x6B, (byte)(3 + qrCodeText.Length + 3), 0x00, 0x31, 0x50, 0x30 };
            byte[] qrCodeData = Encoding.ASCII.GetBytes(qrCodeText);
            storeQRCodeDataCommand = storeQRCodeDataCommand.Concat(qrCodeData).ToArray();

            // Command to print QR code
            byte[] printQRCodeCommand = new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x51, 0x30 };

            // Send commands to printer
            printer.Append(moduleSizeCommand);
            printer.Append(storeQRCodeDataCommand);
            printer.Append(printQRCodeCommand);
        }

    }



    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
