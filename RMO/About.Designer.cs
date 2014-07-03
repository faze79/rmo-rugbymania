namespace RMO
{
    partial class About
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lInfo = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.link2 = new System.Windows.Forms.LinkLabel();
            this.link1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lInfo
            // 
            this.lInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lInfo.Location = new System.Drawing.Point(12, 9);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(370, 173);
            this.lInfo.TabIndex = 0;
            this.lInfo.Text = "label1";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(307, 223);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // link2
            // 
            this.link2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.link2.Location = new System.Drawing.Point(12, 206);
            this.link2.Name = "link2";
            this.link2.Size = new System.Drawing.Size(370, 14);
            this.link2.TabIndex = 2;
            this.link2.TabStop = true;
            this.link2.Text = "http://rugbymaniaitalia.forumfree.net";
            this.link2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2_LinkClicked);
            // 
            // link1
            // 
            this.link1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.link1.Location = new System.Drawing.Point(12, 182);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(370, 14);
            this.link1.TabIndex = 3;
            this.link1.TabStop = true;
            this.link1.Text = "http://www.rugbymania.net";
            this.link1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "faze79";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 258);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.link1);
            this.Controls.Add(this.link2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.lInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.LinkLabel link2;
        private System.Windows.Forms.LinkLabel link1;
        private System.Windows.Forms.Label label1;
    }
}