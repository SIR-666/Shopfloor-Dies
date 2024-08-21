using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApp2
{
    internal class CeLearningButtonEdit : Control
    {
        private int radius = 15;
        public TextBox textbox = new TextBox();
        private GraphicsPath shape;
        private GraphicsPath innerReact;
        private Color br;
        private Color _borderColor = Color.Gray;
        private int borderSize = 1;
        private Button btn = new Button();


        public CeLearningButtonEdit()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.textbox.Parent = this;
            base.Controls.Add(this.textbox);
            this.textbox.BorderStyle = BorderStyle.None;
            textbox.Font = this.Font;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Black;
            this.br = Color.White;
            textbox.BackColor = this.br;
            this.Text = null;
            textbox.Font = new Font("Century Gothic", 12f);
            this.Size = new Size(0x87, 0x21);
            this.DoubleBuffered = true;
            textbox.KeyDown += new KeyEventHandler(textbox_Keydown);

            btn.Size = new Size(25,textbox.ClientSize.Height);
            btn.Dock = DockStyle.Right;
            btn.Cursor = Cursors.Default;
            btn.Image = Properties.Resources.find;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            textbox.Controls.Add(btn);
            SendMessage(textbox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width));

        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private EventHandler onbtnClick;

        public event EventHandler btnClick
        {
            add 
            {
                btn.Click += value;
            }
            remove
            { 
                btn.Click -=value;
            }
        }

        protected virtual void OnbtnClick(EventArgs e)
        {
            onbtnClick?.Invoke(btn,e);
        }

        private void textbox_Keydown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                textbox.SelectionStart = 0;
                textbox.SelectionLength = this.Text.Length;
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            textbox.Font = this.Font;
            base.Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            textbox.ForeColor = this.ForeColor;
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.shape = new MyRectangle((float)base.Width, (float)base.Height, (float)this.radius, 0f, 0f).Path;
            this.innerReact = new MyRectangle(base.Width - 0.5f, base.Height - 0.5f, (float)this.radius, 0.5f, 0.5f).Path;
            if (textbox.Height >= (base.Height - 4))
            {
                base.Height = textbox.Height + 4;
            }
            textbox.Location = new Point(this.radius - 5, (base.Height / 2) - (textbox.Font.Height / 2));
            textbox.Width = base.Width - ((int)(this.radius * 1.5));
            e.Graphics.SmoothingMode = ((SmoothingMode)SmoothingMode.HighQuality);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            e.Graphics.DrawPath(Pens.Gray, this.shape);
            using (SolidBrush brush = new SolidBrush(this.br))
            {
                e.Graphics.FillPath((Brush)brush, this.innerReact);
            }
            Trans.MakeTransparent(this, e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            textbox.Text = this.Text;

        }

        public void SelectAll()
        {
            textbox.SelectAll();
        }

        public Color Br
        {
            get =>
                this.br;
            set
            {
                this.br = value;
                if (this.br != Color.Transparent)
                {
                    textbox.BackColor = this.br;
                }
                base.Invalidate();
            }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = Color.Transparent;
        }

        public Image btnImage
        {
            get =>
                btn.Image;
            set 
            {
                btn.Image = value;
                btn.Invalidate();
            }
        }

    }
}
