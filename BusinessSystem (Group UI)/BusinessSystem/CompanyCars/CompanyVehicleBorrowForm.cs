using BusinessSystemControlLibrary;
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

namespace BusinessSystem.CompanyCars
{
    public partial class CompanyVehicleBorrowForm : SonForm
    {

        //
        //全域變數
        //
        BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();
        int i;
        
        bool bbool = true; 
        //
        //
        //
        public CompanyVehicleBorrowForm()
        {
            InitializeComponent();
            mypic(); 
        }
        public void mypic()
        {
            var q = from p in dbcontext.CompanyVehicles
                    select p;
            List < CompanyVehicle > pphoto = q.ToList();
            
            for (i = 0; i < dbcontext.CompanyVehicles.Count(); i++)
            {
                UserControl1 x = new UserControl1();
                x.pic = pphoto[i].VehiclePhoto;
                x.licNu = pphoto[i].LicenseNumber;
                this.flowLayoutPanel1.Controls.Add(x);
                x.Scclick += new UserControl1.mmouse(x_Scclick);
                
            }
            
        }

        private void x_Scclick(object sender, EventArgs e , UserControl1 tthis)
        {
            var q = from a in this.dbcontext.CompanyVehicles    
                    where a .LicenseNumber == tthis.licNu           
                    select  new
                    {
                        車牌號碼 = a.LicenseNumber,
                        車輛年份 = a.VehicleYear,
                        車輛廠牌 = a.brand,
                        車輛型號 = a.serial,
                        乘坐人數 = a.MaxPassenger,
                        OfficeID = a.officeID
                    };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.comboBox3.Items.Clear();
            bbool = true; 
            if (bbool == true)
            {
                if (this.comboBox1.Text == "上午")
                {
                    this.comboBox3.Items.Add("9:00");
                    this.comboBox3.Items.Add("10:00");
                    this.comboBox3.Items.Add("11:00");
                    this.comboBox3.Items.Add("12:00");
                    bbool = false; 
                }
                else if (this.comboBox1.Text == "下午")
                {
                    this.comboBox3.Items.Add("01:00");
                    this.comboBox3.Items.Add("02:00");
                    this.comboBox3.Items.Add("03:00");
                    this.comboBox3.Items.Add("04:00");
                    this.comboBox3.Items.Add("05:00");
                    bbool = false;
                }
            }
            
            

        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            this.comboBox4.Items.Clear();
            bbool = true;
            if (bbool == true)
            {
                if (this.comboBox2.Text == "上午")
                {
                    this.comboBox4.Items.Add("9:00");
                    this.comboBox4.Items.Add("10:00");
                    this.comboBox4.Items.Add("11:00");
                    this.comboBox4.Items.Add("12:00");
                    bbool = false;
                }
                else if (this.comboBox2.Text == "下午")
                {
                    this.comboBox4.Items.Add("01:00");
                    this.comboBox4.Items.Add("02:00");
                    this.comboBox4.Items.Add("03:00");
                    this.comboBox4.Items.Add("04:00");
                    this.comboBox4.Items.Add("05:00");
                    bbool = false;
                }
                
            }
        }
    }
}
