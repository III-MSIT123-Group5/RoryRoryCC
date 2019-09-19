using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessSystem.EmployeeSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            BusinessDataBaseEntities dbContext;

            dbContext = new BusinessDataBaseEntities();

            var q = from em in dbContext.Employees
                    join a in dbContext.Accounts
                    on em.Account equals a.account1
                    //where a.account1 == textBox1.Text && a.password == textBox2.Text
                    select new { a.account1,a.password};


        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請尋求IT人員協助重設密碼。");
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
