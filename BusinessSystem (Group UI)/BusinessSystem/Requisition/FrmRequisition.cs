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

        private void FrmRequisition_Load(object sender, EventArgs e)
        {
            dbContext = new BusinessDataBaseEntities();

            var report = from RC in this.dbContext.ReportCategories
                         join RM in this.dbContext.RequisitionMains on RC.ReportID equals RM.ReportID
                         join OD in this.dbContext.OrderDetails on RM.OrderID equals OD.OrderID
                         select new
                         {
                             ReportName = RC.ReportName,
                             ReportID = RM.ReportID,
                             OrderID = OD.OrderID,
                             OrderDetailID = OD.OrderDetailID,
                             EmployeeID=RM.EmployeeID,                             
                             ProductName = OD.ProductName,
                             UnitPrice = OD.UnitPrice,
                             Quantity = OD.Quantity,
                             TotalPrice = OD.TotalPrice,
                             Note = OD.Note
                         };

            dataGridView1.DataSource = report.ToList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {   
            dbContext = new BusinessDataBaseEntities();

            try
            {
                var newRequisitionMain = new RequisitionMain
                {
                    ReportID=2,
                    EmployeeID = 1008,
                };

                var newOrderDetail = new OrderDetail
                {
                    Note = txtNote.Text,
                    ProductName = txtProcductName.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    RequisitionMain = newRequisitionMain
                };

                this.dbContext.RequisitionMains.Add(newRequisitionMain);
                this.dbContext.OrderDetails.Add(newOrderDetail);
                this.dbContext.SaveChanges();

                FrmRequisition_Load(sender, e);

                MessageBox.Show("購案新增成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            dbContext = new BusinessDataBaseEntities();

            try
            {
                var report = (from RC in this.dbContext.ReportCategories
                              join RM in this.dbContext.RequisitionMains on RC.ReportID equals RM.ReportID
                              join OD in this.dbContext.OrderDetails on RM.OrderID equals OD.OrderID
                              where OD.ProductName == textBox1.Text                             
                              select OD).FirstOrDefault();

                report.ProductName = txtProcductName.Text;
                report.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                report.Quantity = int.Parse(txtQuantity.Text);
                report.Note = txtNote.Text;

                this.dbContext.SaveChanges();
                FrmRequisition_Load(sender, e);

                MessageBox.Show("購案更新成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }
    }
}
