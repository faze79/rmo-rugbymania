//#define COMPILING

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace My
{
    public class Translate
    {
        private string DL = "app";
        private string FROM = "app";

        private string Language = "english";
        private System.Data.DataSet ds = null;
        private string dictionary = null;

        public Translate(string language, string from)
        {
            if (FROM!="") FROM = from;
            Language = language;
            dictionary = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "language.xml";
            if (!System.IO.File.Exists(dictionary)) CreateLanguageFile(dictionary);
            ds = new System.Data.DataSet();
            ds.ReadXml(dictionary);
            if (!ds.Tables[0].Columns.Contains(language))
                ds.Tables[0].Columns.Add(language);
        }

        private void CreateLanguageFile(string file)
        {
            XmlTextWriter xw = null;
            try
            {
                xw = new XmlTextWriter(file, System.Text.Encoding.UTF8);
                xw.Formatting = System.Xml.Formatting.Indented;
                xw.Indentation = 4;
                xw.WriteStartDocument(true);
                xw.WriteStartElement("language");
                xw.WriteStartElement("item");
                xw.WriteAttributeString(DL, "");
                if(Language!=DL) xw.WriteAttributeString(Language, "");
                xw.WriteEndElement();
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Flush(); xw.Close();
            }
            catch (System.Exception ex)
            { MessageBox.Show(ex.Message + "\n\n My::Xml::NewFile()"); }
        }

        public void Traduci(object f)
        {
            if (Language == FROM) return;
            TranslateMe(f);
        }

        public void Traduci(Form form)
        {
            if (Language == FROM) return;
            TranslateMe((Form)form);
            return;
        }

        public string Traduci(string message)
        {
            if (Language == FROM) return message;
            return TranslateMe(message);
        }

        private void TranslateMe(object item)
        {
            try
            {
                Type t = item.GetType();
                switch (t.ToString())
                {
                    case "System.Windows.Forms.ComboBox":
                        TranslateMe((System.Windows.Forms.ComboBox)item);
                        break;
                    case "System.Windows.Forms.Form":
                        TranslateMe((System.Windows.Forms.Form)item);
                        break;
                    case "System.Windows.Forms.MainMenu":
                        TranslateMe((System.Windows.Forms.MainMenu)item);
                        break;
                    case "System.Windows.Forms.MenuItem":
                        TranslateMe((System.Windows.Forms.MenuItem)item);
                        break;
                    case "System.Windows.Forms.MenuStrip":
                        TranslateMe((System.Windows.Forms.MenuStrip)item);
                        break;
                    case "System.Windows.Forms.ToolStrip":
                        TranslateMe((System.Windows.Forms.ToolStrip)item);
                        break;
                    case "System.Windows.Forms.ToolStripButton":
                        TranslateMe((System.Windows.Forms.ToolStripButton)item);
                        break;
                    case "System.Windows.Forms.ToolStripLabel":
                        TranslateMe((System.Windows.Forms.ToolStripLabel)item);
                        break;
                    case "System.Windows.Forms.ToolStripTextBox":
                        TranslateMe((System.Windows.Forms.ToolStripTextBox)item);
                        break;
                    case "System.Windows.Forms.ToolStripSeparator": break;
                    case "System.Windows.Forms.ToolStripMenuItem":
                        TranslateMe((System.Windows.Forms.ToolStripMenuItem)item);
                        break;
                    case "System.Windows.Forms.CheckedListBox":
                        TranslateMe((System.Windows.Forms.CheckedListBox)item);
                        break;
                    case "System.Windows.Forms.ListView":
                        TranslateMe((System.Windows.Forms.ListView)item);
                        break;
                        /*
                    case "SteepValley.Windows.Forms.XPCaptionPane":
                        TranslateMe((SteepValley.Windows.Forms.XPCaptionPane)item);
                        break;
                    case "SteepValley.Windows.Forms.ThemedControls.XPTaskBox":
                        TranslateMe((SteepValley.Windows.Forms.ThemedControls.XPTaskBox)item);
                        break;
                    case "SteepValley.Windows.Forms.ThemedControls.XPTaskBoxSpecial":
                        TranslateMe((SteepValley.Windows.Forms.ThemedControls.XPTaskBoxSpecial)item);
                        break;
                    case "SteepValley.Windows.Forms.XPLoginEntry":
                        TranslateMe((SteepValley.Windows.Forms.XPLoginEntry)item);
                        break;
                    case "VTWindow.Controls.TabPage":
                        TranslateMe((VTWindow.Controls.TabPage)item);
                        break;
                         */
                    default:
                        try { TranslateMe((System.Windows.Forms.Control)item); }
                        catch { }
                        //{ MessageBox.Show(t.ToString()); }
                        break;
                }
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private bool IsOmitted(object c)
        {
            try
            {
                string s = (string)c;
                if (s != null)
                {
                    if (s.IndexOf("notranslate") != -1) return true;
                }
            }
            catch {  }
            return false;
        }

        private bool IsAllOmitted(object c)
        {
            try
            {
                string s = (string)c;
                if (s != null)
                {
                    if (s.IndexOf("NOTRANSLATE") != -1) return true;
                }
            }
            catch { }
            return false;
        }

        /*
        private void TranslateMe(SteepValley.Windows.Forms.XPCaptionPane item)
        {
            try
            {
                item.CaptionText = TranslateMe(item.CaptionText);
                foreach (Control c in item.Controls) TranslateMe((object)c);
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private void TranslateMe(SteepValley.Windows.Forms.XPLoginEntry item)
        {
            try
            {
                item.HelpString = TranslateMe(item.HelpString);
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private void TranslateMe(VTWindow.Controls.TabPage tpage)
        {
            try
            {
                tpage.Title = TranslateMe(tpage.Title);
                foreach (Control c in tpage.Controls) TranslateMe((object)c);
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private void TranslateMe(SteepValley.Windows.Forms.ThemedControls.XPTaskBox item)
        {
            item.HeaderText = TranslateMe(item.HeaderText);
            foreach (Control c in item.Controls) TranslateMe((object)c);
        }

        private void TranslateMe(SteepValley.Windows.Forms.ThemedControls.XPTaskBoxSpecial item)
        {
            item.HeaderText = TranslateMe(item.HeaderText);
            foreach (Control c in item.Controls) TranslateMe((object)c);
        }
         */

        private void TranslateMe(System.Windows.Forms.Form form)
        {
            if (!IsOmitted(form.Tag)) form.Text = TranslateMe(form.Text);
            if (!IsAllOmitted(form.Tag))
            {
                foreach (Control c in form.Controls) TranslateMe((object)c);
            }
        }

        private void TranslateMe(System.Windows.Forms.MenuStrip menus)
        {
            try
            {
                if (!IsOmitted(menus.Tag)) menus.Text = TranslateMe(menus.Text);
                if (!IsAllOmitted(menus.Tag)) foreach (System.Windows.Forms.ToolStripItem c in menus.Items) TranslateMe((object)c);
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private void TranslateMe(System.Windows.Forms.ToolStrip tstrip)
        {
            try
            {
                //tstrip.Text = TranslateMe(tstrip.Text);
                foreach (ToolStripItem c in tstrip.Items) TranslateMe(c);
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private void TranslateMe(System.Windows.Forms.ToolStripButton tsbutton)
        {
            tsbutton.Text = TranslateMe(tsbutton.Text);
        }

        private void TranslateMe(System.Windows.Forms.ToolStripLabel tslabel)
        {
            if (!IsOmitted(tslabel.Tag)) tslabel.Text = TranslateMe(tslabel.Text);
        }

        private void TranslateMe(System.Windows.Forms.ToolStripTextBox tstext)
        {
            tstext.Text = TranslateMe(tstext.Text);
        }

        private void TranslateMe(System.Windows.Forms.ToolStripMenuItem menui)
        {
            try
            {
                if (!IsOmitted(menui.Tag)) menui.Text = TranslateMe(menui.Text);
                if (!IsAllOmitted(menui.Tag)) foreach (System.Windows.Forms.ToolStripItem c in menui.DropDownItems) TranslateMe((object)c);
            }
            catch (Exception ex) { My.Box.Errore(ex.Message); }
        }

        private void TranslateMe(System.Windows.Forms.ComboBox cbox)
        {
            if (IsOmitted(cbox.Tag)) return;
            cbox.Text = TranslateMe(cbox.Text);
            object[] items = new object[cbox.Items.Count];
            for (int i = 0; i < cbox.Items.Count; i++) 
            {
                if (cbox.Items[i].GetType() == typeof(string))
                {
                    string textold = (string)cbox.Items[i];
                    items[i] = TranslateMe(textold);
                }
            }
            cbox.Items.Clear();
            cbox.Items.AddRange(items);
        }

        private void TranslateMe(System.Windows.Forms.CheckedListBox clbox)
        {
            clbox.Text = TranslateMe(clbox.Text);
            for (int i = 0; i < clbox.Items.Count; i++)
            {
                if (clbox.Items[i].GetType() == typeof(string))
                {
                    string textold = (string)clbox.Items[i];
                    clbox.Items.RemoveAt(i);
                    string textnew = TranslateMe(textold);
                    clbox.Items.Insert(i, textnew);
                }
            }
        }

        private void TranslateMe(System.Windows.Forms.ListView list)
        {
            foreach (System.Windows.Forms.ColumnHeader column in list.Columns)
            {
                column.Text = TranslateMe(column.Text);
            }
        }

        private void TranslateMe(System.Windows.Forms.MainMenu mmenu)
        {
            foreach (MenuItem c in mmenu.MenuItems) TranslateMe((object)c);
        }

        private void TranslateMe(System.Windows.Forms.MenuItem mitem)
        {
            mitem.Text = TranslateMe(mitem.Text);
            foreach (MenuItem c in mitem.MenuItems) TranslateMe((object)c);
        }

        private void TranslateMe(System.Windows.Forms.Control control)
        {
            if (!IsOmitted(control.Tag)) control.Text = TranslateMe(control.Text);
            if (!IsAllOmitted(control.Tag)) foreach (Control c in control.Controls) TranslateMe((object)c);
        }

        private string TranslateMe(string text)
        {
            //return text;    // DISABILITAZIONE
            if (text == "") return text;
            text = text.Replace("\r\n", "|");
            DataRow[] drs = Search(FROM+"='"+text.Replace("'","''")+"'");
            if (drs.Length > 0)
            {
                try 
                {
                    string temp = "";
                    try { temp = drs[0][Language].ToString(); }
                    catch { temp = ""; }
                    if (temp.Length > 0)
                    {
                        temp = temp.Replace("|", "\r\n");
                        return temp;
                    }
#if(COMPILING)
                    else
                    {
                        Traduci dialog = new Traduci(text);
                        dialog.ShowDialog();
                        AddString(DL,text,Language, dialog.Traduzione);
                        text = dialog.Traduzione;
                        dialog.Dispose();
                    }
#endif
                }
                catch { }
            }
            else AddString(DL, text);
            text = text.Replace("|", "\r\n");
            return text;
        }

        private DataRow[] Search(string expression)
        {
            DataTable dt = ds.Tables[0];
            DataRow[] drs = dt.Select(expression);
            return drs;
        }

        private void AddString(string language, string text)
        {
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[language] = text;
            dt.Rows.Add(dr);
            System.Xml.XmlTextWriter xw = new XmlTextWriter(dictionary, Encoding.UTF8);
            xw.Formatting = System.Xml.Formatting.Indented;
            xw.Indentation = 4;
            xw.WriteStartDocument(true);
            dt.WriteXml(xw); xw.Flush(); xw.Close();
        }

        private void AddString(string language1, string text1, string language2, string text2)
        {
            DataTable dt = ds.Tables[0];
            DataRow[] drs = Search(language1+"='" + text1 + "'");
            if (drs.Length > 0) drs[0][language2] = text2;
            else
            {
                DataRow dr = dt.NewRow();
                dr[language1] = text1;
                dr[language2] = text2;
                dt.Rows.Add(dr);
            }
            System.Xml.XmlTextWriter xw = new XmlTextWriter(dictionary, Encoding.UTF8);
            xw.Formatting = System.Xml.Formatting.Indented;
            xw.Indentation = 4;
            xw.WriteStartDocument(true);
            dt.WriteXml(xw); xw.Flush(); xw.Close();
        }
    }

    public partial class Traduci : Form
    {
        public Traduci(string text)
        {
            InitializeComponent();
            this.label1.Text = text;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public string Traduzione
        {
            get
            {
                return this.textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    partial class Traduci
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected new void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Traduzione di un testo da tradurre in una qualche lingua";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Traduci
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 80);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Traduci";
            this.Text = "Traduci";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}