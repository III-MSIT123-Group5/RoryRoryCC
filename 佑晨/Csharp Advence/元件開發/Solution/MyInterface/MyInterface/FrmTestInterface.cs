using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyInterface
{
    public partial class FrmTestInterface : Form
    {
        public FrmTestInterface()
        {
            InitializeComponent();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Cat c = new Cat();

            Dog d = new Dog();

            IAnimals i;

            i = c;
            i.MakeNoise();
            i = d;
            i.MakeNoise();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            using(Dog d = new Dog())
            {
                d.MakeNoise();
            }
        }
    }
}
