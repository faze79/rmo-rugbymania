using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RMO
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Text = Application.ProductName + " - About";
            lInfo.Text = Application.ProductName + " è un semplice programma che aiuta a tenere sotto controllo la propria squadra di RugbyMania.net!\r\n"+
                "Se desiderate ottenere maggiori informazioni, per segnalare problemi o proporre richieste venite sul forum italiano ufficiale di RugbyMania.";
            lInfo.Text += "\r\nBuild: " + Internal.VERSION.ToString() + " 32bit";
            lInfo.Text += "\r\n\r\nSi ringrazia il forum esterno italiano di rugbymania per il supporto morale, tecnologico e inventivo.";
            lInfo.Text += " In ordine sparso:lollone, courgil, mist-r, dany4, Batmancagone, rivel, magicopd, Bongo, scanavacca, 61Thingol, philip_roth, Fresty, LucasimoDJ, rhodigian, rossazzurro80, Shoulin, locicero, narcolino.";
            lInfo.Text += "\r\n\r\nThanks to Hiliadan DuVoile for French translation.";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            My.Shell.Execute(link1.Text);
        }

        private void link2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            My.Shell.Execute(link2.Text);
        }
    }
}