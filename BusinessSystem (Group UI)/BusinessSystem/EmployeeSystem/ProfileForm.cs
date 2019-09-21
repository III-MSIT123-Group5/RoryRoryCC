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
    public partial class ProfileForm : SonForm 
    {
        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();

        public ProfileForm()
        {            
            var q = this.dbcontext.Employees.Where(p => p.employeeID == ClassEmployee.LoginEmployeeID).Select(p => p);
            InitializeComponent();
            foreach (var s in q)
            {
                this.Text = $"{s.EmployeeName }的個人檔案";
                this.txtEmployeeName.Text = s.EmployeeName;
                this.txtGender.Text =s.Gender  ;
                this.txtBirth.Text = ((DateTime)s.Birth).ToShortDateString();
                this.txtHireDate.Text = ((DateTime )s.HireDate).ToShortDateString ();
                this.txtAccount.Text = s.Account;
                this.txtOfficID.Text  =s.Office.office_name     ;
                this.txtDepartmentID.Text = s.Department.name;
                this.txtGroupID.Text = s.Group.GroupName;
                this.txtPositionID.Text = s.Position.position1;
                this.txtManagerID.Text = s.Employee2.EmployeeName;
                this.txtEmployed.Text = this.Emped((bool )s.Employed);
                this.txtPhotoAddress.Text = s.Photo;
                this.picbEmpPhoto.ImageLocation = s.Photo;
            }
        }

        //<<<<<<<<<<<<<<<<<<<方法
        
            string Emped(bool Employed)
        {
            string m_Emped = "在職中";
            if (Employed)
            {
                m_Emped = "在職中";
            }
            else
            {
                m_Emped = "已離職";
            }
            return m_Emped;
        }

        //方法>>>>>>>>>>>>>>>>>>>>


        private void clsAltoButton2_Click(object sender, EventArgs e)　　//btn：修改頭像
        {            
            this.txtPhotoAddress.Enabled = true;
            this.btnConfirmPhoto.Visible = true;
            this.txtPhotoAddress.Focus();
            this.txtPhotoAddress.SelectAll();
        }

        private void btnConfirmPhoto_Click(object sender, EventArgs e)     //btn：確認頭像
        {
            this.txtPhotoAddress.Enabled = false;
            this.btnConfirmPhoto.Visible = false;
            this.picbEmpPhoto.ImageLocation = this.txtPhotoAddress.Text;
            try
            {
                var QchangePhoto =( this.dbcontext.Employees.Where(p => p.employeeID == ClassEmployee.LoginEmployeeID).Select (p=>p)).FirstOrDefault ();

                QchangePhoto.Photo = this.picbEmpPhoto.ImageLocation;
            
                this.dbcontext.SaveChanges ( );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            ChangePasswordForm ch = new ChangePasswordForm();
            ch.ShowDialog();
        }
    }
}
