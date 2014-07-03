using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Tab
{
    public partial class TabDebug : UserControl
    {
        public TabDebug()
        {
            InitializeComponent();
        }

        public TabPage GetTab()
        {
            return this.pageMain;
        }

        public string HTML
        {
            get { return textLog.Text; }
            set { textLog.Text = (string)value; }
        }

        public string Headers
        {
            get { return textHeaders.Text; }
            set { textHeaders.Text = (string)value; }
        }
    }
}
