using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyEvents_CSharp;

namespace MyEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.MouseMove += Form1_MouseMove;
         
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"( {e.X} , {e.Y} )";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.buttonX.Click += new EventHandler(xxx);
            this.buttonX.Click += ButtonX_Click;
        }

        private void xxx(object sender, EventArgs e)
        {
            MessageBox.Show("xxx");
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Register ButtonX");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
            {
                MessageBox.Show("Anonymous匿名方法");
            };

            this.buttonX.Click += (object sender1, EventArgs e1) =>
            {
                MessageBox.Show("Anonymous Lambda匿名方法");
            };


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 x = new Class1();
            x.InvalidPrice += X_InvalidPrice;
            x.Test(-100);

            Class1.Info xx = new Class1.Info() { Price =- 1000};
            x.ClsInvalidPrice += X_ClsInvalidPrice;
            x.ClsTest(xx);

        }

        private void X_ClsInvalidPrice(Class1.Info info)
        {
            MessageBox.Show("Invalid Price " + info.Price);
        }

        private void X_InvalidPrice(int price)
        {
            MessageBox.Show("Invalid Price " + price);
        }
    }
}
