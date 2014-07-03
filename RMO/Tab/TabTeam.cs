using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabTeam : UserControl
    {
        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        public TabTeam()
        {
            InitializeComponent();
            FillVT();
            Internal.DB.OnTeamAdded += new EventHandler(DB_OnTeamAdded);
            Internal.OnDBChange += new EventHandler(DB_OnTeamAdded);
        }

        public void FillVT()
        {
            VTLoading = true;
            comboVT.Items.Clear();
            comboVT.DataSource = Enum.GetNames(typeof(Internal.VT));
            string vt = Properties.Settings.Default.RM_VT;
            if (vt != "") vt = "RM"; 
            comboVT.SelectedIndex = comboVT.FindStringExact(vt);
            VTLoading = false;
        }

        private void DB_OnTeamAdded(object sender, EventArgs e)
        {
            RELOADDATA = true;
            LoadFromDB();
            RELOADDATA = false;
        }

        public TabPage GetTab()
        {
            T(this);
            return this.pageMain;
        }

        public void LoadXML(System.Xml.XmlNode team)
        {
            panelPlayers.SuspendLayout();
            panelPlayers.Controls.Clear();
            Control.Player.MAXRESET();
            int y = 0;
            foreach (System.Xml.XmlNode player in team)
            {
                Control.Player p = new RMO.Control.Player();
                p.LoadXML(player);
                p.Location = new Point(0, y);
                panelPlayers.Controls.Add(p);
                p.BringToFront();
                y += p.Height;
            }
            foreach (Control.Player pl in panelPlayers.Controls)
            {
                pl.SetSize();
            }
            panelPlayers.ResumeLayout();
        }

        private bool _LOADING = false;
        public bool LOADING
        {
            get { return _LOADING; }
            set
            {
                _LOADING = (bool)value;
                panelLoading.Location = panelPlayers.Location;
                panelLoading.Size = panelPlayers.Size;
                panelLoading.Visible = _LOADING;
                panelPlayers.Visible = !panelLoading.Visible;
                panelLoading.Refresh();
            }
        }

        private bool RELOADDATA = true;
        public void LoadFromDB()
        {
            try
            {
                LOADING = true;
                comboDa.Enabled = false;
                comboA.Enabled = false;
                try
                {
                    if (RELOADDATA)
                    {
                        comboDa.Items.Clear();
                        comboA.Items.Clear();
                        comboDa.Items.AddRange(Internal.DB.GetDates());
                        comboA.Items.AddRange(Internal.DB.GetDates());
                        if (comboDa.Items.Count > 1) comboDa.SelectedIndex = 1;
                        else if (comboDa.Items.Count == 1) comboDa.SelectedIndex = 0;
                        if (comboA.Items.Count > 0) comboA.SelectedIndex = 0;
                    }
                    if (comboDa.SelectedIndex < 0) return;
                    if (comboA.SelectedIndex < 0) return;
                    DataTable DT_NEW = Internal.DB.GetPlayers(comboA.Items[comboA.SelectedIndex].ToString());
                    string da = comboDa.Items[comboDa.SelectedIndex].ToString();
                    int y = 0; int j = 0;
                    Internal.Main.StatusBar.Value = 0;
                    Internal.Main.StatusBar.Maximum = DT_NEW.Rows.Count * 2;
                    Control.Player[] list = new RMO.Control.Player[DT_NEW.Rows.Count];
                    foreach (DataRow dr in DT_NEW.Rows)
                    {
                        Control.Player p = new RMO.Control.Player();
                        p.LoadData(dr, da);
                        list[j] = p; j++;
                        switch (comboVT.SelectedIndex)
                        {
                            case 1: p.ShowFACVT(); break;
                            case 2: p.ShowFCDVT(); break;
                        }
                        Internal.Main.StatusBar.Value++;
                    }
                    int totale_stipendi = 0;
                    int totale_eta = 0;
                    Array.Sort(list);
                    panelPlayers.SuspendLayout();
                    panelPlayers.Controls.Clear();
                    int k = 0;
                    foreach (Control.Player pl in list)
                    {
                        pl.SetSize();
                        totale_stipendi += pl.SALARIO;
                        totale_eta += pl.ETA;
                        pl.Location = new Point(0, y);
                        y += pl.Height;
                        panelPlayers.Controls.Add(pl);
                        if (Properties.Settings.Default.GrayLines)
                        {
                            if ((k++ % 2) == 0) pl.BackColor = Properties.Settings.Default.LinesColor1;
                            else pl.BackColor = Properties.Settings.Default.LinesColor2;
                        }
                        Internal.Main.StatusBar.Value++;
                    }
                    lStipendi.Text = string.Format(T("Totale stipendi: {0} €"), totale_stipendi.ToString());
                    decimal media = Math.Truncate((decimal)(totale_eta * 10 / list.Length)) / 10;
                    lEta.Text = string.Format(T("Età media {0} anni"), media.ToString());
                    lTOTALE.Text = string.Format(T("{0} Giocatori"), list.Length.ToString());
                    InitHeader();      
                    panelPlayers.ResumeLayout();
                }
                catch (Exception ex) { My.Box.Errore("TabTeam::LoadFromDB()\r\n"+ex.Message); }
                Internal.Main.StatusBar.Value = 0;
                comboDa.Enabled = true;
                comboA.Enabled = true;
                LOADING = false;
                CheckBlockedMarket();
            }
            catch (Exception ex) { My.Box.Errore("TabTeam::LoadFromDB()\r\n"+ex.Message); }
        }

        private void CheckBlockedMarket()
        {
            try
            {
                DateTime block = Internal.DB.GetBlockedMarket();
                TimeSpan limit = TimeSpan.FromHours(36);
                DateTime stima = block + limit;
                if (stima > DateTime.Now)
                {
                    lMarket.Text = T("Il tuo mercato è bloccato fino al") + " " + stima.ToString();
                    lMarket.Visible = true;
                }
                else lMarket.Visible = false;
            }
            catch { }
        }

        private void comboDa_SelectedIndexChanged(object sender, EventArgs e)
        {
            RELOADDATA = false;
            if (!LOADING) LoadFromDB();
            RELOADDATA = true;
        }

        private void comboA_SelectedIndexChanged(object sender, EventArgs e)
        {
            RELOADDATA = false;
            if (!LOADING) LoadFromDB();
            RELOADDATA = true;
        }

        #region Gestione degli HEADER
        private void SetMAX(System.Windows.Forms.Label c, Control.Player.Skill s)
        {
            c.AutoSize = false;
            c.Width = Control.Player.MAX[(int)s];
            toolHeader.SetToolTip(c, s.ToString());
        }

        private void InitHeader()
        {
            SetMAX(lID, Control.Player.Skill.Id);
            SetMAX(lCOGNOME, Control.Player.Skill.Cognome);
            SetMAX(lNOME, Control.Player.Skill.Nome);
            SetMAX(lSTATO, Control.Player.Skill.Stato);
            SetMAX(lCATEGORIA, Control.Player.Skill.Categoria);
            SetMAX(lHEta, Control.Player.Skill.Eta);
            SetMAX(lALTEZZA, Control.Player.Skill.Altezza);
            SetMAX(lPESO, Control.Player.Skill.Peso);

            SetMAX(lRESISTENZA, Control.Player.Skill.Resistenza);
            SetMAX(lFORZA, Control.Player.Skill.Forza);
            SetMAX(lPLACCAGGI, Control.Player.Skill.Placcaggi);
            SetMAX(lVELOCITA, Control.Player.Skill.Velocita);
            SetMAX(lPASSAGGI, Control.Player.Skill.Passaggi);
            SetMAX(lRICEZIONE, Control.Player.Skill.Ricezione);
            SetMAX(lCALCI, Control.Player.Skill.Calci);
            SetMAX(lESPERIENZA, Control.Player.Skill.Esperienza);

            SetMAX(lGIORNI, Control.Player.Skill.Giorni);
            SetMAX(lSALARIO, Control.Player.Skill.Salario);
            SetMAX(lS1, Control.Player.Skill.Pilone);
            SetMAX(lS2, Control.Player.Skill.Tallonatore);
            SetMAX(lS4, Control.Player.Skill.SecondaLinea);
            SetMAX(lS6, Control.Player.Skill.TerzaLineaAla);
            SetMAX(lS8, Control.Player.Skill.TerzaLineaCentro);
            SetMAX(lS9, Control.Player.Skill.MedianoDiMischia);
            SetMAX(lS10, Control.Player.Skill.MedianoDiApertura);
            SetMAX(lS11, Control.Player.Skill.Ala);
            SetMAX(lS12, Control.Player.Skill.Centro);
            SetMAX(lS15, Control.Player.Skill.Estremo);
        }

        private System.Windows.Forms.Label OldHeader = null;
        private void Sort(Label header, Control.Player.Skill s,bool reverse)
        {
            header.BackColor = Color.Yellow; header.Refresh();
            Control.Player.OrderSkill = s;
            Control.Player.OrderReverse = reverse;
            Control.Player[] list = new RMO.Control.Player[panelPlayers.Controls.Count];
            for (int i = 0; i < list.Length; i++) list[i] = (Control.Player)panelPlayers.Controls[i];
            Array.Sort(list);
            panelPlayers.SuspendLayout();
            int starty = 0; int k = 0;
            for (int i = 0; i < list.Length; i++)
            {
                panelPlayers.Controls.SetChildIndex(list[i], i);
                if (list[i].Visible)
                {
                    list[i].Location = new Point(list[i].Location.X, starty);
                    starty += list[i].Size.Height;
                    if (Properties.Settings.Default.GrayLines)
                    {
                        if ((k++ % 2) == 0) list[i].BackColor = Properties.Settings.Default.LinesColor1;
                        else list[i].BackColor = Properties.Settings.Default.LinesColor2;
                    }
                }
            }
            panelPlayers.ResumeLayout();
            header.BackColor = Color.Transparent;
            if (OldHeader != null) OldHeader.Font = new Font(OldHeader.Font.FontFamily, OldHeader.Font.Size, FontStyle.Regular);
            header.Font = new Font(header.Font.FontFamily, header.Font.Size, FontStyle.Bold);
            OldHeader = header;
        }

        private void lID_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Id);
            Sort(lID ,RMO.Control.Player.Skill.Id, RMO.Control.Player.OrderReverse);
        }

        private void lCOGNOME_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Cognome);
            Sort(lCOGNOME, RMO.Control.Player.Skill.Cognome, RMO.Control.Player.OrderReverse);
        }

        private void lNOME_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Nome);
            Sort(lNOME, RMO.Control.Player.Skill.Nome, RMO.Control.Player.OrderReverse);
        }

        private void lSTATO_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Stato);
            Sort(lSTATO, RMO.Control.Player.Skill.Stato, RMO.Control.Player.OrderReverse);
        }

        private void lCATEGORIA_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Categoria);
            Sort(lCATEGORIA, RMO.Control.Player.Skill.Categoria, RMO.Control.Player.OrderReverse);
        }

        private void lHEta_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Eta);
            Sort(lHEta, RMO.Control.Player.Skill.Eta, RMO.Control.Player.OrderReverse);
        }

        private void lALTEZZA_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Altezza);
            Sort(lALTEZZA, RMO.Control.Player.Skill.Altezza, RMO.Control.Player.OrderReverse);
        }

        private void lPESO_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Peso);
            Sort(lPESO, RMO.Control.Player.Skill.Peso, RMO.Control.Player.OrderReverse);
        }

        private void lRESISTENZA_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Resistenza);
            Sort(lRESISTENZA, RMO.Control.Player.Skill.Resistenza, RMO.Control.Player.OrderReverse);
        }

        private void lFORZA_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Forza);
            Sort(lFORZA, RMO.Control.Player.Skill.Forza, RMO.Control.Player.OrderReverse);
        }

        private void lPLACCAGGI_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Placcaggi);
            Sort(lPLACCAGGI, RMO.Control.Player.Skill.Placcaggi, RMO.Control.Player.OrderReverse);
        }

        private void lVELOCITA_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Velocita);
            Sort(lVELOCITA, RMO.Control.Player.Skill.Velocita, RMO.Control.Player.OrderReverse);
        }

        private void lPASSAGGI_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Passaggi);
            Sort(lPASSAGGI, RMO.Control.Player.Skill.Passaggi, RMO.Control.Player.OrderReverse);
        }

        private void lRICEZIONE_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Ricezione);
            Sort(lRICEZIONE, RMO.Control.Player.Skill.Ricezione, RMO.Control.Player.OrderReverse);
        }

        private void lCALCI_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Calci);
            Sort(lCALCI, RMO.Control.Player.Skill.Calci, RMO.Control.Player.OrderReverse);
        }

        private void lESPERIENZA_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Esperienza);
            Sort(lESPERIENZA, RMO.Control.Player.Skill.Esperienza, RMO.Control.Player.OrderReverse);
        }

        private void lGIORNI_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Giorni);
            Sort(lGIORNI, RMO.Control.Player.Skill.Giorni, RMO.Control.Player.OrderReverse);
        }

        private void lSALARIO_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Salario);
            Sort(lSALARIO, RMO.Control.Player.Skill.Salario, RMO.Control.Player.OrderReverse);
        }

        private void lS1_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Pilone);
            Sort(lS1, RMO.Control.Player.Skill.Pilone, RMO.Control.Player.OrderReverse);
        }

        private void lS2_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Tallonatore);
            Sort(lS2, RMO.Control.Player.Skill.Tallonatore, RMO.Control.Player.OrderReverse);
        }

        private void lS4_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.SecondaLinea);
            Sort(lS4, RMO.Control.Player.Skill.SecondaLinea, RMO.Control.Player.OrderReverse);
        }

        private void lS6_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.TerzaLineaAla);
            Sort(lS6, RMO.Control.Player.Skill.TerzaLineaAla, RMO.Control.Player.OrderReverse);
        }

        private void lS8_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.TerzaLineaCentro);
            Sort(lS8, RMO.Control.Player.Skill.TerzaLineaCentro, RMO.Control.Player.OrderReverse);
        }

        private void lS9_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.MedianoDiMischia);
            Sort(lS9, RMO.Control.Player.Skill.MedianoDiMischia, RMO.Control.Player.OrderReverse);
        }

        private void lS10_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.MedianoDiApertura);
            Sort(lS10, RMO.Control.Player.Skill.MedianoDiApertura, RMO.Control.Player.OrderReverse);
        }

        private void lS11_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Ala);
            Sort(lS11, RMO.Control.Player.Skill.Ala, RMO.Control.Player.OrderReverse);
        }

        private void lS12_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Centro);
            Sort(lS12, RMO.Control.Player.Skill.Centro, RMO.Control.Player.OrderReverse);
        }

        private void lS15_Click(object sender, EventArgs e)
        {
            SetOrderSkill(RMO.Control.Player.Skill.Estremo);
            Sort(lS15, RMO.Control.Player.Skill.Estremo, RMO.Control.Player.OrderReverse);
        }

        private void SetOrderSkill(RMO.Control.Player.Skill skill)
        {
            if (RMO.Control.Player.OrderSkill == skill)
                Control.Player.OrderReverse = !Control.Player.OrderReverse;
        }
        #endregion

        private void textSerch_TextChanged(object sender, EventArgs e)
        {
            string pattern = textSerch.Text.ToLower();
            bool IsNot = pattern.Contains("!");
            if (IsNot) pattern = pattern.Replace("!","");
            panelPlayers.SuspendLayout();
            int starty = 0;
            int counter = 0;
            int eta = 0;
            int stipendi = 0; int k = 0;
            foreach (Control.Player p in panelPlayers.Controls)
            {
                bool show = false;
                if (p.NOME.ToLower().Contains(pattern)) show = true;
                else if (p.COGNOME.ToLower().Contains(pattern)) show = true;
                else if (p.ID.ToString().Contains(pattern)) show = true;
                else if (p.STATO.ToLower().Contains(pattern)) show = true;
                else if (p.CATEGORIA.Contains(pattern)) show = true;
                if (IsNot) p.Visible = !show;
                else p.Visible = show;
                if (p.Visible)
                {
                    p.Location = new Point(0, starty);
                    starty += p.Height;
                    counter++;
                    eta += p.ETA;
                    stipendi += p.SALARIO;
                    if (Properties.Settings.Default.GrayLines)
                    {
                        if ((k++ % 2) == 0) p.BackColor = Properties.Settings.Default.LinesColor1;
                        else p.BackColor = Properties.Settings.Default.LinesColor2;
                    }
                }
            }
            panelPlayers.ResumeLayout();
            lTOTALE.Text = string.Format(T("{0} Giocatori"), counter);
            lStipendi.Text = string.Format(T("Totale stipendi: {0} €"), stipendi);
            decimal media = 0;
            if (eta>0) media = Math.Truncate((decimal)(eta * 10 / counter)) / 10;
            lEta.Text = string.Format(T("Età media {0} anni"), media.ToString());
        }

        private void SmallLabel_Paint(object sender, PaintEventArgs e)
         {
            try
            {
                Label s = (Label)sender;
                if (s.BackColor == Color.Transparent) e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
                else e.Graphics.FillRectangle(new SolidBrush(s.BackColor), e.ClipRectangle);
                e.Graphics.DrawString(s.Text, s.Font, Brushes.Black, new Point(0, 0));
            }
            catch (Exception ex) { Internal.Log("TabTeam::SmallLabel_Paint",ex.Message); }
        }

        private bool VTLoading = false;
        private void comboVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboVT.SelectedIndex >= 0)
            {
                if (!VTLoading)
                {
                    Properties.Settings.Default.RM_VT = comboVT.Items[comboVT.SelectedIndex].ToString();
                    Properties.Settings.Default.Save();
                }
            }
            switch (comboVT.SelectedIndex)
            {
                case 2:
                    foreach (Control.Player pl in panelPlayers.Controls) pl.ShowFCDVT();
                    break;
                case 1:
                    foreach (Control.Player pl in panelPlayers.Controls) pl.ShowFACVT();
                    break;
                case 0:
                default:
                    foreach (Control.Player pl in panelPlayers.Controls) pl.ShowRMVT();
                    break;
            }
        }
    }
}
