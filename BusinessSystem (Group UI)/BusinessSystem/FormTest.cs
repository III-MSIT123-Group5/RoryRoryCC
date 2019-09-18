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
    public partial class FormTest : SonForm
    {
        public FormTest()
        {
            InitializeComponent();

            BusinessDataBaseEntities dbContext;
            dbContext = new BusinessDataBaseEntities();

            var q = from em in dbContext.Employees
                    where em.employeeID == 1001
                    select new { em.photo };

            //MessageBox.Show(q.First().photo);
            pictureBox2.ImageLocation = q.First().photo;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
