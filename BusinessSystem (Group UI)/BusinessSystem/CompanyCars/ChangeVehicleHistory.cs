using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessSystem.CompanyCars
{
    public partial class ChangeVehicleHistory : SonForm
    {


        //
        //全域變數
        //
        BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();
        int empID;
        int waterID =0;
        bool bbool = true; 
        //
        //
        //
        public ChangeVehicleHistory(int empid) : base(empid)
        {
            InitializeComponent();
            
            var q1 = from p in this.dbContext.CompanyVehicleHistories
                     where p.employeeID == LoginID
                     select new
                     {
                         租借編號 = p.VehicleHistoryID,
                         車牌號碼 = p.LicenseNumber,
                         起始時間 = p.StartDateTime,
                         歸還時間 = p.EndDateTime,
                         員工編號 = p.employeeID
                     };
            this.dataGridView1.DataSource = q1.ToList();
        }
        public void mytime1()
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
        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            mytime1();
            mytime2();
            DialogResult x = MessageBox.Show("確定要修改嗎", "確認修改", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                var q = from p in this.dbContext.CompanyVehicleHistories
                        where p.VehicleHistoryID == waterID
                        select p;
                foreach (var Change in q)
                {
                    Change.StartDateTime = this.dateTimePicker1.Value;
                    Change.EndDateTime = this.dateTimePicker2.Value;
                }
            }
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("修改成功！");
                this.dataGridView1.Update();
                this.dataGridView1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            waterID = int.Parse(this.dataGridView1.Rows[e.RowIndex ].Cells[0].Value .ToString ());
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

        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            
            DialogResult x =  MessageBox.Show("確定要刪除嗎", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                var q = (from p in this.dbContext.CompanyVehicleHistories
                         where p.VehicleHistoryID == waterID
                         select p).First();
                this.dbContext.CompanyVehicleHistories.Remove(q);
                this.dbContext.SaveChanges();
                MessageBox.Show("刪除成功");
                this.Close();
            }
        }
    }
}
