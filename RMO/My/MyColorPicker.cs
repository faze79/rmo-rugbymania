using System;
using System.Drawing;
using System.Windows.Forms;

namespace My.Controls
{
    public class ctrl2DColorBox : System.Windows.Forms.UserControl
    {
        #region Class Variables

        public enum eDrawStyle
        {
            Hue,
            Saturation,
            Brightness,
            Red,
            Green,
            Blue
        }

        private int m_iMarker_X = 0;
        private int m_iMarker_Y = 0;
        private bool m_bDragging = false;

        //	These variables keep track of how to fill in the content inside the box;
        private eDrawStyle m_eDrawStyle = eDrawStyle.Hue;
        private MyColors.HSL m_hsl;
        private System.Drawing.Color m_rgb;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors / Destructors

        public ctrl2DColorBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //	Initialize Colors
            m_hsl = new MyColors.HSL();
            m_hsl.H = 1.0;
            m_hsl.S = 1.0;
            m_hsl.L = 1.0;
            m_rgb = MyColors.HSL_to_RGB(m_hsl);
            m_eDrawStyle = eDrawStyle.Hue;
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #endregion

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ctrl2DColorBox
            // 
            this.Name = "ctrl2DColorBox";
            this.Size = new System.Drawing.Size(260, 260);
            this.Resize += new System.EventHandler(this.ctrl2DColorBox_Resize);
            this.Load += new System.EventHandler(this.ctrl2DColorBox_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctrl2DColorBox_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrl2DColorBox_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrl2DColorBox_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrl2DColorBox_MouseDown);

        }
        #endregion

        #region Control Events

        private void ctrl2DColorBox_Load(object sender, System.EventArgs e)
        {
            Redraw_Control();
        }


