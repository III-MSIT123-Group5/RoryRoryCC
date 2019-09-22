using BusinessSystem.EmployeeSystem;
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

namespace BusinessSystem
{
    public partial class CreateEmployeeForm : Form
    {
        public CreateEmployeeForm()
        {
            InitializeComponent();

        }
        MemberClass CheckTextboxClass = new MemberClass();
        BusinessDataBaseEntities dbcontext;
        //int EmID;  //將於"變更員工資料"中顯示
        string AccountName, EmployeeName;
        int magID ;
        bool AccEmpName, AccAcount;
        byte[] SHAPassword;


        private void CreateEmployeeForm_Load(object sender, EventArgs e)   //load事件
        {
            dbcontext = new BusinessDataBaseEntities();
            //預設Office combobox內容 
            this.cmbOfficeID.DataSource = dbcontext.Offices.OrderBy(p => p.officeID).Select(p => p.office_name).Distinct().ToList();
            this.cmbOfficeID.SelectedIndex = 1;
            //預設Department combobox內容 // if index==0 , 值為總經理，departmentID應輸入 index+1 累推
            this.cmbDepartmentID.DataSource = dbcontext.Departments.OrderBy(p => p.departmentID).Select(p => p.name).ToList();
            //預設Employed combobox內容
            this.cmbEmployed.SelectedIndex = 1; // index 1 為"在職" 應輸入 1，index 0 為"離職" 應輸入 0
             //顯示EmployeeID
            var q = from em in dbcontext.Employees
                    select em;            

            this.cmbGender.SelectedIndex = 0;          

            //=====================================
            //EmID = q.Count()+1001;      //將於"變更員工資料"中顯示
            //this.txtEmployeeID.Text = $"{EmID }"; //ID自動產生，不允許變更
            //=====================================
            this.txtAccount.MaxLength = 12; //txtAccount最大值
        }

        //todo<<<<<<<<<<<<<<<<<<<<<<<<<控制項

        private void btnClearAll_Click(object sender, EventArgs e)      //事件：ClearAll
        {
            this.txtEmployeeName.Text = null;
            this.txtPassword.Text = null;
            this.txtConfirmPassword.Text = null;
            this.txtAccount.Text = null;
        }

