using BusinessSystem.CompanyCars;
using BusinessSystem.DocumentManagement;
using BusinessSystem.EmployeeSystem;
using BusinessSystem.ReportTimeSystem;
using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessSystem
{
    public partial class MainForm : Form
    {
        int EmpNum , groupID , posiID;
        string photo;
        string name;

        public MainForm(/*int EmployeeID*/)
        {
            //測試靜態屬性LoginID ok

            //ClassEmployee.LoginEmployeeID = EmpNum = EmployeeID;

            LoginForm lf = new LoginForm();
            lf.ShowDialog();
            
            if (ClassEmployee.LoginEmployeeID == 0)
            {
                this.Close();
            }
            else
            {
                EmpNum = ClassEmployee.LoginEmployeeID;
            }

            InitializeComponent();

            BusinessDataBaseEntities dbContext;
            dbContext = new BusinessDataBaseEntities();

            var q = from em in dbContext.Employees
                    where em.employeeID == EmpNum
                    select new { em.EmployeeName, em.Photo , em.GroupID, em.PositionID   };

            foreach (var p in q)
            {
                photo = p.Photo;
                name = p.EmployeeName;
                groupID = (int )p.GroupID;
                posiID =(int ) p.PositionID;
            }
            btnEmployee.ImageLocation = photo;
            btnEmployee.Title = name;

            //人資組長才有人資管理鈕
            if (groupID == 2  && posiID ==3 )    
            {
                this.btnHRSystem.Visible = true;
            }
            else 
            {
                this.btnHRSystem.Visible = false;
            }
        }

        //主控面>>時間
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timeControl1.TimeText = DateTime.Now.ToString("hh:mm", CultureInfo.InstalledUICulture);
            this.timeControl1.SecondText = DateTime.Now.ToString("ss", CultureInfo.InstalledUICulture);
            this.timeControl1.AMText = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
            this.timeControl1.DateText = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InstalledUICulture);
        }

        //主控面>>員工連結
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ProfileForm p = new ProfileForm();
                p.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //主控面>>佈告欄連結
        private void btnBulletinBoard_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BulletinBoard formshow = new BulletinBoard(EmpNum);
                formshow.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //主控面>>工時回報連結
        private void btnReportTime_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                FormMainRTS formshow = new FormMainRTS();
                formshow.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //主控面>>文件上傳連結
        private void btnDocument_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                FrmFileBrowsing file = new FrmFileBrowsing(EmpNum);
                file.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //主控面>>公務車租借連結
        private void btnCompanyCars_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                CompanyVehicleBorrowForm formshow = new CompanyVehicleBorrowForm(EmpNum);
                formshow.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //主控面>>請購系統連結
        private void btnRequisition_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                FrmRequisition1 formshow = new FrmRequisition1(EmpNum);
                formshow.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        //主控面>>人資管理連結
        private void btnHRSystem_Click(object sender, EventArgs e)
        {
            CreateEmployeeForm ce = new CreateEmployeeForm();
            ce.Show();
        }

        //主控面>>登出連結
        private void mainControls2_Click(object sender, EventArgs e)
        {
            Application.Restart();
            this.Close();
        }

        //---------------------------------------------------------------------------------------------------

        //主控面>>滑鼠進入行事曆上
        private void btnCalendar_MouseEnter(object sender, EventArgs e)
        {
            btnCalendar.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開行事曆上
        private void btnCalendar_MouseLeave(object sender, EventArgs e)
        {
            btnCalendar.ButtonColor = Color.SteelBlue;
        }

        //主控面>>滑鼠進入員工上
        private void btnEmployee_MouseEnter(object sender, EventArgs e)
        {
            btnEmployee.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開員工上
        private void btnEmployee_MouseLeave(object sender, EventArgs e)
        {
            btnEmployee.ButtonColor = Color.FromArgb(153, 180, 209);
        }

        //主控面>>滑鼠進入佈告欄上
        private void btnBulletinBoard_MouseEnter(object sender, EventArgs e)
        {
            this.btnBulletinBoard.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開佈告欄上
        private void btnBulletinBoard_MouseLeave(object sender, EventArgs e)
        {
            this.btnBulletinBoard.ButtonColor = Color.SteelBlue;
        }

        //主控面>>滑鼠進入請假上
        private void btnLeave_MouseEnter(object sender, EventArgs e)
        {
            this.btnLeave.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開請假上
        private void btnLeave_MouseLeave(object sender, EventArgs e)
        {
            this.btnLeave.ButtonColor = Color.DarkSlateBlue;
        }

        //主控面>>滑鼠進入工時回報上
        private void btnReportTime_MouseEnter(object sender, EventArgs e)
        {
            this.btnReportTime.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開工時回報上
        private void btnReportTime_MouseLeave(object sender, EventArgs e)
        {
            this.btnReportTime.ButtonColor = Color.SlateGray;
        }

        //主控面>>滑鼠進入文件上傳上
        private void btnDocument_MouseEnter(object sender, EventArgs e)
        {
            this.btnDocument.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開文件上傳上
        private void btnDocument_MouseLeave(object sender, EventArgs e)
        {
            this.btnDocument.ButtonColor = Color.SlateGray;
        }
       
        //主控面>>滑鼠進入公務車租借上
        private void btnCompanyCars_MouseEnter(object sender, EventArgs e)
        {
            this.btnCompanyCars.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開公務車租借上
        private void btnCompanyCars_MouseLeave(object sender, EventArgs e)
        {
            this.btnCompanyCars.ButtonColor = Color.DarkSlateBlue;
        }

        //主控面>>滑鼠進入會議室租借上
        private void btnMeetingRoom_MouseEnter(object sender, EventArgs e)
        {
            this.btnMeetingRoom.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開會議室租借上
        private void btnMeetingRoom_MouseLeave(object sender, EventArgs e)
        {
            this.btnMeetingRoom.ButtonColor = Color.SlateGray;
        }
 
        //主控面>>滑鼠進入請購系統上
        private void btnRequisition_MouseEnter(object sender, EventArgs e)
        {
            this.btnRequisition.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開請購系統上
        private void btnRequisition_MouseLeave(object sender, EventArgs e)
        {
            this.btnRequisition.ButtonColor = Color.SteelBlue;
        }      

        //主控面>>滑鼠進入人資管理上
        private void btnHRSystem_MouseEnter(object sender, EventArgs e)
        {
            this.btnHRSystem.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開人資管理上
        private void btnHRSystem_MouseLeave(object sender, EventArgs e)
        {
            this.btnCompanyCars.ButtonColor = Color.DarkSlateBlue;
        }

      

        //主控面>>滑鼠進入登出上
        private void btnLogOut_MouseEnter(object sender, EventArgs e)
        {
            this.btnLogOut.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠進入登出上
        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            this.btnLogOut.ButtonColor = Color.FromArgb(153, 180, 209);
        }
    } 
}

