using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0409_Imagebox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = picImage.ImageLocation = openFileDialog1.FileName;
            }
          
        }

        string GetConnectString()
        {
            return ConfigurationManager.ConnectionStrings["_0409_Imagebox.Properties.Settings.NorthwindConnectionString"].ConnectionString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtFileName.Text != "")
            {
                string strConn = GetConnectString();
                string strCmd = @"insert into imagetable(imagecontent) values(@ImageContent)";
                using(SqlConnection conn = new SqlConnection(strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlParameter p = new SqlParameter("@ImageContent", SqlDbType.VarBinary);
                        p.Direction = ParameterDirection.Input;
                        using(FileStream fs = new FileStream(txtFileName.Text , FileMode.Open, FileAccess.Read))
                        {
                            byte[] data = new byte[fs.Length];
                            fs.Read(data, 0, (int)fs.Length);
                            p.Value = data;
                        }
                        cmd.Parameters.Add(p);
                        conn.Open();
                        int n = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{n}筆資料新增成功!");
                    }
                }
            }
            else
            {
                MessageBox.Show("先選圖啦!");
            }
        }


        private void imageTableBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.imageTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

       

        private void imageIDLabel1_TextChanged(object sender, EventArgs e)
        {
            if(imageIDLabel1.Text != "")
            {
                string strConn = GetConnectString();
                string strCmd = @"select ImageContent  from imagetable where ImageID = @ImageID";

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                    {

                        cmd.CommandType = CommandType.Text;
                        SqlParameter p = new SqlParameter("@ImageID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Input;
                        p.Value = imageIDLabel1.Text;
                        cmd.Parameters.Add(p);

                        conn.Open();
                        byte[] data = (byte[])cmd.ExecuteScalar();

                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            Bitmap bmp = new Bitmap(ms);
                            pictureBox1.Image = bmp;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.imageTableTableAdapter.Fill(this.northwindDataSet.ImageTable);
        }
    }
}
