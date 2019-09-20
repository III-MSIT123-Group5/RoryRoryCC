using BusinessSystem.CompanyCars;
using BusinessSystem.EmployeeSystem;
using BusinessSystem.ReportTimeSystem;
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
    public partial class MainForm : Form
    {
        public MainForm(int EmployeeID)
        {
            InitializeComponent();

            rectangleShape_date.Location = new Point(10, 10);
            //rectangleShape_messange.Location = new Point(10, 220);

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

            mainControls6.ImageLocation = photo;
            mainControls6.Title = name;
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
            CompanyVehicleBorrowForm formshow = new CompanyVehicleBorrowForm(EmpNum );
            formshow.ShowDialog();
        }

        private void mainControls9_Click(object sender, EventArgs e)
        {
            FrmRequisition1 formshow = new FrmRequisition1();
            formshow.ShowDialog();
        }

        private void mainControls9_MouseEnter(object sender, EventArgs e)
        {
            this.mainControls9.ButtonColor = Color.Green;
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
            MessageBox.Show(EmpNum.ToString());
        }
    }
}
