using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

namespace BusinessSystem.DocumentManagement
{
    public partial class FrmFileBrowsing : SonForm
    {
        public FrmFileBrowsing()
        {
            InitializeComponent();
        }
        BusinessDataBaseEntities dbContext;

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            //開啟檔案
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //資料存入DB
                FileStream loadFile = File.Open(this.openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                BinaryReader filereader = new BinaryReader(loadFile);

                byte[] filecontent = filereader.ReadBytes(System.Convert.ToInt32(loadFile.Length));
                filereader.Close();
                loadFile.Close();
                //==========================

                var q = dbContext.Files.Where(f => f.FileName.Equals(this.openFileDialog1.FileName)).Select(f => f.FileID);
                int Coumt = q.Count();
                if (Coumt != 0)
                {
                    DialogResult MyResult = MessageBox.Show("已有此檔案!確認要覆蓋嗎?", "檔案重複", MessageBoxButtons.YesNo);
                    if (MyResult == DialogResult.Yes)
                    {

                        var q2 = dbContext.Files.Select(f => new { f.FileName, f.Data, f.FileSize, f.EmployeeID, f.UploadDate });

                    }
                    //==========================

                    //string StrSQL = @"FileName,Data from [File]";
                    //SqlConnection conn = new SqlConnection(StrConn);
                    //SqlCommand cmd = new SqlCommand(StrSQL, conn);
                    //cmd.CommandType = CommandType.Text;

                    //conn.Open();

                    //SqlCommand comm = conn.CreateCommand();

                    //comm.CommandText = "insert into [File](FileName,Data,FileSize,EmployeeID,UploadDate,Extension) values(@FileName,@Data,@FileSize,@EmployeeID,@UploadDate,@Extension)";
                    //comm.Parameters.Add(@"@FileName", SqlDbType.NVarChar);
                    //comm.Parameters.Add(@"@Data", SqlDbType.VarBinary, filecontent.Length);
                    //comm.Parameters.Add(@"@FileSize", SqlDbType.NVarChar);
                    //comm.Parameters.Add(@"@EmployeeID", SqlDbType.NVarChar);
                    //comm.Parameters.Add(@"@UploadDate", SqlDbType.DateTime);
                    //comm.Parameters.Add(@"@Extension", SqlDbType.NVarChar);

                    //comm.Parameters[@"@FileName"].Value = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    //comm.Parameters[@"@Data"].Value = filecontent;
                    //System.IO.FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                    //comm.Parameters[@"@FileSize"].Value = fileInfo.Length.ToString();
                    //comm.Parameters[@"@EmployeeID"].Value = "1";
                    //comm.Parameters[@"@UploadDate"].Value = DateTime.Now;
                    //comm.Parameters[@"@Extension"].Value. = Path.GetExtension(openFileDialog1.FileName);
                    //comm.ExecuteNonQuery();

                    //conn.Close();

                    //MessageBox.Show("上傳成功");
                    //this.fileTableAdapter.Fill(this.dataSet21.File);


                }

            }


        }
    }
}
