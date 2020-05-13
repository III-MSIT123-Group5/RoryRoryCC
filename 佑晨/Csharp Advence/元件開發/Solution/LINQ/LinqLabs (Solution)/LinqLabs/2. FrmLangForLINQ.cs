using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.northwindDataSet1.Products);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int n1 = 100, n2 = 200;
            string n1 = "aaa", n2 = "bbb";
            MessageBox.Show($"{ n1 } , {n2}");
            Swap<string>( ref n1,ref  n2);
            MessageBox.Show($"{ n1 } , {n2}");
        }

        void Swap<T> ( ref T n1, ref T n2)
        {
            T sw = n1;
            n1 = n2;
            n2 = sw;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] words = { "aaa" ,"bbb" , "ccc" , "ddd"};

            this.listBox1.DataSource = nums.Where(Test).ToList();

        }
        


        bool Test (int n)
        {
            return n > 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //具名方法
            this.buttonX.Click += ButtonX_Click;

            //匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
            {
                MessageBox.Show("匿名方法");
            };
            //匿名方法 => C#3.0
            this.buttonX.Click += (object sender2, EventArgs e2) =>
            {
                MessageBox.Show("匿名方法 =>");
            };

        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("具名方法");
        }

         delegate bool Mydelegate (int n);

        private void button9_Click(object sender, EventArgs e)
        {
            //具名方法
            //Mydelegate delObj = new Mydelegate(Test);
            //Mydelegate delObj = Test;

            //bool result = delObj.Invoke(10);
            //bool result = delObj(6);
            //MessageBox.Show( "具名方法 " + result);

            //匿名方法 2.0
            //Mydelegate delObj = delegate (int n)
            //{
            //    return n > 5;
            //};
            //bool result = delObj(6);
            //MessageBox.Show("匿名方法 C#2.0" + result);

            ////匿名方法 3.0
            Mydelegate delObj = n => n > 5;
            bool result = delObj(6);
            MessageBox.Show("匿名方法 C#3.0" + result);

        }

        List<int > MyWhere ( int [] nums , Mydelegate delObj)
        {
            List<int> ls = new List<int>();
            foreach(int n in nums)
            {
                if(delObj(n))
                {
                    ls.Add(n);
                }
            }
            return ls;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.listBox1.DataSource = MyWhere(nums, Test);
            this.listBox2.DataSource = MyWhere(nums, n=> n % 2 == 0);
        }


        IEnumerable<int > MyIterator(int [] nums , Mydelegate del)
        {
            foreach(int n in nums)
            {
                if (del(n))
                {
                    yield return n;
                }
            }
        }

        

        private void button13_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            this.listBox1.DataSource = MyIterator(nums, n => n % 2 == 0).ToList();
            
        }

        private void button43_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = nums.Where(n => n % 2 == 0).Select(n => new { N = n, Square = n * n, Tri = n * n * n });
            this.dataGridView1.DataSource = q.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //var q = this.northwindDataSet1.Products.GroupBy(p => p.CategoryID ).Select()

            var q = from p in this.northwindDataSet1.Products
                    group p by p.CategoryID into g
                    select new { CategoryID = g.Key, sum=   g.Select(p => p.UnitPrice).Sum()};

            this.dataGridView1.DataSource = q.ToList();




        }

        private void button39_Click(object sender, EventArgs e)
        {
            string s = "abcde";
            int i = 2;
            MessageBox.Show(s.WordCount().ToString());
            MessageBox.Show(s.WordCount(i).ToString());
        }
    }

    public static class MyExMethod
    {
        public static int WordCount(this string  s  )
        {
            return s.Length ;
        }
        public static char WordCount(this string s , int i  )
        {
            return s[i];
        }

    }

}



