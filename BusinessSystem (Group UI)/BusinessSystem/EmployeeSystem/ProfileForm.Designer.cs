namespace BusinessSystem.EmployeeSystem
{
    partial class ProfileForm
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
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.txtHireDate = new System.Windows.Forms.TextBox();
            this.txtPositionID = new System.Windows.Forms.TextBox();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.txtManagerID = new System.Windows.Forms.TextBox();
            this.txtOfficID = new System.Windows.Forms.TextBox();
            this.txtEmployed = new System.Windows.Forms.TextBox();
            this.picbEmpPhoto = new System.Windows.Forms.PictureBox();
            this.txtPhotoAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmPhoto = new BusinessSystem.ClsAltoButton();
            this.btnUpdatePhoto = new BusinessSystem.ClsAltoButton();
            this.btnChangePassword = new BusinessSystem.ClsAltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.picbEmpPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(32, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 19);
            this.label17.TabIndex = 70;
            this.label17.Text = "性別：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(32, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 19);
            this.label16.TabIndex = 69;
            this.label16.Text = "姓名：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(32, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 19);
            this.label13.TabIndex = 54;
            this.label13.Text = "組別ID：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(32, 302);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 19);
            this.label12.TabIndex = 53;
            this.label12.Text = "辦公室ID：";
            // 
            // txtAccount
            // 
            this.txtAccount.Enabled = false;
            this.txtAccount.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAccount.Location = new System.Drawing.Point(116, 255);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(156, 26);
            this.txtAccount.TabIndex = 52;
            this.txtAccount.Tag = "Account";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(32, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 19);
            this.label11.TabIndex = 51;
            this.label11.Text = "員工帳號：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(302, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 19);
            this.label10.TabIndex = 50;
            this.label10.Text = "在職中：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(303, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 19);
            this.label9.TabIndex = 49;
            this.label9.Text = "直屬主管ID：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(32, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 48;
            this.label8.Text = "部門ID：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(32, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 47;
            this.label7.Text = "職稱ID：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(32, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 46;
            this.label6.Text = "雇用日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(32, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 45;
            this.label5.Text = "生日：";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEmployeeName.Location = new System.Drawing.Point(116, 79);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(156, 26);
            this.txtEmployeeName.TabIndex = 44;
            // 
            // txtGender
            // 
            this.txtGender.Enabled = false;
            this.txtGender.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGender.Location = new System.Drawing.Point(116, 123);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(156, 26);
            this.txtGender.TabIndex = 74;
            // 
            // txtBirth
            // 
            this.txtBirth.Enabled = false;
            this.txtBirth.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBirth.Location = new System.Drawing.Point(116, 167);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(156, 26);
            this.txtBirth.TabIndex = 75;
            // 
            // txtHireDate
            // 
            this.txtHireDate.Enabled = false;
            this.txtHireDate.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtHireDate.Location = new System.Drawing.Point(116, 211);
            this.txtHireDate.Name = "txtHireDate";
            this.txtHireDate.Size = new System.Drawing.Size(156, 26);
            this.txtHireDate.TabIndex = 76;
            // 
            // txtPositionID
            // 
            this.txtPositionID.Enabled = false;
            this.txtPositionID.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPositionID.Location = new System.Drawing.Point(116, 431);
            this.txtPositionID.Name = "txtPositionID";
            this.txtPositionID.Size = new System.Drawing.Size(156, 26);
            this.txtPositionID.TabIndex = 81;
            // 
            // txtGroupID
            // 
            this.txtGroupID.Enabled = false;
            this.txtGroupID.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGroupID.Location = new System.Drawing.Point(116, 387);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(156, 26);
            this.txtGroupID.TabIndex = 80;
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Enabled = false;
            this.txtDepartmentID.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDepartmentID.Location = new System.Drawing.Point(116, 343);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(156, 26);
            this.txtDepartmentID.TabIndex = 79;
            // 
            // txtManagerID
            // 
            this.txtManagerID.Enabled = false;
            this.txtManagerID.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtManagerID.Location = new System.Drawing.Point(402, 403);
            this.txtManagerID.Name = "txtManagerID";
            this.txtManagerID.Size = new System.Drawing.Size(156, 26);
            this.txtManagerID.TabIndex = 78;
            this.txtManagerID.Tag = "Account";
            // 
            // txtOfficID
            // 
            this.txtOfficID.Enabled = false;
            this.txtOfficID.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOfficID.Location = new System.Drawing.Point(116, 299);
            this.txtOfficID.Name = "txtOfficID";
            this.txtOfficID.Size = new System.Drawing.Size(156, 26);
            this.txtOfficID.TabIndex = 77;
            // 
            // txtEmployed
            // 
            this.txtEmployed.Enabled = false;
            this.txtEmployed.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEmployed.Location = new System.Drawing.Point(402, 435);
            this.txtEmployed.Name = "txtEmployed";
            this.txtEmployed.Size = new System.Drawing.Size(156, 26);
            this.txtEmployed.TabIndex = 82;
            this.txtEmployed.Tag = "Account";
            // 
            // picbEmpPhoto
            // 
            this.picbEmpPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbEmpPhoto.Location = new System.Drawing.Point(305, 76);
            this.picbEmpPhoto.Name = "picbEmpPhoto";
            this.picbEmpPhoto.Padding = new System.Windows.Forms.Padding(3);
            this.picbEmpPhoto.Size = new System.Drawing.Size(253, 201);
            this.picbEmpPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbEmpPhoto.TabIndex = 83;
            this.picbEmpPhoto.TabStop = false;
            // 
            // txtPhotoAddress
            // 
            this.txtPhotoAddress.Enabled = false;
            this.txtPhotoAddress.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPhotoAddress.Location = new System.Drawing.Point(306, 351);
            this.txtPhotoAddress.Name = "txtPhotoAddress";
            this.txtPhotoAddress.Size = new System.Drawing.Size(252, 26);
            this.txtPhotoAddress.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(302, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 85;
            this.label1.Text = "圖片位址：";
            // 
            // btnConfirmPhoto
            // 
            this.btnConfirmPhoto.Active1 = System.Drawing.Color.CornflowerBlue;
            this.btnConfirmPhoto.Active2 = System.Drawing.Color.CornflowerBlue;
            this.btnConfirmPhoto.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmPhoto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmPhoto.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfirmPhoto.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPhoto.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnConfirmPhoto.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnConfirmPhoto.Location = new System.Drawing.Point(565, 349);
            this.btnConfirmPhoto.Name = "btnConfirmPhoto";
            this.btnConfirmPhoto.Radius = 10;
            this.btnConfirmPhoto.Size = new System.Drawing.Size(55, 29);
            this.btnConfirmPhoto.Stroke = false;
            this.btnConfirmPhoto.StrokeColor = System.Drawing.Color.Gray;
            this.btnConfirmPhoto.TabIndex = 87;
            this.btnConfirmPhoto.Text = "確認";
            this.btnConfirmPhoto.Transparency = false;
            this.btnConfirmPhoto.Visible = false;
            this.btnConfirmPhoto.Click += new System.EventHandler(this.btnConfirmPhoto_Click);
            // 
            // btnUpdatePhoto
            // 
            this.btnUpdatePhoto.Active1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdatePhoto.Active2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdatePhoto.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdatePhoto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdatePhoto.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePhoto.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePhoto.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnUpdatePhoto.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnUpdatePhoto.Location = new System.Drawing.Point(383, 283);
            this.btnUpdatePhoto.Name = "btnUpdatePhoto";
            this.btnUpdatePhoto.Radius = 10;
            this.btnUpdatePhoto.Size = new System.Drawing.Size(99, 26);
            this.btnUpdatePhoto.Stroke = false;
            this.btnUpdatePhoto.StrokeColor = System.Drawing.Color.Gray;
            this.btnUpdatePhoto.TabIndex = 86;
            this.btnUpdatePhoto.Text = "修改頭像";
            this.btnUpdatePhoto.Transparency = false;
            this.btnUpdatePhoto.Click += new System.EventHandler(this.clsAltoButton2_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Active1 = System.Drawing.Color.CornflowerBlue;
            this.btnChangePassword.Active2 = System.Drawing.Color.CornflowerBlue;
            this.btnChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChangePassword.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnChangePassword.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnChangePassword.Location = new System.Drawing.Point(457, 467);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Radius = 10;
            this.btnChangePassword.Size = new System.Drawing.Size(101, 31);
            this.btnChangePassword.Stroke = false;
            this.btnChangePassword.StrokeColor = System.Drawing.Color.Gray;
            this.btnChangePassword.TabIndex = 73;
            this.btnChangePassword.Text = "修改密碼";
            this.btnChangePassword.Transparency = false;
            this.btnChangePassword.Click += new System.EventHandler(this.clsAltoButton1_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 539);
            this.Controls.Add(this.btnConfirmPhoto);
            this.Controls.Add(this.btnUpdatePhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhotoAddress);
            this.Controls.Add(this.picbEmpPhoto);
            this.Controls.Add(this.txtEmployed);
            this.Controls.Add(this.txtPositionID);
            this.Controls.Add(this.txtGroupID);
            this.Controls.Add(this.txtDepartmentID);
            this.Controls.Add(this.txtManagerID);
            this.Controls.Add(this.txtOfficID);
            this.Controls.Add(this.txtHireDate);
            this.Controls.Add(this.txtBirth);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmployeeName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfileForm";
            this.Text = "個人檔案";
            ((System.ComponentModel.ISupportInitialize)(this.picbEmpPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private ClsAltoButton btnChangePassword;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.TextBox txtHireDate;
        private System.Windows.Forms.TextBox txtPositionID;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.TextBox txtManagerID;
        private System.Windows.Forms.TextBox txtOfficID;
        private System.Windows.Forms.TextBox txtEmployed;
        private System.Windows.Forms.PictureBox picbEmpPhoto;
        private System.Windows.Forms.TextBox txtPhotoAddress;
        private System.Windows.Forms.Label label1;
        private ClsAltoButton btnUpdatePhoto;
        private ClsAltoButton btnConfirmPhoto;
    }
}