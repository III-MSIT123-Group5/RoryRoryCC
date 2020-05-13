using Banking;
using MyOOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0416DLL
{
    public partial class Form1 : FrmLogo
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsBanking a = new ClsBanking();
            MessageBox.Show($"a { a.Deposit(1000)}");
            ClsSpecialBanking b = new ClsSpecialBanking();
            MessageBox.Show($"b { b.Deposit(1000)}");

        }
    }
}
