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

            var q = from d in dbContext.Departments
                    from g in d.Groups
                    from b in g.BulletinBoards
                    select new { GroupList = g.GroupName, GroupID = b.GroupID, DepartmentList = d.name,DepartmentID=b.DepartmentID };

            dataGridView1.DataSource = q.ToList();


         


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
        }

        private void CBDepartment_DropDownClosed(object sender, EventArgs e)
        {
            //foreach (CCBoxItem item in CBDepartment.CheckedItems)
            //{
            //    sb.Append(item.Name).Append(CBDepartment.ValueSeparator);
            //}
        }
    }
}
