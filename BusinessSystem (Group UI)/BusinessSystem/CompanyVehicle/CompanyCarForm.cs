using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BusinessSystem
{
    public partial class CompanyCarForm : SonForm
    {
        public CompanyCarForm()
        {
            InitializeComponent();
            
        }

        //全域變數======================
        string txt1 = " : 請輸入車號";
        string txt2 = " : 請輸入年分";
        string txt3 = " : 請輸入引擎編號";

        
        //===============================
        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            this.label8.ForeColor = Color.LightSkyBlue;
        }

        private void label8_MouseUp(object sender, MouseEventArgs e)
        {
            this.label8.ForeColor = Color.Blue;
        }

        

        private void label8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                pictureBox2.Image = Image.FromFile(filename);
                this.label6.Text = "";
                this.label6.Text = filename;
                this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox1.Text == txt1 )
            {
                this.textBox1.Clear();
  
                if (this.textBox2.Text == "")
                {
                 
                    this.textBox2.Text = txt2;
                }
                else if (this.textBox3.Text == "")
                {
            
                    this.textBox3.Text = txt3;
                }
            }
            else if  (this.textBox2.Text == "")
            {

                this.textBox2.Text = txt2;
            }
            else if (this.textBox3.Text == "")
            {

                this.textBox3.Text = txt3;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox2.Text == txt2 )
            {
                this.textBox2.Clear();

                if (this.textBox3.Text == "")
                {
                    this.textBox3.Text = txt3;
                }
                else if (this.textBox1.Text == "")
                {
                    this.textBox1.Text = txt1;
                }
            }
            else if  (this.textBox3.Text == "")
            {
                this.textBox3.Text = txt3;
            }
            else if (this.textBox1.Text == "")
            {
                this.textBox1.Text = txt1;
            }
        }
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox3.Text == txt3)
            {

                this.textBox3.Clear();
                if (this.textBox2.Text == "")
                {

                    this.textBox2.Text = txt2;
                }
                else if (this.textBox1.Text == "")
                {

                    this.textBox1.Text = txt1;
                }
            }
            else if (this.textBox2.Text == "")
            {
       
                this.textBox2.Text = txt2;
            }
            else if (this.textBox1.Text == "")
            {
      
                this.textBox1.Text = txt1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || this.textBox1.Focused)
            {
                this.textBox1.ForeColor = Color.Black;
            }
            else if (this.textBox1.Text == txt1)
            {
                this.textBox1.ForeColor = Color.Silver;
                this.textBox1.Text = txt1;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || this.textBox2.Focused)
            {
                this.textBox2.ForeColor = Color.Black;
            }
            else if (this.textBox2.Text == txt2)
            {
                this.textBox2.ForeColor = Color.Silver;
                this.textBox2.Text = txt2;
            }
        }
    
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || this.textBox3.Focused)
            {
                this.textBox3.ForeColor = Color.Black;
            }
            else if(this.textBox3.Text == txt3)
            {
                this.textBox3.ForeColor = Color.Silver;
                this.textBox3.Text = txt3;
            }
        }
    }
}
