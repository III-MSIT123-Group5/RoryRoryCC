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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dTPicBirth = new System.Windows.Forms.DateTimePicker();
            this.dTPicHireDate = new System.Windows.Forms.DateTimePicker();
            this.cmbOfficeID = new System.Windows.Forms.ComboBox();
            this.cmbDepartmentID = new System.Windows.Forms.ComboBox();
            this.cmbPositionID = new System.Windows.Forms.ComboBox();
            this.cmbEmployed = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbGroupID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbManagerID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCreatAccount = new BusinessSystem.ClsAltoButton();
            this.btnClearAll = new BusinessSystem.ClsAltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEmployeeName.Location = new System.Drawing.Point(123, 80);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(206, 26);
            this.txtEmployeeName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtEmployeeName, "employee_name");
            this.txtEmployeeName.Validated += new System.EventHandler(this.txtEmployeeName_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(27, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "生日：";
            this.toolTip1.SetToolTip(this.label5, "birth");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(27, 227);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "雇用日期：";
            this.toolTip1.SetToolTip(this.label6, "hire_date");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(390, 227);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "職稱ID：";
            this.toolTip1.SetToolTip(this.label7, "positionID");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(391, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "部門ID：";
            this.toolTip1.SetToolTip(this.label8, "departmentID");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(390, 318);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "在職中：";
            this.toolTip1.SetToolTip(this.label10, "employed");
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAccount.Location = new System.Drawing.Point(123, 272);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(206, 26);
            this.txtAccount.TabIndex = 5;
            this.txtAccount.Tag = "Account";
            this.toolTip1.SetToolTip(this.txtAccount, "account");
            this.txtAccount.Validated += new System.EventHandler(this.txtAccount_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(27, 275);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 19;
            this.label11.Text = "員工帳號：";
            this.toolTip1.SetToolTip(this.label11, "account");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(390, 83);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 18);
            this.label12.TabIndex = 21;
            this.label12.Text = "辦公室ID：";
            this.toolTip1.SetToolTip(this.label12, "officeID");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(391, 185);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 18);
            this.label13.TabIndex = 24;
            this.label13.Text = "組別ID：";
            this.toolTip1.SetToolTip(this.label13, "groupID");
            // 
            // dTPicBirth
            // 
            this.dTPicBirth.Location = new System.Drawing.Point(123, 179);
            this.dTPicBirth.Name = "dTPicBirth";
            this.dTPicBirth.Size = new System.Drawing.Size(206, 26);
            this.dTPicBirth.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dTPicBirth, "birth");
            // 
            // dTPicHireDate
            // 
            this.dTPicHireDate.Location = new System.Drawing.Point(123, 227);
            this.dTPicHireDate.Name = "dTPicHireDate";
            this.dTPicHireDate.Size = new System.Drawing.Size(206, 26);
            this.dTPicHireDate.TabIndex = 4;
            this.toolTip1.SetToolTip(this.dTPicHireDate, "hire_date");
            // 
            // cmbOfficeID
            // 
            this.cmbOfficeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfficeID.FormattingEnabled = true;
            this.cmbOfficeID.Location = new System.Drawing.Point(503, 80);
            this.cmbOfficeID.Name = "cmbOfficeID";
            this.cmbOfficeID.Size = new System.Drawing.Size(206, 26);
            this.cmbOfficeID.TabIndex = 8;
            this.toolTip1.SetToolTip(this.cmbOfficeID, "officeID");
            // 
            // cmbDepartmentID
            // 
            this.cmbDepartmentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartmentID.FormattingEnabled = true;
            this.cmbDepartmentID.Location = new System.Drawing.Point(503, 133);
            this.cmbDepartmentID.Name = "cmbDepartmentID";
            this.cmbDepartmentID.Size = new System.Drawing.Size(206, 26);
            this.cmbDepartmentID.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cmbDepartmentID, "departmentID");
            this.cmbDepartmentID.TextChanged += new System.EventHandler(this.cmbDepartmentID_TextChanged);
            this.cmbDepartmentID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbDepartmentID_MouseClick);
            // 
            // cmbPositionID
            // 
            this.cmbPositionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositionID.FormattingEnabled = true;
            this.cmbPositionID.Location = new System.Drawing.Point(503, 224);
            this.cmbPositionID.Name = "cmbPositionID";
            this.cmbPositionID.Size = new System.Drawing.Size(206, 26);
            this.cmbPositionID.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmbPositionID, "positionID");
            this.cmbPositionID.DataSourceChanged += new System.EventHandler(this.cmbPositionID_DataSourceChanged);
            this.cmbPositionID.TextChanged += new System.EventHandler(this.cmbPositionID_TextChanged);
            this.cmbPositionID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbPositionID_MouseClick);
            // 
            // cmbEmployed
            // 
            this.cmbEmployed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployed.Enabled = false;
            this.cmbEmployed.FormattingEnabled = true;
            this.cmbEmployed.Items.AddRange(new object[] {
            "離職",
            "在職"});
            this.cmbEmployed.Location = new System.Drawing.Point(503, 318);
            this.cmbEmployed.Name = "cmbEmployed";
            this.cmbEmployed.Size = new System.Drawing.Size(206, 26);
            this.cmbEmployed.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmbEmployed, "employed");
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(547, 407);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 39);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "重新輸入";
            this.toolTip1.SetToolTip(this.btnClear, "重新輸入表格");
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPassword.Location = new System.Drawing.Point(123, 310);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(206, 26);
            this.txtPassword.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtPassword, "password");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(27, 313);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 18);
            this.label14.TabIndex = 34;
            this.label14.Text = "員工密碼：";
            this.toolTip1.SetToolTip(this.label14, "password");
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(123, 348);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(206, 26);
            this.txtConfirmPassword.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtConfirmPassword, "請再輸入一次password");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(27, 351);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 18);
            this.label15.TabIndex = 36;
            this.label15.Text = "確認密碼：";
            this.toolTip1.SetToolTip(this.label15, "confirm password");
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cmbGender.Location = new System.Drawing.Point(123, 128);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(206, 26);
            this.cmbGender.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmbGender, "F:女性 M:男性");
            // 
            // cmbGroupID
            // 
            this.cmbGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupID.FormattingEnabled = true;
            this.cmbGroupID.Items.AddRange(new object[] {
            "離職",
            "在職"});
            this.cmbGroupID.Location = new System.Drawing.Point(503, 179);
            this.cmbGroupID.Name = "cmbGroupID";
            this.cmbGroupID.Size = new System.Drawing.Size(206, 26);
            this.cmbGroupID.TabIndex = 10;
            this.toolTip1.SetToolTip(this.cmbGroupID, "GroupID");
            this.cmbGroupID.DataSourceChanged += new System.EventHandler(this.cmbGroupID_DataSourceChanged);
            this.cmbGroupID.TextChanged += new System.EventHandler(this.cmbGroupID_TextChanged);
            this.cmbGroupID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbGroupID_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(391, 275);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "直屬主管ID：";
            this.toolTip1.SetToolTip(this.label9, "managerID");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(27, 88);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 18);
            this.label16.TabIndex = 41;
            this.label16.Text = "姓名：";
            this.toolTip1.SetToolTip(this.label16, "EmployeeName");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(27, 133);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 18);
            this.label17.TabIndex = 42;
            this.label17.Text = "性別：";
            this.toolTip1.SetToolTip(this.label17, "Gender");
            // 
            // cmbManagerID
            // 
            this.cmbManagerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManagerID.FormattingEnabled = true;
            this.cmbManagerID.Location = new System.Drawing.Point(503, 272);
            this.cmbManagerID.Name = "cmbManagerID";
            this.cmbManagerID.Size = new System.Drawing.Size(206, 26);
            this.cmbManagerID.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmbManagerID, "managerID");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(27, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "員工姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(27, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "性別：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCreatAccount
            // 
            this.btnCreatAccount.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnCreatAccount.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnCreatAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnCreatAccount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreatAccount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreatAccount.ForeColor = System.Drawing.Color.Black;
            this.btnCreatAccount.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnCreatAccount.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnCreatAccount.Location = new System.Drawing.Point(393, 365);
            this.btnCreatAccount.Name = "btnCreatAccount";
            this.btnCreatAccount.Radius = 10;
            this.btnCreatAccount.Size = new System.Drawing.Size(137, 39);
            this.btnCreatAccount.Stroke = false;
            this.btnCreatAccount.StrokeColor = System.Drawing.Color.Gray;
            this.btnCreatAccount.TabIndex = 43;
            this.btnCreatAccount.Text = "新增";
            this.toolTip1.SetToolTip(this.btnCreatAccount, "新增員工資料");
            this.btnCreatAccount.Transparency = false;
            this.btnCreatAccount.Click += new System.EventHandler(this.btnCreatAccount_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnClearAll.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnClearAll.BackColor = System.Drawing.Color.Transparent;
            this.btnClearAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClearAll.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClearAll.ForeColor = System.Drawing.Color.Black;
            this.btnClearAll.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btnClearAll.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btnClearAll.Location = new System.Drawing.Point(547, 365);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Radius = 10;
            this.btnClearAll.Size = new System.Drawing.Size(137, 39);
            this.btnClearAll.Stroke = false;
            this.btnClearAll.StrokeColor = System.Drawing.Color.Gray;
            this.btnClearAll.TabIndex = 44;
            this.btnClearAll.Text = "重新輸入";
            this.toolTip1.SetToolTip(this.btnClearAll, "重新輸入表格");
            this.btnClearAll.Transparency = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // CreateEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 449);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnCreatAccount);
            this.Controls.Add(this.cmbManagerID);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbGroupID);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbEmployed);
            this.Controls.Add(this.cmbPositionID);
            this.Controls.Add(this.cmbDepartmentID);
            this.Controls.Add(this.cmbOfficeID);
            this.Controls.Add(this.dTPicHireDate);
            this.Controls.Add(this.dTPicBirth);
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
            this.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CreateEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增員工資料";
            this.Load += new System.EventHandler(this.CreateEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dTPicBirth;
        private System.Windows.Forms.DateTimePicker dTPicHireDate;
        private System.Windows.Forms.ComboBox cmbOfficeID;
        private System.Windows.Forms.ComboBox cmbDepartmentID;
        private System.Windows.Forms.ComboBox cmbPositionID;
        private System.Windows.Forms.ComboBox cmbEmployed;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbGroupID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbManagerID;
        private ClsAltoButton btnCreatAccount;
        private ClsAltoButton btnClearAll;
    }
}