        private void ctrl2DColorBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)	//	Only respond to left mouse button events
                return;

            m_bDragging = true;		//	Begin dragging which notifies MouseMove function that it needs to update the marker

            int x = e.X - 2, y = e.Y - 2;
            if (x < 0) x = 0;
            if (x > this.Width - 4) x = this.Width - 4;	//	Calculate marker position
            if (y < 0) y = 0;
            if (y > this.Height - 4) y = this.Height - 4;

            if (x == m_iMarker_X && y == m_iMarker_Y)		//	If the marker hasn't moved, no need to redraw it.
                return;										//	or send a scroll notification

            DrawMarker(x, y, true);	//	Redraw the marker
            ResetHSLRGB();			//	Reset the color

            if (Scroll != null)	//	Notify anyone who cares that the controls marker (selected color) has changed
                Scroll(this, e);
        }


        private void ctrl2DColorBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!m_bDragging)		//	Only respond when the mouse is dragging the marker.
                return;

            int x = e.X - 2, y = e.Y - 2;
            if (x < 0) x = 0;
            if (x > this.Width - 4) x = this.Width - 4;	//	Calculate marker position
            if (y < 0) y = 0;
            if (y > this.Height - 4) y = this.Height - 4;

            if (x == m_iMarker_X && y == m_iMarker_Y)		//	If the marker hasn't moved, no need to redraw it.
                return;										//	or send a scroll notification

            DrawMarker(x, y, true);	//	Redraw the marker
            ResetHSLRGB();			//	Reset the color

            if (Scroll != null)	//	Notify anyone who cares that the controls marker (selected color) has changed
                Scroll(this, e);
        }


        private void ctrl2DColorBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)	//	Only respond to left mouse button events
                return;

            if (!m_bDragging)
                return;

            m_bDragging = false;

            int x = e.X - 2, y = e.Y - 2;
            if (x < 0) x = 0;
            if (x > this.Width - 4) x = this.Width - 4;	//	Calculate marker position
            if (y < 0) y = 0;
            if (y > this.Height - 4) y = this.Height - 4;

            if (x == m_iMarker_X && y == m_iMarker_Y)		//	If the marker hasn't moved, no need to redraw it.
                return;										//	or send a scroll notification

            DrawMarker(x, y, true);	//	Redraw the marker
            ResetHSLRGB();			//	Reset the color

            if (Scroll != null)	//	Notify anyone who cares that the controls marker (selected color) has changed
                Scroll(this, e);
        }


        private void ctrl2DColorBox_Resize(object sender, System.EventArgs e)
        {
            Redraw_Control();
        }


        private void ctrl2DColorBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Redraw_Control();
        }


        #endregion

        #region Events

        public new event EventHandler Scroll;

        #endregion

        #region Public Methods

        /// <summary>
        /// The drawstyle of the contol (Hue, Saturation, Brightness, Red, Green or Blue)
        /// </summary>
        public eDrawStyle DrawStyle
        {
            get
            {
                return m_eDrawStyle;
            }
            set
            {
                m_eDrawStyle = value;

                //	Redraw the control based on the new eDrawStyle
                Reset_Marker(true);
                Redraw_Control();
            }
        }


        /// <summary>
        /// The HSL color of the control, changing the HSL will automatically change the RGB color for the control.
        /// </summary>
        public MyColors.HSL HSL
        {
            get
            {
                return m_hsl;
            }
            set
            {
                m_hsl = value;
                m_rgb = MyColors.HSL_to_RGB(m_hsl);

                //	Redraw the control based on the new color.
                Reset_Marker(true);
                Redraw_Control();
            }
        }


        /// <summary>
        /// The RGB color of the control, changing the RGB will automatically change the HSL color for the control.
        /// </summary>
        public System.Drawing.Color RGB
        {
            get
            {
                return m_rgb;
            }
            set
            {
                m_rgb = value;
                m_hsl = MyColors.RGB_to_HSL(m_rgb);

                //	Redraw the control based on the new color.
                Reset_Marker(true);
                Redraw_Control();
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Redraws only the content over the marker
        /// </summary>
        private void ClearMarker()
        {
            Graphics g = this.CreateGraphics();

            //	Determine the area that needs to be redrawn
            int start_x, start_y, end_x, end_y;
            int red = 0; int green = 0; int blue = 0;
            MyColors.HSL hsl_start = new MyColors.HSL();
            MyColors.HSL hsl_end = new MyColors.HSL();

            //	Find the markers corners
            start_x = m_iMarker_X - 5;
            start_y = m_iMarker_Y - 5;
            end_x = m_iMarker_X + 5;
            end_y = m_iMarker_Y + 5;
            //	Adjust the area if part of it hangs outside the content area
            if (start_x < 0) start_x = 0;
            if (start_y < 0) start_y = 0;
            if (end_x > this.Width - 4) end_x = this.Width - 4;
            if (end_y > this.Height - 4) end_y = this.Height - 4;

            //	Redraw the content based on the current draw style:
            //	The code get's a little messy from here
            switch (m_eDrawStyle)
            {
                //		  S=0,S=1,S=2,S=3.....S=100
                //	L=100
                //	L=99
                //	L=98		Drawstyle
                //	L=97		   Hue
                //	...
                //	L=0
                case eDrawStyle.Hue:

                    hsl_start.H = m_hsl.H; hsl_end.H = m_hsl.H;	//	Hue is constant
                    hsl_start.S = (double)start_x / (this.Width - 4);	//	Because we're drawing horizontal lines, s will not change
                    hsl_end.S = (double)end_x / (this.Width - 4);		//	from line to line

                    for (int i = start_y; i <= end_y; i++)		//	For each horizontal line:
                    {
                        hsl_start.L = 1.0 - (double)i / (this.Height - 4);	//	Brightness (L) WILL change for each horizontal
                        hsl_end.L = hsl_start.L;							//	line drawn

                        System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(start_x + 1, i + 2, end_x - start_x + 1, 1), MyColors.HSL_to_RGB(hsl_start), MyColors.HSL_to_RGB(hsl_end), 0, false);
                        g.FillRectangle(br, new Rectangle(start_x + 2, i + 2, end_x - start_x + 1, 1));
                    }

                    break;
                //		  H=0,H=1,H=2,H=3.....H=360
                //	L=100
                //	L=99
                //	L=98		Drawstyle
                //	L=97		Saturation
                //	...
                //	L=0
                case eDrawStyle.Saturation:

                    hsl_start.S = m_hsl.S; hsl_end.S = m_hsl.S;			//	Saturation is constant
                    hsl_start.L = 1.0 - (double)start_y / (this.Height - 4);	//	Because we're drawing vertical lines, L will 
                    hsl_end.L = 1.0 - (double)end_y / (this.Height - 4);		//	not change from line to line

                    for (int i = start_x; i <= end_x; i++)				//	For each vertical line:
                    {
                        hsl_start.H = (double)i / (this.Width - 4);			//	Hue (H) WILL change for each vertical
                        hsl_end.H = hsl_start.H;							//	line drawn

                        System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(i + 2, start_y + 1, 1, end_y - start_y + 2), MyColors.HSL_to_RGB(hsl_start), MyColors.HSL_to_RGB(hsl_end), 90, false);
                        g.FillRectangle(br, new Rectangle(i + 2, start_y + 2, 1, end_y - start_y + 1));
                    }
                    break;
                //		  H=0,H=1,H=2,H=3.....H=360
                //	S=100
                //	S=99
                //	S=98		Drawstyle
                //	S=97		Brightness
                //	...
                //	S=0
                case eDrawStyle.Brightness:

                    hsl_start.L = m_hsl.L; hsl_end.L = m_hsl.L;			//	Luminance is constant
                    hsl_start.S = 1.0 - (double)start_y / (this.Height - 4);	//	Because we're drawing vertical lines, S will 
                    hsl_end.S = 1.0 - (double)end_y / (this.Height - 4);		//	not change from line to line

                    for (int i = start_x; i <= end_x; i++)				//	For each vertical line:
                    {
                        hsl_start.H = (double)i / (this.Width - 4);			//	Hue (H) WILL change for each vertical
                        hsl_end.H = hsl_start.H;							//	line drawn

                        System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(i + 2, start_y + 1, 1, end_y - start_y + 2), MyColors.HSL_to_RGB(hsl_start), MyColors.HSL_to_RGB(hsl_end), 90, false);
                        g.FillRectangle(br, new Rectangle(i + 2, start_y + 2, 1, end_y - start_y + 1));
                    }

                    break;
                //		  B=0,B=1,B=2,B=3.....B=100
                //	G=100
                //	G=99
                //	G=98		Drawstyle
                //	G=97		   Red
                //	...
                //	G=0
                case eDrawStyle.Red:

                    red = m_rgb.R;													//	Red is constant
                    int start_b = Round(255 * (double)start_x / (this.Width - 4));	//	Because we're drawing horizontal lines, B
                    int end_b = Round(255 * (double)end_x / (this.Width - 4));		//	will not change from line to line

                    for (int i = start_y; i <= end_y; i++)						//	For each horizontal line:
                    {
                        green = Round(255 - (255 * (double)i / (this.Height - 4)));	//	green WILL change for each horizontal line drawn

                        System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(start_x + 1, i + 2, end_x - start_x + 1, 1), System.Drawing.Color.FromArgb(red, green, start_b), System.Drawing.Color.FromArgb(red, green, end_b), 0, false);
                        g.FillRectangle(br, new Rectangle(start_x + 2, i + 2, end_x - start_x + 1, 1));
                    }

                    break;
                //		  B=0,B=1,B=2,B=3.....B=100
                //	R=100
                //	R=99
                //	R=98		Drawstyle
                //	R=97		  Green
                //	...
                //	R=0
                case eDrawStyle.Green:

                    green = m_rgb.G; ;												//	Green is constant
                    int start_b2 = Round(255 * (double)start_x / (this.Width - 4));	//	Because we're drawing horizontal lines, B
                    int end_b2 = Round(255 * (double)end_x / (this.Width - 4));		//	will not change from line to line

                    for (int i = start_y; i <= end_y; i++)						//	For each horizontal line:
                    {
                        red = Round(255 - (255 * (double)i / (this.Height - 4)));		//	red WILL change for each horizontal line drawn

                        System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                            new Rectangle(start_x + 1, i + 2, end_x - start_x + 1, 1), 
                            System.Drawing.Color.FromArgb(red, green, start_b2), 
                            System.Drawing.Color.FromArgb(red, green, end_b2), 0, false);
                        g.FillRectangle(br, new Rectangle(start_x + 2, i + 2, end_x - start_x + 1, 1));
                    }

                    break;
                //		  R=0,R=1,R=2,R=3.....R=100
                //	G=100
                //	G=99
                //	G=98		Drawstyle
                //	G=97		   Blue
                //	...
                //	G=0
                case eDrawStyle.Blue:

                    blue = m_rgb.B; ;												//	Blue is constant
                    int start_r = Round(255 * (double)start_x / (this.Width - 4));	//	Because we're drawing horizontal lines, R
                    int end_r = Round(255 * (double)end_x / (this.Width - 4));		//	will not change from line to line

                    for (int i = start_y; i <= end_y; i++)						//	For each horizontal line:
                    {
                        green = Round(255 - (255 * (double)i / (this.Height - 4)));	//	green WILL change for each horizontal line drawn

                        System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                            new Rectangle(start_x + 1, i + 2, end_x - start_x + 1, 1), 
                            System.Drawing.Color.FromArgb(start_r, green, blue), 
                            System.Drawing.Color.FromArgb(end_r, green, blue), 0, false);
                        g.FillRectangle(br, new Rectangle(start_x + 2, i + 2, end_x - start_x + 1, 1));
                    }

                    break;
            }
        }


        /// <summary>
        /// Draws the marker (circle) inside the box
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Unconditional"></param>
        private void DrawMarker(int x, int y, bool Unconditional)			//	   *****
        {																	//	  *  |  *
            if (x < 0) x = 0;												//	 *   |   *
            if (x > this.Width - 4) x = this.Width - 4;					//	*    |    *
            if (y < 0) y = 0;												//	*    |    *
            if (y > this.Height - 4) y = this.Height - 4;					//	*----X----*
            //	*    |    *
            if (m_iMarker_Y == y && m_iMarker_X == x && !Unconditional)	//	*    |    *
                return;														//	 *   |   *
            //	  *  |  *
            ClearMarker();													//	   *****

            m_iMarker_X = x;
            m_iMarker_Y = y;

            Graphics g = this.CreateGraphics();

            Pen pen;
            MyColors.HSL _hsl = GetColor(x, y);	//	The selected color determines the color of the marker drawn over
            //	it (black or white)
            if (_hsl.L < (double)200 / 255)
                pen = new Pen(System.Drawing.Color.White);									//	White marker if selected color is dark
            else if (_hsl.H < (double)26 / 360 || _hsl.H > (double)200 / 360)
                if (_hsl.S > (double)70 / 255)
                    pen = new Pen(System.Drawing.Color.White);
                else
                    pen = new Pen(System.Drawing.Color.Black);								//	Else use a black marker for lighter colors
            else
                pen = new Pen(System.Drawing.Color.Black);

            g.DrawEllipse(pen, x - 3, y - 3, 10, 10);						//	Draw the marker : 11 x 11 circle

            DrawBorder();		//	Force the border to be redrawn, just in case the marker has been drawn over it.
        }


        /// <summary>
        /// Draws the border around the control.
        /// </summary>
        private void DrawBorder()
        {
            Graphics g = this.CreateGraphics();

            Pen pencil;

            //	To make the control look like Adobe Photoshop's the border around the control will be a gray line
            //	on the top and left side, a white line on the bottom and right side, and a black rectangle (line) 
            //	inside the gray/white rectangle

            pencil = new Pen(System.Drawing.Color.FromArgb(172, 168, 153));	//	The same gray color used by Photoshop
            g.DrawLine(pencil, this.Width - 2, 0, 0, 0);	//	Draw top line
            g.DrawLine(pencil, 0, 0, 0, this.Height - 2);	//	Draw left hand line

            pencil = new Pen(System.Drawing.Color.White);
            g.DrawLine(pencil, this.Width - 1, 0, this.Width - 1, this.Height - 1);	//	Draw right hand line
            g.DrawLine(pencil, this.Width - 1, this.Height - 1, 0, this.Height - 1);	//	Draw bottome line

            pencil = new Pen(System.Drawing.Color.Black);
            g.DrawRectangle(pencil, 1, 1, this.Width - 3, this.Height - 3);	//	Draw inner black rectangle
        }


        /// <summary>
        /// Evaluates the DrawStyle of the control and calls the appropriate
        /// drawing function for content
        /// </summary>
        private void DrawContent()
        {
            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    Draw_Style_Hue();
                    break;
                case eDrawStyle.Saturation:
                    Draw_Style_Saturation();
                    break;
                case eDrawStyle.Brightness:
                    Draw_Style_Luminance();
                    break;
                case eDrawStyle.Red:
                    Draw_Style_Red();
                    break;
                case eDrawStyle.Green:
                    Draw_Style_Green();
                    break;
                case eDrawStyle.Blue:
                    Draw_Style_Blue();
                    break;
            }
        }


        /// <summary>
        /// Draws the content of the control filling in all color values with the provided Hue value.
        /// </summary>
        private void Draw_Style_Hue()
        {
            Graphics g = this.CreateGraphics();

            MyColors.HSL hsl_start = new MyColors.HSL();
            MyColors.HSL hsl_end = new MyColors.HSL();
            hsl_start.H = m_hsl.H;
            hsl_end.H = m_hsl.H;
            hsl_start.S = 0.0;
            hsl_end.S = 1.0;

            for (int i = 0; i < this.Height - 4; i++)				//	For each horizontal line in the control:
            {
                hsl_start.L = 1.0 - (double)i / (this.Height - 4);	//	Calculate luminance at this line (Hue and Saturation are constant)
                hsl_end.L = hsl_start.L;

                System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(2, 2, this.Width - 4, 1), MyColors.HSL_to_RGB(hsl_start), MyColors.HSL_to_RGB(hsl_end), 0, false);
                g.FillRectangle(br, new Rectangle(2, i + 2, this.Width - 4, 1));
            }
        }


        /// <summary>
        /// Draws the content of the control filling in all color values with the provided Saturation value.
        /// </summary>
        private void Draw_Style_Saturation()
        {
            Graphics g = this.CreateGraphics();

            MyColors.HSL hsl_start = new MyColors.HSL();
            MyColors.HSL hsl_end = new MyColors.HSL();
            hsl_start.S = m_hsl.S;
            hsl_end.S = m_hsl.S;
            hsl_start.L = 1.0;
            hsl_end.L = 0.0;

            for (int i = 0; i < this.Width - 4; i++)		//	For each vertical line in the control:
            {
                hsl_start.H = (double)i / (this.Width - 4);	//	Calculate Hue at this line (Saturation and Luminance are constant)
                hsl_end.H = hsl_start.H;

                System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(2, 2, 1, this.Height - 4), MyColors.HSL_to_RGB(hsl_start), MyColors.HSL_to_RGB(hsl_end), 90, false);
                g.FillRectangle(br, new Rectangle(i + 2, 2, 1, this.Height - 4));
            }
        }


        /// <summary>
        /// Draws the content of the control filling in all color values with the provided Luminance or Brightness value.
        /// </summary>
        private void Draw_Style_Luminance()
        {
            Graphics g = this.CreateGraphics();

            MyColors.HSL hsl_start = new MyColors.HSL();
            MyColors.HSL hsl_end = new MyColors.HSL();
            hsl_start.L = m_hsl.L;
            hsl_end.L = m_hsl.L;
            hsl_start.S = 1.0;
            hsl_end.S = 0.0;

            for (int i = 0; i < this.Width - 4; i++)		//	For each vertical line in the control:
            {
                hsl_start.H = (double)i / (this.Width - 4);	//	Calculate Hue at this line (Saturation and Luminance are constant)
                hsl_end.H = hsl_start.H;

                System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(2, 2, 1, this.Height - 4), MyColors.HSL_to_RGB(hsl_start), MyColors.HSL_to_RGB(hsl_end), 90, false);
                g.FillRectangle(br, new Rectangle(i + 2, 2, 1, this.Height - 4));
            }
        }


        /// <summary>
        /// Draws the content of the control filling in all color values with the provided Red value.
        /// </summary>
        private void Draw_Style_Red()
        {
            Graphics g = this.CreateGraphics();

            int red = m_rgb.R; ;

            for (int i = 0; i < this.Height - 4; i++)				//	For each horizontal line in the control:
            {
                //	Calculate Green at this line (Red and Blue are constant)
                int green = Round(255 - (255 * (double)i / (this.Height - 4)));

                System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(2, 2, this.Width - 4, 1), 
                    System.Drawing.Color.FromArgb(red, green, 0), 
                    System.Drawing.Color.FromArgb(red, green, 255), 0, false);
                g.FillRectangle(br, new Rectangle(2, i + 2, this.Width - 4, 1));
            }
        }


        /// <summary>
        /// Draws the content of the control filling in all color values with the provided Green value.
        /// </summary>
        private void Draw_Style_Green()
        {
            Graphics g = this.CreateGraphics();

            int green = m_rgb.G; ;

            for (int i = 0; i < this.Height - 4; i++)	//	For each horizontal line in the control:
            {
                //	Calculate Red at this line (Green and Blue are constant)
                int red = Round(255 - (255 * (double)i / (this.Height - 4)));

                System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(2, 2, this.Width - 4, 1), 
                    System.Drawing.Color.FromArgb(red, green, 0), 
                    System.Drawing.Color.FromArgb(red, green, 255), 0, false);
                g.FillRectangle(br, new Rectangle(2, i + 2, this.Width - 4, 1));
            }
        }


        /// <summary>
        /// Draws the content of the control filling in all color values with the provided Blue value.
        /// </summary>
        private void Draw_Style_Blue()
        {
            Graphics g = this.CreateGraphics();

            int blue = m_rgb.B; ;

            for (int i = 0; i < this.Height - 4; i++)	//	For each horizontal line in the control:
            {
                //	Calculate Green at this line (Red and Blue are constant)
                int green = Round(255 - (255 * (double)i / (this.Height - 4)));

                System.Drawing.Drawing2D.LinearGradientBrush br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(2, 2, this.Width - 4, 1),
                    System.Drawing.Color.FromArgb(0, green, blue),
                    System.Drawing.Color.FromArgb(255, green, blue), 0, false);
                g.FillRectangle(br, new Rectangle(2, i + 2, this.Width - 4, 1));
            }
        }


        /// <summary>
        /// Calls all the functions neccessary to redraw the entire control.
        /// </summary>
        private void Redraw_Control()
        {
            DrawBorder();

            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    Draw_Style_Hue();
                    break;
                case eDrawStyle.Saturation:
                    Draw_Style_Saturation();
                    break;
                case eDrawStyle.Brightness:
                    Draw_Style_Luminance();
                    break;
                case eDrawStyle.Red:
                    Draw_Style_Red();
                    break;
                case eDrawStyle.Green:
                    Draw_Style_Green();
                    break;
                case eDrawStyle.Blue:
                    Draw_Style_Blue();
                    break;
            }

            DrawMarker(m_iMarker_X, m_iMarker_Y, true);
        }


        /// <summary>
        /// Resets the marker position of the slider to match the controls color.  Gives the option of redrawing the slider.
        /// </summary>
        /// <param name="Redraw">Set to true if you want the function to redraw the slider after determining the best position</param>
        private void Reset_Marker(bool Redraw)
        {
            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    m_iMarker_X = Round((this.Width - 4) * m_hsl.S);
                    m_iMarker_Y = Round((this.Height - 4) * (1.0 - m_hsl.L));
                    break;
                case eDrawStyle.Saturation:
                    m_iMarker_X = Round((this.Width - 4) * m_hsl.H);
                    m_iMarker_Y = Round((this.Height - 4) * (1.0 - m_hsl.L));
                    break;
                case eDrawStyle.Brightness:
                    m_iMarker_X = Round((this.Width - 4) * m_hsl.H);
                    m_iMarker_Y = Round((this.Height - 4) * (1.0 - m_hsl.S));
                    break;
                case eDrawStyle.Red:
                    m_iMarker_X = Round((this.Width - 4) * (double)m_rgb.B / 255);
                    m_iMarker_Y = Round((this.Height - 4) * (1.0 - (double)m_rgb.G / 255));
                    break;
                case eDrawStyle.Green:
                    m_iMarker_X = Round((this.Width - 4) * (double)m_rgb.B / 255);
                    m_iMarker_Y = Round((this.Height - 4) * (1.0 - (double)m_rgb.R / 255));
                    break;
                case eDrawStyle.Blue:
                    m_iMarker_X = Round((this.Width - 4) * (double)m_rgb.R / 255);
                    m_iMarker_Y = Round((this.Height - 4) * (1.0 - (double)m_rgb.G / 255));
                    break;
            }

            if (Redraw)
                DrawMarker(m_iMarker_X, m_iMarker_Y, true);
        }


        /// <summary>
        /// Resets the controls color (both HSL and RGB variables) based on the current marker position
        /// </summary>
        private void ResetHSLRGB()
        {
            int red, green, blue;

            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    m_hsl.S = (double)m_iMarker_X / (this.Width - 4);
                    m_hsl.L = 1.0 - (double)m_iMarker_Y / (this.Height - 4);
                    m_rgb = MyColors.HSL_to_RGB(m_hsl);
                    break;
                case eDrawStyle.Saturation:
                    m_hsl.H = (double)m_iMarker_X / (this.Width - 4);
                    m_hsl.L = 1.0 - (double)m_iMarker_Y / (this.Height - 4);
                    m_rgb = MyColors.HSL_to_RGB(m_hsl);
                    break;
                case eDrawStyle.Brightness:
                    m_hsl.H = (double)m_iMarker_X / (this.Width - 4);
                    m_hsl.S = 1.0 - (double)m_iMarker_Y / (this.Height - 4);
                    m_rgb = MyColors.HSL_to_RGB(m_hsl);
                    break;
                case eDrawStyle.Red:
                    blue = Round(255 * (double)m_iMarker_X / (this.Width - 4));
                    green = Round(255 * (1.0 - (double)m_iMarker_Y / (this.Height - 4)));
                    m_rgb = System.Drawing.Color.FromArgb(m_rgb.R, green, blue);
                    m_hsl = MyColors.RGB_to_HSL(m_rgb);
                    break;
                case eDrawStyle.Green:
                    blue = Round(255 * (double)m_iMarker_X / (this.Width - 4));
                    red = Round(255 * (1.0 - (double)m_iMarker_Y / (this.Height - 4)));
                    m_rgb = System.Drawing.Color.FromArgb(red, m_rgb.G, blue);
                    m_hsl = MyColors.RGB_to_HSL(m_rgb);
                    break;
                case eDrawStyle.Blue:
                    red = Round(255 * (double)m_iMarker_X / (this.Width - 4));
                    green = Round(255 * (1.0 - (double)m_iMarker_Y / (this.Height - 4)));
                    m_rgb = System.Drawing.Color.FromArgb(red, green, m_rgb.B);
                    m_hsl = MyColors.RGB_to_HSL(m_rgb);
                    break;
            }
        }


        /// <summary>
        /// Kindof self explanitory, I really need to look up the .NET function that does this.
        /// </summary>
        /// <param name="val">double value to be rounded to an integer</param>
        /// <returns></returns>
        private int Round(double val)
        {
            int ret_val = (int)val;

            int temp = (int)(val * 100);

            if ((temp % 100) >= 50)
                ret_val += 1;

            return ret_val;

        }


        /// <summary>
        /// Returns the graphed color at the x,y position on the control
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private MyColors.HSL GetColor(int x, int y)
        {

            MyColors.HSL _hsl = new MyColors.HSL();

            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    _hsl.H = m_hsl.H;
                    _hsl.S = (double)x / (this.Width - 4);
                    _hsl.L = 1.0 - (double)y / (this.Height - 4);
                    break;
                case eDrawStyle.Saturation:
                    _hsl.S = m_hsl.S;
                    _hsl.H = (double)x / (this.Width - 4);
                    _hsl.L = 1.0 - (double)y / (this.Height - 4);
                    break;
                case eDrawStyle.Brightness:
                    _hsl.L = m_hsl.L;
                    _hsl.H = (double)x / (this.Width - 4);
                    _hsl.S = 1.0 - (double)y / (this.Height - 4);
                    break;
                case eDrawStyle.Red:
                    _hsl = MyColors.RGB_to_HSL(System.Drawing.Color.FromArgb(m_rgb.R, Round(255 * (1.0 - (double)y / (this.Height - 4))), Round(255 * (double)x / (this.Width - 4))));
                    break;
                case eDrawStyle.Green:
                    _hsl = MyColors.RGB_to_HSL(System.Drawing.Color.FromArgb(Round(255 * (1.0 - (double)y / (this.Height - 4))), m_rgb.G, Round(255 * (double)x / (this.Width - 4))));
                    break;
                case eDrawStyle.Blue:
                    _hsl = MyColors.RGB_to_HSL(System.Drawing.Color.FromArgb(Round(255 * (double)x / (this.Width - 4)), Round(255 * (1.0 - (double)y / (this.Height - 4))), m_rgb.B));
                    break;
            }

            return _hsl;
        }


        #endregion
    }
    public class ctrlVerticalColorSlider : System.Windows.Forms.UserControl
    {
        #region Class Variables

        public enum eDrawStyle
        {
            Hue,
            Saturation,
            Brightness,
            Red,
            Green,
            Blue
        }


        //	Slider properties
        private int m_iMarker_Start_Y = 0;
        private bool m_bDragging = false;

        //	These variables keep track of how to fill in the content inside the box;
        private eDrawStyle m_eDrawStyle = eDrawStyle.Hue;
        private MyColors.HSL m_hsl;
        private System.Drawing.Color m_rgb;

        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors / Destructors

        public ctrlVerticalColorSlider()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //	Initialize Colors
            m_hsl = new MyColors.HSL();
            m_hsl.H = 1.0;
            m_hsl.S = 1.0;
            m_hsl.L = 1.0;
            m_rgb = MyColors.HSL_to_RGB(m_hsl);
            m_eDrawStyle = eDrawStyle.Hue;
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #endregion

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ctrl1DColorBar
            // 
            this.Name = "ctrl1DColorBar";
            this.Size = new System.Drawing.Size(40, 264);
            this.Resize += new System.EventHandler(this.ctrl1DColorBar_Resize);
            this.Load += new System.EventHandler(this.ctrl1DColorBar_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctrl1DColorBar_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrl1DColorBar_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrl1DColorBar_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrl1DColorBar_MouseDown);

        }
        #endregion

        #region Control Events

        private void ctrl1DColorBar_Load(object sender, System.EventArgs e)
        {
            Redraw_Control();
        }


        private void ctrl1DColorBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)	//	Only respond to left mouse button events
                return;

            m_bDragging = true;		//	Begin dragging which notifies MouseMove function that it needs to update the marker

            int y;
            y = e.Y;
            y -= 4;											//	Calculate slider position
            if (y < 0) y = 0;
            if (y > this.Height - 9) y = this.Height - 9;

            if (y == m_iMarker_Start_Y)					//	If the slider hasn't moved, no need to redraw it.
                return;										//	or send a scroll notification

            DrawSlider(y, false);	//	Redraw the slider
            ResetHSLRGB();			//	Reset the color

            if (Scroll != null)	//	Notify anyone who cares that the controls slider(color) has changed
                Scroll(this, e);
        }


        private void ctrl1DColorBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!m_bDragging)		//	Only respond when the mouse is dragging the marker.
                return;

            int y;
            y = e.Y;
            y -= 4; 										//	Calculate slider position
            if (y < 0) y = 0;
            if (y > this.Height - 9) y = this.Height - 9;

            if (y == m_iMarker_Start_Y)					//	If the slider hasn't moved, no need to redraw it.
                return;										//	or send a scroll notification

            DrawSlider(y, false);	//	Redraw the slider
            ResetHSLRGB();			//	Reset the color

            if (Scroll != null)	//	Notify anyone who cares that the controls slider(color) has changed
                Scroll(this, e);
        }


        private void ctrl1DColorBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)	//	Only respond to left mouse button events
                return;

            m_bDragging = false;

            int y;
            y = e.Y;
            y -= 4; 										//	Calculate slider position
            if (y < 0) y = 0;
            if (y > this.Height - 9) y = this.Height - 9;

            if (y == m_iMarker_Start_Y)					//	If the slider hasn't moved, no need to redraw it.
                return;										//	or send a scroll notification

            DrawSlider(y, false);	//	Redraw the slider
            ResetHSLRGB();			//	Reset the color

            if (Scroll != null)	//	Notify anyone who cares that the controls slider(color) has changed
                Scroll(this, e);
        }


        private void ctrl1DColorBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Redraw_Control();
        }


        private void ctrl1DColorBar_Resize(object sender, System.EventArgs e)
        {
            Redraw_Control();
        }


        #endregion

        #region Events

        public new event EventHandler Scroll;

        #endregion

        #region Public Methods

        /// <summary>
        /// The drawstyle of the contol (Hue, Saturation, Brightness, Red, Green or Blue)
        /// </summary>
        public eDrawStyle DrawStyle
        {
            get
            {
                return m_eDrawStyle;
            }
            set
            {
                m_eDrawStyle = value;

                //	Redraw the control based on the new eDrawStyle
                Reset_Slider(true);
                Redraw_Control();
            }
        }


        /// <summary>
        /// The HSL color of the control, changing the HSL will automatically change the RGB color for the control.
        /// </summary>
        public MyColors.HSL HSL
        {
            get
            {
                return m_hsl;
            }
            set
            {
                m_hsl = value;
                m_rgb = MyColors.HSL_to_RGB(m_hsl);

                //	Redraw the control based on the new color.
                Reset_Slider(true);
                DrawContent();
            }
        }


        /// <summary>
        /// The RGB color of the control, changing the RGB will automatically change the HSL color for the control.
        /// </summary>
        public System.Drawing.Color RGB
        {
            get
            {
                return m_rgb;
            }
            set
            {
                m_rgb = value;
                m_hsl = MyColors.RGB_to_HSL(m_rgb);

                //	Redraw the control based on the new color.
                Reset_Slider(true);
                DrawContent();
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Redraws the background over the slider area on both sides of the control
        /// </summary>
        private void ClearSlider()
        {
            Graphics g = this.CreateGraphics();
            Brush brush = System.Drawing.SystemBrushes.Control;
            g.FillRectangle(brush, 0, 0, 8, this.Height);				//	clear left hand slider
            g.FillRectangle(brush, this.Width - 8, 0, 8, this.Height);	//	clear right hand slider
        }


        /// <summary>
        /// Draws the slider arrows on both sides of the control.
        /// </summary>
        /// <param name="position">position value of the slider, lowest being at the bottom.  The range
        /// is between 0 and the controls height-9.  The values will be adjusted if too large/small</param>
        /// <param name="Unconditional">If Unconditional is true, the slider is drawn, otherwise some logic 
        /// is performed to determine is drawing is really neccessary.</param>
        private void DrawSlider(int position, bool Unconditional)
        {
            if (position < 0) position = 0;
            if (position > this.Height - 9) position = this.Height - 9;

            if (m_iMarker_Start_Y == position && !Unconditional)	//	If the marker position hasn't changed
                return;												//	since the last time it was drawn and we don't HAVE to redraw
            //	then exit procedure

            m_iMarker_Start_Y = position;	//	Update the controls marker position

            this.ClearSlider();		//	Remove old slider

            Graphics g = this.CreateGraphics();

            Pen pencil = new Pen(System.Drawing.Color.FromArgb(116, 114, 106));	//	Same gray color Photoshop uses
            Brush brush = Brushes.White;

            Point[] arrow = new Point[7];				//	 GGG
            arrow[0] = new Point(1, position);			//	G   G
            arrow[1] = new Point(3, position);			//	G    G
            arrow[2] = new Point(7, position + 4);		//	G     G
            arrow[3] = new Point(3, position + 8);		//	G      G
            arrow[4] = new Point(1, position + 8);		//	G     G
            arrow[5] = new Point(0, position + 7);		//	G    G
            arrow[6] = new Point(0, position + 1);		//	G   G
            //	 GGG

            g.FillPolygon(brush, arrow);	//	Fill left arrow with white
            g.DrawPolygon(pencil, arrow);	//	Draw left arrow border with gray

            //	    GGG
            arrow[0] = new Point(this.Width - 2, position);		//	   G   G
            arrow[1] = new Point(this.Width - 4, position);		//	  G    G
            arrow[2] = new Point(this.Width - 8, position + 4);	//	 G     G
            arrow[3] = new Point(this.Width - 4, position + 8);	//	G      G
            arrow[4] = new Point(this.Width - 2, position + 8);	//	 G     G
            arrow[5] = new Point(this.Width - 1, position + 7);	//	  G    G
            arrow[6] = new Point(this.Width - 1, position + 1);	//	   G   G
            //	    GGG

            g.FillPolygon(brush, arrow);	//	Fill right arrow with white
            g.DrawPolygon(pencil, arrow);	//	Draw right arrow border with gray

        }


        /// <summary>
        /// Draws the border around the control, in this case the border around the content area between
        /// the slider arrows.
        /// </summary>
        private void DrawBorder()
        {
            Graphics g = this.CreateGraphics();

            Pen pencil;

            //	To make the control look like Adobe Photoshop's the border around the control will be a gray line
            //	on the top and left side, a white line on the bottom and right side, and a black rectangle (line) 
            //	inside the gray/white rectangle

            pencil = new Pen(System.Drawing.Color.FromArgb(172, 168, 153));	//	The same gray color used by Photoshop
            g.DrawLine(pencil, this.Width - 10, 2, 9, 2);	//	Draw top line
            g.DrawLine(pencil, 9, 2, 9, this.Height - 4);	//	Draw left hand line

            pencil = new Pen(System.Drawing.Color.White);
            g.DrawLine(pencil, this.Width - 9, 2, this.Width - 9, this.Height - 3);	//	Draw right hand line
            g.DrawLine(pencil, this.Width - 9, this.Height - 3, 9, this.Height - 3);	//	Draw bottome line

            pencil = new Pen(System.Drawing.Color.Black);
            g.DrawRectangle(pencil, 10, 3, this.Width - 20, this.Height - 7);	//	Draw inner black rectangle
        }


        /// <summary>
        /// Evaluates the DrawStyle of the control and calls the appropriate
        /// drawing function for content
        /// </summary>
        private void DrawContent()
        {
            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    Draw_Style_Hue();
                    break;
                case eDrawStyle.Saturation:
                    Draw_Style_Saturation();
                    break;
                case eDrawStyle.Brightness:
                    Draw_Style_Luminance();
                    break;
                case eDrawStyle.Red:
                    Draw_Style_Red();
                    break;
                case eDrawStyle.Green:
                    Draw_Style_Green();
                    break;
                case eDrawStyle.Blue:
                    Draw_Style_Blue();
                    break;
            }
        }


        #region Draw_Style_X - Content drawing functions

        //	The following functions do the real work of the control, drawing the primary content (the area between the slider)
        //	

        /// <summary>
        /// Fills in the content of the control showing all values of Hue (from 0 to 360)
        /// </summary>
        private void Draw_Style_Hue()
        {
            Graphics g = this.CreateGraphics();

            MyColors.HSL _hsl = new MyColors.HSL();
            _hsl.S = 1.0;	//	S and L will both be at 100% for this DrawStyle
            _hsl.L = 1.0;

            for (int i = 0; i < this.Height - 8; i++)	//	i represents the current line of pixels we want to draw horizontally
            {
                _hsl.H = 1.0 - (double)i / (this.Height - 8);			//	H (hue) is based on the current vertical position
                Pen pen = new Pen(MyColors.HSL_to_RGB(_hsl));	//	Get the Color for this line

                g.DrawLine(pen, 11, i + 4, this.Width - 11, i + 4);	//	Draw the line and loop back for next line
            }
        }


        /// <summary>
        /// Fills in the content of the control showing all values of Saturation (0 to 100%) for the given
        /// Hue and Luminance.
        /// </summary>
        private void Draw_Style_Saturation()
        {
            Graphics g = this.CreateGraphics();

            MyColors.HSL _hsl = new MyColors.HSL();
            _hsl.H = m_hsl.H;	//	Use the H and L values of the current color (m_hsl)
            _hsl.L = m_hsl.L;

            for (int i = 0; i < this.Height - 8; i++) //	i represents the current line of pixels we want to draw horizontally
            {
                _hsl.S = 1.0 - (double)i / (this.Height - 8);			//	S (Saturation) is based on the current vertical position
                Pen pen = new Pen(MyColors.HSL_to_RGB(_hsl));	//	Get the Color for this line

                g.DrawLine(pen, 11, i + 4, this.Width - 11, i + 4);	//	Draw the line and loop back for next line
            }
        }


        /// <summary>
        /// Fills in the content of the control showing all values of Luminance (0 to 100%) for the given
        /// Hue and Saturation.
        /// </summary>
        private void Draw_Style_Luminance()
        {
            Graphics g = this.CreateGraphics();

            MyColors.HSL _hsl = new MyColors.HSL();
            _hsl.H = m_hsl.H;	//	Use the H and S values of the current color (m_hsl)
            _hsl.S = m_hsl.S;

            for (int i = 0; i < this.Height - 8; i++) //	i represents the current line of pixels we want to draw horizontally
            {
                _hsl.L = 1.0 - (double)i / (this.Height - 8);			//	L (Luminance) is based on the current vertical position
                Pen pen = new Pen(MyColors.HSL_to_RGB(_hsl));	//	Get the Color for this line

                g.DrawLine(pen, 11, i + 4, this.Width - 11, i + 4);	//	Draw the line and loop back for next line
            }
        }


        /// <summary>
        /// Fills in the content of the control showing all values of Red (0 to 255) for the given
        /// Green and Blue.
        /// </summary>
        private void Draw_Style_Red()
        {
            Graphics g = this.CreateGraphics();

            for (int i = 0; i < this.Height - 8; i++) //	i represents the current line of pixels we want to draw horizontally
            {
                int red = 255 - Round(255 * (double)i / (this.Height - 8));	//	red is based on the current vertical position
                Pen pen = new Pen(System.Drawing.Color.FromArgb(red, m_rgb.G, m_rgb.B));	//	Get the Color for this line

                g.DrawLine(pen, 11, i + 4, this.Width - 11, i + 4);			//	Draw the line and loop back for next line
            }
        }


        /// <summary>
        /// Fills in the content of the control showing all values of Green (0 to 255) for the given
        /// Red and Blue.
        /// </summary>
        private void Draw_Style_Green()
        {
            Graphics g = this.CreateGraphics();

            for (int i = 0; i < this.Height - 8; i++) //	i represents the current line of pixels we want to draw horizontally
            {
                int green = 255 - Round(255 * (double)i / (this.Height - 8));	//	green is based on the current vertical position
                Pen pen = new Pen(System.Drawing.Color.FromArgb(m_rgb.R, green, m_rgb.B));	//	Get the Color for this line

                g.DrawLine(pen, 11, i + 4, this.Width - 11, i + 4);			//	Draw the line and loop back for next line
            }
        }


        /// <summary>
        /// Fills in the content of the control showing all values of Blue (0 to 255) for the given
        /// Red and Green.
        /// </summary>
        private void Draw_Style_Blue()
        {
            Graphics g = this.CreateGraphics();

            for (int i = 0; i < this.Height - 8; i++) //	i represents the current line of pixels we want to draw horizontally
            {
                int blue = 255 - Round(255 * (double)i / (this.Height - 8));	//	green is based on the current vertical position
                Pen pen = new Pen(Color.FromArgb(m_rgb.R, m_rgb.G, blue));	//	Get the Color for this line

                g.DrawLine(pen, 11, i + 4, this.Width - 11, i + 4);			//	Draw the line and loop back for next line
            }
        }


        #endregion

        /// <summary>
        /// Calls all the functions neccessary to redraw the entire control.
        /// </summary>
        private void Redraw_Control()
        {
            DrawSlider(m_iMarker_Start_Y, true);
            DrawBorder();
            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    Draw_Style_Hue();
                    break;
                case eDrawStyle.Saturation:
                    Draw_Style_Saturation();
                    break;
                case eDrawStyle.Brightness:
                    Draw_Style_Luminance();
                    break;
                case eDrawStyle.Red:
                    Draw_Style_Red();
                    break;
                case eDrawStyle.Green:
                    Draw_Style_Green();
                    break;
                case eDrawStyle.Blue:
                    Draw_Style_Blue();
                    break;
            }
        }


        /// <summary>
        /// Resets the vertical position of the slider to match the controls color.  Gives the option of redrawing the slider.
        /// </summary>
        /// <param name="Redraw">Set to true if you want the function to redraw the slider after determining the best position</param>
        private void Reset_Slider(bool Redraw)
        {
            //	The position of the marker (slider) changes based on the current drawstyle:
            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    m_iMarker_Start_Y = (this.Height - 8) - Round((this.Height - 8) * m_hsl.H);
                    break;
                case eDrawStyle.Saturation:
                    m_iMarker_Start_Y = (this.Height - 8) - Round((this.Height - 8) * m_hsl.S);
                    break;
                case eDrawStyle.Brightness:
                    m_iMarker_Start_Y = (this.Height - 8) - Round((this.Height - 8) * m_hsl.L);
                    break;
                case eDrawStyle.Red:
                    m_iMarker_Start_Y = (this.Height - 8) - Round((this.Height - 8) * (double)m_rgb.R / 255);
                    break;
                case eDrawStyle.Green:
                    m_iMarker_Start_Y = (this.Height - 8) - Round((this.Height - 8) * (double)m_rgb.G / 255);
                    break;
                case eDrawStyle.Blue:
                    m_iMarker_Start_Y = (this.Height - 8) - Round((this.Height - 8) * (double)m_rgb.B / 255);
                    break;
            }

            if (Redraw)
                DrawSlider(m_iMarker_Start_Y, true);
        }


        /// <summary>
        /// Resets the controls color (both HSL and RGB variables) based on the current slider position
        /// </summary>
        private void ResetHSLRGB()
        {
            switch (m_eDrawStyle)
            {
                case eDrawStyle.Hue:
                    m_hsl.H = 1.0 - (double)m_iMarker_Start_Y / (this.Height - 9);
                    m_rgb = MyColors.HSL_to_RGB(m_hsl);
                    break;
                case eDrawStyle.Saturation:
                    m_hsl.S = 1.0 - (double)m_iMarker_Start_Y / (this.Height - 9);
                    m_rgb = MyColors.HSL_to_RGB(m_hsl);
                    break;
                case eDrawStyle.Brightness:
                    m_hsl.L = 1.0 - (double)m_iMarker_Start_Y / (this.Height - 9);
                    m_rgb = MyColors.HSL_to_RGB(m_hsl);
                    break;
                case eDrawStyle.Red:
                    m_rgb = Color.FromArgb(255 - Round(255 * (double)m_iMarker_Start_Y / (this.Height - 9)), m_rgb.G, m_rgb.B);
                    m_hsl = MyColors.RGB_to_HSL(m_rgb);
                    break;
                case eDrawStyle.Green:
                    m_rgb = Color.FromArgb(m_rgb.R, 255 - Round(255 * (double)m_iMarker_Start_Y / (this.Height - 9)), m_rgb.B);
                    m_hsl = MyColors.RGB_to_HSL(m_rgb);
                    break;
                case eDrawStyle.Blue:
                    m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, 255 - Round(255 * (double)m_iMarker_Start_Y / (this.Height - 9)));
                    m_hsl = MyColors.RGB_to_HSL(m_rgb);
                    break;
            }
        }


        /// <summary>
        /// Kindof self explanitory, I really need to look up the .NET function that does this.
        /// </summary>
        /// <param name="val">double value to be rounded to an integer</param>
        /// <returns></returns>
        private int Round(double val)
        {
            int ret_val = (int)val;

            int temp = (int)(val * 100);

            if ((temp % 100) >= 50)
                ret_val += 1;

            return ret_val;

        }


        #endregion
    }
    public class MyColors
    {
        #region Constructors / Destructors

        public MyColors()
        {
        }


        #endregion

        #region Public Methods

        /// <summary> 
        /// Sets the absolute brightness of a colour 
        /// </summary> 
        /// <param name="c">Original colour</param> 
        /// <param name="brightness">The luminance level to impose</param> 
        /// <returns>an adjusted colour</returns> 
        public static Color SetBrightness(Color c, double brightness)
        {
            HSL hsl = RGB_to_HSL(c);
            hsl.L = brightness;
            return HSL_to_RGB(hsl);
        }


        /// <summary> 
        /// Modifies an existing brightness level 
        /// </summary> 
        /// <remarks> 
        /// To reduce brightness use a number smaller than 1. To increase brightness use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="brightness">The luminance delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifyBrightness(Color c, double brightness)
        {
            HSL hsl = RGB_to_HSL(c);
            hsl.L *= brightness;
            return HSL_to_RGB(hsl);
        }


        /// <summary> 
        /// Sets the absolute saturation level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Saturation">The saturation value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetSaturation(Color c, double Saturation)
        {
            HSL hsl = RGB_to_HSL(c);
            hsl.S = Saturation;
            return HSL_to_RGB(hsl);
        }


        /// <summary> 
        /// Modifies an existing Saturation level 
        /// </summary> 
        /// <remarks> 
        /// To reduce Saturation use a number smaller than 1. To increase Saturation use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="Saturation">The saturation delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifySaturation(Color c, double Saturation)
        {
            HSL hsl = RGB_to_HSL(c);
            hsl.S *= Saturation;
            return HSL_to_RGB(hsl);
        }


        /// <summary> 
        /// Sets the absolute Hue level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Hue">The Hue value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetHue(Color c, double Hue)
        {
            HSL hsl = RGB_to_HSL(c);
            hsl.H = Hue;
            return HSL_to_RGB(hsl);
        }


        /// <summary> 
        /// Modifies an existing Hue level 
        /// </summary> 
        /// <remarks> 
        /// To reduce Hue use a number smaller than 1. To increase Hue use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="Hue">The Hue delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifyHue(Color c, double Hue)
        {
            HSL hsl = RGB_to_HSL(c);
            hsl.H *= Hue;
            return HSL_to_RGB(hsl);
        }


        /// <summary> 
        /// Converts a colour from HSL to RGB 
        /// </summary> 
        /// <remarks>Adapted from the algoritm in Foley and Van-Dam</remarks> 
        /// <param name="hsl">The HSL value</param> 
        /// <returns>A Color structure containing the equivalent RGB values</returns> 
        public static System.Drawing.Color HSL_to_RGB(HSL hsl)
        {
            int Max, Mid, Min;
            double q;

            Max = Round(hsl.L * 255);
            Min = Round((1.0 - hsl.S) * (hsl.L / 1.0) * 255);
            q = (double)(Max - Min) / 255;

            if (hsl.H >= 0 && hsl.H <= (double)1 / 6)
            {
                Mid = Round(((hsl.H - 0) * q) * 1530 + Min);
                return System.Drawing.Color.FromArgb(Max, Mid, Min);
            }
            else if (hsl.H <= (double)1 / 3)
            {
                Mid = Round(-((hsl.H - (double)1 / 6) * q) * 1530 + Max);
                return System.Drawing.Color.FromArgb(Mid, Max, Min);
            }
            else if (hsl.H <= 0.5)
            {
                Mid = Round(((hsl.H - (double)1 / 3) * q) * 1530 + Min);
                return System.Drawing.Color.FromArgb(Min, Max, Mid);
            }
            else if (hsl.H <= (double)2 / 3)
            {
                Mid = Round(-((hsl.H - 0.5) * q) * 1530 + Max);
                return System.Drawing.Color.FromArgb(Min, Mid, Max);
            }
            else if (hsl.H <= (double)5 / 6)
            {
                Mid = Round(((hsl.H - (double)2 / 3) * q) * 1530 + Min);
                return System.Drawing.Color.FromArgb(Mid, Min, Max);
            }
            else if (hsl.H <= 1.0)
            {
                Mid = Round(-((hsl.H - (double)5 / 6) * q) * 1530 + Max);
                return System.Drawing.Color.FromArgb(Max, Min, Mid);
            }
            else return System.Drawing.Color.FromArgb(0, 0, 0);
        }


        /// <summary> 
        /// Converts RGB to HSL 
        /// </summary> 
        /// <remarks>Takes advantage of whats already built in to .NET by using the Color.GetHue, Color.GetSaturation and Color.GetBrightness methods</remarks> 
        /// <param name="c">A Color to convert</param> 
        /// <returns>An HSL value</returns> 
        public static HSL RGB_to_HSL(System.Drawing.Color c)
        {
            HSL hsl = new HSL();

            int Max, Min, Diff, Sum;

            //	Of our RGB values, assign the highest value to Max, and the Smallest to Min
            if (c.R > c.G) { Max = c.R; Min = c.G; }
            else { Max = c.G; Min = c.R; }
            if (c.B > Max) Max = c.B;
            else if (c.B < Min) Min = c.B;

            Diff = Max - Min;
            Sum = Max + Min;

            //	Luminance - a.k.a. Brightness - Adobe photoshop uses the logic that the
            //	site VBspeed regards (regarded) as too primitive = superior decides the 
            //	level of brightness.
            hsl.L = (double)Max / 255;

            //	Saturation
            if (Max == 0) hsl.S = 0;	//	Protecting from the impossible operation of division by zero.
            else hsl.S = (double)Diff / Max;	//	The logic of Adobe Photoshops is this simple.

            //	Hue		R is situated at the angel of 360 eller noll degrees; 
            //			G vid 120 degrees
            //			B vid 240 degrees
            double q;
            if (Diff == 0) q = 0; // Protecting from the impossible operation of division by zero.
            else q = (double)60 / Diff;

            if (Max == c.R)
            {
                if (c.G < c.B) hsl.H = (double)(360 + q * (c.G - c.B)) / 360;
                else hsl.H = (double)(q * (c.G - c.B)) / 360;
            }
            else if (Max == c.G) hsl.H = (double)(120 + q * (c.B - c.R)) / 360;
            else if (Max == c.B) hsl.H = (double)(240 + q * (c.R - c.G)) / 360;
            else hsl.H = 0.0;

            return hsl;
        }


        /// <summary>
        /// Converts RGB to CMYK
        /// </summary>
        /// <param name="c">A color to convert.</param>
        /// <returns>A CMYK object</returns>
        public static CMYK RGB_to_CMYK(Color c)
        {
            CMYK _cmyk = new CMYK();
            double low = 1.0;

            _cmyk.C = (double)(255 - c.R) / 255;
            if (low > _cmyk.C)
                low = _cmyk.C;

            _cmyk.M = (double)(255 - c.G) / 255;
            if (low > _cmyk.M)
                low = _cmyk.M;

            _cmyk.Y = (double)(255 - c.B) / 255;
            if (low > _cmyk.Y)
                low = _cmyk.Y;

            if (low > 0.0)
            {
                _cmyk.K = low;
            }

            return _cmyk;
        }


        /// <summary>
        /// Converts CMYK to RGB
        /// </summary>
        /// <param name="_cmyk">A color to convert</param>
        /// <returns>A Color object</returns>
        public static Color CMYK_to_RGB(CMYK _cmyk)
        {
            int red, green, blue;

            red = Round(255 - (255 * _cmyk.C));
            green = Round(255 - (255 * _cmyk.M));
            blue = Round(255 - (255 * _cmyk.Y));

            return Color.FromArgb(red, green, blue);
        }


        /// <summary>
        /// Custom rounding function.
        /// </summary>
        /// <param name="val">Value to round</param>
        /// <returns>Rounded value</returns>
        private static int Round(double val)
        {
            int ret_val = (int)val;

            int temp = (int)(val * 100);

            if ((temp % 100) >= 50)
                ret_val += 1;

            return ret_val;
        }


        #endregion

        #region Public Classes

        public class HSL
        {
            #region Class Variables

            public HSL()
            {
                _h = 0;
                _s = 0;
                _l = 0;
            }

            double _h;
            double _s;
            double _l;

            #endregion

            #region Public Methods

            public double H
            {
                get { return _h; }
                set
                {
                    _h = value;
                    _h = _h > 1 ? 1 : _h < 0 ? 0 : _h;
                }
            }


            public double S
            {
                get { return _s; }
                set
                {
                    _s = value;
                    _s = _s > 1 ? 1 : _s < 0 ? 0 : _s;
                }
            }


            public double L
            {
                get { return _l; }
                set
                {
                    _l = value;
                    _l = _l > 1 ? 1 : _l < 0 ? 0 : _l;
                }
            }


            #endregion
        }


        public class CMYK
        {
            #region Class Variables

            public CMYK()
            {
                _c = 0;
                _m = 0;
                _y = 0;
                _k = 0;
            }


            double _c;
            double _m;
            double _y;
            double _k;

            #endregion

            #region Public Methods

            public double C
            {
                get { return _c; }
                set
                {
                    _c = value;
                    _c = _c > 1 ? 1 : _c < 0 ? 0 : _c;
                }
            }


            public double M
            {
                get { return _m; }
                set
                {
                    _m = value;
                    _m = _m > 1 ? 1 : _m < 0 ? 0 : _m;
                }
            }


            public double Y
            {
                get { return _y; }
                set
                {
                    _y = value;
                    _y = _y > 1 ? 1 : _y < 0 ? 0 : _y;
                }
            }


            public double K
            {
                get { return _k; }
                set
                {
                    _k = value;
                    _k = _k > 1 ? 1 : _k < 0 ? 0 : _k;
                }
            }


            #endregion
        }


        #endregion
    }
    public class ColorPicker : System.Windows.Forms.Form
    {
        #region Class Variables

        private MyColors.HSL m_hsl;
        private Color m_rgb;
        private string m_tbc;
        private MyColors.CMYK m_cmyk;

        public enum eDrawStyle
        {
            Hue,
            Saturation,
            Brightness,
            Red,
            Green,
            Blue
        }


        #endregion

        #region Designer Generated Variables

        private System.Windows.Forms.Label m_lbl_SelectColor;
        private System.Windows.Forms.PictureBox m_pbx_BlankBox;
        private System.Windows.Forms.Button m_cmd_OK;
        private System.Windows.Forms.Button m_cmd_Cancel;
        private System.Windows.Forms.TextBox m_txt_Red;
        private System.Windows.Forms.TextBox m_txt_Green;
        private System.Windows.Forms.TextBox m_txt_Blue;
        private System.Windows.Forms.TextBox m_txt_Hex;
        private System.Windows.Forms.RadioButton m_rbtn_Red;
        private System.Windows.Forms.RadioButton m_rbtn_Green;
        private System.Windows.Forms.RadioButton m_rbtn_Blue;
        private System.Windows.Forms.Label m_lbl_HexPound;
        private System.Windows.Forms.Label m_lbl_Primary_Color;
        private System.Windows.Forms.Label m_lbl_Secondary_Color;
        private ctrlVerticalColorSlider m_ctrl_ThinBox;
        private ctrl2DColorBox m_ctrl_BigBox;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox textAlpha;
        private System.Windows.Forms.Label labelTBC;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.TextBox textTBC;
        private System.Windows.Forms.Label labelAlpha2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors / Destructors

        public ColorPicker(Color starting_color)
        {
            InitializeComponent();

            m_rgb = starting_color;
            m_hsl = MyColors.RGB_to_HSL(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);

            m_txt_Red.Text = m_rgb.R.ToString();
            m_txt_Green.Text = m_rgb.G.ToString();
            m_txt_Blue.Text = m_rgb.B.ToString();
            this.textAlpha.Text = m_rgb.A.ToString();
            this.trackBar.Value = m_rgb.A;

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();
            this.textAlpha.Update();
            this.trackBar.Update();

            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;

            this.m_pbx_BlankBox.Controls.Add(this.m_lbl_Primary_Color);
            this.m_pbx_BlankBox.Controls.Add(this.m_lbl_Secondary_Color);

            m_lbl_Primary_Color.BackColor = starting_color;
            m_lbl_Secondary_Color.BackColor = starting_color;

            this.WriteHexData(m_rgb);
            this.m_pbx_BlankBox.BackgroundImage = My.Draw.BuildGrid(5, m_pbx_BlankBox);

            this.textTBC.Visible = false;
            this.labelTBC.Visible = false;

            // Localizzazione del testo
            /*
			this.m_lbl_SelectColor.Text =	"Seleziona il colore:";
			this.Text =	"Selezione del colore";
			this.labelAlpha.Text = "Alpha:";
			this.labelTBC.Text = "Codice:";
			this.m_cmd_OK.Text = "OK";
			this.m_cmd_Cancel.Text = "Annulla";
			this.buttonDefault.Text = "Default";*/
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ColorPicker));
            this.m_lbl_SelectColor = new System.Windows.Forms.Label();
            this.m_pbx_BlankBox = new System.Windows.Forms.PictureBox();
            this.m_lbl_Primary_Color = new System.Windows.Forms.Label();
            this.m_lbl_Secondary_Color = new System.Windows.Forms.Label();
            this.m_cmd_OK = new System.Windows.Forms.Button();
            this.m_cmd_Cancel = new System.Windows.Forms.Button();
            this.m_txt_Red = new System.Windows.Forms.TextBox();
            this.m_txt_Green = new System.Windows.Forms.TextBox();
            this.m_txt_Blue = new System.Windows.Forms.TextBox();
            this.m_txt_Hex = new System.Windows.Forms.TextBox();
            this.m_rbtn_Red = new System.Windows.Forms.RadioButton();
            this.m_rbtn_Green = new System.Windows.Forms.RadioButton();
            this.m_rbtn_Blue = new System.Windows.Forms.RadioButton();
            this.m_lbl_HexPound = new System.Windows.Forms.Label();
            this.m_ctrl_ThinBox = new My.Controls.ctrlVerticalColorSlider();
            this.m_ctrl_BigBox = new My.Controls.ctrl2DColorBox();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.labelAlpha2 = new System.Windows.Forms.Label();
            this.textAlpha = new System.Windows.Forms.TextBox();
            this.textTBC = new System.Windows.Forms.TextBox();
            this.labelTBC = new System.Windows.Forms.Label();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.m_pbx_BlankBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lbl_SelectColor
            // 
            this.m_lbl_SelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.m_lbl_SelectColor.Location = new System.Drawing.Point(10, 10);
            this.m_lbl_SelectColor.Name = "m_lbl_SelectColor";
            this.m_lbl_SelectColor.Size = new System.Drawing.Size(260, 20);
            this.m_lbl_SelectColor.TabIndex = 0;
            this.m_lbl_SelectColor.Text = "Seleziona il colore desiderato:";
            // 
            // m_pbx_BlankBox
            // 
            this.m_pbx_BlankBox.BackColor = System.Drawing.Color.Transparent;
            //this.m_pbx_BlankBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_pbx_BlankBox.BackgroundImage")));
            this.m_pbx_BlankBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pbx_BlankBox.Controls.Add(this.m_lbl_Primary_Color);
            this.m_pbx_BlankBox.Controls.Add(this.m_lbl_Secondary_Color);
            this.m_pbx_BlankBox.Location = new System.Drawing.Point(316, 30);
            this.m_pbx_BlankBox.Name = "m_pbx_BlankBox";
            this.m_pbx_BlankBox.Size = new System.Drawing.Size(77, 70);
            this.m_pbx_BlankBox.TabIndex = 3;
            this.m_pbx_BlankBox.TabStop = false;
            // 
            // m_lbl_Primary_Color
            // 
            this.m_lbl_Primary_Color.BackColor = System.Drawing.Color.Transparent;
            this.m_lbl_Primary_Color.ForeColor = System.Drawing.Color.Transparent;
            this.m_lbl_Primary_Color.Location = new System.Drawing.Point(0, 0);
            this.m_lbl_Primary_Color.Name = "m_lbl_Primary_Color";
            this.m_lbl_Primary_Color.Size = new System.Drawing.Size(75, 34);
            this.m_lbl_Primary_Color.TabIndex = 1;
            this.m_lbl_Primary_Color.Click += new System.EventHandler(this.m_lbl_Primary_Color_Click);
            // 
            // m_lbl_Secondary_Color
            // 
            this.m_lbl_Secondary_Color.BackColor = System.Drawing.Color.Transparent;
            this.m_lbl_Secondary_Color.ForeColor = System.Drawing.Color.Transparent;
            this.m_lbl_Secondary_Color.Location = new System.Drawing.Point(0, 34);
            this.m_lbl_Secondary_Color.Name = "m_lbl_Secondary_Color";
            this.m_lbl_Secondary_Color.Size = new System.Drawing.Size(75, 34);
            this.m_lbl_Secondary_Color.TabIndex = 2;
            this.m_lbl_Secondary_Color.Click += new System.EventHandler(this.m_lbl_Secondary_Color_Click);
            // 
            // m_cmd_OK
            // 
            this.m_cmd_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmd_OK.Location = new System.Drawing.Point(323, 312);
            this.m_cmd_OK.Name = "m_cmd_OK";
            this.m_cmd_OK.Size = new System.Drawing.Size(72, 23);
            this.m_cmd_OK.TabIndex = 4;
            this.m_cmd_OK.Text = "Ok";
            this.m_cmd_OK.Click += new System.EventHandler(this.m_cmd_OK_Click);
            // 
            // m_cmd_Cancel
            // 
            this.m_cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmd_Cancel.Location = new System.Drawing.Point(323, 284);
            this.m_cmd_Cancel.Name = "m_cmd_Cancel";
            this.m_cmd_Cancel.Size = new System.Drawing.Size(72, 23);
            this.m_cmd_Cancel.TabIndex = 5;
            this.m_cmd_Cancel.Text = "Annulla";
            this.m_cmd_Cancel.Click += new System.EventHandler(this.m_cmd_Cancel_Click);
            // 
            // m_txt_Red
            // 
            this.m_txt_Red.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.m_txt_Red.Location = new System.Drawing.Point(360, 112);
            this.m_txt_Red.Name = "m_txt_Red";
            this.m_txt_Red.Size = new System.Drawing.Size(35, 21);
            this.m_txt_Red.TabIndex = 9;
            this.m_txt_Red.Text = "";
            this.m_txt_Red.Leave += new System.EventHandler(this.m_txt_Red_Leave);
            // 
            // m_txt_Green
            // 
            this.m_txt_Green.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.m_txt_Green.Location = new System.Drawing.Point(360, 136);
            this.m_txt_Green.Name = "m_txt_Green";
            this.m_txt_Green.Size = new System.Drawing.Size(35, 21);
            this.m_txt_Green.TabIndex = 10;
            this.m_txt_Green.Text = "";
            this.m_txt_Green.Leave += new System.EventHandler(this.m_txt_Green_Leave);
            // 
            // m_txt_Blue
            // 
            this.m_txt_Blue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.m_txt_Blue.Location = new System.Drawing.Point(360, 160);
            this.m_txt_Blue.Name = "m_txt_Blue";
            this.m_txt_Blue.Size = new System.Drawing.Size(35, 21);
            this.m_txt_Blue.TabIndex = 11;
            this.m_txt_Blue.Text = "";
            this.m_txt_Blue.Leave += new System.EventHandler(this.m_txt_Blue_Leave);
            // 
            // m_txt_Hex
            // 
            this.m_txt_Hex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.m_txt_Hex.Location = new System.Drawing.Point(339, 208);
            this.m_txt_Hex.Name = "m_txt_Hex";
            this.m_txt_Hex.Size = new System.Drawing.Size(56, 21);
            this.m_txt_Hex.TabIndex = 19;
            this.m_txt_Hex.Text = "";
            this.m_txt_Hex.Leave += new System.EventHandler(this.m_txt_Hex_Leave);
            // 
            // m_rbtn_Red
            // 
            this.m_rbtn_Red.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_rbtn_Red.Location = new System.Drawing.Point(320, 110);
            this.m_rbtn_Red.Name = "m_rbtn_Red";
            this.m_rbtn_Red.Size = new System.Drawing.Size(35, 24);
            this.m_rbtn_Red.TabIndex = 23;
            this.m_rbtn_Red.Text = "R:";
            this.m_rbtn_Red.CheckedChanged += new System.EventHandler(this.m_rbtn_Red_CheckedChanged);
            // 
            // m_rbtn_Green
            // 
            this.m_rbtn_Green.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_rbtn_Green.Location = new System.Drawing.Point(320, 134);
            this.m_rbtn_Green.Name = "m_rbtn_Green";
            this.m_rbtn_Green.Size = new System.Drawing.Size(35, 24);
            this.m_rbtn_Green.TabIndex = 24;
            this.m_rbtn_Green.Text = "G:";
            this.m_rbtn_Green.CheckedChanged += new System.EventHandler(this.m_rbtn_Green_CheckedChanged);
            // 
            // m_rbtn_Blue
            // 
            this.m_rbtn_Blue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_rbtn_Blue.Location = new System.Drawing.Point(320, 158);
            this.m_rbtn_Blue.Name = "m_rbtn_Blue";
            this.m_rbtn_Blue.Size = new System.Drawing.Size(35, 24);
            this.m_rbtn_Blue.TabIndex = 25;
            this.m_rbtn_Blue.Text = "B:";
            this.m_rbtn_Blue.CheckedChanged += new System.EventHandler(this.m_rbtn_Blue_CheckedChanged);
            // 
            // m_lbl_HexPound
            // 
            this.m_lbl_HexPound.Location = new System.Drawing.Point(323, 211);
            this.m_lbl_HexPound.Name = "m_lbl_HexPound";
            this.m_lbl_HexPound.Size = new System.Drawing.Size(16, 14);
            this.m_lbl_HexPound.TabIndex = 27;
            this.m_lbl_HexPound.Text = "#";
            // 
            // m_ctrl_ThinBox
            // 
            this.m_ctrl_ThinBox.DrawStyle = ctrlVerticalColorSlider.eDrawStyle.Hue;
            this.m_ctrl_ThinBox.Location = new System.Drawing.Point(271, 28);
            this.m_ctrl_ThinBox.Name = "m_ctrl_ThinBox";
            this.m_ctrl_ThinBox.RGB = System.Drawing.Color.Red;
            this.m_ctrl_ThinBox.Size = new System.Drawing.Size(40, 264);
            this.m_ctrl_ThinBox.TabIndex = 38;
            this.m_ctrl_ThinBox.Scroll += new EventHandler(this.m_ctrl_ThinBox_Scroll); //DELEGATE
            // 
            // m_ctrl_BigBox
            // 
            this.m_ctrl_BigBox.DrawStyle = ctrl2DColorBox.eDrawStyle.Hue;
            this.m_ctrl_BigBox.Location = new System.Drawing.Point(10, 30);
            this.m_ctrl_BigBox.Name = "m_ctrl_BigBox";
            this.m_ctrl_BigBox.RGB = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(0)), ((System.Byte)(0)));
            this.m_ctrl_BigBox.Size = new System.Drawing.Size(260, 260);
            this.m_ctrl_BigBox.TabIndex = 39;
            this.m_ctrl_BigBox.Scroll += new EventHandler(this.m_ctrl_BigBox_Scroll); //DELEGATE
            // 
            // labelAlpha
            // 
            this.labelAlpha.Location = new System.Drawing.Point(20, 296);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(56, 24);
            this.labelAlpha.TabIndex = 40;
            this.labelAlpha.Text = "Visibilità:";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(64, 296);
            this.trackBar.Maximum = 255;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(208, 45);
            this.trackBar.TabIndex = 41;
            this.trackBar.TickFrequency = 5;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Value = 255;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // labelAlpha2
            // 
            this.labelAlpha2.Location = new System.Drawing.Point(334, 187);
            this.labelAlpha2.Name = "labelAlpha2";
            this.labelAlpha2.Size = new System.Drawing.Size(16, 16);
            this.labelAlpha2.TabIndex = 42;
            this.labelAlpha2.Text = "a:";
            // 
            // textAlpha
            // 
            this.textAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.textAlpha.Location = new System.Drawing.Point(360, 184);
            this.textAlpha.Name = "textAlpha";
            this.textAlpha.Size = new System.Drawing.Size(35, 21);
            this.textAlpha.TabIndex = 43;
            this.textAlpha.Text = "";
            this.textAlpha.TextChanged += new System.EventHandler(textAlpha_TextChanged);
            // 
            // textTBC
            // 
            this.textTBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.textTBC.Location = new System.Drawing.Point(315, 252);
            this.textTBC.Name = "textTBC";
            this.textTBC.ReadOnly = true;
            this.textTBC.Size = new System.Drawing.Size(80, 21);
            this.textTBC.TabIndex = 44;
            this.textTBC.Text = "";
            // 
            // labelTBC
            // 
            this.labelTBC.Location = new System.Drawing.Point(312, 236);
            this.labelTBC.Name = "labelTBC";
            this.labelTBC.Size = new System.Drawing.Size(88, 16);
            this.labelTBC.TabIndex = 45;
            this.labelTBC.Text = "TitleBox color:";
            // 
            // buttonDefault
            // 
            this.buttonDefault.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDefault.Enabled = false;
            this.buttonDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDefault.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonDefault.Location = new System.Drawing.Point(11, 317);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(50, 20);
            this.buttonDefault.TabIndex = 46;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // frmColorPicker
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(402, 344);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.labelTBC);
            this.Controls.Add(this.textTBC);
            this.Controls.Add(this.textAlpha);
            this.Controls.Add(this.m_ctrl_BigBox);
            this.Controls.Add(this.m_ctrl_ThinBox);
            this.Controls.Add(this.m_txt_Hex);
            this.Controls.Add(this.m_txt_Blue);
            this.Controls.Add(this.m_txt_Green);
            this.Controls.Add(this.m_txt_Red);
            this.Controls.Add(this.labelAlpha2);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.labelAlpha);
            this.Controls.Add(this.m_lbl_HexPound);
            this.Controls.Add(this.m_rbtn_Blue);
            this.Controls.Add(this.m_rbtn_Green);
            this.Controls.Add(this.m_rbtn_Red);
            this.Controls.Add(this.m_cmd_Cancel);
            this.Controls.Add(this.m_cmd_OK);
            this.Controls.Add(this.m_pbx_BlankBox);
            this.Controls.Add(this.m_lbl_SelectColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmColorPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione del colore";
            this.Load += new System.EventHandler(this.frmColorPicker_Load);
            this.m_pbx_BlankBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        #region Events

        #region General Events

        private void frmColorPicker_Load(object sender, System.EventArgs e)
        {
        }

        private void m_cmd_OK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmd_Cancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        #endregion

        #region Primary Picture Box (m_ctrl_BigBox)

        private void m_ctrl_BigBox_Scroll(object sender, System.EventArgs e)
        {
            m_hsl = m_ctrl_BigBox.HSL;
            m_rgb = MyColors.HSL_to_RGB(m_hsl);
            m_rgb = ToTransparent(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);

            m_txt_Red.Text = m_rgb.R.ToString();
            m_txt_Green.Text = m_rgb.G.ToString();
            m_txt_Blue.Text = m_rgb.B.ToString();

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();

            m_ctrl_ThinBox.HSL = m_hsl;

            m_lbl_Primary_Color.BackColor = m_rgb;
            m_lbl_Primary_Color.Update();

            WriteHexData(m_rgb);
        }


        #endregion

        #region Secondary Picture Box (m_ctrl_ThinBox)

        private void m_ctrl_ThinBox_Scroll(object sender, System.EventArgs e)
        {
            m_hsl = m_ctrl_ThinBox.HSL;
            m_rgb = MyColors.HSL_to_RGB(m_hsl);
            m_rgb = ToTransparent(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);

            m_txt_Red.Text = m_rgb.R.ToString();
            m_txt_Green.Text = m_rgb.G.ToString();
            m_txt_Blue.Text = m_rgb.B.ToString();

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();

            m_ctrl_BigBox.HSL = m_hsl;

            m_lbl_Primary_Color.BackColor = m_rgb;
            m_lbl_Primary_Color.Update();

            WriteHexData(m_rgb);
        }


        #endregion

        #region Hex Box (m_txt_Hex)

        private void m_txt_Hex_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Hex.Text.ToUpper();
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            foreach (char letter in text)
            {
                if (!char.IsNumber(letter))
                {
                    if (letter >= 'A' && letter <= 'F')
                        continue;
                    has_illegal_chars = true;
                    break;
                }
            }

            if (has_illegal_chars)
            {
                My.Box.Warning("Non è un numero esadecimale");
                WriteHexData(m_rgb);
                return;
            }

            m_rgb = ParseHexData(text);
            m_rgb = ToTransparent(m_rgb);
            m_hsl = MyColors.RGB_to_HSL(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);

            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;
            m_lbl_Primary_Color.BackColor = m_rgb;

            UpdateTextBoxes();
        }


        #endregion

        #region Color Boxes

        private void m_lbl_Primary_Color_Click(object sender, System.EventArgs e)
        {
            m_rgb = m_lbl_Primary_Color.BackColor;
            m_hsl = MyColors.RGB_to_HSL(m_rgb);

            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;

            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);

            m_txt_Red.Text = m_rgb.R.ToString();
            m_txt_Green.Text = m_rgb.G.ToString();
            m_txt_Blue.Text = m_rgb.B.ToString();
            this.textAlpha.Text = m_rgb.A.ToString();
            this.trackBar.Value = (int)m_rgb.A;

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();
            this.textAlpha.Update();
            this.trackBar.Update();
        }


        private void m_lbl_Secondary_Color_Click(object sender, System.EventArgs e)
        {
            m_rgb = m_lbl_Secondary_Color.BackColor;
            m_hsl = MyColors.RGB_to_HSL(m_rgb);

            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;

            m_lbl_Primary_Color.BackColor = m_rgb;
            m_lbl_Primary_Color.Update();

            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);

            m_txt_Red.Text = m_rgb.R.ToString();
            m_txt_Green.Text = m_rgb.G.ToString();
            m_txt_Blue.Text = m_rgb.B.ToString();
            this.textAlpha.Text = m_rgb.A.ToString();
            this.trackBar.Value = (int)m_rgb.A;

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();
            this.textAlpha.Update();
            this.trackBar.Update();
        }


        #endregion

        #region Radio Buttons

        private void m_rbtn_Red_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_rbtn_Red.Checked)
            {
                m_ctrl_ThinBox.DrawStyle = ctrlVerticalColorSlider.eDrawStyle.Red;
                m_ctrl_BigBox.DrawStyle = ctrl2DColorBox.eDrawStyle.Red;
                this.buttonDefault.Enabled = true;
            }
        }


        private void m_rbtn_Green_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_rbtn_Green.Checked)
            {
                m_ctrl_ThinBox.DrawStyle = ctrlVerticalColorSlider.eDrawStyle.Green;
                m_ctrl_BigBox.DrawStyle = ctrl2DColorBox.eDrawStyle.Green;
                this.buttonDefault.Enabled = true;
            }
        }


        private void m_rbtn_Blue_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_rbtn_Blue.Checked)
            {
                m_ctrl_ThinBox.DrawStyle = ctrlVerticalColorSlider.eDrawStyle.Blue;
                m_ctrl_BigBox.DrawStyle = ctrl2DColorBox.eDrawStyle.Blue;
                this.buttonDefault.Enabled = true;
            }
        }


        #endregion

        #region Text Boxes

        private void m_txt_Red_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Red.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                My.Box.Warning("Non è un colore RGB");
                UpdateTextBoxes();
                return;
            }

            int red = int.Parse(text);

            if (red < 0)
            {
                My.Box.Warning("Non è un colore RGB");
                m_rgb = Color.FromArgb(0, m_rgb.G, m_rgb.B);
            }
            else if (red > 255)
            {
                My.Box.Warning("Non è un colore RGB");
                m_rgb = Color.FromArgb(255, m_rgb.G, m_rgb.B);
            }
            else
            {
                m_rgb = Color.FromArgb(red, m_rgb.G, m_rgb.B);
            }

            m_hsl = MyColors.RGB_to_HSL(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);
            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;
            m_lbl_Primary_Color.BackColor = m_rgb;

            UpdateTextBoxes();
        }


        private void m_txt_Green_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Green.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                My.Box.Warning("Non è un colore RGB");
                UpdateTextBoxes();
                return;
            }

            int green = int.Parse(text);

            if (green < 0)
            {
                My.Box.Warning("Non è un colore RGB");
                m_txt_Green.Text = "0";
                m_rgb = Color.FromArgb(m_rgb.R, 0, m_rgb.B);
            }
            else if (green > 255)
            {
                My.Box.Warning("Non è un colore RGB");
                m_txt_Green.Text = "255";
                m_rgb = Color.FromArgb(m_rgb.R, 255, m_rgb.B);
            }
            else
            {
                m_rgb = Color.FromArgb(m_rgb.R, green, m_rgb.B);
            }

            m_hsl = MyColors.RGB_to_HSL(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);
            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;
            m_lbl_Primary_Color.BackColor = m_rgb;

            UpdateTextBoxes();
        }


        private void m_txt_Blue_Leave(object sender, System.EventArgs e)
        {
            string text = m_txt_Blue.Text;
            bool has_illegal_chars = false;

            if (text.Length <= 0)
                has_illegal_chars = true;
            else
                foreach (char letter in text)
                {
                    if (!char.IsNumber(letter))
                    {
                        has_illegal_chars = true;
                        break;
                    }
                }

            if (has_illegal_chars)
            {
                My.Box.Warning("Non è un colore RGB");
                UpdateTextBoxes();
                return;
            }

            int blue = int.Parse(text);

            if (blue < 0)
            {
                My.Box.Warning("Non è un colore RGB");
                m_txt_Blue.Text = "0";
                m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, 0);
            }
            else if (blue > 255)
            {
                My.Box.Warning("Non è un colore RGB");
                m_txt_Blue.Text = "255";
                m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, 255);
            }
            else
            {
                m_rgb = Color.FromArgb(m_rgb.R, m_rgb.G, blue);
            }

            m_hsl = MyColors.RGB_to_HSL(m_rgb);
            m_cmyk = MyColors.RGB_to_CMYK(m_rgb);
            m_ctrl_BigBox.HSL = m_hsl;
            m_ctrl_ThinBox.HSL = m_hsl;
            m_lbl_Primary_Color.BackColor = m_rgb;

            UpdateTextBoxes();
        }

        #endregion

        #endregion

        #region Private Functions

        private int Round(double val)
        {
            int ret_val = (int)val;

            int temp = (int)(val * 100);

            if ((temp % 100) >= 50)
                ret_val += 1;

            return ret_val;
        }


        private void WriteHexData(Color rgb)
        {
            string red = System.Convert.ToString(rgb.R, 16);
            if (red.Length < 2) red = "0" + red;
            string green = System.Convert.ToString(rgb.G, 16);
            if (green.Length < 2) green = "0" + green;
            string blue = System.Convert.ToString(rgb.B, 16);
            if (blue.Length < 2) blue = "0" + blue;
            string tran = System.Convert.ToString(this.trackBar.Value, 16);
            if (tran.Length < 2) tran = "0" + tran;
            red = red.ToUpper(); green = green.ToUpper();
            blue = blue.ToUpper(); tran = tran.ToUpper();
            m_txt_Hex.Text = red + green + blue;
            m_txt_Hex.Update();
            m_tbc = tran + red + green + blue;
            m_tbc = System.Convert.ToInt64(m_tbc, 16).ToString();
            this.textTBC.Text = m_tbc;
            this.textTBC.Update();
        }

        private void WriteTBC()
        {	// Aggiornamento del colore in formato TitleBox
            string tran = System.Convert.ToString(this.trackBar.Value, 16);
            if (tran.Length < 2) tran = "0" + tran;
            tran = tran.ToUpper();
            m_tbc = tran + this.m_txt_Hex.Text;
            m_tbc = System.Convert.ToInt64(m_tbc, 16).ToString();
            this.textTBC.Text = m_tbc;
            this.textTBC.Update();
            this.m_rgb = ToTransparent(m_rgb);
            this.m_lbl_Primary_Color.BackColor = m_rgb;
        }

        private Color ParseHexData(string hex_data)
        {
            if (hex_data.Length != 6)
                return Color.Black;

            string r_text, g_text, b_text;
            int r, g, b;

            r_text = hex_data.Substring(0, 2);
            g_text = hex_data.Substring(2, 2);
            b_text = hex_data.Substring(4, 2);

            r = int.Parse(r_text, System.Globalization.NumberStyles.HexNumber);
            g = int.Parse(g_text, System.Globalization.NumberStyles.HexNumber);
            b = int.Parse(b_text, System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(r, g, b);
        }

        private void UpdateTextBoxes()
        {
            m_txt_Red.Text = m_rgb.R.ToString();
            m_txt_Green.Text = m_rgb.G.ToString();
            m_txt_Blue.Text = m_rgb.B.ToString();

            m_txt_Red.Update();
            m_txt_Green.Update();
            m_txt_Blue.Update();

            WriteHexData(m_rgb);
        }


        #endregion

        #region Public Methods

        public Color PrimaryColor
        {
            get
            {
                return m_rgb;
            }
            set
            {
                m_rgb = value;
                m_hsl = MyColors.RGB_to_HSL(m_rgb);

                m_txt_Red.Text = m_rgb.R.ToString();
                m_txt_Green.Text = m_rgb.G.ToString();
                m_txt_Blue.Text = m_rgb.B.ToString();
                this.textAlpha.Text = m_rgb.A.ToString();
                this.trackBar.Value = m_rgb.A;

                m_txt_Red.Update();
                m_txt_Green.Update();
                m_txt_Blue.Update();
                this.textAlpha.Update();
                this.trackBar.Update();

                m_ctrl_BigBox.HSL = m_hsl;
                m_ctrl_ThinBox.HSL = m_hsl;

                m_lbl_Primary_Color.BackColor = m_rgb;
            }
        }

        public string TBColor
        {
            get { return ToTBC(m_rgb); }
        }

        private string ToTBC(Color c)
        {
            string a = ToHex(c.A);
            string r = ToHex(c.R);
            string g = ToHex(c.G);
            string b = ToHex(c.B);
            string result = a + r + g + b;
            return System.Convert.ToInt64(result, 16).ToString();
        }
        private string ToHex(int c)
        {
            string result = System.Convert.ToString(c, 16);
            if (result.Length < 2) result = "0" + result;
            return result.ToUpper();
        }

        public eDrawStyle DrawStyle
        {
            get
            {
                if (m_rbtn_Red.Checked)
                    return eDrawStyle.Red;
                else if (m_rbtn_Green.Checked)
                    return eDrawStyle.Green;
                else if (m_rbtn_Blue.Checked)
                    return eDrawStyle.Blue;
                else
                    return eDrawStyle.Hue;
            }
            set
            {
                switch (value)
                {
                    case eDrawStyle.Red:
                        m_rbtn_Red.Checked = true;
                        break;
                    case eDrawStyle.Green:
                        m_rbtn_Green.Checked = true;
                        break;
                    case eDrawStyle.Blue:
                        m_rbtn_Blue.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }


        #endregion

        private void trackBar_Scroll(object sender, System.EventArgs e)
        {
            double val = (double)this.trackBar.Value;
            this.textAlpha.Text = val.ToString();
            this.textAlpha.Update();
            WriteTBC();
        }

        private void buttonDefault_Click(object sender, System.EventArgs e)
        {
            m_ctrl_ThinBox.DrawStyle = ctrlVerticalColorSlider.eDrawStyle.Hue;
            m_ctrl_BigBox.DrawStyle = ctrl2DColorBox.eDrawStyle.Hue;
            this.buttonDefault.Enabled = false;
            this.m_rbtn_Red.Checked = false;
            this.m_rbtn_Green.Checked = false;
            this.m_rbtn_Blue.Checked = false;
        }

        private Color ToTransparent(Color c)
        {
            return Color.FromArgb(this.trackBar.Value, c);
        }

        private void textAlpha_TextChanged(object sender, EventArgs e)
        {
            int result = 255;
            try
            {
                result = System.Convert.ToInt16(this.textAlpha.Text);
                if (result > 255) result = 255;
            }
            catch { result = 255; }
            this.trackBar.Value = result;
            WriteTBC();
        }
    }
}