using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
        BusinessSystemDBEntityModel.BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();
        public FormAdd()
        {
            InitializeComponent();

            var q = from reptime in dbcontext.ReportTimeSystems
                    join eve in dbcontext.Events
                    on reptime.EventID equals eve.EventID
                    select eve.EventName;
            comboBox1.DataSource = q.ToList();          
            
        }
        
        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
          

            dbcontext.ReportTimeSystems.Add(
                new BusinessSystemDBEntityModel.ReportTimeSystem
                {
                    employeeID = 0,
                    ApplyDateTime = DateTime.Now,
                    EventHours = int.Parse(comboBox2.Text),
                    EventID = FindID(comboBox1.Text),
                    Note = richTextBox1.Text,
                    Discontinue = true
                });
             
           
            dbcontext.SaveChanges();
            

        }


        private void FormAdd_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = dbcontext.Events.Select(n=>n.EventName).Distinct().ToList();
           
        }
        private int FindID(string Text)
        {
            int result = 0;

            if (dbcontext.Events.First().EventName == Text)
            {
                result = dbcontext.Events.First().EventID;
            }
            return result;

        }

    }
}
