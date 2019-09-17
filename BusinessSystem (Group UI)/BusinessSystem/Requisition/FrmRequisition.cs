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
    public partial class FrmRequisition : SonForm
    {
        public FrmRequisition()
        {
            InitializeComponent();                
        }

        BusinessDataBaseEntities dbContext;

        private void altoButton1_Click(object sender, EventArgs e)
        {

            dbContext = new BusinessDataBaseEntities();

            try
            {
                var q = new RequisitionChild
                {   
                    //RequisitionID=100
                    ProductName = textBox1.Text,
                    UnitPrice = decimal.Parse(textBox2.Text),
                    Quantity = decimal.Parse(textBox3.Text),
                    Discount = decimal.Parse(textBox4.Text),
                    Note = textBox5.Text
                };

                dbContext.RequisitionChilds.Add(q);
                dbContext.SaveChanges();

                MessageBox.Show("XXXX");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            dbContext = new BusinessDataBaseEntities();

            var q = from RM in dbContext.RequisitionMains
                    from RC in dbContext.RequisitionChilds
                    select new
                    {
                        ReportID=RM.ReportID,
                        RequisitionID=RC.RequisitionID,
                        ProductName=RC.ProductName,

                    };
            dataGridView1.DataSource = q.ToList();



            //var q = from d in dbContext.Departments
            //        from g in d.Groups
            //        from b in g.BulletinBoards
            //        select new { GroupList = g.GroupName, b.GroupID, DepartmentList = d.name, b.DepartmentID, b.Content };

            //dataGridView1.DataSource = q.ToList();
        }
    }
}
