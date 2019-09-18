using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainControls
{
    public partial class MainControls : UserControl
    {
        public MainControls()
        {
            InitializeComponent();
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        public string Title
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;

            }
        }
        
        





        private Color m_backgroundcolor1;
        public Color backgroundcolor
        {
            get
            {
                return m_backgroundcolor1;
            }
            set
            {

                m_backgroundcolor1 = value;
                this.clsAltoButton1.Inactive1 = m_backgroundcolor1;
                this.clsAltoButton1.Inactive2 = m_backgroundcolor1;
                this.label1.BackColor = m_backgroundcolor1;
                this.pictureBox1.BackColor = m_backgroundcolor1;
                this.clsAltoButton1.Invalidate();
            }
        }
        
        private Color m_TitleColor;
        public Color TitleColor
        {
            get
            {
                return m_TitleColor;
            }
            set
            {

                m_TitleColor = value;
                this.label1.ForeColor = m_TitleColor;
                
            }
        }

        private Image m_image;
        public Image image
        {
            get
            {
                return m_image;
            }
            set
            {

                this.pictureBox1.Image = value;
                m_image = this.pictureBox1.Image;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void clsAltoButton1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
    }
}
