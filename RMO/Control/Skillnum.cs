using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMO.Control
{
    public partial class Skillnum : UserControl
    {
        public Skillnum()
        {
            InitializeComponent();
            LoadImages();
        }

        private Bitmap[] Images = null;

        private void LoadImages()
        {
            Images = new Bitmap[4];
            Images[0] = new Bitmap(typeof(MainForm), "SkillNum.0.png");
            Images[1] = new Bitmap(typeof(MainForm), "SkillNum.1.png");
            Images[2] = new Bitmap(typeof(MainForm), "SkillNum.2.png");
            Images[3] = new Bitmap(typeof(MainForm), "SkillNum.3.png");
            p1.Image = p2.Image = p3.Image = p4.Image = p5.Image = p6.Image = Images[0];
        }

        private int _Value = 0;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = (int)value;
                DisplayNum();
            }
        }

        private void DisplayNum()
        {
            switch (_Value)
            {
                default:
                case 0: p1.Image = p2.Image = p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 1: p1.Image = Images[1]; p2.Image = p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 2: p1.Image = Images[2]; p2.Image = p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 3: p1.Image = Images[3]; p2.Image = p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 4: p1.Image = Images[3]; p2.Image = Images[1]; p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 5: p1.Image = Images[3]; p2.Image = Images[2]; p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 6: p1.Image = p2.Image = Images[3]; p3.Image = p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 7: p1.Image = p2.Image = Images[3]; p3.Image = Images[1]; p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 8: p1.Image = p2.Image = Images[3]; p3.Image = Images[2]; p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 9: p1.Image = p2.Image = p3.Image = Images[3];  p4.Image = p5.Image = p6.Image = Images[0]; break;
                case 10: p1.Image = p2.Image = p3.Image = Images[3]; p4.Image = Images[1]; p5.Image = p6.Image = Images[0]; break;
                case 11: p1.Image = p2.Image = p3.Image = Images[3]; p4.Image = Images[2]; p5.Image = p6.Image = Images[0]; break;
                case 12: p1.Image = p2.Image = p3.Image = p4.Image = Images[3]; p5.Image = p6.Image = Images[0]; break;
                case 13: p1.Image = p2.Image = p3.Image = p4.Image = Images[3]; p5.Image = Images[1]; p6.Image = Images[0]; break;
                case 14: p1.Image = p2.Image = p3.Image = p4.Image = Images[3]; p5.Image = Images[2]; p6.Image = Images[0]; break;
                case 15: p1.Image = p2.Image = p3.Image = p4.Image = p5.Image = Images[3]; p6.Image = Images[0]; break;
                case 16: p1.Image = p2.Image = p3.Image = p4.Image = p5.Image = Images[3]; p6.Image = Images[1]; break;
                case 17: p1.Image = p2.Image = p3.Image = p4.Image = p5.Image = Images[3]; p6.Image = Images[2]; break;
                case 18: p1.Image = p2.Image = p3.Image = p4.Image = p5.Image = p6.Image = Images[3]; break;
            }
            pN.Text = _Value.ToString();
        }

    }
}
