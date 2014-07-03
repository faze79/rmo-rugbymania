using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabEvents: UserControl
    {
        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        public TabEvents()
        {
            InitializeComponent();
            dateA.Value = DateTime.Now;
            dateDa.Value = DateTime.Now - new TimeSpan(30, 0, 0, 0);
            Internal.OnDBChange += new EventHandler(Internal_OnDBChange);
        }

        private void Internal_OnDBChange(object sender, EventArgs e)
        {
            LoadFromDB();
        }

        public TabPage GetTab()
        {
            T(this);
            return this.pageMain;
        }

        public static int ProcessEvents(string file,bool isfile)
        {
            int result = 0;
            try
            {
                string content = file;
                if (isfile) content = System.IO.File.ReadAllText(file, Encoding.UTF8);
                int start = content.IndexOf(@"<ol start=");
                int end = content.IndexOf(@"</ol></div>", start);
                if (start <= 0) return 0;
                if (end <= 0) return 0;
                if (end < start) return 0;
                content = content.Substring(start, end - start);
                int more = content.IndexOf(">", 0);
                more = more + 1;
                content = content.Substring(more, content.Length - more);
                content = content.Replace("\n", "");
                content = content.Replace(@"<tr><td width=120 class='textlong'>", "");
                content = content.Replace(@"<li>", "");
                content = content.Replace(@"<li>", "");
                content = content.Replace(@"</li>", "|");
                string[] tokens = content.Split('|');
                foreach (string line in tokens)
                {
                    if (line.Length > 18)
                    {
                        string[] cols = new string[2];
                        cols[0] = line.Substring(0, 16);
                        cols[1] = line.Substring(18, line.Length - 18);
                        try
                        {
                            DateTime date = DateTime.Parse(cols[0]);
                            string evento = cols[1];
                            result += Internal.DB.LoadEvent(date, evento);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex) { 
                My.Box.Errore("TabEvents::ProcessEvents()\r\n"+ex.Message+"\r\n"+file); 
            }
            return result;
        }

        public void LoadFromDB()
        {
            DataTable dt = Internal.DB.GetEvents(dateDa.Value,dateA.Value,textSerch.Text);
            DataTable dtid = Internal.DB.GetIDPlayers();
            if (dt == null) return;
            listEvents.BeginUpdate();
            listEvents.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                string[] line = new string[4];
                for (int i = 0; i < 4; i++) line[i] = dr[i].ToString();
                if (line[2] != "")
                {
                    DataRow[] drid = dtid.Select(string.Format("id='{0}'",line[2]));
                    if (drid.Length > 0)
                    {
                        string nome = drid[0]["nom"].ToString();
                        string cognome = drid[0]["prenom"].ToString();
                        line[2] = string.Format("{1} {0}", U(nome), U(cognome));
                    }
                }
                if (line[3] != "")
                {
                    line[3] = U(line[3]);
                    line[3] = System.Text.RegularExpressions.Regex.Replace(line[3], @"<[^>]*>", "");
                }
                ListViewItem item = new ListViewItem(line);
                listEvents.Items.Add(item);
            }
            listEvents.EndUpdate();
        }

        private void listEvents_Resize(object sender, EventArgs e)
        {
            cDettagli.Width = listEvents.Width - (cData.Width + cTipo.Width + cPlayer.Width + 25);
        }

        private void dateDa_ValueChanged(object sender, EventArgs e)
        {
            LoadFromDB();
        }

        private void dateA_ValueChanged(object sender, EventArgs e)
        {
            LoadFromDB();
        }

        private void textSerch_TextChanged(object sender, EventArgs e)
        {
            LoadFromDB();
        }
        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

    }
}
