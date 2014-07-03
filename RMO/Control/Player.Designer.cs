namespace RMO.Control
{
    partial class Player
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
            this.lID = new System.Windows.Forms.Label();
            this.lNOME = new System.Windows.Forms.Label();
            this.lCOGNOME = new System.Windows.Forms.Label();
            this.lSTATO = new System.Windows.Forms.Label();
            this.lCATEGORIA = new System.Windows.Forms.Label();
            this.lETA = new System.Windows.Forms.Label();
            this.lALTEZZA = new System.Windows.Forms.Label();
            this.lPESO = new System.Windows.Forms.Label();
            this.lRESISTENZA = new System.Windows.Forms.Label();
            this.lFORZA = new System.Windows.Forms.Label();
            this.lPLACCAGGI = new System.Windows.Forms.Label();
            this.lVELOCITA = new System.Windows.Forms.Label();
            this.lPASSAGGI = new System.Windows.Forms.Label();
            this.lRICEZIONE = new System.Windows.Forms.Label();
            this.lCALCI = new System.Windows.Forms.Label();
            this.lGIORNI = new System.Windows.Forms.Label();
            this.lSALARIO = new System.Windows.Forms.Label();
            this.lS1 = new System.Windows.Forms.Label();
            this.lS2 = new System.Windows.Forms.Label();
            this.lS4 = new System.Windows.Forms.Label();
            this.lS6 = new System.Windows.Forms.Label();
            this.lS8 = new System.Windows.Forms.Label();
            this.lS9 = new System.Windows.Forms.Label();
            this.lS10 = new System.Windows.Forms.Label();
            this.lS11 = new System.Windows.Forms.Label();
            this.lS12 = new System.Windows.Forms.Label();
            this.lS15 = new System.Windows.Forms.Label();
            this.toolETA = new System.Windows.Forms.ToolTip(this.components);
            this.lESPERIENZA = new System.Windows.Forms.Label();
            this.toolSKILL = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lID.Dock = System.Windows.Forms.DockStyle.Left;
            this.lID.ForeColor = System.Drawing.Color.Blue;
            this.lID.Location = new System.Drawing.Point(0, 0);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(18, 13);
            this.lID.TabIndex = 0;
            this.lID.Text = "ID";
            this.lID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lID.Click += new System.EventHandler(this.lID_Click);
            // 
            // lNOME
            // 
            this.lNOME.AutoSize = true;
            this.lNOME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lNOME.Dock = System.Windows.Forms.DockStyle.Left;
            this.lNOME.Location = new System.Drawing.Point(18, 0);
            this.lNOME.Name = "lNOME";
            this.lNOME.Size = new System.Drawing.Size(35, 13);
            this.lNOME.TabIndex = 1;
            this.lNOME.Text = "Nome";
            this.lNOME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lNOME.MouseLeave += new System.EventHandler(this.lNOME_MouseLeave);
            this.lNOME.MouseEnter += new System.EventHandler(this.lNOME_MouseEnter);
            // 
            // lCOGNOME
            // 
            this.lCOGNOME.AutoSize = true;
            this.lCOGNOME.Dock = System.Windows.Forms.DockStyle.Left;
            this.lCOGNOME.Location = new System.Drawing.Point(53, 0);
            this.lCOGNOME.Name = "lCOGNOME";
            this.lCOGNOME.Size = new System.Drawing.Size(52, 13);
            this.lCOGNOME.TabIndex = 2;
            this.lCOGNOME.Text = "Cognome";
            this.lCOGNOME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lSTATO
            // 
            this.lSTATO.AutoSize = true;
            this.lSTATO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lSTATO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lSTATO.Location = new System.Drawing.Point(105, 0);
            this.lSTATO.Name = "lSTATO";
            this.lSTATO.Size = new System.Drawing.Size(46, 13);
            this.lSTATO.TabIndex = 3;
            this.lSTATO.Text = "Nazione";
            this.lSTATO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCATEGORIA
            // 
            this.lCATEGORIA.AutoSize = true;
            this.lCATEGORIA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lCATEGORIA.Location = new System.Drawing.Point(151, 0);
            this.lCATEGORIA.Name = "lCATEGORIA";
            this.lCATEGORIA.Size = new System.Drawing.Size(52, 13);
            this.lCATEGORIA.TabIndex = 4;
            this.lCATEGORIA.Text = "Categoria";
            this.lCATEGORIA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lETA
            // 
            this.lETA.AutoSize = true;
            this.lETA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lETA.Location = new System.Drawing.Point(203, 0);
            this.lETA.Name = "lETA";
            this.lETA.Size = new System.Drawing.Size(23, 13);
            this.lETA.TabIndex = 5;
            this.lETA.Text = "Età";
            this.lETA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lALTEZZA
            // 
            this.lALTEZZA.AutoSize = true;
            this.lALTEZZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lALTEZZA.Location = new System.Drawing.Point(226, 0);
            this.lALTEZZA.Name = "lALTEZZA";
            this.lALTEZZA.Size = new System.Drawing.Size(41, 13);
            this.lALTEZZA.TabIndex = 6;
            this.lALTEZZA.Text = "Altezza";
            this.lALTEZZA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPESO
            // 
            this.lPESO.AutoSize = true;
            this.lPESO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPESO.Location = new System.Drawing.Point(267, 0);
            this.lPESO.Name = "lPESO";
            this.lPESO.Size = new System.Drawing.Size(31, 13);
            this.lPESO.TabIndex = 7;
            this.lPESO.Text = "Peso";
            this.lPESO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lRESISTENZA
            // 
            this.lRESISTENZA.AutoSize = true;
            this.lRESISTENZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lRESISTENZA.Location = new System.Drawing.Point(298, 0);
            this.lRESISTENZA.Name = "lRESISTENZA";
            this.lRESISTENZA.Size = new System.Drawing.Size(21, 13);
            this.lRESISTENZA.TabIndex = 8;
            this.lRESISTENZA.Text = "Re";
            this.lRESISTENZA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lFORZA
            // 
            this.lFORZA.AutoSize = true;
            this.lFORZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lFORZA.Location = new System.Drawing.Point(319, 0);
            this.lFORZA.Name = "lFORZA";
            this.lFORZA.Size = new System.Drawing.Size(19, 13);
            this.lFORZA.TabIndex = 9;
            this.lFORZA.Text = "Fo";
            this.lFORZA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPLACCAGGI
            // 
            this.lPLACCAGGI.AutoSize = true;
            this.lPLACCAGGI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPLACCAGGI.Location = new System.Drawing.Point(338, 0);
            this.lPLACCAGGI.Name = "lPLACCAGGI";
            this.lPLACCAGGI.Size = new System.Drawing.Size(16, 13);
            this.lPLACCAGGI.TabIndex = 10;
            this.lPLACCAGGI.Text = "Pl";
            this.lPLACCAGGI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lVELOCITA
            // 
            this.lVELOCITA.AutoSize = true;
            this.lVELOCITA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lVELOCITA.Location = new System.Drawing.Point(354, 0);
            this.lVELOCITA.Name = "lVELOCITA";
            this.lVELOCITA.Size = new System.Drawing.Size(20, 13);
            this.lVELOCITA.TabIndex = 11;
            this.lVELOCITA.Text = "Ve";
            this.lVELOCITA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPASSAGGI
            // 
            this.lPASSAGGI.AutoSize = true;
            this.lPASSAGGI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPASSAGGI.Location = new System.Drawing.Point(374, 0);
            this.lPASSAGGI.Name = "lPASSAGGI";
            this.lPASSAGGI.Size = new System.Drawing.Size(20, 13);
            this.lPASSAGGI.TabIndex = 12;
            this.lPASSAGGI.Text = "Pa";
            this.lPASSAGGI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lRICEZIONE
            // 
            this.lRICEZIONE.AutoSize = true;
            this.lRICEZIONE.Dock = System.Windows.Forms.DockStyle.Left;
            this.lRICEZIONE.Location = new System.Drawing.Point(394, 0);
            this.lRICEZIONE.Name = "lRICEZIONE";
            this.lRICEZIONE.Size = new System.Drawing.Size(17, 13);
            this.lRICEZIONE.TabIndex = 13;
            this.lRICEZIONE.Text = "Ri";
            this.lRICEZIONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCALCI
            // 
            this.lCALCI.AutoSize = true;
            this.lCALCI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lCALCI.Location = new System.Drawing.Point(411, 0);
            this.lCALCI.Name = "lCALCI";
            this.lCALCI.Size = new System.Drawing.Size(20, 13);
            this.lCALCI.TabIndex = 14;
            this.lCALCI.Text = "Ca";
            this.lCALCI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lGIORNI
            // 
            this.lGIORNI.AutoSize = true;
            this.lGIORNI.Dock = System.Windows.Forms.DockStyle.Left;
            this.lGIORNI.Location = new System.Drawing.Point(450, 0);
            this.lGIORNI.Name = "lGIORNI";
            this.lGIORNI.Size = new System.Drawing.Size(34, 13);
            this.lGIORNI.TabIndex = 15;
            this.lGIORNI.Text = "Giorni";
            this.lGIORNI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lSALARIO
            // 
            this.lSALARIO.AutoSize = true;
            this.lSALARIO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lSALARIO.Location = new System.Drawing.Point(484, 0);
            this.lSALARIO.Name = "lSALARIO";
            this.lSALARIO.Size = new System.Drawing.Size(22, 13);
            this.lSALARIO.TabIndex = 16;
            this.lSALARIO.Text = "Sal";
            this.lSALARIO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lS1
            // 
            this.lS1.AutoSize = true;
            this.lS1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS1.Location = new System.Drawing.Point(506, 0);
            this.lS1.Name = "lS1";
            this.lS1.Size = new System.Drawing.Size(18, 13);
            this.lS1.TabIndex = 17;
            this.lS1.Text = "Pil";
            this.lS1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS1.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS2
            // 
            this.lS2.AutoSize = true;
            this.lS2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS2.Location = new System.Drawing.Point(524, 0);
            this.lS2.Name = "lS2";
            this.lS2.Size = new System.Drawing.Size(22, 13);
            this.lS2.TabIndex = 18;
            this.lS2.Text = "Tal";
            this.lS2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS2.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS4
            // 
            this.lS4.AutoSize = true;
            this.lS4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS4.Location = new System.Drawing.Point(546, 0);
            this.lS4.Name = "lS4";
            this.lS4.Size = new System.Drawing.Size(26, 13);
            this.lS4.TabIndex = 19;
            this.lS4.Text = "Sec";
            this.lS4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS4.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS6
            // 
            this.lS6.AutoSize = true;
            this.lS6.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS6.Location = new System.Drawing.Point(572, 0);
            this.lS6.Name = "lS6";
            this.lS6.Size = new System.Drawing.Size(27, 13);
            this.lS6.TabIndex = 20;
            this.lS6.Text = "TeA";
            this.lS6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS6.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS8
            // 
            this.lS8.AutoSize = true;
            this.lS8.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS8.Location = new System.Drawing.Point(599, 0);
            this.lS8.Name = "lS8";
            this.lS8.Size = new System.Drawing.Size(27, 13);
            this.lS8.TabIndex = 21;
            this.lS8.Text = "TeC";
            this.lS8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS8.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS9
            // 
            this.lS9.AutoSize = true;
            this.lS9.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS9.Location = new System.Drawing.Point(626, 0);
            this.lS9.Name = "lS9";
            this.lS9.Size = new System.Drawing.Size(24, 13);
            this.lS9.TabIndex = 22;
            this.lS9.Text = "Mm";
            this.lS9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS9.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS10
            // 
            this.lS10.AutoSize = true;
            this.lS10.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS10.Location = new System.Drawing.Point(650, 0);
            this.lS10.Name = "lS10";
            this.lS10.Size = new System.Drawing.Size(22, 13);
            this.lS10.TabIndex = 23;
            this.lS10.Text = "Ma";
            this.lS10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS10.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS11
            // 
            this.lS11.AutoSize = true;
            this.lS11.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS11.Location = new System.Drawing.Point(672, 0);
            this.lS11.Name = "lS11";
            this.lS11.Size = new System.Drawing.Size(22, 13);
            this.lS11.TabIndex = 24;
            this.lS11.Text = "Ala";
            this.lS11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS11.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS12
            // 
            this.lS12.AutoSize = true;
            this.lS12.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS12.Location = new System.Drawing.Point(694, 0);
            this.lS12.Name = "lS12";
            this.lS12.Size = new System.Drawing.Size(26, 13);
            this.lS12.TabIndex = 25;
            this.lS12.Text = "Cen";
            this.lS12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS12.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // lS15
            // 
            this.lS15.AutoSize = true;
            this.lS15.Dock = System.Windows.Forms.DockStyle.Left;
            this.lS15.Location = new System.Drawing.Point(720, 0);
            this.lS15.Name = "lS15";
            this.lS15.Size = new System.Drawing.Size(22, 13);
            this.lS15.TabIndex = 26;
            this.lS15.Text = "Est";
            this.lS15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lS15.TextChanged += new System.EventHandler(this.lValutazione_TextChanged);
            // 
            // toolETA
            // 
            this.toolETA.IsBalloon = true;
            this.toolETA.ShowAlways = true;
            this.toolETA.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lESPERIENZA
            // 
            this.lESPERIENZA.AutoSize = true;
            this.lESPERIENZA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lESPERIENZA.Location = new System.Drawing.Point(431, 0);
            this.lESPERIENZA.Name = "lESPERIENZA";
            this.lESPERIENZA.Size = new System.Drawing.Size(19, 13);
            this.lESPERIENZA.TabIndex = 27;
            this.lESPERIENZA.Text = "Es";
            this.lESPERIENZA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolSKILL
            // 
            this.toolSKILL.IsBalloon = true;
            this.toolSKILL.ShowAlways = true;
            this.toolSKILL.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lS15);
            this.Controls.Add(this.lS12);
            this.Controls.Add(this.lS11);
            this.Controls.Add(this.lS10);
            this.Controls.Add(this.lS9);
            this.Controls.Add(this.lS8);
            this.Controls.Add(this.lS6);
            this.Controls.Add(this.lS4);
            this.Controls.Add(this.lS2);
            this.Controls.Add(this.lS1);
            this.Controls.Add(this.lSALARIO);
            this.Controls.Add(this.lGIORNI);
            this.Controls.Add(this.lESPERIENZA);
            this.Controls.Add(this.lCALCI);
            this.Controls.Add(this.lRICEZIONE);
            this.Controls.Add(this.lPASSAGGI);
            this.Controls.Add(this.lVELOCITA);
            this.Controls.Add(this.lPLACCAGGI);
            this.Controls.Add(this.lFORZA);
            this.Controls.Add(this.lRESISTENZA);
            this.Controls.Add(this.lPESO);
            this.Controls.Add(this.lALTEZZA);
            this.Controls.Add(this.lETA);
            this.Controls.Add(this.lCATEGORIA);
            this.Controls.Add(this.lSTATO);
            this.Controls.Add(this.lCOGNOME);
            this.Controls.Add(this.lNOME);
            this.Controls.Add(this.lID);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(1090, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lID;
        private System.Windows.Forms.Label lNOME;
        private System.Windows.Forms.Label lCOGNOME;
        private System.Windows.Forms.Label lSTATO;
        private System.Windows.Forms.Label lCATEGORIA;
        private System.Windows.Forms.Label lETA;
        private System.Windows.Forms.Label lALTEZZA;
        private System.Windows.Forms.Label lPESO;
        private System.Windows.Forms.Label lRESISTENZA;
        private System.Windows.Forms.Label lFORZA;
        private System.Windows.Forms.Label lPLACCAGGI;
        private System.Windows.Forms.Label lVELOCITA;
        private System.Windows.Forms.Label lPASSAGGI;
        private System.Windows.Forms.Label lRICEZIONE;
        private System.Windows.Forms.Label lCALCI;
        private System.Windows.Forms.Label lGIORNI;
        private System.Windows.Forms.Label lSALARIO;
        private System.Windows.Forms.Label lS1;
        private System.Windows.Forms.Label lS2;
        private System.Windows.Forms.Label lS4;
        private System.Windows.Forms.Label lS6;
        private System.Windows.Forms.Label lS8;
        private System.Windows.Forms.Label lS9;
        private System.Windows.Forms.Label lS10;
        private System.Windows.Forms.Label lS11;
        private System.Windows.Forms.Label lS12;
        private System.Windows.Forms.Label lS15;
        private System.Windows.Forms.ToolTip toolETA;
        private System.Windows.Forms.Label lESPERIENZA;
        private System.Windows.Forms.ToolTip toolSKILL;
    }
}
