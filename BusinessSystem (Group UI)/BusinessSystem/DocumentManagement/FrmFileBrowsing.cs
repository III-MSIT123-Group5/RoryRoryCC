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
        BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();
        public FrmFileBrowsing()
        {
            InitializeComponent();
            //顯示檔案
            MyUpdate();
            
        }


        private void clsAltoButton1_Click(object sender, EventArgs e)
        {

            //開啟檔案
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //資料存入DB

                //判斷選擇檔案的檔名是否與資料庫中檔案重複
                var q = dbContext.Files.AsEnumerable().FirstOrDefault(f => f.FileName.Equals(Path.GetFileNameWithoutExtension(this.openFileDialog1.SafeFileName)));
                //如果有傳回重複檔名
                if (q != null)
                {   //彈窗詢問是否覆蓋檔案
                    DialogResult MyResult = MessageBox.Show("已有此檔案!確認要覆蓋嗎?", "檔案重複", MessageBoxButtons.YesNo);
                    //選擇覆蓋檔案
                    if (MyResult == DialogResult.Yes)
                    {   //找到第一筆檔名重複的資料
                        var q2 = dbContext.Files.AsEnumerable().First(f => f.FileName.Equals(Path.GetFileNameWithoutExtension(this.openFileDialog1.SafeFileName)));
                        //刪除資料
                        dbContext.Files.Remove(q2);
                        //儲存變更
                        dbContext.SaveChanges();
                        //新增檔案
                        NewAdd(openFileDialog1.FileName);
                        MessageBox.Show("覆蓋成功");
                    }
                }
                else
                {   //新增檔案
                    NewAdd(openFileDialog1.FileName);
                    MessageBox.Show("新增成功");
                }

            }


        }

        private void MyUpdate()
        {
            //更新dataGridView顯示

            //清除現有顯示
            dataGridView1.Columns.Clear();
            //查詢欲顯示資料
            var q = dbContext.Files.OrderBy(f => f.FileID).Select(f => new
            {
                檔案編號 = f.FileID,
                檔案名稱 = f.FileName,
                檔案大小 = f.FileSize,
                上傳時間 = f.UploadDate,
                檔案類型 = f.Extension
            });
            //顯示在dataGridView1上
            this.dataGridView1.DataSource = q.ToList();
        }

        private void NewAdd(string fileName)
        {
            //新增檔案

            //讀取檔案資料
            FileStream loadFile = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader filereader = new BinaryReader(loadFile);
            //存入陣列中
            byte[] filecontent = filereader.ReadBytes(System.Convert.ToInt32(loadFile.Length));
            filereader.Close();
            loadFile.Close();
            System.IO.FileInfo fileInfo = new FileInfo(fileName);
            //存入DB
            dbContext.Files.Add(new BusinessSystemDBEntityModel.File
            {
                FileName = Path.GetFileNameWithoutExtension(fileName),
                Data = filecontent,
                FileSize = fileInfo.Length.ToString(),
                EmployeeID = 1001,
                UploadDate = DateTime.Now,
                Extension = Path.GetExtension(fileName)
            });
            //儲存修改
            dbContext.SaveChanges();
            //更新顯示
            MyUpdate();

        }
        bool MyDeleteText = true;
        private void clsAltoButton3_Click(object sender, EventArgs e)
        {
            //刪除
            if (MyDeleteText)
            {
                AddButton("刪除");
                Judgment = "刪除";
                clsAltoButton3.Text = "關閉刪除";
                MyDeleteText = false;
                clsAltoButton1.Visible = false;
                clsAltoButton2.Visible = false;
            }
            else
            {
                clsAltoButton3.Text = "刪除";
                MyDeleteText = true;
                clsAltoButton1.Visible = true;
                clsAltoButton2.Visible = true;
                Judgment = "";
            }
        }
        string Judgment;
        bool MyDownloadsText = true;
        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            //下載
            if (MyDownloadsText)
            {
                AddButton("下載");
                Judgment = "下載";
                clsAltoButton2.Text = "關閉下載";
                MyDownloadsText = false;
                clsAltoButton1.Visible = false;
                clsAltoButton3.Visible = false;
            }
            else
            {
                clsAltoButton2.Text = "下載";
                MyDownloadsText = true;
                clsAltoButton1.Visible = true;
                clsAltoButton3.Visible = true;
                Judgment = "";
            }

        }

        private void AddButton(string v)
        {
            MyUpdate();
            DataGridViewButtonColumn MyButton = new DataGridViewButtonColumn();
            MyButton.Text = v;
            MyButton.HeaderText = v;
            MyButton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(MyButton);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (Judgment + e.ColumnIndex)
            {
                case "下載5":
                    var q = dbContext.Files.AsEnumerable().Where(f => f.FileName == this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                    saveFileDialog1.FileName = q.Select(f => f.Extension).FirstOrDefault();
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
                case "刪除5":
                    DialogResult MyResult = MessageBox.Show("確定要刪除嗎?", "檔案刪除", MessageBoxButtons.YesNo);

                    if (MyResult == DialogResult.Yes)
                    {
                        var q2 = dbContext.Files.AsEnumerable().First(f => f.FileName == this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        dbContext.Files.Remove(q2);
                        dbContext.SaveChanges();
                        MyUpdate();
                        AddButton("刪除");
                        MessageBox.Show("刪除成功!");
                    }
                    break;

            }
        }
    }
}
