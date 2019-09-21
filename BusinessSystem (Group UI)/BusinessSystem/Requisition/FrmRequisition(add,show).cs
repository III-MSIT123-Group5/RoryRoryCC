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
        public FrmRequisition1(int empid) : base(empid)
        {
            InitializeComponent();           
        }

        BusinessDataBaseEntities dbContext=new BusinessDataBaseEntities();

        private void FrmRequisition_Load(object sender, EventArgs e)
        {           
            txtProcductName.Text = "請輸入產品名稱";
            txtUnitPrice.Text = "請輸入產品單價";
            txtQuantity.Text = "請輸入產品數量";
            txtNote.Text = "請輸入購買原因";
        }
        
        //DEMO
        private void btnDEMO_Click(object sender, EventArgs e)
        {
            txtProcductName.ForeColor = Color.Black;
            txtUnitPrice.ForeColor = Color.Black;
            txtQuantity.ForeColor = Color.Black;
            txtNote.ForeColor = Color.Black;

            this.txtProcductName.Text = "郵資";
            this.txtUnitPrice.Text = "15";
            this.txtQuantity.Text = "10";
            this.txtNote.Text = "寄信給顧客A";
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

                this.dbContext.Dispose();

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

        //清除展示
        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }

        //進入修改、刪除頁面
        private void btnEnterToChangeDelete_Click(object sender, EventArgs e)
        {
            FrmRequisition2 frmRequisition2 = new FrmRequisition2(LoginID);
            frmRequisition2.ShowDialog();
        }

        //DataGridView顯示所有資料
        //DataGridView格式
        private void DataGridViewFormat()
        {
            dataGridView1.Columns.Clear();

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

        string txtProcductNameExpand = "請輸入產品名稱";
        string txtUnitPriceExpand = "請輸入產品單價";
        string txtQuantityExpand = "請輸入產品數量";
        string txtNoteExpand = "請輸入購買原因";

        //提示字
        private void txtProcductName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtProcductName.Text == txtProcductNameExpand)
            {
                txtProcductName.Clear();
                if (txtUnitPrice.Text == "")
                {
                    txtUnitPrice.Text = txtUnitPriceExpand;
                }
                else if (txtQuantity.Text == "")
                {
                    txtQuantity.Text = txtQuantityExpand;
                }
                else if (txtNote.Text == "")
                {
                    txtNote.Text = txtNoteExpand;
                }
            }
            else if (txtUnitPrice.Text == "")
            {
                txtUnitPrice.Text = txtUnitPriceExpand;
            }
            else if (txtQuantity.Text == "")
            {
                txtQuantity.Text = txtQuantityExpand;
            }
            else if (txtNote.Text == "")
            {
                txtNote.Text = txtNoteExpand;
            }
            else
            {
                txtProcductName.Text = "";                    
            }
        }
        private void txtUnitPrice_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUnitPrice.Text == txtUnitPriceExpand)
            {
                txtUnitPrice.Clear();
                if (txtQuantity.Text == "")
                {
                   txtQuantity.Text = txtQuantityExpand;
                }
                else if (txtProcductName.Text == "")
                {
                    txtProcductName.Text = txtProcductNameExpand;
                }
                else if (txtNote.Text == "")
                {
                    txtNote.Text = txtNoteExpand;
                }
            }
            else if (txtQuantity.Text == "")
            {
                txtQuantity.Text = txtQuantityExpand;
            }
            else if (txtProcductName.Text == "")
            {
                txtProcductName.Text = txtProcductNameExpand;
            }
            else if (txtNote.Text == "")
            {
                txtNote.Text = txtNoteExpand;
            }
            else
            {
                txtUnitPrice.Text = "";
            }
        }
        private void txtQuantity_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtQuantity.Text == txtQuantityExpand)
            {
                txtQuantity.Clear();
                if (txtUnitPrice.Text == "")
                {
                    txtUnitPrice.Text = txtUnitPriceExpand;
                }
                else if (txtProcductName.Text == "")
                {
                    txtProcductName.Text = txtProcductNameExpand;
                }
                else if (txtNote.Text == "")
                {
                    txtNote.Text = txtNoteExpand;
                }
            }
            else if (txtUnitPrice.Text == "")
            {
                txtUnitPrice.Text = txtUnitPriceExpand;
            }
            else if (txtProcductName.Text == "")
            {
               txtProcductName.Text = txtProcductNameExpand;
            }
            else if (txtNote.Text == "")
            {
                txtNote.Text = txtNoteExpand;
            }
            else
            {
                txtQuantity.Text = "";
            }
        }
        private void txtNote_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNote.Text == txtNoteExpand)
            {
                txtNote.Clear();
                if (txtUnitPrice.Text == "")
                {
                   txtUnitPrice.Text = txtUnitPriceExpand;
                }
                else if (txtProcductName.Text == "")
                {
                    txtProcductName.Text = txtProcductNameExpand;
                }
                else if (txtQuantity.Text == "")
                {
                    txtQuantity.Text = txtQuantityExpand;
                }
            }
            else if (txtUnitPrice.Text == "")
            {
                txtUnitPrice.Text = txtUnitPriceExpand;
            }
            else if (txtProcductName.Text == "")
            {
                txtProcductName.Text = txtProcductNameExpand;
            }
            else if (txtQuantity.Text == "")
            {
                txtQuantity.Text = txtQuantityExpand;
            }
            else
            {
                txtNote.Text = "";
            }
        }

        //方法>>未輸入資料-灰色、輸入資料-黑色
        private void textboxStyle(TextBox textBox, string txt)
        {
            if (textBox.Text == "" || textBox.Focused)
            {
                textBox.ForeColor = Color.Black;
            }
            else if (textBox.Text == txt)
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = txt;
            }
        }

        //未輸入資料-灰色、輸入資料-黑色
        private void txtProcductName_TextChanged(object sender, EventArgs e)
        {
            textboxStyle(txtProcductName, txtProcductNameExpand);
        }
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            textboxStyle(txtUnitPrice, txtUnitPriceExpand);
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            textboxStyle(txtQuantity, txtQuantityExpand);
        }
        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            textboxStyle(txtNote, txtNoteExpand);
        }        
    }
}
