using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabWeb : UserControl
    {
        public TabWeb()
        {
            InitializeComponent();
            this.pageMain.Text = "Navigazione Web";
            SetHandler();
        }

        private void SetHandler()
        {
            webBrowser1.AllowNavigation = true;
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            webBrowser1.StatusTextChanged += new EventHandler(webBrowser1_StatusTextChanged);
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            webBrowser1.DocumentTitleChanged += new EventHandler(webBrowser1_DocumentTitleChanged);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //ProcessHTML();
        }

        private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            string title = webBrowser1.DocumentTitle.Replace("Internet Explorer", Application.ProductName);
            //this.pageMain.Text = title;
        }

        private void  webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            long max = e.MaximumProgress;
            long val = e.CurrentProgress;
            if (val < 0) val = 0;
            if (val > max) max = val + 1;
            Internal.Main.StatusBar.Maximum = (int)max;
            Internal.Main.StatusBar.Value = (int)val;
        }

        private void  webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            try
            {
                Internal.Main.StatusString = webBrowser1.StatusText;
            }
            catch (Exception ex) { Internal.Main.StatusString = ""; }
        }

        private void  webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            NAVIGATED = false;
 	        Internal.Main.StatusString = "Connessione in corso...";
        }

        private bool NAVIGATED = false;
        private void  webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            NAVIGATED = true;
            Internal.Main.StatusString = "";
            if (NextURL != "") webBrowser1.Navigate(NextURL);
            webBrowser1.Visible = true;
            NextURL = "";
        }

        public TabPage GetTab()
        {
            return this.pageMain;
        }

        private string NextURL = "";
        public void ShowPlayer(string player_id)
        {
            string postData = string.Format(@"log_id={0}&log_password={1}", Properties.Settings.Default.RM_User, Properties.Settings.Default.RM_Password);
            Encoding enc = System.Text.Encoding.Default;
            byte[] postBuffer = enc.GetBytes(postData);

            // NEW STYLE
            webBrowser1.Navigate(@"http://www.rugbymania.net/play.php", "", postBuffer, "Content-Type: application/x-www-form-urlencoded");
            System.Threading.Thread.Sleep(1000);
            webBrowser1.Navigate("http://www.rugbymania.net/ctrl_account.php", "", postBuffer, "Content-Type: application/x-www-form-urlencoded");
            NextURL = "http://www.rugbymania.net/player.php?id_player="+player_id;
        }

        public void GotToRMUrl(string url)
        {
            string postData = string.Format(@"log_id={0}&log_password={1}", Properties.Settings.Default.RM_User, Properties.Settings.Default.RM_Password);
            Encoding enc = System.Text.Encoding.Default;
            byte[] postBuffer = enc.GetBytes(postData);
            webBrowser1.Navigate(@"http://www.rugbymania.net/play.php", "", postBuffer, "Content-Type: application/x-www-form-urlencoded");
            System.Threading.Thread.Sleep(1000);
            webBrowser1.Navigate(@"http://www.rugbymania.net/ctrl_account.php", "", postBuffer, "Content-Type: application/x-www-form-urlencoded");
            NextURL = url;
        }

        public void GoToURL(string url)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate(url);
        }

        private static string[] HTML_Remove = new string[] { "urchinTracker();",
            "<script type=\"text/javascript\" src=\"/scripts/onglets.js\"></script>", 
            "<script language=\"Javascript\" type=\"text/javascript\" src=\"/support/hesk_javascript.js\">",
            "<script type=\"text/javascript\" src=\"/scripts/sortable.js\"></script>" };
        private static string HTML_Login = @"<input name='log_id' type=text size=12>";
        private static string RMO_Login = @"<input name='log_id' type=text size=12 value='{0}'>";
        private static string HTML_Password = @"<input name='log_password' type=password size=15>";
        private static string RMO_Password = @"<input name='log_password' type=password size=15 value='{0}'>";
        private void ProcessHTML()
        {
            if (!webBrowser1.Visible) return;
            string pagina = webBrowser1.DocumentText;
            if (pagina.Contains(@"</html>"))
            {
                pagina = pagina.Replace(HTML_Login, string.Format(RMO_Login,Properties.Settings.Default.RM_User));
                pagina = pagina.Replace(HTML_Password, string.Format(RMO_Password, Properties.Settings.Default.RM_Password));
                foreach(string r in HTML_Remove) pagina = pagina.Replace(r, "");
                webBrowser1.Document.OpenNew(true);
                webBrowser1.Document.Write(pagina);
            }
            return;
        }
    }
}
