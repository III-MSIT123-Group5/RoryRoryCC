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
                    select new { em.EmployeeName,em.Photo};


            foreach (var p in q)
            {
                photo = p.Photo;
                name = p.EmployeeName;
            }            
            employeeControl1.ImageLocation = photo;            
            employeeControl1.Title = name;
        }
        
        int EmpNum;
        string photo;
        string name;

        private void MainForm_Load(object sender, EventArgs e)
        {


        }

        private void mainControls4_Click(object sender, EventArgs e)
        {
            BulletinBoard formshow = new BulletinBoard(EmpNum );
            formshow.ShowDialog();
        }

        private void mainControls3_Click(object sender, EventArgs e)
        {
            FormMainRTS formshow = new FormMainRTS();
            formshow.ShowDialog();
        }

        private void mainControls2_Click(object sender, EventArgs e)
        {
            CompanyVehicleBorrowForm formshow = new CompanyVehicleBorrowForm(EmpNum);
            formshow.ShowDialog();
        }

        private void mainControls9_Click(object sender, EventArgs e)
        {
            FrmRequisition1 formshow = new FrmRequisition1(EmpNum);
            formshow.ShowDialog();
        }

        private void mainControls9_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls9.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls9_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls9.ButtonColor = Color.DarkBlue;
        }

     

        private void mainControls10_Click(object sender, EventArgs e)
        {
            
        }


        private void mainControls6_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void mainControls6_Click(object sender, EventArgs e)
        {

        }

        private void employeeControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EmpNum.ToString());
            MessageBox.Show("靜態logID測試"+ClassEmployee.LoginEmployeeID );
        }

        private void mainControls3_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls3.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls3_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls3.ButtonColor = Color.SlateGray;
        }

        private void mainControls8_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls8.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls8_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls8.ButtonColor = Color.DarkSlateBlue;
        }

        private void mainControls1_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls1.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls1_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls1.ButtonColor = Color.SlateGray;
        }

        private void mainControls2_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls2.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls2_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls2.ButtonColor = Color.DarkSlateBlue;
        }

        private void mainControls7_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls7.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls7_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls7.ButtonColor = Color.FromArgb(153,180,209);
        }

        private void mainControls4_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls4.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls4_MouseLeave(object sender, EventArgs e)
        {
            this.mainControls4.ButtonColor = Color.SteelBlue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timeControl1.TimeText = DateTime.Now.ToString("hh:mm", CultureInfo.InstalledUICulture);
            this.timeControl1.SecondText = DateTime.Now.ToString("ss", CultureInfo.InstalledUICulture);
            this.timeControl1.AMText = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
            this.timeControl1.DateText = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InstalledUICulture);
        }

        private void employeeControl1_MouseEnter(object sender, EventArgs e)
        {
            employeeControl1.ButtonColor = Color.LightSkyBlue;
        }

        private void employeeControl1_MouseLeave(object sender, EventArgs e)
        {
            employeeControl1.ButtonColor = Color.FromArgb(153, 180, 209);
        }

        private void mainControls5_MouseEnter(object sender, EventArgs e)
        {
            mainControls5.ButtonColor = Color.LightSkyBlue;
        }

        private void mainControls5_MouseLeave(object sender, EventArgs e)
        {
            mainControls5.ButtonColor = Color.SteelBlue;
        }

        private void mainControls7_Click(object sender, EventArgs e)
        {
            FrmFileBrowsing file = new FrmFileBrowsing(EmpNum);
            file.Show();
        }

        private void mainControls9_Load(object sender, EventArgs e)
        {

        }       
    }
}
