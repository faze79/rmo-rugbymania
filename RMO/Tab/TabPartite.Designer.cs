namespace RMO.Tab
{
    partial class TabPartite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabPartite));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.buttonAggiorna = new System.Windows.Forms.Button();
            this.listPartite = new System.Windows.Forms.ListView();
            this.cTurno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTeam1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTeam2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPunti1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPunti2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
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
            this.pageMain.Controls.Add(this.listPartite);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(632, 454);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "NOTRANSLATE partite";
            this.pageMain.Text = "Le Partite";
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
            this.buttonAggiorna.TabIndex = 6;
            this.buttonAggiorna.Text = "Aggiorna";
            this.buttonAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAggiorna.UseVisualStyleBackColor = true;
            this.buttonAggiorna.Click += new System.EventHandler(this.buttonAggiorna_Click);
            // 
            // listPartite
            // 
            this.listPartite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPartite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cTurno,
            this.cData,
            this.cTeam1,
            this.cTeam2,
            this.cPunti1,
            this.cPunti2});
            this.listPartite.FullRowSelect = true;
            this.listPartite.HideSelection = false;
            this.listPartite.Location = new System.Drawing.Point(6, 33);
            this.listPartite.Name = "listPartite";
            this.listPartite.Size = new System.Drawing.Size(620, 415);
            this.listPartite.TabIndex = 5;
            this.listPartite.UseCompatibleStateImageBehavior = false;
            this.listPartite.View = System.Windows.Forms.View.Details;
            this.listPartite.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listPartite_ColumnClick);
            // 
            // cTurno
            // 
            this.cTurno.Text = "Turno";
            // 
            // cData
            // 
            this.cData.Text = "Data";
            this.cData.Width = 120;
            // 
            // cTeam1
            // 
            this.cTeam1.Text = "Squadra in casa";
            this.cTeam1.Width = 150;
            // 
            // cTeam2
            // 
            this.cTeam2.Text = "Squadra fuori casa";
            this.cTeam2.Width = 150;
            // 
            // cPunti1
            // 
            this.cPunti1.Text = "P.C.";
            this.cPunti1.Width = 40;
            // 
            // cPunti2
            // 
            this.cPunti2.Text = "P.F.";
            this.cPunti2.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Stagione:";
            // 
            // numStagione
            // 
            this.numStagione.Location = new System.Drawing.Point(61, 9);
            this.numStagione.Name = "numStagione";
            this.numStagione.Size = new System.Drawing.Size(49, 20);
            this.numStagione.TabIndex = 7;
            this.numStagione.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.numStagione.ValueChanged += new System.EventHandler(this.numStagione_ValueChanged);
            // 
            // TabPartite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabPartite";
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
        private System.Windows.Forms.ListView listPartite;
        private System.Windows.Forms.ColumnHeader cTurno;
        private System.Windows.Forms.ColumnHeader cData;
        private System.Windows.Forms.ColumnHeader cTeam1;
        private System.Windows.Forms.ColumnHeader cTeam2;
        private System.Windows.Forms.ColumnHeader cPunti1;
        private System.Windows.Forms.ColumnHeader cPunti2;
        private System.Windows.Forms.Button buttonAggiorna;
        private System.Windows.Forms.NumericUpDown numStagione;
    }
}
