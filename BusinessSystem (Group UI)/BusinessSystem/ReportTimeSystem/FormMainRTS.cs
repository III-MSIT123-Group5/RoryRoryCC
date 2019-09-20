﻿using System;
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

        
        

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();

        public class data
        {
            public int 報表編號 { get; set; }
            public string 員工名稱 { get; set; }
            public DateTime 申請時間 { get; set; }
            public string 申請事件 { get; set; }
            public string 備註 { get; set; }

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
                    w.ReportID = q.報表編號;
                }
            }
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
                        員工名稱 = emp.EmployeeName,
                        申請時間 = RTS.ApplyDateTime,
                        //事件所需時間 =
                        申請事件 = eve.EventName,
                        備註 = RTS.Note
                    };

            listcatalog = q.ToList();
            
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = listcatalog;
            dataGridView1.Columns[0].ReadOnly = true;


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

        
    }
}
