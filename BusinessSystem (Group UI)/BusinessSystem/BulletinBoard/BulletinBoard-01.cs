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
    public partial class BulletinBoard : SonForm
    {
        private string[] DepartmentArr = { "業務部", "行政部", "產品部", "財務部", "資訊部" };
        private string[] GroupArr = { "總務組","人資組"};

        BusinessDataBaseEntities dbContext;

        public BulletinBoard()
        {
            InitializeComponent();


            dbContext = new BusinessDataBaseEntities();

            CBDepartment.ItemCheck += CBDepartment_ItemCheck;


            var q = from b in dbContext.BulletinBoards
                    join d in dbContext.Departments
                    on b.DepartmentID equals d.departmentID
                    join g in dbContext.Groups
                    on b.GroupID equals g.GroupID
                    join em in dbContext.Employees
                    on b.EmployeeID equals em.employeeID
                    select new { 部門 = d.name, 組別 = g.GroupName,姓名 = em.employee_name,留言內容 = b.Content, 張貼時間 = b.PostTime };


            dataGridView1.DataSource = q.ToList();

            dgvFormat(dataGridView1);


        }

        private void CBDepartment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = CBDepartment.Items[e.Index] as CCBoxItem;

        }

        private void BulletinBoard_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < DepartmentArr.Length; i++)
            {
                CCBoxItem item = new CCBoxItem(DepartmentArr[i], i);
                CBDepartment.Items.Add(item);
            }

            // If more then 5 items, add a scroll bar to the dropdown.
            CBDepartment.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            CBDepartment.DisplayMember = "Name";
            CBDepartment.ValueSeparator = ", ";
            // Check the first 2 items.
            CBDepartment.SetItemChecked(0, true);
            CBDepartment.SetItemChecked(1, true);
            //ccb.SetItemCheckState(1, CheckState.Indeterminate);



            if (CBDepartment.CheckedIndices.Contains(1))
            {
                for (int i = 0; i < GroupArr.Length; i++)
                {
                    CCBoxItem item2 = new CCBoxItem(GroupArr[i], i);
                    CBGroup.Items.Add(item2);
                }

                // If more then 5 items, add a scroll bar to the dropdown.
                CBGroup.MaxDropDownItems = 3;
                // Make the "Name" property the one to display, rather than the ToString() representation.
                CBGroup.DisplayMember = "Name";
                CBGroup.ValueSeparator = ", ";
                // Check the first 2 items.
                CBGroup.SetItemChecked(0, true);
                CBGroup.SetItemChecked(1, true);
                //ccb.SetItemCheckState(1, CheckState.Indeterminate);
            }



        }



        private void CBDepartment_DropDownClosed(object sender, EventArgs e)
        {
            BusinessDataBaseEntities dbContext;

            this.dataGridView1.DataSource = null;

            CBGroup.Items.Clear();

            //List<string> listD = new List<string>(DepartmentArr);
            //List<string> listG = new List<string>(GroupArr);

            //Group
            if (CBDepartment.CheckedIndices.Contains(1))
            {
                for (int i = 0; i < GroupArr.Length; i++)
                {
                    CCBoxItem item2 = new CCBoxItem(GroupArr[i], i);
                    CBGroup.Items.Add(item2);
                }

                // If more then 5 items, add a scroll bar to the dropdown.
                CBGroup.MaxDropDownItems = 2;
                // Make the "Name" property the one to display, rather than the ToString() representation.
                CBGroup.DisplayMember = "Name";
                CBGroup.ValueSeparator = ", ";
                // Check the first 2 items.
                CBGroup.SetItemChecked(0, true);
                CBGroup.SetItemChecked(1, true);
                //CBGroup.SetItemCheckState(1, CheckState.Indeterminate);



                //foreach (CCBoxItem item in CBDepartment.CheckedItems)
                //{
                //    sb.Append(item.Name).Append(CBDepartment.ValueSeparator);
                //}
            }
            else
            {
                CBGroup.Items.Clear();
                CBGroup.Text = "(無組別)";
            }

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("部門", typeof(string)));
            dt.Columns.Add(new DataColumn("組別", typeof(string)));
            dt.Columns.Add(new DataColumn("姓名", typeof(string)));
            dt.Columns.Add(new DataColumn("留言內容", typeof(string)));
            dt.Columns.Add(new DataColumn("張貼時間", typeof(DateTime)));


            this.dataGridView1.DataSource = dt;



            dbContext = new BusinessDataBaseEntities();

            var q = from b in dbContext.BulletinBoards.AsEnumerable()
                    join d in dbContext.Departments.AsEnumerable()
                    on b.DepartmentID equals d.departmentID
                    join g in dbContext.Groups.AsEnumerable()
                    on b.GroupID equals g.GroupID
                    join em in dbContext.Employees.AsEnumerable()
                    on b.EmployeeID equals em.employeeID
                    where DepartmentArr.Contains(d.name)
                    select new { 部門 = d.name, 組別 = g.GroupName, 姓名 = em.employee_name, 留言內容 = b.Content, 張貼時間 = b.PostTime };

            q.ToList().ForEach(q1 => dt.Rows.Add(q1.部門, q1.組別, q1.姓名, q1.留言內容, q1.張貼時間));



            dgvFormat(dataGridView1);

            //if (CBDepartment.CheckedIndices.Contains(0))
            //{
            //    var q = from b in dbContext.BulletinBoards.AsEnumerable()
            //            join d in dbContext.Departments.AsEnumerable()
            //            on b.DepartmentID equals d.departmentID
            //            join g in dbContext.Groups.AsEnumerable()
            //            on b.GroupID equals g.GroupID
            //            join em in dbContext.Employees.AsEnumerable()
            //            on b.EmployeeID equals em.employeeID
            //            where b.DepartmentID == 2
            //            select new { 部門 = d.name, 組別 = g.GroupName, 姓名 = em.employee_name, 留言內容 = b.Content, 張貼時間 = b.PostTime };

            //   q.ToList().ForEach(q1=>dt.Rows.Add(q1.部門,q1.組別,q1.姓名,q1.留言內容,q1.張貼時間));

            //}


            //if (CBDepartment.CheckedIndices.Contains(1))
            //{
            //    var q = from b in dbContext.BulletinBoards.AsEnumerable()
            //            join d in dbContext.Departments.AsEnumerable()
            //            on b.DepartmentID equals d.departmentID
            //            join g in dbContext.Groups.AsEnumerable()
            //            on b.GroupID equals g.GroupID
            //            join em in dbContext.Employees.AsEnumerable()
            //            on b.EmployeeID equals em.employeeID
            //            where b.DepartmentID == 3
            //            select new { 部門 = d.name, 組別 = g.GroupName, 姓名 = em.employee_name, 留言內容 = b.Content, 張貼時間 = b.PostTime };

            //    q.ToList().ForEach(q1 => dt.Rows.Add(q1.部門, q1.組別, q1.姓名, q1.留言內容, q1.張貼時間));

            //}

            //if (CBDepartment.CheckedIndices.Contains(2))
            //{
            //    var q = from b in dbContext.BulletinBoards.AsEnumerable()
            //            join d in dbContext.Departments.AsEnumerable()
            //            on b.DepartmentID equals d.departmentID
            //            join g in dbContext.Groups.AsEnumerable()
            //            on b.GroupID equals g.GroupID
            //            join em in dbContext.Employees.AsEnumerable()
            //            on b.EmployeeID equals em.employeeID
            //            where b.DepartmentID == 4
            //            select new { 部門 = d.name, 組別 = g.GroupName, 姓名 = em.employee_name, 留言內容 = b.Content, 張貼時間 = b.PostTime };

            //    q.ToList().ForEach(q1 => dt.Rows.Add(q1.部門, q1.組別, q1.姓名, q1.留言內容, q1.張貼時間));

            //}


            //if (CBDepartment.CheckedIndices.Contains(3))
            //{
            //    var q = from b in dbContext.BulletinBoards.AsEnumerable()
            //            join d in dbContext.Departments.AsEnumerable()
            //            on b.DepartmentID equals d.departmentID
            //            join g in dbContext.Groups.AsEnumerable()
            //            on b.GroupID equals g.GroupID
            //            join em in dbContext.Employees.AsEnumerable()
            //            on b.EmployeeID equals em.employeeID
            //            where b.DepartmentID == 5
            //            select new { 部門 = d.name, 組別 = g.GroupName, 姓名 = em.employee_name, 留言內容 = b.Content, 張貼時間 = b.PostTime };

            //    q.ToList().ForEach(q1 => dt.Rows.Add(q1.部門, q1.組別, q1.姓名, q1.留言內容, q1.張貼時間));

            //}


            //if (CBDepartment.CheckedIndices.Contains(4))
            //{
            //    var q = from b in dbContext.BulletinBoards.AsEnumerable()
            //            join d in dbContext.Departments.AsEnumerable()
            //            on b.DepartmentID equals d.departmentID
            //            join g in dbContext.Groups.AsEnumerable()
            //            on b.GroupID equals g.GroupID
            //            join em in dbContext.Employees.AsEnumerable()
            //            on b.EmployeeID equals em.employeeID
            //            where b.DepartmentID == 6
            //            select new { 部門 = d.name, 組別 = g.GroupName, 姓名 = em.employee_name, 留言內容 = b.Content, 張貼時間 = b.PostTime };

            //    q.ToList().ForEach(q1 => dt.Rows.Add(q1.部門, q1.組別, q1.姓名, q1.留言內容, q1.張貼時間));

            //}




        }


        public void dgvFormat(DataGridView dgv)
        {
            dgv.Columns[0].Width = 70;
            dgv.Columns[1].Width = 70;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void CBDepartment_DropDown(object sender, EventArgs e)
        {


        }
    }


}
