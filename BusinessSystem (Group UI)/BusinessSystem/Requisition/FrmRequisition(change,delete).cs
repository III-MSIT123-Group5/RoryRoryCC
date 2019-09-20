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

namespace BusinessSystem.Requisition
{
    public partial class FrmRequisition2 : SonForm
    {
        public FrmRequisition2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// /
        /// </summary>
        BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();

        //展示
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReportID.Text == "")
                {
                    MessageBox.Show("請輸入訂單號碼再查詢!!!");
                }
                else
                {

                    var report = (from RC in this.dbContext.ReportCategories.AsEnumerable()
                                  join RM in this.dbContext.RequisitionMains.AsEnumerable() on RC.ReportID equals RM.ReportID
                                  join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                                  where OD.OrderID == Convert.ToInt32(txtReportID.Text)
                                  select OD).FirstOrDefault();

                    txtProcductName.Text = report.ProductName.ToString();
                    txtUnitPrice.Text = report.UnitPrice.ToString();
                    txtQuantity.Text = report.Quantity.ToString();
                    txtNote.Text = report.Note.ToString();

                    DataGridViewFormat();
                }
            }
            catch
            {
                MessageBox.Show("查無此訂單!!!");
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
                              where OD.OrderID == Convert.ToInt32(txtReportID.Text)
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
                              where OD.OrderID == int.Parse(txtReportID.Text)
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

        private void DataGridViewFormat()
        {
            dataGridView1.Columns.Clear();

            var report = from OD in this.dbContext.OrderDetails.AsEnumerable()
                         where OD.OrderID == Convert.ToInt32(txtReportID.Text)
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
    }
}
