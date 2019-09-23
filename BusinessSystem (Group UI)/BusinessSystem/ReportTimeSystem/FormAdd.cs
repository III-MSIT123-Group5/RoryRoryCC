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
        FormMainRTS rts;
        
        public FormAdd(/*int empid) : base(empid*/)
        {
            InitializeComponent();
             

        }


        public FormAdd(FormMainRTS ff)
        {
            InitializeComponent();
            rts = ff;


        }
        
        
        private int FindID(string Text)
        {

            var q = from eve in dbcontext.Events
                    where Text == eve.EventName
                    select eve.EventID ;
            
            return q.First();

        }



        private void FormAdd_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = dbcontext.Events.Select(p => p.EventName).ToList();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd tt hh:mm";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.CustomFormat = "yyyy/MM/dd tt hh:mm";
            
            if (dateTimePicker2.Value.TimeOfDay > dateTimePicker1.Value.TimeOfDay)
            {

            }
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            
            if (dateTimePicker2.Value > dateTimePicker1.Value &&
                this.textBox1.Text.Length>0&&
                this.textBox1.Text.Length<=10)
            {

                dbcontext.ReportTimeSystems.Add(
                new BusinessSystemDBEntityModel.ReportTimeSystem
                {
                    ReportName = textBox1.Text,
                    employeeID = ClassEmployee.LoginEmployeeID ,
                    StartTime = dateTimePicker1.Value,
                    EndTime = dateTimePicker2.Value,
                    EventHours = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).TotalHours,
                    EventID = FindID(comboBox1.Text),
                    Note = richTextBox1.Text,
                    ApplyDateTime = DateTime.Now,
                    Discontinue = true
                });


                dbcontext.SaveChanges();
                MessageBox.Show("新增成功");
                var q = from RTS in dbcontext.ReportTimeSystems
                        join emp in dbcontext.Employees
                        on RTS.employeeID equals emp.employeeID
                        join eve in dbcontext.Events
                        on RTS.EventID equals eve.EventID
                        where RTS.Discontinue == true  &&RTS.employeeID == ClassEmployee.LoginEmployeeID
                        select new
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
                rts.dataGridView1.DataSource = q.ToList();
                this.Close();


            }
            else
            {
                MessageBox.Show("請更正警示欄位");
            }

            if (rts.dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < rts.dataGridView1.Rows.Count;)
                {
                    rts.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    i += 2;
                }
            }
            
        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value <= dateTimePicker1.Value )
            {
                errorProvider1.SetError(dateTimePicker2, "結束時間需大於開始時間");
                
            }
            if (0<this.textBox1.Text.Length &&this.textBox1.Text.Length<11)
            {
                errorProvider1.SetError(textBox1, "請輸入活動名稱");
            }




        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
           
        }
    }
    
}
