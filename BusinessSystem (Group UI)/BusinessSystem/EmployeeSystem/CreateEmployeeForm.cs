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
    public partial class CreateEmployeeForm :SonForm 
    {
        public CreateEmployeeForm()
        {
            InitializeComponent();
            
        }

        BusinessDataBaseEntities dbcontext;
        //int EmID;  //將於"變更員工資料"中顯示
        string AccountName;
         int  magID ;
        private void CreateEmployeeForm_Load(object sender, EventArgs e)
        {
            dbcontext = new BusinessDataBaseEntities();
            //預設Office combobox內容 
            this.cmbOfficeID.DataSource = dbcontext.Offices.OrderBy  (p=>p.officeID).Select(p => p.office_name ).Distinct ().ToList();
            this.cmbOfficeID.SelectedIndex = 1; 
            //預設Department combobox內容 // if index==0 , 值為總經理，departmentID應輸入 index+1 累推
            this.cmbDepartmentID.DataSource = dbcontext.Departments.OrderBy(p => p.departmentID).Select(p => p.name).ToList();
            //預設Employed combobox內容
            this.cmbEmployed.SelectedIndex = 1; // index 1 為"在職" 應輸入 1，index 0 為"離職" 應輸入 0
            //預設Position ID內容 // if index==0 , 值為General manager，positionID應輸入 index+1 累推
            this.cmbPositionID.DataSource = dbcontext.Positions.OrderBy(p => p.positionID).Select(p => p.position1).ToList();
            //顯示EmployeeID
            var q = from em in dbcontext.Employees
                    select em;
            //預設GroupID內容
                //this.cmbGroupID.DataSource =this.dbcontext.Groups.OrderBy (p=>p.GroupID ).

            //=====================================
            //EmID = q.Count()+1001;      //將於"變更員工資料"中顯示
            //this.txtEmployeeID.Text = $"{EmID }"; //ID自動產生，不允許變更
            //=====================================
            this.txtAccount.MaxLength = 12; //txtAccount最大值

        }

        private void btnCreate_Click(object sender, EventArgs e) //btn 新增
        {
            if ((this.txtManagerID.Text is null) ==false) //判斷ManagerID是否為空值
            {
                int m_magID = 0;
                bool chkMagInput = int.TryParse(this.txtManagerID.Text, out m_magID); //確認輸入值ok
                                                                                      //確認managerID輸入的ID在employee內有資料
                var q = this.dbcontext.Employees.Where(p => p.employeeID == m_magID).Select(p => new { p.employeeID }).Any();

                if (chkMagInput && q)
                {
                    magID = m_magID;
                }
                else
                {
                    MessageBox.Show("請輸入正確的主管EmployeeID。", "請輸入正確的ManagerID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtManagerID.Focus();
                    this.txtManagerID.SelectAll();                    
                    return;
                }
            }
            


            var addEmp = new BusinessSystemDBEntityModel.Employee
            {
                //employeeID = EmID,   //將於"變更員工資料"中顯示
                employee_name = this.txtEmployeeName.Text,
                gender = this.cmbGender.Text,
                birth = this.dTPicBirth.Value,
                hire_date = this.dTPicHireDate.Value,
                account = AccountName,
                officeID = this.offID(this.cmbOfficeID.SelectedIndex),
                departmentID = this.cmbDepartmentID.SelectedIndex,
                positionID = this.cmbPositionID.SelectedIndex + 1,
                managerID = magID,
                employed = this.transEmployed(this.cmbEmployed.SelectedIndex),
                //groupID =
            };
        }      

        private void btnCheckAccount_Click(object sender, EventArgs e)    //檢查帳號
        {
            if (String.IsNullOrEmpty (this.txtAccount.Text ))
            {
                MessageBox.Show("請輸入正確的資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtAccount.Focus();                
            }
            else if (this.checkAccount (this.txtAccount .Text))
            {
                MessageBox.Show  ("此帳號可以使用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.btnCreate .Enabled = true;
                AccountName = this.txtAccount.Text.Replace(" ", "");   //清除字串中的空格
            }
            else
            {
                MessageBox.Show("此帳號已被使用！請嚐試別組帳號！", "提示", MessageBoxButtons.OK , MessageBoxIcon.Error );
                this.txtAccount.Focus();
            }
        }

        bool transEmployed (int @cmbEmpoyedIndex)
        {
            bool f = false;
            switch ( cmbEmpoyedIndex)
            {
                case 0:
                    f = false;
                    break;
                case 1:
                    f = true;
                    break;
            }
            return f;
        }

        bool   checkAccount(string @account)    //檢查帳號的方法
        {
            var q = from ac in dbcontext.Employees
                    where ac.account == @account
                    select ac;
            if (q.Any()  )
            {
                return false ;
            }
            else
            {
                return true ;
            }
        }

      int  offID (int cmbOfiiceIndex)   //officeID轉資料
        {
            int result = 1;
            if (cmbOfiiceIndex == 1)
            {
                result = 1;
            }              
            if (cmbOfiiceIndex == 0)
            {
                result = 2;
            }
            return result;
        }
       

    }
}
