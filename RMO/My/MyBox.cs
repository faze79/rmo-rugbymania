using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace My
{
    public class Box
    {

        public static bool Conferma(string msg)
        {
            if (DialogResult.Yes == MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return true;
            return false;
        }

        public static void Errore(string msg)
        {
            try
            {
                System.IO.StreamWriter SW;
                SW = System.IO.File.AppendText(Application.UserAppDataPath + System.IO.Path.DirectorySeparatorChar + "Error.txt");
                SW.WriteLine(msg);
                SW.Close();
            }
            catch (System.Exception ex)
            {
                System.IO.StreamWriter SW;
                SW = System.IO.File.AppendText("C:\\Error.txt");
                SW.WriteLine(msg);
                SW.WriteLine(ex.Message);
                SW.Close();
            }
            MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string msg)
        {
            try
            {
                System.IO.StreamWriter SW;
                SW = System.IO.File.AppendText(Application.UserAppDataPath + System.IO.Path.DirectorySeparatorChar + "Error.txt");
                SW.WriteLine(msg);
                SW.Close();
            }
            catch (System.Exception ex)
            {
                System.IO.StreamWriter SW;
                SW = System.IO.File.AppendText("C:\\Error.txt");
                SW.WriteLine(msg);
                SW.WriteLine(ex.Message);
                SW.Close();
            }
            MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string msg)
        {
            try
            {
                System.IO.StreamWriter SW;
                SW = System.IO.File.AppendText(Application.UserAppDataPath + System.IO.Path.DirectorySeparatorChar + "Error.txt");
                SW.WriteLine(msg);
                SW.Close();
            }
            catch (System.Exception ex)
            {
                System.IO.StreamWriter SW;
                SW = System.IO.File.AppendText("C:\\Error.txt");
                SW.WriteLine(msg);
                SW.WriteLine(ex.Message);
                SW.Close();
            }
            MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string OpenImageFile()
        {
            string result = "";
            OpenFileDialog d = new OpenFileDialog();
            d.CheckFileExists = true;
            d.CheckPathExists = true;
            d.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            d.Multiselect = false;
            d.Title = "Seleziona l'immagine da aprire";
            d.Filter = "Tutte le immagini (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|Tutti i file (*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK) result = d.FileName;
            d.Dispose();
            return result;
        }

        public static string SaveFile(string start, string title, string filter, string extension, string file)
        {
            string result = "";
            SaveFileDialog d = new SaveFileDialog();
            d.AddExtension = true; d.CheckPathExists = true;
            d.DefaultExt = extension; d.FileName = file;
            d.Filter = filter; d.InitialDirectory = start;
            d.OverwritePrompt = true; d.Title = title;
            if (d.ShowDialog() == DialogResult.OK) result = d.FileName;
            return result;
        }

        public static string GetFolder(string title)
        {
            string result = "";
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.Description = title;
            d.ShowNewFolderButton = true;
            if (d.ShowDialog() == DialogResult.OK) result = d.SelectedPath;
            d.Dispose(); d = null;
            return result;
        }

        /// <summary>
        /// Function used to fade out a form using a user defined number
        /// of steps
        /// </summary>
        /// <param name="f">The Windows form to fade out</param>
        /// <param name="NumberOfSteps">The number of steps used to fade the
        /// form</param>
        public static void FadeForm(System.Windows.Forms.Form f, byte NumberOfSteps)
        {
            DateTime start = DateTime.Now;
            float StepVal = (float)(100f / NumberOfSteps);
            float fOpacity = 100f;
            for (byte b = 0; b < NumberOfSteps; b++)
            {
                f.Opacity = fOpacity / 100;
                f.Refresh();
                fOpacity -= StepVal;
                if ((DateTime.Now - start) > TimeSpan.FromMilliseconds(800))
                {
                    f.Opacity = 0;
                    b = NumberOfSteps;
                }
            }
        }

        public static void SetFade(System.Windows.Forms.Form f)
        {
            f.FormClosing += new FormClosingEventHandler(f_FormClosing);
        }

        private static void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            FadeForm((Form)sender, 50);
        }
    }
}
