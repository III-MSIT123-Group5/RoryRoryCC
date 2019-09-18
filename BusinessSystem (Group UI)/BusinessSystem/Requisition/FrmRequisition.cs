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
                var newReportMain = new ReportMain
                {
                    ApplicantID = 1008,                    
                    ApplyDate=DateTime.Now     
                };

                var newRequisitionMain = new RequisitionMain
                {   
                    TotalPrice=2500,
                    ReportMain=newReportMain
                };

                var newRequisitionChild = new RequisitionChild
                {          
                    ProductName = textBox1.Text,
                    UnitPrice = decimal.Parse(textBox2.Text),
                    Quantity = decimal.Parse(textBox3.Text),
                    Discount = decimal.Parse(textBox4.Text),                   
                    Note = textBox5.Text,                    
                    RequisitionMain=newRequisitionMain                    
                };

                dbContext.RequisitionChilds.Add(newRequisitionChild);
                dbContext.SaveChanges();

                MessageBox.Show("購案新增成功");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            var q = from RM in this.dbContext.ReportMains
                    join RQM in this.dbContext.RequisitionMains on RM.ReportID equals RQM.ReportID
                    join RC in this.dbContext.RequisitionChilds on RQM.RequisitionID equals RC.RequisitionID
                    select new
                    {
                        EmployeeID=RM.ApplicantID,
                        ReportID = RQM.ReportID,
                        RequisitionID = RC.RequisitionID,
                        ProductName = RC.ProductName,
                        UnitPrice = RC.UnitPrice,
                        Quantity = RC.Quantity,
                        Dincount = RC.Discount,
                        Note = RC.Note
                    };

            dataGridView1.DataSource = q.ToList();
        }

        private void altoButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }
    }
}
