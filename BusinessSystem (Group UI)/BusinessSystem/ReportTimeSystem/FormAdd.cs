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
        BusinessSystemDBEntityModel.ReportTimeSystem rts = new BusinessSystemDBEntityModel.ReportTimeSystem();

      
        public FormAdd()
        {
            InitializeComponent();
           
            
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

        private int FindID(string Text)
        {
            int result=0;

            if (dbcontext.Events.First().EventName == Text)
            {
                result = dbcontext.Events.First().EventID;
            } 
            return result;
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = dbcontext.Events.Select(n=>n.EventName).Distinct().ToList();
           
        }
    }
}
