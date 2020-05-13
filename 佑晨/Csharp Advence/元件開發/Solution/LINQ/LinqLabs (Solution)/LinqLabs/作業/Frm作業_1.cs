using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            this.ordersTableAdapter1.Fill(this.northwindDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(this.northwindDataSet1.Order_Details);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.lblMaster.Text = "LOG Files";

            System.IO.DirectoryInfo dirs = new System.IO.DirectoryInfo(@"c:\windows");
            FileInfo[] files = dirs.GetFiles();

            this.dataGridView1.DataSource = files;

        }

        private void button6_Click(object sender, EventArgs e)
        {           
            this.bindingSource1.DataSource = this.northwindDataSet1.Orders;
            this.dataGridView1.DataSource =this.bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.bindingSource2.DataSource = this.bindingSource1;
            this.bindingSource2.DataMember = "FK_Order_Details_Orders";
            this.dataGridView2.DataSource = this.bindingSource2;
        }

    }
}
