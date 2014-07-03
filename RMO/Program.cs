using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RMO
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if(!DEBUG)
            try
            {
#endif
                System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
#if(!DEBUG)
            }
            catch (Exception ex) { My.Box.Errore("Main()\r\n"+ex.Message); }
#endif
        }
    }
}