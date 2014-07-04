using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RMO
{
    public partial class MainForm : Form
    {
        public static string SPOT = ">>> RMO = RugbyMania Organizer (Go to Impostazioni->Lingua->English/French)";

        public RMDB DB { get { return Internal.DB; } set { Internal.DB = (RMDB)value; } }
        public MainForm()
        {
            try
            {
                Internal.Main = this;
                Copy();
                InitializeComponent();
                lStatus.IsLink = false;
                
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.MainLocation;
                this.Size = Properties.Settings.Default.MainSize;
                if (Properties.Settings.Default.MainMaximized) this.WindowState = FormWindowState.Maximized;

                InitDB();
                //this.Text = string.Format("RMO [{0}] [BUILD:{1}]", Internal.WORKPATH + RMDB.DBPATH,Internal.VERSION);
                this.Text = string.Format("RMO  v.{0}", Internal.VERSION);
                this.Load += new EventHandler(MainForm_Load);
                this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
                this.lStatus.Text = SPOT;
                SetCloseButton();

                menuInfo.Text = T("Informazioni su") + " " + Application.ProductName;
                SetLanguage(Properties.Settings.Default.Language, "app");

#if(DEBUG)
                menuMarket.Visible = true;
#endif
            }
            catch (Exception ex) { My.Box.Errore("MainForm::()\r\n"+ex.Message); }
        }

        #region Close Button
        private void SetCloseButton()
        {
            bClose.Image = imgClose.Images[0];
            bClose.MouseEnter += new EventHandler(bClose_MouseEnter);
            bClose.MouseLeave += new EventHandler(bClose_MouseLeave);
            bClose.MouseDown += new MouseEventHandler(bClose_MouseDown);
            bClose.MouseUp += new MouseEventHandler(bClose_MouseUp);
        }

        private void bClose_MouseUp(object sender, MouseEventArgs e)
        {
            bClose.Image = imgClose.Images[0];
            IsCloseDown = false;
        }

        private bool IsCloseDown = false;
        private void bClose_MouseDown(object sender, MouseEventArgs e)
        {
            bClose.Image = imgClose.Images[2];
            IsCloseDown = true;
        }

        private void bClose_MouseLeave(object sender, EventArgs e)
        {
            bClose.Image = imgClose.Images[0];
        }

        private void bClose_MouseEnter(object sender, EventArgs e)
        {
            bClose.Image = imgClose.Images[1];
        }
        #endregion

        private void Copy()
        {
            if (!System.IO.Directory.Exists(PATH_HISTORY_OLD)) return;
            string[] files1 = System.IO.Directory.GetFiles(PATH_HISTORY_OLD, "*.team");
            string[] files2 = System.IO.Directory.GetFiles(PATH_HISTORY_OLD, "*.events");
            foreach (string file in files1) Move(file);
            foreach (string file in files2) Move(file);
        }
        private void Move(string f1) 
        {
            if (!System.IO.Directory.Exists(PATH_HISTORY)) System.IO.Directory.CreateDirectory(PATH_HISTORY);
            string f2 = PATH_HISTORY + System.IO.Path.GetFileName(f1);
            if (!System.IO.File.Exists(f2)) System.IO.File.Move(f1, f2); 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeDB();
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainLocation = this.Location;
                Properties.Settings.Default.MainSize = this.Size;
            }
            Properties.Settings.Default.MainMaximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.RM_User = textUser.Text;
            Properties.Settings.Default.RM_Password = textPwd.Text;
            Properties.Settings.Default.RM_Codice = textCodice.Text;
            Properties.Settings.Default.RM_Id = textID.Text;
            Properties.Settings.Default.PlayerOrderSkill = Control.Player.OrderSkill.ToString();
            Properties.Settings.Default.PlayerOrderAsc = Control.Player.OrderReverse;
            Properties.Settings.Default.GrayLines = menuAlternateLines.Checked;
            Properties.Settings.Default.Save();
        }

        private void InitDB()
        {
            DB = new RMDB();
        }

        private void DisposeDB()
        {
            if (DB != null) { DB.Dispose(); DB = null; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(InitApp));
            t.IsBackground = true; t.Priority = System.Threading.ThreadPriority.Lowest;
            t.Start();
        }

        private void InitApp()
        {
            try
            {
                textUser.Text = Properties.Settings.Default.RM_User;
                textPwd.Text = Properties.Settings.Default.RM_Password;
                textCodice.Text = Properties.Settings.Default.RM_Codice;
                textID.Text = Properties.Settings.Default.RM_Id;
                menuCheckUpdates.Checked = Properties.Settings.Default.CheckUpdates;
                menuAlternateLines.Checked = Properties.Settings.Default.GrayLines;
                menuColorPari.BackColor = Properties.Settings.Default.LinesColor1;
                menuColorDispari.BackColor = Properties.Settings.Default.LinesColor2;
                menuSkillZero.BackColor = Properties.Settings.Default.Skill_0;
                menuColorU21.BackColor = Properties.Settings.Default.Color_U21;
                menuColorU25.BackColor = Properties.Settings.Default.Color_U25;
                menuColorTraining.BackColor = Properties.Settings.Default.Color_Allenamento;
                menuColorScattoPiu.BackColor = Properties.Settings.Default.Color_ScattoPiu;
                menuScattoMeno.BackColor = Properties.Settings.Default.Color_ScattoMeno;

                Control.Player.OrderSkill = RMO.Control.Player.GetSkillFromString(Properties.Settings.Default.PlayerOrderSkill);
                Control.Player.OrderReverse = Properties.Settings.Default.PlayerOrderAsc;
                if (DB.NEW_DATABASE) RebuildDatabase();
                if (!DB.IsEmpty()) this.Invoke(new MethodInvoker(ShowPlayers));
                groupLogin.Enabled = true;
                no_update_message = false;
                if (Properties.Settings.Default.CheckUpdates)
                    menuUpdate_Click(null, EventArgs.Empty);
                StatusString = SPOT;

            }
            catch (Exception ex) { My.Box.Errore("MainForm::InitApp()\r\n" + ex.Message); }
        }

        private void menuEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string PATH_HISTORY { get { return Internal.WORKPATH + Internal.BAR + "xml" + Internal.BAR; } }
        public string PATH_HISTORY_OLD { get { return Application.StartupPath + Internal.BAR + "xml" + Internal.BAR; } }

        private void LoadTeamHistory()
        {
            if (!System.IO.Directory.Exists(PATH_HISTORY)) return;
            string[] files = System.IO.Directory.GetFiles(PATH_HISTORY, "*.team");
            string sql = "";
            foreach (string file in files)
            {
                sql += DB.LoadTeam(file,false);
            }
            StatusString = T("Aggiornamento del database in corso...");
            DB.Execute(sql);
            StatusString = T("Aggiornamento del database completato!");
        }

        private void LoadEventHistory()
        {
            StatusString = T("Caricamento degli eventi nel database in corso...");
            if (!System.IO.Directory.Exists(PATH_HISTORY)) return;
            string[] files = System.IO.Directory.GetFiles(PATH_HISTORY, "*.events");
            foreach (string file in files)
            {
                string content = System.IO.File.ReadAllText(file, Encoding.UTF8);
                Internal.DB.Execute(content);
            }
            StatusBar.Value = 0;
            StatusString = T("Aggiornamento del database completato!");
        }

        private void bnEntra_Click(object sender, EventArgs e)
        {
            bool ok = UpdateRemoteData();
            if (ok) ShowPlayers();

            // Salva i settaggi corretti
            Properties.Settings.Default.RM_User = textUser.Text;
            Properties.Settings.Default.RM_Password = textPwd.Text;
            Properties.Settings.Default.RM_Codice = textCodice.Text;
            Properties.Settings.Default.RM_Id = textID.Text;
            Properties.Settings.Default.Save();
        }


        private bool UpdateRemoteData()
        {
            bool result = false;
            bnEntra.Enabled = false;
            menuAggiorna.Enabled = toolAggiorna.Enabled = false;
            try
            {
                string url = @"http://www.rugbymania.net/export_xml_part.php?lang=italiano&id=$1&access_key=$2&object=players";
                url = url.Replace("$1", textID.Text);
                url = url.Replace("$2", textCodice.Text);
                string pagina = GetWebPage(url, "", true);
                if ((pagina != "")&&(pagina != "\r\n"))
                {
                    string file = SaveHistory(pagina);
                    if (System.IO.File.Exists(file)) DB.LoadTeam(file, true);
                    result = true;
                }
                else
                {
                    Error_on_xml();
                    result = false;
                }
            }
            catch (Exception ex) { My.Box.Errore("MainForm::UpdateRemoteData()\r\n" + ex.Message); }
            menuAggiorna.Enabled = toolAggiorna.Enabled = true;
            return result;
        }

        public void Error_on_xml()
        {
            this.menuLogin_Click(null, EventArgs.Empty);
            lAlert.Text = T("ID o Codice di accesso errato.");
            lAlert.Visible = true;
        }

        private string SaveHistory(string pagina)
        {
            try
            {
                string dir = Internal.WORKPATH + Internal.BAR + "xml" + Internal.BAR;
                string name = RMHTML.GetDate() + ".team";
                string file = dir + name;
                if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
                System.IO.File.WriteAllText(file, pagina, Encoding.UTF8);
                return file;
            }
            catch (Exception ex) { Internal.Log("MainForm::SaveHistory",ex.Message); }
            return "";
        }

        private bool IsLoginOK()
        {
            bool ok = (LAST_HEADERS.IndexOf("Location: club.php") > 0);
            if (!ok) ok = (LAST_HEADERS.IndexOf("Location: vote.php") > 0);
            return ok;
        }
        /*
         * 
OK
Pragma: no-cache
Vary: Accept-Encoding,User-Agent
Keep-Alive: timeout=25, max=100
Connection: Keep-Alive
Transfer-Encoding: chunked
Cache-Control: no-store, no-cache, must-revalidate, post-check=0, pre-check=0
Content-Type: text/html
Date: Tue, 03 Nov 2009 09:19:17 GMT
Expires: Thu, 19 Nov 1981 08:52:00 GMT
Set-Cookie: PHPSESSID=5adc7bf20a97e802d92b80b39d80dd44; path=/
Server: Apache
X-Powered-By: PHP/5.2.5-pl1-gentoo

Status Code: OK
From: http://www.rugbymania.net/play.php
ISO-8859-1
         * 
         * 
         * Pragma: no-cache
Cache-Control: no-store, no-cache, must-revalidate, post-check=0, pre-check=0
Date: Tue, 03 Nov 2009 09:21:26 GMT
Expires: Thu, 19 Nov 1981 08:52:00 GMT
Set-Cookie: PHPSESSID=c9594328a33747715278e967cdd0a198; path=/,cookielogin=%2C+%233087%23; expires=Wed, 03-Nov-2010 09:21:26 GMT
Server: Apache
X-Powered-By: PHP/5.2.5-pl1-gentoo
Location: club.php
Vary: Accept-Encoding,User-Agent
Content-Length: 0
Content-Type: text/html

Status Code: Found
From: http://www.rugbymania.net/ctrl_account.php
ISO-8859-1
         */

        private string LAST_HEADERS = "";
        private CookieContainer LAST_Cookies = null;
        public string GetWebPage(string url, string postData, bool alert)
        {
            string pagina = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (LAST_Cookies == null) LAST_Cookies = new CookieContainer();
                request.CookieContainer = LAST_Cookies;
                request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; it; rv:1.9.0.6) Gecko/2009011913 Firefox/3.0.7";
                if (postData.Length > 0) request.Method = WebRequestMethods.Http.Post;
                else request.Method = WebRequestMethods.Http.Get;
                request.Accept = "text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
                request.AllowAutoRedirect = false;
                request.KeepAlive = true;
                request.ContentType = @"application/x-www-form-urlencoded";
                Encoding enc = System.Text.Encoding.Default;
                if (postData.Length > 0)
                {
                    byte[] postBuffer = enc.GetBytes(postData);
                    request.ContentLength = postBuffer.Length;
                    System.IO.Stream postDataStream = request.GetRequestStream();
                    postDataStream.Write(postBuffer, 0, postBuffer.Length);
                    postDataStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                LAST_Cookies = new CookieContainer();
                foreach (Cookie aCookie in response.Cookies)
                {
                    LAST_Cookies.Add(new Cookie(aCookie.Name, aCookie.Value, aCookie.Path, aCookie.Domain));
                }

                // Read the response from the stream
                System.IO.StreamReader responseStream = new System.IO.StreamReader(response.GetResponseStream(), enc, true);
                pagina = responseStream.ReadToEnd();

                LAST_HEADERS = response.Headers.ToString();
                LAST_HEADERS += "Status Code: " + response.StatusCode;
                LAST_HEADERS += "\r\nFrom: " + response.ResponseUri.ToString();
                LAST_HEADERS += "\r\n" + response.CharacterSet.ToString();

                response.Close();
                responseStream.Close();
            }
            catch (Exception ex) 
            { 
                if (alert)
                    My.Box.Errore("Impossibile connettersi ad internet!\r\nVerifica le impostazioni della tua: connessione, proxy e firewall.\r\n\r\n"+ex.Message); 
            }
            return pagina;
        }

        public string Download(string url, string parameters)
        {
            try
            {
                My.HTTP.DownloadThread dl = new My.HTTP.DownloadThread();
                dl.DownloadUrl = url;
                dl.DownloadParameters = parameters;
                dl.CompleteCallback += new My.HTTP.DownloadCompleteHandler(DownloadCompleteCallback);
                dl.ProgressCallback += new My.HTTP.DownloadProgressHandler(DownloadProgressCallback);
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(dl.Download));
                t.Start(); t.Join();
                return Downloaded;
            }
            catch (System.Exception ex) { My.Box.Errore("MainForm::Download()\r\n"+ex.Message); return ""; }
        }

        private void DownloadProgressCallback(int bytesSoFar, int totalBytes)
        {
            string strSoFar = bytesSoFar.ToString("#,##0");
            string strTotal = totalBytes.ToString("#,##0");
            lStatus.Text = T("Download... ") + " (" + strSoFar + "/" + strTotal + ")";
            if (totalBytes != -1)
            {
                progressBar.Value = bytesSoFar;
                progressBar.Maximum = totalBytes;
            }
            else
            {
                progressBar.Value = 0;
                progressBar.Maximum = 100;
                lStatus.Text = "";
            }
        }

        private string Downloaded = "";
        private void DownloadCompleteCallback(byte[] dataDownloaded)
        {
            lStatus.Text = T("Download completato.");
            if (dataDownloaded != null)
            {
                string file = System.IO.Path.GetTempFileName();
                System.IO.BinaryWriter outStream = new System.IO.BinaryWriter(new System.IO.FileStream(file, System.IO.FileMode.Create));
                outStream.Write(dataDownloaded);
                outStream.Close();
                Downloaded = System.IO.File.ReadAllText(file);
            }
            else Downloaded = "";
        }

        private void pageLogin_SizeChanged(object sender, EventArgs e)
        {
            int x = (pageLogin.Width - groupLogin.Width) / 2;
            int y = (pageLogin.Height - groupLogin.Height) / 2;
            groupLogin.Location = new Point(x, y);
        }

        private void ShowPlayers()
        {
            tabControl1.TabPages.Remove(pageLogin);
            //if (GetPageIndex(T("La mia squadra"))<0) menuTeam_Click(null, EventArgs.Empty);
            if (GetPageIndex("squadra") < 0) menuTeam_Click(null, EventArgs.Empty);
        }

        private void menuFormazione_Click(object sender, EventArgs e)
        {
            if (!menuFormazione.Checked)
            {
                Tab.TabFormazione page = new RMO.Tab.TabFormazione();
                TabPage tpage = page.GetTab();
                tpage.ImageIndex = 1;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                toolFormazione.Checked = menuFormazione.Checked = true;
                page.LoadFromDB();
            }
            else
            {
                //int index = GetPageIndex(T("Formazione"));
                int index = GetPageIndex("formazione");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                toolFormazione.Checked = menuFormazione.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        public string StatusString { get { return lStatus.Text; } set { lStatus.Text = (string)value; } }
        public ToolStripProgressBar StatusBar { get { return progressBar; } }

        private void menuAggiorna_Click(object sender, EventArgs e)
        {
            bool ok = UpdateRemoteData();
            if (!ok)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(pageLogin);
            }
            else ShowPlayers();
        }

        private Tab.TabWeb WebPage = null;
        public void ShowPlayer(string id)
        {
            if (WebPage == null) WebPage = new RMO.Tab.TabWeb();
            TabPage page = WebPage.GetTab();
            page.ImageIndex = 5;
            if (!tabControl1.TabPages.Contains(page)) tabControl1.TabPages.Add(page);
            if (tabControl1.SelectedTab != page) tabControl1.SelectedTab = page;
            WebPage.ShowPlayer(id);
            toolWWW.Checked = menuWWW.Checked = true;
        }

        public void ShowPlayer2(string id)
        {
            Tab.TabPlayer t = new RMO.Tab.TabPlayer();
            TabPage page = t.GetTab();
            page.ImageIndex = 6;
            tabControl1.TabPages.Add(page);
            tabControl1.SelectedTab = page;
            t.LoadGiocatore(id);
        }

        public void ShowRM(string url)
        {
            if (WebPage == null) WebPage = new RMO.Tab.TabWeb();
            TabPage page = WebPage.GetTab();
            page.ImageIndex = 5;
            if (!tabControl1.TabPages.Contains(page)) tabControl1.TabPages.Add(page);
            if (tabControl1.SelectedTab != page) tabControl1.SelectedTab = page;
            WebPage.GotToRMUrl(url);
            toolWWW.Checked = menuWWW.Checked = true;
        }

        private void menuInfo_Click(object sender, EventArgs e)
        {
            About d = new About();
            d.ShowDialog();
            d.Dispose();
            d = null;
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(UpdateApp);
            System.Threading.Thread t = new System.Threading.Thread(ts);
            t.Start(); 	
        }

        private bool no_update_message = true;
        private void UpdateApp()
        {
            try
            {
                if (NewUpdate())
                {
                    if (My.Box.Conferma(T("E' disponibile una nuova versione del programma, desideri aggiornare?")))
                    {
                        try
                        {
                            Internal.DB.Dispose();
                            Internal.DB = null;
                            System.IO.File.Delete(Internal.WORKPATH + RMDB.DBPATH);
                        }
                        catch (Exception ex) { Internal.Log("MainForm::UpdateApp()",ex.Message); }

                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "Update.exe";
                        p.StartInfo.Verb = "runas";
                        p.StartInfo.WorkingDirectory = Application.StartupPath;
                        p.StartInfo.Arguments = "\"$1\" \"$2\" \"$3\" ";
                        p.StartInfo.Arguments = p.StartInfo.Arguments.Replace("$1", "RMO");
                        p.StartInfo.Arguments = p.StartInfo.Arguments.Replace("$2", UPDATEXML);
                        p.StartInfo.Arguments = p.StartInfo.Arguments.Replace("$3", Application.StartupPath.Replace("\\",""+Internal.BAR));
                        p.Start();

                        this.Close();
                    }
                }
                else
                {
                    if (no_update_message) My.Box.Info(T("Nessun nuovo aggiornamento disponibile"));
                    if (Internal.DB != null)
                    {
                        if (Internal.DB.NeedUpdate())
                        {
                            if (My.Box.Conferma(T("E' ora di aggiornare i dati della tua squadra, aggiorno?")))
                                this.Invoke(new MethodInvoker(Aggiorna));
                        }
                    }
                }
            }
            catch (Exception ex) { Internal.Log("MainForm::UpdateApp()",ex.Message); }
            no_update_message = true;
        }

        private void Aggiorna()
        {
            this.menuAggiorna_Click(null, EventArgs.Empty);
        }

        private static string UPDATEXML = "http://faze.altervista.org/rmo/rmo32.xml";
        //private static string UPDATEXML = "http://faze.altervista.org/rmo/rmo32.xml";
        
        private bool NewUpdate()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(UPDATEXML);
                string root = "rmo";
                System.Xml.XmlNodeList list = doc.GetElementsByTagName(root);
                if (list.Count > 0)
                {
                    System.Collections.ArrayList downloadlist = new System.Collections.ArrayList();
                    System.Xml.XmlNode node_root = list[0];
                    if (node_root.Attributes["version"] != null)
                    {
                        string ver = node_root.Attributes["version"].Value.ToString();
                        int version = System.Convert.ToInt32(ver);
                        if (version > Internal.VERSION) return true;
                    }
                }
            }
            catch (Exception ex) { Internal.Log("MainForm::NewUpdate()",ex.Message); }
            return false;
        }

        private void menuDownloadEvents_Click(object sender, EventArgs e)
        {
            bool execute = false;
            if (Internal.DB == null) { My.Box.Info(T("Database non trovato!")+"\r\nMainForm::menuDownloadEvents_Click"); return; }
            DataTable dt = Internal.DB.GetEvents(new DateTime(2000,01,01),DateTime.Now,"");
            if ((dt==null)||(dt.Rows.Count == 0))
            {
                string msg = T("Il download degli eventi è una operazione molto lunga (10 minuti circa), siete sicuri di volerla eseguire ora?");
                msg += "\r\n"+T("E' necessario lasciare aperto il programma fino al termine dell'operazione!");
                if (My.Box.Conferma(msg)) execute = true;
            }
            else execute = true;
            if (execute)
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(DownloadAllEvents));
                t.IsBackground = true; t.Priority = System.Threading.ThreadPriority.Lowest;
                t.Start();
            }
        }

        public static string LOGINURL1 = @"http://www.rugbymania.net/play.php";
        public static string LOGINURL2 = @"http://www.rugbymania.net/ctrl_account.php";

        private void DownloadAllEvents()
        {
            int z = 0;
            bnEntra.Enabled = false; z++;
            if (!menuDownloadEvents.Enabled) return;
            menuDownloadEvents.Enabled = toolDownloadEvents.Enabled = false; z++;
            try
            {
                z++; bool ok1 = My.Box.Conferma(string.Format("Sei sicuro che i tuoi dati siano i seguenti?\r\nLogin: {0}\r\nPassword: {1}\r\n", textUser.Text, textPwd.Text));
                z++; string autenticazione = "log_id=" + textUser.Text + "&log_password=" + textPwd.Text;
                z++; string pagina = GetWebPage(LOGINURL1, autenticazione, true);
                z++; pagina = GetWebPage(LOGINURL2, autenticazione, true);
                z++; bool ok2 = IsLoginOK();
                if (ok1 && ok2)
                {
                    z++; int inserted = 1; int counter = 0; int allcounter = 0;
                    while (inserted > 0)
                    {
                        z++; string url = "http://www.rugbymania.net/journal.php?debut=" + counter.ToString();
                        z++; StatusString = T("Download di ") + url;
                        z++; pagina = GetWebPage(url, "", true);
                        z++; StatusString = T("Elaborazione di ") + url;
                        if (pagina != "")
                        {
                            z++; inserted = Tab.TabEvents.ProcessEvents(pagina, false);
                            z++; counter = counter + 30;
                            z++; allcounter += inserted;
                        }
                        else
                        {
                            z++; pagina = GetWebPage(LOGINURL1, autenticazione, true);
                            z++; pagina = GetWebPage(LOGINURL2, autenticazione, true);
                        }
                    }
                    z++; StatusString = string.Format(T("Download di tutti gli eventi terminato! {0} eventi inseriti"), allcounter.ToString());
                    z++; Internal.DB.SetVersion(true);
                    z++; this.Invoke(new MethodInvoker(Internal.DBChanged));
                }
                else
                {
                    My.Box.Info("Nome utente o password errati.");
                    z++; this.Invoke(new MethodInvoker(InvokeLogin));
                    z++; lAlert.Text = T("Nome utente o password errati.");
                    z++; lAlert.Visible = true;
                }
            }
            catch (Exception ex) 
            {
                if (Properties.Settings.Default.RM_User.Length == 0)
                    My.Box.Errore(T("E' necessario inserire il nome utente di RM!"));
                if (Properties.Settings.Default.RM_Password.Length == 0)
                    My.Box.Errore(T("E' necessario inserire la password di RM!"));
                My.Box.Errore("MainForm::DownloadAllEvents()\r\n" + ex.Message + "\r\nERRORE: " +z.ToString()); 
            }
            menuDownloadEvents.Enabled = toolDownloadEvents.Enabled = true;
        }

        public string DownloadNazionale(bool alert)
        {
            try
            {
                string autenticazione = "log_id=" + textUser.Text + "&log_password=" + textPwd.Text;
                string pagina = GetWebPage(LOGINURL1, autenticazione, alert);
                pagina = GetWebPage(LOGINURL2, autenticazione, alert);
                bool ok = IsLoginOK();
                if (ok)
                {
                    string url = @"http://www.rugbymania.net/national_staff.php";
                    pagina = GetWebPage(url, "", alert);
                    return pagina;
                }
            }
            catch (Exception ex)
            {
                My.Box.Errore("Impossibile scaricare i dati della squadra\r\n"+ex.Message);
            }
            return "";
        }

        public string GetRMPage(string url)
        {
            try
            {
                string pagina = GetWebPage(LOGINURL1, "log_id=" + textUser.Text + "&log_password=" + textPwd.Text + "", true);
                pagina = GetWebPage(LOGINURL2, "log_id=" + textUser.Text + "&log_password=" + textPwd.Text + "", true);
                if (IsLoginOK())
                {
                    pagina = GetWebPage(url,"", true);
                    return pagina;
                }
            }
            catch (Exception ex) { My.Box.Errore("MainForm::GetRMPage()()\r\n" + ex.Message); }
            return "";
        }

        private void menuEventi_Click(object sender, EventArgs e)
        {
            if (!menuEventi.Checked)
            {
                Tab.TabEvents page = new RMO.Tab.TabEvents();
                TabPage tpage = page.GetTab();
                tpage.ImageIndex = 4;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                toolEventi.Checked = menuEventi.Checked = true;
                page.LoadFromDB();
            }
            else
            {
                //int index = GetPageIndex(T("Gestione Eventi"));
                int index = GetPageIndex("eventi");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                toolEventi.Checked = menuEventi.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void menuClassifica_Click(object sender, EventArgs e)
        {
            if (!menuClassifica.Checked)
            {
                Tab.TabClassifica page = new RMO.Tab.TabClassifica();
                TabPage tpage = page.GetTab();
                tpage.ImageIndex = 2;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                toolClassifica.Checked = menuClassifica.Checked = true;
            }
            else
            {
                //int index = GetPageIndex(T("La Classifica"));
                int index = GetPageIndex("classifica");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                toolClassifica.Checked = menuClassifica.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void menuPartite_Click(object sender, EventArgs e)
        {
            if (!menuPartite.Checked)
            {
                Tab.TabPartite page = new RMO.Tab.TabPartite();
                TabPage tpage = page.GetTab();
                tpage.ImageIndex = 3;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                toolPartite.Checked = menuPartite.Checked = true;
            }
            else
            {
                int index = GetPageIndex("partite");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                toolPartite.Checked = menuPartite.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void menuTeam_Click(object sender, EventArgs e)
        {
            if (!menuTeam.Checked)
            {
                Tab.TabTeam page = new RMO.Tab.TabTeam();
                TabPage tpage = page.GetTab();
                tpage.ImageIndex = 0;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                toolTeam.Checked = menuTeam.Checked = true;
                page.LoadFromDB();
            }
            else
            {
                //int index = GetPageIndex(T("La mia squadra"));
                int index = GetPageIndex("squadra");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                toolTeam.Checked = menuTeam.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void menuNazionale_Click(object sender, EventArgs e)
        {
            if (!menuNazionale.Checked)
            {
                Tab.TabNazionale page = new RMO.Tab.TabNazionale();
                TabPage tpage = page.GetTab();
                tpage.ImageIndex = 7;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                menuTeam.Checked = true;
                page.LoadFromWWW();
            }
            else
            {
                int index = GetPageIndex("nazionale");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                menuTeam.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void menuWWW_Click(object sender, EventArgs e)
        {
            if (!menuWWW.Checked)
            {
                if (WebPage == null) WebPage = new RMO.Tab.TabWeb();
                TabPage tpage = WebPage.GetTab();
                tpage.ImageIndex = 5;
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                toolWWW.Checked = menuWWW.Checked = true;
                WebPage.GoToURL(@"http://rugbymaniaitalia.forumfree.net");
            }
            else
            {
                if (WebPage != null) { WebPage.Dispose(); WebPage = null; }
                //int index = GetPageIndex(T("Navigazione Web"));
                int index = GetPageIndex("www");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                toolWWW.Checked = menuWWW.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void menuMarket_Click(object sender, EventArgs e)
        {
            if (!menuMarket.Checked)
            {
                Tab.TabMarket page = new RMO.Tab.TabMarket();
                TabPage tpage = page.GetTab();
                tabControl1.TabPages.Add(tpage);
                tabControl1.SelectedTab = tpage;
                menuMarket.Checked = true;
            }
            else
            {
                //int index = GetPageIndex(T("Il Mercato"));
                int index = GetPageIndex("mercato");
                if (index >= 0)
                {
                    this.tabControl1.SelectedTab = null;
                    this.tabControl1.TabPages.RemoveAt(index);
                    this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                }
                menuMarket.Checked = false;
            }
            tabControl1_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private int GetPageIndex(string s)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                TabPage page = this.tabControl1.TabPages[i];
                //if (page.Text.IndexOf(s) >= 0) return i;
                if (((string)page.Tag).IndexOf(s) >= 0) return i;
            }
            return -1;
        }

        public void Rebuild_Database() { this.menuRebuild_Click(null, EventArgs.Empty); }
        private void menuRebuild_Click(object sender, EventArgs e)
        {
            string msg = T("Sei sicuro di voler ricostruire il database?")+"\r\n";
            msg += T("Eseguite questo comando solo se siete certi di quello che state facendo,")+"\r\n";
            msg += T("Questa operazione potrebbe durare a lungo ed RMO apparire bloccato!");
            if (My.Box.Conferma(msg))
            {
                DisposeDB();
                try { System.IO.File.Delete(Internal.WORKPATH + RMDB.DBPATH); }
                catch {
                    My.Box.Info(T("Impossibile ricostruire il database, eliminare il file db.s3db"));
                    this.menuConfigDir_Click(sender, EventArgs.Empty);
                    return; 
                }
                InitDB();

                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(RebuildDatabase));
                t.IsBackground = true; t.Priority = System.Threading.ThreadPriority.Lowest;
                t.Start();
            }
        }

        private void RebuildDatabase()
        {
            MyBeginUpdate();
            LoadTeamHistory();
            LoadEventHistory();
            MyEndUpdate();
            Internal.DB.SetVersion(true);
            this.Invoke(new MethodInvoker(Internal.DBChanged));
        }

        private void MyBeginUpdate()
        {
            tabControl1.Visible = false;
            labelUpdate.Visible = true;
            labelUpdate.Refresh();
            this.Refresh();
        }

        private void MyEndUpdate()
        {
            labelUpdate.Visible = false;
            tabControl1.Visible = true;
        }

        private void menuCheckUpdates_Click(object sender, EventArgs e)
        {
            menuCheckUpdates.Checked = !menuCheckUpdates.Checked;
            Properties.Settings.Default.CheckUpdates = menuCheckUpdates.Checked;
            Properties.Settings.Default.Save();
        }

        private void toolTeam_Click(object sender, EventArgs e)
        {
            menuTeam_Click(null, EventArgs.Empty);
        }

        private void toolFormazione_Click(object sender, EventArgs e)
        {
            menuFormazione_Click(null, EventArgs.Empty);
        }

        private void toolEventi_Click(object sender, EventArgs e)
        {
            menuEventi_Click(null, EventArgs.Empty);
        }

        private void toolAggiorna_Click(object sender, EventArgs e)
        {
            menuAggiorna_Click(null, EventArgs.Empty);
        }

        private void toolDownloadEvents_Click(object sender, EventArgs e)
        {
            menuDownloadEvents_Click(null, EventArgs.Empty);
        }

        private void toolClassifica_Click(object sender, EventArgs e)
        {
            menuClassifica_Click(null, EventArgs.Empty);
        }

        private void toolPartite_Click(object sender, EventArgs e)
        {
            menuPartite_Click(null, EventArgs.Empty);
        }

        private void toolWWW_Click(object sender, EventArgs e)
        {
            menuWWW_Click(null, EventArgs.Empty);
        }

        private void menuExportTeamData_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.AddExtension = true;
            d.DefaultExt = ".zip";
            d.Filter = T("Tutti i file ZIP (*.zip)")+"|*.zip";
            d.FileName = "RMO-Team-Data-" + DateTime.Now.ToString("yyyy-MM-dd") + ".zip";
            d.InitialDirectory = My.Dir.Desktop;
            d.OverwritePrompt = true;
            d.Title = T("Nome del file da esportare");
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] filenames = System.IO.Directory.GetFiles(PATH_HISTORY, "*.team");
                    progressBar.Value = 0;
                    progressBar.Maximum = filenames.Length;
                    using (ICSharpCode.SharpZipLib.Zip.ZipOutputStream s = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(System.IO.File.Create(d.FileName)))
                    {
                        s.SetLevel(9);
                        byte[] buffer = new byte[4096];
                        foreach (string file in filenames)
                        {
                            ICSharpCode.SharpZipLib.Zip.ZipEntry entry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(System.IO.Path.GetFileName(file));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);
                            using (System.IO.FileStream fs = System.IO.File.OpenRead(file))
                            {
                                int sourceBytes;
                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    s.Write(buffer, 0, sourceBytes);
                                }
                                while (sourceBytes > 0);
                            }
                            progressBar.Value++;
                        }
                        s.Finish();
                        s.Close();
                        lStatus.Text = T("Esportazione del backup ultimata correttamente!");
                    }
                }
                catch (Exception ex) { My.Box.Errore(T("Errore durante l'esportazione del backup")+"\r\n"+ex.Message); }
                progressBar.Value = 0;
            }
        }

        private void menuImportTeamData_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.CheckFileExists = true;
            d.CheckPathExists = true;
            d.Filter = T("Tutti i file ZIP (*.zip)")+"|*.zip";
            d.InitialDirectory = My.Dir.Desktop;
            d.Multiselect = false;
            d.Title = T("Importa dati precedentemente importati");
            if (d.ShowDialog() == DialogResult.OK)
            {
                string file = d.FileName;
                try
                {
                    if (!System.IO.Directory.Exists(PATH_HISTORY)) System.IO.Directory.CreateDirectory(PATH_HISTORY);
                    using (ICSharpCode.SharpZipLib.Zip.ZipInputStream s = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(System.IO.File.OpenRead(file)))
                    {
                        ICSharpCode.SharpZipLib.Zip.ZipEntry theEntry;
                        while ((theEntry = s.GetNextEntry()) != null)
                        {
                            lStatus.Text = string.Format(T("Importazione di {0}"), theEntry.Name);
                            string fileName = System.IO.Path.GetFileName(theEntry.Name);
                            if (fileName != String.Empty)
                            {
                                string new_path = PATH_HISTORY + "\\" + fileName;
                                using (System.IO.FileStream streamWriter = System.IO.File.Create(new_path))
                                {
                                    int size = 2048;
                                    byte[] data = new byte[2048];
                                    while (true)
                                    {
                                        size = s.Read(data, 0, data.Length);
                                        if (size > 0) streamWriter.Write(data, 0, size);
                                        else break;
                                    }
                                }
                            }
                        }
                        lStatus.Text = T("Import ultimato correttamente");
                    }
                }
                catch (Exception ex) { My.Box.Errore(T("Errore durante l'importazione del backup")+"\r\n" + ex.Message); }
            }
        }

        private void InvokeLogin()
        {
            menuLogin_Click(null, EventArgs.Empty);
        }

        private void menuLogin_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(pageLogin);
            bnEntra.Enabled = true;
            lAlert.Text = "";
            lAlert.Visible = false;
            // Ho eliminato tutte le pagine visualizzate
            menuClassifica.Checked = toolClassifica.Checked = false;
            menuPartite.Checked = toolPartite.Checked = false;
            menuTeam.Checked = toolTeam.Checked = false;
            menuFormazione.Checked = toolFormazione.Checked = false;
            menuEventi.Checked = toolEventi.Checked = false;
        }

        private void menuConfigDir_Click(object sender, EventArgs e)
        {
            My.Shell.ExploreFolder(Internal.WORKPATH, this.Handle);
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            /*
            if (this.tabControl1.SelectedIndex == GetPageIndex(T("La mia squadra"))) menuTeam_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex(T("Formazione"))) menuFormazione_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex(T("La Classifica"))) menuClassifica_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex(T("Le Partite"))) menuPartite_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex(T("Gestione Eventi"))) menuEventi_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex(T("Navigazione Web"))) menuWWW_Click(null, EventArgs.Empty);
             * */
            if (this.tabControl1.SelectedIndex == GetPageIndex("squadra")) menuTeam_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex("formazione")) menuFormazione_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex("classifica")) menuClassifica_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex("partite")) menuPartite_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex("eventi")) menuEventi_Click(null, EventArgs.Empty);
            else if (this.tabControl1.SelectedIndex == GetPageIndex("www")) menuWWW_Click(null, EventArgs.Empty);
            else
            {
                if (tabControl1.SelectedTab != null)
                {
                    int index = GetPageIndex((string)tabControl1.SelectedTab.Tag);
                    tabControl1.SelectedTab = null;
                    tabControl1.TabPages.RemoveAt(index);
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bClose.Visible = (tabControl1.TabPages.Count > 0);
        }

        private void menuEventReset_Click(object sender, EventArgs e)
        {
            Internal.DB.ResetEvents();
            // Scarica nuovamente tutti gli eventi
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(DownloadAllEvents));
            t.IsBackground = true; t.Priority = System.Threading.ThreadPriority.Lowest;
            t.Start();
        }

        private void menuLDefault_Click(object sender, EventArgs e)
        {
            if (menuLDefault.Checked) return;
            string old = Properties.Settings.Default.Language;
            foreach (ToolStripMenuItem item in menuLingue.DropDownItems)
            {
                if (item.Checked) old = (string)item.Tag;
                item.Checked = false;
            }
            SetLanguage("app",old);
            Properties.Settings.Default.Language = "app";
        }

        private void menuLItalian_Click(object sender, EventArgs e)
        {
            if (menuLItalian.Checked) return;
            string old = Properties.Settings.Default.Language;
            foreach (ToolStripMenuItem item in menuLingue.DropDownItems)
            {
                if (item.Checked) old = (string)item.Tag;
                item.Checked = false;
            }
            SetLanguage("italian",old);
            Properties.Settings.Default.Language = "italian";
        }

        private void menuLEnglish_Click(object sender, EventArgs e)
        {
            if (menuLEnglish.Checked) return;
            string old = Properties.Settings.Default.Language;
            foreach (ToolStripMenuItem item in menuLingue.DropDownItems)
            {
                if (item.Checked) old = (string)item.Tag;
                item.Checked = false;
            }
            SetLanguage("english", old);
            Properties.Settings.Default.Language = "english";
        }

        private void menuLFrench_Click(object sender, EventArgs e)
        {
            if (menuLFrench.Checked) return;
            string old = Properties.Settings.Default.Language;
            foreach (ToolStripMenuItem item in menuLingue.DropDownItems)
            {
                if (item.Checked) old = (string)item.Tag;
                item.Checked = false;
            }
            SetLanguage("french", old);
            Properties.Settings.Default.Language = "french";
        }

        public static void T(object f) { if (Internal.Translate != null) Internal.Translate.Traduci(f); }
        public static string T(string s) { if (Internal.Translate != null) return Internal.Translate.Traduci(s); return s; }

        private void SetLanguage(string language,string from)
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture
            switch (language)
            {
                case "app": menuLDefault.Checked = true;
                    menuLItalian.Checked = menuLEnglish.Checked = menuLFrench.Checked = false;
                    break;
                case "italian": menuLItalian.Checked = true;
                    menuLDefault.Checked = menuLEnglish.Checked = menuLFrench.Checked = false;
                    break;
                case "english": menuLEnglish.Checked = true;
                    menuLDefault.Checked = menuLItalian.Checked = menuLFrench.Checked = false;
                    break;
                case "french": menuLFrench.Checked = true;
                    menuLDefault.Checked = menuLItalian.Checked = menuLEnglish.Checked = false;
                    break;
            }
            try { Internal.Translate = new My.Translate(language,from); }
            catch (Exception ex)
            {
                My.Box.Errore(ex.Message);
                Internal.Translate = null; 
            } 
            T(this);
        }

        private void menuAlternateLines_Click(object sender, EventArgs e)
        {
            menuAlternateLines.Checked = !menuAlternateLines.Checked;
            Properties.Settings.Default.GrayLines = menuAlternateLines.Checked;
            Internal.DBChanged();
        }

        #region Gestione dei colori utente
        private void menuColorPari_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.LinesColor1);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LinesColor1 = d.PrimaryColor;
                menuColorPari.BackColor = Properties.Settings.Default.LinesColor1;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuColorDispari_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.LinesColor2);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LinesColor2 = d.PrimaryColor;
                menuColorDispari.BackColor = Properties.Settings.Default.LinesColor2;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuSkillZero_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.Skill_0);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Skill_0 = d.PrimaryColor;
                menuSkillZero.BackColor = Properties.Settings.Default.Skill_0;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuColorU21_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.Color_U21);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Color_U21 = d.PrimaryColor;
                menuColorU21.BackColor = Properties.Settings.Default.Color_U21;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuColorU25_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.Color_U25);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Color_U25 = d.PrimaryColor;
                menuColorU25.BackColor = Properties.Settings.Default.Color_U25;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuColorTraining_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.Color_Allenamento);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Color_Allenamento = d.PrimaryColor;
                menuColorTraining.BackColor = Properties.Settings.Default.Color_Allenamento;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuColorScatto_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.Color_ScattoPiu);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Color_ScattoPiu = d.PrimaryColor;
                menuColorScattoPiu.BackColor = Properties.Settings.Default.Color_ScattoPiu;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }

        private void menuScattoMeno_Click(object sender, EventArgs e)
        {
            My.Controls.ColorPicker d = new My.Controls.ColorPicker(Properties.Settings.Default.Color_ScattoMeno);
            if (d.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Color_ScattoMeno = d.PrimaryColor;
                menuScattoMeno.BackColor = Properties.Settings.Default.Color_ScattoMeno;
                Internal.DBChanged();
            }
            d.Dispose(); d = null;
        }
        #endregion

        private void menuIntervista_Click(object sender, EventArgs e)
        {
            Naviga(@"http://www.gamefox.it/rugbymania/rugbymania-intervista-a-faze-il-creatore-del-gestionale-rmo");
        }

        private void menuRugbymania_Click(object sender, EventArgs e)
        {
            Naviga(@"http://www.rugbymania.net");
        }

        private void menuWeb_Click(object sender, EventArgs e)
        {
            Naviga(@"http://rugbymaniaitalia.forumfree.net/?f=7472872");
        }

        private void Naviga(string url)
        {
            try
            {
                TabPage tpage = null;
                if (WebPage == null)
                {
                    WebPage = new RMO.Tab.TabWeb();
                    tpage = WebPage.GetTab();
                    tpage.ImageIndex = 5;
                    tabControl1.TabPages.Add(tpage);
                }
                else tpage = WebPage.GetTab();
                tabControl1.SelectedTab = tpage;
                toolWWW.Checked = menuWWW.Checked = true;
                WebPage.GoToURL(url);
            }
            catch { My.Shell.Execute(url); }
        }

        private void menuTest_Click(object sender, EventArgs k)
        {
            string file = System.IO.File.ReadAllText(@"C:\cr_matchv3.php.htm");
            int x, s, e; x = s = e = 0;
            x = s = file.IndexOf(@"id_club="+Properties.Settings.Default.RM_Id); // Trovo la tabella della mia squadra
            e = file.IndexOf(@"16-", s); // Trova la fine della tabella della mia squadra
            file = file.Substring(s, e - s);
            file = file.Replace("\r", "");
            file = file.Replace("\n", "");
            while (x > 0)
            {
                // Cerco l'id del giocatore
                s = x = file.IndexOf(@"id_player=");
                if (x > 0)
                {
                    // PREPARO
                    e = file.IndexOf(@"</tr>", s);
                    string p = file.Substring(s, e - s);
                    file = file.Substring(e, file.Length - e);                    
                    // ID
                    e = p.IndexOf("\"");
                    string id = p.Substring(10, e-10);
                    // Rcerca dei valori
                    p = p.Replace(@"<td class='statreport'>&nbsp;</td>", "<td class='statreport'><a();\">0 / 0</a></td>");
                    // Passaggi
                    s = p.IndexOf("();\""); s += 5;
                    e = p.IndexOf("<", s);
                    id += "\r\n" + p.Substring(s, e - s);
                    p = p.Substring(e, p.Length - e);
                    // Ricezioni
                    s = p.IndexOf("();\""); s += 5;
                    e = p.IndexOf("<", s);
                    id += "\r\n" + p.Substring(s, e - s);
                    p = p.Substring(e, p.Length - e);
                    // Attacchi
                    s = p.IndexOf("();\""); s += 5;
                    e = p.IndexOf("<", s);
                    id += "\r\n" + p.Substring(s, e - s);
                    p = p.Substring(e, p.Length - e);
                    // Placcaggi
                    s = p.IndexOf("();\""); s += 5;
                    e = p.IndexOf("<", s);
                    id += "\r\n" + p.Substring(s, e - s);
                    p = p.Substring(e, p.Length - e);
                    // NEXT
                    MessageBox.Show(id);
                }
            }
        }

        private void lStatus_Click(object sender, EventArgs e)
        {
            //ShowRM(@"http://www.rugbymania.net/vote.php");
            //lStatus.IsLink = false;
        }

    }

    internal class Internal
    {
        public static MainForm Main = null;
        public static RMDB DB = null;
        public static int VERSION = 0075;
        public static string WORKPATH = Application.UserAppDataPath;
        public static char BAR = System.IO.Path.DirectorySeparatorChar;
        public static My.Translate Translate;

        public static event EventHandler OnDBChange;
        public static void DBChanged() { if (OnDBChange != null) OnDBChange(null, EventArgs.Empty); }

        public static void Log(string Source, string Message)
        {
            if (!Properties.Settings.Default.EnableLog) return;
            try
            {
                string data = System.DateTime.Now.ToString("yyyy-MM-dd");
                string time = System.DateTime.Now.ToString("HH:mm:ss.fffffff");
                string dir = WORKPATH + BAR + "log" + BAR;
                System.IO.StreamWriter SW;
                if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
                SW = System.IO.File.AppendText(dir + "log." + data + ".txt");
                SW.WriteLine(time + "-> [" + Source + "] " + Message);
                SW.Close();
            }
            catch { }
        }

        public enum VT : int { RM = 0, FAC = 1, FCD = 2 };
        public static VT CurrentVT = VT.RM;
    }
}

