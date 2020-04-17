using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmHelloLinq : Form
    {
        public FrmHelloLinq()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.northwindDataSet1.Products);
            this.ordersTableAdapter1.Fill(this.northwindDataSet1.Orders);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 8, 7, 5, 4, 52, 2, 45 };

            //foreach (int aa in nums)
            //{
            //    this.listBox1.Items.Add(aa);
            //}
            // IEnumerator en =  nums.GetEnumerator();
            //while (en.MoveNext())
            //{
            //    this.listBox1.Items.Add(en.Current);
            //}
            //IEnumerable<int> q = from n in nums where n % 2 == 0 select n;

            var q = nums.Where(n =>IsEven(n)  ).Select(n =>  n);
            this.listBox1.DataSource = q.ToList();
        }

        bool IsEven(int n)
        {
            //if (n % 2 == 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return n % 2 == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] strs = { "apple", "pineapple", "banana", "strowberry" };

            var q = strs.Where(s => s.ToLower().Contains("apple")).Select(s => s);

            this.listBox1.DataSource = q.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var q = this.northwindDataSet1.Products.Where(p => p.UnitPrice < 30).Select(p => p);

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var q = this.northwindDataSet1.Orders.Where(n => n.OrderDate.Year == 1997);

            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
