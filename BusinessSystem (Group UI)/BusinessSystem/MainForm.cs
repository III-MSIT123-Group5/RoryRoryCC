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
        int EmpNum;
        string photo;
        string name;

        public MainForm(int EmployeeID)
        {
            InitializeComponent();
            //測試靜態屬性LoginID ok

            ClassEmployee.LoginEmployeeID = EmployeeID;

            EmpNum = EmployeeID;

            BusinessDataBaseEntities dbContext;
            dbContext = new BusinessDataBaseEntities();

            var q = from em in dbContext.Employees
                    where em.employeeID == EmpNum
                    select new { em.EmployeeName, em.Photo };

            foreach (var p in q)
            {
                photo = p.Photo;
                name = p.EmployeeName;
            }
            mcEmployee.ImageLocation = photo;
            mcEmployee.Title = name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timeControl1.TimeText = DateTime.Now.ToString("hh:mm", CultureInfo.InstalledUICulture);
            this.timeControl1.SecondText = DateTime.Now.ToString("ss", CultureInfo.InstalledUICulture);
            this.timeControl1.AMText = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
            this.timeControl1.DateText = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InstalledUICulture);
        }

        //主控面>>員工連結
        private void mcEmployee_Click(object sender, EventArgs e)
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
        private void mcBulletinBoard_Click(object sender, EventArgs e)
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
        private void mcReportTime_Click(object sender, EventArgs e)
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
        private void mcDocument_Click(object sender, EventArgs e)
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
        private void mcCompanyCars_Click(object sender, EventArgs e)
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
        private void mcRequisition_Click(object sender, EventArgs e)
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

        //---------------------------------------------------------------------------------------------------

        //主控面>>滑鼠進入行事曆上
        private void mcCalendar_MouseEnter(object sender, EventArgs e)
        {
            mcCalendar.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開行事曆上
        private void mcCalendar_MouseLeave(object sender, EventArgs e)
        {
            mcCalendar.ButtonColor = Color.SteelBlue;
        }

        //主控面>>滑鼠進入員工上
        private void mcEmployee_MouseEnter(object sender, EventArgs e)
        {
            mcEmployee.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開員工上
        private void mcEmployee_MouseLeave(object sender, EventArgs e)
        {
            mcEmployee.ButtonColor = Color.FromArgb(153, 180, 209);
        }

        //主控面>>滑鼠進入佈告欄上
        private void mcBulletinBoard_MouseEnter(object sender, EventArgs e)
        {
            this.mcBulletinBoard.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開佈告欄上
        private void mcBulletinBoard_MouseLeave(object sender, EventArgs e)
        {
            this.mcBulletinBoard.ButtonColor = Color.SteelBlue;
        }

        //主控面>>滑鼠進入請假上
        private void mcLeave_MouseEnter(object sender, EventArgs e)
        {
            this.mcLeave.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開請假上
        private void mcLeave_MouseLeave(object sender, EventArgs e)
        {
            this.mcLeave.ButtonColor = Color.DarkSlateBlue;
        }

        //主控面>>滑鼠進入工時回報上
        private void mcReportTime_MouseEnter(object sender, EventArgs e)
        {
            this.mcReportTime.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開工時回報上
        private void mcReportTime_MouseLeave(object sender, EventArgs e)
        {
            this.mcReportTime.ButtonColor = Color.SlateGray;
        }

        //主控面>>滑鼠進入文件上傳上
        private void mcDocument_MouseEnter(object sender, EventArgs e)
        {
            this.mcDocument.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開文件上傳上
        private void mcDocument_MouseLeave(object sender, EventArgs e)
        {
            this.mcDocument.ButtonColor = Color.FromArgb(153, 180, 209);
        }

        //主控面>>滑鼠進入公務車租借上
        private void mcCompanyCars_MouseEnter(object sender, EventArgs e)
        {
            this.mcCompanyCars.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開公務車租借上
        private void mcCompanyCars_MouseLeave(object sender, EventArgs e)
        {
            this.mcCompanyCars.ButtonColor = Color.DarkSlateBlue;
        }

        //主控面>>滑鼠進入會議室租借上
        private void mcMeetingRoom_MouseEnter(object sender, EventArgs e)
        {
            this.mcMeetingRoom.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開會議室租借上
        private void mcMeetingRoom_MouseLeave(object sender, EventArgs e)
        {
            this.mcMeetingRoom.ButtonColor = Color.SlateGray;
        }

        //主控面>>滑鼠進入請購系統上
        private void mcRequisition_MouseEnter(object sender, EventArgs e)
        {
            this.mcRequisition.ButtonColor = Color.LightSkyBlue;
        }

        //主控面>>滑鼠離開請購系統上
        private void mcRequisition_MouseLeave(object sender, EventArgs e)
        {
            this.mcRequisition.ButtonColor = Color.SteelBlue;
        }

    }
}

