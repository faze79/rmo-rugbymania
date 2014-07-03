using System;
using System.Collections.Generic;
using System.Text;

using System.Security;
using System.Security.Cryptography;

namespace My
{
    public class MD5
    {
        public static string LastError = "";
        public static string MD5FromFile(string fileName)
        {
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            if (!System.IO.File.Exists(fileName)) return "";
            try
            {
                string result = "";
                System.IO.Stream stream = System.IO.File.Open(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                result = ByteToString(md5.ComputeHash(stream));
                stream.Close();
                return result;
            }
            catch (Exception ex) { LastError = "MyMD5::MD5FromFile()\r\n"+ex.Message; return ""; }
        }

        public static string MD5FromString(string text)
        {
            string result = "";
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            System.IO.MemoryStream stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(text));
            result = ByteToString(md5.ComputeHash(stream));
            stream.Close();
            return result;
        }

        private static string ByteToString(byte[] input)
        {
            string result = "";
            foreach (byte b in input) result += b.ToString("x2");
            return result;
        }
    }
}
