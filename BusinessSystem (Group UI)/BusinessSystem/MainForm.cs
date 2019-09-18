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
            rectangleShape_messange.Location = new Point(10, 220);
         
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Width = 870;
            Height = 680;
        }

        private void mainControls1_MouseClick(object sender, MouseEventArgs e)
        {
            FormMainRTS formshow =new FormMainRTS();
            formshow.ShowDialog();
        }

        private void mainControls5_Click(object sender, EventArgs e)
        {
           
        }

        private void mainControls5_MouseEnter(object sender, EventArgs e)
        {

        }

        private void mainControls1_Click(object sender, EventArgs e)
        {
            FrmRequisition formshow = new FrmRequisition();
            formshow.ShowDialog();
        }

        private void mainControls8_Click(object sender, EventArgs e)
        {
            FrmRequisition formshow = new FrmRequisition();
            formshow.ShowDialog();
        }
    }
}
