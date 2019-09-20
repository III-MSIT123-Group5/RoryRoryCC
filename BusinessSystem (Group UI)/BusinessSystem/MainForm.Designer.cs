namespace BusinessSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeControl1 = new MainControls.TimeControl();
            this.employeeControl1 = new MainControls.EmployeeControl();
            this.mainControls4 = new MainControls.MainControls();
            this.mainControls1 = new MainControls.MainControls();
            this.mainControls3 = new MainControls.MainControls();
            this.mainControls2 = new MainControls.MainControls();
            this.mainControls8 = new MainControls.MainControls();
            this.mainControls5 = new MainControls.MainControls();
            this.mainControls9 = new MainControls.MainControls();
            this.mainControls7 = new MainControls.MainControls();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timeControl1);
            this.panel1.Controls.Add(this.employeeControl1);
            this.panel1.Controls.Add(this.mainControls4);
            this.panel1.Controls.Add(this.mainControls1);
            this.panel1.Controls.Add(this.mainControls3);
            this.panel1.Controls.Add(this.mainControls2);
            this.panel1.Controls.Add(this.mainControls8);
            this.panel1.Controls.Add(this.mainControls5);
            this.panel1.Controls.Add(this.mainControls9);
            this.panel1.Controls.Add(this.mainControls7);
            this.panel1.Location = new System.Drawing.Point(16, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 640);
            this.panel1.TabIndex = 51;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeControl1
            // 
            this.timeControl1.AMText = "AM";
            this.timeControl1.BackgroundColor = System.Drawing.Color.Empty;
            this.timeControl1.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.timeControl1.DateText = "2019/9/20";
            this.timeControl1.Location = new System.Drawing.Point(6, 3);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.SecondText = "59";
            this.timeControl1.Size = new System.Drawing.Size(411, 200);
            this.timeControl1.TabIndex = 55;
            this.timeControl1.TimeText = "10:00";
            this.timeControl1.TitleColor = System.Drawing.Color.White;
            // 
            // employeeControl1
            // 
            this.employeeControl1.BackgroundColor = System.Drawing.Color.Empty;
            this.employeeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.employeeControl1.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.employeeControl1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.employeeControl1.image = null;
            this.employeeControl1.ImageLocation = null;
            this.employeeControl1.Location = new System.Drawing.Point(626, 3);
            this.employeeControl1.Name = "employeeControl1";
            this.employeeControl1.Size = new System.Drawing.Size(200, 200);
            this.employeeControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeeControl1.TabIndex = 53;
            this.employeeControl1.Title = "label";
            this.employeeControl1.TitleColor = System.Drawing.Color.White;
            this.employeeControl1.Click += new System.EventHandler(this.employeeControl1_Click);
            this.employeeControl1.MouseEnter += new System.EventHandler(this.employeeControl1_MouseEnter);
            this.employeeControl1.MouseLeave += new System.EventHandler(this.employeeControl1_MouseLeave);
            // 
            // mainControls4
            // 
            this.mainControls4.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls4.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls4.image = global::BusinessSystem.Properties.Resources.edit_property_128;
            this.mainControls4.ImageLocation = null;
            this.mainControls4.Location = new System.Drawing.Point(6, 206);
            this.mainControls4.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls4.Name = "mainControls4";
            this.mainControls4.Size = new System.Drawing.Size(411, 200);
            this.mainControls4.TabIndex = 50;
            this.mainControls4.Title = "佈告欄";
            this.mainControls4.TitleColor = System.Drawing.Color.White;
            this.mainControls4.Click += new System.EventHandler(this.mainControls4_Click);
            this.mainControls4.MouseEnter += new System.EventHandler(this.mainControls4_MouseEnter);
            this.mainControls4.MouseLeave += new System.EventHandler(this.mainControls4_MouseLeave);
            // 
            // mainControls1
            // 
            this.mainControls1.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls1.ButtonColor = System.Drawing.Color.SlateGray;
            this.mainControls1.image = global::BusinessSystem.Properties.Resources.chair_2_128;
            this.mainControls1.ImageLocation = null;
            this.mainControls1.Location = new System.Drawing.Point(420, 410);
            this.mainControls1.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls1.Name = "mainControls1";
            this.mainControls1.Size = new System.Drawing.Size(200, 200);
            this.mainControls1.TabIndex = 49;
            this.mainControls1.Title = "會議室租借";
            this.mainControls1.TitleColor = System.Drawing.Color.White;
            this.mainControls1.MouseEnter += new System.EventHandler(this.mainControls1_MouseEnter);
            this.mainControls1.MouseLeave += new System.EventHandler(this.mainControls1_MouseLeave);
            // 
            // mainControls3
            // 
            this.mainControls3.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls3.ButtonColor = System.Drawing.Color.SlateGray;
            this.mainControls3.image = global::BusinessSystem.Properties.Resources.briefcase_128;
            this.mainControls3.ImageLocation = null;
            this.mainControls3.Location = new System.Drawing.Point(626, 205);
            this.mainControls3.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls3.Name = "mainControls3";
            this.mainControls3.Size = new System.Drawing.Size(200, 200);
            this.mainControls3.TabIndex = 48;
            this.mainControls3.Title = "工時回報";
            this.mainControls3.TitleColor = System.Drawing.Color.White;
            this.mainControls3.Click += new System.EventHandler(this.mainControls3_Click);
            this.mainControls3.MouseEnter += new System.EventHandler(this.mainControls3_MouseEnter);
            this.mainControls3.MouseLeave += new System.EventHandler(this.mainControls3_MouseLeave);
            // 
            // mainControls2
            // 
            this.mainControls2.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls2.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.mainControls2.image = global::BusinessSystem.Properties.Resources.car_128;
            this.mainControls2.ImageLocation = null;
            this.mainControls2.Location = new System.Drawing.Point(216, 409);
            this.mainControls2.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls2.Name = "mainControls2";
            this.mainControls2.Size = new System.Drawing.Size(200, 200);
            this.mainControls2.TabIndex = 47;
            this.mainControls2.Title = "公務車租借";
            this.mainControls2.TitleColor = System.Drawing.Color.White;
            this.mainControls2.Click += new System.EventHandler(this.mainControls2_Click);
            this.mainControls2.MouseEnter += new System.EventHandler(this.mainControls2_MouseEnter);
            this.mainControls2.MouseLeave += new System.EventHandler(this.mainControls2_MouseLeave);
            // 
            // mainControls8
            // 
            this.mainControls8.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls8.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.mainControls8.image = global::BusinessSystem.Properties.Resources.time_8_128;
            this.mainControls8.ImageLocation = null;
            this.mainControls8.Location = new System.Drawing.Point(421, 206);
            this.mainControls8.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls8.Name = "mainControls8";
            this.mainControls8.Size = new System.Drawing.Size(200, 200);
            this.mainControls8.TabIndex = 46;
            this.mainControls8.Title = "請假";
            this.mainControls8.TitleColor = System.Drawing.Color.White;
            this.mainControls8.MouseEnter += new System.EventHandler(this.mainControls8_MouseEnter);
            this.mainControls8.MouseLeave += new System.EventHandler(this.mainControls8_MouseLeave);
            // 
            // mainControls5
            // 
            this.mainControls5.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls5.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls5.image = global::BusinessSystem.Properties.Resources.calendar_3_128;
            this.mainControls5.ImageLocation = null;
            this.mainControls5.Location = new System.Drawing.Point(422, 3);
            this.mainControls5.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls5.Name = "mainControls5";
            this.mainControls5.Size = new System.Drawing.Size(200, 200);
            this.mainControls5.TabIndex = 44;
            this.mainControls5.Title = "行事曆";
            this.mainControls5.TitleColor = System.Drawing.Color.White;
            this.mainControls5.MouseEnter += new System.EventHandler(this.mainControls5_MouseEnter);
            this.mainControls5.MouseLeave += new System.EventHandler(this.mainControls5_MouseLeave);
            // 
            // mainControls9
            // 
            this.mainControls9.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls9.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls9.image = global::BusinessSystem.Properties.Resources.cart_5_128;
            this.mainControls9.ImageLocation = null;
            this.mainControls9.Location = new System.Drawing.Point(626, 409);
            this.mainControls9.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls9.Name = "mainControls9";
            this.mainControls9.Size = new System.Drawing.Size(200, 200);
            this.mainControls9.TabIndex = 43;
            this.mainControls9.Title = "請購系統";
            this.mainControls9.TitleColor = System.Drawing.Color.White;
            this.mainControls9.Click += new System.EventHandler(this.mainControls9_Click);
            this.mainControls9.MouseEnter += new System.EventHandler(this.mainControls9_MouseEnter);
            this.mainControls9.MouseLeave += new System.EventHandler(this.mainControls9_MouseLeave);
            // 
            // mainControls7
            // 
            this.mainControls7.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls7.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainControls7.ForeColor = System.Drawing.Color.White;
            this.mainControls7.image = global::BusinessSystem.Properties.Resources.report_3_128;
            this.mainControls7.ImageLocation = null;
            this.mainControls7.Location = new System.Drawing.Point(10, 409);
            this.mainControls7.Margin = new System.Windows.Forms.Padding(2);
            this.mainControls7.Name = "mainControls7";
            this.mainControls7.Size = new System.Drawing.Size(200, 200);
            this.mainControls7.TabIndex = 41;
            this.mainControls7.Title = "文件上傳";
            this.mainControls7.TitleColor = System.Drawing.Color.Empty;
            this.mainControls7.Click += new System.EventHandler(this.mainControls7_Click);
            this.mainControls7.MouseEnter += new System.EventHandler(this.mainControls7_MouseEnter);
            this.mainControls7.MouseLeave += new System.EventHandler(this.mainControls7_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 684);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private MainControls.MainControls mainControls7;
        private MainControls.MainControls mainControls9;
        private MainControls.MainControls mainControls5;
        private MainControls.MainControls mainControls8;
        private MainControls.MainControls mainControls2;
        private MainControls.MainControls mainControls3;
        private MainControls.MainControls mainControls1;
        private MainControls.MainControls mainControls4;
        private System.Windows.Forms.Panel panel1;
        private MainControls.EmployeeControl employeeControl1;
        private MainControls.TimeControl timeControl1;
        private System.Windows.Forms.Timer timer1;
    }
}