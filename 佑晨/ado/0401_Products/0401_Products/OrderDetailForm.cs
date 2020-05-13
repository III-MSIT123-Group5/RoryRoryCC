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
    public partial class OrderDetailForm : Form
    {
        public OrderDetailForm()
        {
            InitializeComponent();
        }

        private void order_DetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.order_DetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        internal int ProductID;

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details, ProductID);
        }
    }
}
