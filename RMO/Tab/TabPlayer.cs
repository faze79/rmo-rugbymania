using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabPlayer : UserControl
    {
        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        public TabPlayer()
        {
            InitializeComponent();
        }

        public TabPage GetTab()
        {
            T(this);
            return this.pageMain;
        }

        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        public void LoadGiocatore(string id)
        {
            DataTable dt = Internal.DB.ExecuteQuery(string.Format("SELECT * FROM players WHERE (id={0}) ORDER BY data DESC",id));
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                // ANAGRAFICA
                pageMain.Text = labelNome.Text = U(string.Format("{0} {1}", dr["prenom"], dr["nom"]));
                sNazione.Text = U(dr["country"].ToString());
                Età = dr["age"].ToString();
                Stipendio = dr["salaire"].ToString();
                lEta.Text = string.Format(T("Età: {0}"), Età);
                lStipendio.Text = string.Format(T("Stipendio: {0} €"), Stipendio);
                _ALTEZZA = System.Convert.ToDecimal(dr["size"]);
                sAltezza.Text = string.Format("{0} cm.",_ALTEZZA);
                _PESO = System.Convert.ToDecimal(dr["weight"]);
                _PESO = _PESO / 100;
                sPeso.Text = string.Format("{0} kg.", _PESO);
                sAltezzaSkill.Value = System.Convert.ToInt32(decimal.Floor(ALTEZZASKILL));
                sPesoSkill.Value = System.Convert.ToInt32(decimal.Floor(PESOSKILL));
                // SKILL
                sResistenza.Value = System.Convert.ToInt32(dr["endurance"]);
                tt.SetToolTip(sResistenza, sResistenza.Value.ToString());
                sForza.Value = System.Convert.ToInt32(dr["puissance"]);
                tt.SetToolTip(sForza, sForza.Value.ToString());
                sPlaccaggi.Value = System.Convert.ToInt32(dr["placage"]);
                tt.SetToolTip(sPlaccaggi, sPlaccaggi.Value.ToString());
                sVelocita.Value = System.Convert.ToInt32(dr["rapidite"]);
                tt.SetToolTip(sVelocita, sVelocita.Value.ToString());
                sPassaggi.Value = System.Convert.ToInt32(dr["passe"]);
                tt.SetToolTip(sPassaggi, sPassaggi.Value.ToString());
                sRicezione.Value = System.Convert.ToInt32(dr["receptionb"]);
                tt.SetToolTip(sRicezione, sRicezione.Value.ToString());
                sEsperienza.Value = System.Convert.ToInt32(dr["experience"]);
                tt.SetToolTip(sEsperienza, sEsperienza.Value.ToString());
                sCalci.Value = System.Convert.ToInt32(dr["kicking"]);
                tt.SetToolTip(sCalci, sCalci.Value.ToString());
                LoadEventi(id);
                CalcolaValore();
                CalcolaTouche();
            }
        }

        private string Età = "17";
        private string Stipendio = "0";

        private decimal _PESO = 0;
        public decimal PESOSKILL
        {
            get
            {
                decimal tmp = _PESO;//decimal.Divide(_PESO, (decimal)100);
                tmp = decimal.Subtract(tmp, (decimal)60);
                tmp = decimal.Divide(tmp, (decimal)3.5);
                tmp = decimal.Floor(tmp * 100);
                tmp = decimal.Divide(tmp, 100);
                if (tmp > 18) tmp = 18;
                return tmp;
            }
        }

        private decimal _ALTEZZA = 0;
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

        public void LoadEventi(string id)
        {
            DataTable dt = Internal.DB.GetEvents(string.Format("(player='{0}')", id));
            if (dt == null) return;
            listEvents.BeginUpdate();
            listEvents.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                string[] line = new string[4];
                for (int i = 0; i < 4; i++) line[i] = dr[i].ToString();
                if (line[2] != "") line[2] = labelNome.Text;
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

        private void listEvents_SizeChanged(object sender, EventArgs e)
        {
            cDettagli.Width = listEvents.Width - cData.Width - cPlayer.Width - cTipo.Width - 25;
        }

        private void CalcolaValore()
        {
            decimal somma = 0; int s = 0;
            somma = ((decimal)(ALTEZZASKILL + PESOSKILL)-18);
            if (somma < 0) somma = 0;
            somma += sForza.Value + sPlaccaggi.Value;
            somma += sVelocita.Value + sPassaggi.Value + sRicezione.Value;
            somma += sCalci.Value;
            somma += ((decimal)sEsperienza.Value) / 3;
            somma += ((decimal)sResistenza.Value) / 6;
            int eta = System.Convert.ToInt32(Età);
            somma = somma / ((decimal)eta / 25);
            if (somma <= 18) somma = somma * somma;
            else
            {
                somma = somma - 18;
                somma = somma * somma * 1500;
            }
            somma += ((decimal)listEvents.Items.Count)*5;
            string v = decimal.Floor(somma).ToString("#,#");
            if (v == "") v = "0";
            lValore.Text = string.Format(T("Valore stimato: {0} €"),v);

            int val = CalcolaStipendio(sForza.Value,sPlaccaggi.Value,sVelocita.Value,sPassaggi.Value,sRicezione.Value,sCalci.Value);
            lStipendio2.Text = string.Format(T("Stipendio stimato: {0} €"),val);
            SelectScatto();
        }

        private void SelectScatto()
        {
            int s = 0; int k = sForza.Value;
            int[] v = new int[6] {sForza.Value,sPlaccaggi.Value,sVelocita.Value,sPassaggi.Value,sRicezione.Value,sCalci.Value};
            for (int i = 1; i < v.Length; i++)
            {
                if (k < v[i])
                {
                    k = v[i];
                    s = i;
                }
            }
            comboScatto.SelectedIndex = s;
        }

        private void comboScatto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboScatto.SelectedIndex < 0) { labelScatto.Text = ""; return; }
            int scatti = 9; double step = 0.125;
            if (System.Convert.ToInt32(Età) < 21) { scatti = 6; step = 0.2; }
            int[] stipendi = new int[scatti];
            int v = 0;
            for (int i = 0; i < scatti; i++)
            {
                switch(comboScatto.SelectedIndex)
                {
                    case 0: 
                        v = sForza.Value;
                        stipendi[i] = CalcolaStipendio(sForza.Value+(i*step), sPlaccaggi.Value, sVelocita.Value, sPassaggi.Value, sRicezione.Value, sCalci.Value);
                        break;
                    case 1:
                        v = sPlaccaggi.Value;
                        stipendi[i] = CalcolaStipendio(sForza.Value, sPlaccaggi.Value + (i * step), sVelocita.Value, sPassaggi.Value, sRicezione.Value, sCalci.Value);
                        break;
                    case 2:
                        v = sVelocita.Value;
                        stipendi[i] = CalcolaStipendio(sForza.Value, sPlaccaggi.Value, sVelocita.Value + (i * step), sPassaggi.Value, sRicezione.Value, sCalci.Value);
                        break;
                    case 3:
                        v = sPassaggi.Value;
                        stipendi[i] = CalcolaStipendio(sForza.Value, sPlaccaggi.Value, sVelocita.Value, sPassaggi.Value + (i * step), sRicezione.Value, sCalci.Value);
                        break;
                    case 4:
                        v = sRicezione.Value;
                        stipendi[i] = CalcolaStipendio(sForza.Value, sPlaccaggi.Value, sVelocita.Value, sPassaggi.Value, sRicezione.Value + (i * step), sCalci.Value);
                        break;
                    case 5:
                        v = sCalci.Value;
                        stipendi[i] = CalcolaStipendio(sForza.Value, sPlaccaggi.Value, sVelocita.Value, sPassaggi.Value, sRicezione.Value, sCalci.Value + (i * step));
                        break;
                }
            }
            string text = string.Format(T("Base: {0} €")+"\r\n", stipendi[0]);
            if (v!=18) for (int x = 1; x < scatti; x++) text += string.Format("{0}+{1}: {2} €\r\n",v,x,stipendi[x]);
            labelScatto.Text = text;
        }

        public static int CalcolaStipendio(double a, double b, double c, double d, double e, double f)
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

        private void CalcolaTouche()
        {
            int val = System.Convert.ToInt32(_ALTEZZA + sRicezione.Value);
            lTouche.Text = string.Format(T("Punti Touche: {0}"),val);
        }

    }
}
