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

        
        

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();

        private void FormMainRTS_Load(object sender, EventArgs e)
        {
            
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
            

            this.dataGridView1.DataSource = q.ToList();




        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            FormAdd formshow = new FormAdd();
            formshow.ShowDialog();
        }

        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            FormUpdate formshow = new FormUpdate();
            formshow.ShowDialog();


        }



        public void RefreshGridView()
        {
            this.dataGridView1.Refresh();
        }
    }
}
