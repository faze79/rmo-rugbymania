using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Control
{
    public partial class Player : UserControl, IComparable 
    {
        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        public Player()
        {
            InitializeComponent();
            SetHandler();
            this.Height = lID.Font.Height+6;
        }

        public override string ToString()
        {
            return "*** " + NOME + " " + COGNOME;
        }

        public static bool OrderReverse = false;
        public static Skill OrderSkill = Skill.Id;
        public int CompareTo(object obj)
        {
            Player p = (Player)obj;
            switch (OrderSkill)
            {
                case Skill.Id:  return (OrderReverse) ? (p.ID-ID) : (ID-p.ID);
                case Skill.Nome: return (OrderReverse) ? string.Compare(p.NOME,NOME) : string.Compare(NOME,p.NOME);
                case Skill.Cognome: return (OrderReverse) ? string.Compare(p.COGNOME, COGNOME) : string.Compare(COGNOME, p.COGNOME);
                case Skill.Stato: return (OrderReverse) ? string.Compare(p.STATO,STATO) : string.Compare(STATO,p.STATO);
                case Skill.Categoria: return (OrderReverse) ? string.Compare(p.CATEGORIA,CATEGORIA) : string.Compare(CATEGORIA,p.CATEGORIA);
                case Skill.Eta: return (OrderReverse) ? (p.ETA-ETA) : (ETA-p.ETA);
                case Skill.Altezza: return (OrderReverse) ? (int)(p.ALTEZZA-ALTEZZA) : (int)(ALTEZZA-p.ALTEZZA);
                case Skill.Peso: return (OrderReverse) ? (p.PESO-PESO) : (PESO-p.PESO);
                case Skill.Resistenza: return (OrderReverse) ? (p.RESISTENZA-RESISTENZA) : (RESISTENZA-p.RESISTENZA);
                case Skill.Forza: return (OrderReverse) ? (int)((p.FORZA - FORZA) * 10) : (int)((FORZA - p.FORZA) * 10);
                case Skill.Placcaggi: return (OrderReverse) ? (int)((p.PLACCAGGI - PLACCAGGI) * 10) : (int)((PLACCAGGI - p.PLACCAGGI) * 10);
                case Skill.Velocita: return (OrderReverse) ? (int)((p.VELOCITA - VELOCITA) * 10) : (int)((VELOCITA - p.VELOCITA) * 10);
                case Skill.Passaggi: return (OrderReverse) ? (int)((p.PASSAGGI - PASSAGGI) * 10) : (int)((PASSAGGI - p.PASSAGGI) * 10);
                case Skill.Ricezione: return (OrderReverse) ? (int)((p.RICEZIONE - RICEZIONE) * 10) : (int)((RICEZIONE - p.RICEZIONE) * 10);
                case Skill.Calci: return (OrderReverse) ? (int)((p.CALCI - CALCI) * 10) : (int)((CALCI - p.CALCI) * 10);
                case Skill.Esperienza: return (OrderReverse) ? (p.ESPERIENZA - ESPERIENZA) : (ESPERIENZA - p.ESPERIENZA);
                case Skill.Giorni: return (OrderReverse) ? (int)((p.GIORNI - GIORNI)*10) : (int)((GIORNI - p.GIORNI)*10);
                case Skill.Salario: return (OrderReverse) ? (p.SALARIO - SALARIO) : (SALARIO - p.SALARIO);
                case Skill.Pilone: return (OrderReverse) ? (p.PILONE - PILONE) : (PILONE - p.PILONE);
                case Skill.Tallonatore: return (OrderReverse) ? (p.TALLONATORE-TALLONATORE) : (TALLONATORE-p.TALLONATORE);
                case Skill.SecondaLinea: return (OrderReverse) ? (p.SECONDALINEA-SECONDALINEA) : (SECONDALINEA-p.SECONDALINEA);
                case Skill.TerzaLineaAla: return (OrderReverse) ? (p.TERZALINEAALA-TERZALINEAALA) : (TERZALINEAALA-p.TERZALINEAALA);
                case Skill.TerzaLineaCentro: return (OrderReverse) ? (p.TERZALINEACENTRO-TERZALINEACENTRO) : (TERZALINEACENTRO-p.TERZALINEACENTRO);
                case Skill.MedianoDiMischia: return (OrderReverse) ? (p.MEDIANODIMISCHIA-MEDIANODIMISCHIA) : (MEDIANODIMISCHIA-p.MEDIANODIMISCHIA);
                case Skill.MedianoDiApertura: return (OrderReverse) ? (p.MEDIANODIAPERTURA-MEDIANODIAPERTURA) : (MEDIANODIAPERTURA-p.MEDIANODIAPERTURA);
                case Skill.Ala: return (OrderReverse) ? (p.ALA-ALA) : (ALA-p.ALA);
                case Skill.Centro: return (OrderReverse) ? (p.CENTRO-CENTRO) : (CENTRO-p.CENTRO);
                case Skill.Estremo: return (OrderReverse) ? (p.ESTREMO-ESTREMO) : (ESTREMO-p.ESTREMO);
            }
            return 0;
        }

        private void SetHandler()
        {
            lETA.Click += new EventHandler(lETA_Click);
            lID.MouseEnter += new EventHandler(lID_MouseEnter);
            lID.MouseLeave += new EventHandler(lID_MouseLeave);
            lSTATO.Paint += new PaintEventHandler(lSTATO_Paint);
            lSTATO.Click += new EventHandler(lSTATO_Click);
            lFORZA.MouseDown += new MouseEventHandler(Skill_MouseDown);
            lPLACCAGGI.MouseDown += new MouseEventHandler(Skill_MouseDown);
            lVELOCITA.MouseDown += new MouseEventHandler(Skill_MouseDown);
            lPASSAGGI.MouseDown += new MouseEventHandler(Skill_MouseDown);
            lRICEZIONE.MouseDown += new MouseEventHandler(Skill_MouseDown);
            lCALCI.MouseDown += new MouseEventHandler(Skill_MouseDown);
            lNOME.Click += new EventHandler(lNOME_Click);
        }

        private void lNOME_Click(object sender, EventArgs e)
        {
            Internal.Main.ShowPlayer2(ID.ToString());
        }

        private void Skill_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem(T("Aggiungi allenamento manualmente"));
                item.Click += new EventHandler(AllenamentoInForza_Click);
                menu.Items.Add(item);
                item = new ToolStripMenuItem(T("Rimuovi allenamento manualmente"));
                item.Click += new EventHandler(AllenamentoRimuovi_Click);
                menu.Items.Add(item);
                item = new ToolStripMenuItem(T("Visualizza gli allenamenti in dettaglio"));
                item.Click += new EventHandler(AllenamentoMostra_Click);
                menu.Items.Add(item);
                // Visualizza il menu
                Point p = new Point(0, 0);
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)sender;
                p = c.PointToScreen(e.Location);
                menu.Show(p);
            }
        }

        private void AllenamentoRimuovi_Click(object sender, EventArgs e)
        {
            My.Box.Info(T("Funzione non implementata"));
        }

        private void AllenamentoMostra_Click(object sender, EventArgs e)
        {
            My.Box.Info(T("Funzione non implementata"));
        }

        private void AllenamentoInForza_Click(object sender, EventArgs e)
        {
            My.Box.Info(T("Funzione non implementata"));
        }

        private void lSTATO_Paint(object sender, PaintEventArgs e)
        {
            if (Flag != null)
            {
                e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
                e.Graphics.DrawImage(Flag, 0, 0,32,20);
                e.Graphics.DrawRectangle(Pens.White, 0, 0, 32, 20);
            }
        }

        private Bitmap Flag = null;
        private void LoadFlag()
        {
            switch (lSTATO.Text)
            {
                case "Italia": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag390.gif"); break;
                case "Romania": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag40.gif"); break;
                case "France": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag33.gif"); break;
                case "England": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag44.gif"); break;
                case "Scotland": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag440.gif"); break;
                case "Deutschland": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag49.gif"); break;
                case "Nederland": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag31.gif"); break;
                case "Andorra": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag376.gif"); break;
                case "Polska": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag48.gif"); break;
                case "Ireland": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag353.gif"); break;
                case "Argentina": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag54.gif"); break;
                case "Australia": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag61.gif"); break;
                case "Wales": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag441.gif"); break;
                case "España": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag34.gif"); break;
                case "Brasil": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag55.gif"); break;
                case "Magyarország": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag36.gif"); break;
                case "New Zealand": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag64.gif"); break;
                case "Portugal": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag351.gif"); break;
                case "South Africa": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag27.gif"); break;
                case "Sverige": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag46.gif"); break;
                case "Chile": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag56.gif"); break;
                case "Belgique": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag32.gif"); break;
                case "Hrvatska": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag385.gif"); break;
                case "USA": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag101.gif"); break;
                case "Canada": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag102.gif"); break;
                case "Perú": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag51.gif"); break;
                case "Paraguay": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag595.gif"); break;
                case "Uruguay": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag598.gif"); break;
                case "Österreich": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag43.gif"); break;
                case "Schweiz": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag41.gif"); break;
                case "Nippon": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag81.gif"); break;
                case "Slovenija": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag386.gif"); break;
                case "Republica Moldova": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag373.gif"); break;
                case "Bosna": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag387.gif"); break;
                case "Česká Republika": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag420.gif"); break;
                case "Danmark": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag45.gif"); break;
                case "Finland": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag358.gif"); break;
                case "Norge": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag47.gif"); break;
                case "Venezuela": Flag = new Bitmap(typeof(MainForm), "Bandiere.flag58.gif"); break;
            }
            string msg = "\r\n"+T("Clicca qui per andare alla pagina della nazionale.");
            if (Flag!=null) toolSKILL.SetToolTip(lSTATO, lSTATO.Text + msg);
        }

        private void lID_MouseLeave(object sender, EventArgs e)
        {
            lID.Font = new Font(lID.Font.FontFamily, lID.Font.Size, System.Drawing.FontStyle.Regular);
        }

        private void lID_MouseEnter(object sender, EventArgs e)
        {
            lID.Font = new Font(lID.Font.FontFamily, lID.Font.Size, System.Drawing.FontStyle.Underline);
        }

        private void lNOME_MouseEnter(object sender, EventArgs e)
        {
            lNOME.Font = new Font(lNOME.Font.FontFamily, lNOME.Font.Size, System.Drawing.FontStyle.Underline);
        }

        private void lNOME_MouseLeave(object sender, EventArgs e)
        {
            lNOME.Font = new Font(lNOME.Font.FontFamily, lNOME.Font.Size, System.Drawing.FontStyle.Regular);
        }

        private void lETA_Click(object sender, EventArgs e)
        {
            if (lETA.BackColor != Color.Transparent)
            {
                foreach (System.Windows.Forms.Control c in Controls)
                {
                    if (c.Tag == null)
                    {
                        if (c.BackColor.A == 0) c.BackColor = lETA.BackColor;
                        else c.BackColor = Color.FromArgb(0, 255, 255, 255);
                    }
                }
            }
        }

        public void LoadXML(System.Xml.XmlNode player)
        {
            this.SuspendLayout();
            foreach (System.Xml.XmlNode prop in player)
            {
                SetValue(prop.Name, prop.InnerText);
            }
            LoadFlag();
            CheckToolTip();
            CheckColors();
            CheckSize();
            this.ResumeLayout();
        }

        public bool Loaded = false;
        public void LoadData(DataRow dr,string da)
        {
            try
            {
                this.SuspendLayout();
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    SetValue(dr.Table.Columns[i].ColumnName, dr[i].ToString());
                }
                LoadFlag();
                CheckOld(da);
                CheckToolTip();
                CheckColors();
                CheckSize();
                this.ResumeLayout();
                Loaded = true;
            }
            catch (Exception ex) { 
                //My.Box.Errore("Player::LoadData()\r\n" + ex.Message); 
            }
        }

        public void LoadData(RMO.Class.Player d)
        {
            this.SuspendLayout();
            SetValue("id", d.ID.ToString());
            SetValue("prenom", d.NOME);
            SetValue("nom", d.COGNOME);
            SetValue("country", d.STATO);
            SetValue("category", d.CATEGORIA);
            SetValue("age", d.ETA.ToString());
            SetValue("experience", d.ESPERIENZA.ToString());
            SetValue("salaire", d.SALARIO.ToString());
            SetValue("placage", d.PLACCAGGI.ToString());
            SetValue("puissance", d.FORZA.ToString());
            SetValue("passe", d.PASSAGGI.ToString());
            SetValue("receptionb", d.RICEZIONE.ToString());
            SetValue("endurance", d.RESISTENZA.ToString());
            SetValue("rapidite", d.VELOCITA.ToString());
            SetValue("kicking", d.CALCI.ToString());
            SetValue("size", d.ALTEZZA.ToString());
            SetValue("weight", (d.PESO*100).ToString());
            lSTATO.Visible = lGIORNI.Visible = lCATEGORIA.Visible = false;
            CheckOld(null);
            CheckToolTip();
            CheckColors();
            CheckSize();
            this.ResumeLayout();
            Loaded = true;
        }

        private void SetValue(string nome, string valore)
        {
            switch (nome.ToLower())
            {
                case "id": lID.Text = valore; break;
                case "nom": lCOGNOME.Text = U(valore); break;
                case "prenom": lNOME.Text = U(valore); break;
                case "country": lSTATO.Text = U(valore); break;
                case "category":
                    switch (valore)
                    {
                        case "1": lCATEGORIA.Text = T("avanti"); break;
                        case "5": lCATEGORIA.Text = T("jolly"); break;
                        case "9": lCATEGORIA.Text = T("3/4"); break;
                        default: lCATEGORIA.Text = valore; break;
                    }
                    break;
                case "age": lETA.Text = valore; break;
                case "experience": SetSkill(Skill.Esperienza, valore); break;
                case "salaire": lSALARIO.Text = valore; break;
                case "placage": SetSkill(Skill.Placcaggi, valore); break;
                case "puissance": SetSkill(Skill.Forza, valore); break;
                case "passe": SetSkill(Skill.Passaggi, valore); break;
                case "receptionb": SetSkill(Skill.Ricezione, valore); break;
                case "endurance": SetSkill(Skill.Resistenza, valore); break;
                case "rapidite": SetSkill(Skill.Velocita, valore); break;
                case "kicking": SetSkill(Skill.Calci, valore); break;
                case "size": SetSkill(Skill.Altezza, valore); break;
                case "weight": SetSkill(Skill.Peso, valore); break;
                case "arrivee":
                    if (valore=="0") lGIORNI.Text = "A";
                    else lGIORNI.Text = valore.Replace("giorni", "").Trim(); 
                    break;
                //case "date_from":
                //case "injured_until":
                case "stat1": SetSkill(Skill.Pilone, valore); break;
                case "stat2": SetSkill(Skill.Tallonatore, valore); break;
                case "stat4": SetSkill(Skill.SecondaLinea, valore); break;
                case "stat6": SetSkill(Skill.TerzaLineaAla, valore); break;
                case "stat8": SetSkill(Skill.TerzaLineaCentro, valore); break;
                case "stat9": SetSkill(Skill.MedianoDiMischia, valore); break;
                case "stat10": SetSkill(Skill.MedianoDiApertura, valore); break;
                case "stat11": SetSkill(Skill.Ala, valore); break;
                case "stat12": SetSkill(Skill.Centro, valore); break;
                case "stat15": SetSkill(Skill.Estremo, valore); break;
            }
        }

        private void SetSkill(Skill s, string valore)
        {
            switch (s)
            {
                case Skill.Altezza:
                    lALTEZZA.Text = valore; 
                    _ALTEZZA = System.Convert.ToInt32(valore);
                    break;
                case Skill.Peso:
                    decimal dval = My.Convert.ToDecimal(valore);
                    dval = ((decimal)(dval / 100));
                    while (dval > 200) dval = ((decimal)(dval / 10));
                    lPESO.Text = dval.ToString("00.00");
                    _PESO = dval;
                    break;

                case Skill.Esperienza: 
                    lESPERIENZA.Text = valore; 
                    _ESPERIENZA = System.Convert.ToInt32(valore); 
                    break;
                case Skill.Placcaggi:
                    lPLACCAGGI.Text = valore; 
                    _PLACCAGGI = My.Convert.ToDecimal(valore);
                    break;
                case Skill.Forza:
                    lFORZA.Text = valore; 
                    _FORZA = My.Convert.ToDecimal(valore);
                    break;
                case Skill.Passaggi:
                    lPASSAGGI.Text = valore; 
                    _PASSAGGI = My.Convert.ToDecimal(valore);
                    break;
                case Skill.Ricezione:
                    lRICEZIONE.Text = valore; 
                    _RICEZIONE = My.Convert.ToDecimal(valore);
                    break;
                case Skill.Resistenza:
                    lRESISTENZA.Text = valore; 
                    _RESISTENZA = System.Convert.ToInt32(valore);
                    break;
                case Skill.Velocita:
                    lVELOCITA.Text = valore; 
                    _VELOCITA = My.Convert.ToDecimal(valore);
                    break;
                case Skill.Calci:
                    lCALCI.Text = valore; 
                    _CALCI = My.Convert.ToDecimal(valore);
                    break;

                case Skill.Pilone:
                    lS1.Text = valore; 
                    _PILONE = System.Convert.ToInt32(valore);
                    break;
                case Skill.Tallonatore:
                    lS2.Text = valore; 
                    _TALLONATORE = System.Convert.ToInt32(valore);
                    break;
                case Skill.SecondaLinea:
                    lS4.Text = valore; 
                    _SECONDALINEA = System.Convert.ToInt32(valore);
                    break;
                case Skill.TerzaLineaAla:
                    lS6.Text = valore; 
                    _TERZALINEAALA = System.Convert.ToInt32(valore);
                    break;
                case Skill.TerzaLineaCentro:
                    lS8.Text = valore; 
                    _TERZALINEACENTRO = System.Convert.ToInt32(valore);
                    break;
                case Skill.MedianoDiMischia:
                    lS9.Text = valore; 
                    _MEDIANODIMISCHIA = System.Convert.ToInt32(valore);
                    break;
                case Skill.MedianoDiApertura:
                    lS10.Text = valore; 
                    _MEDIANODIAPERTURA = System.Convert.ToInt32(valore);
                    break;
                case Skill.Ala:
                    lS11.Text = valore; 
                    _ALA = System.Convert.ToInt32(valore);
                    break;
                case Skill.Centro:
                    lS12.Text = valore; 
                    _CENTRO = System.Convert.ToInt32(valore);
                    break;
                case Skill.Estremo:
                    lS15.Text = valore; 
                    _ESTREMO = System.Convert.ToInt32(valore);
                    break;
            }
        }

        public int ID { get { return System.Convert.ToInt32(lID.Text); } }
        public string NOME { get { return lNOME.Text; } }
        public string COGNOME { get { return lCOGNOME.Text; } }
        public string STATO { get { return lSTATO.Text; } }
        public string CATEGORIA { get { return lCATEGORIA.Text; } }
        public int SALARIO { get { return System.Convert.ToInt32(lSALARIO.Text); } }
        public int ETA { get { return System.Convert.ToInt32(lETA.Text); } }

        private decimal _ALTEZZA = 0;
        public decimal ALTEZZA { get { return _ALTEZZA; } }
        private decimal _PESO = 0;
        public int PESO { get { return (int)(System.Convert.ToDouble(lPESO.Text)*100); } }

        private int _RESISTENZA = 0;
        public int RESISTENZA { get { return _RESISTENZA; } }
        private decimal _FORZA = 0;
        public decimal FORZA { get { return _FORZA; } }
        private decimal _PLACCAGGI = 0;
        public decimal PLACCAGGI { get { return _PLACCAGGI; } }
        private decimal _VELOCITA = 0;
        public decimal VELOCITA { get { return _VELOCITA; } }
        private decimal _PASSAGGI = 0;
        public decimal PASSAGGI { get { return _PASSAGGI; } }
        private decimal _RICEZIONE = 0;
        public decimal RICEZIONE { get { return _RICEZIONE; } }
        private decimal _CALCI = 0;
        public decimal CALCI { get { return _CALCI; } }
        private int _ESPERIENZA = 0;
        public int ESPERIENZA { get { return _ESPERIENZA; } }

        public decimal GIORNI { get {
            try { return My.Convert.ToDecimal(lGIORNI.Text); }
            catch { return 9999; }
            //return (lGIORNI.Text == "A") ? 9999 : My.Convert.ToDecimal(lGIORNI.Text); 
        } }

        private int _PILONE = 0;
        public int PILONE
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACPILONE);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDPILONE);
                    default: return _PILONE;
                }
            }
        }
        private int _TALLONATORE = 0;
        public int TALLONATORE
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACTALLONATORE);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDTALLONATORE);
                    default: return _TALLONATORE;
                }
            }
        }
        private int _SECONDALINEA = 0;
        public int SECONDALINEA
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACSECONDA);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDSECONDA);
                    default: return _SECONDALINEA;
                }
            }
        }
        private int _TERZALINEAALA = 0;
        public int TERZALINEAALA
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACTERZAALA);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDTERZAALA);
                    default: return _TERZALINEAALA;
                }
            }
        }
        private int _TERZALINEACENTRO = 0;
        public int TERZALINEACENTRO
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACTERZACENTRO);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDTERZACENTRO);
                    default: return _TERZALINEACENTRO;
                }
            }
        }
        private int _MEDIANODIMISCHIA = 0;
        public int MEDIANODIMISCHIA
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACMM);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDMM);
                    default: return _MEDIANODIMISCHIA;
                }
            }
        }
        private int _MEDIANODIAPERTURA = 0;
        public int MEDIANODIAPERTURA
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACMA);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDMA);
                    default: return _MEDIANODIAPERTURA;
                }
            }
        }
        private int _ALA = 0;
        public int ALA
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACALA);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDALA);
                    default: return _ALA;
                }
            }
        }
        private int _CENTRO = 0;
        public int CENTRO
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACCENTRO);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDCENTRO);
                    default: return _CENTRO;
                }
            }
        }  
        private int _ESTREMO = 0;
        public int ESTREMO
        {
            get
            {
                switch (Internal.CurrentVT)
                {
                    case Internal.VT.FAC: return decimal.ToInt32(FACESTREMO);
                    case Internal.VT.FCD: return decimal.ToInt32(FCDESTREMO);
                    default: return _ESTREMO;
                }
            }
        }

        public decimal PESOSKILL
        {
            get 
            {
                decimal tmp = _PESO;//decimal.Divide(_PESO, (decimal)100);
                tmp = decimal.Subtract(tmp,(decimal)60);
                tmp = decimal.Divide(tmp,(decimal)3.5);
                tmp = decimal.Floor(tmp * 100);
                tmp = decimal.Divide(tmp, 100);
                if (tmp > 18) tmp = 18;
                return tmp;
            }
        }

        public decimal ALTEZZASKILL
        {
            get
            {
                decimal tmp = _ALTEZZA;
                if (tmp > 205) return 18;
                if (tmp < 162) return 0;
                tmp = tmp - 161;
                tmp = decimal.Divide(tmp, (decimal)2.5);
                return tmp;
            }
        }
        public decimal FACPILONE        { get { return FACVT(10,30,5,0,10,10,5,0,30,0); } }
        public decimal FACTALLONATORE   { get { return FACVT(10,30,5,0,20,10,5,0,20,0); } }
        public decimal FACSECONDA       { get { return FACVT(5,20,0,5,10,20,5,0,15,20); } }
        public decimal FACTERZAALA      { get { return FACVT(5,15,15,5,10,20,10,0,10,10); } }
        public decimal FACTERZACENTRO   { get { return FACVT(5,20,20,5,15,15,10,0,5,5); } }
        public decimal FACMM            { get { return FACVT(0,10,10,10,30,30,10,0,0,0); } }
        public decimal FACMA            { get { return FACVT(0,5,20,10,20,20,10,15,0,0); } }
        public decimal FACCENTRO        { get { return FACVT(0,15,20,15,20,20,10,0,0,0); } }
        public decimal FACALA           { get { return FACVT(0,25,15,25,15,20,0,0,0,0); } }
        public decimal FACESTREMO       { get { return FACVT(0,15,20,15,20,20,10,0,0,0); } }

        public decimal FCDPILONE        { get { return FACVT(2, 34, 8, 2, 8, 14, 8, 0, 4, 20); } }
        public decimal FCDTALLONATORE   { get { return FACVT(2, 27, 10, 5, 22, 14, 8, 0, 2, 10); } }
        public decimal FCDSECONDA       { get { return FACVT(2, 20, 3, 2, 12, 19, 8, 0, 14, 20); } }
        public decimal FCDTERZAALA      { get { return FACVT(2, 15, 18, 7, 12, 20, 10, 0, 8, 8); } }
        public decimal FCDTERZACENTRO   { get { return FACVT(2, 27, 18, 6, 15, 15, 10, 0, 3, 4); } }
        public decimal FCDMM            { get { return FACVT(0, 13, 21, 13, 35, 10, 8, 0,0,0); } }
        public decimal FCDMA            { get { return FACVT(0, 13, 25, 13, 18, 18, 8, 5,0,0); } }
        public decimal FCDCENTRO        { get { return FACVT(0, 17, 15, 17, 20, 23, 8, 0,0,0); } }
        public decimal FCDALA           { get { return FACVT(0, 25, 10, 25, 15, 25, 0, 0,0,0); } }
        public decimal FCDESTREMO       { get { return FACVT(0, 17, 16, 17, 18, 24, 8, 0,0,0); } }

        private decimal FACVT(int resistenza, int forza, int placcaggi, int velocita, int passaggi, int ricezione, int esperienza, int calci, int peso, int altezza)
        {
            decimal result = 0;
            int check = resistenza + forza + placcaggi + velocita + passaggi + ricezione + esperienza + calci + peso + altezza;
            if (check == 100)
            {
                result += decimal.Multiply(_RESISTENZA, decimal.Divide(resistenza, 100));
                result += decimal.Multiply(_FORZA, decimal.Divide(forza, 100));
                result += decimal.Multiply(_PLACCAGGI, decimal.Divide(placcaggi, 100));
                result += decimal.Multiply(_VELOCITA, decimal.Divide(velocita, 100));
                result += decimal.Multiply(_PASSAGGI, decimal.Divide(passaggi, 100));
                result += decimal.Multiply(_RICEZIONE, decimal.Divide(ricezione, 100));
                result += decimal.Multiply(_ESPERIENZA, decimal.Divide(esperienza, 100));
                result += decimal.Multiply(_CALCI, decimal.Divide(calci, 100));
                result += decimal.Multiply(PESOSKILL, decimal.Divide(peso, 100));
                result += decimal.Multiply(ALTEZZASKILL, decimal.Divide(altezza, 100));
                result = decimal.Floor(result * (decimal)5.56 * 100);
                result = decimal.Divide(result, 100);
            }
            return result;
        }

        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        private void lID_Click(object sender, EventArgs e)
        {
            Internal.Main.ShowPlayer(lID.Text);
        }

        /// <summary>
        /// Vai al sito della nazionale
        /// </summary>
        private void lSTATO_Click(object sender, EventArgs e)
        {
            string url = "";
            switch (lSTATO.Text)
            {
                case "Italia": url = @"http://www.rugbymania.net/national.php?parbestof=17"; break;
                case "Romania": url = @"http://www.rugbymania.net/national.php?parbestof=28"; break;
                case "France": url = @"http://www.rugbymania.net/national.php?parbestof=14"; break;
                case "England": url = @"http://www.rugbymania.net/national.php?parbestof=11"; break;
                case "Scotland": url = @"http://www.rugbymania.net/national.php?parbestof=30"; break;
                case "Deutschland": url = @"http://www.rugbymania.net/national.php?parbestof=10"; break;
                case "Nederland": url = @"http://www.rugbymania.net/national.php?parbestof=20"; break;
                case "Andorra": url = @"http://www.rugbymania.net/national.php?parbestof=2"; break;
                case "Polska": url = @"http://www.rugbymania.net/national.php?parbestof=26"; break;
                case "Ireland": url = @"http://www.rugbymania.net/national.php?parbestof=16"; break;
                case "Argentina": url = @"http://www.rugbymania.net/national.php?parbestof=3"; break;
                case "Australia": url = @"http://www.rugbymania.net/national.php?parbestof=4"; break;
                case "Wales": url = @"http://www.rugbymania.net/national.php?parbestof=36"; break;
                case "España": url = @"http://www.rugbymania.net/national.php?parbestof=12"; break;
                case "Brasil": url = @"http://www.rugbymania.net/national.php?parbestof=7"; break;
                case "Magyarország": url = @"http://www.rugbymania.net/national.php?parbestof=18"; break;
                case "New Zealand": url = @"http://www.rugbymania.net/national.php?parbestof=21"; break;
                case "Portugal": url = @"http://www.rugbymania.net/national.php?parbestof=27"; break;
                case "South Africa": url = @"http://www.rugbymania.net/national.php?parbestof=32"; break;
                case "Sverige": url = @"http://www.rugbymania.net/national.php?parbestof=33"; break;
                case "Chile": url = @"http://www.rugbymania.net/national.php?parbestof=9"; break;
                case "Belgique": url = @"http://www.rugbymania.net/national.php?parbestof=5"; break;
                case "Hrvatska": url = @"http://www.rugbymania.net/national.php?parbestof=15"; break;
                case "USA": url = @"http://www.rugbymania.net/national.php?parbestof=35"; break;
                case "Canada": url = @"http://www.rugbymania.net/national.php?parbestof=8"; break;
                case "Perú": url = @"http://www.rugbymania.net/national.php?parbestof=25"; break;
                case "Paraguay": url = @"http://www.rugbymania.net/national.php?parbestof=24"; break;
                case "Uruguay": url = @"http://www.rugbymania.net/national.php?parbestof=34"; break;
                case "Österreich": url = @"http://www.rugbymania.net/national.php?parbestof=37"; break;
                case "Schweiz": url = @"http://www.rugbymania.net/national.php?parbestof=29"; break;
                case "Nippon": url = @"http://www.rugbymania.net/national.php?parbestof=6"; break;
                case "Slovenija": url = @"http://www.rugbymania.net/national.php?parbestof=6"; break;
                case "Republica Moldova": url = @"http://www.rugbymania.net/national.php?parbestof=6"; break;
                case "Bosna": url = @"http://www.rugbymania.net/national.php?parbestof=6"; break;
                case "Česká Republika": url = @"http://www.rugbymania.net/national.php?parbestof=6"; break;
                case "Danmark": url = @"http://www.rugbymania.net/national.php?parbestof=13"; break;
                case "Finland": url = @"http://www.rugbymania.net/national.php?parbestof=13"; break;
                case "Norge": url = @"http://www.rugbymania.net/national.php?parbestof=13"; break;
            }
            if (url != "") Internal.Main.ShowRM(url);
        }

        private void CheckOld(string da)
        {
            DataRow dr = null;
            if (da!=null) dr = Internal.DB.GetPlayer(lID.Text, da);
            CompareSkill(lRESISTENZA, dr, Skill.Resistenza);
            CompareSkill(lFORZA, dr, Skill.Forza);
            CompareSkill(lPLACCAGGI, dr, Skill.Placcaggi);
            CompareSkill(lVELOCITA, dr, Skill.Velocita);
            CompareSkill(lPASSAGGI, dr, Skill.Passaggi);
            CompareSkill(lRICEZIONE, dr, Skill.Ricezione);
            CompareSkill(lCALCI, dr, Skill.Calci);
            CompareSkill(lESPERIENZA, dr, Skill.Esperienza);
            if (dr != null)
            {
                CompareSkill3(lPESO, dr, Skill.Peso);

                CompareSkill2(lS1, dr, Skill.Pilone);
                CompareSkill2(lS2, dr, Skill.Tallonatore);
                CompareSkill2(lS4, dr, Skill.SecondaLinea);
                CompareSkill2(lS6, dr, Skill.TerzaLineaAla);
                CompareSkill2(lS8, dr, Skill.TerzaLineaCentro);
                CompareSkill2(lS9, dr, Skill.MedianoDiMischia);
                CompareSkill2(lS10, dr, Skill.MedianoDiApertura);
                CompareSkill2(lS11, dr, Skill.Ala);
                CompareSkill2(lS12, dr, Skill.Centro);
                CompareSkill2(lS15, dr, Skill.Estremo);

                CompareSkillStd(lSALARIO, dr, Skill.Salario, "Lo stipendio", "€");
            }
            else
            {   // Cose da fare se un giocatore non ha alcuna storia 
                SetPesoLimite(lPESO);
                CompareStipendio(lSALARIO);
            }
            CompareGiorni(lGIORNI);
            toolSKILL.SetToolTip(lALTEZZA, string.Format("FAC VT: {0}", ALTEZZASKILL));
        }

        private string S(Enum s) { return GetStringValue(s); }

        private void CompareSkill(Label l,DataRow dr,Skill s)
        {
            string vecchiostr="";
            if (dr != null) vecchiostr = dr[S(s)].ToString();
            else vecchiostr = l.Text;
            string tooltext = "";
            if (l.Text == vecchiostr)
            {
                tooltext = string.Format(T("Ha {0} in {1}."), l.Text, SkillToString(s));
            }
            else
            {
                decimal nuovo = System.Convert.ToDecimal(l.Text);
                decimal vecchio = System.Convert.ToDecimal(vecchiostr);
                decimal differenza = (nuovo - vecchio);
                l.Tag = "Allenamento";
                if (differenza < 0)
                {
                    tooltext = string.Format(T("Ha {0} in {1}.|E' diminuito di {2}|con l'età"),
                        nuovo.ToString(), SkillToString(s), Math.Abs(differenza).ToString());
                    l.BackColor = Properties.Settings.Default.Color_ScattoMeno;
                }
                else
                {
                    tooltext = string.Format(T("Ha {0} in {1}.|E' aumentato di {2}|con gli allenamenti"),
                        nuovo.ToString(), SkillToString(s), differenza.ToString());
                    l.BackColor = Properties.Settings.Default.Color_ScattoPiu;
                }
            }
            int num = SetNumAllenamenti(l, s);
            double stima = SetStimaSkill(l, s);
            if (num != 0)
            {
                tooltext += string.Format("\n" + T("Ha {0} allenamenti in {1}"), num, SkillToString(s));
                if (l.BackColor.A == 255) l.BackColor = Properties.Settings.Default.Color_Allenamento;
            }
            if (stima > 0) tooltext += string.Format("\nStima: {0}", stima);
            if (l.Text == "18") { l.BackColor = Color.FromArgb(50, Color.DarkViolet); }
            toolSKILL.SetToolTip(l, tooltext);
        }

        public void ShowFACVT()
        {
            Internal.CurrentVT = Internal.VT.FAC;
            lS1.Text = decimal.Floor(FACPILONE).ToString();
            lS2.Text = decimal.Floor(FACTALLONATORE).ToString();
            lS4.Text = decimal.Floor(FACSECONDA).ToString();
            lS6.Text = decimal.Floor(FACTERZAALA).ToString();
            lS8.Text = decimal.Floor(FACTERZACENTRO).ToString();
            lS9.Text = decimal.Floor(FACMM).ToString();
            lS10.Text = decimal.Floor(FACMA).ToString();
            lS11.Text = decimal.Floor(FACALA).ToString();
            lS12.Text = decimal.Floor(FACCENTRO).ToString();
            lS15.Text = decimal.Floor(FACESTREMO).ToString();
        }

        public void ShowFCDVT()
        {
            Internal.CurrentVT = Internal.VT.FCD;
            lS1.Text = decimal.Floor(FCDPILONE).ToString();
            lS2.Text = decimal.Floor(FCDTALLONATORE).ToString();
            lS4.Text = decimal.Floor(FCDSECONDA).ToString();
            lS6.Text = decimal.Floor(FCDTERZAALA).ToString();
            lS8.Text = decimal.Floor(FCDTERZACENTRO).ToString();
            lS9.Text = decimal.Floor(FCDMM).ToString();
            lS10.Text = decimal.Floor(FCDMA).ToString();
            lS11.Text = decimal.Floor(FCDALA).ToString();
            lS12.Text = decimal.Floor(FCDCENTRO).ToString();
            lS15.Text = decimal.Floor(FCDESTREMO).ToString();
        }

        public void ShowRMVT()
        {
            Internal.CurrentVT = Internal.VT.RM;
            lS1.Text = _PILONE.ToString();
            lS2.Text = _TALLONATORE.ToString();
            lS4.Text = _SECONDALINEA.ToString();
            lS6.Text = _TERZALINEAALA.ToString();
            lS8.Text = _TERZALINEACENTRO.ToString();
            lS9.Text = _MEDIANODIMISCHIA.ToString();
            lS10.Text = _MEDIANODIAPERTURA.ToString();
            lS11.Text = _ALA.ToString();
            lS12.Text = _CENTRO.ToString();
            lS15.Text = _ESTREMO.ToString(); 
        }

        private void CompareGiorni(Label l)
        {
            try
            {
                DateTime comprato = GetDays();
                if (comprato != DateTime.MinValue)
                {
                    TimeSpan tempo = DateTime.Now - comprato;
                    l.Text = tempo.TotalDays.ToString("###.0");
                    if (tempo < TimeSpan.FromDays(49))
                    {
                        comprato += TimeSpan.FromDays(49);
                        string v = string.Format(T("Sarà vendibile il {0}"), comprato.ToString());
                        toolSKILL.SetToolTip(l, v);
                    }
                }
            }
            catch (Exception ex) { My.Box.Info("Player::CompareGiorni()\r\n"+ex.Message); }
        }

        private double SetStimaSkill(Label l, Skill s)
        {
            string sql = ""; DataTable dt = null;
            int S, S1, S2; S = S1 = S2 = 0;
            double SX = 0;
            switch (s)
            {
                case Skill.Ricezione:
                    sql = string.Format("SELECT skill_handling,experience,receptionb FROM players WHERE (id={0}) ORDER BY data DESC LIMIT 1", ID);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        S1 = System.Convert.ToInt32(dt.Rows[0][0].ToString());
                        S2 = System.Convert.ToInt32(dt.Rows[0][1].ToString());
                        S = System.Convert.ToInt32(dt.Rows[0][2].ToString());
                        SX = ((18.0 / 88.0) * S1) - ((12.0 / 88.0) * S2);
                    }
                    break;
                case Skill.Passaggi:
                    sql = string.Format("SELECT skill_passing,experience,passe FROM players WHERE (id={0}) ORDER BY data DESC LIMIT 1", ID);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        S1 = System.Convert.ToInt32(dt.Rows[0][0].ToString());
                        S2 = System.Convert.ToInt32(dt.Rows[0][1].ToString());
                        S = System.Convert.ToInt32(dt.Rows[0][2].ToString());
                        SX = ((18.0 / 88.0) * S1) - ((12.0 / 88.0) * S2);
                    }
                    break;
                case Skill.Forza:
                    sql = string.Format("SELECT skill_powera,skill_powerd,puissance FROM players WHERE (id={0}) ORDER BY data DESC LIMIT 1", ID);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        S1 = System.Convert.ToInt32(dt.Rows[0][0].ToString());
                        S2 = System.Convert.ToInt32(dt.Rows[0][1].ToString());
                        S = System.Convert.ToInt32(dt.Rows[0][2].ToString());
                        SX = ((6.0 / 25.0) * S1) - ((3.0 / 50.0) * S2);
                    }
                    break;
                case Skill.Placcaggi:
                    sql = string.Format("SELECT skill_powera,skill_powerd,placage FROM players WHERE (id={0}) ORDER BY data DESC LIMIT 1", ID);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        S1 = System.Convert.ToInt32(dt.Rows[0][0].ToString());
                        S2 = System.Convert.ToInt32(dt.Rows[0][1].ToString());
                        S = System.Convert.ToInt32(dt.Rows[0][2].ToString());
                        SX = ((6.0 / 25.0) * S2) - ((3.0 / 50.0) * S1);
                    }
                    break;
                case Skill.Velocita:
                    sql = string.Format("SELECT skill_speeda,skill_speedd,rapidite FROM players WHERE (id={0}) ORDER BY data DESC LIMIT 1", ID);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        S1 = System.Convert.ToInt32(dt.Rows[0][0].ToString());
                        S2 = System.Convert.ToInt32(dt.Rows[0][1].ToString());
                        S = System.Convert.ToInt32(dt.Rows[0][2].ToString());
                        SX = ((6.0 / 25.0) * S1) - ((3.0 / 50.0) * S2);
                    }
                    break;
                case Skill.Calci:
                    sql = string.Format("SELECT skill_kicker,kicking FROM players WHERE (id={0}) ORDER BY data DESC LIMIT 1", ID);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        S1 = System.Convert.ToInt32(dt.Rows[0][0].ToString());
                        S = System.Convert.ToInt32(dt.Rows[0][1].ToString());
                        SX = S1 / 100.00 * 18.00;
                    }
                    break;
            }
            if (S > 0)
            {
                SX = Math.Floor(SX * 100) / 100;
                if (SX >= (S + 1)) SetSkill(s, (S + 0.99).ToString());
                else if (SX > S) SetSkill(s, SX.ToString());
            }
            return SX;
        }

        private int SetNumAllenamenti(Label l, Skill s)
        {
            try
            {
                int val = System.Convert.ToInt32(l.Text);
                if (val == 18) return 0;
                string skill = GetStringValue(s);
                string skill2 = GetDBStringFromSkill(s);
                string sql = string.Format("SELECT data FROM players WHERE (id={0}) AND ({1}={2}) ORDER BY data ASC",ID,skill,val);
                DataTable dt = Internal.DB.ExecuteQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    string data = dt.Rows[0][0].ToString();
                    DateTime date = DateTime.Parse(data);
                    string d = My.SQLLite.DateToSQLite(date);
                    sql = string.Format("SELECT * FROM events WHERE (player='{0}') AND (detail='{1}') AND (tipo='allenamento') AND (data>='{2}') ORDER BY data DESC", ID, skill2,d);
                    dt = Internal.DB.ExecuteQuery(sql);
                    if(dt.Rows.Count > 0)
                    {
                        string valore = "";
                        double all = (double)dt.Rows.Count;
                        double vva = (double)val;
                        double a1 = (double)80; double a2 = (double)0.075/(double)8;
                        double e1 = (double)0.325; double e2 = (double)0.875 / (double)4;
                        // NUOVO SCHEMA ALLENAMENTI
                        if (ETA<21) valore = Math.Floor((e1-(vva/a1))*all*10).ToString();
                        else valore = Math.Floor((e2 - (vva*a2)) * all*10).ToString();
                        SetSkill(s, val.ToString() + "." + valore);
                    }
                    return dt.Rows.Count;
                }
            }
