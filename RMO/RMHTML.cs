using System;
using System.Collections.Generic;
using System.Text;

namespace RMO
{
    public class RMHTML
    {
        public static string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        public static decimal GetNumero(string pagina, string inizio, string fine)
        {
            int index1 = pagina.IndexOf(inizio);
            if (index1 >= 0)
            {
                int index2 = pagina.IndexOf(fine, index1);
                int start = index1 + inizio.Length;
                string strval = pagina.Substring(start, index2 - start);
                strval = strval.Replace("cms", "");
                strval = strval.Replace("kgs", "");
                strval = strval.Replace(" ", "");
                strval = strval.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                strval = strval.Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                decimal val = System.Convert.ToDecimal(strval);
                return val;
            }
            return 0;
        }

        public static decimal GetNumero(string pagina, string fine)
        {
            int index2 = pagina.IndexOf(fine);
            string strval = pagina.Substring(0, index2);
            strval = strval.Replace(" ", "");
            strval = strval.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            strval = strval.Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            decimal val = System.Convert.ToDecimal(strval);
            return val;
        }

        public static decimal GetNumero(string pagina, string inizio, string fine, int first)
        {
            int index1 = pagina.IndexOf(inizio, first);
            if (index1 >= 0)
            {
                int index2 = pagina.IndexOf(fine, index1);
                int start = index1 + inizio.Length;
                string strval = pagina.Substring(start, index2 - start);
                strval = strval.Replace(" ", "");
                strval = strval.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                strval = strval.Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                decimal val = System.Convert.ToDecimal(strval);
                return val;
            }
            return 0;
        }

        public static string GetStringa(string pagina, string inizio, string fine)
        {
            int index1 = pagina.IndexOf(inizio);
            if (index1 >= 0)
            {
                int index2 = pagina.IndexOf(fine, index1);
                int start = index1 + inizio.Length;
                string strval = pagina.Substring(start, index2 - start);
                return strval.Trim();
            }
            return "";
        }

        public static string GetDate()
        {
            string data = DateTime.Now.ToString("yyyyMMddHHmmss");
            return data;
        }

        // C:\Documents and Settings\Administrator\Application Data\RMO\RMO\1.0.0.0\xml\1-30-2011 2=27=58 PM.team
        public static DateTime GetDate(string path)
        {
            DateTime result = new DateTime(2000,01,01);
            try
            {
                string file = System.IO.Path.GetFileNameWithoutExtension(path);
                IFormatProvider culture = new System.Globalization.CultureInfo("it-IT", true);
                string[] expectedFormats = { "dd-MM-yyyy HH=mm=ss", "dd-MM-yyyy H=mm=ss", "dd-MM-yyyy H.mm.ss", "dd-MM-yyyy HH.mm.ss", "yyyyMMddHHmmss" };
                result = DateTime.ParseExact(file, expectedFormats, culture, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                return result;
            }
            catch (Exception ex) { }
            My.Box.Errore(string.Format("Manda una mail a faze106@hotmail.com con questo testo:\r\n{0}",path));
            return result;
        }

        public static string GetBody(string html)
        {
            string result = html;
            int index = html.IndexOf("<body>");
            if (index >= 0)
            {
                int length = html.Length;
                result = html.Substring(index, length - index);
            }
            return result;
        }
    }
}
