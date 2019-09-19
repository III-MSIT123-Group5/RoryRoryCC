using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessSystemDBEntityModel;



namespace BusinessSystem.ReportTimeSystem
{
    public partial class FormAdd : SonForm
    {
        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();
        FormMainRTS rts ;
        

        public FormAdd(FormMainRTS ff)
        {
            InitializeComponent();
            rts = ff;

        }
        
       
        int result=0;
        private int FindID(string Text)
        {
            

            if (dbcontext.Events.First().EventName == Text)
            {
                result = dbcontext.Events.First().EventID;
            } 
            return result;
           
        }
      
       

        private void FormAdd_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = dbcontext.Events.Select(p => p.EventName).ToList();

            



        }


       
        private void clsAltoButton1_Click(object sender, EventArgs e)
        {

            dbcontext.ReportTimeSystems.Add(
                new BusinessSystemDBEntityModel.ReportTimeSystem
                {

                    employeeID =FindID(label3.Text) ,
                    ApplyDateTime = DateTime.Now,
                    EventHours = double.Parse(comboBox2.Text),
                    EventID = FindID(comboBox1.Text),
                    Note = richTextBox1.Text,
                    Discontinue = true
                });


            dbcontext.SaveChanges();
            MessageBox.Show("新增成功");
            var q = from RTS in dbcontext.ReportTimeSystems
                    join emp in dbcontext.Employees
                    on RTS.employeeID equals emp.employeeID
                    join eve in dbcontext.Events
                    on RTS.EventID equals eve.EventID
                    where RTS.Discontinue == true
                    select new
                    {
                        報表編號 = RTS.ReportID,
                        員工名稱 = emp.EmployeeName,
                        申請時間 = RTS.ApplyDateTime,
                        申請事件 = eve.EventName,
                        備註 = RTS.Note
                    };
            rts.dataGridView1.DataSource = q.ToList();
        
        }
    }
}
