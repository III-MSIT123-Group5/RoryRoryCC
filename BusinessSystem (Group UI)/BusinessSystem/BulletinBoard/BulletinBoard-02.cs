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
    public partial class BulletinBoard_2 : Form
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
            int departmentID=0;
            int groupID=0;

            try
            {
                var q2 = from em in dbContext.Employees
                         where em.employeeID == ClassEmployee.LoginEmployeeID 
                         select new { em.GroupID,em.DepartmentID};

                foreach (var n in q2)
                {
                    departmentID = Convert.ToInt32(n.DepartmentID);
                    groupID = Convert.ToInt32(n.GroupID);
                }

     var q = new BusinessSystemDBEntityModel.BulletinBoard
                {
                    EmployeeID = ClassEmployee.LoginEmployeeID,
                    GroupID = groupID,
                    DepartmentID = departmentID,
                    PostTime = DateTime.Now,
                    Content = this.richTextBox1.Text
                };

                dbContext.BulletinBoards.Add(q);
                dbContext.SaveChanges();

                MessageBox.Show("張貼成功！");
                this.Close();
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



}
    }
}
