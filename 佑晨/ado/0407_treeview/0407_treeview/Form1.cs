using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0407_treeview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string strCountry = "";
        string strCity = "";
        string strCustomerID = "";
        TreeNode CountryNode = null;
        TreeNode CityNode = null;
        TreeNode CusNode = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
            if (lf.DialogResult == DialogResult.Cancel)
            {
                Close();
            }
            else
            {
                if (LoginCheck(lf.txtUsername.Text , lf.txtPassword.Text))
                {

                    // TODO: 這行程式碼會將資料載入 'northwindDataSet.Orders' 資料表。您可以視需要進行移動或移除。
                    this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
                    // TODO: 這行程式碼會將資料載入 'northwindDataSet.Customers' 資料表。您可以視需要進行移動或移除。
                    this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

                    foreach (NorthwindDataSet.CustomersRow row in northwindDataSet.Customers.Rows)
                    {
                        if (strCountry != row.Country)
                        {
                            CountryNode = treeView1.Nodes.Add(row.Country);
                            CountryNode.ImageIndex = 0;
                            CountryNode.SelectedImageIndex = 1;
                            CountryNode.Tag = "國家";
                            strCountry = row.Country;
                            strCity = "";
                        }
                        if (strCity != row.City)
                        {
                            CityNode = CountryNode.Nodes.Add(row.City);
                            CityNode.ImageIndex = 0;
                            CityNode.SelectedImageIndex = 1;
                            CityNode.Tag = "城市";
                            strCity = row.City;
                            strCustomerID = "";
                        }
                        if (strCustomerID != row.CustomerID)
                        {
                            CusNode = CityNode.Nodes.Add(row.CustomerID);
                            CusNode.ImageIndex = 2;
                            CusNode.SelectedImageIndex = 3;
                            CusNode.Tag = "客戶";
                            strCustomerID = row.CustomerID;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("登入失敗!");
                }
                }
            }

        private bool LoginCheck(string Username, string Password)
        {
            string strConn = ConfigurationManager.ConnectionStrings["_0407_treeview.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            string strSQL = "LoginCheck";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 16);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = Username;
            cmd.Parameters.Add(pUsername);

            SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.VarBinary, 32);
            pPassword.Direction = ParameterDirection.Input;
            byte[] bytesPassword = Encoding.Unicode.GetBytes(Password);
            SHA256Managed Alogorithm = new SHA256Managed();
            pPassword.Value = Alogorithm.ComputeHash(bytesPassword);
            cmd.Parameters.Add(pPassword);

            SqlParameter pReturnValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            pReturnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(pReturnValue);

            conn.Open();
            //================
            cmd.ExecuteNonQuery();

            int n = Convert.ToInt32(cmd.Parameters["@RETURN_VALUE"].Value);
            
            //================    
            conn.Close();
            conn.Dispose();
            return n == 1 ? true : false;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataView dv = new DataView();
            switch (Convert.ToString(e.Node.Tag))
            {
                case "國家":
                    dv.Table = northwindDataSet.Customers;
                    dv.RowFilter = $"Country = '{e.Node.Text}'";
                    break;
                case "城市":
                    dv.Table = northwindDataSet.Customers;
                    dv.RowFilter = $"City = '{e.Node.Text}'";
                    break;
                case "客戶":
                    dv.Table = northwindDataSet.Orders;
                    dv.RowFilter = $"CustomerID = '{e.Node.Text}'";
                    break;
            }
            dataGridView1.DataSource = dv;

            e.Node.Expand();
        }
    }
}