        private void btnCreatAccount_Click(object sender, EventArgs e)    //按鈕:新增
        {
            //確認各欄位是否為空值
            if (AccEmpName == false || AccAcount == false || string.IsNullOrEmpty(this.cmbManagerID.Text))
            {
                MessageBox.Show("資料未完整輸入");
                return;
            }
            //確認密碼正確性 & 空值
            if (CheckPassword(this.txtPassword.Text, this.txtConfirmPassword.Text) && String.IsNullOrEmpty(this.txtConfirmPassword.Text) == false)
            {
                //雜湊
                byte[] bytesPassword = Encoding.Unicode.GetBytes(this.txtConfirmPassword.Text);
                SHA256Managed Algorithm = new SHA256Managed();
                SHAPassword = Algorithm.ComputeHash(bytesPassword);
            }
            else
            {
                MessageBox.Show("請確認[密碼]及[確認密碼]的。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassword.Text = "";
                this.txtConfirmPassword.Text = "";
                this.txtPassword.Focus();
                return;
            }

            try
            {
                var addEmp = new BusinessSystemDBEntityModel.Employee
                {
                    //employeeID = EmID,   //將於"變更員工資料"中顯示
                    EmployeeName = this.EmployeeName,
                    Gender = this.cmbGender.Text,
                    Birth = this.dTPicBirth.Value,
                    HireDate = this.dTPicHireDate.Value,
                    Account = AccountName,
                    OfficeID = this.Insert_offID(this.cmbOfficeID.SelectedIndex),
                    DepartmentID = this.cmbDepartmentID.SelectedIndex,
                    PositionID = this.cmbPositionID.SelectedIndex + 1,
                    ManagerID = int.Parse(this.cmbManagerID.Text),
                    Employed = this.Insert_transEmployed(this.cmbEmployed.SelectedIndex),
                    GroupID = this.Insert_grpID(this.cmbGroupID.Text),
                    Photo = PhotoAddress(this.cmbGender.Text)
                };
                var addAccount = new BusinessSystemDBEntityModel.Account
                {
                    account1 = addEmp.Account,
                    password = SHAPassword,
                };
                this.dbcontext.Accounts.Add(addAccount);
                this.dbcontext.Employees.Add(addEmp);

                this.dbcontext.SaveChanges();

                MessageBox.Show("新增成功");
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

       

        //控制項>>>>>>>>>>>>>>>>>>>>>>>>>

        //todo<<<<<<<<<<<<<<<<<<<<<<<<<方法

        string  PhotoAddress (string GenderText )         //新增Photo
        {
            string m_address = "";
            switch (GenderText)
            {
                case "F":
                    m_address = "https://icon-icons.com/icons2/2061/PNG/512/happy_consumer_people_man_icon_124583.png";
                        break;
                case "M":
                    m_address = "https://icon-icons.com/icons2/2061/PNG/512/happy_consumer_people_man_icon_124583.png";
                        break;
            }
            return  m_address;
        }

        bool Insert_transEmployed(int @cmbEmpoyedIndex) 　//方法：從cmbEmployedIndex轉成可存入的資料
        {
            bool f = false;
            switch (cmbEmpoyedIndex)
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

        bool checkAccount(string @account)    //方法：檢查帳號是否重覆
        {
            var q = from ac in dbcontext.Employees
                    where ac.Account == @account
                    select ac;
            if (q.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        int Insert_offID(int cmbOfiiceIndex)   //方法：officeID轉成可存入的資料
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

        int Insert_grpID(string cmbGroupIDText)    //方法：將輸入值轉為可存入SQL的資料
        {
            int m_groupid = 0;
            switch (cmbGroupIDText)
            {
                case "無組別":
                    m_groupid = 0;
                        break;
                case "總務組":
                    m_groupid =1 ;
                    break;
                case "人資組":
                    m_groupid =2 ;
                    break;
                case "行政部室":
                    m_groupid =3 ;
                    break;
                case "業務部室":
                    m_groupid =4 ;
                    break;
                case "產品部室":
                    m_groupid =5 ;
                    break;
                case "財務部室":
                    m_groupid =6 ;
                    break;
                case "資訊部室":
                    m_groupid = 7;
                    break;
                case "總經理室":
                    m_groupid = 8 ;
                    break;
            }
            return m_groupid;
            //var q = this.dbcontext.Groups.Where(p => p.GroupName == cmbGroupIDText).Select(p => p.GroupID);
            //return q.FirstOrDefault();
        }        

        bool CheckPassword (string password,string ConfirmPassword)    //方法：檢查Password
        {
            bool result = false;
            if (password == ConfirmPassword)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }    
                
        //方法>>>>>>>>>>>>>>>>>>>>>>>>>

        //todo<<<<<<<<<<<<<<<<<<<<<<<<<事件

        private void cmbDepartmentID_TextChanged(object sender, EventArgs e)   //事件：產生cmbGroupID
        {
            var q = this.dbcontext.Groups.Where(p => p.DepartmentID == this.cmbDepartmentID.SelectedIndex).Select(p => p.GroupName);
            if (q.Any())
            {
                this.cmbGroupID.DataSource = q.ToList();
            }
            else
            {
                var q1 = this.dbcontext.Groups.Where(p => p.DepartmentID == 0).Select(p => p.GroupName);
                this.cmbGroupID.DataSource = q1.ToList();
            }
        }       

        private void txtEmployeeName_Validated(object sender, EventArgs e)   //事件：EmployeeName空值驗證
        {
            this.CheckTextboxClass.EmployeeName = this.txtEmployeeName.Text; 
            errorProvider1.SetError((TextBox)sender, CheckTextboxClass.errorstring);
            if (errorProvider1.GetError((TextBox)sender) == "")
            {
                this.EmployeeName = this.txtEmployeeName.Text;
                this.AccEmpName = true;
            }
            else
            {
                this.AccEmpName = false ;
            }
        }       

        private void txtAccount_Validated(object sender, EventArgs e)  //事件：帳號驗證
        {
            AccountName = this.txtAccount.Text.Replace(" ", "");
            this.CheckTextboxClass.Account = AccountName;

            errorProvider1.SetError((TextBox)sender, CheckTextboxClass.errorstring);
            if (errorProvider1.GetError((TextBox)sender )== "")
            {
                this.AccAcount = true;
            }
            else
            {
                this.AccAcount = false ;
            }
        }

        //todo事件：自動帶入直屬主管ManagerID
        private void cmbPositionID_MouseClick(object sender, MouseEventArgs e) //事件：自動帶入直屬主管ManagerID
        {
            switch (this.cmbPositionID.SelectedIndex)
            {
                case 3:     //員工
                    var QposiEmp = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                   && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    if (QposiEmp.Any())
                    {
                        this.cmbManagerID.DataSource = QposiEmp.ToList();
                    }
                    else
                    {
                        var QposiEmpNonCap = from f in this.dbcontext.Employees.AsEnumerable()
                                             where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                             && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                             && f.PositionID == this.cmbPositionID.SelectedIndex - 1    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                             select f.employeeID;
                        this.cmbManagerID.DataSource = QposiEmpNonCap.ToList();
                    }                   
                    break;
                case 2:    //組長
                    var QposiSup = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiSup.ToList();
                    break;
                case 1:  //部長
                    var QposiDir = from f in this.dbcontext.Employees.AsEnumerable()
                                   where  f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiDir.ToList();               
                    break;
                case 0://總經理
                    var QposiGM = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.PositionID ==0    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;                   
                    this.cmbManagerID.DataSource = QposiGM.ToList();                    
                    break;
            }
        }               

        private void cmbDepartmentID_MouseClick(object sender, MouseEventArgs e)
        {
            switch (this.cmbPositionID.SelectedIndex)
            {
                case 3:     //員工
                    var QposiEmp = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                   && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    if (QposiEmp.Any())
                    {
                        this.cmbManagerID.DataSource = QposiEmp.ToList();
                    }
                    else
                    {
                        var QposiEmpNonCap = from f in this.dbcontext.Employees.AsEnumerable()
                                             where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                             && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                             && f.PositionID == this.cmbPositionID.SelectedIndex - 1    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                             select f.employeeID;
                        this.cmbManagerID.DataSource = QposiEmpNonCap.ToList();
                    }
                    break;
                case 2:    //組長
                    var QposiSup = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiSup.ToList();
                    break;
                case 1:  //部長
                    var QposiDir = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiDir.ToList();

                    break;
                case 0://總經理
                    var QposiGM = from f in this.dbcontext.Employees.AsEnumerable()
                                  where f.PositionID == 0    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                  select f.employeeID;
                    this.cmbManagerID.DataSource = QposiGM.ToList();
                    break;
            }
        }

        private void cmbGroupID_MouseClick(object sender, MouseEventArgs e)
        {
            switch (this.cmbPositionID.SelectedIndex)
            {
                case 3:     //員工
                    var QposiEmp = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                   && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    if (QposiEmp.Any())
                    {
                        this.cmbManagerID.DataSource = QposiEmp.ToList();
                    }
                    else
                    {
                        var QposiEmpNonCap = from f in this.dbcontext.Employees.AsEnumerable()
                                             where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                             && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                             && f.PositionID == this.cmbPositionID.SelectedIndex - 1    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                             select f.employeeID;
                        this.cmbManagerID.DataSource = QposiEmpNonCap.ToList();
                    }
                    break;
                case 2:    //組長
                    var QposiSup = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiSup.ToList();
                    break;
                case 1:  //部長
                    var QposiDir = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiDir.ToList();

                    break;
                case 0://總經理
                    var QposiGM = from f in this.dbcontext.Employees.AsEnumerable()
                                  where f.PositionID == 0    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                  select f.employeeID;
                    this.cmbManagerID.DataSource = QposiGM.ToList();
                    break;
            }
        }

        private void cmbGroupID_TextChanged(object sender, EventArgs e)
        {
            switch (this.cmbPositionID.SelectedIndex)
            {
                case 3:     //員工
                    var QposiEmp = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                   && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    if (QposiEmp.Any())
                    {
                        this.cmbManagerID.DataSource = QposiEmp.ToList();
                    }
                    else
                    {
                        var QposiEmpNonCap = from f in this.dbcontext.Employees.AsEnumerable()
                                             where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                             && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                             && f.PositionID == this.cmbPositionID.SelectedIndex - 1    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                             select f.employeeID;
                        this.cmbManagerID.DataSource = QposiEmpNonCap.ToList();
                    }
                    break;
                case 2:    //組長
                    var QposiSup = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiSup.ToList();
                    break;
                case 1:  //部長
                    var QposiDir = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiDir.ToList();

                    break;
                case 0://總經理
                    var QposiGM = from f in this.dbcontext.Employees.AsEnumerable()
                                  where f.PositionID == 0    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                  select f.employeeID;
                    this.cmbManagerID.DataSource = QposiGM.ToList();
                    break;
            }
        }

        private void cmbPositionID_DataSourceChanged(object sender, EventArgs e)
        {
            switch (this.cmbPositionID.SelectedIndex)
            {
                case 3:     //員工
                    var QposiEmp = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                   && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    if (QposiEmp.Any())
                    {
                        this.cmbManagerID.DataSource = QposiEmp.ToList();
                    }
                    else
                    {
                        var QposiEmpNonCap = from f in this.dbcontext.Employees.AsEnumerable()
                                             where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                             && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                             && f.PositionID == this.cmbPositionID.SelectedIndex - 1    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                             select f.employeeID;
                        this.cmbManagerID.DataSource = QposiEmpNonCap.ToList();
                    }
                    break;
                case 2:    //組長
                    var QposiSup = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiSup.ToList();
                    break;
                case 1:  //部長
                    var QposiDir = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiDir.ToList();

                    break;
                case 0://總經理
                    var QposiGM = from f in this.dbcontext.Employees.AsEnumerable()
                                  where f.PositionID == 0    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                  select f.employeeID;
                    this.cmbManagerID.DataSource = QposiGM.ToList();
                    break;
            }
        }
        

        private void cmbPositionID_TextChanged(object sender, EventArgs e)
        {
            switch (this.cmbPositionID.SelectedIndex)
            {
                case 3:     //員工
                    var QposiEmp = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                   && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    if (QposiEmp.Any())
                    {
                        this.cmbManagerID.DataSource = QposiEmp.ToList();
                    }
                    else
                    {
                        var QposiEmpNonCap = from f in this.dbcontext.Employees.AsEnumerable()
                                             where f.GroupID == this.Insert_grpID(this.cmbGroupID.Text)
                                             && f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                             && f.PositionID == this.cmbPositionID.SelectedIndex - 1    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                             select f.employeeID;
                        this.cmbManagerID.DataSource = QposiEmpNonCap.ToList();
                    }
                    break;
                case 2:    //組長
                    var QposiSup = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.DepartmentID == this.cmbDepartmentID.SelectedIndex
                                   && f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiSup.ToList();
                    break;
                case 1:  //部長
                    var QposiDir = from f in this.dbcontext.Employees.AsEnumerable()
                                   where f.PositionID == this.cmbPositionID.SelectedIndex    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                   select f.employeeID;
                    this.cmbManagerID.DataSource = QposiDir.ToList();

                    break;
                case 0://總經理
                    var QposiGM = from f in this.dbcontext.Employees.AsEnumerable()
                                  where f.PositionID == 0    //cmbPositionID.SelectedIndex+1才是該員的職稱
                                  select f.employeeID;
                    this.cmbManagerID.DataSource = QposiGM.ToList();
                    break;
            }
        }     
        //ManagerID=========================        
        
        private void cmbGroupID_DataSourceChanged(object sender, EventArgs e)
        {
            this.cmbPositionID.DataSource = dbcontext.Positions.OrderBy(p => p.positionID).Select(p => p.position1).ToList();
            this.cmbPositionID.SelectedIndex = 3;
        }   //事件：預設Position ID內容 // if index==0 , 值為General manager，positionID應輸入 index+1 累推

        //事件>>>>>>>>>>>>>>>>>>>>>>>>>






    }
}
