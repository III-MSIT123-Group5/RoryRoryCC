using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0409_Products
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Orders' 資料表。您可以視需要進行移動或移除。
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Orders' 資料表。您可以視需要進行移動或移除。
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet1.Orders' 資料表。您可以視需要進行移動或移除。
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Orders' 資料表。您可以視需要進行移動或移除。
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Employees' 資料表。您可以視需要進行移動或移除。
            this.employeesTableAdapter.Fill(this.northwindDataSet.Employees);

        }
    }
}
