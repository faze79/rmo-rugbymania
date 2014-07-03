using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace My
{
    public class Draw
    {
        public static Bitmap BuildGrid(int len, System.Windows.Forms.Control c)
        {
            return BuildGrid(len, c.Width, c.Height, c.BackColor);
        }

        public static Bitmap BuildGrid(int len, int w, int h, Color b)
        {
            Bitmap map = new System.Drawing.Bitmap(w, h);
            Graphics g = Graphics.FromImage(map);
            if ((len == 0) || (len == 1))
            {
                g.FillRectangle(new SolidBrush(b), 0, 0, w, h);
                g.Dispose();
                return map;
            }
            bool colorLine = true;
            bool colorColumn = true;
            Brush b1 = new SolidBrush(Color.FromArgb(204, 204, 204));
            Brush b2 = new SolidBrush(Color.White);
            for (int y = 0; y < h; )
            {
                colorLine = !colorLine;
                colorColumn = true;
                for (int x = 0; x < w; )
                {
                    if (colorLine == colorColumn) g.FillRectangle(b1, x, y, len, len);
                    else g.FillRectangle(b2, x, y, len, len);
                    colorColumn = !colorColumn;
                    x = x + len;
                }
                y = y + len;
            }
            g.FillRectangle(new SolidBrush(b), 0, 0, w, h);
            g.Dispose();
            return map;
        }

        public static bool Avaiable(Size original, Size item)
        {
            if ((original.Width >= item.Width) && (original.Height >= item.Height)) return true;
            return false;
        }

        static public Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);
            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
            // Clean up
            g.Dispose();
            // Return the bitmap
            return bmp;
        }

        public static RectangleF ArrangeRectangle(Size real, Size clip)
        {
            RectangleF r = new RectangleF(0, 0, 0, 0);
            float fx = (float)clip.Width / real.Width;
            float fy = (float)clip.Height / real.Height;
            if (fx > fy)
            {
                r.Width = real.Width * fy;
                r.Height = clip.Height;
                r.X = (clip.Width - r.Width) / 2;
                r.Y = 0;
            }
            else
            {
                r.Width = clip.Width;
                r.Height = real.Height * fx;
                r.X = 0;
                r.Y = (clip.Height - r.Height) / 2;
            }
            return r;
        }

        public static RectangleF CenterRectangle(Size area, Size item)
        {
            if ((item.Width >= area.Width) || (item.Height >= area.Height)) return ArrangeRectangle(item,area);
            float x = (area.Width - item.Width) / 2;
            float y = (area.Height - item.Height) / 2;
            return new RectangleF(x, y, item.Width, item.Height);
        }

        public static void EnableAntiAlias(Graphics g)
        {
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        }

        public static Bitmap ImageFromText(string strText, Font fnt, Color clrFore, Color clrBack, int border)
        {
            if (strText.Length == 0) strText = " ";
            Bitmap bmpOut = null;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(strText, fnt);
                using (Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height))
                using (Graphics gBmp = Graphics.FromImage(bmp))
                using (SolidBrush brBack = new SolidBrush(Color.FromArgb(100, clrBack.R, clrBack.G, clrBack.B)))
                using (SolidBrush brFore = new SolidBrush(clrFore))
                {
                    EnableAntiAlias(gBmp);
                    gBmp.DrawString(strText, fnt, brBack, 0, 0);
                    bmpOut = new Bitmap(bmp.Width + border, bmp.Height + border);
                    using (Graphics gBmpOut = Graphics.FromImage(bmpOut))
                    {
                        EnableAntiAlias(gBmpOut);
                        for (int x = 0; x <= border; x++) for (int y = 0; y <= border; y++) gBmpOut.DrawImageUnscaled(bmp, x, y);
                        gBmpOut.DrawString(strText, fnt, brFore, border / 2, border / 2);
                    }
                }
            }
            return bmpOut;
        }

    }
}
