﻿namespace RMO.Tab
{
    partial class TabMarket
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.labelClub = new System.Windows.Forms.Label();
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
            this.label12 = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.bCarica = new System.Windows.Forms.Button();
            this.textPlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
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
            this.pageMain.Controls.Add(this.labelClub);
            this.pageMain.Controls.Add(this.groupBox2);
            this.pageMain.Controls.Add(this.groupBox1);
            this.pageMain.Controls.Add(this.labelNome);
            this.pageMain.Controls.Add(this.bCarica);
            this.pageMain.Controls.Add(this.textPlayer);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(632, 454);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "NOTRANSLATE mercato";
            this.pageMain.Text = "Il Mercato";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // labelClub
            // 
            this.labelClub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClub.Location = new System.Drawing.Point(390, 28);
            this.labelClub.Name = "labelClub";
            this.labelClub.Size = new System.Drawing.Size(236, 24);
            this.labelClub.TabIndex = 6;
            this.labelClub.Text = "Club";
            this.labelClub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox2.Location = new System.Drawing.Point(10, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 83);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anagrafica del giocatore";
            // 
            // lStipendio
            // 
            this.lStipendio.Location = new System.Drawing.Point(252, 16);
            this.lStipendio.Name = "lStipendio";
            this.lStipendio.Size = new System.Drawing.Size(106, 16);
            this.lStipendio.TabIndex = 12;
            this.lStipendio.Text = "Stipendio: {0} €";
            this.lStipendio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lEta
            // 
            this.lEta.Location = new System.Drawing.Point(184, 16);
            this.lEta.Name = "lEta";
            this.lEta.Size = new System.Drawing.Size(60, 16);
            this.lEta.TabIndex = 11;
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
            this.sAltezzaSkill.Value = 1;
            // 
            // sPeso
            // 
            this.sPeso.AutoSize = true;
            this.sPeso.Location = new System.Drawing.Point(74, 61);
            this.sPeso.Name = "sPeso";
            this.sPeso.Size = new System.Drawing.Size(42, 13);
            this.sPeso.TabIndex = 6;
            this.sPeso.Text = "<peso>";
            // 
            // sAltezza
            // 
            this.sAltezza.AutoSize = true;
            this.sAltezza.Location = new System.Drawing.Point(74, 40);
            this.sAltezza.Name = "sAltezza";
            this.sAltezza.Size = new System.Drawing.Size(52, 13);
            this.sAltezza.TabIndex = 5;
            this.sAltezza.Text = "<altezza>";
            // 
            // sNazione
            // 
            this.sNazione.AutoSize = true;
            this.sNazione.Location = new System.Drawing.Point(74, 18);
            this.sNazione.Name = "sNazione";
            this.sNazione.Size = new System.Drawing.Size(69, 13);
            this.sNazione.TabIndex = 4;
            this.sNazione.Text = "<nazionalità>";
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
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(10, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 112);
            this.groupBox1.TabIndex = 4;
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
            this.sEsperienza.Value = 6;
            this.sEsperienza.Visible = false;
            // 
            // sPassaggi
            // 
            this.sPassaggi.Location = new System.Drawing.Point(74, 65);
            this.sPassaggi.MaximumSize = new System.Drawing.Size(108, 16);
            this.sPassaggi.MinimumSize = new System.Drawing.Size(108, 16);
            this.sPassaggi.Name = "sPassaggi";
            this.sPassaggi.Size = new System.Drawing.Size(108, 16);
            this.sPassaggi.TabIndex = 12;
            this.sPassaggi.Value = 4;
            this.sPassaggi.Visible = false;
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
            this.sCalci.Value = 7;
            this.sCalci.Visible = false;
            // 
            // sRicezione
            // 
            this.sRicezione.Location = new System.Drawing.Point(255, 65);
            this.sRicezione.MaximumSize = new System.Drawing.Size(108, 16);
            this.sRicezione.MinimumSize = new System.Drawing.Size(108, 16);
            this.sRicezione.Name = "sRicezione";
            this.sRicezione.Size = new System.Drawing.Size(108, 16);
            this.sRicezione.TabIndex = 7;
            this.sRicezione.Value = 5;
            this.sRicezione.Visible = false;
            // 
            // sVelocita
            // 
            this.sVelocita.Location = new System.Drawing.Point(255, 43);
            this.sVelocita.MaximumSize = new System.Drawing.Size(108, 16);
            this.sVelocita.MinimumSize = new System.Drawing.Size(108, 16);
            this.sVelocita.Name = "sVelocita";
            this.sVelocita.Size = new System.Drawing.Size(108, 16);
            this.sVelocita.TabIndex = 6;
            this.sVelocita.Value = 3;
            this.sVelocita.Visible = false;
            // 
            // sForza
            // 
            this.sForza.Location = new System.Drawing.Point(255, 21);
            this.sForza.MaximumSize = new System.Drawing.Size(108, 16);
            this.sForza.MinimumSize = new System.Drawing.Size(108, 16);
            this.sForza.Name = "sForza";
            this.sForza.Size = new System.Drawing.Size(108, 16);
            this.sForza.TabIndex = 5;
            this.sForza.Value = 1;
            this.sForza.Visible = false;
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
            this.sPlaccaggi.Value = 2;
            this.sPlaccaggi.Visible = false;
            // 
            // sResistenza
            // 
            this.sResistenza.Location = new System.Drawing.Point(74, 21);
            this.sResistenza.MaximumSize = new System.Drawing.Size(108, 16);
            this.sResistenza.MinimumSize = new System.Drawing.Size(108, 16);
            this.sResistenza.Name = "sResistenza";
            this.sResistenza.Size = new System.Drawing.Size(108, 16);
            this.sResistenza.TabIndex = 2;
            this.sResistenza.Value = 0;
            this.sResistenza.Visible = false;
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
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Resistenza:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(6, 28);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(167, 24);
            this.labelNome.TabIndex = 3;
            this.labelNome.Text = "Nome e Cognome";
            this.labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bCarica
            // 
            this.bCarica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCarica.Location = new System.Drawing.Point(576, 3);
            this.bCarica.Name = "bCarica";
            this.bCarica.Size = new System.Drawing.Size(50, 23);
            this.bCarica.TabIndex = 2;
            this.bCarica.Text = "Carica";
            this.bCarica.UseVisualStyleBackColor = true;
            this.bCarica.Click += new System.EventHandler(this.bCarica_Click);
            // 
            // textPlayer
            // 
            this.textPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textPlayer.Location = new System.Drawing.Point(133, 5);
            this.textPlayer.Name = "textPlayer";
            this.textPlayer.Size = new System.Drawing.Size(437, 20);
            this.textPlayer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "La pagina del giocatore:";
            // 
            // TabMarket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabMarket";
            this.Size = new System.Drawing.Size(640, 480);
            this.Tag = "";
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.Button bCarica;
        private System.Windows.Forms.TextBox textPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private RMO.Control.Skillnum sPesoSkill;
        private RMO.Control.Skillnum sAltezzaSkill;
        private System.Windows.Forms.Label sPeso;
        private System.Windows.Forms.Label sAltezza;
        private System.Windows.Forms.Label sNazione;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private RMO.Control.Skillnum sEsperienza;
        private RMO.Control.Skillnum sPassaggi;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label lStipendio;
        private System.Windows.Forms.Label lEta;
        private System.Windows.Forms.Label labelClub;
    }
}
