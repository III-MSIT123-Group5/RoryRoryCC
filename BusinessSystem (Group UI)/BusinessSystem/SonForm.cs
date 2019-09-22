using BusinessSystem.EmployeeSystem;
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

namespace BusinessSystem
{
    public partial class SonForm : Form
    {
        
        private int M_LoginID;
        public int LoginID
        {
            get
            {
                return M_LoginID;
            }
            set
            {
                M_LoginID = value;
            }
        }
        public SonForm()
        {
            InitializeComponent();
        }
        public SonForm(int empID)
        {
            InitializeComponent();
            LoginID = empID;
        }
        string name = null;
        string gender = null;
        string photo = null;


        private void SonForm_Load(object sender, EventArgs e)
        {
            BusinessDataBaseEntities dbContext;
            dbContext = new BusinessDataBaseEntities();
            var q = from em in dbContext.Employees
                    where em.employeeID == ClassEmployee.LoginEmployeeID  
                    select new { em.EmployeeName, em.Gender, em.Photo };

            foreach (var n in q)
            {
                name = n.EmployeeName;
                gender = n.Gender;
                photo = n.Photo;
            }

            label3.Text = name;

            if (gender == "M")
            {
                label4.Text = "先 生";
            }
            else
            {
                label4.Text = "小 姐";
            }

            pictureBox2.ImageLocation = photo;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProfileForm pf = new ProfileForm();
            pf.Show();
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show ($"確定登出 {name} 的帳號？","登出", MessageBoxButtons.YesNo ,MessageBoxIcon.Question )==DialogResult.Yes)
            {
                Application.Restart();
                this.Close();
            }
        }
    }
}
