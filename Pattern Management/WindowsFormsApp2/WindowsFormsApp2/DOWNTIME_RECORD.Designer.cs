namespace WindowsFormsApp2
{
    partial class DOWNTIME_RECORD
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rjButton2 = new WindowsFormsApp2.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rjButton1 = new WindowsFormsApp2.RJControls.RJButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode_Mesin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenis_Downtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jam_Mulai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jam_Selesai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail_Downtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1241, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.73333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.6F));
            this.tableLayoutPanel2.Controls.Add(this.rjButton2, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.rjButton1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1235, 58);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rjButton2
            // 
            this.rjButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rjButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 20;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(869, 15);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(150, 40);
            this.rjButton2.TabIndex = 5;
            this.rjButton2.Text = "Export";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shift";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "All"});
            this.comboBox1.Location = new System.Drawing.Point(429, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(626, 15);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(150, 40);
            this.rjButton1.TabIndex = 4;
            this.rjButton1.Text = "Load";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(68, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(290, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.Shift,
            this.Kode_Mesin,
            this.Jenis_Downtime,
            this.Jam_Mulai,
            this.Jam_Selesai,
            this.Lama,
            this.Detail_Downtime,
            this.Terminal,
            this.Keterangan});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Location = new System.Drawing.Point(3, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1235, 507);
            this.dataGridView1.TabIndex = 1;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "tanggal";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.MinimumWidth = 8;
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.Width = 150;
            // 
            // Shift
            // 
            this.Shift.DataPropertyName = "SIFT";
            this.Shift.HeaderText = "Shift";
            this.Shift.MinimumWidth = 8;
            this.Shift.Name = "Shift";
            this.Shift.Width = 150;
            // 
            // Kode_Mesin
            // 
            this.Kode_Mesin.DataPropertyName = "KodeMesin";
            this.Kode_Mesin.HeaderText = "Kode Mesin";
            this.Kode_Mesin.MinimumWidth = 8;
            this.Kode_Mesin.Name = "Kode_Mesin";
            this.Kode_Mesin.Width = 150;
            // 
            // Jenis_Downtime
            // 
            this.Jenis_Downtime.DataPropertyName = "KETERANGAN1";
            this.Jenis_Downtime.HeaderText = "Jenis Downtime";
            this.Jenis_Downtime.MinimumWidth = 8;
            this.Jenis_Downtime.Name = "Jenis_Downtime";
            this.Jenis_Downtime.Width = 150;
            // 
            // Jam_Mulai
            // 
            this.Jam_Mulai.DataPropertyName = "jammulai";
            this.Jam_Mulai.HeaderText = "Jam Mulai";
            this.Jam_Mulai.MinimumWidth = 8;
            this.Jam_Mulai.Name = "Jam_Mulai";
            this.Jam_Mulai.Width = 150;
            // 
            // Jam_Selesai
            // 
            this.Jam_Selesai.DataPropertyName = "jamselesai";
            this.Jam_Selesai.HeaderText = "Jam_Selesai";
            this.Jam_Selesai.MinimumWidth = 8;
            this.Jam_Selesai.Name = "Jam_Selesai";
            this.Jam_Selesai.Width = 150;
            // 
            // Lama
            // 
            this.Lama.DataPropertyName = "LAMA";
            this.Lama.HeaderText = "Lama";
            this.Lama.MinimumWidth = 8;
            this.Lama.Name = "Lama";
            this.Lama.Width = 150;
            // 
            // Detail_Downtime
            // 
            this.Detail_Downtime.DataPropertyName = "KETERANGAN2";
            this.Detail_Downtime.HeaderText = "Detail Downtime";
            this.Detail_Downtime.MinimumWidth = 8;
            this.Detail_Downtime.Name = "Detail_Downtime";
            this.Detail_Downtime.Width = 150;
            // 
            // Terminal
            // 
            this.Terminal.DataPropertyName = "TERMINAL";
            this.Terminal.HeaderText = "Terminal";
            this.Terminal.MinimumWidth = 8;
            this.Terminal.Name = "Terminal";
            this.Terminal.Width = 150;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "KETERANGAN";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.MinimumWidth = 8;
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.Width = 150;
            // 
            // DOWNTIME_RECORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "DOWNTIME_RECORD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOWNTIME_RECORD";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private RJControls.RJButton rjButton1;
        private RJControls.RJButton rjButton2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shift;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode_Mesin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenis_Downtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jam_Mulai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jam_Selesai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail_Downtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
    }
}