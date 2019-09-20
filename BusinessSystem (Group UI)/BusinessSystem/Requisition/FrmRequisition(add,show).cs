using BusinessSystem.Requisition;
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
                    EmployeeID = LoginID
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
        
        //展示
        private void btnShow_Click(object sender, EventArgs e)
        {
            DataGridViewFormat();
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            FrmRequisition2 frmRequisition2 = new FrmRequisition2();
            frmRequisition2.ShowDialog();
        }

        private void DataGridViewFormat()
        {
            dataGridView1.Columns.Clear();

            var report = from OD in this.dbContext.OrderDetails.AsEnumerable()
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

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 207;

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
