using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessSystem.companycars
{
    public partial class text123 : Form
    {
        public text123()
        {
            InitializeComponent();
        }
        BusinessDataBaseEntities context = new BusinessDataBaseEntities(); 
        private void button1_Click(object sender, EventArgs e)
        {
            var q = from p in context.CompanyVehicles
                    select p;
            List<CompanyVehicle> pphoto = q.ToList();
            MemoryStream ppic = new MemoryStream(pphoto[1].VehiclePhoto);
            this.pictureBox1.Image = Image.FromStream(ppic);
        }
    }
}
