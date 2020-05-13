using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string strconn = @"Data Source=. ; Initial Catalog = Northwind; Integrated Security = true";

        private void Form1_Load(object sender, EventArgs e)
        {
            string strcmd = "Select Distinct Country from customers";
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand(strcmd, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            //================
           SqlDataReader dr =  cmd.ExecuteReader();
            while (dr.Read())
            {
                cbCountry.Items.Add(dr["Country"]);
            }
            cbCountry.SelectedIndex = 0;
            dr.Close();
            cmd.Dispose();
            //================
            conn.Close();
            conn.Dispose();
            lvCustomers_Resize(sender, e);
        }

        

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strcmd = "Select customerid, companyname, contactname, city, region, country, phone  from customers where country = @Country";
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand(strcmd, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Country", cbCountry.Text);

            conn.Open();
            //================            
            SqlDataReader dr = cmd.ExecuteReader();
            lvCustomers.Items.Clear();

            bool isOdd = true;
            while (dr.Read())
            {
                int imgId = cbCountry.Items.IndexOf(dr["Country"]);
                ListViewItem item =       lvCustomers.Items.Add(Convert.ToString(dr["CustomerID"]),imgId);
                item.SubItems.Add(Convert.ToString(dr["CompanyName"]));
                item.SubItems.Add(Convert.ToString(dr["ContactName"]));
                item.SubItems.Add(Convert.ToString(dr["City"]));
                if (dr.IsDBNull(dr.GetOrdinal("Region")))
                {
                    item.SubItems.Add("--");
                }
                else
                {
                    item.SubItems.Add(Convert.ToString(dr["Region"]));
                }                
                item.SubItems.Add(Convert.ToString(dr["Country"]));
                item.SubItems.Add(Convert.ToString(dr["Phone"]));
                if (isOdd)
                {
                    item.BackColor = Color.LightGray;
                    isOdd = false;
                }
                else
                {
                    isOdd = true;
                }
            }
            
            dr.Close();
            cmd.Dispose();
            //================
            conn.Close();
            conn.Dispose();

        }

        private void lvCustomers_Resize(object sender, EventArgs e)
        {
            lvCustomers.Columns[0].Width = lvCustomers.Width / 10;
            lvCustomers.Columns[1].Width = lvCustomers.Width / 5;
            lvCustomers.Columns[2].Width = lvCustomers.Width / 5;
            lvCustomers.Columns[3].Width = lvCustomers.Width / 10;
            lvCustomers.Columns[4].Width = lvCustomers.Width / 10;
            lvCustomers.Columns[5].Width = lvCustomers.Width / 10;
            lvCustomers.Columns[6].Width = lvCustomers.Width / 5;
        }

        private void 大型圖示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvCustomers.View = View.LargeIcon;
        }

        private void 小型圖示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvCustomers.View = View.SmallIcon ;
        }

        private void 清單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvCustomers.View = View.List;
        }

        private void 詳細資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvCustomers.View = View.Details;
        }

        private void 並排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvCustomers.View = View.Tile;
            lvCustomers.Width++;
            lvCustomers.Width--;
        }
    }
}
