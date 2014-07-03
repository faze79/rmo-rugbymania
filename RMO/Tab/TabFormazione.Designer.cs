namespace RMO.Tab
{
    partial class TabFormazione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabFormazione));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textOrder = new System.Windows.Forms.TextBox();
            this.buttonAuto = new System.Windows.Forms.Button();
            this.panelFormazione = new System.Windows.Forms.Panel();
            this.tEXP = new System.Windows.Forms.Label();
            this.lEXP = new System.Windows.Forms.Label();
            this.tRQ = new System.Windows.Forms.Label();
            this.tPQ = new System.Windows.Forms.Label();
            this.tPLA = new System.Windows.Forms.Label();
            this.tFA = new System.Windows.Forms.Label();
            this.tPA = new System.Windows.Forms.Label();
            this.tVTQ = new System.Windows.Forms.Label();
            this.tVTA = new System.Windows.Forms.Label();
            this.tVTT = new System.Windows.Forms.Label();
            this.lRQ = new System.Windows.Forms.Label();
            this.lPQ = new System.Windows.Forms.Label();
            this.lPLA = new System.Windows.Forms.Label();
            this.lVTQ = new System.Windows.Forms.Label();
            this.lVTA = new System.Windows.Forms.Label();
            this.lFA = new System.Windows.Forms.Label();
            this.lPA = new System.Windows.Forms.Label();
            this.l15 = new My.Controls.MyLabel();
            this.lVTT = new System.Windows.Forms.Label();
            this.l13 = new My.Controls.MyLabel();
            this.l12 = new My.Controls.MyLabel();
            this.l14 = new My.Controls.MyLabel();
            this.l11 = new My.Controls.MyLabel();
            this.l10 = new My.Controls.MyLabel();
            this.l9 = new My.Controls.MyLabel();
            this.l8 = new My.Controls.MyLabel();
            this.l7 = new My.Controls.MyLabel();
            this.l6 = new My.Controls.MyLabel();
            this.l5 = new My.Controls.MyLabel();
            this.l4 = new My.Controls.MyLabel();
            this.l2 = new My.Controls.MyLabel();
            this.l3 = new My.Controls.MyLabel();
            this.l1 = new My.Controls.MyLabel();
            this.c15 = new System.Windows.Forms.ComboBox();
            this.c13 = new System.Windows.Forms.ComboBox();
            this.c12 = new System.Windows.Forms.ComboBox();
            this.c14 = new System.Windows.Forms.ComboBox();
            this.c11 = new System.Windows.Forms.ComboBox();
            this.c10 = new System.Windows.Forms.ComboBox();
            this.c9 = new System.Windows.Forms.ComboBox();
            this.c8 = new System.Windows.Forms.ComboBox();
            this.c7 = new System.Windows.Forms.ComboBox();
            this.c6 = new System.Windows.Forms.ComboBox();
            this.c5 = new System.Windows.Forms.ComboBox();
            this.c4 = new System.Windows.Forms.ComboBox();
            this.c3 = new System.Windows.Forms.ComboBox();
            this.c2 = new System.Windows.Forms.ComboBox();
            this.c1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDa = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.panelFormazione.SuspendLayout();
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
            this.pageMain.Controls.Add(this.label2);
            this.pageMain.Controls.Add(this.textOrder);
            this.pageMain.Controls.Add(this.buttonAuto);
            this.pageMain.Controls.Add(this.panelFormazione);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Controls.Add(this.comboDa);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(632, 454);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "NOSTRASLATE formazione";
            this.pageMain.Text = "Formazione";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ordine:";
            // 
            // textOrder
            // 
            this.textOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textOrder.Location = new System.Drawing.Point(305, 7);
            this.textOrder.Name = "textOrder";
            this.textOrder.Size = new System.Drawing.Size(197, 20);
            this.textOrder.TabIndex = 7;
            this.textOrder.Tag = "notranslate";
            this.textOrder.Text = "1,2,3,4,5,8,6,7,10,9,12,15,11,13,14";
            this.textOrder.TextChanged += new System.EventHandler(this.textOrder_TextChanged);
            // 
            // buttonAuto
            // 
            this.buttonAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAuto.Location = new System.Drawing.Point(508, 5);
            this.buttonAuto.Name = "buttonAuto";
            this.buttonAuto.Size = new System.Drawing.Size(118, 23);
            this.buttonAuto.TabIndex = 6;
            this.buttonAuto.Text = "Calcola la formazione";
            this.buttonAuto.UseVisualStyleBackColor = true;
            this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click);
            // 
            // panelFormazione
            // 
            this.panelFormazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFormazione.BackColor = System.Drawing.Color.White;
            this.panelFormazione.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelFormazione.BackgroundImage")));
            this.panelFormazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormazione.Controls.Add(this.tEXP);
            this.panelFormazione.Controls.Add(this.lEXP);
            this.panelFormazione.Controls.Add(this.tRQ);
            this.panelFormazione.Controls.Add(this.tPQ);
            this.panelFormazione.Controls.Add(this.tPLA);
            this.panelFormazione.Controls.Add(this.tFA);
            this.panelFormazione.Controls.Add(this.tPA);
            this.panelFormazione.Controls.Add(this.tVTQ);
            this.panelFormazione.Controls.Add(this.tVTA);
            this.panelFormazione.Controls.Add(this.tVTT);
            this.panelFormazione.Controls.Add(this.lRQ);
            this.panelFormazione.Controls.Add(this.lPQ);
            this.panelFormazione.Controls.Add(this.lPLA);
            this.panelFormazione.Controls.Add(this.lVTQ);
            this.panelFormazione.Controls.Add(this.lVTA);
            this.panelFormazione.Controls.Add(this.lFA);
            this.panelFormazione.Controls.Add(this.lPA);
            this.panelFormazione.Controls.Add(this.l15);
            this.panelFormazione.Controls.Add(this.lVTT);
            this.panelFormazione.Controls.Add(this.l13);
            this.panelFormazione.Controls.Add(this.l12);
            this.panelFormazione.Controls.Add(this.l14);
            this.panelFormazione.Controls.Add(this.l11);
            this.panelFormazione.Controls.Add(this.l10);
            this.panelFormazione.Controls.Add(this.l9);
            this.panelFormazione.Controls.Add(this.l8);
            this.panelFormazione.Controls.Add(this.l7);
            this.panelFormazione.Controls.Add(this.l6);
            this.panelFormazione.Controls.Add(this.l5);
            this.panelFormazione.Controls.Add(this.l4);
            this.panelFormazione.Controls.Add(this.l2);
            this.panelFormazione.Controls.Add(this.l3);
            this.panelFormazione.Controls.Add(this.l1);
            this.panelFormazione.Controls.Add(this.c15);
            this.panelFormazione.Controls.Add(this.c13);
            this.panelFormazione.Controls.Add(this.c12);
            this.panelFormazione.Controls.Add(this.c14);
            this.panelFormazione.Controls.Add(this.c11);
            this.panelFormazione.Controls.Add(this.c10);
            this.panelFormazione.Controls.Add(this.c9);
            this.panelFormazione.Controls.Add(this.c8);
            this.panelFormazione.Controls.Add(this.c7);
            this.panelFormazione.Controls.Add(this.c6);
            this.panelFormazione.Controls.Add(this.c5);
            this.panelFormazione.Controls.Add(this.c4);
            this.panelFormazione.Controls.Add(this.c3);
            this.panelFormazione.Controls.Add(this.c2);
            this.panelFormazione.Controls.Add(this.c1);
            this.panelFormazione.Location = new System.Drawing.Point(7, 33);
            this.panelFormazione.Name = "panelFormazione";
            this.panelFormazione.Size = new System.Drawing.Size(619, 415);
            this.panelFormazione.TabIndex = 5;
            this.panelFormazione.SizeChanged += new System.EventHandler(this.panelFormazione_SizeChanged);
            // 
            // tEXP
            // 
            this.tEXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tEXP.Location = new System.Drawing.Point(554, 393);
            this.tEXP.Name = "tEXP";
            this.tEXP.Size = new System.Drawing.Size(50, 16);
            this.tEXP.TabIndex = 45;
            this.tEXP.Tag = "notranslate";
            this.tEXP.Text = "000";
            // 
            // lEXP
            // 
            this.lEXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lEXP.Location = new System.Drawing.Point(398, 393);
            this.lEXP.Name = "lEXP";
            this.lEXP.Size = new System.Drawing.Size(157, 16);
            this.lEXP.TabIndex = 44;
            this.lEXP.Text = "Esperienza media:";
            // 
            // tRQ
            // 
            this.tRQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tRQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tRQ.Location = new System.Drawing.Point(554, 378);
            this.tRQ.Name = "tRQ";
            this.tRQ.Size = new System.Drawing.Size(50, 16);
            this.tRQ.TabIndex = 43;
            this.tRQ.Tag = "notranslate";
            this.tRQ.Text = "000";
            // 
            // tPQ
            // 
            this.tPQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tPQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tPQ.Location = new System.Drawing.Point(554, 363);
            this.tPQ.Name = "tPQ";
            this.tPQ.Size = new System.Drawing.Size(50, 16);
            this.tPQ.TabIndex = 42;
            this.tPQ.Tag = "notranslate";
            this.tPQ.Text = "000";
            // 
            // tPLA
            // 
            this.tPLA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tPLA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tPLA.Location = new System.Drawing.Point(342, 393);
            this.tPLA.Name = "tPLA";
            this.tPLA.Size = new System.Drawing.Size(50, 16);
            this.tPLA.TabIndex = 41;
            this.tPLA.Tag = "notranslate";
            this.tPLA.Text = "000";
            // 
            // tFA
            // 
            this.tFA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tFA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tFA.Location = new System.Drawing.Point(342, 378);
            this.tFA.Name = "tFA";
            this.tFA.Size = new System.Drawing.Size(50, 16);
            this.tFA.TabIndex = 40;
            this.tFA.Tag = "notranslate";
            this.tFA.Text = "000";
            // 
            // tPA
            // 
            this.tPA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tPA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tPA.Location = new System.Drawing.Point(342, 363);
            this.tPA.Name = "tPA";
            this.tPA.Size = new System.Drawing.Size(50, 16);
            this.tPA.TabIndex = 39;
            this.tPA.Tag = "notranslate";
            this.tPA.Text = "000 Kg";
            // 
            // tVTQ
            // 
            this.tVTQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tVTQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tVTQ.Location = new System.Drawing.Point(161, 393);
            this.tVTQ.Name = "tVTQ";
            this.tVTQ.Size = new System.Drawing.Size(50, 16);
            this.tVTQ.TabIndex = 38;
            this.tVTQ.Tag = "notranslate";
            this.tVTQ.Text = "000";
            // 
            // tVTA
            // 
            this.tVTA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tVTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tVTA.Location = new System.Drawing.Point(161, 378);
            this.tVTA.Name = "tVTA";
            this.tVTA.Size = new System.Drawing.Size(50, 16);
            this.tVTA.TabIndex = 37;
            this.tVTA.Tag = "notranslate";
            this.tVTA.Text = "000";
            // 
            // tVTT
            // 
            this.tVTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tVTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tVTT.Location = new System.Drawing.Point(161, 363);
            this.tVTT.Name = "tVTT";
            this.tVTT.Size = new System.Drawing.Size(50, 16);
            this.tVTT.TabIndex = 36;
            this.tVTT.Tag = "notranslate";
            this.tVTT.Text = "000";
            // 
            // lRQ
            // 
            this.lRQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lRQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lRQ.Location = new System.Drawing.Point(398, 378);
            this.lRQ.Name = "lRQ";
            this.lRQ.Size = new System.Drawing.Size(157, 16);
            this.lRQ.TabIndex = 35;
            this.lRQ.Text = "Ricezione dei 3/4:";
            // 
            // lPQ
            // 
            this.lPQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lPQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lPQ.Location = new System.Drawing.Point(398, 363);
            this.lPQ.Name = "lPQ";
            this.lPQ.Size = new System.Drawing.Size(157, 16);
            this.lPQ.TabIndex = 34;
            this.lPQ.Text = "Passaggi dei 3/4:";
            // 
            // lPLA
            // 
            this.lPLA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lPLA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lPLA.Location = new System.Drawing.Point(217, 393);
            this.lPLA.Name = "lPLA";
            this.lPLA.Size = new System.Drawing.Size(126, 16);
            this.lPLA.TabIndex = 33;
            this.lPLA.Text = "Placcaggi degli avanti:";
            // 
            // lVTQ
            // 
            this.lVTQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lVTQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVTQ.Location = new System.Drawing.Point(3, 393);
            this.lVTQ.Name = "lVTQ";
            this.lVTQ.Size = new System.Drawing.Size(159, 16);
            this.lVTQ.TabIndex = 32;
            this.lVTQ.Text = "Valutazione totale dei 3/4:";
            // 
            // lVTA
            // 
            this.lVTA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lVTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVTA.Location = new System.Drawing.Point(3, 378);
            this.lVTA.Name = "lVTA";
            this.lVTA.Size = new System.Drawing.Size(159, 16);
            this.lVTA.TabIndex = 31;
            this.lVTA.Text = "Valutazione totale degli avanti:";
            // 
            // lFA
            // 
            this.lFA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lFA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lFA.Location = new System.Drawing.Point(217, 378);
            this.lFA.Name = "lFA";
            this.lFA.Size = new System.Drawing.Size(126, 16);
            this.lFA.TabIndex = 30;
            this.lFA.Text = "Forza degli avanti:";
            // 
            // lPA
            // 
            this.lPA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lPA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lPA.Location = new System.Drawing.Point(217, 363);
            this.lPA.Name = "lPA";
            this.lPA.Size = new System.Drawing.Size(126, 16);
            this.lPA.TabIndex = 8;
            this.lPA.Text = "Peso degli avanti:";
            // 
            // l15
            // 
            this.l15.BackColor = System.Drawing.Color.Silver;
            this.l15.ColorEnd = System.Drawing.Color.Silver;
            this.l15.ColorStart = System.Drawing.Color.Gray;
            this.l15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l15.ForeColor = System.Drawing.Color.White;
            this.l15.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l15.Location = new System.Drawing.Point(231, 295);
            this.l15.Name = "l15";
            this.l15.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l15.Size = new System.Drawing.Size(150, 14);
            this.l15.TabIndex = 29;
            this.l15.Text = "15 - Estremo";
            this.l15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l15.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l15.Themed = true;
            this.l15.Click += new System.EventHandler(this.l15_Click);
            // 
            // lVTT
            // 
            this.lVTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lVTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVTT.Location = new System.Drawing.Point(3, 363);
            this.lVTT.Name = "lVTT";
            this.lVTT.Size = new System.Drawing.Size(159, 16);
            this.lVTT.TabIndex = 7;
            this.lVTT.Text = "Valutazione totale:";
            // 
            // l13
            // 
            this.l13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l13.BackColor = System.Drawing.Color.Silver;
            this.l13.ColorEnd = System.Drawing.Color.Silver;
            this.l13.ColorStart = System.Drawing.Color.Gray;
            this.l13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l13.ForeColor = System.Drawing.Color.White;
            this.l13.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l13.Location = new System.Drawing.Point(350, 257);
            this.l13.Name = "l13";
            this.l13.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l13.Size = new System.Drawing.Size(150, 14);
            this.l13.TabIndex = 28;
            this.l13.Text = "13 - Centro";
            this.l13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l13.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l13.Themed = true;
            this.l13.Click += new System.EventHandler(this.l13_Click);
            // 
            // l12
            // 
            this.l12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l12.BackColor = System.Drawing.Color.Silver;
            this.l12.ColorEnd = System.Drawing.Color.Silver;
            this.l12.ColorStart = System.Drawing.Color.Gray;
            this.l12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l12.ForeColor = System.Drawing.Color.White;
            this.l12.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l12.Location = new System.Drawing.Point(118, 257);
            this.l12.Name = "l12";
            this.l12.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l12.Size = new System.Drawing.Size(150, 14);
            this.l12.TabIndex = 27;
            this.l12.Text = "12 - Centro";
            this.l12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l12.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l12.Themed = true;
            this.l12.Click += new System.EventHandler(this.l12_Click);
            // 
            // l14
            // 
            this.l14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l14.BackColor = System.Drawing.Color.Silver;
            this.l14.ColorEnd = System.Drawing.Color.Silver;
            this.l14.ColorStart = System.Drawing.Color.Gray;
            this.l14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l14.ForeColor = System.Drawing.Color.White;
            this.l14.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l14.Location = new System.Drawing.Point(464, 219);
            this.l14.Name = "l14";
            this.l14.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l14.Size = new System.Drawing.Size(150, 14);
            this.l14.TabIndex = 26;
            this.l14.Text = "14 - Ala";
            this.l14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l14.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l14.Themed = true;
            this.l14.Click += new System.EventHandler(this.l14_Click);
            // 
            // l11
            // 
            this.l11.BackColor = System.Drawing.Color.Silver;
            this.l11.ColorEnd = System.Drawing.Color.Silver;
            this.l11.ColorStart = System.Drawing.Color.Gray;
            this.l11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l11.ForeColor = System.Drawing.Color.White;
            this.l11.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l11.Location = new System.Drawing.Point(3, 219);
            this.l11.Name = "l11";
            this.l11.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l11.Size = new System.Drawing.Size(150, 14);
            this.l11.TabIndex = 25;
            this.l11.Text = "11 - Ala";
            this.l11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l11.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l11.Themed = true;
            this.l11.Click += new System.EventHandler(this.l11_Click);
            // 
            // l10
            // 
            this.l10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l10.BackColor = System.Drawing.Color.Silver;
            this.l10.ColorEnd = System.Drawing.Color.Silver;
            this.l10.ColorStart = System.Drawing.Color.Gray;
            this.l10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l10.ForeColor = System.Drawing.Color.White;
            this.l10.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l10.Location = new System.Drawing.Point(350, 181);
            this.l10.Name = "l10";
            this.l10.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l10.Size = new System.Drawing.Size(150, 14);
            this.l10.TabIndex = 24;
            this.l10.Text = "10 - Mediano di apertura";
            this.l10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l10.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l10.Themed = true;
            this.l10.Click += new System.EventHandler(this.l10_Click);
            // 
            // l9
            // 
            this.l9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l9.BackColor = System.Drawing.Color.Silver;
            this.l9.ColorEnd = System.Drawing.Color.Silver;
            this.l9.ColorStart = System.Drawing.Color.Gray;
            this.l9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l9.ForeColor = System.Drawing.Color.White;
            this.l9.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l9.Location = new System.Drawing.Point(118, 181);
            this.l9.Name = "l9";
            this.l9.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l9.Size = new System.Drawing.Size(150, 14);
            this.l9.TabIndex = 23;
            this.l9.Text = "9 - Mediano di mischia";
            this.l9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l9.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l9.Themed = true;
            this.l9.Click += new System.EventHandler(this.l9_Click);
            // 
            // l8
            // 
            this.l8.BackColor = System.Drawing.Color.Silver;
            this.l8.ColorEnd = System.Drawing.Color.Silver;
            this.l8.ColorStart = System.Drawing.Color.Gray;
            this.l8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l8.ForeColor = System.Drawing.Color.White;
            this.l8.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l8.Location = new System.Drawing.Point(231, 108);
            this.l8.Name = "l8";
            this.l8.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l8.Size = new System.Drawing.Size(150, 14);
            this.l8.TabIndex = 22;
            this.l8.Text = "8 - Terza linea centro";
            this.l8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l8.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l8.Themed = true;
            this.l8.Click += new System.EventHandler(this.l8_Click);
            // 
            // l7
            // 
            this.l7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l7.BackColor = System.Drawing.Color.Silver;
            this.l7.ColorEnd = System.Drawing.Color.Silver;
            this.l7.ColorStart = System.Drawing.Color.Gray;
            this.l7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l7.ForeColor = System.Drawing.Color.White;
            this.l7.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l7.Location = new System.Drawing.Point(464, 86);
            this.l7.Name = "l7";
            this.l7.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l7.Size = new System.Drawing.Size(150, 14);
            this.l7.TabIndex = 21;
            this.l7.Text = "7 - Terza linea ala";
            this.l7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l7.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l7.Themed = true;
            this.l7.Click += new System.EventHandler(this.l7_Click);
            // 
            // l6
            // 
            this.l6.BackColor = System.Drawing.Color.Silver;
            this.l6.ColorEnd = System.Drawing.Color.Silver;
            this.l6.ColorStart = System.Drawing.Color.Gray;
            this.l6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l6.ForeColor = System.Drawing.Color.White;
            this.l6.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l6.Location = new System.Drawing.Point(3, 86);
            this.l6.Name = "l6";
            this.l6.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l6.Size = new System.Drawing.Size(150, 14);
            this.l6.TabIndex = 20;
            this.l6.Text = "6 - Terza linea ala";
            this.l6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l6.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l6.Themed = true;
            this.l6.Click += new System.EventHandler(this.l6_Click);
            // 
            // l5
            // 
            this.l5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l5.BackColor = System.Drawing.Color.Silver;
            this.l5.ColorEnd = System.Drawing.Color.Silver;
            this.l5.ColorStart = System.Drawing.Color.Gray;
            this.l5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l5.ForeColor = System.Drawing.Color.White;
            this.l5.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l5.Location = new System.Drawing.Point(350, 47);
            this.l5.Name = "l5";
            this.l5.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l5.Size = new System.Drawing.Size(150, 14);
            this.l5.TabIndex = 19;
            this.l5.Text = "5 - Seconda linea";
            this.l5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l5.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l5.Themed = true;
            this.l5.Click += new System.EventHandler(this.l5_Click);
            // 
            // l4
            // 
            this.l4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.l4.BackColor = System.Drawing.Color.Silver;
            this.l4.ColorEnd = System.Drawing.Color.Silver;
            this.l4.ColorStart = System.Drawing.Color.Gray;
            this.l4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l4.ForeColor = System.Drawing.Color.White;
            this.l4.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l4.Location = new System.Drawing.Point(118, 47);
            this.l4.Name = "l4";
            this.l4.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l4.Size = new System.Drawing.Size(150, 14);
            this.l4.TabIndex = 18;
            this.l4.Text = "4 - Seconda linea";
            this.l4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l4.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l4.Themed = true;
            this.l4.Click += new System.EventHandler(this.l4_Click);
            // 
            // l2
            // 
            this.l2.BackColor = System.Drawing.Color.Silver;
            this.l2.ColorEnd = System.Drawing.Color.Silver;
            this.l2.ColorStart = System.Drawing.Color.Gray;
            this.l2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l2.ForeColor = System.Drawing.Color.White;
            this.l2.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l2.Location = new System.Drawing.Point(231, 7);
            this.l2.Name = "l2";
            this.l2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l2.Size = new System.Drawing.Size(150, 14);
            this.l2.TabIndex = 17;
            this.l2.Text = "2 - Tallonatore";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l2.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l2.Themed = true;
            this.l2.Click += new System.EventHandler(this.l2_Click);
            // 
            // l3
            // 
            this.l3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l3.BackColor = System.Drawing.Color.Silver;
            this.l3.ColorEnd = System.Drawing.Color.Silver;
            this.l3.ColorStart = System.Drawing.Color.Gray;
            this.l3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l3.ForeColor = System.Drawing.Color.White;
            this.l3.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l3.Location = new System.Drawing.Point(464, 7);
            this.l3.Name = "l3";
            this.l3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l3.Size = new System.Drawing.Size(150, 14);
            this.l3.TabIndex = 16;
            this.l3.Text = "3 - Pilone";
            this.l3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l3.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l3.Themed = true;
            this.l3.Click += new System.EventHandler(this.l3_Click);
            // 
            // l1
            // 
            this.l1.BackColor = System.Drawing.Color.Silver;
            this.l1.ColorEnd = System.Drawing.Color.Silver;
            this.l1.ColorStart = System.Drawing.Color.Gray;
            this.l1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.l1.ForeColor = System.Drawing.Color.White;
            this.l1.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.l1.Location = new System.Drawing.Point(3, 7);
            this.l1.Name = "l1";
            this.l1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 1);
            this.l1.Size = new System.Drawing.Size(150, 14);
            this.l1.TabIndex = 15;
            this.l1.Text = "1 - Pilone";
            this.l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l1.Theme = My.Controls.MSType.ThemeStyle.HomeStead;
            this.l1.Themed = true;
            this.l1.Click += new System.EventHandler(this.l1_Click);
            // 
            // c15
            // 
            this.c15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c15.Enabled = false;
            this.c15.FormattingEnabled = true;
            this.c15.Location = new System.Drawing.Point(231, 309);
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(150, 21);
            this.c15.TabIndex = 14;
            this.c15.Tag = "notranslate";
            this.c15.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c15.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c13
            // 
            this.c13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.c13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c13.Enabled = false;
            this.c13.FormattingEnabled = true;
            this.c13.Location = new System.Drawing.Point(350, 271);
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(150, 21);
            this.c13.TabIndex = 13;
            this.c13.Tag = "notranslate";
            this.c13.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c13.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c12
            // 
            this.c12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.c12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c12.Enabled = false;
            this.c12.FormattingEnabled = true;
            this.c12.Location = new System.Drawing.Point(118, 271);
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(150, 21);
            this.c12.TabIndex = 12;
            this.c12.Tag = "notranslate";
            this.c12.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c12.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c14
            // 
            this.c14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c14.Enabled = false;
            this.c14.FormattingEnabled = true;
            this.c14.Location = new System.Drawing.Point(464, 233);
            this.c14.Name = "c14";
            this.c14.Size = new System.Drawing.Size(150, 21);
            this.c14.TabIndex = 11;
            this.c14.Tag = "notranslate";
            this.c14.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c14.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c11
            // 
            this.c11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c11.Enabled = false;
            this.c11.FormattingEnabled = true;
            this.c11.Location = new System.Drawing.Point(3, 233);
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(150, 21);
            this.c11.TabIndex = 10;
            this.c11.Tag = "notranslate";
            this.c11.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c11.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c10
            // 
            this.c10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.c10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c10.Enabled = false;
            this.c10.FormattingEnabled = true;
            this.c10.Location = new System.Drawing.Point(350, 195);
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(150, 21);
            this.c10.TabIndex = 9;
            this.c10.Tag = "notranslate";
            this.c10.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c10.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c9
            // 
            this.c9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.c9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c9.Enabled = false;
            this.c9.FormattingEnabled = true;
            this.c9.Location = new System.Drawing.Point(118, 195);
            this.c9.Name = "c9";
            this.c9.Size = new System.Drawing.Size(150, 21);
            this.c9.TabIndex = 8;
            this.c9.Tag = "notranslate";
            this.c9.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c9.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c8
            // 
            this.c8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c8.Enabled = false;
            this.c8.FormattingEnabled = true;
            this.c8.Location = new System.Drawing.Point(231, 122);
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(150, 21);
            this.c8.TabIndex = 7;
            this.c8.Tag = "notranslate";
            this.c8.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c8.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c7
            // 
            this.c7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c7.Enabled = false;
            this.c7.FormattingEnabled = true;
            this.c7.Location = new System.Drawing.Point(464, 100);
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(150, 21);
            this.c7.TabIndex = 6;
            this.c7.Tag = "notranslate";
            this.c7.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c7.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c6
            // 
            this.c6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c6.Enabled = false;
            this.c6.FormattingEnabled = true;
            this.c6.Location = new System.Drawing.Point(3, 100);
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(150, 21);
            this.c6.TabIndex = 5;
            this.c6.Tag = "notranslate";
            this.c6.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c6.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c5
            // 
            this.c5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.c5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c5.Enabled = false;
            this.c5.FormattingEnabled = true;
            this.c5.Location = new System.Drawing.Point(350, 61);
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(150, 21);
            this.c5.TabIndex = 4;
            this.c5.Tag = "notranslate";
            this.c5.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c5.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c4
            // 
            this.c4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.c4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c4.Enabled = false;
            this.c4.FormattingEnabled = true;
            this.c4.Location = new System.Drawing.Point(118, 61);
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(150, 21);
            this.c4.TabIndex = 3;
            this.c4.Tag = "notranslate";
            this.c4.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c4.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c3
            // 
            this.c3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c3.Enabled = false;
            this.c3.FormattingEnabled = true;
            this.c3.Location = new System.Drawing.Point(464, 21);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(150, 21);
            this.c3.TabIndex = 2;
            this.c3.Tag = "notranslate";
            this.c3.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c3.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c2
            // 
            this.c2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c2.Enabled = false;
            this.c2.FormattingEnabled = true;
            this.c2.Location = new System.Drawing.Point(231, 21);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(150, 21);
            this.c2.TabIndex = 1;
            this.c2.Tag = "notranslate";
            this.c2.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c2.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // c1
            // 
            this.c1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c1.Enabled = false;
            this.c1.FormattingEnabled = true;
            this.c1.Location = new System.Drawing.Point(3, 21);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(150, 21);
            this.c1.TabIndex = 0;
            this.c1.Tag = "notranslate";
            this.c1.SelectedIndexChanged += new System.EventHandler(this.ComboPlayer_SelectedIndexChanged);
            this.c1.DropDown += new System.EventHandler(this.ComboPlayer_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Formazione alla data:";
            // 
            // comboDa
            // 
            this.comboDa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDa.FormattingEnabled = true;
            this.comboDa.Location = new System.Drawing.Point(117, 6);
            this.comboDa.Name = "comboDa";
            this.comboDa.Size = new System.Drawing.Size(135, 21);
            this.comboDa.TabIndex = 3;
            this.comboDa.Tag = "notranslate";
            this.comboDa.SelectedIndexChanged += new System.EventHandler(this.comboDa_SelectedIndexChanged);
            // 
            // TabFormazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabFormazione";
            this.Size = new System.Drawing.Size(640, 480);
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            this.panelFormazione.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDa;
        private System.Windows.Forms.Panel panelFormazione;
        private System.Windows.Forms.Label lVTT;
        private System.Windows.Forms.ComboBox c15;
        private System.Windows.Forms.ComboBox c13;
        private System.Windows.Forms.ComboBox c12;
        private System.Windows.Forms.ComboBox c14;
        private System.Windows.Forms.ComboBox c11;
        private System.Windows.Forms.ComboBox c10;
        private System.Windows.Forms.ComboBox c9;
        private System.Windows.Forms.ComboBox c8;
        private System.Windows.Forms.ComboBox c7;
        private System.Windows.Forms.ComboBox c6;
        private System.Windows.Forms.ComboBox c5;
        private System.Windows.Forms.ComboBox c4;
        private System.Windows.Forms.ComboBox c3;
        private System.Windows.Forms.ComboBox c2;
        private System.Windows.Forms.ComboBox c1;
        private My.Controls.MyLabel l3;
        private My.Controls.MyLabel l1;
        private My.Controls.MyLabel l5;
        private My.Controls.MyLabel l4;
        private My.Controls.MyLabel l2;
        private My.Controls.MyLabel l6;
        private My.Controls.MyLabel l8;
        private My.Controls.MyLabel l7;
        private My.Controls.MyLabel l10;
        private My.Controls.MyLabel l9;
        private My.Controls.MyLabel l15;
        private My.Controls.MyLabel l13;
        private My.Controls.MyLabel l12;
        private My.Controls.MyLabel l14;
        private My.Controls.MyLabel l11;
        private System.Windows.Forms.Label lPA;
        private System.Windows.Forms.Label lPQ;
        private System.Windows.Forms.Label lPLA;
        private System.Windows.Forms.Label lVTQ;
        private System.Windows.Forms.Label lVTA;
        private System.Windows.Forms.Label lFA;
        private System.Windows.Forms.Label tPLA;
        private System.Windows.Forms.Label tFA;
        private System.Windows.Forms.Label tPA;
        private System.Windows.Forms.Label tVTQ;
        private System.Windows.Forms.Label tVTA;
        private System.Windows.Forms.Label tVTT;
        private System.Windows.Forms.Label lRQ;
        private System.Windows.Forms.Label tRQ;
        private System.Windows.Forms.Label tPQ;
        private System.Windows.Forms.Label lEXP;
        private System.Windows.Forms.Label tEXP;
        private System.Windows.Forms.Button buttonAuto;
        private System.Windows.Forms.TextBox textOrder;
        private System.Windows.Forms.Label label2;
    }
}
