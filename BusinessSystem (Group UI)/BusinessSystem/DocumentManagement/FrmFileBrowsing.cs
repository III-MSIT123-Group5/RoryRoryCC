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
        BusinessDataBaseEntities dbContext=new BusinessDataBaseEntities();
        public FrmFileBrowsing()
        {
            InitializeComponent();
            MyUpdate();
        }
        

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            //開啟檔案
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //資料存入DB
                

                var q = dbContext.Files.AsEnumerable().Where(f => f.FileName!= Path.GetFileNameWithoutExtension(this.openFileDialog1.SafeFileName)).Select(f=>f.FileName);
                //todo判斷失敗
                string MyRepeat = q.FirstOrDefault();
                if (MyRepeat!=null)
                {
                    DialogResult MyResult = MessageBox.Show("已有此檔案!確認要覆蓋嗎?", "檔案重複", MessageBoxButtons.YesNo);
                    if (MyResult == DialogResult.Yes)
                    {
                        var q2 = dbContext.Files.AsEnumerable().Single(f=>f.FileName.Equals(this.openFileDialog1.FileName));
                        dbContext.Files.Remove(q2);
                        dbContext.SaveChanges();
                        MyUpdate();
                        NewAdd(openFileDialog1.FileName);
                        MessageBox.Show("覆蓋成功");
                    }
                }
                else
                {
                    NewAdd(openFileDialog1.FileName);
                    MessageBox.Show("新增成功");
                }
                MyUpdate();
            }


        }

        private void MyUpdate()
        {
            //更新dataGridView顯示
            dataGridView1.Columns.Clear();
            var q = dbContext.Files.OrderBy(f => f.FileID).Select(f => new
            {
                檔案編號 = f.FileID,
                檔案名稱 = f.FileName,
                檔案大小 = f.FileSize,
                上傳時間 = f.UploadDate,
                檔案類型 = f.Extension
            });
            this.dataGridView1.DataSource = q.ToList();
        }

        private void NewAdd(string fileName)
        {
            //新增檔案
            FileStream loadFile = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            BinaryReader filereader = new BinaryReader(loadFile);

            byte[] filecontent = filereader.ReadBytes(System.Convert.ToInt32(loadFile.Length));
            filereader.Close();
            loadFile.Close();
            System.IO.FileInfo fileInfo = new FileInfo(fileName);
            dbContext.Files.Add(new BusinessSystemDBEntityModel.File
            {
                FileName = Path.GetFileNameWithoutExtension(fileName),
                Data = filecontent,
                FileSize = fileInfo.Length.ToString(),
                EmployeeID = 1001,
                UploadDate = DateTime.Now,
                Extension = Path.GetExtension(fileName)
            });
            dbContext.SaveChanges();
            
        }

        private void clsAltoButton3_Click(object sender, EventArgs e)
        {
            //刪除
            MyUpdate();
            DataGridViewButtonColumn MyDelete = new DataGridViewButtonColumn();
            MyDelete.Text = "刪除";
            MyDelete.HeaderText = "刪除";
            MyDelete.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(MyDelete);
            Judgment = "刪除";
            
        }
        string Judgment;
        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            //下載
             MyUpdate();
            DataGridViewButtonColumn MyDelete = new DataGridViewButtonColumn();
            MyDelete.Text = "下載";
            MyDelete.HeaderText = "下載";
            MyDelete.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(MyDelete);
            Judgment = "下載";


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (Judgment)
            {
                case "下載":
            var q=dbContext.Files.AsEnumerable().Where(f=> f.FileName == this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

            saveFileDialog1.FileName =q.Select(f => f.Extension).FirstOrDefault();
            saveFileDialog1.DefaultExt = saveFileDialog1.FileName;
            saveFileDialog1.Filter = $"(*{saveFileDialog1.FileName})|";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter bw = new
BinaryWriter(File.Open(saveFileDialog1.FileName, FileMode.OpenOrCreate));
                        foreach (var bt in q.Select(f => f.Data))
                        {
                            bw.Write(bt);
                        }
                        bw.Close();
                        MessageBox.Show("下載成功!");
                    }
                    break;
                case "刪除":
                    var q2 = dbContext.Files.AsEnumerable().Single(f => f.FileName == this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    dbContext.Files.Remove(q2);
                    dbContext.SaveChanges();
                    MyUpdate();
                    MessageBox.Show("刪除成功!");
                    break;
                    
          }  
        }
    }
}
