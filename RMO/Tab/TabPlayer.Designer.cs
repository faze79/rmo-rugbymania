namespace RMO.Tab
{
    partial class TabPlayer
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelScatto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboScatto = new System.Windows.Forms.ComboBox();
            this.lStipendio2 = new System.Windows.Forms.Label();
            this.lValore = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listEvents = new System.Windows.Forms.ListView();
            this.cData = new System.Windows.Forms.ColumnHeader();
            this.cTipo = new System.Windows.Forms.ColumnHeader();
            this.cPlayer = new System.Windows.Forms.ColumnHeader();
            this.cDettagli = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lStipendio = new System.Windows.Forms.Label();
            this.lEta = new System.Windows.Forms.Label();
            this.sPesoSkill = new RMO.Control.Skillnum();
            this.sAltezzaSkill = new RMO.Control.Skillnum();
            this.sPeso = new System.Windows.Forms.Label();
            this.sAltezza = new System.Windows.Forms.Label();
            this.sNazione = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sEsperienza = new RMO.Control.Skillnum();
            this.sPassaggi = new RMO.Control.Skillnum();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sCalci = new RMO.Control.Skillnum();
            this.sRicezione = new RMO.Control.Skillnum();
            this.sVelocita = new RMO.Control.Skillnum();
            this.sForza = new RMO.Control.Skillnum();
            this.label3 = new System.Windows.Forms.Label();
            this.sPlaccaggi = new RMO.Control.Skillnum();
            this.sResistenza = new RMO.Control.Skillnum();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.lTouche = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageMain);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 480);
            this.tabControl1.TabIndex = 0;
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.groupBox4);
            this.pageMain.Controls.Add(this.groupBox3);
            this.pageMain.Controls.Add(this.groupBox2);
            this.pageMain.Controls.Add(this.groupBox1);
            this.pageMain.Controls.Add(this.labelNome);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(632, 454);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "giocatore";
            this.pageMain.Text = "Il Giocatore";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lTouche);
            this.groupBox4.Controls.Add(this.labelScatto);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.comboScatto);
            this.groupBox4.Controls.Add(this.lStipendio2);
            this.groupBox4.Controls.Add(this.lValore);
            this.groupBox4.Location = new System.Drawing.Point(389, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 201);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Statistiche";
            // 
            // labelScatto
            // 
            this.labelScatto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScatto.Location = new System.Drawing.Point(110, 80);
            this.labelScatto.Multiline = true;
            this.labelScatto.Name = "labelScatto";
            this.labelScatto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.labelScatto.Size = new System.Drawing.Size(121, 112);
            this.labelScatto.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 3;
            this.label12.Tag = "NOTRANSLATE";
            this.label12.Text = "Costo per scatto:";
            // 
            // comboScatto
            // 
            this.comboScatto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScatto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScatto.FormattingEnabled = true;
            this.comboScatto.Items.AddRange(new object[] {
            "Forza",
            "Placcaggi",
            "Velocità",
            "Passaggi",
            "Ricezione",
            "Calci"});
            this.comboScatto.Location = new System.Drawing.Point(110, 53);
            this.comboScatto.Name = "comboScatto";
            this.comboScatto.Size = new System.Drawing.Size(121, 21);
            this.comboScatto.TabIndex = 2;
            this.comboScatto.SelectedIndexChanged += new System.EventHandler(this.comboScatto_SelectedIndexChanged);
            // 
            // lStipendio2
            // 
            this.lStipendio2.AutoSize = true;
            this.lStipendio2.Location = new System.Drawing.Point(6, 37);
            this.lStipendio2.Name = "lStipendio2";
            this.lStipendio2.Size = new System.Drawing.Size(96, 13);
            this.lStipendio2.TabIndex = 1;
            this.lStipendio2.Tag = "NOTRANSLATE";
            this.lStipendio2.Text = "Stipendio stimanto:";
            // 
            // lValore
            // 
            this.lValore.AutoSize = true;
            this.lValore.Location = new System.Drawing.Point(6, 18);
            this.lValore.Name = "lValore";
            this.lValore.Size = new System.Drawing.Size(82, 13);
            this.lValore.TabIndex = 0;
            this.lValore.Tag = "NOTRANSLATE";
            this.lValore.Text = "Valore stimanto:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listEvents);
            this.groupBox3.Location = new System.Drawing.Point(10, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 207);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eventi";
            // 
            // listEvents
            // 
            this.listEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cData,
            this.cTipo,
            this.cPlayer,
            this.cDettagli});
            this.listEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEvents.FullRowSelect = true;
            this.listEvents.Location = new System.Drawing.Point(3, 16);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(610, 188);
            this.listEvents.TabIndex = 5;
            this.listEvents.UseCompatibleStateImageBehavior = false;
            this.listEvents.View = System.Windows.Forms.View.Details;
            this.listEvents.SizeChanged += new System.EventHandler(this.listEvents_SizeChanged);
            // 
            // cData
            // 
            this.cData.Text = "Data";
            this.cData.Width = 120;
            // 
            // cTipo
            // 
            this.cTipo.Text = "Tipo";
            this.cTipo.Width = 80;
            // 
            // cPlayer
            // 
            this.cPlayer.Text = "Giocatore";
            this.cPlayer.Width = 120;
            // 
            // cDettagli
            // 
            this.cDettagli.Text = "Dettagli";
            this.cDettagli.Width = 240;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lStipendio);
            this.groupBox2.Controls.Add(this.lEta);
            this.groupBox2.Controls.Add(this.sPesoSkill);
            this.groupBox2.Controls.Add(this.sAltezzaSkill);
            this.groupBox2.Controls.Add(this.sPeso);
            this.groupBox2.Controls.Add(this.sAltezza);
            this.groupBox2.Controls.Add(this.sNazione);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(10, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 83);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anagrafica del giocatore";
            // 
            // lStipendio
            // 
            this.lStipendio.Location = new System.Drawing.Point(250, 16);
            this.lStipendio.Name = "lStipendio";
            this.lStipendio.Size = new System.Drawing.Size(106, 16);
            this.lStipendio.TabIndex = 14;
            this.lStipendio.Text = "Stipendio: {0} €";
            this.lStipendio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lEta
            // 
            this.lEta.Location = new System.Drawing.Point(182, 16);
            this.lEta.Name = "lEta";
            this.lEta.Size = new System.Drawing.Size(60, 16);
            this.lEta.TabIndex = 13;
            this.lEta.Text = "Età: {0}";
            this.lEta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sPesoSkill
            // 
            this.sPesoSkill.Location = new System.Drawing.Point(253, 59);
            this.sPesoSkill.MaximumSize = new System.Drawing.Size(108, 16);
            this.sPesoSkill.MinimumSize = new System.Drawing.Size(108, 16);
            this.sPesoSkill.Name = "sPesoSkill";
            this.sPesoSkill.Size = new System.Drawing.Size(108, 16);
            this.sPesoSkill.TabIndex = 9;
            this.sPesoSkill.Tag = "NOTRANSLATE";
            this.sPesoSkill.Value = 1;
            // 
            // sAltezzaSkill
            // 
            this.sAltezzaSkill.Location = new System.Drawing.Point(253, 37);
            this.sAltezzaSkill.MaximumSize = new System.Drawing.Size(108, 16);
            this.sAltezzaSkill.MinimumSize = new System.Drawing.Size(108, 16);
            this.sAltezzaSkill.Name = "sAltezzaSkill";
            this.sAltezzaSkill.Size = new System.Drawing.Size(108, 16);
            this.sAltezzaSkill.TabIndex = 8;
            this.sAltezzaSkill.Tag = "NOTRANSLATE";
            this.sAltezzaSkill.Value = 1;
            // 
            // sPeso
            // 
            this.sPeso.AutoSize = true;
            this.sPeso.Location = new System.Drawing.Point(74, 61);
            this.sPeso.Name = "sPeso";
            this.sPeso.Size = new System.Drawing.Size(0, 13);
            this.sPeso.TabIndex = 6;
            this.sPeso.Tag = "";
            // 
            // sAltezza
            // 
            this.sAltezza.AutoSize = true;
            this.sAltezza.Location = new System.Drawing.Point(74, 40);
            this.sAltezza.Name = "sAltezza";
            this.sAltezza.Size = new System.Drawing.Size(0, 13);
            this.sAltezza.TabIndex = 5;
            this.sAltezza.Tag = "";
            // 
            // sNazione
            // 
            this.sNazione.AutoSize = true;
            this.sNazione.Location = new System.Drawing.Point(74, 18);
            this.sNazione.Name = "sNazione";
            this.sNazione.Size = new System.Drawing.Size(0, 13);
            this.sNazione.TabIndex = 4;
            this.sNazione.Tag = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Peso:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Altezza:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Nazionalità:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.sEsperienza);
            this.groupBox1.Controls.Add(this.sPassaggi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sCalci);
            this.groupBox1.Controls.Add(this.sRicezione);
            this.groupBox1.Controls.Add(this.sVelocita);
            this.groupBox1.Controls.Add(this.sForza);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.sPlaccaggi);
            this.groupBox1.Controls.Add(this.sResistenza);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Abilità del giocatore";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Esperienza:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Passaggi:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sEsperienza
            // 
            this.sEsperienza.Location = new System.Drawing.Point(74, 87);
            this.sEsperienza.MaximumSize = new System.Drawing.Size(108, 16);
            this.sEsperienza.MinimumSize = new System.Drawing.Size(108, 16);
            this.sEsperienza.Name = "sEsperienza";
            this.sEsperienza.Size = new System.Drawing.Size(108, 16);
            this.sEsperienza.TabIndex = 13;
            this.sEsperienza.Tag = "NOTRANSLATE";
            this.sEsperienza.Value = 6;
            // 
            // sPassaggi
            // 
            this.sPassaggi.Location = new System.Drawing.Point(74, 65);
            this.sPassaggi.MaximumSize = new System.Drawing.Size(108, 16);
            this.sPassaggi.MinimumSize = new System.Drawing.Size(108, 16);
            this.sPassaggi.Name = "sPassaggi";
            this.sPassaggi.Size = new System.Drawing.Size(108, 16);
            this.sPassaggi.TabIndex = 12;
            this.sPassaggi.Tag = "NOTRANSLATE";
            this.sPassaggi.Value = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(184, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Calci:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(184, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ricezione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(184, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Velocità:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sCalci
            // 
            this.sCalci.Location = new System.Drawing.Point(255, 87);
            this.sCalci.MaximumSize = new System.Drawing.Size(108, 16);
            this.sCalci.MinimumSize = new System.Drawing.Size(108, 16);
            this.sCalci.Name = "sCalci";
            this.sCalci.Size = new System.Drawing.Size(108, 16);
            this.sCalci.TabIndex = 8;
            this.sCalci.Tag = "NOTRANSLATE";
            this.sCalci.Value = 7;
            // 
            // sRicezione
            // 
            this.sRicezione.Location = new System.Drawing.Point(255, 65);
            this.sRicezione.MaximumSize = new System.Drawing.Size(108, 16);
            this.sRicezione.MinimumSize = new System.Drawing.Size(108, 16);
            this.sRicezione.Name = "sRicezione";
            this.sRicezione.Size = new System.Drawing.Size(108, 16);
            this.sRicezione.TabIndex = 7;
            this.sRicezione.Tag = "NOTRANSLATE";
            this.sRicezione.Value = 5;
            // 
            // sVelocita
            // 
            this.sVelocita.Location = new System.Drawing.Point(255, 43);
            this.sVelocita.MaximumSize = new System.Drawing.Size(108, 16);
            this.sVelocita.MinimumSize = new System.Drawing.Size(108, 16);
            this.sVelocita.Name = "sVelocita";
            this.sVelocita.Size = new System.Drawing.Size(108, 16);
            this.sVelocita.TabIndex = 6;
            this.sVelocita.Tag = "NOTRANSLATE";
            this.sVelocita.Value = 3;
            // 
            // sForza
            // 
            this.sForza.Location = new System.Drawing.Point(255, 21);
            this.sForza.MaximumSize = new System.Drawing.Size(108, 16);
            this.sForza.MinimumSize = new System.Drawing.Size(108, 16);
            this.sForza.Name = "sForza";
            this.sForza.Size = new System.Drawing.Size(108, 16);
            this.sForza.TabIndex = 5;
            this.sForza.Tag = "NOTRANSLATE";
            this.sForza.Value = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Forza:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sPlaccaggi
            // 
            this.sPlaccaggi.Location = new System.Drawing.Point(74, 43);
            this.sPlaccaggi.MaximumSize = new System.Drawing.Size(108, 16);
            this.sPlaccaggi.MinimumSize = new System.Drawing.Size(108, 16);
            this.sPlaccaggi.Name = "sPlaccaggi";
            this.sPlaccaggi.Size = new System.Drawing.Size(108, 16);
            this.sPlaccaggi.TabIndex = 3;
            this.sPlaccaggi.Tag = "NOTRANSLATE";
            this.sPlaccaggi.Value = 2;
            // 
            // sResistenza
            // 
            this.sResistenza.Location = new System.Drawing.Point(74, 21);
            this.sResistenza.MaximumSize = new System.Drawing.Size(108, 16);
            this.sResistenza.MinimumSize = new System.Drawing.Size(108, 16);
            this.sResistenza.Name = "sResistenza";
            this.sResistenza.Size = new System.Drawing.Size(108, 16);
            this.sResistenza.TabIndex = 2;
            this.sResistenza.Tag = "NOTRANSLATE";
            this.sResistenza.Value = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Placcaggi:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resistenza:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(6, 6);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(167, 24);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome e Cognome";
            // 
            // tt
            // 
            this.tt.AutoPopDelay = 5000;
            this.tt.InitialDelay = 500;
            this.tt.IsBalloon = true;
            this.tt.ReshowDelay = 100;
            this.tt.ShowAlways = true;
            this.tt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lTouche
            // 
            this.lTouche.AutoSize = true;
            this.lTouche.Location = new System.Drawing.Point(6, 80);
            this.lTouche.Name = "lTouche";
            this.lTouche.Size = new System.Drawing.Size(95, 13);
            this.lTouche.TabIndex = 5;
            this.lTouche.Text = "Punti Touche: {0}";
            // 
            // TabPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabPlayer";
            this.Size = new System.Drawing.Size(640, 480);
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private RMO.Control.Skillnum sCalci;
        private RMO.Control.Skillnum sRicezione;
        private RMO.Control.Skillnum sVelocita;
        private RMO.Control.Skillnum sForza;
        private System.Windows.Forms.Label label3;
        private RMO.Control.Skillnum sPlaccaggi;
        private RMO.Control.Skillnum sResistenza;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private RMO.Control.Skillnum sEsperienza;
        private RMO.Control.Skillnum sPassaggi;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label sPeso;
        private System.Windows.Forms.Label sAltezza;
        private System.Windows.Forms.Label sNazione;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private RMO.Control.Skillnum sAltezzaSkill;
        private RMO.Control.Skillnum sPesoSkill;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listEvents;
        private System.Windows.Forms.ColumnHeader cData;
        private System.Windows.Forms.ColumnHeader cTipo;
        private System.Windows.Forms.ColumnHeader cPlayer;
        private System.Windows.Forms.ColumnHeader cDettagli;
        private System.Windows.Forms.Label lValore;
        private System.Windows.Forms.Label lStipendio;
        private System.Windows.Forms.Label lEta;
        private System.Windows.Forms.Label lStipendio2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboScatto;
        private System.Windows.Forms.TextBox labelScatto;
        private System.Windows.Forms.Label lTouche;
    }
}
