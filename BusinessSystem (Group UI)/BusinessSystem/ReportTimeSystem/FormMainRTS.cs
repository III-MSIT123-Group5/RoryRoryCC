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
    public partial class FormMainRTS : Form
    {
        public FormMainRTS()
        {
            InitializeComponent();
        }

        
        

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
        }


        private void FormMainRTS_Load(object sender, EventArgs e)
        {

            var q = from RTS in dbcontext.ReportTimeSystems
                    join emp in dbcontext.Employees
                    on RTS.employeeID equals emp.employeeID
                    join eve in dbcontext.Events
                    on RTS.EventID equals eve.EventID
                    where RTS.Discontinue == true
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
            
            //dataGridView1.Columns[5] = dgvcc;
            
                

        }


        //呼叫新增資料的表單
        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            FormAdd formshow = new FormAdd(this);
            formshow.Show();
        }




        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            FormUpdate formshow = new FormUpdate();
            formshow.ShowDialog();

            
        }

        private void clsAltoButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            foreach (var q in listcatalog)
            {
                var w = dbcontext.ReportTimeSystems.Where(K => K.ReportID == q.報表編號).FirstOrDefault();

                if (w != null)
                {

                    w.Discontinue = false;


                }
            }
            dbcontext.SaveChanges();
        }
    }
}
