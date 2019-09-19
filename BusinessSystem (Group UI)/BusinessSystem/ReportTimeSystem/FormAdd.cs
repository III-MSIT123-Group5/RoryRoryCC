﻿using System;
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

        

        public FormAdd()
        {
            InitializeComponent();
            

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

                    employeeID =1001 ,
                    ApplyDateTime = DateTime.Now,
                    EventHours = double.Parse(comboBox2.Text),
                    EventID = FindID(comboBox1.Text),
                    Note = richTextBox1.Text,
                    Discontinue = true
                });


            dbcontext.SaveChanges();
            MessageBox.Show("新增成功");
            
        }
    }
}
