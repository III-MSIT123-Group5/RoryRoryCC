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
        public FrmRequisition2(int empid) : base(empid)
        {
            InitializeComponent();
        }  

        BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();

        //展示單筆
        private void btnOnlyShow_Click(object sender, EventArgs e)
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

                    DataGridViewFormat2();
                }
            }
            catch
            {
                MessageBox.Show("查無此訂單!!!");
            }
        }

        //展示所有
        private void btnAllShow_Click(object sender, EventArgs e)
        {
            DataGridViewFormat1();
        }

        //修改
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtProcductName.Text == "" || txtUnitPrice.Text == "" || txtQuantity.Text == "" || txtNote.Text == "")
            {
                MessageBox.Show("請輸入修改資料!!!");                
            }
            else
            { 
            try
            {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        var report = (from RM in this.dbContext.RequisitionMains.AsEnumerable()
                                      join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                                      where OD.OrderID == Convert.ToInt32(txtReportID.Text)
                                      select OD).FirstOrDefault();

                        report.ProductName = txtProcductName.Text;
                        report.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                        report.Quantity = Convert.ToInt32(txtQuantity.Text);
                        report.Note = txtNote.Text;

                        this.dbContext.SaveChanges();
                        DataGridViewFormat2();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                MessageBox.Show("購案更新成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }

        //刪除
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    var report1 = (from OD in this.dbContext.OrderDetails.AsEnumerable()
                                   where OD.OrderID == int.Parse(txtReportID.Text)
                                   select OD).FirstOrDefault();

                    var report2 = (from RM in this.dbContext.RequisitionMains.AsEnumerable()
                                   where RM.OrderID == int.Parse(txtReportID.Text)
                                   select RM).FirstOrDefault();

                    this.dbContext.OrderDetails.Remove(report1);
                    this.dbContext.RequisitionMains.Remove(report2);
                    this.dbContext.SaveChanges();
                    DataGridViewFormat2();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                MessageBox.Show("購案刪除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //DataGridView顯示個人所有資料
        //DataGridView格式
        private void DataGridViewFormat1()
        {
            dataGridView1.Columns.Clear();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                var report = from RM in this.dbContext.RequisitionMains.AsEnumerable()
                             join OD in this.dbContext.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                             where RM.EmployeeID == LoginID
                             select new
                             {
                                 請購單號 = OD.OrderID,
                                 產品名稱 = OD.ProductName,
                                 單價 = $"{OD.UnitPrice:c0}".ToString(),
                                 數量 = OD.Quantity,
                                 總價 = $"{OD.TotalPrice:c0}".ToString(),
                                 請購原因 = OD.Note
                             };

                dataGridView1.DataSource = report.ToList();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 297;

            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        //DataGridView顯示單筆資料
        //DataGridView格式
        private void DataGridViewFormat2()
        {
            dataGridView1.Columns.Clear();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                var report = from OD in this.dbContext.OrderDetails.AsEnumerable()
                             where OD.OrderID == Convert.ToInt32(txtReportID.Text)
                             select new
                             {
                                 請購單號 = OD.OrderID,
                                 產品名稱 = OD.ProductName,
                                 單價 = $"{OD.UnitPrice:c0}".ToString(),
                                 數量 = OD.Quantity,
                                 總價 = $"{OD.TotalPrice:c0}".ToString(),
                                 請購原因 = OD.Note
                             };

                dataGridView1.DataSource = report.ToList();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 297;

            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
    }
}
