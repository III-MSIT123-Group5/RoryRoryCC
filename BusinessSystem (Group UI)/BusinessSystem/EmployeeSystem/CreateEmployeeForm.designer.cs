namespace BusinessSystem
{
    partial class CreateEmployeeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dTPicBirth = new System.Windows.Forms.DateTimePicker();
            this.dTPicHireDate = new System.Windows.Forms.DateTimePicker();
            this.cmbOfficeID = new System.Windows.Forms.ComboBox();
            this.cmbDepartmentID = new System.Windows.Forms.ComboBox();
            this.cmbPositionID = new System.Windows.Forms.ComboBox();
            this.cmbEmployed = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(25, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工ID：";
            this.toolTip1.SetToolTip(this.label2, "employeeID");
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEmployeeID.Location = new System.Drawing.Point(121, 120);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(206, 30);
            this.txtEmployeeID.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtEmployeeID, "employeeID");
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEmployeeName.Location = new System.Drawing.Point(121, 168);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(206, 30);
            this.txtEmployeeName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtEmployeeName, "employee_name");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(25, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "員工姓名：";
            this.toolTip1.SetToolTip(this.label3, "employee_name");
            // 
            // txtGender
            // 
            this.txtGender.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGender.Location = new System.Drawing.Point(121, 216);
            this.txtGender.Margin = new System.Windows.Forms.Padding(4);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(206, 30);
            this.txtGender.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtGender, "gender");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(25, 219);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "性別：";
            this.toolTip1.SetToolTip(this.label4, "gender");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(25, 267);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "生日：";
            this.toolTip1.SetToolTip(this.label5, "birth");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(25, 315);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "雇用日期：";
            this.toolTip1.SetToolTip(this.label6, "hire_date");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(356, 219);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "職稱ID：";
            this.toolTip1.SetToolTip(this.label7, "positionID");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(357, 171);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "部門ID：";
            this.toolTip1.SetToolTip(this.label8, "departmentID");
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox7.Location = new System.Drawing.Point(469, 264);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(206, 30);
            this.textBox7.TabIndex = 16;
            this.toolTip1.SetToolTip(this.textBox7, "managerID");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(357, 267);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "直屬經理ID：";
            this.toolTip1.SetToolTip(this.label9, "managerID");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(357, 315);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 22);
            this.label10.TabIndex = 17;
            this.label10.Text = "在職中：";
            this.toolTip1.SetToolTip(this.label10, "employed");
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAccount.Location = new System.Drawing.Point(121, 360);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(206, 30);
            this.txtAccount.TabIndex = 20;
            this.toolTip1.SetToolTip(this.txtAccount, "account");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(25, 363);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 22);
            this.label11.TabIndex = 19;
            this.label11.Text = "員工帳號：";
            this.toolTip1.SetToolTip(this.label11, "account");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(357, 123);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 22);
            this.label12.TabIndex = 21;
            this.label12.Text = "OfficeID：";
            this.toolTip1.SetToolTip(this.label12, "officeID");
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(469, 363);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 30);
            this.textBox2.TabIndex = 25;
            this.toolTip1.SetToolTip(this.textBox2, "groupID");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(356, 363);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 22);
            this.label13.TabIndex = 24;
            this.label13.Text = "組別ID：";
            this.toolTip1.SetToolTip(this.label13, "groupID");
            // 
            // dTPicBirth
            // 
            this.dTPicBirth.Location = new System.Drawing.Point(121, 267);
            this.dTPicBirth.Name = "dTPicBirth";
            this.dTPicBirth.Size = new System.Drawing.Size(206, 30);
            this.dTPicBirth.TabIndex = 26;
            this.toolTip1.SetToolTip(this.dTPicBirth, "birth");
            // 
            // dTPicHireDate
            // 
            this.dTPicHireDate.Location = new System.Drawing.Point(121, 315);
            this.dTPicHireDate.Name = "dTPicHireDate";
            this.dTPicHireDate.Size = new System.Drawing.Size(206, 30);
            this.dTPicHireDate.TabIndex = 27;
            this.toolTip1.SetToolTip(this.dTPicHireDate, "hire_date");
            // 
            // cmbOfficeID
            // 
            this.cmbOfficeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfficeID.FormattingEnabled = true;
            this.cmbOfficeID.Location = new System.Drawing.Point(469, 120);
            this.cmbOfficeID.Name = "cmbOfficeID";
            this.cmbOfficeID.Size = new System.Drawing.Size(206, 30);
            this.cmbOfficeID.TabIndex = 28;
            this.toolTip1.SetToolTip(this.cmbOfficeID, "officeID");
            // 
            // cmbDepartmentID
            // 
            this.cmbDepartmentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartmentID.FormattingEnabled = true;
            this.cmbDepartmentID.Location = new System.Drawing.Point(469, 163);
            this.cmbDepartmentID.Name = "cmbDepartmentID";
            this.cmbDepartmentID.Size = new System.Drawing.Size(206, 30);
            this.cmbDepartmentID.TabIndex = 29;
            this.toolTip1.SetToolTip(this.cmbDepartmentID, "departmentID");
            // 
            // cmbPositionID
            // 
            this.cmbPositionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositionID.FormattingEnabled = true;
            this.cmbPositionID.Location = new System.Drawing.Point(469, 216);
            this.cmbPositionID.Name = "cmbPositionID";
            this.cmbPositionID.Size = new System.Drawing.Size(206, 30);
            this.cmbPositionID.TabIndex = 30;
            this.toolTip1.SetToolTip(this.cmbPositionID, "positionID");
            // 
            // cmbEmployed
            // 
            this.cmbEmployed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployed.Enabled = false;
            this.cmbEmployed.FormattingEnabled = true;
            this.cmbEmployed.Items.AddRange(new object[] {
            "離職",
            "在職"});
            this.cmbEmployed.Location = new System.Drawing.Point(469, 315);
            this.cmbEmployed.Name = "cmbEmployed";
            this.cmbEmployed.Size = new System.Drawing.Size(206, 30);
            this.cmbEmployed.TabIndex = 31;
            this.toolTip1.SetToolTip(this.cmbEmployed, "employed");
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(375, 431);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(137, 39);
            this.btnCreate.TabIndex = 32;
            this.btnCreate.Text = "新增";
            this.toolTip1.SetToolTip(this.btnCreate, "新增員工資料至資料庫");
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(538, 431);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 39);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "重新輸入";
            this.toolTip1.SetToolTip(this.btnClear, "重新輸入表格");
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPassword.Location = new System.Drawing.Point(121, 398);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(206, 30);
            this.txtPassword.TabIndex = 35;
            this.toolTip1.SetToolTip(this.txtPassword, "password");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(25, 401);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 22);
            this.label14.TabIndex = 34;
            this.label14.Text = "員工密碼：";
            this.toolTip1.SetToolTip(this.label14, "password");
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(121, 436);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(206, 30);
            this.txtConfirmPassword.TabIndex = 37;
            this.toolTip1.SetToolTip(this.txtConfirmPassword, "請再輸入一次password");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(25, 439);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 22);
            this.label15.TabIndex = 36;
            this.label15.Text = "確認密碼：";
            this.toolTip1.SetToolTip(this.label15, "confirm password");
            // 
            // CreateEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 487);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbEmployed);
            this.Controls.Add(this.cmbPositionID);
            this.Controls.Add(this.cmbDepartmentID);
            this.Controls.Add(this.cmbOfficeID);
            this.Controls.Add(this.dTPicHireDate);
            this.Controls.Add(this.dTPicBirth);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateEmployeeForm";
            this.Text = "新增員工資料";
            this.Load += new System.EventHandler(this.CreateEmployeeForm_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtEmployeeID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtEmployeeName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtGender, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.textBox7, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtAccount, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.dTPicBirth, 0);
            this.Controls.SetChildIndex(this.dTPicHireDate, 0);
            this.Controls.SetChildIndex(this.cmbOfficeID, 0);
            this.Controls.SetChildIndex(this.cmbDepartmentID, 0);
            this.Controls.SetChildIndex(this.cmbPositionID, 0);
            this.Controls.SetChildIndex(this.cmbEmployed, 0);
            this.Controls.SetChildIndex(this.btnCreate, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtConfirmPassword, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dTPicBirth;
        private System.Windows.Forms.DateTimePicker dTPicHireDate;
        private System.Windows.Forms.ComboBox cmbOfficeID;
        private System.Windows.Forms.ComboBox cmbDepartmentID;
        private System.Windows.Forms.ComboBox cmbPositionID;
        private System.Windows.Forms.ComboBox cmbEmployed;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label15;
    }
}