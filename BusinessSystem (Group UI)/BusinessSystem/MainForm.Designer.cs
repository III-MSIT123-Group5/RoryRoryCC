﻿namespace BusinessSystem
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timeControl1 = new MainControls.TimeControl();
            this.mcCalendar = new MainControls.MainControls();
            this.mcEmployee = new MainControls.EmployeeControl();
            this.mcBulletinBoard = new MainControls.MainControls();
            this.mcLeave = new MainControls.MainControls();
            this.mcReportTime = new MainControls.MainControls();
            this.mcDocument = new MainControls.MainControls();
            this.mcCompanyCars = new MainControls.MainControls();
            this.mcMeetingRoom = new MainControls.MainControls();
            this.mcRequisition = new MainControls.MainControls();
            this.btnHRSystem = new MainControls.MainControls();
            this.btnLogOut = new MainControls.MainControls();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.timeControl1);
            this.flowLayoutPanel1.Controls.Add(this.mcCalendar);
            this.flowLayoutPanel1.Controls.Add(this.mcEmployee);
            this.flowLayoutPanel1.Controls.Add(this.mcBulletinBoard);
            this.flowLayoutPanel1.Controls.Add(this.mcLeave);
            this.flowLayoutPanel1.Controls.Add(this.mcReportTime);
            this.flowLayoutPanel1.Controls.Add(this.mcDocument);
            this.flowLayoutPanel1.Controls.Add(this.mcCompanyCars);
            this.flowLayoutPanel1.Controls.Add(this.mcMeetingRoom);
            this.flowLayoutPanel1.Controls.Add(this.mcRequisition);
            this.flowLayoutPanel1.Controls.Add(this.btnHRSystem);
            this.flowLayoutPanel1.Controls.Add(this.btnLogOut);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(835, 615);
            this.flowLayoutPanel1.TabIndex = 52;
            // 
            // timeControl1
            // 
            this.timeControl1.AMText = "PM";
            this.timeControl1.BackgroundColor = System.Drawing.Color.Empty;
            this.timeControl1.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.timeControl1.DateText = "2019-09-20";
            this.timeControl1.Location = new System.Drawing.Point(3, 3);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.SecondText = "59";
            this.timeControl1.Size = new System.Drawing.Size(403, 200);
            this.timeControl1.TabIndex = 54;
            this.timeControl1.TimeText = "10:00";
            this.timeControl1.TitleColor = System.Drawing.Color.White;
            // 
            // mcCalendar
            // 
            this.mcCalendar.BackgroundColor = System.Drawing.Color.Empty;
            this.mcCalendar.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mcCalendar.image = global::BusinessSystem.Properties.Resources.calendar_3_128;
            this.mcCalendar.ImageLocation = null;
            this.mcCalendar.Location = new System.Drawing.Point(411, 2);
            this.mcCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.mcCalendar.Name = "mcCalendar";
            this.mcCalendar.Size = new System.Drawing.Size(199, 200);
            this.mcCalendar.TabIndex = 44;
            this.mcCalendar.Title = "行事曆";
            this.mcCalendar.TitleColor = System.Drawing.Color.White;
            this.mcCalendar.MouseEnter += new System.EventHandler(this.mcCalendar_MouseEnter);
            this.mcCalendar.MouseLeave += new System.EventHandler(this.mcCalendar_MouseLeave);
            // 
            // mcEmployee
            // 
            this.mcEmployee.BackgroundColor = System.Drawing.Color.Empty;
            this.mcEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mcEmployee.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.mcEmployee.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.mcEmployee.image = null;
            this.mcEmployee.ImageLocation = null;
            this.mcEmployee.Location = new System.Drawing.Point(615, 3);
            this.mcEmployee.Name = "mcEmployee";
            this.mcEmployee.Size = new System.Drawing.Size(199, 200);
            this.mcEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mcEmployee.TabIndex = 53;
            this.mcEmployee.Title = "label";
            this.mcEmployee.TitleColor = System.Drawing.Color.White;
            this.mcEmployee.Click += new System.EventHandler(this.mcEmployee_Click);
            this.mcEmployee.MouseEnter += new System.EventHandler(this.mcEmployee_MouseEnter);
            this.mcEmployee.MouseLeave += new System.EventHandler(this.mcEmployee_MouseLeave);
            // 
            // mcBulletinBoard
            // 
            this.mcBulletinBoard.BackgroundColor = System.Drawing.Color.Empty;
            this.mcBulletinBoard.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mcBulletinBoard.image = global::BusinessSystem.Properties.Resources.edit_property_128;
            this.mcBulletinBoard.ImageLocation = null;
            this.mcBulletinBoard.Location = new System.Drawing.Point(2, 208);
            this.mcBulletinBoard.Margin = new System.Windows.Forms.Padding(2);
            this.mcBulletinBoard.Name = "mcBulletinBoard";
            this.mcBulletinBoard.Size = new System.Drawing.Size(404, 200);
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
            this.mcLeave.Location = new System.Drawing.Point(410, 208);
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
            this.mcReportTime.Location = new System.Drawing.Point(614, 208);
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
            this.mcDocument.Location = new System.Drawing.Point(2, 412);
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
            this.mcCompanyCars.Location = new System.Drawing.Point(206, 412);
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
            this.mcMeetingRoom.Location = new System.Drawing.Point(410, 412);
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
            this.mcRequisition.Location = new System.Drawing.Point(614, 412);
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
            // btnHRSystem
            // 
            this.btnHRSystem.BackgroundColor = System.Drawing.Color.Empty;
            this.btnHRSystem.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.btnHRSystem.image = global::BusinessSystem.Properties.Resources.edit_user_128;
            this.btnHRSystem.ImageLocation = null;
            this.btnHRSystem.Location = new System.Drawing.Point(2, 616);
            this.btnHRSystem.Margin = new System.Windows.Forms.Padding(2);
            this.btnHRSystem.Name = "btnHRSystem";
            this.btnHRSystem.Size = new System.Drawing.Size(200, 200);
            this.btnHRSystem.TabIndex = 55;
            this.btnHRSystem.Title = "人資管理";
            this.btnHRSystem.TitleColor = System.Drawing.Color.White;
            this.btnHRSystem.Visible = false;
            this.btnHRSystem.Click += new System.EventHandler(this.btnHRSystem_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackgroundColor = System.Drawing.Color.Empty;
            this.btnLogOut.ButtonColor = System.Drawing.Color.SlateGray;
            this.btnLogOut.image = global::BusinessSystem.Properties.Resources.logout_128;
            this.btnLogOut.ImageLocation = null;
            this.btnLogOut.Location = new System.Drawing.Point(206, 616);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(200, 200);
            this.btnLogOut.TabIndex = 56;
            this.btnLogOut.Title = "登出";
            this.btnLogOut.TitleColor = System.Drawing.Color.White;
            this.btnLogOut.Click += new System.EventHandler(this.mainControls2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 31);
            this.panel1.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(675, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "© Business System Corp. Since 2019";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MainControls.TimeControl timeControl1;
        private MainControls.MainControls btnHRSystem;
        private MainControls.MainControls btnLogOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}