using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessSystemDBEntityModel;

namespace BusinessSystem.ReportTimeSystem
{
    
    public partial class FormMainRTS : SonForm
    {
        
        public FormMainRTS()
        {
            InitializeComponent();
            
        }
        //public FormMainRTS(int empid) : base(empid)
        //{
        //    InitializeComponent();

        //}



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();

        public class data
        {
            public int 報表編號 { get; set; }
            public string 活動名稱 { get; set; }
            public DateTime 開始時間 { get; set; }
            public DateTime 結束時間 { get; set; }
            public double 所需總時數 { get; set; }
            public string 活動類型 { get; set; }
            public string 備註 { get; set; }
            public DateTime 申請時間 { get; set; }


        }
        //將資料先存於data內,使datagridview 的cell 可以做更改

        List<data> listcatalog = null;//建立一個list<data>把資料存到list
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result= MessageBox.Show( /*Environment.NewLine +*/ "資料是否更改",
                                                 "警告",
                                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (result == DialogResult.OK)
            {
                foreach (var q in listcatalog)
                {
                    var w = dbcontext.ReportTimeSystems.Where(K => K.ReportID == q.報表編號).FirstOrDefault();

                    if (w != null)
                    {

                        w.ReportName = q.活動名稱;
                        w.StartTime = q.開始時間;
                        w.EndTime = q.結束時間;
                        w.Note = q.備註;
                        w.ApplyDateTime = q.申請時間;
                    }

                }
                dbcontext.SaveChanges();
                MessageBox.Show("資料已更新");
            }
            else
            {
                var q = from RTS in dbcontext.ReportTimeSystems
                        join emp in dbcontext.Employees
                        on RTS.employeeID equals emp.employeeID
                        join eve in dbcontext.Events
                        on RTS.EventID equals eve.EventID
                        where RTS.Discontinue == true && RTS.employeeID == ClassEmployee.LoginEmployeeID
                        select new data
                        {
                            報表編號 = RTS.ReportID,
                            //員工名稱 = emp.EmployeeName,
                            活動名稱 = RTS.ReportName,
                            開始時間 = RTS.StartTime,
                            結束時間 = RTS.EndTime,
                            所需總時數 = RTS.EventHours,
                            活動類型 = eve.EventName,
                            備註 = RTS.Note,
                            申請時間 = RTS.ApplyDateTime
                        };

                listcatalog = q.ToList();
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = listcatalog;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                



                MessageBox.Show("請重新輸入");
            }



        }


        private void FormMainRTS_Load(object sender, EventArgs e)
        {
            
            
            var q = from RTS in dbcontext.ReportTimeSystems
                    join emp in dbcontext.Employees
                    on RTS.employeeID equals emp.employeeID
                    join eve in dbcontext.Events
                    on RTS.EventID equals eve.EventID
                    where RTS.Discontinue == true && RTS.employeeID ==ClassEmployee.LoginEmployeeID
                    select new data
                    {
                        報表編號 = RTS.ReportID,
                        //員工名稱 = emp.EmployeeName,
                        活動名稱 = RTS.ReportName,
                        開始時間 = RTS.StartTime,
                        結束時間 = RTS.EndTime,
                        所需總時數 = RTS.EventHours,
                        活動類型 = eve.EventName,
                        備註 = RTS.Note,
                        申請時間 = RTS.ApplyDateTime
                    };

            listcatalog = q.ToList();
           
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = listcatalog;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            if (this.dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count;)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    i += 2;
                }
            }




        }


        //呼叫新增資料的表單
        private void AddRTSButton_Click(object sender, EventArgs e)
        {
            FormAdd formshow = new FormAdd(this);
            formshow.Show();
        }

        private void ChartRTSButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteRTSButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( /*Environment.NewLine +*/ "資料是否刪除",
                                                 "警告",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            
            foreach (var y in listcatalog)
            {
                if (y.報表編號.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                {
                    var w = dbcontext.ReportTimeSystems.Where(K => K.ReportID ==y.報表編號).FirstOrDefault();

                    if (w != null)
                    {

                        w.Discontinue = false;

                    }

                }
                
            }
            
                dbcontext.SaveChanges();
                MessageBox.Show("資料已刪除");
                
            


            var q = from RTS in dbcontext.ReportTimeSystems
                    join emp in dbcontext.Employees
                    on RTS.employeeID equals emp.employeeID
                    join eve in dbcontext.Events
                    on RTS.EventID equals eve.EventID
                    where RTS.Discontinue == true && RTS.employeeID==ClassEmployee.LoginEmployeeID
                    select new data
                    {
                        報表編號 = RTS.ReportID,
                        //員工名稱 = emp.EmployeeName,
                        活動名稱 = RTS.ReportName,
                        開始時間 = RTS.StartTime,
                        結束時間 = RTS.EndTime,
                        所需總時數 = RTS.EventHours,
                        活動類型 = eve.EventName,
                        備註 = RTS.Note,
                        申請時間 = RTS.ApplyDateTime
                    };

            listcatalog = q.ToList();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = listcatalog;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            if (this.dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count;)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    i += 2;
                }
            }






        }
    }
}
