using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabMarket : UserControl
    {
        public TabMarket()
        {
            InitializeComponent();
        }

        public TabPage GetTab()
        {
            return this.pageMain;
        }

        private void bCarica_Click(object sender, EventArgs e)
        {
            bCarica.Enabled = false;
            string pagina = "";
            if (pagina.Contains("http:")) pagina = Internal.Main.GetRMPage(textPlayer.Text);
            else pagina = System.IO.File.ReadAllText(textPlayer.Text,Encoding.Default);
            if (pagina != "")
            {   // NOME
                int index = 0;
                labelNome.Text = U(GetStringa(pagina, @"div class='titre1'>", @"<"));
                // ETA
                Età = GetStringa(pagina, @"età:", @"anni");
                lEta.Text = string.Format("Età: {0}", Età);
                // STIPENDIO
                Stipendio = GetStringa(pagina, @"Stipendio settimanale:", @"euros");
                lStipendio.Text = string.Format("Stipendio: {0} €", Stipendio);
                // NAZIONE
                sNazione.Text = U(GetStringa(pagina, @"nazionalità:", @"<"));
                // CLUB
                ClubID = GetStringa(pagina, @"club.php?id_club=", "\"");
                labelClub.Text = U(System.Text.RegularExpressions.Regex.Replace(GetStringa(pagina, @"Club attuale: ", "</a>"), @"<[^>]*>", ""));
                // ALTEZZA
                _ALTEZZA = System.Convert.ToInt32(GetStringa(pagina, @"altezza:", @"<"));
                sAltezzaSkill.Value = System.Convert.ToInt32(ALTEZZASKILL);
                sAltezza.Text = _ALTEZZA.ToString() + " cm.";
                // PESO
                _PESO = GetNumero(pagina, @"peso:", @"<"); 
                sPesoSkill.Value = System.Convert.ToInt32(PESOSKILL);
                sPeso.Text = _PESO.ToString() + " kg.";
                // SKILL
                int qskill = 0;
                while (index != -1)
                {
                    string skill = @"/images/niveau";
                    index = pagina.IndexOf(skill);
                    if (index > 0)
                    {
                        pagina = pagina.Substring(index, pagina.Length - index);
                        index = pagina.IndexOf(@".gif");
                        string num = pagina.Substring(0, index);
                        string val = num.Replace(skill, "");
                        int v = System.Convert.ToInt32(val);
                        switch (qskill)
                        {
                            case 0: sResistenza.Value = v; sResistenza.Visible = true; break;
                            case 1: sForza.Value = v; sForza.Visible = true; break;
                            case 2: sPlaccaggi.Value = v; sPassaggi.Visible = true; break;
                            case 3: sVelocita.Value = v; sVelocita.Visible = true; break;
                            case 4: sPassaggi.Value = v; sPassaggi.Visible = true; break;
                            case 5: sRicezione.Value = v; sRicezione.Visible = true; break;
                            case 6: sEsperienza.Value = v; sEsperienza.Visible = true; break;
                            case 7: sCalci.Value = v; sCalci.Visible = true; break;
                        }
                        qskill++;
                        pagina = pagina.Substring(index, pagina.Length - index);
                    }
                }
            }
            bCarica.Enabled = true;
        }

        private string Età = "17";
        private string Stipendio = "0";
        private string ClubID = "0";

        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        private decimal GetNumero(string pagina, string inizio, string fine)
        {
            int index1 = pagina.IndexOf(inizio);
            int index2 = pagina.IndexOf(fine, index1);
            int start = index1 + inizio.Length;
            string strval = pagina.Substring(start, index2-start);
            strval = strval.Replace(" ","");
            strval = strval.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            strval = strval.Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            decimal val = System.Convert.ToDecimal(strval);
            return val;
        }

        private string GetStringa(string pagina, string inizio, string fine)
        {
            int index1 = pagina.IndexOf(inizio);
            int index2 = pagina.IndexOf(fine, index1);
            int start = index1 + inizio.Length;
            string strval = pagina.Substring(start, index2-start);
            return strval.Trim();
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
    }
}
