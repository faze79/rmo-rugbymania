using System;
using System.Collections.Generic;
using System.Text;

namespace RMO.Class
{
    public class Player : IComparable 
    {
        public override string ToString()
        {
            return COGNOME + " " + NOME;
        }

        public int ID = 0;
        public string NOME = "Nome";
        public string COGNOME = "Cognome";
        public string STATO = "Stato";
        public string CATEGORIA = "Categoria";
        public int SALARIO = 0;
        public int ETA = 0;
        public int ALTEZZA = 0;
        public decimal PESO = 0;
        public int RESISTENZA = 0;
        public int FORZA = 0;
        public int PLACCAGGI = 0;
        public int VELOCITA = 0;
        public int PASSAGGI = 0;
        public int RICEZIONE = 0;
        public int CALCI = 0;
        public int ESPERIENZA = 0;
        public int GIORNI = 0;
        public int PILONE = 0;
        public int TALLONATORE = 0;
        public int SECONDALINEA = 0;
        public int TERZALINEAALA = 0;
        public int TERZALINEACENTRO = 0;
        public int MEDIANODIMISCHIA = 0;
        public int MEDIANODIAPERTURA = 0;
        public int ALA = 0;
        public int CENTRO = 0;
        public int ESTREMO = 0;

        public void LoadData(System.Data.DataRow dr, string data)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                SetValue(dr.Table.Columns[i].ColumnName, dr[i].ToString());
            }
        }

        private void SetValue(string nome, string valore)
        {
            switch (nome)
            {
                case "id": ID = System.Convert.ToInt32(valore); break;
                case "nom": NOME = U(valore); break;
                case "prenom": COGNOME = U(valore); break;
                case "country": STATO = valore; break;
                case "category": CATEGORIA = valore; break;
                case "age": ETA = System.Convert.ToInt32(valore); break;
                case "experience": ESPERIENZA = System.Convert.ToInt32(valore); break;
                case "salaire": SALARIO = System.Convert.ToInt32(valore); break;
                case "placage": PLACCAGGI = System.Convert.ToInt32(valore); break;
                case "puissance": FORZA = System.Convert.ToInt32(valore); break;
                case "passe": PASSAGGI = System.Convert.ToInt32(valore); break;
                case "receptionb": RICEZIONE = System.Convert.ToInt32(valore); break;
                case "endurance": RESISTENZA = System.Convert.ToInt32(valore); break;
                case "size": ALTEZZA = System.Convert.ToInt32(valore); break;
                case "weight":
                    decimal dval = My.Convert.ToDecimal(valore);
                    // Nel database il peso è senza la virgola moltiplicato per 100
                    PESO = ((decimal)(dval / 100));
                    break;
                case "rapidite": VELOCITA = System.Convert.ToInt32(valore); break;
                case "kicking": CALCI = System.Convert.ToInt32(valore); break;
                case "arrivee":
                    if (valore.Contains("-1")) GIORNI = 9999;
                    else GIORNI = System.Convert.ToInt32(valore.Replace("giorni", "").Trim()); break;
                case "stat1": PILONE = System.Convert.ToInt32(valore); break;
                case "stat2": TALLONATORE = System.Convert.ToInt32(valore); break;
                case "stat4": SECONDALINEA = System.Convert.ToInt32(valore); break;
                case "stat6": TERZALINEAALA = System.Convert.ToInt32(valore); break;
                case "stat8": TERZALINEACENTRO = System.Convert.ToInt32(valore); break;
                case "stat9": MEDIANODIMISCHIA = System.Convert.ToInt32(valore); break;
                case "stat10": MEDIANODIAPERTURA = System.Convert.ToInt32(valore); break;
                case "stat11": ALA = System.Convert.ToInt32(valore); break;
                case "stat12": CENTRO = System.Convert.ToInt32(valore); break;
                case "stat15": ESTREMO = System.Convert.ToInt32(valore); break;
            }
        }

        private string U(string text)
        {
            string result = System.Web.HttpUtility.HtmlDecode(text);
            result = System.Web.HttpUtility.HtmlDecode(result);
            return result;
        }

        public static bool OrderReverse = true;
        public static Control.Player.Skill OrderSkill = Control.Player.Skill.Id;
        public int CompareTo(object obj)
        {
            Player p = (Player)obj;
            switch (OrderSkill)
            {
                case Control.Player.Skill.Id: return (OrderReverse) ? (p.ID - ID) : (ID - p.ID);
                case Control.Player.Skill.Nome: return (OrderReverse) ? string.Compare(p.NOME, NOME) : string.Compare(NOME, p.NOME);
                case Control.Player.Skill.Cognome: return (OrderReverse) ? string.Compare(p.COGNOME, COGNOME) : string.Compare(COGNOME, p.COGNOME);
                case Control.Player.Skill.Stato: return (OrderReverse) ? string.Compare(p.STATO, STATO) : string.Compare(STATO, p.STATO);
                case Control.Player.Skill.Categoria: return (OrderReverse) ? string.Compare(p.CATEGORIA, CATEGORIA) : string.Compare(CATEGORIA, p.CATEGORIA);
                case Control.Player.Skill.Eta: return (OrderReverse) ? (p.ETA - ETA) : (ETA - p.ETA);
                case Control.Player.Skill.Altezza: return (OrderReverse) ? (p.ALTEZZA - ALTEZZA) : (ALTEZZA - p.ALTEZZA);
                case Control.Player.Skill.Peso: return (OrderReverse) ? (int)(p.PESO - PESO) : (int)(PESO - p.PESO);
                case Control.Player.Skill.Resistenza: return (OrderReverse) ? (p.RESISTENZA - RESISTENZA) : (RESISTENZA - p.RESISTENZA);
                case Control.Player.Skill.Forza: return (OrderReverse) ? (p.FORZA - FORZA) : (FORZA - p.FORZA);
                case Control.Player.Skill.Placcaggi: return (OrderReverse) ? (p.PLACCAGGI - PLACCAGGI) : (PLACCAGGI - p.PLACCAGGI);
                case Control.Player.Skill.Velocita: return (OrderReverse) ? (p.VELOCITA - VELOCITA) : (VELOCITA - p.VELOCITA);
                case Control.Player.Skill.Passaggi: return (OrderReverse) ? (p.PASSAGGI - PASSAGGI) : (PASSAGGI - p.PASSAGGI);
                case Control.Player.Skill.Ricezione: return (OrderReverse) ? (p.RICEZIONE - RICEZIONE) : (RICEZIONE - p.RICEZIONE);
                case Control.Player.Skill.Calci: return (OrderReverse) ? (p.CALCI - CALCI) : (CALCI - p.CALCI);
                case Control.Player.Skill.Esperienza: return (OrderReverse) ? (p.ESPERIENZA - ESPERIENZA) : (ESPERIENZA - p.ESPERIENZA);
                case Control.Player.Skill.Giorni: return (OrderReverse) ? (p.GIORNI - GIORNI) : (GIORNI - p.GIORNI);
                case Control.Player.Skill.Salario: return (OrderReverse) ? (p.SALARIO - SALARIO) : (SALARIO - p.SALARIO);
                case Control.Player.Skill.Pilone: return (OrderReverse) ? (p.PILONE - PILONE) : (PILONE - p.PILONE);
                case Control.Player.Skill.Tallonatore: return (OrderReverse) ? (p.TALLONATORE - TALLONATORE) : (TALLONATORE - p.TALLONATORE);
                case Control.Player.Skill.SecondaLinea: return (OrderReverse) ? (p.SECONDALINEA - SECONDALINEA) : (SECONDALINEA - p.SECONDALINEA);
                case Control.Player.Skill.TerzaLineaAla: return (OrderReverse) ? (p.TERZALINEAALA - TERZALINEAALA) : (TERZALINEAALA - p.TERZALINEAALA);
                case Control.Player.Skill.TerzaLineaCentro: return (OrderReverse) ? (p.TERZALINEACENTRO - TERZALINEACENTRO) : (TERZALINEACENTRO - p.TERZALINEACENTRO);
                case Control.Player.Skill.MedianoDiMischia: return (OrderReverse) ? (p.MEDIANODIMISCHIA - MEDIANODIMISCHIA) : (MEDIANODIMISCHIA - p.MEDIANODIMISCHIA);
                case Control.Player.Skill.MedianoDiApertura: return (OrderReverse) ? (p.MEDIANODIAPERTURA - MEDIANODIAPERTURA) : (MEDIANODIAPERTURA - p.MEDIANODIAPERTURA);
                case Control.Player.Skill.Ala: return (OrderReverse) ? (p.ALA - ALA) : (ALA - p.ALA);
                case Control.Player.Skill.Centro: return (OrderReverse) ? (p.CENTRO - CENTRO) : (CENTRO - p.CENTRO);
                case Control.Player.Skill.Estremo: return (OrderReverse) ? (p.ESTREMO - ESTREMO) : (ESTREMO - p.ESTREMO);
            }
            return 0;
        }

    }
}
