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
    public partial class FrmRequisition1 : SonForm
    {
        public FrmRequisition1()
        {
            InitializeComponent();
           
        }

         BusinessDataBaseEntities dbContext=new BusinessDataBaseEntities();

        private void FrmRequisition_Load(object sender, EventArgs e)
        {           

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
                DataGridViewFormat();

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
                DataGridViewFormat();

                MessageBox.Show("購案更新成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //刪除
        private void btnClear_Click(object sender, EventArgs e)
        {
            //TODO>>>>RequisitionMains資料未刪
            try
            {        
                var report = (from RC in this.dbContext.ReportCategories.AsEnumerable()
                              join RM in this.dbContext.RequisitionMains.AsEnumerable() on RC.ReportID equals RM.ReportID
                              join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                              where OD.OrderID == int.Parse(textBox1.Text)
                              select OD).FirstOrDefault();

                this.dbContext.OrderDetails.Remove(report);
                this.dbContext.SaveChanges();
                DataGridViewFormat();

                MessageBox.Show("購案刪除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataGridViewFormat();
        }

        private void DataGridViewFormat()
        {
            dataGridView1.Columns.Clear();

            var report = from OD in this.dbContext.OrderDetails
                         select new
                         {
                             請購單號 = OD.OrderID,
                             產品名稱 = OD.ProductName,
                             單價 = OD.UnitPrice,
                             數量 = OD.Quantity,
                             總價 = OD.TotalPrice,
                             請購原因 = OD.Note                             
        };

            dataGridView1.DataSource = report.ToList();
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("請輸入訂單號碼再查詢!!!");
            }
            else
            {

                var report = (from RC in this.dbContext.ReportCategories.AsEnumerable()
                              join RM in this.dbContext.RequisitionMains.AsEnumerable() on RC.ReportID equals RM.ReportID
                              join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                              where OD.OrderID == Convert.ToInt32(textBox1.Text)
                              select OD).FirstOrDefault();

                txtProcductName.Text = report.ProductName.ToString();
                txtUnitPrice.Text = report.UnitPrice.ToString();
                txtQuantity.Text = report.Quantity.ToString();
                txtNote.Text = report.Note.ToString();

                DataGridViewFormat();
            }
        }
    }
}
