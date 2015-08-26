using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace RMO
{
    public class RMDB
    {
        public static string DBPATH = System.IO.Path.DirectorySeparatorChar + "db.s3db";
        private My.SQLLite DB;
        private string[] DBCREATE = new string[] { "CREATE TABLE players (id INTEGER, data DATETIME, nom TEXT, prenom TEXT, country TEXT, category TEXT, "+
            "age INTEGER, experience INTEGER, salaire INTEGER, placage INTEGER, puissance INTEGER, passe INTEGER, receptionb INTEGER, endurance INTEGER, "+
            "size INTEGER, weight INTEGER, rapidite INTEGER, kicking INTEGER, arrivee INTEGER, stat1 INTEGER, stat2 INTEGER, stat4 INTEGER, "+
            "stat6 INTEGER, stat8 INTEGER, stat9 INTEGER, stat10 INTEGER, stat11 INTEGER, stat12 INTEGER, stat15 INTEGER, "+
            "skill_akickoff INTEGER, skill_dkickoff INTEGER, skill_lineout INTEGER, skill_ruck INTEGER, skill_scrum INTEGER, skill_looseball INTEGER, "+
            "skill_speeda INTEGER, skill_speedd INTEGER, skill_powera INTEGER, skill_powerd INTEGER, skill_passing INTEGER, skill_handling INTEGER, skill_kicker INTEGER)", 
            "CREATE TABLE files (path TEXT, md5 TEXT, note TEXT)",
            "CREATE TABLE events (data DATETIME, tipo TEXT, player TEXT, detail TEXT)" };

        public bool NEW_DATABASE;
        public RMDB()
        {
            string path = Internal.WORKPATH + DBPATH;
            HISTORY_PATH = Internal.WORKPATH + System.IO.Path.DirectorySeparatorChar + "xml" + System.IO.Path.DirectorySeparatorChar + "history.events";
            NEW_DATABASE = !System.IO.File.Exists(path);
            DB = new My.SQLLite(path, DBCREATE);
            int versione = SetVersion(false);
            if (versione <= 31)
            {
                My.Box.Info("A causa di un errore nella vecchia versione di RMO,\r\n"+
                    "E' necessario eseguire nuovamente il download degli eventi.\r\n"+
                    "Quando sarai connesso ad internet ricordati di eseguire:\r\n"+
                    "Menu -> Azioni -> Reset degli eventi\r\n\r\n"+
                    "Durerà molti minuti e reinserirà tutti gli eventi.");
            }
            else if (versione <= 32)
            {
                My.Box.Info("A causa di nuove implementazioni in RMO,\r\n"+
                    "E' necessario eseguire nuovamente il download degli eventi.\r\n"+
                    "Quando sarai connesso ad internet ricordati di eseguire:\r\n"+
                    "Menu -> Azioni -> Reset degli eventi\r\n\r\n"+
                    "Durerà molti minuti e reinserirà tutti gli eventi.");
            }
            else if (versione < 70)
            {
                My.Box.Info("A causa di nuove implementazioni in RMO,\r\n" +
                   "E' necessario effettuare la ricostruzione del database\r\n" +
                   "Please, for new features of database please rebuild database\r\n");
                Internal.Main.Rebuild_Database();
            }
            LoadHistory();
        }

        public int SetVersion(bool update)
        {
            string sql = "";
            if (update)
            {
                sql = string.Format("UPDATE files SET note='{0}' WHERE (path='build') AND (md5='build')", Internal.VERSION);
                DB.ExecuteCommand(sql);
            }
            else
            {
                sql = string.Format("SELECT * FROM files WHERE (path='build') AND (md5='build')");
                DataTable dt = DB.ExecuteQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    string ver = dt.Rows[0]["note"].ToString();
                    int version = System.Convert.ToInt32(ver);
                    return version;
                }
                else
                {
                    sql = string.Format("INSERT INTO files (path,md5,note) VALUES ('build','build','{0}')", Internal.VERSION);
                    DB.ExecuteCommand(sql);
                }
            }
            return Internal.VERSION;
        }

        public bool Execute(string sql)
        {
            try
            {
                sql = "BEGIN TRANSACTION;" + sql + "END TRANSACTION;";
                DB.ExecuteCommand(sql);
                return true;
            }
            catch { return false; }
        }

        public void Begin()
        {
            DB.ExecuteCommand("BEGIN TRANSACTION;");
        }

        public void End()
        {
            DB.ExecuteCommand("END TRANSACTION;"); 
        }

        public DataTable ExecuteQuery(string sql)
        {
            return DB.ExecuteQuery(sql);
        }

        public void Dispose()
        {
            if (DB != null)
            {
                DB.CloseDatabase();
                DB = null;
            }
        }

        public event EventHandler OnTeamAdded;
        public string LoadTeam(string file,bool execute)
        {
            string sql = "";
            try
            {
                if (LoadedFile(file)) return "";
                string nome = System.IO.Path.GetFileName(file);
                DateTime dt = RMHTML.GetDate(file);
                System.Xml.XmlDocument doc = My.XML.ReadXML(file);
                System.Xml.XmlNodeList list = doc.GetElementsByTagName("players");
                if (list.Count > 0)
                {
                    System.Xml.XmlNode root = list[0];
                    Internal.Main.StatusString = "Loading: " + nome;
                    Internal.Main.StatusBar.Value = 0;
                    Internal.Main.StatusBar.Maximum = root.ChildNodes.Count;
                    foreach (System.Xml.XmlNode player in root.ChildNodes)
                    {
                        sql += LoadPlayerSql(player, dt) + ";";
                        Internal.Main.StatusBar.Value++;
                    }
                    if (execute) DB.ExecuteCommand(sql);
                    Internal.Main.StatusBar.Value = 0;
                    Internal.Main.StatusString = "";
                }
                if (OnTeamAdded != null) OnTeamAdded(null, EventArgs.Empty);
            }
            catch(Exception ex) { Internal.Log("RMDB::LoadTeam", ex.Message + "\r\n>>> " + file); }
            return sql;
        }

        /// <summary>
        /// Verifica se è già stato importato un file con il medesimo contenuto
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool LoadedFile(string file)
        {
            string md5 = My.MD5.MD5FromFile(file);
            string sql = string.Format("SELECT * FROM files WHERE (md5='{0}')",md5);
            DataTable dt = DB.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                System.IO.File.Delete(file);
                return true;
            }
            sql = string.Format("INSERT INTO files (path,md5,note) VALUES ('{0}','{1}','')",file,md5);
            DB.ExecuteCommand(sql);
            return false;
        }

        private string HISTORY_PATH = "";
        private string HISTORY = "";
        public void LoadHistory()
        { 
            if (System.IO.File.Exists(HISTORY_PATH)) HISTORY = System.IO.File.ReadAllText(HISTORY_PATH,Encoding.UTF8);
        }

        public bool Loaded(string command) { return HISTORY.Contains(command); }
        public void Record(string command) 
        { 
            System.IO.File.AppendAllText(HISTORY_PATH, command,Encoding.UTF8);
            HISTORY = HISTORY + "\r\n" + command;
        }

        public int LoadEvent(DateTime data, string detail)
        {
            int result = 0;
            string sql = ""; string player = "";
            string mydate = My.SQLLite.DateToSQLite(data);
            string mydata = detail.Replace("'", "''");
            // Selezione del tipo di evento
            string tipo = GetEventType(detail);
            switch (tipo)
            {
                case "allenamento":
                    System.Collections.ArrayList allenamenti = GetTrainingFromDetail(detail);
                    foreach (Allenamento train in allenamenti)
                    {
                        sql = string.Format("INSERT INTO events (data,tipo,player,detail) VALUES ('{0}','{1}','{2}','{3}')", mydate, tipo, train.Player, train.Skill);
                        if (!Loaded(sql))
                        {
                            DB.ExecuteCommand(sql);
                            Record(sql + ";" + Environment.NewLine);
                            result++;
                        }
                    }
                    break;
                default:
                case "generico":
                    System.Collections.ArrayList players = GetPlayersFromDetail(detail);
                    if (players.Count == 1) player = players[0].ToString();
                    sql = string.Format("INSERT INTO events (data,tipo,player,detail) VALUES ('{0}','{1}','{2}','{3}')", mydate, tipo,player, mydata);
                    if (!Loaded(sql))
                    {
                        DB.ExecuteCommand(sql);
                        Record(sql + ";" + Environment.NewLine);
                        result++;
                    }
                    break;
            }
            return result;
        }

        public string[] VENDITA = new string[] { "hai venduto il", "euros for your player", "suite au transfert" };
        public string[] ACQUISTO = new string[] { "per comprare", "sign the player", "dans votre club" };
        public string[] ALLENAMENTO = new string[] { "allenamento settimanale", "weekly training", "cette semaine" };
        public string[] ECONOMIA = new string[] { "i loro stipendi", "sponsor", "costi settimanali", "incasso", "IRB ti ha versato", "versato un premio", 
            "salaries", "income for the game", "IRmB refund", "reward for your results", "academy cost", 
            "salaires", "recette du match", "IRmB a pris en charge", "une prime d'un montant", "couts du centre de formation" };

        private string GetEventType(string s) 
        {
            foreach (string template in ACQUISTO) if (s.Contains(template)) return "acquisto"; // DEVE ESSERE PRIMA PER FRANCESI
            foreach (string template in VENDITA) if (s.Contains(template)) return "vendita";
            foreach (string template in ALLENAMENTO) if (s.Contains(template)) return "allenamento";
            foreach (string template in ECONOMIA) if (s.Contains(template)) return "economia";
            return "generico";
        }

        public string[] RESISTENZA = new string[] { "resistenza", "stamina", "endurance" };
        public string[] FORZA = new string[] { "forza", "strength", "force" };
        public string[] PLACCAGGI = new string[] { "placcaggi", "tackling", "plaquage" };
        public string[] VELOCITA = new string[] { "velocità", "speed", "rapidité" };
        public string[] PASSAGGI = new string[] { "passaggi", "passing", "passes" };
        public string[] RICEZIONE = new string[] { "ricezione", "handling", "réception balle" };
        public string[] CALCI = new string[] { "calci", "kicking", "coup de pied" };
        public string[] ALTRI = new string[] { "passaggi + ricezione", "handling + passing", "réception balle + passes" };
        private string GetTradingType(string s)
        {
            foreach (string template in RESISTENZA) if (s == template) return RESISTENZA[0];
            foreach (string template in FORZA) if (s == template) return FORZA[0];
            foreach (string template in PLACCAGGI) if (s == template) return PLACCAGGI[0];
            foreach (string template in VELOCITA) if (s == template) return VELOCITA[0];
            foreach (string template in PASSAGGI) if (s == template) return PASSAGGI[0];
            foreach (string template in RICEZIONE) if (s == template) return RICEZIONE[0];
            foreach (string template in CALCI) if (s == template) return CALCI[0];
            foreach (string template in ALTRI) if (s == template) return ALTRI[0];
            return "";
        }

        public void ResetEvents()
        {
            DB.ExecuteCommand("DELETE FROM events");
            System.IO.File.Delete(HISTORY_PATH);
            HISTORY = "";
        }

        public string[] MARKET = new string[] { "Un giocatore è stato inserito nelle liste di trasferimento.",
        "A player has been listed on the transfer market.", "Vous avez placé un joueur sur le marché des transferts."};
        public DateTime GetBlockedMarket()
        {
            try
            {
                foreach (string s in MARKET)
                {
                    string sql = string.Format("SELECT * FROM events WHERE (detail='{0}') ORDER BY data DESC LIMIT 1",s);
                    DataTable dt = DB.ExecuteQuery(sql);
                    if (dt.Rows.Count > 0)
                    {
                        DateTime result = DateTime.Parse(dt.Rows[0][0].ToString());
                        return result;
                    }
                }
            }
            catch { }
            return new DateTime(2000, 01, 01);
        }

        private System.Collections.ArrayList GetPlayersFromDetail(string detail)
        {
            string[] tokens = detail.Split(new char[2] { '<', '>' });
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (string s in tokens)
            {
                if (s.Contains("id_player"))
                {
                    string[] subtokens = s.Split(new char[2] {'=','\'' });
                    list.Add(subtokens[subtokens.Length-2]);
                }
            }
            return list;
        }


        public class Allenamento { public string Player = ""; public string Skill = "";}
        private System.Collections.ArrayList GetTrainingFromDetail(string detail)
        {
            string[] tokens = detail.Split(new char[4] { '(', ')', ',', '+' });
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            Allenamento l;
            string player = "";
            foreach (string s in tokens)
            {
                //if (s.Contains("id_player="))
                if (s.Contains("'player/"))
                {
                    //string[] subtokens = s.Split(new char[2] { '=', '\'' });
                    //player = subtokens[subtokens.Length - 2];
                    player = My.Convert.GetString(s, "'player/", "'>");
                }
                string ss = s.Trim().ToLower();
                if (player != "")
                {
                    string tipo = GetTradingType(ss);
                    switch(tipo)
                    {
                        case "resistenza": l = new Allenamento(); l.Player = player; l.Skill = "resistenza"; list.Add(l); break;
                        case "forza": l = new Allenamento(); l.Player = player; l.Skill = "forza"; list.Add(l); break;
                        case "placcaggi": l = new Allenamento(); l.Player = player; l.Skill = "placcaggi"; list.Add(l); break;
                        case "velocità": l = new Allenamento(); l.Player = player; l.Skill = "velocità"; list.Add(l); break;
                        case "passaggi": l = new Allenamento(); l.Player = player; l.Skill = "passaggi"; list.Add(l); break;
                        case "ricezione": l = new Allenamento(); l.Player = player; l.Skill = "ricezione"; list.Add(l); break;
                        case "calci": l = new Allenamento(); l.Player = player; l.Skill = "calci"; list.Add(l); break;
                        case "passaggi + ricezione": l = new Allenamento(); l.Player = player; l.Skill = "passaggi + ricezione"; list.Add(l); break;
                    }
                }
            }
            return list;
        }

        private void LoadPlayer(System.Xml.XmlNode player,DateTime date)
        {
            try
            {
                string sql = "INSERT INTO players (id,data,nom,prenom,country,category,age,experience,salaire,placage,puissance,passe,receptionb,endurance,size,weight,rapidite,kicking,arrivee,stat1,stat2,stat4,stat6,stat8,stat9,stat10,stat11,stat12,stat15,skill_akickoff,skill_dkickoff,skill_lineout,skill_ruck,skill_scrum,skill_looseball,skill_speeda,skill_speedd,skill_powera,skill_powerd,skill_passing,skill_handling,skill_kicker) " +
                                          "VALUES ($01,'$02','$03','$04','$05','$06'  ,$07,$08       ,$09    ,$10    ,$11      ,$12  ,$13       ,$14      ,$15 ,$16   ,$17     ,$18    ,$19    ,$21  ,$22  ,$24  ,$26  ,$28  ,$29  ,$30   ,$31   ,$32   ,$35   ,$40           ,$41           ,$42          ,$43       ,$44        ,$45            ,$46         ,$47         ,$48         ,$49         ,$50          ,$51           ,$52         )";
                string data = "";
                foreach (System.Xml.XmlNode prop in player.ChildNodes)
                {
                    switch (prop.Name)
                    {
                        case "id":          sql = sql.Replace("$01",prop.InnerText); break;
                        case "nom":         sql = sql.Replace("$03",prop.InnerText.Replace("'","''")); break;
                        case "prenom":      sql = sql.Replace("$04",prop.InnerText.Replace("'","''")); break;
                        case "country":     sql = sql.Replace("$05",prop.InnerText); break;
                        case "category":    sql = sql.Replace("$06",prop.InnerText); break;
                        case "age":         sql = sql.Replace("$07",prop.InnerText); break;
                        case "experience":  sql = sql.Replace("$08",prop.InnerText); break;
                        case "salaire":     sql = sql.Replace("$09",prop.InnerText); break;
                        case "placage":     sql = sql.Replace("$10",prop.InnerText); break;
                        case "puissance":   sql = sql.Replace("$11",prop.InnerText); break;
                        case "passe":       sql = sql.Replace("$12",prop.InnerText); break;
                        case "receptionb":  sql = sql.Replace("$13",prop.InnerText); break;
                        case "endurance":   sql = sql.Replace("$14",prop.InnerText); break;
                        case "size":        sql = sql.Replace("$15",prop.InnerText); break;
                        case "rapidite":    sql = sql.Replace("$17",prop.InnerText); break;
                        case "kicking":     sql = sql.Replace("$18",prop.InnerText); break;
                        case "arrivee":     data = prop.InnerText.Replace("giorni", "").Trim(); break;
                        case "date_from":
                            try
                            {
                                DateTime acquisto = DateTime.Parse(prop.InnerText);
                                TimeSpan diff = DateTime.Now - acquisto;
                                sql = sql.Replace("$19", diff.Days.ToString());
                            }
                            catch (Exception ex)
                            { sql = sql.Replace("$19", prop.InnerText); }
                            break;
                        case "stat1":       sql = sql.Replace("$21",prop.InnerText); break;
                        case "stat2":       sql = sql.Replace("$22",prop.InnerText); break;
                        case "stat4":       sql = sql.Replace("$24",prop.InnerText); break;
                        case "stat6":       sql = sql.Replace("$26",prop.InnerText); break;
                        case "stat8":       sql = sql.Replace("$28",prop.InnerText); break;
                        case "stat9":       sql = sql.Replace("$29",prop.InnerText); break;
                        case "stat10":      sql = sql.Replace("$30",prop.InnerText); break;
                        case "stat11":      sql = sql.Replace("$31",prop.InnerText); break;
                        case "stat12":      sql = sql.Replace("$32",prop.InnerText); break;
                        case "stat15":      sql = sql.Replace("$35",prop.InnerText); break;
                        case "weight":
                            decimal peso = My.Convert.ToDecimal(prop.InnerText);
                            peso = peso * 100; int ipeso = System.Convert.ToInt32(peso);
                            sql = sql.Replace("$16", ipeso.ToString());
                            break;
                        case "skill_akickoff":  sql = sql.Replace("$40", prop.InnerText); break;   // Calci d'avvio in attacco
                        case "skill_dkickoff":  sql = sql.Replace("$41", prop.InnerText); break;   // Calci d'avvio in difesa
                        case "skill_lineout":   sql = sql.Replace("$42", prop.InnerText); break;   // Touche
                        case "skill_ruck":      sql = sql.Replace("$43", prop.InnerText); break;   // Ruck, Palle vaganti
                        case "skill_scrum":     sql = sql.Replace("$44", prop.InnerText); break;   // Mischie
                        case "skill_looseball": sql = sql.Replace("$45", prop.InnerText); break;   // Ruck, Palle vaganti
                        case "skill_speeda":    sql = sql.Replace("$46", prop.InnerText); break;   // Attacca la linea (velocità)
                        case "skill_speedd":    sql = sql.Replace("$47", prop.InnerText); break;   // Difesa su giocatori veloci
                        case "skill_powera":    sql = sql.Replace("$48", prop.InnerText); break;   // Attacca la linea (forza)
                        case "skill_powerd":    sql = sql.Replace("$49", prop.InnerText); break;   // Difesa su giocatori forti
                        case "skill_passing":   sql = sql.Replace("$50", prop.InnerText); break;   // Passaggi
                        case "skill_handling":  sql = sql.Replace("$51", prop.InnerText); break;   // Ricezione
                        case "skill_kicker":    sql = sql.Replace("$52", prop.InnerText); break;   // Calci
                        default: break;
                    }
                }
                if (sql.Contains("$19")) sql = sql.Replace("$19", data);
                sql = sql.Replace("$02", My.SQLLite.DateToSQLite(date));
                if (sql.IndexOf("$")<0) DB.ExecuteCommand(sql);
            }
            catch (Exception ex) { My.Box.Errore("RMDB::LoadPlayer()\r\n"+ex.Message); }
        }

        private string LoadPlayerSql(System.Xml.XmlNode player, DateTime date)
        {
            try
            {
                string sql = "INSERT INTO players (id,data,nom,prenom,country,category,age,experience,salaire,placage,puissance,passe,receptionb,endurance,size,weight,rapidite,kicking,arrivee,stat1,stat2,stat4,stat6,stat8,stat9,stat10,stat11,stat12,stat15,skill_akickoff,skill_dkickoff,skill_lineout,skill_ruck,skill_scrum,skill_looseball,skill_speeda,skill_speedd,skill_powera,skill_powerd,skill_passing,skill_handling,skill_kicker) " +
                                          "VALUES ($01,'$02','$03','$04','$05','$06'  ,$07,$08       ,$09    ,$10    ,$11      ,$12  ,$13       ,$14      ,$15 ,$16   ,$17     ,$18    ,$19    ,$21  ,$22  ,$24  ,$26  ,$28  ,$29  ,$30   ,$31   ,$32   ,$35   ,$40           ,$41           ,$42          ,$43       ,$44        ,$45            ,$46         ,$47         ,$48         ,$49         ,$50          ,$51           ,$52         )";
                string data = "";
                foreach (System.Xml.XmlNode prop in player.ChildNodes)
                {
                    switch (prop.Name)
                    {
                        case "id": sql = sql.Replace("$01", prop.InnerText); break;
                        case "nom": sql = sql.Replace("$03", prop.InnerText.Replace("'", "''")); break;
                        case "prenom": sql = sql.Replace("$04", prop.InnerText.Replace("'", "''")); break;
                        case "country": sql = sql.Replace("$05", prop.InnerText); break;
                        case "category": sql = sql.Replace("$06", prop.InnerText); break;
                        case "age": sql = sql.Replace("$07", prop.InnerText); break;
                        //birthyear
                        //birthday
                        //injured_until
                        case "experience": sql = sql.Replace("$08", prop.InnerText); break;
                        case "salaire": sql = sql.Replace("$09", prop.InnerText); break;
                        case "placage": sql = sql.Replace("$10", prop.InnerText); break;
                        case "puissance": sql = sql.Replace("$11", prop.InnerText); break;
                        case "passe": sql = sql.Replace("$12", prop.InnerText); break;
                        case "receptionb": sql = sql.Replace("$13", prop.InnerText); break;
                        case "endurance": sql = sql.Replace("$14", prop.InnerText); break;
                        case "size": sql = sql.Replace("$15", prop.InnerText); break;
                        case "rapidite": sql = sql.Replace("$17", prop.InnerText); break;
                        case "kicking": sql = sql.Replace("$18", prop.InnerText); break;
                        case "arrivee": data = prop.InnerText.Replace("giorni", "").Trim(); break;
                        case "date_from":
                            try
                            {
                                DateTime acquisto = DateTime.Parse(prop.InnerText);
                                TimeSpan diff = DateTime.Now - acquisto;
                                sql = sql.Replace("$19", diff.Days.ToString());
                            }
                            catch (Exception ex)
                            { sql = sql.Replace("$19", prop.InnerText); }
                            break;
                        case "stat1": sql = sql.Replace("$21", prop.InnerText); break;
                        case "stat2": sql = sql.Replace("$22", prop.InnerText); break;
                        case "stat4": sql = sql.Replace("$24", prop.InnerText); break;
                        case "stat6": sql = sql.Replace("$26", prop.InnerText); break;
                        case "stat8": sql = sql.Replace("$28", prop.InnerText); break;
                        case "stat9": sql = sql.Replace("$29", prop.InnerText); break;
                        case "stat10": sql = sql.Replace("$30", prop.InnerText); break;
                        case "stat11": sql = sql.Replace("$31", prop.InnerText); break;
                        case "stat12": sql = sql.Replace("$32", prop.InnerText); break;
                        case "stat15": sql = sql.Replace("$35", prop.InnerText); break;
                        case "weight":
                            decimal peso = My.Convert.ToDecimal(prop.InnerText);
                            peso = peso * 100; int ipeso = System.Convert.ToInt32(peso);
                            sql = sql.Replace("$16", ipeso.ToString());
                            break;
                        case "skill_akickoff":  sql = sql.Replace("$40", prop.InnerText); break;   // Calci d'avvio in attacco
                        case "skill_dkickoff":  sql = sql.Replace("$41", prop.InnerText); break;   // Calci d'avvio in difesa
                        case "skill_lineout":   sql = sql.Replace("$42", prop.InnerText); break;   // Touche
                        case "skill_ruck":      sql = sql.Replace("$43", prop.InnerText); break;   // Ruck, Palle vaganti
                        case "skill_scrum":     sql = sql.Replace("$44", prop.InnerText); break;   // Mischie
                        case "skill_looseball": sql = sql.Replace("$45", prop.InnerText); break;   // Ruck, Palle vaganti
                        case "skill_speeda":    sql = sql.Replace("$46", prop.InnerText); break;   // Attacca la linea (velocità)
                        case "skill_speedd":    sql = sql.Replace("$47", prop.InnerText); break;   // Difesa su giocatori veloci
                        case "skill_powera":    sql = sql.Replace("$48", prop.InnerText); break;   // Attacca la linea (forza)
                        case "skill_powerd":    sql = sql.Replace("$49", prop.InnerText); break;   // Difesa su giocatori forti
                        case "skill_passing":   sql = sql.Replace("$50", prop.InnerText); break;   // Passaggi
                        case "skill_handling":  sql = sql.Replace("$51", prop.InnerText); break;   // Ricezione
                        case "skill_kicker":    sql = sql.Replace("$52", prop.InnerText); break;   // Calci
                    }
                }
                if (sql.Contains("$19")) sql = sql.Replace("$19", data);
                sql = sql.Replace("$02", My.SQLLite.DateToSQLite(date));
                sql = Patch2014(sql);
                if (sql.IndexOf("$") < 0) return sql;
            }
            catch (Exception ex) { My.Box.Errore("RMDB::LoadPlayerSql()\r\n" + ex.Message); }
            return "";
        }

        private string Patch2014(string sql)
        {
            sql = sql.Replace("$21", "0");
            sql = sql.Replace("$22", "0");
            sql = sql.Replace("$24", "0");
            sql = sql.Replace("$26", "0");
            sql = sql.Replace("$28", "0");
            sql = sql.Replace("$29", "0");
            sql = sql.Replace("$30", "0");
            sql = sql.Replace("$31", "0");
            sql = sql.Replace("$32", "0");
            sql = sql.Replace("$35", "0");
            sql = sql.Replace("$40", "0");
            return sql;
        }

        public bool IsEmpty()
        {
            try
            {
                DataTable dt = DB.ExecuteQuery("SELECT COUNT(*) FROM players");
                if (dt.Rows.Count > 0)
                {
                    string val = dt.Rows[0][0].ToString();
                    if (val != "0") return false;
                    else return true;
                }
            }
            catch { }
            return true;
        }

        public string[] GetDates()
        {
            DataTable dt = DB.ExecuteQuery("SELECT DISTINCT data FROM players ORDER BY data DESC");
            string[] result = new string[dt.Rows.Count];
            for (int i = 0; i < result.Length; i++) result[i] = dt.Rows[i][0].ToString();
            return result;
        }

        public DateTime GetLastEvent()
        {
            DataTable dt = DB.ExecuteQuery("SELECT MAX(data) FROM events");
            if (dt.Rows.Count > 0)
            {
                string data = dt.Rows[0][0].ToString();
                if (data!="") return DateTime.Parse(data);
            }
            return new DateTime(2000, 1, 1);
        }

        public bool NeedUpdate()
        {
            DataTable dt = DB.ExecuteQuery("SELECT MAX(data) FROM players");
            if (dt.Rows.Count > 0)
            {
                string data = dt.Rows[0][0].ToString();
                if (data != "")
                {
                    DateTime dt_data = DateTime.Parse(data);
                    if (dt_data.DayOfWeek == DayOfWeek.Thursday) if (dt_data.Hour < 5) dt_data = dt_data - new TimeSpan(1,0,0,0);
                    DateTime dt_oggi = DateTime.Now;
                    if (dt_oggi.DayOfWeek == DayOfWeek.Thursday) if (dt_oggi.Hour < 5) dt_oggi = dt_oggi - new TimeSpan(1,0,0,0);
                    if (dt_oggi > dt_data)
                    {
                        DateTime g1 = dt_data - GetSpan(dt_data.DayOfWeek);
                        DateTime g2 = dt_oggi - GetSpan(dt_oggi.DayOfWeek);
                        if ((g2 - g1) < new TimeSpan(1, 0, 0, 0)) return false;
                    } 
                    else return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calcola la distanza dal giovedi precedente
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private TimeSpan GetSpan(DayOfWeek day)
        {
            switch (day)
            {
                default:
                case DayOfWeek.Monday: return new TimeSpan(4, 0, 0, 0);
                case DayOfWeek.Tuesday: return new TimeSpan(5, 0, 0, 0);
                case DayOfWeek.Wednesday: return new TimeSpan(6, 0, 0, 0);
                case DayOfWeek.Thursday: return new TimeSpan(0, 0, 0, 0);
                case DayOfWeek.Friday: return new TimeSpan(1, 0, 0, 0);
                case DayOfWeek.Saturday: return new TimeSpan(2, 0, 0, 0);
                case DayOfWeek.Sunday: return new TimeSpan(3, 0, 0, 0);
            }
        }

        public DataTable GetPlayers(string data)
        {
            DateTime date = DateTime.Parse(data);
            string sql = string.Format("SELECT * FROM players WHERE data='{0}'",My.SQLLite.DateToSQLite(date));
            DataTable result = DB.ExecuteQuery(sql);
            return result;
        }

        public DataRow GetPlayer(string id, string data)
        {
            DateTime date = DateTime.Parse(data);
            string sql = string.Format("SELECT * FROM players WHERE (data='{0}') AND (id={1})",My.SQLLite.DateToSQLite(date),id);
            DataTable result = DB.ExecuteQuery(sql);
            if (result.Rows.Count > 0) return result.Rows[0];
            return null;
        }

        public DataTable GetEvents(DateTime da, DateTime a, string like)
        {
            DateTime daa = new DateTime(da.Year, da.Month, da.Day, 0, 0, 0);
            DateTime aa = new DateTime(a.Year, a.Month, a.Day, 0, 0, 0);
            aa = aa + new TimeSpan(1, 0, 0, 0);
            string _da = My.SQLLite.DateToSQLite(daa);
            string _a = My.SQLLite.DateToSQLite(aa);
            string sql = string.Format("SELECT * FROM events WHERE (data>='{0}') AND (data <'{1}')",_da,_a);
            if (like != "") sql += string.Format(" AND ((tipo LIKE '%{0}%')OR(detail LIKE '%{0}%')OR(player LIKE '%{0}%'))",like);
            sql += " ORDER BY data DESC";
            DataTable result = DB.ExecuteQuery(sql);
            if (result.Rows.Count > 0) return result;
            return new DataTable();
        }

        public DataTable GetEvents(string where)
        {
            string sql = "SELECT * FROM events";
            if (where != "") sql = string.Format("{0} WHERE {1}", sql, where);
            sql += " ORDER BY data DESC";
            DataTable result = DB.ExecuteQuery(sql);
            if (result.Rows.Count > 0) return result;
            return new DataTable();
        }

        public DataTable GetIDPlayers()
        {
            string sql = "SELECT DISTINCT id, nom, prenom FROM players";
            DataTable result = DB.ExecuteQuery(sql);
            return result;
        }
    }
}
