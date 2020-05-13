using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyInterface
{
    public partial class FrmMyEmploee : Form
    {
        public FrmMyEmploee()
        {
            InitializeComponent();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ClsEmployee> emp = new List<ClsEmployee>();
            emp.Add(new ClsEmployee { EmpName = "John", EmpTitle = JobTitle.Manager, HireDate = DateTime.Now.AddDays(-200), Salary = 60000 });
            emp.Add(new ClsEmployee { EmpName = "May", EmpTitle = JobTitle.Engineer, HireDate = DateTime.Now, Salary = 50000 });
            emp.Add(new ClsEmployee { EmpName = "JoJo", EmpTitle = JobTitle.Tester, HireDate = DateTime.Now.AddDays(-2), Salary = 40000 });
            emp.Add(new ClsEmployee { EmpName = "AAA", EmpTitle = JobTitle.Engineer, HireDate = DateTime.Now.AddDays(-1), Salary = 50000 });
            emp.Add(new ClsEmployee { EmpName = "AAAAA", EmpTitle = JobTitle.Engineer, HireDate = DateTime.Now, Salary = 50000 });

            //至少一個物件必須實作 IComparable。

            emp.Sort();

            this.listBox1.DataSource = emp;
            this.dataGridView1.DataSource = emp;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClsEmployee a = new ClsEmployee() { EmpName = "a", Salary = 60000 };
            ClsEmployee b = new ClsEmployee() { EmpName = "b", Salary = 40000 };
            int ComResult = a.CompareTo(b);
            string ResultStr;

            if (ComResult > 0)
            {
                ResultStr = "a >ｂ";
            }
            else if (ComResult <0)
            {
                ResultStr = "a<b";
            }
            else
            {
                ResultStr = "a == b";
            }
            MessageBox.Show(ResultStr);

        }
    }
}
