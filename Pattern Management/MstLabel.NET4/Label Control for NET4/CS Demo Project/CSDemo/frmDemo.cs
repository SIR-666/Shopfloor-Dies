using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using BaiqiSoft.LabelControl;


namespace Demo
{
    public partial class frmDemo : Form
    {
        DataTable m_DataTable;

        public frmDemo()
        {
            InitializeComponent();
        }

        private void frmDemo_Load(object sender, EventArgs e)
        {
            //Enter your license key here
            LabelDesigner1.LicenseKey = "";
            //
            //LabelDesigner1.LanguageConfig = Application.StartupPath + "\\Language.ini";
            //
            ToolStripMenuItem mnuHelp = new ToolStripMenuItem("&Help");
            LabelDesigner1.MenuStrip.Items.Add(mnuHelp);
            ToolStripMenuItem mnuHomePage = new ToolStripMenuItem("Home Page", null, new EventHandler(mnuHomePage_Click));
            mnuHelp.DropDownItems.Add(mnuHomePage);
            ToolStripSeparator mnuS1 = new ToolStripSeparator();
            mnuHelp.DropDownItems.Add(mnuS1);
            ToolStripMenuItem mnuAbout = new ToolStripMenuItem("About...", null, new EventHandler(mnuAbout_Click));
            mnuHelp.DropDownItems.Add(mnuAbout);

            CreateDataTable();

            LabelDesigner1.TableNames.Clear();
            LabelDesigner1.TableNames.Add("Product");
            LabelDesigner1.RefreshPropertiesPanel();

            //LabelDesigner1.MenuItems.NewLabel.Visible = false;
            //LabelDesigner1.ToolbarButtons.NewLabel.Visible = false;

            cboScrollbars.SelectedIndex = (int)LabelDesigner1.ScrollBars;

            frmDemo_Resize(this, EventArgs.Empty);
        }

        private void mnuHomePage_Click(System.Object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mysofttool.com");
        }

        private void mnuAbout_Click(System.Object sender, System.EventArgs e)
        {
            LabelDesigner1.AboutBox();
        }

        private void CreateDataTable()
        {
            if (m_DataTable != null)
                return;
            m_DataTable = new DataTable();
            //Columns
            m_DataTable.Columns.Add("ProductName", typeof(string));
            m_DataTable.Columns.Add("Barcode", typeof(string));
            m_DataTable.Columns.Add("Price", typeof(float));
            m_DataTable.Columns.Add("LabelNumber", typeof(int));
            //Rows
            m_DataTable.Rows.Add("Mishi Kobe Niku", "845723054943", 96.0, 2);
            m_DataTable.Rows.Add("Carnarvon Tigers", "246321456231", 61.5, 1);
            m_DataTable.Rows.Add("Ipoh Coffee", "589412354786", 46.0, 3);
            m_DataTable.Rows.Add("Aniseed Syrup", "457125463254", 10.0, 1);
            m_DataTable.Rows.Add("Teatime Chocolate Biscuits", "232145674321", 9.2, 5);
        }

        private void frmDemo_Resize(object sender, EventArgs e)
        {
            grpOptions.Left = ClientSize.Width - 8 - grpOptions.Width;
            LabelDesigner1.Width = grpOptions.Left - 8;
            LabelDesigner1.Height = ClientSize.Height;
        }

        private void LabelDesigner1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            if (e.Button == Buttons.Exit)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void LabelDesigner1_PictureLibraryInitializing(object sender, PictureLibraryInitializingEventArgs e)
        {
            string sPath = Application.StartupPath + "\\Clipart";
            string[] fileList = null;
            try
            {
                fileList = Directory.GetFiles(sPath);
            }
            catch (Exception ex)
            {
                return;
            }
            foreach (string filename in fileList)
            {
                e.AddImage(Path.GetFileNameWithoutExtension(filename), filename);
            }
        }

