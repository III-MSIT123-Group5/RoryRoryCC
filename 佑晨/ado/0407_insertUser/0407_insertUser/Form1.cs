using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0407_insertUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string strConn = @"Data Source=. ; Initial Catalog=Northwind; Integrated Security=true";
            //string strSQL = @"Insert into Users(Username,Password) values(@Username , @Password)";
            string strSQL = "ProeInsert";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 16);
            pUsername.Direction = ParameterDirection.Input;
            pUsername.Value = txtUsername.Text;
            cmd.Parameters.Add(pUsername);

            SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.VarBinary, 32);
            pPassword.Direction = ParameterDirection.Input;
            byte[] bytesPassword = Encoding.Unicode.GetBytes(txtPassword.Text);
            SHA256Managed Alogorithm = new SHA256Managed();
            pPassword.Value = Alogorithm.ComputeHash(bytesPassword);
            cmd.Parameters.Add(pPassword);

            SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
            pID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pID);

            conn.Open();
            //================
            //int n = cmd.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            int n = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            //================
            //MessageBox.Show($"{n}筆資料新增成功!");
            MessageBox.Show($"User ID: {n}");
            conn.Close();
            conn.Dispose();

        }
    }
}
