using BusinessSystem.CompanyCars;
using BusinessSystem.ReportTimeSystem;
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
        public MainForm()
        {
            InitializeComponent();

            rectangleShape_date.Location = new Point(10, 10);           
            //rectangleShape_messange.Location = new Point(10, 220);
         
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void mainControls4_Click(object sender, EventArgs e)
        {
            BulletinBoard_2 formshow = new BulletinBoard_2();
            formshow.ShowDialog();
        }

        private void mainControls3_Click(object sender, EventArgs e)
        {
            FormMainRTS formshow = new FormMainRTS();
            formshow.ShowDialog();
        }

        private void mainControls2_Click(object sender, EventArgs e)
        {
            CompanyVehicleBorrowForm formshow = new CompanyVehicleBorrowForm();
            formshow.ShowDialog();
        }

        private void mainControls9_Click(object sender, EventArgs e)
        {
            FrmRequisition formshow = new FrmRequisition();
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

      
    }
}
