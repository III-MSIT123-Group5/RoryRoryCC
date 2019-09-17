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

        private void CreateEmployeeForm_Load(object sender, EventArgs e)
        {
            dbcontext = new BusinessDataBaseEntities();
            //預設Office combobox內容 
            this.cmbOfficeID.DataSource = dbcontext.Offices.OrderBy  (p=>p.officeID).Select(p => p.office_name ).Distinct ().ToList();
            this.cmbOfficeID.SelectedIndex = 1;  // index 0 為Branch office ID應輸入 2，index 1 為Head office ID應輸入 1
            //預設Department combobox內容 // if index==0 , 值為總經理，departmentID應輸入 index+1 累推
            this.cmbDepartmentID.DataSource = dbcontext.Departments.OrderBy(p => p.departmentID).Select(p => p.name).ToList();
            //預設Employed combobox內容
            this.cmbEmployed.SelectedIndex = 1; // index 1 為"在職" 應輸入 1，index 0 為"離職" 應輸入 0
            //預設Position ID內容 // if index==0 , 值為General manager，positionID應輸入 index+1 累推
            this.cmbPositionID.DataSource = dbcontext.Positions.OrderBy(p => p.positionID).Select(p => p.position1).ToList();
            //顯示EmployeeID
            var q = from em in dbcontext.Employees
                    select em;
            this.txtEmployeeID.Text = $"{ q.Count() + 1001 }"; //ID自動產生，不允許變更


        }
    }
}
