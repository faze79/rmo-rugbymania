namespace RMO.Tab
{
    partial class TabEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabEvents));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textSerch = new System.Windows.Forms.TextBox();
            this.listEvents = new System.Windows.Forms.ListView();
            this.cData = new System.Windows.Forms.ColumnHeader();
            this.cTipo = new System.Windows.Forms.ColumnHeader();
            this.cPlayer = new System.Windows.Forms.ColumnHeader();
            this.cDettagli = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.dateA = new System.Windows.Forms.DateTimePicker();
            this.dateDa = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pageMain.Controls.Add(this.pictureBox1);
            this.pageMain.Controls.Add(this.textSerch);
            this.pageMain.Controls.Add(this.listEvents);
            this.pageMain.Controls.Add(this.label2);
            this.pageMain.Controls.Add(this.dateA);
            this.pageMain.Controls.Add(this.dateDa);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(632, 454);
            this.pageMain.TabIndex = 0;
            this.pageMain.Tag = "eventi";
            this.pageMain.Text = "Gestione Eventi";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(505, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textSerch
            // 
            this.textSerch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSerch.Location = new System.Drawing.Point(526, 7);
            this.textSerch.Name = "textSerch";
            this.textSerch.Size = new System.Drawing.Size(100, 20);
            this.textSerch.TabIndex = 11;
            this.textSerch.TextChanged += new System.EventHandler(this.textSerch_TextChanged);
            // 
            // listEvents
            // 
            this.listEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cData,
            this.cTipo,
            this.cPlayer,
            this.cDettagli});
            this.listEvents.FullRowSelect = true;
            this.listEvents.Location = new System.Drawing.Point(3, 32);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(623, 419);
            this.listEvents.TabIndex = 4;
            this.listEvents.UseCompatibleStateImageBehavior = false;
            this.listEvents.View = System.Windows.Forms.View.Details;
            this.listEvents.Resize += new System.EventHandler(this.listEvents_Resize);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A:";
            // 
            // dateA
            // 
            this.dateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateA.Location = new System.Drawing.Point(158, 6);
            this.dateA.Name = "dateA";
            this.dateA.Size = new System.Drawing.Size(86, 20);
            this.dateA.TabIndex = 2;
            this.dateA.ValueChanged += new System.EventHandler(this.dateA_ValueChanged);
            // 
            // dateDa
            // 
            this.dateDa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDa.Location = new System.Drawing.Point(36, 6);
            this.dateDa.Name = "dateDa";
            this.dateDa.Size = new System.Drawing.Size(86, 20);
            this.dateDa.TabIndex = 1;
            this.dateDa.ValueChanged += new System.EventHandler(this.dateDa_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Da:";
            // 
            // TabEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabEvents";
            this.Size = new System.Drawing.Size(640, 480);
            this.tabControl1.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.ListView listEvents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateA;
        private System.Windows.Forms.DateTimePicker dateDa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader cData;
        private System.Windows.Forms.ColumnHeader cTipo;
        private System.Windows.Forms.ColumnHeader cPlayer;
        private System.Windows.Forms.ColumnHeader cDettagli;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textSerch;
    }
}
