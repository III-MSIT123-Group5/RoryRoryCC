using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _0408_Char
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Customers' 資料表。您可以視需要進行移動或移除。
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
            Form1_Resize(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.customersDataGridView.Columns[0].Width = this.customersDataGridView.Columns[1].Width = this.Width / 2;
        }

        private void chart1_PrePaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
        {
            foreach(DataPoint p in chart1.Series[0].Points)
            {
                p["Exploded"] = "True";
            }
        }

        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataPoint p in chart1.Series[0].Points)
            {
                p["Exploded"] = "False";
            }

            //chart1.Series[0].Points[e.RowIndex]["Exploded"] = "";



        }
    }
}
