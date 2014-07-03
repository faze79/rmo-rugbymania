namespace RMO.Tab
{
    partial class TabTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabTeam));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.comboVT = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lMarket = new System.Windows.Forms.Label();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textSerch = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lS15 = new System.Windows.Forms.Label();
            this.lS12 = new System.Windows.Forms.Label();
            this.lS11 = new System.Windows.Forms.Label();
            this.lS10 = new System.Windows.Forms.Label();
            this.lS9 = new System.Windows.Forms.Label();
            this.lS8 = new System.Windows.Forms.Label();
            this.lS6 = new System.Windows.Forms.Label();
            this.lS4 = new System.Windows.Forms.Label();
            this.lS2 = new System.Windows.Forms.Label();
            this.lS1 = new System.Windows.Forms.Label();
            this.lSALARIO = new System.Windows.Forms.Label();
            this.lGIORNI = new System.Windows.Forms.Label();
            this.lESPERIENZA = new System.Windows.Forms.Label();
            this.lCALCI = new System.Windows.Forms.Label();
            this.lRICEZIONE = new System.Windows.Forms.Label();
            this.lPASSAGGI = new System.Windows.Forms.Label();
            this.lVELOCITA = new System.Windows.Forms.Label();
            this.lPLACCAGGI = new System.Windows.Forms.Label();
            this.lFORZA = new System.Windows.Forms.Label();
            this.lRESISTENZA = new System.Windows.Forms.Label();
            this.lPESO = new System.Windows.Forms.Label();
            this.lALTEZZA = new System.Windows.Forms.Label();
            this.lHEta = new System.Windows.Forms.Label();
            this.lCATEGORIA = new System.Windows.Forms.Label();
            this.lSTATO = new System.Windows.Forms.Label();
            this.lCOGNOME = new System.Windows.Forms.Label();
            this.lNOME = new System.Windows.Forms.Label();
            this.lID = new System.Windows.Forms.Label();
            this.lEta = new System.Windows.Forms.Label();
            this.lStipendi = new System.Windows.Forms.Label();
            this.lTOTALE = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDa = new System.Windows.Forms.ComboBox();
            this.panelPlayers = new System.Windows.Forms.Panel();
            this.toolHeader = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.panelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageMain);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 528);
            this.tabControl1.TabIndex = 0;
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.comboVT);
            this.pageMain.Controls.Add(this.label3);
            this.pageMain.Controls.Add(this.lMarket);
            this.pageMain.Controls.Add(this.panelLoading);
            this.pageMain.Controls.Add(this.pictureBox1);
            this.pageMain.Controls.Add(this.textSerch);
            this.pageMain.Controls.Add(this.panelHeader);
            this.pageMain.Controls.Add(this.lEta);
            this.pageMain.Controls.Add(this.lStipendi);
            this.pageMain.Controls.Add(this.lTOTALE);
            this.pageMain.Controls.Add(this.label2);
            this.pageMain.Controls.Add(this.comboA);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Controls.Add(this.comboDa);
            this.pageMain.Controls.Add(this.panelPlayers);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(717, 502);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "squadra";
            this.pageMain.Text = "La mia squadra";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // comboVT
            // 
            this.comboVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVT.FormattingEnabled = true;
            this.comboVT.Items.AddRange(new object[] {
            "RM VT",
            "FAC VT"});
            this.comboVT.Location = new System.Drawing.Point(421, 6);
            this.comboVT.Name = "comboVT";
            this.comboVT.Size = new System.Drawing.Size(55, 21);
            this.comboVT.TabIndex = 14;
            this.comboVT.Tag = "notranslate";
            this.comboVT.SelectedIndexChanged += new System.EventHandler(this.comboVT_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "VT:";
            // 
            // lMarket
            // 
            this.lMarket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lMarket.BackColor = System.Drawing.Color.Red;
            this.lMarket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lMarket.Location = new System.Drawing.Point(345, 486);
            this.lMarket.Name = "lMarket";
            this.lMarket.Size = new System.Drawing.Size(366, 16);
            this.lMarket.TabIndex = 12;
            this.lMarket.Visible = false;
            // 
            // panelLoading
            // 
            this.panelLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoading.BackColor = System.Drawing.Color.White;
            this.panelLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Location = new System.Drawing.Point(530, 486);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(184, 16);
            this.panelLoading.TabIndex = 11;
            this.panelLoading.Visible = false;
            // 
            // labelLoading
            // 
            this.labelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLoading.Location = new System.Drawing.Point(0, 0);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(182, 14);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "Caricamento in corso...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(590, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // textSerch
            // 
            this.textSerch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSerch.Location = new System.Drawing.Point(611, 7);
            this.textSerch.Name = "textSerch";
            this.textSerch.Size = new System.Drawing.Size(100, 20);
            this.textSerch.TabIndex = 9;
            this.textSerch.TextChanged += new System.EventHandler(this.textSerch_TextChanged);
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.lS15);
            this.panelHeader.Controls.Add(this.lS12);
            this.panelHeader.Controls.Add(this.lS11);
            this.panelHeader.Controls.Add(this.lS10);
            this.panelHeader.Controls.Add(this.lS9);
            this.panelHeader.Controls.Add(this.lS8);
            this.panelHeader.Controls.Add(this.lS6);
            this.panelHeader.Controls.Add(this.lS4);
            this.panelHeader.Controls.Add(this.lS2);
            this.panelHeader.Controls.Add(this.lS1);
            this.panelHeader.Controls.Add(this.lSALARIO);
            this.panelHeader.Controls.Add(this.lGIORNI);
            this.panelHeader.Controls.Add(this.lESPERIENZA);
            this.panelHeader.Controls.Add(this.lCALCI);
            this.panelHeader.Controls.Add(this.lRICEZIONE);
            this.panelHeader.Controls.Add(this.lPASSAGGI);
            this.panelHeader.Controls.Add(this.lVELOCITA);
            this.panelHeader.Controls.Add(this.lPLACCAGGI);
            this.panelHeader.Controls.Add(this.lFORZA);
            this.panelHeader.Controls.Add(this.lRESISTENZA);
            this.panelHeader.Controls.Add(this.lPESO);
            this.panelHeader.Controls.Add(this.lALTEZZA);
            this.panelHeader.Controls.Add(this.lHEta);
            this.panelHeader.Controls.Add(this.lCATEGORIA);
            this.panelHeader.Controls.Add(this.lSTATO);
            this.panelHeader.Controls.Add(this.lCOGNOME);
            this.panelHeader.Controls.Add(this.lNOME);
            this.panelHeader.Controls.Add(this.lID);
            this.panelHeader.Location = new System.Drawing.Point(6, 30);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(705, 16);
            this.panelHeader.TabIndex = 8;
            // 
            // lS15
            // 
            this.lS15.AutoSize = true;
            this.lS15.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS15.Location = new System.Drawing.Point(588, 0);
            this.lS15.Name = "lS15";
            this.lS15.Size = new System.Drawing.Size(19, 13);
            this.lS15.TabIndex = 54;
            this.lS15.Text = "Es";
            this.lS15.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS15.Click += new System.EventHandler(this.lS15_Click);
            // 
            // lS12
            // 
            this.lS12.AutoSize = true;
            this.lS12.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS12.Location = new System.Drawing.Point(568, 0);
            this.lS12.Name = "lS12";
            this.lS12.Size = new System.Drawing.Size(20, 13);
            this.lS12.TabIndex = 53;
            this.lS12.Text = "Ce";
            this.lS12.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS12.Click += new System.EventHandler(this.lS12_Click);
            // 
            // lS11
            // 
            this.lS11.AutoSize = true;
            this.lS11.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS11.Location = new System.Drawing.Point(552, 0);
            this.lS11.Name = "lS11";
            this.lS11.Size = new System.Drawing.Size(16, 13);
            this.lS11.TabIndex = 52;
            this.lS11.Text = "Al";
            this.lS11.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS11.Click += new System.EventHandler(this.lS11_Click);
            // 
            // lS10
            // 
            this.lS10.AutoSize = true;
            this.lS10.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS10.Location = new System.Drawing.Point(530, 0);
            this.lS10.Name = "lS10";
            this.lS10.Size = new System.Drawing.Size(22, 13);
            this.lS10.TabIndex = 51;
            this.lS10.Text = "Ma";
            this.lS10.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS10.Click += new System.EventHandler(this.lS10_Click);
            // 
            // lS9
            // 
            this.lS9.AutoSize = true;
            this.lS9.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS9.Location = new System.Drawing.Point(506, 0);
            this.lS9.Name = "lS9";
            this.lS9.Size = new System.Drawing.Size(24, 13);
            this.lS9.TabIndex = 50;
            this.lS9.Text = "Mm";
            this.lS9.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS9.Click += new System.EventHandler(this.lS9_Click);
            // 
            // lS8
            // 
            this.lS8.AutoSize = true;
            this.lS8.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS8.Location = new System.Drawing.Point(487, 0);
            this.lS8.Name = "lS8";
            this.lS8.Size = new System.Drawing.Size(19, 13);
            this.lS8.TabIndex = 49;
            this.lS8.Text = "n8";
            this.lS8.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS8.Click += new System.EventHandler(this.lS8_Click);
            // 
            // lS6
            // 
            this.lS6.AutoSize = true;
            this.lS6.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS6.Location = new System.Drawing.Point(468, 0);
            this.lS6.Name = "lS6";
            this.lS6.Size = new System.Drawing.Size(19, 13);
            this.lS6.TabIndex = 48;
            this.lS6.Text = "3a";
            this.lS6.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS6.Click += new System.EventHandler(this.lS6_Click);
            // 
            // lS4
            // 
            this.lS4.AutoSize = true;
            this.lS4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS4.Location = new System.Drawing.Point(449, 0);
            this.lS4.Name = "lS4";
            this.lS4.Size = new System.Drawing.Size(19, 13);
            this.lS4.TabIndex = 47;
            this.lS4.Text = "2L";
            this.lS4.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS4.Click += new System.EventHandler(this.lS4_Click);
            // 
            // lS2
            // 
            this.lS2.AutoSize = true;
            this.lS2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS2.Location = new System.Drawing.Point(429, 0);
            this.lS2.Name = "lS2";
            this.lS2.Size = new System.Drawing.Size(20, 13);
            this.lS2.TabIndex = 46;
            this.lS2.Text = "Ta";
            this.lS2.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS2.Click += new System.EventHandler(this.lS2_Click);
            // 
            // lS1
            // 
            this.lS1.AutoSize = true;
            this.lS1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS1.Location = new System.Drawing.Point(413, 0);
            this.lS1.Name = "lS1";
            this.lS1.Size = new System.Drawing.Size(16, 13);
            this.lS1.TabIndex = 45;
            this.lS1.Text = "Pi";
            this.lS1.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lS1.Click += new System.EventHandler(this.lS1_Click);
            // 
            // lSALARIO
            // 
            this.lSALARIO.AutoSize = true;
            this.lSALARIO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lSALARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSALARIO.Location = new System.Drawing.Point(391, 0);
            this.lSALARIO.Name = "lSALARIO";
            this.lSALARIO.Size = new System.Drawing.Size(22, 13);
            this.lSALARIO.TabIndex = 44;
            this.lSALARIO.Text = "Sal";
            this.lSALARIO.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lSALARIO.Click += new System.EventHandler(this.lSALARIO_Click);
            // 
            // lGIORNI
            // 
            this.lGIORNI.AutoSize = true;
            this.lGIORNI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lGIORNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGIORNI.Location = new System.Drawing.Point(370, 0);
            this.lGIORNI.Name = "lGIORNI";
            this.lGIORNI.Size = new System.Drawing.Size(21, 13);
            this.lGIORNI.TabIndex = 43;
            this.lGIORNI.Text = "Gg";
            this.lGIORNI.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lGIORNI.Click += new System.EventHandler(this.lGIORNI_Click);
            // 
            // lESPERIENZA
            // 
            this.lESPERIENZA.AutoSize = true;
            this.lESPERIENZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lESPERIENZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lESPERIENZA.Location = new System.Drawing.Point(351, 0);
            this.lESPERIENZA.Name = "lESPERIENZA";
            this.lESPERIENZA.Size = new System.Drawing.Size(19, 13);
            this.lESPERIENZA.TabIndex = 55;
            this.lESPERIENZA.Text = "Ex";
            this.lESPERIENZA.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lESPERIENZA.Click += new System.EventHandler(this.lESPERIENZA_Click);
            // 
            // lCALCI
            // 
            this.lCALCI.AutoSize = true;
            this.lCALCI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lCALCI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCALCI.Location = new System.Drawing.Point(331, 0);
            this.lCALCI.Name = "lCALCI";
            this.lCALCI.Size = new System.Drawing.Size(20, 13);
            this.lCALCI.TabIndex = 42;
            this.lCALCI.Text = "Ca";
            this.lCALCI.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lCALCI.Click += new System.EventHandler(this.lCALCI_Click);
            // 
            // lRICEZIONE
            // 
            this.lRICEZIONE.AutoSize = true;
            this.lRICEZIONE.Dock = System.Windows.Forms.DockStyle.Left;
            this.lRICEZIONE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRICEZIONE.Location = new System.Drawing.Point(314, 0);
            this.lRICEZIONE.Name = "lRICEZIONE";
            this.lRICEZIONE.Size = new System.Drawing.Size(17, 13);
            this.lRICEZIONE.TabIndex = 41;
            this.lRICEZIONE.Text = "Ri";
            this.lRICEZIONE.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lRICEZIONE.Click += new System.EventHandler(this.lRICEZIONE_Click);
            // 
            // lPASSAGGI
            // 
            this.lPASSAGGI.AutoSize = true;
            this.lPASSAGGI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPASSAGGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPASSAGGI.Location = new System.Drawing.Point(294, 0);
            this.lPASSAGGI.Name = "lPASSAGGI";
            this.lPASSAGGI.Size = new System.Drawing.Size(20, 13);
            this.lPASSAGGI.TabIndex = 40;
            this.lPASSAGGI.Text = "Pa";
            this.lPASSAGGI.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lPASSAGGI.Click += new System.EventHandler(this.lPASSAGGI_Click);
            // 
            // lVELOCITA
            // 
            this.lVELOCITA.AutoSize = true;
            this.lVELOCITA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lVELOCITA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVELOCITA.Location = new System.Drawing.Point(274, 0);
            this.lVELOCITA.Name = "lVELOCITA";
            this.lVELOCITA.Size = new System.Drawing.Size(20, 13);
            this.lVELOCITA.TabIndex = 39;
            this.lVELOCITA.Text = "Ve";
            this.lVELOCITA.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lVELOCITA.Click += new System.EventHandler(this.lVELOCITA_Click);
            // 
            // lPLACCAGGI
            // 
            this.lPLACCAGGI.AutoSize = true;
            this.lPLACCAGGI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPLACCAGGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPLACCAGGI.Location = new System.Drawing.Point(258, 0);
            this.lPLACCAGGI.Name = "lPLACCAGGI";
            this.lPLACCAGGI.Size = new System.Drawing.Size(16, 13);
            this.lPLACCAGGI.TabIndex = 38;
            this.lPLACCAGGI.Text = "Pl";
            this.lPLACCAGGI.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lPLACCAGGI.Click += new System.EventHandler(this.lPLACCAGGI_Click);
            // 
            // lFORZA
            // 
            this.lFORZA.AutoSize = true;
            this.lFORZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lFORZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFORZA.Location = new System.Drawing.Point(239, 0);
            this.lFORZA.Name = "lFORZA";
            this.lFORZA.Size = new System.Drawing.Size(19, 13);
            this.lFORZA.TabIndex = 37;
            this.lFORZA.Text = "Fo";
            this.lFORZA.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lFORZA.Click += new System.EventHandler(this.lFORZA_Click);
            // 
            // lRESISTENZA
            // 
            this.lRESISTENZA.AutoSize = true;
            this.lRESISTENZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lRESISTENZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRESISTENZA.Location = new System.Drawing.Point(218, 0);
            this.lRESISTENZA.Name = "lRESISTENZA";
            this.lRESISTENZA.Size = new System.Drawing.Size(21, 13);
            this.lRESISTENZA.TabIndex = 36;
            this.lRESISTENZA.Text = "Re";
            this.lRESISTENZA.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallLabel_Paint);
            this.lRESISTENZA.Click += new System.EventHandler(this.lRESISTENZA_Click);
            // 
            // lPESO
            // 
            this.lPESO.AutoSize = true;
            this.lPESO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPESO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPESO.Location = new System.Drawing.Point(187, 0);
            this.lPESO.Name = "lPESO";
            this.lPESO.Size = new System.Drawing.Size(31, 13);
            this.lPESO.TabIndex = 35;
            this.lPESO.Text = "Peso";
            this.lPESO.Click += new System.EventHandler(this.lPESO_Click);
            // 
            // lALTEZZA
            // 
            this.lALTEZZA.AutoSize = true;
            this.lALTEZZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lALTEZZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lALTEZZA.Location = new System.Drawing.Point(168, 0);
            this.lALTEZZA.Name = "lALTEZZA";
            this.lALTEZZA.Size = new System.Drawing.Size(19, 13);
            this.lALTEZZA.TabIndex = 34;
            this.lALTEZZA.Text = "Alt";
            this.lALTEZZA.Click += new System.EventHandler(this.lALTEZZA_Click);
            // 
            // lHEta
            // 
            this.lHEta.AutoSize = true;
            this.lHEta.Dock = System.Windows.Forms.DockStyle.Left;
            this.lHEta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHEta.Location = new System.Drawing.Point(154, 0);
            this.lHEta.Name = "lHEta";
            this.lHEta.Size = new System.Drawing.Size(14, 13);
            this.lHEta.TabIndex = 33;
            this.lHEta.Text = "E";
            this.lHEta.Click += new System.EventHandler(this.lHEta_Click);
            // 
            // lCATEGORIA
            // 
            this.lCATEGORIA.AutoSize = true;
            this.lCATEGORIA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lCATEGORIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCATEGORIA.Location = new System.Drawing.Point(131, 0);
            this.lCATEGORIA.Name = "lCATEGORIA";
            this.lCATEGORIA.Size = new System.Drawing.Size(23, 13);
            this.lCATEGORIA.TabIndex = 32;
            this.lCATEGORIA.Text = "Cat";
            this.lCATEGORIA.Click += new System.EventHandler(this.lCATEGORIA_Click);
            // 
            // lSTATO
            // 
            this.lSTATO.AutoSize = true;
            this.lSTATO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lSTATO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSTATO.Location = new System.Drawing.Point(105, 0);
            this.lSTATO.Name = "lSTATO";
            this.lSTATO.Size = new System.Drawing.Size(26, 13);
            this.lSTATO.TabIndex = 31;
            this.lSTATO.Text = "Naz";
            this.lSTATO.Click += new System.EventHandler(this.lSTATO_Click);
            // 
            // lCOGNOME
            // 
            this.lCOGNOME.AutoSize = true;
            this.lCOGNOME.Dock = System.Windows.Forms.DockStyle.Left;
            this.lCOGNOME.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCOGNOME.Location = new System.Drawing.Point(53, 0);
            this.lCOGNOME.Name = "lCOGNOME";
            this.lCOGNOME.Size = new System.Drawing.Size(52, 13);
            this.lCOGNOME.TabIndex = 30;
            this.lCOGNOME.Text = "Cognome";
            this.lCOGNOME.Click += new System.EventHandler(this.lCOGNOME_Click);
            // 
            // lNOME
            // 
            this.lNOME.AutoSize = true;
            this.lNOME.Dock = System.Windows.Forms.DockStyle.Left;
            this.lNOME.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNOME.Location = new System.Drawing.Point(18, 0);
            this.lNOME.Name = "lNOME";
            this.lNOME.Size = new System.Drawing.Size(35, 13);
            this.lNOME.TabIndex = 29;
            this.lNOME.Text = "Nome";
            this.lNOME.Click += new System.EventHandler(this.lNOME_Click);
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lID.Dock = System.Windows.Forms.DockStyle.Left;
            this.lID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lID.ForeColor = System.Drawing.Color.Black;
            this.lID.Location = new System.Drawing.Point(0, 0);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(18, 13);
            this.lID.TabIndex = 28;
            this.lID.Text = "ID";
            this.lID.Click += new System.EventHandler(this.lID_Click);
            // 
            // lEta
            // 
            this.lEta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lEta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lEta.Location = new System.Drawing.Point(230, 486);
            this.lEta.Name = "lEta";
            this.lEta.Size = new System.Drawing.Size(109, 16);
            this.lEta.TabIndex = 7;
            this.lEta.Tag = "notranslate";
            this.lEta.Text = "Età media 20,5 anni.";
            // 
            // lStipendi
            // 
            this.lStipendi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lStipendi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lStipendi.Location = new System.Drawing.Point(88, 486);
            this.lStipendi.Name = "lStipendi";
            this.lStipendi.Size = new System.Drawing.Size(136, 16);
            this.lStipendi.TabIndex = 6;
            this.lStipendi.Tag = "notranslate";
            this.lStipendi.Text = "Monte stipendi: 35000 €";
            // 
            // lTOTALE
            // 
            this.lTOTALE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTOTALE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTOTALE.Location = new System.Drawing.Point(6, 486);
            this.lTOTALE.Name = "lTOTALE";
            this.lTOTALE.Size = new System.Drawing.Size(76, 16);
            this.lTOTALE.TabIndex = 5;
            this.lTOTALE.Tag = "notranslate";
            this.lTOTALE.Text = "0 Giocatori:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "al:";
            // 
            // comboA
            // 
            this.comboA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboA.FormattingEnabled = true;
            this.comboA.Location = new System.Drawing.Point(250, 6);
            this.comboA.Name = "comboA";
            this.comboA.Size = new System.Drawing.Size(135, 21);
            this.comboA.TabIndex = 3;
            this.comboA.Tag = "notranslate";
            this.comboA.SelectedIndexChanged += new System.EventHandler(this.comboA_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Confronta dal:";
            // 
            // comboDa
            // 
            this.comboDa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDa.FormattingEnabled = true;
            this.comboDa.Location = new System.Drawing.Point(85, 6);
            this.comboDa.Name = "comboDa";
            this.comboDa.Size = new System.Drawing.Size(135, 21);
            this.comboDa.TabIndex = 1;
            this.comboDa.Tag = "notranslate";
            this.comboDa.SelectedIndexChanged += new System.EventHandler(this.comboDa_SelectedIndexChanged);
            // 
            // panelPlayers
            // 
            this.panelPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlayers.AutoScroll = true;
            this.panelPlayers.BackColor = System.Drawing.Color.White;
            this.panelPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayers.Location = new System.Drawing.Point(6, 45);
            this.panelPlayers.Name = "panelPlayers";
            this.panelPlayers.Size = new System.Drawing.Size(705, 439);
            this.panelPlayers.TabIndex = 0;
            this.panelPlayers.Tag = "NOTRANSLATE";
            // 
            // toolHeader
            // 
            this.toolHeader.IsBalloon = true;
            this.toolHeader.ShowAlways = true;
            this.toolHeader.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolHeader.ToolTipTitle = "Colonna";
            // 
            // TabTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabTeam";
            this.Size = new System.Drawing.Size(725, 528);
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.Panel panelPlayers;
        private System.Windows.Forms.ComboBox comboDa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lTOTALE;
        private System.Windows.Forms.Label lStipendi;
        private System.Windows.Forms.Label lEta;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lS15;
        private System.Windows.Forms.Label lS12;
        private System.Windows.Forms.Label lS11;
        private System.Windows.Forms.Label lS10;
        private System.Windows.Forms.Label lS9;
        private System.Windows.Forms.Label lS8;
        private System.Windows.Forms.Label lS6;
        private System.Windows.Forms.Label lS4;
        private System.Windows.Forms.Label lS2;
        private System.Windows.Forms.Label lS1;
        private System.Windows.Forms.Label lSALARIO;
        private System.Windows.Forms.Label lGIORNI;
        private System.Windows.Forms.Label lESPERIENZA;
        private System.Windows.Forms.Label lCALCI;
        private System.Windows.Forms.Label lRICEZIONE;
        private System.Windows.Forms.Label lPASSAGGI;
        private System.Windows.Forms.Label lVELOCITA;
        private System.Windows.Forms.Label lPLACCAGGI;
        private System.Windows.Forms.Label lFORZA;
        private System.Windows.Forms.Label lRESISTENZA;
        private System.Windows.Forms.Label lPESO;
        private System.Windows.Forms.Label lALTEZZA;
        private System.Windows.Forms.Label lHEta;
        private System.Windows.Forms.Label lCATEGORIA;
        private System.Windows.Forms.Label lSTATO;
        private System.Windows.Forms.Label lNOME;
        private System.Windows.Forms.Label lCOGNOME;
        private System.Windows.Forms.Label lID;
        private System.Windows.Forms.ToolTip toolHeader;
        private System.Windows.Forms.TextBox textSerch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Label lMarket;
        private System.Windows.Forms.ComboBox comboVT;
        private System.Windows.Forms.Label label3;
    }
}
