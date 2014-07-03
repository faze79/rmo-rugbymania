namespace RMO.Tab
{
    partial class TabClassifica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabClassifica));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.buttonAggiorna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listClassifica = new System.Windows.Forms.ListView();
            this.cPosizione = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cClub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cGiocate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cVinte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPareggiate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPerse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPuntiFatti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPuntiSubiti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPuntiDiff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cBonus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPunti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numStagione = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStagione)).BeginInit();
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
            this.pageMain.Controls.Add(this.numStagione);
            this.pageMain.Controls.Add(this.buttonAggiorna);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Controls.Add(this.listClassifica);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(632, 454);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "classifica";
            this.pageMain.Text = "La Classifica";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // buttonAggiorna
            // 
            this.buttonAggiorna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAggiorna.Image = ((System.Drawing.Image)(resources.GetObject("buttonAggiorna.Image")));
            this.buttonAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAggiorna.Location = new System.Drawing.Point(551, 6);
            this.buttonAggiorna.Name = "buttonAggiorna";
            this.buttonAggiorna.Size = new System.Drawing.Size(75, 23);
            this.buttonAggiorna.TabIndex = 3;
            this.buttonAggiorna.Text = "Aggiorna";
            this.buttonAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAggiorna.UseVisualStyleBackColor = true;
            this.buttonAggiorna.Click += new System.EventHandler(this.buttonAggiorna_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stagione:";
            // 
            // listClassifica
            // 
            this.listClassifica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listClassifica.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cPosizione,
            this.cClub,
            this.cGiocate,
            this.cVinte,
            this.cPareggiate,
            this.cPerse,
            this.cPuntiFatti,
            this.cPuntiSubiti,
            this.cPuntiDiff,
            this.cBonus,
            this.cPunti});
            this.listClassifica.FullRowSelect = true;
            this.listClassifica.HideSelection = false;
            this.listClassifica.Location = new System.Drawing.Point(6, 33);
            this.listClassifica.Name = "listClassifica";
            this.listClassifica.Size = new System.Drawing.Size(620, 415);
            this.listClassifica.TabIndex = 0;
            this.listClassifica.UseCompatibleStateImageBehavior = false;
            this.listClassifica.View = System.Windows.Forms.View.Details;
            this.listClassifica.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listClassifica_ColumnClick);
            // 
            // cPosizione
            // 
            this.cPosizione.Text = "Posizione";
            this.cPosizione.Width = 30;
            // 
            // cClub
            // 
            this.cClub.Text = "Squadra";
            this.cClub.Width = 150;
            // 
            // cGiocate
            // 
            this.cGiocate.Text = "P.G.";
            this.cGiocate.Width = 40;
            // 
            // cVinte
            // 
            this.cVinte.Text = "P.V.";
            this.cVinte.Width = 40;
            // 
            // cPareggiate
            // 
            this.cPareggiate.Text = "P.N.";
            this.cPareggiate.Width = 40;
            // 
            // cPerse
            // 
            this.cPerse.Text = "P.P.";
            this.cPerse.Width = 40;
            // 
            // cPuntiFatti
            // 
            this.cPuntiFatti.Text = "+";
            this.cPuntiFatti.Width = 40;
            // 
            // cPuntiSubiti
            // 
            this.cPuntiSubiti.Text = "-";
            this.cPuntiSubiti.Width = 40;
            // 
            // cPuntiDiff
            // 
            this.cPuntiDiff.Text = "Diff.";
            this.cPuntiDiff.Width = 40;
            // 
            // cBonus
            // 
            this.cBonus.Text = "Bonus";
            this.cBonus.Width = 40;
            // 
            // cPunti
            // 
            this.cPunti.Text = "Punti";
            this.cPunti.Width = 40;
            // 
            // numStagione
            // 
            this.numStagione.Location = new System.Drawing.Point(61, 9);
            this.numStagione.Name = "numStagione";
            this.numStagione.Size = new System.Drawing.Size(49, 20);
            this.numStagione.TabIndex = 4;
            this.numStagione.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.numStagione.ValueChanged += new System.EventHandler(this.numStagione_ValueChanged);
            // 
            // TabClassifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabClassifica";
            this.Size = new System.Drawing.Size(640, 480);
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStagione)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listClassifica;
        private System.Windows.Forms.ColumnHeader cPosizione;
        private System.Windows.Forms.ColumnHeader cClub;
        private System.Windows.Forms.ColumnHeader cPunti;
        private System.Windows.Forms.ColumnHeader cGiocate;
        private System.Windows.Forms.ColumnHeader cVinte;
        private System.Windows.Forms.ColumnHeader cPareggiate;
        private System.Windows.Forms.ColumnHeader cPerse;
        private System.Windows.Forms.ColumnHeader cPuntiFatti;
        private System.Windows.Forms.ColumnHeader cPuntiSubiti;
        private System.Windows.Forms.ColumnHeader cPuntiDiff;
        private System.Windows.Forms.ColumnHeader cBonus;
        private System.Windows.Forms.Button buttonAggiorna;
        private System.Windows.Forms.NumericUpDown numStagione;
    }
}
