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

        public BulletinBoard()
        {
            InitializeComponent();

            BusinessDataBaseEntities dbContext;
            dbContext = new BusinessDataBaseEntities();

            CBDepartment.ItemCheck += CBDepartment_ItemCheck;

            var q1 = from d in dbContext.Departments
                     from g in d.Groups
                     from em in g.Employees
                     from b in em.BulletinBoards
                     select new { Group = g.GroupName, Department = d.name, em.employee_name, b.Content, b.PostTime };

            dataGridView1.DataSource = q1.ToList();


            var q = from d in dbContext.Departments
                    from g in d.Groups
                    from b in g.BulletinBoards
                    from em in g.Employees
                    select new { Group = g.GroupName, Department = d.name, em.employee_name, b.Content, b.PostTime };
            //dataGridView1.DataSource = q.ToList();


         


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
                CBGroup.MaxDropDownItems = 2;
                // Make the "Name" property the one to display, rather than the ToString() representation.
                CBGroup.DisplayMember = "Name";
                CBGroup.ValueSeparator = ", ";
                // Check the first 2 items.
                CBGroup.SetItemChecked(0, true);
                CBGroup.SetItemChecked(1, true);
                //ccb.SetItemCheckState(1, CheckState.Indeterminate);
            }

            BulletinBoard_Resize(sender, e);

        }

        private void CBDepartment_DropDownClosed(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            CBGroup.Items.Clear();
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
        }

        private void BulletinBoard_Resize(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = listView1.Width / 10;
            listView1.Columns[1].Width = listView1.Width / 10;
            listView1.Columns[2].Width = listView1.Width / 10;
            listView1.Columns[3].Width = listView1.Width / 2;
            listView1.Columns[4].Width = listView1.Width / 5;
        }

        private void CBDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            BusinessDataBaseEntities dbContext;
            listView1.Items.Clear();

            dbContext = new BusinessDataBaseEntities();


            var q = from d in dbContext.Departments
                    from g in d.Groups
                    from b in g.BulletinBoards
                    from em in g.Employees
                    select new { GroupList = g.GroupName, DepartmentList = d.name,  em.employee_name, b.Content,b.PostTime };

            dataGridView1.DataSource = q.ToList();

        }
    }
}
