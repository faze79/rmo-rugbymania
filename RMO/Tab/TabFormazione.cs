using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabFormazione : UserControl
    {
        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        public TabFormazione()
        {
            InitializeComponent();
            textOrder.Text = Properties.Settings.Default.OrdineFormazione;
            Internal.DB.OnTeamAdded += new EventHandler(DB_OnTeamAdded);
        }

        private void DB_OnTeamAdded(object sender, EventArgs e)
        {
            LoadFromDB();
        }

        public TabPage GetTab()
        {
            T(this);
            return this.pageMain;
        }

        private bool LOADING = false;

        private Class.Player[] Players = null;
        private bool RELOADDATA = true;
        public void LoadFromDB()
        {
            LOADING = true;
            comboDa.Enabled = false;
            try
            {
                if (RELOADDATA)
                {
                    comboDa.Items.Clear();
                    comboDa.Items.AddRange(Internal.DB.GetDates());
                    if (comboDa.Items.Count>0) comboDa.SelectedIndex = 0;
                }
                if (comboDa.SelectedIndex < 0) return;
                string data = comboDa.Items[comboDa.SelectedIndex].ToString();
                DataTable DT_NEW = Internal.DB.GetPlayers(data);
                Players = new RMO.Class.Player[DT_NEW.Rows.Count];
                int i = 0;
                foreach (DataRow dr in DT_NEW.Rows)
                {
                    Class.Player p = new RMO.Class.Player();
                    p.LoadData(dr, data);
                    Players[i] = p; i++;
                }
                FillCombo(c1, Players); FillCombo(c2, Players); FillCombo(c3, Players);
                FillCombo(c4, Players); FillCombo(c5, Players); FillCombo(c6, Players);
                FillCombo(c7, Players); FillCombo(c8, Players); FillCombo(c9, Players);
                FillCombo(c10, Players); FillCombo(c11, Players); FillCombo(c12, Players);
                FillCombo(c13, Players); FillCombo(c14, Players); FillCombo(c15, Players);
            }
            catch (Exception ex) { My.Box.Info(ex.Message); }
            //BestTeam();
            comboDa.Enabled = true;
            LOADING = false;
        }

        private void FillCombo(ComboBox c, object[] p)
        {
            string old = "";
            if (c.SelectedIndex >= 0) old = c.Items[c.SelectedIndex].ToString();
            c.Items.Clear();
            c.Items.AddRange(p);
            if (old != "") c.SelectedIndex = c.FindStringExact(old);
            c.Enabled = true;
        }

        private void panelFormazione_SizeChanged(object sender, EventArgs e)
        {
            int x = (panelFormazione.Width - l2.Width) / 2;
            int xx = ((panelFormazione.Width / 2) - l4.Width) / 2;
            int xxx = xx + (panelFormazione.Width / 2);

            panelFormazione.SuspendLayout();
            
            l2.Location = new Point(x, l2.Location.Y);
            c2.Location = new Point(x, c2.Location.Y);
            l8.Location = new Point(x, l8.Location.Y);
            c8.Location = new Point(x, c8.Location.Y);
            l15.Location = new Point(x, l15.Location.Y);
            c15.Location = new Point(x, c15.Location.Y);

            panelFormazione.ResumeLayout();
        }

        private void BestTeam()
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (Class.Player p in Players) list.Add(p);
        }

        private Class.Player BestRule(System.Collections.ArrayList list, int i)
        {
            Class.Player result = null;
            int val = 0;
            foreach (Class.Player p in list)
            {
                switch (i)
                {
                    case 1: 
                    case 3:
                        if (p.PILONE > val) { result = p; val = p.PILONE; }
                        break;
                    case 2:
                        if (p.TALLONATORE > val) { result = p; val = p.TALLONATORE; }
                        break;
                    case 4:
                    case 5:
                        if (p.SECONDALINEA > val) { result = p; val = p.SECONDALINEA; }
                        break;
                    case 6:
                    case 7:
                        if (p.TERZALINEAALA > val) { result = p; val = p.TERZALINEAALA; }
                        break;
                    case 8:
                        if (p.TERZALINEACENTRO > val) { result = p; val = p.TERZALINEACENTRO; }
                        break;
                    case 9:
                        if (p.MEDIANODIMISCHIA > val) { result = p; val = p.MEDIANODIMISCHIA; }
                        break;
                    case 10:
                        if (p.MEDIANODIAPERTURA > val) { result = p; val = p.MEDIANODIAPERTURA; }
                        break;
                    case 11:
                    case 14:
                        if (p.ALA > val) { result = p; val = p.ALA; }
                        break;
                    case 12:
                    case 13:
                        if (p.CENTRO > val) { result = p; val = p.CENTRO; }
                        break;
                    case 15:
                        if (p.ESTREMO > val) { result = p; val = p.ESTREMO; }
                        break;
                }
            }
            SelectPlayer(result, i);
            return result;
        }

        private void SelectPlayer(Class.Player p, int i)
        {
            switch (i)
            {
                case 1: c1.SelectedItem = p; break;
                case 2: c2.SelectedItem = p; break;
                case 3: c3.SelectedItem = p; break;
                case 4: c4.SelectedItem = p; break;
                case 5: c5.SelectedItem = p; break;
                case 6: c6.SelectedItem = p; break;
                case 7: c7.SelectedItem = p; break;
                case 8: c8.SelectedItem = p; break;
                case 9: c9.SelectedItem = p; break;
                case 10: c10.SelectedItem = p; break;
                case 11: c11.SelectedItem = p; break;
                case 12: c12.SelectedItem = p; break;
                case 13: c13.SelectedItem = p; break;
                case 14: c14.SelectedItem = p; break;
                case 15: c15.SelectedItem = p; break;
            }
        }

        private void ComboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcolaValutazioneTotale();
        }

        private void ComboPlayer_DropDown(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            string old = "";
            if (c.SelectedIndex>=0) old = c.Items[c.SelectedIndex].ToString();
            c.Items.Clear();
            if (c==c1) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Pilone));
            else if (c == c2) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Tallonatore));
            else if (c == c3) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Pilone));
            else if (c == c4) c.Items.AddRange(Sort(RMO.Control.Player.Skill.SecondaLinea));
            else if (c == c5) c.Items.AddRange(Sort(RMO.Control.Player.Skill.SecondaLinea));
            else if (c == c6) c.Items.AddRange(Sort(RMO.Control.Player.Skill.TerzaLineaAla));
            else if (c == c7) c.Items.AddRange(Sort(RMO.Control.Player.Skill.TerzaLineaAla));
            else if (c == c8) c.Items.AddRange(Sort(RMO.Control.Player.Skill.TerzaLineaCentro));
            else if (c == c9) c.Items.AddRange(Sort(RMO.Control.Player.Skill.MedianoDiMischia));
            else if (c == c10) c.Items.AddRange(Sort(RMO.Control.Player.Skill.MedianoDiApertura));
            else if (c == c11) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Ala));
            else if (c == c12) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Centro));
            else if (c == c13) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Centro));
            else if (c == c14) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Ala));
            else if (c == c15) c.Items.AddRange(Sort(RMO.Control.Player.Skill.Estremo));

            if ((c != c1) && (c1.SelectedIndex >= 0)) c.Items.Remove(c1.SelectedItem);
            if ((c != c2) && (c2.SelectedIndex >= 0)) c.Items.Remove(c2.SelectedItem);
            if ((c != c3) && (c3.SelectedIndex >= 0)) c.Items.Remove(c3.SelectedItem);
            if ((c != c4) && (c4.SelectedIndex >= 0)) c.Items.Remove(c4.SelectedItem);
            if ((c != c5) && (c5.SelectedIndex >= 0)) c.Items.Remove(c5.SelectedItem);
            if ((c != c6) && (c6.SelectedIndex >= 0)) c.Items.Remove(c6.SelectedItem);
            if ((c != c7) && (c7.SelectedIndex >= 0)) c.Items.Remove(c7.SelectedItem);
            if ((c != c8) && (c8.SelectedIndex >= 0)) c.Items.Remove(c8.SelectedItem);
            if ((c != c9) && (c9.SelectedIndex >= 0)) c.Items.Remove(c9.SelectedItem);
            if ((c != c10) && (c10.SelectedIndex >= 0)) c.Items.Remove(c10.SelectedItem);
            if ((c != c11) && (c11.SelectedIndex >= 0)) c.Items.Remove(c11.SelectedItem);
            if ((c != c12) && (c12.SelectedIndex >= 0)) c.Items.Remove(c12.SelectedItem);
            if ((c != c13) && (c13.SelectedIndex >= 0)) c.Items.Remove(c13.SelectedItem);
            if ((c != c14) && (c14.SelectedIndex >= 0)) c.Items.Remove(c14.SelectedItem);
            if ((c != c15) && (c15.SelectedIndex >= 0)) c.Items.Remove(c15.SelectedItem);
            if (old != "") c.SelectedIndex = c.FindStringExact(old);
        }

        private RMO.Class.Player[] Sort(Control.Player.Skill s)
        {
            RMO.Class.Player.OrderSkill = s;
            Array.Sort(Players);
            return Players;
        }

        private void CalcolaValutazioneTotale()
        {
            int vtot = 0; int vta = 0; int vtq = 0; int vt = 0;
            decimal peso = 0; int fa = 0; int pla = 0;
            int pq = 0; int rq = 0;
            int exp = 0; int counter = 0;
            if (c1.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c1.SelectedItem)).PILONE;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c1.SelectedItem)).PESO;
                fa += ((Class.Player)(c1.SelectedItem)).FORZA;
                pla += ((Class.Player)(c1.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c1.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c2.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c2.SelectedItem)).TALLONATORE;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c2.SelectedItem)).PESO;
                fa += ((Class.Player)(c2.SelectedItem)).FORZA;
                pla += ((Class.Player)(c2.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c2.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c3.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c3.SelectedItem)).PILONE;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c3.SelectedItem)).PESO;
                fa += ((Class.Player)(c3.SelectedItem)).FORZA;
                pla += ((Class.Player)(c3.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c3.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c4.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c4.SelectedItem)).SECONDALINEA;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c4.SelectedItem)).PESO;
                fa += ((Class.Player)(c4.SelectedItem)).FORZA;
                pla += ((Class.Player)(c4.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c4.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c5.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c5.SelectedItem)).SECONDALINEA;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c5.SelectedItem)).PESO;
                fa += ((Class.Player)(c5.SelectedItem)).FORZA;
                pla += ((Class.Player)(c5.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c5.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c6.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c6.SelectedItem)).TERZALINEAALA;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c6.SelectedItem)).PESO;
                fa += ((Class.Player)(c6.SelectedItem)).FORZA;
                pla += ((Class.Player)(c6.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c6.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c7.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c7.SelectedItem)).TERZALINEAALA;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c7.SelectedItem)).PESO;
                fa += ((Class.Player)(c7.SelectedItem)).FORZA;
                pla += ((Class.Player)(c7.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c7.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c8.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c8.SelectedItem)).TERZALINEACENTRO;
                vtot += vt; vta += vt;
                peso += ((Class.Player)(c8.SelectedItem)).PESO;
                fa += ((Class.Player)(c8.SelectedItem)).FORZA;
                pla += ((Class.Player)(c8.SelectedItem)).PLACCAGGI;
                exp += ((Class.Player)(c8.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c9.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c9.SelectedItem)).MEDIANODIMISCHIA;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c9.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c9.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c9.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c10.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c10.SelectedItem)).MEDIANODIAPERTURA;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c10.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c10.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c10.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c11.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c11.SelectedItem)).ALA;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c11.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c11.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c11.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c12.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c12.SelectedItem)).CENTRO;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c12.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c12.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c12.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c13.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c13.SelectedItem)).CENTRO;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c13.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c13.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c13.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c14.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c14.SelectedItem)).ALA;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c14.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c14.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c14.SelectedItem)).ESPERIENZA;
                counter++;
            }
            if (c15.SelectedIndex >= 0)
            {
                vt = ((Class.Player)(c15.SelectedItem)).ESTREMO;
                vtot += vt; vtq += vt;
                pq += ((Class.Player)(c15.SelectedItem)).PASSAGGI;
                rq += ((Class.Player)(c15.SelectedItem)).RICEZIONE;
                exp += ((Class.Player)(c15.SelectedItem)).ESPERIENZA;
                counter++;
            }
            // Scrittura totali
            tVTT.Text = vtot.ToString();
            tVTA.Text = vta.ToString();
            tVTQ.Text = vtq.ToString();
            tPA.Text = string.Format("{0} kg", peso);
            tFA.Text = fa.ToString();
            tPLA.Text = pla.ToString();
            tPQ.Text = pq.ToString();
            tRQ.Text = rq.ToString();
            tEXP.Text = ((decimal)((decimal)exp)/counter).ToString();
        }

        private void l1_Click(object sender, EventArgs e)
        {
            c1.Items.Clear();
        }

        private void l2_Click(object sender, EventArgs e)
        {
            c2.Items.Clear();
        }

        private void l3_Click(object sender, EventArgs e)
        {
            c3.Items.Clear();
        }

        private void l4_Click(object sender, EventArgs e)
        {
            c4.Items.Clear();
        }

        private void l5_Click(object sender, EventArgs e)
        {
            c5.Items.Clear();
        }

        private void l6_Click(object sender, EventArgs e)
        {
            c6.Items.Clear();
        }

        private void l7_Click(object sender, EventArgs e)
        {
            c7.Items.Clear();
        }

        private void l8_Click(object sender, EventArgs e)
        {
            c8.Items.Clear();
        }

        private void l9_Click(object sender, EventArgs e)
        {
            c9.Items.Clear();
        }

        private void l10_Click(object sender, EventArgs e)
        {
            c10.Items.Clear();
        }

        private void l11_Click(object sender, EventArgs e)
        {
            c11.Items.Clear();
        }

        private void l14_Click(object sender, EventArgs e)
        {
            c14.Items.Clear();
        }

        private void l12_Click(object sender, EventArgs e)
        {
            c12.Items.Clear();
        }

        private void l13_Click(object sender, EventArgs e)
        {
            c13.Items.Clear();
        }

        private void l15_Click(object sender, EventArgs e)
        {
            c15.Items.Clear();
        }

        private void comboDa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LOADING)
            {
                RELOADDATA = false;
                LoadFromDB();
                CalcolaValutazioneTotale();
                RELOADDATA = true;
            }
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control c in panelFormazione.Controls) 
                if (c.GetType() == typeof(ComboBox)) ((ComboBox)c).Items.Clear();

            string[] numeri = textOrder.Text.Split(new char[] { ',', ';', ' ', '.',':','-','+','\\','/'});
            foreach (string numero in numeri)
            {
                try
                {
                    int i = System.Convert.ToInt32(numero);
                    SetBest(i);
                }
                catch { }
            }
        }

        private void SetBest(int num)
        {
            Class.Player empty = new RMO.Class.Player();
            Class.Player max = empty;
            switch (num)
            {
                case 10:
                    ComboPlayer_DropDown(c10, EventArgs.Empty);
                    foreach (Class.Player p in c10.Items) if (p.MEDIANODIAPERTURA > max.MEDIANODIAPERTURA) max = p;
                    if (max != empty) c10.SelectedItem = max; max = empty;
                    break;

                case 9:
                    ComboPlayer_DropDown(c9, EventArgs.Empty);
                    foreach (Class.Player p in c9.Items) if (p.MEDIANODIMISCHIA > max.MEDIANODIMISCHIA) max = p;
                    if (max != empty) c9.SelectedItem = max; max = empty;
                    break;

                case 8:
                    ComboPlayer_DropDown(c8, EventArgs.Empty);
                    foreach (Class.Player p in c8.Items) if (p.TERZALINEACENTRO > max.TERZALINEACENTRO) max = p;
                    if (max != empty) c8.SelectedItem = max; max = empty;
                    break;

                case 2:
                    ComboPlayer_DropDown(c2, EventArgs.Empty);
                    foreach (Class.Player p in c2.Items) if (p.TALLONATORE > max.TALLONATORE) max = p;
                    if (max != empty) c2.SelectedItem = max; max = empty;
                    break;

                case 15:
                    ComboPlayer_DropDown(c15, EventArgs.Empty);
                    foreach (Class.Player p in c15.Items) if (p.ESTREMO > max.ESTREMO) max = p;
                    if (max != empty) c15.SelectedItem = max; max = empty;
                    break;

                case 4:
                    ComboPlayer_DropDown(c4, EventArgs.Empty);
                    foreach (Class.Player p in c4.Items) if (p.SECONDALINEA > max.SECONDALINEA) max = p;
                    if (max != empty) c4.SelectedItem = max; max = empty;
                    break;

                case 5:
                    ComboPlayer_DropDown(c5, EventArgs.Empty);
                    foreach (Class.Player p in c5.Items) if (p.SECONDALINEA > max.SECONDALINEA) max = p;
                    if (max != empty) c5.SelectedItem = max; max = empty;
                    break;

                case 6:
                    ComboPlayer_DropDown(c6, EventArgs.Empty);
                    foreach (Class.Player p in c6.Items) if (p.TERZALINEAALA > max.TERZALINEAALA) max = p;
                    if (max != empty) c6.SelectedItem = max; max = empty;
                    break;

                case 7:
                    ComboPlayer_DropDown(c7, EventArgs.Empty);
                    foreach (Class.Player p in c7.Items) if (p.TERZALINEAALA > max.TERZALINEAALA) max = p;
                    if (max != empty) c7.SelectedItem = max; max = empty;
                    break;

                case 1:
                    ComboPlayer_DropDown(c1, EventArgs.Empty);
                    foreach (Class.Player p in c1.Items) if (p.PILONE > max.PILONE) max = p;
                    if (max != empty) c1.SelectedItem = max; max = empty;
                    break;

                case 3:
                    ComboPlayer_DropDown(c3, EventArgs.Empty);
                    foreach (Class.Player p in c3.Items) if (p.PILONE > max.PILONE) max = p;
                    if (max != empty) c3.SelectedItem = max; max = empty;
                    break;

                case 12:
                    ComboPlayer_DropDown(c12, EventArgs.Empty);
                    foreach (Class.Player p in c12.Items) if (p.CENTRO > max.CENTRO) max = p;
                    if (max != empty) c12.SelectedItem = max; max = empty;
                    break;

                case 13:
                    ComboPlayer_DropDown(c13, EventArgs.Empty);
                    foreach (Class.Player p in c13.Items) if (p.CENTRO > max.CENTRO) max = p;
                    if (max != empty) c13.SelectedItem = max; max = empty;
                    break;

                case 11:
                    ComboPlayer_DropDown(c11, EventArgs.Empty);
                    foreach (Class.Player p in c11.Items) if (p.ALA > max.ALA) max = p;
                    if (max != empty) c11.SelectedItem = max; max = empty;
                    break;

                case 14:
                    ComboPlayer_DropDown(c14, EventArgs.Empty);
                    foreach (Class.Player p in c14.Items) if (p.ALA > max.ALA) max = p;
                    if (max != empty) c14.SelectedItem = max; max = empty;
                    break;
            }
        }

        private void textOrder_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OrdineFormazione = textOrder.Text;
        }


     }
}