#if(DEBUG)
            catch (Exception ex) { My.Box.Info(ex.Message); }
#else
            catch {}
#endif
            return 0;
        }

        private DateTime GetDays()
        {
            string data = "";
            try
            {
                string sql = string.Format("SELECT data FROM events WHERE (player='{0}') ORDER BY data ASC LIMIT 1",ID);
                DataTable dt = Internal.DB.ExecuteQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    data = dt.Rows[0][0].ToString();
                    DateTime date = DateTime.Parse(data);
                    return date;
                }
            }
            catch (Exception ex) { My.Box.Info(data+"\r\n"+ex.Message); }
            return DateTime.MinValue;
        }

        public static Skill GetSkillFromString(string from)
        {
            switch (from)
            {
                default:
                case "Eta":
                case "RMO.Control.Player.Skill.Eta": return Skill.Eta;
                case "Ala":
                case "RMO.Control.Player.Skill.Ala": return Skill.Ala;
                case "Altezza":
                case "RMO.Control.Player.Skill.Altezza": return Skill.Altezza;
                case "Calci":
                case "RMO.Control.Player.Skill.Calci": return Skill.Calci;
                case "Categoria":
                case "RMO.Control.Player.Skill.Categoria": return Skill.Categoria;
                case "Centro":
                case "RMO.Control.Player.Skill.Centro": return Skill.Centro;
                case "Cognome":
                case "RMO.Control.Player.Skill.Cognome": return Skill.Cognome;
                case "Esperienza":
                case "RMO.Control.Player.Skill.Esperienza": return Skill.Esperienza;
                case "Estremo":
                case "RMO.Control.Player.Skill.Estremo": return Skill.Estremo;
                case "Forza":
                case "RMO.Control.Player.Skill.Forza": return Skill.Forza;
                case "Giorni":
                case "RMO.Control.Player.Skill.Giorni": return Skill.Giorni;
                case "Id":
                case "RMO.Control.Player.Skill.Id": return Skill.Id;
                case "MedianoDiApertura":
                case "RMO.Control.Player.Skill.MedianoDiApertura": return Skill.MedianoDiApertura;
                case "MedianoDiMischia":
                case "RMO.Control.Player.Skill.MedianoDiMischia": return Skill.MedianoDiMischia;
                case "Nome":
                case "RMO.Control.Player.Skill.Nome": return Skill.Nome;
                case "Passaggi":
                case "RMO.Control.Player.Skill.Passaggi": return Skill.Passaggi;
                case "Peso":
                case "RMO.Control.Player.Skill.Peso": return Skill.Peso;
                case "Pilone":
                case "RMO.Control.Player.Skill.Pilone": return Skill.Pilone;
                case "Placcaggi":
                case "RMO.Control.Player.Skill.Placcaggi": return Skill.Placcaggi;
                case "Resistenza":
                case "RMO.Control.Player.Skill.Resistenza": return Skill.Resistenza;
                case "Ricezione":
                case "RMO.Control.Player.Skill.Ricezione": return Skill.Ricezione;
                case "Salario":
                case "RMO.Control.Player.Skill.Salario": return Skill.Salario;
                case "SecondaLinea":
                case "RMO.Control.Player.Skill.SecondaLinea": return Skill.SecondaLinea;
                case "Stato":
                case "RMO.Control.Player.Skill.Stato": return Skill.Stato;
                case "Tallonatore":
                case "RMO.Control.Player.Skill.Tallonatore": return Skill.Tallonatore;
                case "TerzaLineaAla":
                case "RMO.Control.Player.Skill.TerzaLineaAla": return Skill.TerzaLineaAla;
                case "TerzaLineaCentro":
                case "RMO.Control.Player.Skill.TerzaLineaCentro": return Skill.TerzaLineaCentro;
                case "Velocita":
                case "RMO.Control.Player.Skill.Velocita": return Skill.Velocita;
            }
            return Skill.Id;
        }

        /// <summary>
        /// Da usare solo per query sul DB
        /// </summary>
        private string GetDBStringFromSkill(Skill s)
        {
            switch (s)
            {
                case Skill.Resistenza: return "resistenza";
                case Skill.Forza: return "forza";
                case Skill.Placcaggi: return "placcaggi";
                case Skill.Velocita: return "velocità";
                case Skill.Passaggi: return "passaggi";
                case Skill.Ricezione: return "ricezione";
                case Skill.Calci: return "calci";
            }
            return "";
        }

        public static string SkillToString(Skill s)
        {
            switch (s)
            {
                case Skill.Resistenza: return T("resistenza");
                case Skill.Forza: return T("forza");
                case Skill.Placcaggi: return T("placcaggi");
                case Skill.Velocita: return T("velocità");
                case Skill.Passaggi: return T("passaggi");
                case Skill.Ricezione: return T("ricezione");
                case Skill.Calci: return T("calci");
                case Skill.Esperienza: return T("esperienza");

                default: return T(s.ToString());
            }
            return "";
        }

        private void CompareSkillStd(Label l, DataRow dr, Skill s, string soggetto, string unità)
        {
            string vecchiostr = dr[S(s)].ToString();
            //if (l.Text == vecchiostr) return;
            decimal nuovo = System.Convert.ToDecimal(l.Text);
            decimal vecchio = System.Convert.ToDecimal(vecchiostr);
            decimal differenza = (nuovo - vecchio);
            string msg = "";
            l.Tag = "variazione";
            if (differenza < 0)
            {
                msg = string.Format(T("{0} è diminuito di {1}{2}"), soggetto, Math.Abs(differenza).ToString(), unità);
                l.BackColor = Properties.Settings.Default.Color_ScattoMeno;
            }
            else if (differenza > 0)
            {
                msg = string.Format(T("{0} è aumentato di {1}{2}"), soggetto, differenza.ToString(), unità);
                l.BackColor = Properties.Settings.Default.Color_ScattoPiu;
            }

            virtual_stipendio = CalcolaStipendio(FORZA, PLACCAGGI, VELOCITA, PASSAGGI, RICEZIONE, CALCI);
            virtual_next = CalcolaStipendioNext(FORZA, PLACCAGGI, VELOCITA, PASSAGGI, RICEZIONE, CALCI);
            virtual_base = CalcolaStipendioBase(FORZA, PLACCAGGI, VELOCITA, PASSAGGI, RICEZIONE, CALCI);
            virtual_diff = (int)(SALARIO - virtual_stipendio);
            if (virtual_diff > 0)
            {
                if (msg != "") msg += "\r\n";
                msg += string.Format(T("Guadagna {0} € più del previsto!") + "\r\n", virtual_diff);
                msg += string.Format(T("Stipendio base: {0} €") + "\r\n", virtual_base);
                msg += string.Format(T("Stipendio massimo: {0} €") + "\r\n", virtual_next);
                msg += string.Format(T("Stipendio previsto: {0} €") + "\r\n", virtual_stipendio);
                if (msg != "") l.Paint += new PaintEventHandler(Stipendio_Paint);
            }

            if (msg != "") toolSKILL.SetToolTip(l, msg);
        }

        private void CompareStipendio(Label l)
        {
            virtual_stipendio = CalcolaStipendio(FORZA, PLACCAGGI, VELOCITA, PASSAGGI, RICEZIONE, CALCI);
            virtual_next = CalcolaStipendioNext(FORZA, PLACCAGGI, VELOCITA, PASSAGGI, RICEZIONE, CALCI);
            virtual_base = CalcolaStipendioBase(FORZA, PLACCAGGI, VELOCITA, PASSAGGI, RICEZIONE, CALCI);
            virtual_diff = (int)(SALARIO - virtual_stipendio);
            if (virtual_diff > 0)
            {
                string msg = "";
                msg += string.Format(T("Guadagna {0} € più del previsto!") + "\r\n", virtual_diff);
                msg += string.Format(T("Stipendio base: {0} €") + "\r\n", virtual_base);
                msg += string.Format(T("Stipendio massimo: {0} €") + "\r\n", virtual_next);
                msg += string.Format(T("Stipendio previsto: {0} €") + "\r\n", virtual_stipendio);
                if (msg != "")
                {
                    toolSKILL.SetToolTip(l, msg);
                    l.Paint += new PaintEventHandler(Stipendio_Paint);
                }
            }
        }

        private int virtual_base = 0;
        private int virtual_stipendio = 0;
        private int virtual_diff = 0;
        private int virtual_next = 0;
        private void Stipendio_Paint(object sender, PaintEventArgs e)
        {
            if (virtual_stipendio==0) return;
            if (virtual_diff == 0) return;
            Label l = (Label)sender;
            int s1 = SALARIO - virtual_base;
            int s2 = virtual_next - virtual_base;
            decimal y = (decimal)((s1 * l.Height) / (double)s2);
            int j = (int)decimal.Truncate(y);
            if (j > l.Height) j = l.Height;
            //e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(0,0,l.Width-1,l.Height-1));
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(l.Width-3,l.Height-j,2,l.Height));
        }

        public static int CalcolaStipendioNext(decimal a, decimal b, decimal c, decimal d, decimal e, decimal f)
        {
            double aa = (double)decimal.Truncate(a);
            double bb = (double)decimal.Truncate(b);
            double cc = (double)decimal.Truncate(c);
            double dd = (double)decimal.Truncate(d);
            double ee = (double)decimal.Truncate(e);
            double ff = (double)decimal.Truncate(f);
            return CalcolaStipendio(aa + 1, bb + 1, cc + 1, dd + 1, ee + 1, ff + 1);
        }
        public static int CalcolaStipendioBase(decimal a, decimal b, decimal c, decimal d, decimal e, decimal f)
        {
            double aa = (double)decimal.Truncate(a);
            double bb = (double)decimal.Truncate(b);
            double cc = (double)decimal.Truncate(c);
            double dd = (double)decimal.Truncate(d);
            double ee = (double)decimal.Truncate(e);
            double ff = (double)decimal.Truncate(f);
            return CalcolaStipendio(aa, bb, cc, dd, ee, ff);
        }
        public static int CalcolaStipendio(decimal a, decimal b, decimal c, decimal d, decimal e, decimal f)
        { return CalcolaStipendio((double)a,(double)b,(double)c,(double)d,(double)e,(double)f); }
        public static int CalcolaStipendio(double a,double b,double c, double d, double e, double f)
        {
            double result = Math.Pow(a, 2);
            result += Math.Pow(b, 2); 
            result += Math.Pow(c, 2);
            result += Math.Pow(d, 2);
            result += Math.Pow(e, 2);
            result += Math.Pow(f, 2);
            result = result * 10;
            return (int)result;
        }

        private void CompareSkill2(Label l, DataRow dr, Skill s)
        {
            string vecchiostr = dr[S(s)].ToString();
            string msg = SkillToString(s) +"\r\n" ;
            if (l.Text == vecchiostr)
            {
                if (l.Text == "0") msg += T("Nessuna valutazione");
                else msg += string.Format("RM VT: {0}", l.Text);
            }
            else
            {
                decimal nuovo = System.Convert.ToDecimal(l.Text);
                decimal vecchio = System.Convert.ToDecimal(vecchiostr);
                decimal differenza = (nuovo - vecchio);
                l.Tag = "Allenamento";
                if (differenza < 0)
                {
                    msg = string.Format(T("Fa {0} come {1}.\r\nE' diminuito di {2}\r\ncon l'età"),
                        nuovo.ToString(), SkillToString(s), Math.Abs(differenza).ToString());
                    l.BackColor = Properties.Settings.Default.Color_ScattoMeno;
                }
                else
                {
                    if (vecchio == 0)
                    {
                        msg = string.Format(T("Fa {0} come {1}.\r\nNuova valutazione!"),
                            nuovo.ToString(), SkillToString(s));
                        l.BackColor = Color.FromArgb(50, Color.Green);
                    }
                    else
                    {
                        msg = string.Format(T("Fa {0} come {1}.\r\nE' aumentato di {2}\r\ncon gli allenamenti"),
                            nuovo.ToString(), SkillToString(s), differenza.ToString());
                        l.BackColor = Properties.Settings.Default.Color_ScattoPiu;
                    }
                }
            }
            switch (s)
            {
                case Skill.Pilone:              
                    msg += string.Format("\r\nFAC VT: {0}", FACPILONE);
                    msg += string.Format("\r\nFCD VT: {0}", FCDPILONE); 
                    break;
                case Skill.Tallonatore:         
                    msg += string.Format("\r\nFAC VT: {0}", FACTALLONATORE);
                    msg += string.Format("\r\nFCD VT: {0}", FCDTALLONATORE); 
                    break;
                case Skill.SecondaLinea:        
                    msg += string.Format("\r\nFAC VT: {0}", FACSECONDA);
                    msg += string.Format("\r\nFCD VT: {0}", FCDSECONDA); 
                    break;
                case Skill.TerzaLineaAla:       
                    msg += string.Format("\r\nFAC VT: {0}", FACTERZAALA);
                    msg += string.Format("\r\nFCD VT: {0}", FCDTERZAALA); 
                    break;
                case Skill.TerzaLineaCentro:    
                    msg += string.Format("\r\nFAC VT: {0}", FACTERZACENTRO);
                    msg += string.Format("\r\nFCD VT: {0}", FCDTERZACENTRO); 
                    break;
                case Skill.MedianoDiMischia:    
                    msg += string.Format("\r\nFAC VT: {0}", FACMM);
                    msg += string.Format("\r\nFCD VT: {0}", FCDMM); 
                    break;
                case Skill.MedianoDiApertura:   
                    msg += string.Format("\r\nFAC VT: {0}", FACMA);
                    msg += string.Format("\r\nFCD VT: {0}", FCDMA); 
                    break;
                case Skill.Centro:              
                    msg += string.Format("\r\nFAC VT: {0}", FACCENTRO);
                    msg += string.Format("\r\nFCD VT: {0}", FCDCENTRO); 
                    break;
                case Skill.Ala:                 
                    msg += string.Format("\r\nFAC VT: {0}", FACALA);
                    msg += string.Format("\r\nFCD VT: {0}", FCDALA); 
                    break;
                case Skill.Estremo:             
                    msg += string.Format("\r\nFAC VT: {0}", FACESTREMO);
                    msg += string.Format("\r\nFCD VT: {0}", FCDESTREMO); 
                    break;
            }
            if (msg!="") toolSKILL.SetToolTip(l, msg);
        }

        private void CompareSkill3(Label l, DataRow dr, Skill s)
        {
            string vecchiostr = dr[S(s)].ToString();
            decimal nuovo = System.Convert.ToDecimal(l.Text);
            decimal vecchio = System.Convert.ToDecimal(vecchiostr);
            string msg = "";
            vecchio = vecchio / 100;
            msg = string.Format("Pesa {0} kg.", l.Text);

            if (nuovo > vecchio)
            {
                l.BackColor = Properties.Settings.Default.Color_ScattoPiu;
                l.Tag = "Allenamento";
                msg += string.Format("\r\n"+T("E' aumentato di {0} kg|con la dieta"), (nuovo - vecchio).ToString());
            }

            msg += string.Format("\r\nFAC VT: {0}", PESOSKILL);

            // Calcolo del peso limite
            decimal max = decimal.Subtract(ALTEZZA,70);
            if (max > (decimal)123.75) max = (decimal)123.75;
            if (nuovo == max)
            {
                msg += "\r\n "+T("Ha raggiunto il suo peso limite!");
                l.BackColor = Color.FromArgb(50, Color.DarkViolet);
                l.Tag = "Limite";
            }
            else msg += string.Format("\r\n"+T("Peso MAX: {0} kg"), max);
            toolSKILL.SetToolTip(l, msg);
        }

        private void SetPesoLimite(Label l)
        {
            // Calcolo del peso limite
            string msg = string.Format(T("Pesa {0} kg."), l.Text);
            msg += string.Format("\r\nFAC VT: {0}", PESOSKILL);
            decimal max = decimal.Subtract(ALTEZZA, 70);
            if (max > (decimal)123.75) max = (decimal)123.75;
            decimal attuale = decimal.Divide((decimal)PESO,(decimal)100);
            if (attuale == max)
            {
                msg += "\r\n "+T("Ha raggiunto il suo peso limite!");
                l.BackColor = Color.FromArgb(50, Color.DarkViolet);
                l.Tag = "Limite";
            }
            else msg += string.Format("\r\n"+T("Peso MAX: {0} kg"), max);
            toolSKILL.SetToolTip(l, msg);
        }

        private void CheckToolTip()
        {
            string nome = string.Format("{0} {1}", lCOGNOME.Text, lNOME.Text);
            // ID
            this.toolSKILL.SetToolTip(lID, T("Cliccando qui visiterai la sua pagina"));
            // ETA
            this.toolETA.ToolTipTitle = nome;
            int eta = System.Convert.ToInt16(lETA.Text);
            if (eta < 21)
            {
                lETA.Tag = "Under21";
                this.toolETA.SetToolTip(lETA, string.Format(T("Ha {0} anni è quindi Under 21"), lETA.Text));
            }
            else if (eta < 26)
            {
                lETA.Tag = "Under26";
                this.toolETA.SetToolTip(lETA, string.Format(T("Ha {0} anni è quindi Under 26"), lETA.Text));
            }
            else this.toolETA.SetToolTip(lETA, string.Format(T("Ha {0} anni."), lETA.Text));
            // GIORNI
            if (GIORNI >= 49)
            {
                lGIORNI.Tag = "Vendibile";
                toolSKILL.SetToolTip(lGIORNI, T("Questo giocatore è vendibile!"));
            }
            this.toolSKILL.ToolTipTitle = nome;
        }

        private void CheckColors()
        {
            int eta = System.Convert.ToInt16(lETA.Text);
            if (eta < 21) lETA.BackColor = Properties.Settings.Default.Color_U21;
            else if (eta < 26) lETA.BackColor = Properties.Settings.Default.Color_U25;
            if (GIORNI >= 49) lGIORNI.BackColor = Color.FromArgb((GIORNI<90) ? (int)(90-GIORNI):10 , Color.Red); 
        }

        public static int MINWIDTH = 20;
        public static int[] MAX = new int[31];
        public static void MAXRESET() { for (int i = 0; i < MAX.Length; i++) MAX[i] = MINWIDTH; }

        private void CheckSize()
        {
            GetMAX(lID,Skill.Id);
            GetMAX(lNOME, Skill.Nome);
            GetMAX(lCOGNOME,Skill.Cognome);
            GetMAX(lSTATO,Skill.Stato);
            GetMAX(lCATEGORIA,Skill.Categoria);
            GetMAX(lETA,Skill.Eta);
            GetMAX(lALTEZZA, Skill.Altezza);
            GetMAX(lPESO, Skill.Peso);

            GetMAX(lRESISTENZA, Skill.Resistenza);
            GetMAX(lFORZA, Skill.Forza);
            GetMAX(lPLACCAGGI, Skill.Placcaggi);
            GetMAX(lVELOCITA, Skill.Velocita);
            GetMAX(lPASSAGGI, Skill.Passaggi);
            GetMAX(lRICEZIONE, Skill.Ricezione);
            GetMAX(lCALCI, Skill.Calci);
            GetMAX(lESPERIENZA, Skill.Esperienza);

            GetMAX(lGIORNI, Skill.Giorni);
            GetMAX(lSALARIO, Skill.Salario);
            GetMAX(lS1, Skill.Pilone);
            GetMAX(lS2, Skill.Tallonatore);
            GetMAX(lS4, Skill.SecondaLinea);
            GetMAX(lS6, Skill.TerzaLineaAla);
            GetMAX(lS8, Skill.TerzaLineaCentro);
            GetMAX(lS9, Skill.MedianoDiMischia);
            GetMAX(lS10, Skill.MedianoDiApertura);
            GetMAX(lS11, Skill.Ala);
            GetMAX(lS12, Skill.Centro);
            GetMAX(lS15, Skill.Estremo);
        }

        private void GetMAX(System.Windows.Forms.Control c, Skill s)
        {
            int w = c.Width;
            // Alcuni nomi non rientrano comunque nel massimo individuato
            if (s == Skill.Nome) w += 4;
            else if (s == Skill.Cognome) w += 4;
            // Se visualizzata la bandiera w=32
            if ((s == Skill.Stato) && (Flag != null)) w = 32;
            if (MAX[(int)s] < w) MAX[(int)s] = w;
        }
        private void SetMAX(System.Windows.Forms.Control c, Skill s)
        {
            c.Width = MAX[(int)s];
        }

        public void SetSize()
        {
            foreach (System.Windows.Forms.Label c in Controls) c.AutoSize = false;
            
            SetMAX(lID, Skill.Id);
            SetMAX(lNOME, Skill.Nome);
            SetMAX(lCOGNOME, Skill.Cognome);
            SetMAX(lSTATO, Skill.Stato);
            SetMAX(lCATEGORIA, Skill.Categoria);
            SetMAX(lETA, Skill.Eta);
            SetMAX(lALTEZZA, Skill.Altezza);
            SetMAX(lPESO, Skill.Peso);

            SetMAX(lRESISTENZA, Skill.Resistenza);
            SetMAX(lFORZA, Skill.Forza);
            SetMAX(lPLACCAGGI, Skill.Placcaggi);
            SetMAX(lVELOCITA, Skill.Velocita);
            SetMAX(lPASSAGGI, Skill.Passaggi);
            SetMAX(lRICEZIONE, Skill.Ricezione);
            SetMAX(lCALCI, Skill.Calci);
            SetMAX(lESPERIENZA, Skill.Esperienza);

            SetMAX(lGIORNI, Skill.Giorni);
            SetMAX(lSALARIO, Skill.Salario);
            SetMAX(lS1, Skill.Pilone);
            SetMAX(lS2, Skill.Tallonatore);
            SetMAX(lS4, Skill.SecondaLinea);
            SetMAX(lS6, Skill.TerzaLineaAla);
            SetMAX(lS8, Skill.TerzaLineaCentro);
            SetMAX(lS9, Skill.MedianoDiMischia);
            SetMAX(lS10, Skill.MedianoDiApertura);
            SetMAX(lS11, Skill.Ala);
            SetMAX(lS12, Skill.Centro);
            SetMAX(lS15, Skill.Estremo);

            Width = lS15.Right;
        }

        public enum Skill : int
        {
            [StringValue("id")]         Id = 0,
            [StringValue("nom")]        Nome = 1,
            [StringValue("prenom")]     Cognome = 2,
            [StringValue("country")]    Stato = 3,
            [StringValue("category")]   Categoria = 4,
            [StringValue("age")]        Eta = 5,
            [StringValue("experience")] Esperienza = 6,
            [StringValue("salaire")]    Salario = 7,
            [StringValue("placage")]    Placcaggi = 8,
            [StringValue("puissance")]  Forza = 9,
            [StringValue("passe")]      Passaggi = 10,
            [StringValue("receptionb")] Ricezione = 11,
            [StringValue("endurance")]  Resistenza = 12,
            [StringValue("size")]       Altezza = 13,
            [StringValue("weight")]     Peso = 14,
            [StringValue("rapidite")]   Velocita = 15,
            [StringValue("kicking")]    Calci = 16,
            [StringValue("arrivee")]    Giorni = 17,
            [StringValue("stat1")]      Pilone = 18,
            [StringValue("stat2")]      Tallonatore = 19,
            [StringValue("stat4")]      SecondaLinea = 20,
            [StringValue("stat6")]      TerzaLineaAla = 21,
            [StringValue("stat8")]      TerzaLineaCentro = 22,
            [StringValue("stat9")]      MedianoDiMischia = 23,
            [StringValue("stat10")]     MedianoDiApertura = 24,
            [StringValue("stat11")]     Ala = 25,
            [StringValue("stat12")]     Centro = 26,
            [StringValue("stat15")]     Estremo = 27
        }
        private static System.Collections.Hashtable _stringValues = new System.Collections.Hashtable();
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            //Check first in our cached results...
            if (_stringValues.ContainsKey(value))
                output = (_stringValues[value] as StringValueAttribute).Value;
            else
            {
                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                StringValueAttribute[] attrs =
                   fi.GetCustomAttributes(typeof(StringValueAttribute),
                                           false) as StringValueAttribute[];
                if (attrs.Length > 0)
                {
                    _stringValues.Add(value, attrs[0]);
                    output = attrs[0].Value;
                }
            }

            return output;
        }
        public class StringValueAttribute : System.Attribute
        {
            private string _value;
            public StringValueAttribute(string value)
            {
                _value = value;
            }
            public string Value
            {
                get { return _value; }
            }
        }

        private void lValutazione_TextChanged(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            if (l.Text == "0") l.ForeColor = Properties.Settings.Default.Skill_0;
        }

    }

}
