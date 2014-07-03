using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace My
{
    public class Dir
    {
        public static string Documenti
        { get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); } }

        public static string Desktop
        { get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop); } }

        public static bool Svuota(string start)
        {
            bool result = true;
            string[] files, dirs; files = dirs = new string[0];
            try
            {
                files = System.IO.Directory.GetFiles(start);
                dirs = System.IO.Directory.GetDirectories(start);
            }
            catch { result = false; }
            for (int i = 0; i < files.Length; i++)
            {
                try { System.IO.File.Delete(files[i]); }
                catch { result = false; }
            }
            for (int j = 0; j < dirs.Length; j++)
            {
                My.Dir.Svuota(dirs[j]);
                try { System.IO.Directory.Delete(dirs[j]); }
                catch { result = false; }
            }
            return result;
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetDiskFreeSpaceEx(
        string lpDirectoryName,
        out UInt64 lpFreeBytesAvailable,
        out UInt64 lpTotalNumberOfBytes,
        out UInt64 lpTotalNumberOfFreeBytes);
        public static long FreeSpace2(string dir)
        {
            try
            {
                ulong freeBytesAvailable = 0;
                ulong totalNumberOfBytes = 0;
                ulong totalNumberOfFreeBytes = 0;

                GetDiskFreeSpaceEx(
                   dir,
                   out freeBytesAvailable,
                   out totalNumberOfBytes,
                   out totalNumberOfFreeBytes);

                return System.Convert.ToInt64(freeBytesAvailable);
            }
            catch { }
            return 0;
        }

        public static long OccupedSpace2(string dir)
        {
            try
            {
                ulong freeBytesAvailable = 0;
                ulong totalNumberOfBytes = 0;
                ulong totalNumberOfFreeBytes = 0;

                GetDiskFreeSpaceEx(
                   dir,
                   out freeBytesAvailable,
                   out totalNumberOfBytes,
                   out totalNumberOfFreeBytes);

                return System.Convert.ToInt64(totalNumberOfBytes - freeBytesAvailable);
            }
            catch { }
            return 0;
        }

        public static int FreeSpacePercent(string dir)
        {
            try
            {
                ulong freeBytesAvailable = 0;
                ulong totalNumberOfBytes = 0;
                ulong totalNumberOfFreeBytes = 0;

                GetDiskFreeSpaceEx(
                   dir,
                   out freeBytesAvailable,
                   out totalNumberOfBytes,
                   out totalNumberOfFreeBytes);
                double T = totalNumberOfBytes / 1024;
                double F = totalNumberOfFreeBytes / 1024;
                double result = (F / T) * 100;
                return System.Convert.ToInt32(result);
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// Anche nelle sottodirectory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static System.Collections.ArrayList GetFiles(string path, string pattern)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            try
            {
                list.AddRange(System.IO.Directory.GetFiles(path, pattern));
            }
            catch { }

            string[] dirs = null;
            try
            {
                dirs = System.IO.Directory.GetDirectories(path);
            }
            catch { }

            if (dirs != null)
            {
                foreach (string dir in dirs)
                {
                    list.AddRange(GetFiles(dir, pattern));
                }
            }
            return list;
        }

        /// <summary>
        /// Anche nelle sottodirectory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static System.Collections.ArrayList GetFiles(string path)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            try
            {
                list.AddRange(System.IO.Directory.GetFiles(path));
            }
            catch { }

            string[] dirs = null;
            try
            {
                dirs = System.IO.Directory.GetDirectories(path);
            }
            catch { }

            if (dirs != null)
            {
                foreach (string dir in dirs)
                {
                    list.AddRange(GetFiles(dir));
                }
            }
            return list;
        }

        public static string GetNumberSize(long Bytes)
        {
            if (Bytes >= 1073741824)
            {
                Decimal size = Decimal.Divide(Bytes, 1073741824);
                return String.Format("{0:##.##} GB", size);
            }
            else if (Bytes >= 1048576)
            {
                Decimal size = Decimal.Divide(Bytes, 1048576);
                return String.Format("{0:##.##} MB", size);
            }
            else if (Bytes >= 1024)
            {
                Decimal size = Decimal.Divide(Bytes, 1024);
                return String.Format("{0:##.##} KB", size);
            }
            else if (Bytes > 0 & Bytes < 1024)
            {
                Decimal size = Bytes;
                return String.Format("{0:##.##} Bytes", size);
            }
            else
            {
                return "0 Bytes";
            }
        }

        public static string GetNumberGarante(long Bytes,int g)
        {
            try
            {
                Decimal size = Decimal.Divide(Bytes, (126220000*g));
                TimeSpan tempo = TimeSpan.FromHours((double)size);
                return tempo.Days.ToString() + "G " + tempo.Hours.ToString("00") + ":" + 
                    tempo.Minutes.ToString("00") + ":" + tempo.Seconds.ToString("00");
            }
            catch { return "0"; }
        }
    }
}
