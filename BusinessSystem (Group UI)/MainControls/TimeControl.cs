using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controls;

namespace MainControls
{
    public partial class TimeControl : UserControl
    {
        MouseState state;

        public TimeControl()
        {
            InitializeComponent();

            m_TitleColor = Color.White;

            m_buttoncolor1 = Color.DarkSlateBlue;
        }


        public string TimeText
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
        public string SecondText
        {
            get
            {
                return this.label2.Text;
            }
            set
            {
                this.label2.Text = value;

            }
        }
        public string AMText
        {
            get
            {
                return this.label3.Text;
            }
            set
            {
                this.label3.Text = value;

            }
        }
        public string DateText
        {
            get
            {
                return this.label4.Text;
            }
            set
            {
                this.label4.Text = value;

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
    }
}
