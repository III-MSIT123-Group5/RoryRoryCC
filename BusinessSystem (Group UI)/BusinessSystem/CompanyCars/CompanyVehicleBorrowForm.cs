using BusinessSystemControlLibrary;
using BusinessSystemDBEntityModel;
using Controls;
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
        private void mytime1()
        {
            int t1 = 0;
            string Tmm = this.comboBox3.Text;
            if (Tmm == "09:00")
            {
                t1 = 09;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "10:00")
            {
                t1 = 10;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "11:00")
            {
                t1 = 11;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "12:00")
            {
                t1 = 12;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "01:00")
            {
                t1 = 13;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "02:00")
            {
                t1 = 14;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "03:00")
            {
                t1 = 15;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "04:00")
            {
                t1 = 16;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
            else if (Tmm == "05:00")
            {
                t1 = 17;
                DateTime dtstart = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value
                .Month, this.dateTimePicker1.Value.Day, t1, 00, 00);
                this.dateTimePicker1.Value = dtstart;
            }
        }
        private void mytime2()
        {
            int t1 = 0;
            string Tmm = this.comboBox4.Text;
            if (Tmm == "09:00")
            {
                t1 = 09;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "10:00")
            {
                t1 = 10;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "11:00")
            {
                t1 = 11;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "12:00")
            {
                t1 = 12;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "01:00")
            {
                t1 = 13;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "02:00")
            {
                t1 = 14;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "03:00")
            {
                t1 = 15;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "04:00")
            {
                t1 = 16;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
            else if (Tmm == "05:00")
            {
                t1 = 17;
                DateTime dtstart = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value
                .Month, this.dateTimePicker2.Value.Day, t1, 00, 00);
                this.dateTimePicker2.Value = dtstart;
            }
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
        
        
        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            mytime1();
            mytime2();
            if (this.dateTimePicker1.Value < this.dateTimePicker2.Value)
            {
                MessageBox.Show(((this.dateTimePicker2.Value- this.dateTimePicker1.Value).Hours ).ToString());
                MessageBox.Show(this.dateTimePicker1.Value.ToString());
                MessageBox.Show(this.dateTimePicker2.Value.ToString());
            }
            
            
            
        }
    }
}
