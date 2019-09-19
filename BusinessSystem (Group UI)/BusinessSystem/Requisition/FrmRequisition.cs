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

         BusinessDataBaseEntities dbContext=new BusinessDataBaseEntities();

        private void FrmRequisition_Load(object sender, EventArgs e)
        {           

            var report = from OD in this.dbContext.OrderDetails
                         select new
                         {
                             請購單號=OD.OrderID,                         
                             產品名稱 = OD.ProductName,
                             單價 = OD.UnitPrice,
                             數量 = OD.Quantity,
                             總價 = OD.TotalPrice,
                             請購原因 = OD.Note
                         };

            dataGridView1.DataSource = report.ToList();
        }

        //新增
        private void btnSubmit_Click(object sender, EventArgs e)
        {  
            try
            {
                var newRequisitionMain = new RequisitionMain
                {
                    ReportID = 2,
                    EmployeeID = 1008
                };

                var newOrderDetail = new OrderDetail
                {
                    Note = txtNote.Text,
                    ProductName = txtProcductName.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = Convert.ToInt32(txtQuantity.Text),
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

        //修改
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            { 
                var report = (from RC in this.dbContext.ReportCategories.AsEnumerable()
                              join RM in this.dbContext.RequisitionMains.AsEnumerable() on RC.ReportID equals RM.ReportID
                              join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                              where OD.OrderID == Convert.ToInt32(textBox1.Text)
                              select OD).FirstOrDefault();

                report.ProductName = txtProcductName.Text;
                report.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                report.Quantity = Convert.ToInt32(txtQuantity.Text);
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
            try
            {
                var OrderDetails = from OD in this.dbContext.OrderDetails.AsEnumerable()
                                   where OD.RequisitionMain.OrderID == Convert.ToInt32(textBox1.Text)
                                   select OD;

                var RequisitionMain = (from RM in this.dbContext.RequisitionMains.AsEnumerable()
                                       where RM.ReportID == Convert.ToInt32(textBox1.Text)
                                       select RM).FirstOrDefault();
                foreach (OrderDetail OD in OrderDetails)
                {
                    this.dbContext.OrderDetails.Remove(OD);
                }
                this.dbContext.RequisitionMains.Remove(RequisitionMain);
                this.dbContext.SaveChanges();
                FrmRequisition_Load(sender, e);

                //var report = (from RC in this.dbContext.ReportCategories.AsEnumerable()
                //              join RM in this.dbContext.RequisitionMains.AsEnumerable() on RC.ReportID equals RM.ReportID
                //              join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                //              where OD.OrderID == int.Parse(textBox1.Text)
                //              select OD).FirstOrDefault();

                //this.dbContext.OrderDetails.Remove(report);                
                //this.dbContext.SaveChanges();
                //FrmRequisition_Load(sender, e);

                MessageBox.Show("購案刪除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
