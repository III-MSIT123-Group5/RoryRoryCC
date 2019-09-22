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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timeControl1 = new MainControls.TimeControl();
            this.btnCalendar = new MainControls.MainControls();
            this.btnEmployee = new MainControls.EmployeeControl();
            this.btnBulletinBoard = new MainControls.MainControls();
            this.btnLeave = new MainControls.MainControls();
            this.btnReportTime = new MainControls.MainControls();
            this.btnDocument = new MainControls.MainControls();
            this.btnCompanyCars = new MainControls.MainControls();
            this.btnMeetingRoom = new MainControls.MainControls();
            this.btnRequisition = new MainControls.MainControls();
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
            this.flowLayoutPanel1.Controls.Add(this.btnCalendar);
            this.flowLayoutPanel1.Controls.Add(this.btnEmployee);
            this.flowLayoutPanel1.Controls.Add(this.btnBulletinBoard);
            this.flowLayoutPanel1.Controls.Add(this.btnLeave);
            this.flowLayoutPanel1.Controls.Add(this.btnReportTime);
            this.flowLayoutPanel1.Controls.Add(this.btnDocument);
            this.flowLayoutPanel1.Controls.Add(this.btnCompanyCars);
            this.flowLayoutPanel1.Controls.Add(this.btnMeetingRoom);
            this.flowLayoutPanel1.Controls.Add(this.btnRequisition);
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
            // btnCalendar
            // 
            this.btnCalendar.BackgroundColor = System.Drawing.Color.Empty;
            this.btnCalendar.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnCalendar.image = global::BusinessSystem.Properties.Resources.calendar_3_128;
            this.btnCalendar.ImageLocation = null;
            this.btnCalendar.Location = new System.Drawing.Point(411, 2);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(199, 200);
            this.btnCalendar.TabIndex = 44;
            this.btnCalendar.Title = "行事曆";
            this.btnCalendar.TitleColor = System.Drawing.Color.White;
            this.btnCalendar.MouseEnter += new System.EventHandler(this.btnCalendar_MouseEnter);
            this.btnCalendar.MouseLeave += new System.EventHandler(this.btnCalendar_MouseLeave);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackgroundColor = System.Drawing.Color.Empty;
            this.btnEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmployee.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnEmployee.image = null;
            this.btnEmployee.ImageLocation = null;
            this.btnEmployee.Location = new System.Drawing.Point(615, 3);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(199, 200);
            this.btnEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEmployee.TabIndex = 53;
            this.btnEmployee.Title = "label";
            this.btnEmployee.TitleColor = System.Drawing.Color.White;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            this.btnEmployee.MouseEnter += new System.EventHandler(this.btnEmployee_MouseEnter);
            this.btnEmployee.MouseLeave += new System.EventHandler(this.btnEmployee_MouseLeave);
            // 
            // btnBulletinBoard
            // 
            this.btnBulletinBoard.BackgroundColor = System.Drawing.Color.Empty;
            this.btnBulletinBoard.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnBulletinBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBulletinBoard.image = global::BusinessSystem.Properties.Resources.edit_property_128;
            this.btnBulletinBoard.ImageLocation = null;
            this.btnBulletinBoard.Location = new System.Drawing.Point(2, 208);
            this.btnBulletinBoard.Margin = new System.Windows.Forms.Padding(2);
            this.btnBulletinBoard.Name = "btnBulletinBoard";
            this.btnBulletinBoard.Size = new System.Drawing.Size(404, 200);
            this.btnBulletinBoard.TabIndex = 50;
            this.btnBulletinBoard.Title = "佈告欄";
            this.btnBulletinBoard.TitleColor = System.Drawing.Color.White;
            this.btnBulletinBoard.Click += new System.EventHandler(this.btnBulletinBoard_Click);
            this.btnBulletinBoard.MouseEnter += new System.EventHandler(this.btnBulletinBoard_MouseEnter);
            this.btnBulletinBoard.MouseLeave += new System.EventHandler(this.btnBulletinBoard_MouseLeave);
            // 
            // btnLeave
            // 
            this.btnLeave.BackgroundColor = System.Drawing.Color.Empty;
            this.btnLeave.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeave.image = global::BusinessSystem.Properties.Resources.time_8_128;
            this.btnLeave.ImageLocation = null;
            this.btnLeave.Location = new System.Drawing.Point(410, 208);
            this.btnLeave.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(200, 200);
            this.btnLeave.TabIndex = 46;
            this.btnLeave.Title = "請假";
            this.btnLeave.TitleColor = System.Drawing.Color.White;
            this.btnLeave.MouseEnter += new System.EventHandler(this.btnLeave_MouseEnter);
            this.btnLeave.MouseLeave += new System.EventHandler(this.btnLeave_MouseLeave);
            // 
            // btnReportTime
            // 
            this.btnReportTime.BackgroundColor = System.Drawing.Color.Empty;
            this.btnReportTime.ButtonColor = System.Drawing.Color.SlateGray;
            this.btnReportTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportTime.image = global::BusinessSystem.Properties.Resources.briefcase_128;
            this.btnReportTime.ImageLocation = null;
            this.btnReportTime.Location = new System.Drawing.Point(614, 208);
            this.btnReportTime.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportTime.Name = "btnReportTime";
            this.btnReportTime.Size = new System.Drawing.Size(200, 200);
            this.btnReportTime.TabIndex = 48;
            this.btnReportTime.Title = "工時回報";
            this.btnReportTime.TitleColor = System.Drawing.Color.White;
            this.btnReportTime.Click += new System.EventHandler(this.btnReportTime_Click);
            this.btnReportTime.MouseEnter += new System.EventHandler(this.btnReportTime_MouseEnter);
            this.btnReportTime.MouseLeave += new System.EventHandler(this.btnReportTime_MouseLeave);
            // 
            // btnDocument
            // 
            this.btnDocument.BackgroundColor = System.Drawing.Color.Empty;
            this.btnDocument.ButtonColor = System.Drawing.Color.SlateGray;
            this.btnDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocument.ForeColor = System.Drawing.Color.White;
            this.btnDocument.image = global::BusinessSystem.Properties.Resources.report_3_128;
            this.btnDocument.ImageLocation = null;
            this.btnDocument.Location = new System.Drawing.Point(2, 412);
            this.btnDocument.Margin = new System.Windows.Forms.Padding(2);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(200, 200);
            this.btnDocument.TabIndex = 41;
            this.btnDocument.Title = "文件上傳";
            this.btnDocument.TitleColor = System.Drawing.Color.Empty;
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
            this.btnDocument.MouseEnter += new System.EventHandler(this.btnDocument_MouseEnter);
            this.btnDocument.MouseLeave += new System.EventHandler(this.btnDocument_MouseLeave);
            // 
            // btnCompanyCars
            // 
            this.btnCompanyCars.BackgroundColor = System.Drawing.Color.Empty;
            this.btnCompanyCars.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.btnCompanyCars.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompanyCars.image = global::BusinessSystem.Properties.Resources.car_128;
            this.btnCompanyCars.ImageLocation = null;
            this.btnCompanyCars.Location = new System.Drawing.Point(206, 412);
            this.btnCompanyCars.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompanyCars.Name = "btnCompanyCars";
            this.btnCompanyCars.Size = new System.Drawing.Size(200, 200);
            this.btnCompanyCars.TabIndex = 47;
            this.btnCompanyCars.Title = "公務車租借";
            this.btnCompanyCars.TitleColor = System.Drawing.Color.White;
            this.btnCompanyCars.Click += new System.EventHandler(this.btnCompanyCars_Click);
            this.btnCompanyCars.MouseEnter += new System.EventHandler(this.btnCompanyCars_MouseEnter);
            this.btnCompanyCars.MouseLeave += new System.EventHandler(this.btnCompanyCars_MouseLeave);
            // 
            // btnMeetingRoom
            // 
            this.btnMeetingRoom.BackgroundColor = System.Drawing.Color.Empty;
            this.btnMeetingRoom.ButtonColor = System.Drawing.Color.SlateGray;
            this.btnMeetingRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMeetingRoom.image = global::BusinessSystem.Properties.Resources.chair_2_128;
            this.btnMeetingRoom.ImageLocation = null;
            this.btnMeetingRoom.Location = new System.Drawing.Point(410, 412);
            this.btnMeetingRoom.Margin = new System.Windows.Forms.Padding(2);
            this.btnMeetingRoom.Name = "btnMeetingRoom";
            this.btnMeetingRoom.Size = new System.Drawing.Size(200, 200);
            this.btnMeetingRoom.TabIndex = 49;
            this.btnMeetingRoom.Title = "會議室租借";
            this.btnMeetingRoom.TitleColor = System.Drawing.Color.White;
            this.btnMeetingRoom.MouseEnter += new System.EventHandler(this.btnMeetingRoom_MouseEnter);
            this.btnMeetingRoom.MouseLeave += new System.EventHandler(this.btnMeetingRoom_MouseLeave);
            // 
            // btnRequisition
            // 
            this.btnRequisition.BackgroundColor = System.Drawing.Color.Empty;
            this.btnRequisition.ButtonColor = System.Drawing.Color.SteelBlue;
            this.btnRequisition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequisition.image = global::BusinessSystem.Properties.Resources.cart_5_128;
            this.btnRequisition.ImageLocation = null;
            this.btnRequisition.Location = new System.Drawing.Point(614, 412);
            this.btnRequisition.Margin = new System.Windows.Forms.Padding(2);
            this.btnRequisition.Name = "btnRequisition";
            this.btnRequisition.Size = new System.Drawing.Size(200, 200);
            this.btnRequisition.TabIndex = 43;
            this.btnRequisition.Title = "請購系統";
            this.btnRequisition.TitleColor = System.Drawing.Color.White;
            this.btnRequisition.Click += new System.EventHandler(this.btnRequisition_Click);
            this.btnRequisition.MouseEnter += new System.EventHandler(this.btnRequisition_MouseEnter);
            this.btnRequisition.MouseLeave += new System.EventHandler(this.btnRequisition_MouseLeave);
            // 
            // btnHRSystem
            // 
            this.btnHRSystem.BackgroundColor = System.Drawing.Color.Empty;
            this.btnHRSystem.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.btnHRSystem.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnHRSystem.MouseEnter += new System.EventHandler(this.btnHRSystem_MouseEnter);
            this.btnHRSystem.MouseLeave += new System.EventHandler(this.btnHRSystem_MouseLeave);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackgroundColor = System.Drawing.Color.Empty;
            this.btnLogOut.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnLogOut.MouseEnter += new System.EventHandler(this.btnLogOut_MouseEnter);
            this.btnLogOut.MouseLeave += new System.EventHandler(this.btnLogOut_MouseLeave);
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
        private MainControls.MainControls btnDocument;
        private MainControls.MainControls btnRequisition;
        private MainControls.MainControls btnCalendar;
        private MainControls.MainControls btnLeave;
        private MainControls.MainControls btnCompanyCars;
        private MainControls.MainControls btnReportTime;
        private MainControls.MainControls btnMeetingRoom;
        private MainControls.MainControls btnBulletinBoard;
        private MainControls.EmployeeControl btnEmployee;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MainControls.TimeControl timeControl1;
        private MainControls.MainControls btnHRSystem;
        private MainControls.MainControls btnLogOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}