        private void LabelDesigner1_SelectedTableChanged(object sender, EventArgs e)
        {
            switch (LabelDesigner1.Label.DataTable)
            {
                case "Product":
                    LabelDesigner1.DataSource = m_DataTable;
                    LabelDesigner1.ColumnNames.Clear();
                    LabelDesigner1.ColumnNames.Add("ProductName");
                    LabelDesigner1.ColumnNames.Add("Barcode");
                    LabelDesigner1.ColumnNames.Add("Price");
                    LabelDesigner1.ColumnNames.Add("LabelNumber");
                    break;
                default:
                    LabelDesigner1.DataSource = null;
                    LabelDesigner1.ColumnNames.Clear();
                    break;
            }
        }

        private void chkShowMenuStrip_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowMenuStrip = chkShowMenuStrip.Checked;
        }

        private void chkShowStandardToolStrip_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowStandardToolStrip = chkShowStandardToolStrip.Checked;
        }

        private void chkShowFormattingToolStrip_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowFormattingToolStrip = chkShowFormattingToolStrip.Checked;
        }

        private void chkShowToolbox_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowToolbox = chkShowToolbox.Checked;
        }

        private void chkShowRightPanel_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowRightPanel = chkShowRightPanel.Checked;
        }

        private void chkShowStatusStrip_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowStatusStrip = chkShowStatusStrip.Checked;
        }

        private void chkShowRuler_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ShowRuler = chkShowRuler.Checked;
        }

        private void chkReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ReadOnly = chkReadOnly.Checked;
        }

        private void cboScrollbars_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelDesigner1.ScrollBars = (ScrollBars)cboScrollbars.SelectedIndex;
        }

        private void btnBackgroundPrinting_Click(object sender, EventArgs e)
        {
            //Unlike LabelDesigner class, the LabelPrinting class does not have a user interface.
            //It will greatly improves performance when you only need to print in the background on the production machine.

            LabelPrinting newLabel = new LabelPrinting(true);
            newLabel.LicenseKey = "";

            newLabel.BeginUpdate();

            //Label properties
            newLabel.Label.Width = 80;    //default unit is mm
            newLabel.Label.Height = 50;   //mm

            //Page setup
            newLabel.PageSetup.PaperSize.RawKind = (int)PaperKind.Custom;
            newLabel.PageSetup.PaperWidth = 80;    //default unit is mm
            newLabel.PageSetup.PaperHeight = 50;   //mm

            //Add objects
            Text text = new Text();
            text.Location = new PointF(22, 10.5f);
            text.Size = new SizeF(36, 7.7f);
            text.DataType = DataType.DataTable;
            text.DataColumn = "ProductName";
            newLabel.Items.Add(text);

            Barcode barcode = new Barcode();
            barcode.Location = new PointF(14, 25.1f);
            barcode.Size = new SizeF(52.1f, 16.4f);
            barcode.DataType = DataType.DataTable;
            barcode.DataColumn = "Barcode";
            newLabel.Items.Add(barcode);

            newLabel.EndUpdate();

            newLabel.DataSource = m_DataTable;
            newLabel.PrintOptions.Quantity = QuantityOptions.AllRecords;

            newLabel.PrintPreview(false);
            //newLabel.PrintOut(false);
        }

        private void btnPrintTemlate_Click(object sender, EventArgs e)
        {
            //Unlike LabelDesigner class, the LabelPrinting class does not have a user interface.
            //It will greatly improves performance when you only need to print in the background on the production machine.

            LabelPrinting theLabel = new LabelPrinting();
            theLabel.LicenseKey = "";

            theLabel.OpenLabel(Application.StartupPath + "\\test.blf");

            theLabel.DataSource = m_DataTable;

            theLabel.PrintOptions.Quantity = QuantityOptions.SelectedRecords;
            theLabel.PrintOptions.RecordsFrom = 1;
            theLabel.PrintOptions.RecordsTo = 5;

            theLabel.PrintPreview(true);
            //theLabel.PrintOut(false);
        }

        private void optMillimeters_CheckedChanged(object sender, EventArgs e)
        {
            if (optMillimeters.Checked)
            {
                LabelDesigner1.MeasurementUnit = MeasurementUnits.Millimeters;
            }
        }

        private void optInches_CheckedChanged(object sender, EventArgs e)
        {
            if (optInches.Checked)
            {
                LabelDesigner1.MeasurementUnit = MeasurementUnits.Inches;
            }
        }
    }
}
