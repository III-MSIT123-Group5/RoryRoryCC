using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BusinessSystemControlLibrary
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        
        public byte [] pic
        {
            set
            {
                MemoryStream st = new MemoryStream(value);
                this.pictureBox1.Image = Image.FromStream(st);
            }
        }
        private string m_licNu;
        public string licNu
        {
            get
            {
                return m_licNu;
            }
            set
            {
                this.m_licNu = value;
            }
        }

        
        public delegate void mmouse(object sender, EventArgs e,UserControl1 tthis );
        public event mmouse Scclick;
        //private int m_Abab;
        //public int Abab
        //{
        //    get
        //    {
        //        return m_Abab;
        //    }
        //    set
        //    {
        //        m_Abab  = value;
        //    }
        //}
        
        private void label1_Click(object sender, EventArgs e)
        {
            
            Scclick(sender, e , this);
            
        }
    }
}
