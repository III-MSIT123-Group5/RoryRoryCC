using BusinessSystemDBEntityModel;
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
    public partial class ChangePasswordForm : SonForm 
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
           
        }
        BusinessDataBaseEntities dbContext =  new BusinessDataBaseEntities();

        private void btnSumitNewPW_Click(object sender, EventArgs e)
        {           
            byte[] bytesPassword = Encoding.Unicode.GetBytes(this.txtOldPassword .Text );
            SHA256Managed Algorithm = new SHA256Managed();
            byte[] validPassword = Algorithm.ComputeHash(bytesPassword);

            var q = from pw in this.dbContext.Employees
                    where pw.employeeID == ClassEmployee.LoginEmployeeID && pw.Account1.password == validPassword
                    select pw;

            if (q.Any())
            {
                if (this.txtConfirmNewPassword.Text == this.txtNewPassword.Text)
                {
                    try
                    {
                        byte[] bytesNewPassword = Encoding.Unicode.GetBytes(this.txtConfirmNewPassword.Text);
                        SHA256Managed NewAlgorithm = new SHA256Managed();
                        byte[] NewPassword = NewAlgorithm.ComputeHash(bytesNewPassword);
                        q.FirstOrDefault().Account1.password = NewPassword;
                        dbContext.SaveChanges();
                        string EmpName = "0";
                        var Qname = this.dbContext.Employees.Where(p => p.employeeID == ClassEmployee.LoginEmployeeID).Select(p => new { p.EmployeeName });
                        foreach (var na in Qname)
                        {
                            EmpName = na.EmployeeName;
                        }                        

                        MessageBox.Show($"{EmpName} 的密碼更新成功，請重新登入！");
                        Application.Restart();
                        this.Close();
                                                                   
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                  
                }
                else
                {
                    MessageBox.Show("密碼驗證錯誤，請重新嘗試。");
                }
            }
            else
            {
                MessageBox.Show("舊密碼驗證錯誤，請重新嘗試。");
            }           
        }
    }
}
