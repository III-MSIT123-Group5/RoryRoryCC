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
    //public partial class FrmFileBrowsing : Form

    {
        BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();
        public FrmFileBrowsing(int empid) : base(empid)
        {
            InitializeComponent();
            //顯示檔案
            MyUpdate();
            panel1.Visible = false;
            panel2.Visible = false;
            dateTimePicker1.Visible = false;
            this.dataGridView1.Anchor = AnchorStyles.Top;
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
            var q = dbContext.Files.Join(dbContext.Employees, f => f.EmployeeID, e => e.employeeID, (f, e) => new
            {
                檔案編號 = f.FileID,
                檔案名稱 = f.FileName,
                檔案大小 = f.FileSize,
                上傳員工 = e.EmployeeName,
                上傳日期 = f.UploadDate,
                檔案類型 = f.Extension
            }).OrderBy(fe => fe.檔案編號);
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
                EmployeeID = LoginID,
                UploadDate = DateTime.Now,
                Extension = Path.GetExtension(fileName)
            });
            //儲存修改
            dbContext.SaveChanges();
            //更新顯示
            MyUpdate();

        }
        bool MyDiscriminate = true;
        private void clsAltoButton3_Click(object sender, EventArgs e)
        {
            //刪除
            if (MyDiscriminate)
            {
                AddButton("刪除");
                Judgment = "刪除";
                clsAltoButton3.Text = "關閉刪除";
                MyDiscriminate = false;
                clsAltoButton1.Visible = false;
                clsAltoButton2.Visible = false;
                clsAltoButton4.Visible = false;
                clsAltoButton9.Visible = false;

            }
            else
            {
                clsAltoButton3.Text = "刪除";
                MyDiscriminate = true;
                clsAltoButton1.Visible = true;
                clsAltoButton2.Visible = true;
                clsAltoButton4.Visible = true;
                clsAltoButton9.Visible = true;
                Judgment = "";
                MyUpdate();
            }
        }
        string Judgment;
        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            //下載
            if (MyDiscriminate)
            {
                AddButton("下載");
                Judgment = "下載";
                clsAltoButton2.Text = "關閉下載";
                MyDiscriminate = false;
                clsAltoButton4.Visible = false;
                clsAltoButton1.Visible = false;
                clsAltoButton3.Visible = false;
                clsAltoButton9.Visible = false;
            }
            else
            {
                clsAltoButton2.Text = "下載";
                MyDiscriminate = true;
                clsAltoButton1.Visible = true;
                clsAltoButton3.Visible = true;
                clsAltoButton4.Visible = true;
                clsAltoButton9.Visible = true;
                Judgment = "";
                MyUpdate();
            }

        }

        private void AddButton(string v)
        {
            DataGridViewButtonColumn MyButton = new DataGridViewButtonColumn();
            MyButton.Text = v;
            MyButton.HeaderText = v;
            MyButton.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(MyButton);
            this.dataGridView1.ScrollBars = ScrollBars.Both;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (Judgment + e.ColumnIndex)
            {
                case "下載6":
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
                case "刪除6":
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
        private void clsAltoButton4_Click(object sender, EventArgs e)
        {
            //查詢
            if(MyDiscriminate)
            {
                this.clsAltoButton4.Text = "關閉查詢";
                clsAltoButton1.Visible = false;
                clsAltoButton2.Visible = false;
                clsAltoButton3.Visible = false;
                MyDiscriminate = false;
                panel1.Visible = true;
                clsAltoButton4.Location=new Point(25, 328);
                clsAltoButton9.Location = new Point(25, 269);
                clsAltoButton4.BringToFront();
            }
            else
            {
                this.clsAltoButton4.Text = "條件查詢";
                clsAltoButton1.Visible = true;
                clsAltoButton2.Visible = true;
                clsAltoButton3.Visible = true;
                MyDiscriminate = true;
                panel1.Visible = false;
                clsAltoButton4.Location = new Point(25,210);
                clsAltoButton9.Location = new Point(25, 269);

            }
        }
        bool MyInquire = true;
        private void clsAltoButton7_Click(object sender, EventArgs e)
        {
            //查詢檔名
            if (MyInquire)
            {
                this.clsAltoButton7.Text = "關閉檔名";
                clsAltoButton4.Visible = false;
                clsAltoButton5.Visible = false;
                clsAltoButton6.Visible = false;
                clsAltoButton7.Location = new Point(23, this.clsAltoButton8.Location.Y + 121);
                clsAltoButton9.Location = new Point(25, this.clsAltoButton8.Location.Y + 113);
                MyInquire = false;
                panel2.Visible = true;
                panel2.BringToFront();
                clsAltoButton9.BringToFront();
                label1.Text = "檔案名稱";
            }
            else
            {
                this.clsAltoButton7.Text = "檔名";
                clsAltoButton4.Visible = true;
                clsAltoButton5.Visible = true;
                clsAltoButton6.Visible = true;
                MyInquire = true;
                panel2.Visible = false;
                clsAltoButton7.Location = new Point(23, 41);
                clsAltoButton9.Location = new Point(25, 269);
            }
        }

        private void clsAltoButton6_Click(object sender, EventArgs e)
        {
            //查詢員工
            if (MyInquire)
            {
                this.clsAltoButton6.Text = "關閉員工";
                clsAltoButton4.Visible = false;
                clsAltoButton5.Visible = false;
                clsAltoButton7.Visible = false;
                MyInquire = false;
                clsAltoButton6.Location = new Point(23, this.clsAltoButton8.Location.Y + 121);
                clsAltoButton9.Location = new Point(25, this.clsAltoButton8.Location.Y + 113);
                clsAltoButton9.BringToFront();
                panel2.Visible = true;
                panel2.BringToFront();
                label1.Text = "員工姓名";
            }
            else
            {
                this.clsAltoButton6.Text = "員工";
                clsAltoButton4.Visible = true;
                clsAltoButton5.Visible = true;
                clsAltoButton7.Visible = true;
                MyInquire = true;
                clsAltoButton6.Location = new Point(23, 100);
                panel2.Visible = false;
                clsAltoButton9.Location = new Point(25, 269);
            }
        }

        private void clsAltoButton5_Click(object sender, EventArgs e)
        {
            //查詢日期
            if (MyInquire)
            {
                this.clsAltoButton5.Text = "關閉日期";
                clsAltoButton4.Visible = false;
                clsAltoButton7.Visible = false;
                clsAltoButton6.Visible = false;
                MyInquire = false;
                clsAltoButton5.Location = new Point(23, this.clsAltoButton8.Location.Y+121);
                clsAltoButton9.Location = new Point(25, this.clsAltoButton8.Location.Y + 113);
                panel2.Visible = true;
                panel2.BringToFront();
                clsAltoButton9.BringToFront();
                clsAltoButton5.BringToFront();
                label1.Text = "上傳日期";
                dateTimePicker1.Visible = true;
            }
            else
            {
                this.clsAltoButton5.Text = "日期";
                clsAltoButton4.Visible = true;
                clsAltoButton7.Visible = true;
                clsAltoButton6.Visible = true;
                MyInquire = true;
                clsAltoButton5.Location = new Point(23, 159);
                panel2.Visible = false;
                dateTimePicker1.Visible = false;
                clsAltoButton9.Location = new Point(25, 269);
            }
        }

        private void clsAltoButton8_Click(object sender, EventArgs e)
        {
            //依條件查詢
            switch(label1.Text)
            {
                case "檔案名稱":
                    var q = dbContext.Files.Join(dbContext.Employees, f => f.EmployeeID, emp => emp.employeeID, (f, emp) => new
                    {
                        檔案編號 = f.FileID,
                        檔案名稱 = f.FileName,
                        檔案大小 = f.FileSize,
                        上傳員工 = emp.EmployeeName,
                        上傳日期 = f.UploadDate,
                        檔案類型 = f.Extension
                    }).OrderBy(fe => fe.檔案編號).Where(fe=>fe.檔案名稱.Contains(textBox1.Text));
                    dataGridView1.Columns.Clear();
                    this.dataGridView1.DataSource = q.ToList();
                    break;
                case "員工姓名":
                    var q2 = dbContext.Files.Join(dbContext.Employees, f => f.EmployeeID, emp => emp.employeeID, (f, emp) => new
                    {
                        檔案編號 = f.FileID,
                        檔案名稱 = f.FileName,
                        檔案大小 = f.FileSize,
                        上傳員工 = emp.EmployeeName,
                        上傳日期 = f.UploadDate,
                        檔案類型 = f.Extension
                    }).OrderBy(fe => fe.檔案編號).Where(fe => fe.上傳員工.Contains(textBox1.Text));
                    dataGridView1.Columns.Clear();
                    this.dataGridView1.DataSource = q2.ToList();
                    break;
                case "上傳日期":
                    var q3 = dbContext.Files.Join(dbContext.Employees, f => f.EmployeeID, emp => emp.employeeID, (f, emp) => new
                    {
                        檔案編號 = f.FileID,
                        檔案名稱 = f.FileName,
                        檔案大小 = f.FileSize,
                        上傳員工 = emp.EmployeeName,
                        上傳日期 = f.UploadDate,
                        檔案類型 = f.Extension
                    }).OrderBy(fe => fe.檔案編號).Where(fe => fe.上傳日期.Day == dateTimePicker1.Value.Day);
                    dataGridView1.Columns.Clear();
                    this.dataGridView1.DataSource = q3.ToList();
                    break;
            }
        }

        private void clsAltoButton9_Click(object sender, EventArgs e)
        {
            MyUpdate();
        }


    }
}
