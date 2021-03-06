﻿using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        public int EmpID;
        public string EmpName;

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BusinessDataBaseEntities dbContext;

                dbContext = new BusinessDataBaseEntities();

                byte[] bytesPassword = Encoding.Unicode.GetBytes(this.txtLoginPassword.Text);
                SHA256Managed Algorithm = new SHA256Managed();
                byte[] validPassword = Algorithm.ComputeHash(bytesPassword);

                var q = from em in dbContext.Employees
                        join a in dbContext.Accounts
                        on em.Account equals a.account1
                        where em.Account == this.txtLoginAccount.Text && a.password == validPassword
                        select new { a.account1, a.password, em.employeeID, em.EmployeeName };

                foreach (var v in q)
                {
                    EmpID = v.employeeID;
                    EmpName = v.EmployeeName;
                }

                if (q.Any())
                {
                    //readname.EmpAcount = this.txtLoginAccount.Text;//擷取登入者姓名 (Kai)

                    MessageBox.Show($"歡迎回來， {EmpName}!", "登入成功", MessageBoxButtons.OK);

                    //MessageBox.Show(readname.EmpAcount);//測試
                    //MainForm main = new MainForm(EmpID);
                    //main.Show();
                    ClassEmployee.LoginEmployeeID = EmpID;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"請重新登入", "登入失敗", MessageBoxButtons.OK);
                    this.txtLoginPassword.Text = "";
                    this.txtLoginPassword.Focus();
                    ClassEmployee.LoginEmployeeID = 0;
                }
            }
            finally
            {                
                this.Cursor = Cursors.Default;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請尋求IT人員協助重設密碼。");
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            this.txtLoginAccount.Text = "reshinfang";
            this.txtLoginPassword.Text = "123456";
        }

        private void clsAltoButton3_Click(object sender, EventArgs e)
        {
            this.txtLoginAccount.Text = "mary";
            this.txtLoginPassword.Text = "123456";
        }
    }
}
