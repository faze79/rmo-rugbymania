using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;

namespace My
{
    public class Convert
    {
        public static string ColorToString(System.Drawing.Color c)
        {
            string result = "";
            result += c.A + ";" + c.R + ";" + c.G + ";" + c.B + ";";
            return result;
        }

        public static System.Drawing.Color ColorFromString(string source)
        {
            string[] c = source.Split(';');
            if (c.Length > 3)
            {
                int a = System.Convert.ToInt32(c[0]);
                int r = System.Convert.ToInt32(c[1]);
                int g = System.Convert.ToInt32(c[2]);
                int b = System.Convert.ToInt32(c[3]);
                return Color.FromArgb(a, r, g, b);
            }
            return Color.Black;
        }

        public static Rectangle ToRectangle(RectangleF r)
        {
            return new Rectangle(ToInt32(r.X),ToInt32(r.Y),ToInt32(r.Width),ToInt32(r.Height));
        }

        public static int ToInt32(float f)
        {
            return System.Convert.ToInt32(f);
        }

        public static System.Drawing.Font ToFont(string font)
        {
            string name = GetString(font, "Name=", ",");
            int isize = 18;
            string size = GetString(font, "Size=", ",");
            if (name == "") name = "Verdana";
            try { isize = System.Convert.ToInt32(size); } catch { isize = 18; }
            return new Font(name, isize, FontStyle.Regular);
        }

        public static System.Drawing.FontStyle ToFontStyle(string fs)
        {
            FontStyle result = FontStyle.Regular;
            if (fs.IndexOf("Italic") >= 0) result = result | FontStyle.Italic;
            if (fs.IndexOf("Bold") >= 0) result = result | FontStyle.Bold;
            if (fs.IndexOf("Stikeout") >= 0) result = result | FontStyle.Strikeout;
            if (fs.IndexOf("Underline") >= 0) result = result | FontStyle.Underline;
            return result;
        }

        public static string GetString(string source, string start, string end)
        {
            string result = "";
            int istart = source.IndexOf(start);
            if (istart >= 0)
            {
                istart = istart + start.Length;
                int iend = source.IndexOf(end, istart);
                if (iend > istart) result = source.Substring(istart, iend - istart);
            }
            return result;
        }

        public static string GetNumString(string num)
        {
            string result = "";
            bool first = true;
            num = num.Trim();
            foreach (char c in num)
            {
                switch (c)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9': result += c; break;
                    case ',':
                    case '.': 
                        if (first) 
                        { 
                            result += System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator; 
                            first = false; 
                        } break;
                    default: break;
                }
            }
            return result;
        }

        public static decimal ToDecimal(string valore)
        {
            string virgola = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (virgola == "") virgola = ".";
            string val = valore.Replace(".", virgola);
            val = val.Replace(",", virgola);
            decimal dval = (decimal)System.Convert.ToDecimal(val);
            return dval;
        }
    }
}
