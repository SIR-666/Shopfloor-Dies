using BaiqiSoft.LabelControl;


namespace Demo
{
    partial class frmDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LabelDesigner1 = new BaiqiSoft.LabelControl.LabelDesigner();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.btnPrintTemlate = new System.Windows.Forms.Button();
            this.btnBackgroundPrinting = new System.Windows.Forms.Button();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.lblScrollbars = new System.Windows.Forms.Label();
            this.cboScrollbars = new System.Windows.Forms.ComboBox();
            this.chkShowRuler = new System.Windows.Forms.CheckBox();
            this.chkShowStatusStrip = new System.Windows.Forms.CheckBox();
            this.chkShowRightPanel = new System.Windows.Forms.CheckBox();
            this.chkShowFormattingToolStrip = new System.Windows.Forms.CheckBox();
            this.chkShowToolbox = new System.Windows.Forms.CheckBox();
            this.chkShowStandardToolStrip = new System.Windows.Forms.CheckBox();
            this.chkShowMenuStrip = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optMillimeters = new System.Windows.Forms.RadioButton();
            this.optInches = new System.Windows.Forms.RadioButton();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelDesigner1
            // 
            this.LabelDesigner1.Location = new System.Drawing.Point(0, 0);
            this.LabelDesigner1.Name = "LabelDesigner1";
            this.LabelDesigner1.Size = new System.Drawing.Size(865, 554);
            this.LabelDesigner1.TabIndex = 0;
            this.LabelDesigner1.SelectedTableChanged += new System.EventHandler(this.LabelDesigner1_SelectedTableChanged);
            this.LabelDesigner1.PictureLibraryInitializing += new BaiqiSoft.LabelControl.PictureLibraryInitializingEventHandler(this.LabelDesigner1_PictureLibraryInitializing);
            this.LabelDesigner1.ButtonClick += new BaiqiSoft.LabelControl.ButtonClickEventHandler(this.LabelDesigner1_ButtonClick);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.optInches);
            this.grpOptions.Controls.Add(this.optMillimeters);
            this.grpOptions.Controls.Add(this.label1);
            this.grpOptions.Controls.Add(this.btnPrintTemlate);
            this.grpOptions.Controls.Add(this.btnBackgroundPrinting);
            this.grpOptions.Controls.Add(this.chkReadOnly);
            this.grpOptions.Controls.Add(this.lblScrollbars);
            this.grpOptions.Controls.Add(this.cboScrollbars);
            this.grpOptions.Controls.Add(this.chkShowRuler);
            this.grpOptions.Controls.Add(this.chkShowStatusStrip);
            this.grpOptions.Controls.Add(this.chkShowRightPanel);
            this.grpOptions.Controls.Add(this.chkShowFormattingToolStrip);
            this.grpOptions.Controls.Add(this.chkShowToolbox);
            this.grpOptions.Controls.Add(this.chkShowStandardToolStrip);
            this.grpOptions.Controls.Add(this.chkShowMenuStrip);
            this.grpOptions.Location = new System.Drawing.Point(871, 11);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(179, 461);
            this.grpOptions.TabIndex = 13;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // btnPrintTemlate
            // 
            this.btnPrintTemlate.Location = new System.Drawing.Point(16, 403);
            this.btnPrintTemlate.Name = "btnPrintTemlate";
            this.btnPrintTemlate.Size = new System.Drawing.Size(127, 26);
            this.btnPrintTemlate.TabIndex = 15;
            this.btnPrintTemlate.Text = "Print Template";
            this.btnPrintTemlate.UseVisualStyleBackColor = true;
            this.btnPrintTemlate.Click += new System.EventHandler(this.btnPrintTemlate_Click);
            // 
            // btnBackgroundPrinting
            // 
            this.btnBackgroundPrinting.Location = new System.Drawing.Point(16, 360);
            this.btnBackgroundPrinting.Name = "btnBackgroundPrinting";
            this.btnBackgroundPrinting.Size = new System.Drawing.Size(127, 26);
            this.btnBackgroundPrinting.TabIndex = 13;
            this.btnBackgroundPrinting.Text = "Background printing";
            this.btnBackgroundPrinting.UseVisualStyleBackColor = true;
            this.btnBackgroundPrinting.Click += new System.EventHandler(this.btnBackgroundPrinting_Click);
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.AutoSize = true;
            this.chkReadOnly.Location = new System.Drawing.Point(19, 185);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(72, 16);
            this.chkReadOnly.TabIndex = 12;
            this.chkReadOnly.Text = "ReadOnly";
            this.chkReadOnly.UseVisualStyleBackColor = true;
            this.chkReadOnly.CheckedChanged += new System.EventHandler(this.chkReadOnly_CheckedChanged);
            // 
            // lblScrollbars
            // 
            this.lblScrollbars.AutoSize = true;
            this.lblScrollbars.Location = new System.Drawing.Point(16, 217);
            this.lblScrollbars.Name = "lblScrollbars";
            this.lblScrollbars.Size = new System.Drawing.Size(101, 12);
            this.lblScrollbars.TabIndex = 7;
            this.lblScrollbars.Text = "Show Scrollbars:";
            // 
            // cboScrollbars
            // 
            this.cboScrollbars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScrollbars.FormattingEnabled = true;
            this.cboScrollbars.Items.AddRange(new object[] {
            "None",
            "Horizontal",
            "Vertical",
            "Both"});
            this.cboScrollbars.Location = new System.Drawing.Point(16, 232);
            this.cboScrollbars.Name = "cboScrollbars";
            this.cboScrollbars.Size = new System.Drawing.Size(127, 20);
            this.cboScrollbars.TabIndex = 11;
            this.cboScrollbars.SelectedIndexChanged += new System.EventHandler(this.cboScrollbars_SelectedIndexChanged);
            // 
            // chkShowRuler
            // 
            this.chkShowRuler.AutoSize = true;
            this.chkShowRuler.Checked = true;
            this.chkShowRuler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowRuler.Location = new System.Drawing.Point(19, 163);
            this.chkShowRuler.Name = "chkShowRuler";
            this.chkShowRuler.Size = new System.Drawing.Size(78, 16);
            this.chkShowRuler.TabIndex = 6;
            this.chkShowRuler.Text = "ShowRuler";
            this.chkShowRuler.UseVisualStyleBackColor = true;
            this.chkShowRuler.CheckedChanged += new System.EventHandler(this.chkShowRuler_CheckedChanged);
            // 
            // chkShowStatusStrip
            // 
            this.chkShowStatusStrip.AutoSize = true;
            this.chkShowStatusStrip.Checked = true;
            this.chkShowStatusStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowStatusStrip.Location = new System.Drawing.Point(19, 142);
            this.chkShowStatusStrip.Name = "chkShowStatusStrip";
            this.chkShowStatusStrip.Size = new System.Drawing.Size(114, 16);
            this.chkShowStatusStrip.TabIndex = 5;
            this.chkShowStatusStrip.Text = "ShowStatusStrip";
            this.chkShowStatusStrip.UseVisualStyleBackColor = true;
            this.chkShowStatusStrip.CheckedChanged += new System.EventHandler(this.chkShowStatusStrip_CheckedChanged);
            // 
            // chkShowRightPanel
            // 
            this.chkShowRightPanel.AutoSize = true;
            this.chkShowRightPanel.Checked = true;
            this.chkShowRightPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowRightPanel.Location = new System.Drawing.Point(19, 121);
            this.chkShowRightPanel.Name = "chkShowRightPanel";
            this.chkShowRightPanel.Size = new System.Drawing.Size(108, 16);
            this.chkShowRightPanel.TabIndex = 4;
            this.chkShowRightPanel.Text = "ShowRightPanel";
            this.chkShowRightPanel.UseVisualStyleBackColor = true;
            this.chkShowRightPanel.CheckedChanged += new System.EventHandler(this.chkShowRightPanel_CheckedChanged);
            // 
            // chkShowFormattingToolStrip
            // 
            this.chkShowFormattingToolStrip.AutoSize = true;
            this.chkShowFormattingToolStrip.Checked = true;
            this.chkShowFormattingToolStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowFormattingToolStrip.Location = new System.Drawing.Point(19, 78);
            this.chkShowFormattingToolStrip.Name = "chkShowFormattingToolStrip";
            this.chkShowFormattingToolStrip.Size = new System.Drawing.Size(162, 16);
            this.chkShowFormattingToolStrip.TabIndex = 3;
            this.chkShowFormattingToolStrip.Text = "ShowFormattingToolStrip";
            this.chkShowFormattingToolStrip.UseVisualStyleBackColor = true;
            this.chkShowFormattingToolStrip.CheckedChanged += new System.EventHandler(this.chkShowFormattingToolStrip_CheckedChanged);
            // 
            // chkShowToolbox
            // 
            this.chkShowToolbox.AutoSize = true;
            this.chkShowToolbox.Checked = true;
            this.chkShowToolbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowToolbox.Location = new System.Drawing.Point(19, 100);
            this.chkShowToolbox.Name = "chkShowToolbox";
            this.chkShowToolbox.Size = new System.Drawing.Size(90, 16);
            this.chkShowToolbox.TabIndex = 2;
            this.chkShowToolbox.Text = "ShowToolbox";
            this.chkShowToolbox.UseVisualStyleBackColor = true;
            this.chkShowToolbox.CheckedChanged += new System.EventHandler(this.chkShowToolbox_CheckedChanged);
            // 
            // chkShowStandardToolStrip
            // 
            this.chkShowStandardToolStrip.AutoSize = true;
            this.chkShowStandardToolStrip.Checked = true;
            this.chkShowStandardToolStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowStandardToolStrip.Location = new System.Drawing.Point(19, 57);
            this.chkShowStandardToolStrip.Name = "chkShowStandardToolStrip";
            this.chkShowStandardToolStrip.Size = new System.Drawing.Size(150, 16);
            this.chkShowStandardToolStrip.TabIndex = 1;
            this.chkShowStandardToolStrip.Text = "ShowStandardToolStrip";
            this.chkShowStandardToolStrip.UseVisualStyleBackColor = true;
            this.chkShowStandardToolStrip.CheckedChanged += new System.EventHandler(this.chkShowStandardToolStrip_CheckedChanged);
            // 
            // chkShowMenuStrip
            // 
            this.chkShowMenuStrip.AutoSize = true;
            this.chkShowMenuStrip.Checked = true;
            this.chkShowMenuStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMenuStrip.Location = new System.Drawing.Point(19, 35);
            this.chkShowMenuStrip.Name = "chkShowMenuStrip";
            this.chkShowMenuStrip.Size = new System.Drawing.Size(102, 16);
            this.chkShowMenuStrip.TabIndex = 0;
            this.chkShowMenuStrip.Text = "ShowMenuStrip";
            this.chkShowMenuStrip.UseVisualStyleBackColor = true;
            this.chkShowMenuStrip.CheckedChanged += new System.EventHandler(this.chkShowMenuStrip_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Measurement Units:";
            // 
            // optMillimeters
            // 
            this.optMillimeters.AutoSize = true;
            this.optMillimeters.Checked = true;
            this.optMillimeters.Location = new System.Drawing.Point(19, 298);
            this.optMillimeters.Name = "optMillimeters";
            this.optMillimeters.Size = new System.Drawing.Size(89, 16);
            this.optMillimeters.TabIndex = 17;
            this.optMillimeters.TabStop = true;
            this.optMillimeters.Text = "Millimeters";
            this.optMillimeters.UseVisualStyleBackColor = true;
            this.optMillimeters.CheckedChanged += new System.EventHandler(this.optMillimeters_CheckedChanged);
            // 
            // optInches
            // 
            this.optInches.AutoSize = true;
            this.optInches.Location = new System.Drawing.Point(19, 320);
            this.optInches.Name = "optInches";
            this.optInches.Size = new System.Drawing.Size(59, 16);
            this.optInches.TabIndex = 18;
            this.optInches.TabStop = true;
            this.optInches.Text = "Inches";
            this.optInches.UseVisualStyleBackColor = true;
            this.optInches.CheckedChanged += new System.EventHandler(this.optInches_CheckedChanged);
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 555);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.LabelDesigner1);
            this.Name = "frmDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MstLabel Control Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDemo_Load);
            this.Resize += new System.EventHandler(this.frmDemo_Resize);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelDesigner LabelDesigner1;
        internal System.Windows.Forms.GroupBox grpOptions;
        internal System.Windows.Forms.Button btnBackgroundPrinting;
        internal System.Windows.Forms.CheckBox chkReadOnly;
        internal System.Windows.Forms.Label lblScrollbars;
        internal System.Windows.Forms.ComboBox cboScrollbars;
        internal System.Windows.Forms.CheckBox chkShowRuler;
        internal System.Windows.Forms.CheckBox chkShowStatusStrip;
        internal System.Windows.Forms.CheckBox chkShowRightPanel;
        internal System.Windows.Forms.CheckBox chkShowFormattingToolStrip;
        internal System.Windows.Forms.CheckBox chkShowToolbox;
        internal System.Windows.Forms.CheckBox chkShowStandardToolStrip;
        internal System.Windows.Forms.CheckBox chkShowMenuStrip;
        internal System.Windows.Forms.Button btnPrintTemlate;
        private System.Windows.Forms.RadioButton optInches;
        private System.Windows.Forms.RadioButton optMillimeters;
        private System.Windows.Forms.Label label1;
    }
}

