namespace My
{
    public class Button
    {
        public string Directory = "";

        public System.Windows.Forms.PictureBox Control = null;

        public string Nome = "";
        public enum State { ON, OFF };

        private System.Drawing.Image OFF = null;
        private System.Drawing.Image OFF_HOVER = null;
        private System.Drawing.Image ON = null;
        private System.Drawing.Image ON_HOVER = null;
        private System.Drawing.Image DISABLED = null;

        public static void SetButton(System.Windows.Forms.PictureBox p, string nome, string dir, bool auto_off)
        {
            My.Button tmp = new Button(p, nome, dir, auto_off);
            tmp.AutoOFF = auto_off;
            p.Tag = tmp;
        }

        public static void Enable(System.Windows.Forms.PictureBox p, bool val)
        {
            My.Button c = (My.Button)p.Tag;
            if (c != null) c.Enabled = val;
        }

        public static void SetON(System.Windows.Forms.PictureBox p, bool val)
        {
            My.Button c = (My.Button)p.Tag;
            if (c != null)
            {
                if (val == false) c.Stato = State.OFF;
                else c.Stato = State.ON;
            }
        }

        public Button(System.Windows.Forms.PictureBox p, string nome, string dir, bool autooff)
        {
            Control = p;
            Directory = dir;
            Nome = nome;
            LoadImages();
            Control.Image = OFF;
            Control.MouseEnter += new System.EventHandler(p_MouseEnter);
            Control.MouseLeave += new System.EventHandler(p_MouseLeave);
            Control.MouseDown += new System.Windows.Forms.MouseEventHandler(Control_MouseDown);
            Control.MouseUp += new System.Windows.Forms.MouseEventHandler(Control_MouseUp);
        }

        public void Dispose()
        {
            if (DISABLED != null) { DISABLED.Dispose(); DISABLED = null; }
            if (OFF != null) { OFF.Dispose(); OFF = null; }
            if (OFF_HOVER != null) { OFF_HOVER.Dispose(); OFF_HOVER = null; }
            if (ON != null) { ON.Dispose(); ON = null; }
            if (ON_HOVER != null) { ON_HOVER.Dispose(); ON_HOVER = null; }
        }

        private bool _IsHover = false;
        public bool IsHover
        {
            get { return _IsHover; }
            set
            {
                bool val = (bool)value;
                if (val != _IsHover)
                {
                    _IsHover = val;
                    Refresh();
                }
            }
        }

        private bool _Enabled = true;
        public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                bool val = (bool)value;
                if (val != _Enabled)
                {
                    _Enabled = val;
                    Refresh();
                }
            }
        }

        private State _Stato = State.OFF;
        public State Stato
        {
            get { return _Stato; }
            set
            {
                State val = (State)value;
                if (val != _Stato)
                {
                    _Stato = val;
                    Refresh();
                }
            }
        }

        private void p_MouseLeave(object sender, System.EventArgs e)
        {
            IsHover = false;
        }

        private void p_MouseEnter(object sender, System.EventArgs e)
        {
            IsHover = true;
        }

        private void Control_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Stato = State.ON;
        }

        private bool AutoOFF = true;
        private void Control_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (AutoOFF) Stato = State.OFF;
        }

        private void LoadImages()
        {
            if (!System.IO.Directory.Exists(Directory)) return;
            OFF = LoadImage(Directory + Nome + "_off.png");
            OFF_HOVER = LoadImage(Directory + Nome + "_off_hover.png");
            ON = LoadImage(Directory + Nome + "_on.png");
            ON_HOVER = LoadImage(Directory + Nome + "_on_hover.png");
            DISABLED = LoadImage(Directory + Nome + "_disabled.png");
        }

        private System.Drawing.Image LoadImage(string file)
        {
            if (System.IO.File.Exists(file))
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(file);
                System.Drawing.Bitmap result = (System.Drawing.Bitmap)bmp.Clone();
                bmp.Dispose(); bmp = null;
                return result;
            }
            return null;
        }

        public void Refresh()
        {
            if (!Enabled) Control.Image = DISABLED;
            else
            {
                if (Stato == State.OFF)
                {
                    if (IsHover) Control.Image = OFF_HOVER;
                    else Control.Image = OFF;
                }
                else
                {
                    if (IsHover) Control.Image = ON_HOVER;
                    else Control.Image = ON;
                }
            }
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}