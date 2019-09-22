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
            this.timeControl1 = new MainControls.TimeControl();
            this.mcEmployee = new MainControls.EmployeeControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mcCalendar = new MainControls.MainControls();
            this.mcBulletinBoard = new MainControls.MainControls();
            this.mcLeave = new MainControls.MainControls();
            this.mcReportTime = new MainControls.MainControls();
            this.mcDocument = new MainControls.MainControls();
            this.mcCompanyCars = new MainControls.MainControls();
            this.mcMeetingRoom = new MainControls.MainControls();
            this.mcRequisition = new MainControls.MainControls();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeControl1
            // 
            this.timeControl1.AMText = "AM";
            this.timeControl1.BackgroundColor = System.Drawing.Color.Empty;
            this.timeControl1.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.timeControl1.DateText = "2019/9/20";
            this.timeControl1.Location = new System.Drawing.Point(16, 17);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.SecondText = "59";
            this.timeControl1.Size = new System.Drawing.Size(411, 200);
            this.timeControl1.TabIndex = 55;
            this.timeControl1.TimeText = "10:00";
            this.timeControl1.TitleColor = System.Drawing.Color.White;
            // 
            // mcEmployee
            // 
            this.mcEmployee.BackgroundColor = System.Drawing.Color.Empty;
            this.mcEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mcEmployee.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.mcEmployee.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.mcEmployee.image = null;
            this.mcEmployee.ImageLocation = null;
            this.mcEmployee.Location = new System.Drawing.Point(645, 17);
            this.mcEmployee.Name = "mcEmployee";
            this.mcEmployee.Size = new System.Drawing.Size(200, 200);
            this.mcEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mcEmployee.TabIndex = 53;
            this.mcEmployee.Title = "label";
            this.mcEmployee.TitleColor = System.Drawing.Color.White;
            this.mcEmployee.Click += new System.EventHandler(this.mcEmployee_Click);
            this.mcEmployee.MouseEnter += new System.EventHandler(this.mcEmployee_MouseEnter);
            this.mcEmployee.MouseLeave += new System.EventHandler(this.mcEmployee_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mcCalendar
            // 
            this.mcCalendar.BackgroundColor = System.Drawing.Color.Empty;
            this.mcCalendar.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mcCalendar.image = global::BusinessSystem.Properties.Resources.calendar_3_128;
            this.mcCalendar.ImageLocation = null;
            this.mcCalendar.Location = new System.Drawing.Point(436, 17);
            this.mcCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.mcCalendar.Name = "mcCalendar";
            this.mcCalendar.Size = new System.Drawing.Size(200, 200);
            this.mcCalendar.TabIndex = 44;
            this.mcCalendar.Title = "行事曆";
            this.mcCalendar.TitleColor = System.Drawing.Color.White;
            this.mcCalendar.MouseEnter += new System.EventHandler(this.mcCalendar_MouseEnter);
            this.mcCalendar.MouseLeave += new System.EventHandler(this.mcCalendar_MouseLeave);
            // 
            // mcBulletinBoard
            // 
            this.mcBulletinBoard.BackgroundColor = System.Drawing.Color.Empty;
            this.mcBulletinBoard.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mcBulletinBoard.image = global::BusinessSystem.Properties.Resources.edit_property_128;
            this.mcBulletinBoard.ImageLocation = null;
            this.mcBulletinBoard.Location = new System.Drawing.Point(16, 225);
            this.mcBulletinBoard.Margin = new System.Windows.Forms.Padding(2);
            this.mcBulletinBoard.Name = "mcBulletinBoard";
            this.mcBulletinBoard.Size = new System.Drawing.Size(411, 200);
            this.mcBulletinBoard.TabIndex = 50;
            this.mcBulletinBoard.Title = "佈告欄";
            this.mcBulletinBoard.TitleColor = System.Drawing.Color.White;
            this.mcBulletinBoard.Click += new System.EventHandler(this.mcBulletinBoard_Click);
            this.mcBulletinBoard.MouseEnter += new System.EventHandler(this.mcBulletinBoard_MouseEnter);
            this.mcBulletinBoard.MouseLeave += new System.EventHandler(this.mcBulletinBoard_MouseLeave);
            // 
            // mcLeave
            // 
            this.mcLeave.BackgroundColor = System.Drawing.Color.Empty;
            this.mcLeave.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.mcLeave.image = global::BusinessSystem.Properties.Resources.time_8_128;
            this.mcLeave.ImageLocation = null;
            this.mcLeave.Location = new System.Drawing.Point(436, 225);
            this.mcLeave.Margin = new System.Windows.Forms.Padding(2);
            this.mcLeave.Name = "mcLeave";
            this.mcLeave.Size = new System.Drawing.Size(200, 200);
            this.mcLeave.TabIndex = 46;
            this.mcLeave.Title = "請假";
            this.mcLeave.TitleColor = System.Drawing.Color.White;
            this.mcLeave.MouseEnter += new System.EventHandler(this.mcLeave_MouseEnter);
            this.mcLeave.MouseLeave += new System.EventHandler(this.mcLeave_MouseLeave);
            // 
            // mcReportTime
            // 
            this.mcReportTime.BackgroundColor = System.Drawing.Color.Empty;
            this.mcReportTime.ButtonColor = System.Drawing.Color.SlateGray;
            this.mcReportTime.image = global::BusinessSystem.Properties.Resources.briefcase_128;
            this.mcReportTime.ImageLocation = null;
            this.mcReportTime.Location = new System.Drawing.Point(645, 225);
            this.mcReportTime.Margin = new System.Windows.Forms.Padding(2);
            this.mcReportTime.Name = "mcReportTime";
            this.mcReportTime.Size = new System.Drawing.Size(200, 200);
            this.mcReportTime.TabIndex = 48;
            this.mcReportTime.Title = "工時回報";
            this.mcReportTime.TitleColor = System.Drawing.Color.White;
            this.mcReportTime.Click += new System.EventHandler(this.mcReportTime_Click);
            this.mcReportTime.MouseEnter += new System.EventHandler(this.mcReportTime_MouseEnter);
            this.mcReportTime.MouseLeave += new System.EventHandler(this.mcReportTime_MouseLeave);
            // 
            // mcDocument
            // 
            this.mcDocument.BackgroundColor = System.Drawing.Color.Empty;
            this.mcDocument.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.mcDocument.ForeColor = System.Drawing.Color.White;
            this.mcDocument.image = global::BusinessSystem.Properties.Resources.report_3_128;
            this.mcDocument.ImageLocation = null;
            this.mcDocument.Location = new System.Drawing.Point(16, 433);
            this.mcDocument.Margin = new System.Windows.Forms.Padding(2);
            this.mcDocument.Name = "mcDocument";
            this.mcDocument.Size = new System.Drawing.Size(200, 200);
            this.mcDocument.TabIndex = 41;
            this.mcDocument.Title = "文件上傳";
            this.mcDocument.TitleColor = System.Drawing.Color.Empty;
            this.mcDocument.Click += new System.EventHandler(this.mcDocument_Click);
            this.mcDocument.MouseEnter += new System.EventHandler(this.mcDocument_MouseEnter);
            this.mcDocument.MouseLeave += new System.EventHandler(this.mcDocument_MouseLeave);
            // 
            // mcCompanyCars
            // 
            this.mcCompanyCars.BackgroundColor = System.Drawing.Color.Empty;
            this.mcCompanyCars.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.mcCompanyCars.image = global::BusinessSystem.Properties.Resources.car_128;
            this.mcCompanyCars.ImageLocation = null;
            this.mcCompanyCars.Location = new System.Drawing.Point(227, 433);
            this.mcCompanyCars.Margin = new System.Windows.Forms.Padding(2);
            this.mcCompanyCars.Name = "mcCompanyCars";
            this.mcCompanyCars.Size = new System.Drawing.Size(200, 200);
            this.mcCompanyCars.TabIndex = 47;
            this.mcCompanyCars.Title = "公務車租借";
            this.mcCompanyCars.TitleColor = System.Drawing.Color.White;
            this.mcCompanyCars.Click += new System.EventHandler(this.mcCompanyCars_Click);
            this.mcCompanyCars.MouseEnter += new System.EventHandler(this.mcCompanyCars_MouseEnter);
            this.mcCompanyCars.MouseLeave += new System.EventHandler(this.mcCompanyCars_MouseLeave);
            // 
            // mcMeetingRoom
            // 
            this.mcMeetingRoom.BackgroundColor = System.Drawing.Color.Empty;
            this.mcMeetingRoom.ButtonColor = System.Drawing.Color.SlateGray;
            this.mcMeetingRoom.image = global::BusinessSystem.Properties.Resources.chair_2_128;
            this.mcMeetingRoom.ImageLocation = null;
            this.mcMeetingRoom.Location = new System.Drawing.Point(436, 433);
            this.mcMeetingRoom.Margin = new System.Windows.Forms.Padding(2);
            this.mcMeetingRoom.Name = "mcMeetingRoom";
            this.mcMeetingRoom.Size = new System.Drawing.Size(200, 200);
            this.mcMeetingRoom.TabIndex = 49;
            this.mcMeetingRoom.Title = "會議室租借";
            this.mcMeetingRoom.TitleColor = System.Drawing.Color.White;
            this.mcMeetingRoom.MouseEnter += new System.EventHandler(this.mcMeetingRoom_MouseEnter);
            this.mcMeetingRoom.MouseLeave += new System.EventHandler(this.mcMeetingRoom_MouseLeave);
            // 
            // mcRequisition
            // 
            this.mcRequisition.BackgroundColor = System.Drawing.Color.Empty;
            this.mcRequisition.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mcRequisition.image = global::BusinessSystem.Properties.Resources.cart_5_128;
            this.mcRequisition.ImageLocation = null;
            this.mcRequisition.Location = new System.Drawing.Point(645, 433);
            this.mcRequisition.Margin = new System.Windows.Forms.Padding(2);
            this.mcRequisition.Name = "mcRequisition";
            this.mcRequisition.Size = new System.Drawing.Size(200, 200);
            this.mcRequisition.TabIndex = 43;
            this.mcRequisition.Title = "請購系統";
            this.mcRequisition.TitleColor = System.Drawing.Color.White;
            this.mcRequisition.Click += new System.EventHandler(this.mcRequisition_Click);
            this.mcRequisition.MouseEnter += new System.EventHandler(this.mcRequisition_MouseEnter);
            this.mcRequisition.MouseLeave += new System.EventHandler(this.mcRequisition_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mcRequisition);
            this.panel1.Controls.Add(this.mcMeetingRoom);
            this.panel1.Controls.Add(this.mcCompanyCars);
            this.panel1.Controls.Add(this.mcDocument);
            this.panel1.Controls.Add(this.mcReportTime);
            this.panel1.Controls.Add(this.mcLeave);
            this.panel1.Controls.Add(this.mcBulletinBoard);
            this.panel1.Controls.Add(this.mcEmployee);
            this.panel1.Controls.Add(this.mcCalendar);
            this.panel1.Controls.Add(this.timeControl1);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 642);
            this.panel1.TabIndex = 53;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 666);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private MainControls.MainControls mcDocument;
        private MainControls.MainControls mcRequisition;
        private MainControls.MainControls mcCalendar;
        private MainControls.MainControls mcLeave;
        private MainControls.MainControls mcCompanyCars;
        private MainControls.MainControls mcReportTime;
        private MainControls.MainControls mcMeetingRoom;
        private MainControls.MainControls mcBulletinBoard;
        private MainControls.EmployeeControl mcEmployee;
        private MainControls.TimeControl timeControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
    }
}