﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using Controls;

namespace MainControls
{
    public partial class MainControls : UserControl
    {
        MouseState state;


        public MainControls()
        {
            InitializeComponent();
            m_TitleColor = Color.White;
           
            m_buttoncolor1 = Color.SteelBlue;

            

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
        public Color BackgroundColor
        {
            get
            {
                return m_backgroundcolor1;
            }
            set
            {

                m_backgroundcolor1 = value;
                this.BackColor = m_backgroundcolor1;
                
            }
        }




        private Color m_buttoncolor1;
        public Color ButtonColor
        {
            get
            {
                return m_buttoncolor1;
            }
            set
            {

                m_buttoncolor1 = value;
                this.clsAltoButton1.Active1 = m_buttoncolor1;
                this.clsAltoButton1.Active2 = m_buttoncolor1;
                this.clsAltoButton1.Inactive1 = m_buttoncolor1;
                this.clsAltoButton1.Inactive2 = m_buttoncolor1;
                this.label1.BackColor = m_buttoncolor1;
                this.pictureBox1.BackColor = m_buttoncolor1;
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
        private string m_imagelocation;
        public string ImageLocation
        {
            get
            {
                return m_imagelocation;
            }
            set
            {
                this.pictureBox1.ImageLocation = value;
                m_imagelocation = this.pictureBox1.ImageLocation;
            }
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            
            this.OnClick(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void clsAltoButton1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void clsAltoButton1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void clsAltoButton1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void clsAltoButton1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
    }
}
