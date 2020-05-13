using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0401_Products
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Suppliers' 資料表。您可以視需要進行移動或移除。
            this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Suppliers' 資料表。您可以視需要進行移動或移除。
            this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);

        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {
            if (btnFreeze.Checked)
            {
                int RowIndex = productsDataGridView.CurrentCell.RowIndex;
                RowIndex = RowIndex > 0 ? --RowIndex : RowIndex;
                int ColumnIndex = productsDataGridView.CurrentCell.ColumnIndex;
                ColumnIndex = ColumnIndex > 0 ? --ColumnIndex : ColumnIndex;
                FreezeGrid(RowIndex, ColumnIndex, true);
            }
            else
            {
                FreezeGrid(0, 0, false);
            }

        }

        void FreezeGrid(int RowIndex , int ColumnIndex , bool Status)
        {
            productsDataGridView.Columns[ColumnIndex].Frozen = Status;
            productsDataGridView.Rows[RowIndex].Frozen = Status;
        }

        private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:                    
                    OrderDetailForm ODF = new OrderDetailForm();
                    ODF.ProductID = (int)productsDataGridView.Rows[e.RowIndex].Cells[1].Value;
                    ODF.ShowDialog();
                    ODF.Dispose();
                    break;
                case 4:
                    CategoryForm CF = new CategoryForm();
                    CF.CategoryID = (int)productsDataGridView.Rows[e.RowIndex].Cells[4].Value;
                    CF.ShowDialog();
                    CF.Dispose();
                    break;
            }
        }
    }
}
