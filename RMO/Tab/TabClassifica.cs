using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabClassifica : UserControl
    {
        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        public TabClassifica()
        {
            InitializeComponent();
            // Permetti alle colonne di essere ordinate
            sorter = new My.Listview.ListViewColumnSorter();
            listClassifica.ListViewItemSorter = sorter;
            numStagione.Value = Properties.Settings.Default.RM_Stagione;
            Reload();
        }

        private My.Listview.ListViewColumnSorter sorter;

        public TabPage GetTab()
        {
            T(this);
            return this.pageMain;
        }

        //http://www.rugbymania.net/export_xml_part.php?lang=italiano&season=11&id={0}&access_key={1}&object=standings
        private string DEFAULT_DATA = Internal.WORKPATH + "\\xml\\last.series";
        public void LoadData(bool show_error)
        {
            buttonAggiorna.Enabled = numStagione.Enabled = false;
            try
            {
                Internal.Main.StatusString = T("Download della classifica in corso...");
                string stagione = numStagione.Value.ToString();
                string url = string.Format(@"http://www.rugbymania.net/export_xml_part.php?lang=italiano&season={2}&id={0}&access_key={1}&object=standings",
                    Properties.Settings.Default.RM_Id, Properties.Settings.Default.RM_Codice,stagione);
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                try 
                { 
                    doc.Load(url); 
                }
                catch (Exception ex)
                {
                    if (show_error) My.Box.Errore(T("Impossibile scaricare i dati della classifica")+"\r\n" + ex.Message);
                    if (System.IO.File.Exists(DEFAULT_DATA)) doc.Load(DEFAULT_DATA); 
                }
                Internal.Main.StatusString = T("Download della classifica terminato!");
                ShowClassifica(doc);
                doc.Save(DEFAULT_DATA);
            }
            catch (Exception ex) 
            { 
                #if(DEBUG)
                My.Box.Info("TabClassifica::LoadData\r\n"+ex.Message); 
                #endif
                if (Properties.Settings.Default.RM_Id.Length == 0)
                    My.Box.Errore(T("E' necessario inserire l'ID della tua squadra!"));
                if (Properties.Settings.Default.RM_Codice.Length == 0)
                    My.Box.Errore(T("E' necessario inserire il Codice per il download dei dati da RM!"));
                Internal.Main.Error_on_xml();
            }
            buttonAggiorna.Enabled = numStagione.Enabled = true;
        }

        private void ShowClassifica(System.Xml.XmlDocument doc)
        {
            listClassifica.BeginUpdate();
            listClassifica.Items.Clear();
            System.Xml.XmlNode root = doc.GetElementsByTagName("standings")[0];
            Internal.Main.StatusBar.Value = 0;
            Internal.Main.StatusBar.Maximum = root.ChildNodes.Count * 10;
            Internal.Main.StatusString = T("Elaborazione della classifica in corso...");
            foreach (System.Xml.XmlNode row in root.ChildNodes)
            {
                string[] line = new string[11];
                foreach (System.Xml.XmlNode e in row.ChildNodes)
                {
                    switch (e.Name)
                    {
                        case "position": line[0] = e.InnerText; break;
                        case "club_name": line[1] = U(e.InnerText); break;
                        case "points": line[10] = e.InnerText; break;
                        case "played": line[2] = e.InnerText; break;
                        case "win": line[3] = e.InnerText; break;
                        case "draw": line[4] = e.InnerText; break;
                        case "loss": line[5] = e.InnerText; break;
                        case "pts_plus": line[6] = e.InnerText; break;
                        case "pts_minus": line[7] = e.InnerText; break;
                        case "bonus": line[9] = e.InnerText; break;
                    }
                    if (Internal.Main.StatusBar.Value < Internal.Main.StatusBar.Maximum) Internal.Main.StatusBar.Value++;
                }
                int diff = ((int)(System.Convert.ToInt32(line[6]) - System.Convert.ToInt32(line[7])));
                line[8] = diff.ToString();
                if (diff > 0) line[8] = "+" + line[8];
                ListViewItem item = new ListViewItem(line);
                listClassifica.Items.Add(item);
            }
            Internal.Main.StatusString = T("Elaborazione della classifica terminata!");
            Internal.Main.StatusBar.Value = 0;
            listClassifica.EndUpdate();
        }

        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        private void Reload()
        {
            LoadData(false);
        }

        private void listClassifica_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listClassifica.Sort();
        }

        private void buttonAggiorna_Click(object sender, EventArgs e)
        {
            LoadData(true);
        }

        private void numStagione_ValueChanged(object sender, EventArgs e)
        {
            Reload();
            Properties.Settings.Default.RM_Stagione = (int)numStagione.Value;
            Properties.Settings.Default.Save();
        }
    }
}
