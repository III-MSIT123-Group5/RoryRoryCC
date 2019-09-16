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
            rectangleShape4.Location = new Point(10, 220);
            rectangleShape_MeetingRoom.Location = new Point(10, 430);
            rectangleShape_Car.Location = new Point(220, 430);
            rectangleShape1.Location = new Point(430, 10);
            rectangleShape2.Location = new Point(430, 220);
            rectangleShape_File.Location = new Point(430, 430);
            rectangleShape5.Location = new Point(640, 10);
            rectangleShape9.Location = new Point(640, 220);
            rectangleShape7.Location = new Point(640, 430);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Width = 870;
            Height = 680;
        }      
    }
}
