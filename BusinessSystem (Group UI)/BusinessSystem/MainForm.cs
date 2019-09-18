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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmRequisition frmRequisition = new FrmRequisition();
            frmRequisition.Show();
        }

        private void mainControls1_Load(object sender, EventArgs e)
        {

        }
    }
}