/******************************************
 * BUILD 74
 * Aggiunta stagione 21
 * BUILD 73
 * Aggiunta stagione 20
 * BUILD 72
 * Aggiunta stagione 19
 * BUILD 71
 * Correzione di alcune problematiche di aggiornamento automatico
 * BUILD 70
 * Test Release
 * BUILD 62
 * Aggiunto calcolo allenamento secondo il valore della skill
 * Corretto BUG allenamenti sopra la skill 18
 * BUILD 61
 * Aggiunta stagione 18
 * BUILD 60
 * Adattamento causa modifica della pagina "Cosa è successo"
 * BUILD 59
 * Aggiunta stagione 17
 * BUILD 58
 * Aggiunta stagione 16
 * Correzione errore nell'import dei dati da file
 * BUILD 56
 * Corretto BUG nell'uso del browser web
 * Corretto BUG nell'uso della traduzione nelle varie lingue
 * Aggiornata la traduzione di alcune voci (language.xml)
 * BUILD 55
 * Stagione 15
 * Qualcosa che non ricordo...
 * BUILD 54
 * Correzione di un problema nella visualizzazione del numero degli allenamenti
 * BUILD 53
 * Visualizzazione dei giocatori della nazionale (se gestisci una nazionale)
 * Correzione bug nella ricostruzione del database
 * BUILD 52
 * Colora il massimo valore di skill 18
 * Cambiato compilatore
 * Vai al sito di Rugbymania
 * Aggiunti ringraziamenti
 * BUILD 51
 * Lingua francese
 * BUILD 50
 * Utilizzo del tag date_from
 * Risoluzione problemi legati alla ricostruzione del database a seguito dei cambiamenti su xml
 * Aggiornamento del programma di aggiornamento dell'applicazione (Da aggiornare manualmente)
 * BUILD 49
 * Aggiornamento tecnico per cambiamenti XML
 * BUILD 48
 * Eventi in francese
 * Lingua francese
 * BUILD 46/47
 * Visualizzazione punti Touche
 * Aggiunta la stagione 14
 * Lingua inglese
 * Correzzione dowload eventi (chirs ha cambiato il sito)
 * BUILD 45
 * Correzzione Bug raggiungimento peso limite
 * Correzzione Bug calcolo della valutazione del peso
 * Correzzione Bug download degli eventi causa cambiamento del sito
 * Correzzione Bug visualizzazione della variazione dello stipendio
 * BUILD 44
 * Visualizzazione costo per allenamento
 * Correzione del calcolo dello stipendio
 * BUILD 43
 * Supporto per la lingua inglese (in progress)
 * Visualizzazione stipendio base del giocatore
 * Visualizzazione del valore dell'allenamento ponderato
 * Visualizzazione dello scostamento dallo stipendio base
 * BUILD 42
 * Visualizzazione eventi sulla pagina del giocatore
 * Visualizzazione valore ipotetico
 * BUILD 41
 * Stagione 13
 * Correzzione login download eventi
 * BUILD 40
 * Visualizzazione età del giocatore
 * Correzzione della pagina web visualizzata inizialmente
 * Correzzione arrotondamento nella visualizzazione della skill peso / altezza nei giocatori 
 * BUILD 39
 * Dati anagrafici del giocatore
 * Mono 2.4.2 (Ubuntu 9.10) updates, WINE + MONO
 * Visualizzazione del valore numerico sulla visualizzazione skill a cubi
 * Correzioni BUG vari navigazione web (ce ne sono ancora molti)
 * BUILD 38
 * Risoluzione problema segnalato con il webbrowser
 * Correzzione ortografia aggiornamento e Nazionalità
 * Visualizzazione giocatore
 * Aggiunta bandiera del Venezuela
 * BUILD 37
 * Correzzione ordinamento per Nome e Cognome dei giocatori
 * Visualizzazione delle righe
 * Personalizzazione di alcuni colori dell'interfaccia
 * BUILD 36
 * Correzzione nel calcolo del peso limite
 * Memorizzazzione della skill e del tipo di ordinamento dei giocatori
 * Memorizza la tipologia di valutazione utilizzata
 * BUILD 35
 * Correzzione a causa del cambiamento della pagina di login di RM.
 * BUILD 34
 * Risoluzione del BUG di visualizzazione di nome e cognome dei giocatori
 * BUILD 33
 * Inserita la stagione 12 nelle pagine di Classifica e Partite
 * Supporto degli eventi in lingua inglese dal sito di RM (non mischiate italiano esistente e nuovo inglese) o uno o l'altro
 * English version coming very soon!
 * Calcolo del peso limite per ogni giocatore
 * Calcolo delle FCD VT
 * BUILD 32
 * Correzzione di un BUG nel download degli eventi
 * Aggiornamento delle librerie SQLite
 * Incremento estremo delle prestazioni del database
 * BUILD 31
 * Implementazione della visualizzazione delle FAC VT
 * Correzione di un BUG nella visualizzazione della pagina della nazionale di un giocatore
 * Visualizzazione totale delle FAC VT
 * BUILD 30
 * Controllo della crescita degli stipendi
 * Inserimento delle icone nella barra del titolo
 * Inserimento di un tasto per chiudere il tab corrente
 * Corretto BUG nella pagina della Formazione (non veniva usata la scelta della data)
 * Calcolo automatico della formazione in base ad un ordine definito dall'utente
 * ****************************************
 * BUILD 29
 * Ultimata la pagina Navigazione Web
 * Correzzione BUG nella visualizzazione degli eventi
 * Rimozione TAG html dalla visualizzazione degli eventi
 * Correzzione BUG del salvataggio dei dati al primo avvio del programma
 * Correzzione BUG download degli eventi replicati
 * Correzzione BUG nome delle squadre con caratteri UTF8 nella pagina partite
 * ****************************************
 * BUILD 28
 * Bandierine portano alla pagina della nazionale
 * Visualizzazione del nome del giocatore nella visualizzazione eventi
 * Apri la directory dei file di configurazione e del database
 * Comando aggiorna sulle pagine di partite e classifica
 * ****************************************
 * BUILD 27
 * Visualizza dati di autenticazione
 * BUG Download eventi con autenticazione errata
 * BUG Visualizzazione classifica e partite
 * ****************************************
 * BUILD 26
 * Bug rannik [Edit] (13/6/2009, 17:45)
 * Consiglio LolloRM [3] (14/6/2009, 11:49)
 * Consultazione di Partite e Classifica offline
 * Controlla se il tuo mercato è bloccato per 36 ore
 * ****************************************
 * BUILD 0019
 * Inserimento di una simpatica toolbar
 * Visualizzazione di un messaggio di errore in caso di errore sulle dll
 * Correzzione BUG di un possibile indesiderato doppio download degli eventi
 * ****************************************
 * BUILD 0018
 * NON E' PIU' POSSIBILE GESTIRE 2 SQUADRE DIFFERENTI DALLO STESSO PC CON RMO!
 * Vista update (xml, log e database sono memorizzati in un diverso percorso,
 * mostrato nella barra del titolo. I file locali vengono copiati automaticamente)
 * Aggiunta voce al menu La mia squadra
 * Risoluzione BUG sui nomi degli stati di appartenenza dei giocatori
 * Aggiunto messaggio visualizzato prima di ricostruire il database
 * La ricerca automatica di aggiornamenti è ora opzionale
 * ****************************************
 * BUILD 0017
 * Ordinamento degli eventi per data
 * Aggiornamento team dopo il download degli avvenimenti
 * Risoluzione BUG ultimo giorno del mese
 * ****************************************
 * BUILD 0016
 * Update problem
 * Download event problem
 * ****************************************
 * BUILD 0014
 * Gestione Formazione
 * Gestione Eventi
 * Visualizzazione Allenamenti
 * ****************************************
 * BUILD 0011
 * Risoluzione del problema di Rui
 * Aggiornamento del database
 * ****************************************
 * BUILD 0010
 * BUG Gestione della virgola nel peso per alcuni paesi
 * Calcolo nuovi valori nella formazione
 * ****************************************
 * BUILD 0009
 * Segnalazione nuova VT
 * Segnalazione diminuzione VT
 * Suporto per giocatori allievi (quando chris metterà -1)
 * Esperimento pagina formazione (non calcola nulla)
 * BUG: Password con caratteri accentati
******************************************/