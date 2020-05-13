using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Starter
{
    public partial class FrmLINQ_To_XXX : Form
    {
        public FrmLINQ_To_XXX()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var q =  nums.GroupBy(n => n % 2);
            var q = from n in nums
                    group n by n % 2==  0? "偶數":"奇數";

            this.dataGridView1.DataSource = q.ToList();

            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString() + group.Count() );
                foreach(var item in group)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

            this.listView1.Items.Clear();
            foreach (var group in q)
            {
                ListViewGroup x  =  this.listView1.Groups.Add(group.Key.ToString(), group.Key.ToString());
                foreach(var item in group)
                {
                    this.listView1.Items.Add(item.ToString()).Group = x;
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = from n in nums
                    group n by n % 2 == 0 ? "偶數" : "奇數" into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyAverage = g.Average() , MyGroup = g  };

            this.dataGridView1.DataSource = q.ToList();

            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add($"{group.MyKey} ({group.MyCount})");
                foreach (var item in group.MyGroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

            this.listView1.Items.Clear();
            foreach (var group in q)
            {
                string s = $"{group.MyKey} ({group.MyCount})";
                ListViewGroup x = this.listView1.Groups.Add(s, s);
                foreach (var item in group.MyGroup)
                {
                    this.listView1.Items.Add(item.ToString()).Group = x;
                }
            }

            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            this.chart1.Series[0].XValueMember = "MyKey";
            this.chart1.Series[0].YValueMembers = "MyCount";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            this.chart1.Series[1].XValueMember = "MyKey";
            this.chart1.Series[1].YValueMembers = "MyAverage";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,25,31 };

            var q = from n in nums
                    group n by MyKey(n) into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyAverage = g.Average(), MyGroup = g };

            this.dataGridView1.DataSource = q.ToList();

            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add($"{group.MyKey} ({group.MyCount})");
                foreach (var item in group.MyGroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

            this.listView1.Items.Clear();
            foreach (var group in q)
            {
                string s = $"{group.MyKey} ({group.MyCount})";
                ListViewGroup x = this.listView1.Groups.Add(s, s);
                foreach (var item in group.MyGroup)
                {
                    this.listView1.Items.Add(item.ToString()).Group = x;
                }
            }

            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            this.chart1.Series[0].XValueMember = "MyKey";
            this.chart1.Series[0].YValueMembers = "MyCount";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            this.chart1.Series[1].XValueMember = "MyKey";
            this.chart1.Series[1].YValueMembers = "MyAverage";
        }

        string MyKey(int n)
        {
            if (n < 5)
            {
                return "低";
            }
            else if ( n < 10)
            {
                return "中";
            }
            else
            {
                return "高";
            }

        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.treeView1.Nodes.Clear();

            DirectoryInfo dir = new DirectoryInfo(@"c:\\windows");
            FileInfo[] fi = dir.GetFiles();

            var q = from f in fi
                    group f by f.Extension into g
                    select new { g.Key, MyCount =  g.Count(), Group = g };

            this.dataGridView2.DataSource = q.ToList();

            foreach(var group in q)
            {
                string s = $"{group.Key} ({group.Key})";
                ListViewGroup x = this.listView1.Groups.Add(s, s);
                foreach (var  f in group.Group)
                {
                    this.listView1.Items.Add(f.Name).Group = x;
                }
            }

            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(group.Key);
                foreach (var f in group.Group)
                {
                    x.Nodes.Add(f.Name);
                }
            }


        }
    }
}
