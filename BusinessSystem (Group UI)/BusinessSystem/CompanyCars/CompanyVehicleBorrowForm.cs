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
        string licence;
        bool bbool = true;
        
        public CompanyVehicleBorrowForm(int empid) : base(empid)
        {
            InitializeComponent();
            
            //MessageBox.Show( LoginID.ToString()) ;
            //    var q = from e in this.dbcontext.Employees
            //            where e.EmployeeName == label3.Text
            //            select new { e.employeeID };
            //    foreach (var ID in q)
            //    {
            //        empID = ID.employeeID;
            //    }
        }
        public void mytime1()
        {
            int t1 = 0;
            string Tmm = this.comboBox3.Text;
            if (Tmm == "9:00")
            {
                t1 = 9;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "10:00")
            {
                t1 = 10;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "11:00")
            {
                t1 = 11;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "12:00")
            {
                t1 = 12;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "01:00")
            {
                t1 = 13;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "02:00")
            {
                t1 = 14;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "03:00")
            {
                t1 = 15;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "04:00")
            {
                t1 = 16;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
            else if (Tmm == "05:00")
            {
                t1 = 17;
                DateTime dtstart = new DateTime(this.dTPStartTime.Value.Year, this.dTPStartTime.Value
                .Month, this.dTPStartTime.Value.Day, t1, 00, 00);
                this.dTPStartTime.Value = dtstart;
            }
        }
        private void mytime2()
        {
            int t1 = 0;
            string Tmm = this.comboBox4.Text;
            if (Tmm == "9:00")
            {
                t1 = 9;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "10:00")
            {
                t1 = 10;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "11:00")
            {
                t1 = 11;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "12:00")
            {
                t1 = 12;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "01:00")
            {
                t1 = 13;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "02:00")
            {
                t1 = 14;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "03:00")
            {
                t1 = 15;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "04:00")
            {
                t1 = 16;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
            else if (Tmm == "05:00")
            {
                t1 = 17;
                DateTime dtstart = new DateTime(this.dTPEndTime.Value.Year, this.dTPEndTime.Value
                .Month, this.dTPEndTime.Value.Day, t1, 00, 00);
                this.dTPEndTime.Value = dtstart;
            }
        }
        public void mypic()                      //todo 方法add
        {
            string licenceNum = null;
            var Nlicence = from p in dbcontext.CompanyVehicleHistories
                    where (this.dTPStartTime.Value >= p.StartDateTime && this.dTPEndTime.Value <= p.EndDateTime) ||( ( this.dTPStartTime.Value >= p.StartDateTime && this.dTPStartTime.Value<p.EndDateTime) && this.dTPEndTime.Value > p.EndDateTime) ||( this.dTPStartTime.Value < p.StartDateTime &&( this.dTPEndTime.Value>p.StartDateTime && this.dTPEndTime.Value <= p.EndDateTime)) || (this.dTPStartTime.Value < p.StartDateTime && this.dTPEndTime.Value > p.EndDateTime)
                           select new {  p.LicenseNumber };
            var q2 = Nlicence.ToList();
            var AllLicence = from p in dbcontext.CompanyVehicles
                    select new { p.LicenseNumber};
            var q4 = AllLicence.ToList();
            var RightLicence = from right in q4
                      where q2.Contains(right) == false
                      select right ;
            var q6 = RightLicence.ToList();
            for(i = 0; i < RightLicence.Count();i++)
            {
                licenceNum = q6[i].LicenseNumber;
                var q =( from n in this.dbcontext.CompanyVehicles
                        where n.LicenseNumber == licenceNum
                        select new
                        {
                            n.LicenseNumber,
                            n.brand,
                            n.serial,
                            n.MaxPassenger,
                            n.officeID,
                            n.VehiclePhoto
                        }).FirstOrDefault();
                UserControl1 x = new UserControl1();
                x.pic = q.VehiclePhoto ;
                x.licNu = q.LicenseNumber;
                x.Scclick += new UserControl1.mmouse(x_Scclick);
                this.flowLayoutPanel1.Controls.Add(x);

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
            var q1 = from a in this.dbcontext.CompanyVehicles
                    where a.LicenseNumber == tthis.licNu
                    select new
                    {
                        a.LicenseNumber
                    };
            licence = q1.First().ToString();
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
            
            if (this.richTextBox1.Text != "" && this.comboBox3.Text != "" && this.comboBox4.Text != "" && this.dataGridView1.DataSource != null)
            {
                
                var q = new CompanyVehicleHistory
                {
                    LicenseNumber = this.dataGridView1.Rows[0].Cells["車牌號碼"].Value.ToString(),
                    StartDateTime = this.dTPStartTime.Value,
                    EndDateTime = this.dTPEndTime.Value,
                    employeeID = LoginID,
                    purpose = this.richTextBox1.Text
                };
                dbcontext.CompanyVehicleHistories.Add(q);
                dbcontext.SaveChanges();
                MessageBox.Show("借車成功！" + "\n" + "借車時數共 " + ((this.dTPEndTime.Value - this.dTPStartTime.Value).Days).ToString() + "日" + ((this.dTPEndTime.Value - this.dTPStartTime.Value).Hours).ToString() +"小時"+ "\n請準時歸還!");
                
            }
            else
            {
                MessageBox.Show("請正確操作", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            ChangeVehicleHistory x = new ChangeVehicleHistory(LoginID);
            x.Show();
        }

        

        private void clsAltoButton4_Click(object sender, EventArgs e)
        {
            CompanyCarForm x = new CompanyCarForm(LoginID);
            x.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();
            mytime1();
            mytime2();
            mypic();
        }
    }
}
