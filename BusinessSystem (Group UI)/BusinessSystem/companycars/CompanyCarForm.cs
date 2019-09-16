using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BusinessSystem
{
    public partial class CompanyCarForm : SonForm
    {
        public CompanyCarForm()
        {
            InitializeComponent();
            
        }

        //全域變數======================
        string txt1 = " : 請輸入車號";
        string txt2 = " : 請輸入年分";
        string txt3 = " : 請輸入廠牌";
        string txt4 = " : 請輸入款式";
        string txt5 = " : 最大承載數";
        
        BusinessDataBaseEntities dbContext;

        //===============================
        


        //
        //顏色控制
        //
        
        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            this.label8.ForeColor = Color.LightSkyBlue;
        }

        private void label8_MouseUp(object sender, MouseEventArgs e)
        {
            this.label8.ForeColor = Color.Blue;
        }

        

        private void label8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                pictureBox2.Image = Image.FromFile(filename);
                this.label6.Text = "";
                this.label6.Text = filename;
                this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox1.Text == txt1 )
            {
                this.textBox1.Clear();
                if (this.textBox2.Text == "")
                {
                    this.textBox2.Text = txt2;
                }
                else if (this.textBox3.Text == "")
                {
                    this.textBox3.Text = txt3;
                }
                else if (this.textBox4.Text == "")
                {
                    this.textBox4.Text = txt4;
                }
                else if (this.textBox5.Text == "")
                {
                    this.textBox5.Text = txt5;
                }
            }

            else if  (this.textBox2.Text == "")
            {
                this.textBox2.Text = txt2;
            }

            else if (this.textBox3.Text == "")
            {
                this.textBox3.Text = txt3;
            }

            else if (this.textBox4.Text == "")
            {
                this.textBox4.Text = txt4;
            }

            else if (this.textBox5.Text == "")
            {
                this.textBox5.Text = txt5;
            }

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox2.Text == txt2 )
            {
                this.textBox2.Clear();

                if (this.textBox3.Text == "")
                {
                    this.textBox3.Text = txt3;
                }
                else if (this.textBox1.Text == "")
                {
                    this.textBox1.Text = txt1;
                }
                else if (this.textBox4.Text == "")
                {
                    this.textBox4.Text = txt4;
                }

                else if (this.textBox5.Text == "")
                {
                    this.textBox5.Text = txt5;
                }
            }
            else if  (this.textBox3.Text == "")
            {
                this.textBox3.Text = txt3;
            }
            else if (this.textBox1.Text == "")
            {
                this.textBox1.Text = txt1;
            }
            else if (this.textBox4.Text == "")
            {
                this.textBox4.Text = txt4;
            }

            else if (this.textBox5.Text == "")
            {
                this.textBox5.Text = txt5;
            }
        }
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox3.Text == txt3)
            {

                this.textBox3.Clear();
                if (this.textBox2.Text == "")
                {

                    this.textBox2.Text = txt2;
                }
                else if (this.textBox1.Text == "")
                {

                    this.textBox1.Text = txt1;
                }
                else if (this.textBox4.Text == "")
                {
                    this.textBox4.Text = txt4;
                }

                else if (this.textBox5.Text == "")
                {
                    this.textBox5.Text = txt5;
                }
            }
            else if (this.textBox2.Text == "")
            {

                this.textBox2.Text = txt2;
            }
            else if (this.textBox1.Text == "")
            {

                this.textBox1.Text = txt1;
            }
            else if (this.textBox4.Text == "")
            {
                this.textBox4.Text = txt4;
            }

            else if (this.textBox5.Text == "")
            {
                this.textBox5.Text = txt5;
            }
        }
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox4.Text == txt4)
            {

                this.textBox4.Clear();
                if (this.textBox2.Text == "")
                {

                    this.textBox2.Text = txt2;
                }
                else if (this.textBox1.Text == "")
                {

                    this.textBox1.Text = txt1;
                }
                else if (this.textBox3.Text == "")
                {
                    this.textBox3.Text = txt3;
                }

                else if (this.textBox5.Text == "")
                {
                    this.textBox5.Text = txt5;
                }
            }
            else if (this.textBox2.Text == "")
            {

                this.textBox2.Text = txt2;
            }
            else if (this.textBox1.Text == "")
            {

                this.textBox1.Text = txt1;
            }
            else if (this.textBox3.Text == "")
            {
                this.textBox3.Text = txt3;
            }

            else if (this.textBox5.Text == "")
            {
                this.textBox5.Text = txt5;
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.textBox5.Text == txt5)
            {

                this.textBox5.Clear();
                if (this.textBox2.Text == "")
                {

                    this.textBox2.Text = txt2;
                }
                else if (this.textBox1.Text == "")
                {

                    this.textBox1.Text = txt1;
                }
                else if (this.textBox4.Text == "")
                {
                    this.textBox4.Text = txt4;
                }

                else if (this.textBox3.Text == "")
                {
                    this.textBox3.Text = txt3;
                }
            }
            else if (this.textBox2.Text == "")
            {

                this.textBox2.Text = txt2;
            }
            else if (this.textBox1.Text == "")
            {

                this.textBox1.Text = txt1;
            }
            else if (this.textBox4.Text == "")
            {
                this.textBox4.Text = txt4;
            }

            else if (this.textBox3.Text == "")
            {
                this.textBox3.Text = txt3;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || this.textBox1.Focused)
            {
                this.textBox1.ForeColor = Color.Black;
            }
            else if (this.textBox1.Text == txt1)
            {
                this.textBox1.ForeColor = Color.Silver;
                this.textBox1.Text = txt1;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || this.textBox2.Focused)
            {
                this.textBox2.ForeColor = Color.Black;
            }
            else if (this.textBox2.Text == txt2)
            {
                this.textBox2.ForeColor = Color.Silver;
                this.textBox2.Text = txt2;
            }
        }
    
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || this.textBox3.Focused)
            {
                this.textBox3.ForeColor = Color.Black;
            }
            else if(this.textBox3.Text == txt3)
            {
                this.textBox3.ForeColor = Color.Silver;
                this.textBox3.Text = txt3;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || this.textBox4.Focused)
            {
                this.textBox4.ForeColor = Color.Black;
            }
            else if (this.textBox4.Text == txt4)
            {
                this.textBox4.ForeColor = Color.Silver;
                this.textBox4.Text = txt4;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || this.textBox5.Focused)
            {
                this.textBox5.ForeColor = Color.Black;
            }
            else if (this.textBox5.Text == txt5)
            {
                this.textBox5.ForeColor = Color.Silver;
                this.textBox5.Text = txt5;
            }
        }

        private void clsAltoButton2_Click(object sender, EventArgs e)
        {
            dbContext = new BusinessDataBaseEntities();
            FileStream fs = System.IO.File.OpenRead(label6.Text);
            byte[] imageb = new byte[fs.Length];
            fs.Read(imageb, 0, imageb.Length);
            try
            {
                var q = new CompanyVehicle
                        
                {
                    LicenseNumber = textBox1.Text,
                    VehicleYear = int.Parse(textBox2.Text),
                    PurchaseDate = dateTimePicker1.Value,
                    brand = textBox3.Text,
                    serial = textBox4.Text,
                    MaxPassenger = textBox5.Text,
                    officeID = int.Parse(comboBox1.Text),
                    VehiclePhoto = imageb
                };
                dbContext.CompanyVehicles.Add(q);
                dbContext.SaveChanges();
                MessageBox.Show("Succeed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        //public void imgToDB(string sql)
        //{   //引數sql中要求儲存的imge變數名稱為@images
        //    //呼叫方法如:imgToDB("update UserPhoto set Photo=@images where UserNo='" + temp + "'");
            
        //    SqlCommand com3 = new SqlCommand(sql, con);
        //    com3.Parameters.Add("@images", SqlDbType.Image).Value = imageb;
        //    if (com3.Connection.State == ConnectionState.Closed)
        //        com3.Connection.Open();
        //    try
        //    {
        //        com3.ExecuteNonQuery();
        //    }
        //    catch
        //    { }
        //    finally
        //    { com3.Connection.Close(); }
        //}

    }
}
