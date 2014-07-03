using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

namespace My.Controls
{
    public partial class MyLabel : System.Windows.Forms.Label
    {
        public MyLabel()
        {
            base.ForeColor = Color.White;
            base.BackColor = Color.Gray;
            base.TextAlign = ContentAlignment.MiddleLeft;
            base.Padding = new Padding(4, 0, 0, 1);
            base.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        }

        #region Gestione del tema del controllo
        private bool _Themed = true;
        private MSType.ThemeStyle _Theme = MSType.ThemeStyle.HomeStead;

        public bool Themed
        {
            get { return _Themed; }
            set 
            { 
                bool newVal = (bool)value;
                if (_Themed != newVal)
                {
                    _Themed = newVal;
                    this.Invalidate();
                }
            }
        }

        public MSType.ThemeStyle Theme
        {
            get { return _Theme; }
            set
            {
                MSType.ThemeStyle newVal = (MSType.ThemeStyle)value;
                if (newVal != _Theme)
                {
                    _Theme = newVal;
                    switch (_Theme)
                    {
                        case MSType.ThemeStyle.HomeStead:
                            this._ColorStart = Color.FromArgb(255, 252, 235);
                            this._ColorEnd = Color.FromArgb(139, 158, 89);
                            this.Themed = true;
                            break;
                        case MSType.ThemeStyle.Metallic:
                            this._ColorStart = Color.FromArgb(162, 161, 161);
                            this._ColorEnd = Color.FromArgb(255, 255, 255);
                            this.Themed = true;
                            break;
                        case MSType.ThemeStyle.NormalColor:
                            this._ColorStart = Color.FromArgb(216, 228, 248);
                            this._ColorEnd = Color.FromArgb(122, 150, 223);
                            this.Themed = true;
                            break;
                        case MSType.ThemeStyle.Unthemed:
                            this.Themed = false;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Gestione del gradiente del controllo
        private Color _ColorStart = Color.FromArgb(90, 135, 215);
        private Color _ColorEnd = Color.FromArgb(3,55,145);
        private LinearGradientMode _Gradient = LinearGradientMode.Vertical;

        public LinearGradientMode Gradient
        {
            get { return _Gradient; }
            set { _Gradient = (LinearGradientMode)value; }
        }

        public Color ColorStart
        {
            get { return _ColorStart; }
            set { _ColorStart = (Color)value; if (_Themed) this.Invalidate(); }
        }

        public Color ColorEnd
        {
            get { return _ColorEnd; }
            set { _ColorEnd = (Color)value; if (_Themed) this.Invalidate(); }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if ((Themed)&&(Width>0)&&(Height>0))
            {
                LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, _ColorStart, _ColorEnd, _Gradient);
                pevent.Graphics.FillRectangle(brush,this.ClientRectangle);
            }
            else base.OnPaintBackground(pevent);
        }
        #endregion
    }
}
