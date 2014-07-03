using System;
using System.Runtime.InteropServices;

namespace My
{
    class File
    {
        public static string GetValidName(string input)
        {
            string result = input;
            //result = result.Replace(":","");
            return result;
        }

        public static bool Exist(string file)
        {
            return System.IO.File.Exists(file);
        }

        public static void Append(string file, string line)
        {
            System.IO.File.AppendAllText(file, line);
        }

        public static void Delete(string file)
        {
            try { System.IO.File.Delete(file); }
            catch { }
        }

        public static long Size(string file)
        {
            long result = 0;
            if (System.IO.File.Exists(file))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                result = fi.Length;
            }
            return result;
        }

        /// <summary>
        /// Calcola il nome di un file temporaneo in una directory temporanea
        /// </summary>
        /// <param name="extension">Estendione desiderate per un file (esempio: .avi)</param>
        /// <returns>Restituisce il nome del file</returns>
        public static string GetTempFile(string extension)
        {
            string dir = System.IO.Path.GetTempPath();
            string file = "temp_";
            return My.File.GetFileNumber(dir, file, extension);
        }

        /// <summary>
        /// Calcola un eventuale numero da associare al nome del file da creare
        /// </summary>
        /// <param name="dir">Directory contenente il nuovo file</param>
        /// <param name="name">Nome del file</param>
        /// <param name="extension">Estensione del file (esempio: .avi)</param>
        /// <returns>Restituisce il nome del file calcolato</returns>
        public static string GetFileNumber(string dir, string name, string extension)
        {
            int counter = 0;
            if (dir.LastIndexOf("\\") != (dir.Length - 1)) dir += "\\";
            string result = dir + name + extension;
            while (System.IO.File.Exists(result))
            {   // Se il file esiste allora è necessario calcolare un nuovo nome
                counter++;
                result = dir + name + counter.ToString() + extension;
            }
            return result;
        }

        public static string GetFileNumber2(string dir, string name, string extension)
        {
            int counter = 0;
            if (dir.LastIndexOf("\\") != (dir.Length - 1)) dir += "\\";
            string result = dir + name + counter.ToString() + extension;
            while (System.IO.File.Exists(result))
            {   // Se il file esiste allora è necessario calcolare un nuovo nome
                counter++;
                result = dir + name + counter.ToString() + extension;
            }
            return result;
        }

        public static string GetDirectoryNumber(string dir, string name)
        {
            int counter = 0;
            if (dir.LastIndexOf("\\") != (dir.Length - 1)) dir += "\\";
            string result = dir + name;
            while (System.IO.Directory.Exists(result))
            {   // Se il file esiste allora è necessario calcolare un nuovo nome
                counter++;
                result = dir + name + counter.ToString();
            }
            return result;
        }

        public static string GetHumanSize(long Bytes)
        {
            if (Bytes >= 1073741824)
            {
                Decimal size = Decimal.Divide(Bytes, 1073741824);
                return System.String.Format("{0:##.##} GB", size);
            }
            else if (Bytes >= 1048576)
            {
                Decimal size = Decimal.Divide(Bytes, 1048576);
                return System.String.Format("{0:##.##} MB", size);
            }
            else if (Bytes >= 1024)
            {
                Decimal size = Decimal.Divide(Bytes, 1024);
                return System.String.Format("{0:##.##} KB", size);
            }
            else if (Bytes > 0 & Bytes < 1024)
            {
                Decimal size = Bytes;
                return System.String.Format("{0:##.##} Bytes", size);
            }
            else
            {
                return "0 Bytes";
            }
        } 

        public static string GetFreeName(string file)
        {
            string dir = System.IO.Path.GetDirectoryName(file);
            string name = System.IO.Path.GetFileNameWithoutExtension(file);
            string ext = System.IO.Path.GetExtension(file);
            string newfilename = dir + "\\" + System.IO.Path.GetFileName(file);
            int counter = 1;
            while (My.File.Exist(newfilename))
            {
                newfilename = dir + "\\" + name + counter + ext;
                counter++;
            }
            return newfilename;
        }

        /// <summary>
        /// Indica se il percorso al file è valido o meno dal punto di vista sintattico
        /// </summary>
        /// <param name="path">Percorso al file</param>
        /// <returns>True se valido, False altrimenti</returns>
        public static bool IsValidPath(string path)
        {
            return (path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1);
        }

        /// <summary>
        /// Indica se il nome di un file è valido o meno
        /// </summary>
        /// <param name="file">Nome del file</param>
        /// <returns>True se valido, False altrimenti</returns>
        public static bool IsValidFile(string file)
        {
            return (file.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1);
        }

        /// <summary>
        /// Restituisce un nome file valido, da un nome qualsiasi
        /// </summary>
        /// <param name="file">Nome del file</param>
        /// <param name="invalid_char">Caratteri da inserire al posto dei caratteri non validi</param>
        /// <returns>Nome di file valido</returns>
        public static string GetValidFile(string file, char invalid_char)
        {
            string result = file;
            char[] caratteri = System.IO.Path.GetInvalidFileNameChars();
            foreach (char carattere in caratteri)
            {
                if (result.IndexOf(carattere) != -1) result = result.Replace(carattere, invalid_char);
            }
            return result;
        }
    }
}
