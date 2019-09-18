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
    public partial class BulletinBoard_2 : SonForm
    {
        public BulletinBoard_2()
        {
            InitializeComponent();
        }

        BusinessDataBaseEntities dbContext;

        private void BullitinBoard_2_Load(object sender, EventArgs e)
        {

        }

        private void altoButton2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = null;
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            dbContext = new BusinessDataBaseEntities();


            try
            {
                var q = new BusinessSystemDBEntityModel.BulletinBoard
                {
                    EmployeeID = 1009,
                    DepartmentID = 3,
                    GroupID = 2,
                    PostTime = DateTime.Now,
                    Content = this.richTextBox1.Text
                };

                dbContext.BulletinBoards.Add(q);
                dbContext.SaveChanges();

                MessageBox.Show("Succeed");
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



}
    }
}
