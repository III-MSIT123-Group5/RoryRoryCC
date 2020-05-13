using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MyOOP
{
    public partial class FrmLogo : Form
    {
        public FrmLogo()
        {
            InitializeComponent();

            this.Paint += FrmLogo_Paint;
            this.LinearColor2 = Color.Aqua;
            this.LinearColor1 = Color.Orange;
        }

        public Color LinearColor1 { get; set; }
        public Color LinearColor2 { get; set; }

        protected void FrmLogo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(ClientRectangle.Width, 0);
            //SolidBrush brush1 = new SolidBrush(Color.Aqua);
            
            LinearGradientBrush brush1 = new System.Drawing.Drawing2D.LinearGradientBrush(pt1, pt2,this.LinearColor1, this.LinearColor2);

            g.FillRectangle(brush1, ClientRectangle);

        }

        private void FrmLogo_Load(object sender, EventArgs e)
        {

        }
    }
}
