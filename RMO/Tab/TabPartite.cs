using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabPartite : UserControl
    {
        public TabPartite()
        {
            InitializeComponent();
            // Permetti alle colonne di essere ordinate
            sorter = new My.Listview.ListViewColumnSorter();
            listPartite.ListViewItemSorter = sorter;
            numStagione.Value = Properties.Settings.Default.RM_Stagione;
            Reload();
        }

        private My.Listview.ListViewColumnSorter sorter;

        public TabPage GetTab()
        {
            return this.pageMain;
        }

        //http://www.rugbymania.net/export_xml_part.php?lang=italiano&season=11&id=3087&access_key=catoblep&object=calendar
        private string DEFAULT_DATA = Internal.WORKPATH + "\\xml\\last.matches";
        public void LoadData(bool show_error)
        {
            buttonAggiorna.Enabled = numStagione.Enabled = false;
            try
            {
                Internal.Main.StatusString = "Download dell'elenco delle partite in corso...";
                string stagione = numStagione.Value.ToString();
                string url = string.Format(@"http://www.rugbymania.net/export_xml_part.php?lang=italiano&season={2}&id={0}&access_key={1}&object=calendar",
                    Properties.Settings.Default.RM_Id, Properties.Settings.Default.RM_Codice, stagione);
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                try 
                { 
                    doc.Load(url); 
                }
                catch (Exception ex)
                {
                    if (show_error) My.Box.Errore("Impossibile scaricare i dati delle partite\r\n"+ex.Message);
                    if (System.IO.File.Exists(DEFAULT_DATA)) doc.Load(DEFAULT_DATA); 
                }
                Internal.Main.StatusString = "Download dell'elenco delle partite terminato!";
                ShowPartite(doc);
                if (doc.HasChildNodes) doc.Save(DEFAULT_DATA);
            }
            catch (Exception ex) 
            { 
                #if(DEBUG)
                My.Box.Info("TabClassifica::LoadData\r\n" + ex.Message); 
                #endif
                Internal.Main.Error_on_xml();
            }
            buttonAggiorna.Enabled = numStagione.Enabled = true;
        }

        private void ShowPartite(System.Xml.XmlDocument doc)
        {
            Internal.Main.StatusString = "Elaborazione dei dati delle partite in corso...";
            listPartite.BeginUpdate();
            listPartite.Items.Clear();
            System.Xml.XmlNode root = doc.GetElementsByTagName("calendar")[0];
            Internal.Main.StatusBar.Value = 0;
            Internal.Main.StatusBar.Maximum = root.ChildNodes.Count * 7;
            foreach (System.Xml.XmlNode row in root.ChildNodes)
            {
                string[] line = new string[6];
                foreach (System.Xml.XmlNode e in row.ChildNodes)
                {
                    switch (e.Name)
                    {
                        case "round": line[0] = e.InnerText; break;
                        case "date_match": line[1] = e.InnerText; break;
                        case "home_team": line[2] = U(e.InnerText); break;
                        case "away_team": line[3] = U(e.InnerText); break;
                        case "home_score": line[4] = e.InnerText; break;
                        case "away_score": line[5] = e.InnerText; break;
                    }
                    if (Internal.Main.StatusBar.Value < Internal.Main.StatusBar.Maximum) Internal.Main.StatusBar.Value++;
                }
                if (line[0] == "FRIENDLY") line[0] = "Amichevole";
                else if (line[0].Length >= 3) line[0] = "Coppa";
                if (line[4] == "#") line[4] = "-";
                if (line[5] == "#") line[5] = "-";
                ListViewItem item = new ListViewItem(line);
                listPartite.Items.Add(item);
            }
            listPartite.EndUpdate();
            Internal.Main.StatusString = "Elaborazione dei dati delle partite terminato!";
            Internal.Main.StatusBar.Value = 0;
        }

        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        private void comboStagione_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*System.Threading.Thread t = new System.Threading.Thread(Reload);
            t.IsBackground = true; t.Priority = System.Threading.ThreadPriority.Normal;
            t.Start();*/
            Reload();
        }

        private void Reload()
        {
            LoadData(false);
        }

        private void listPartite_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.listPartite.Sort();
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
