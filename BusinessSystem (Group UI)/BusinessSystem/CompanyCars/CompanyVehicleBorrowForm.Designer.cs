namespace BusinessSystem.CompanyCars
{
    partial class CompanyVehicleBorrowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyVehicleBorrowForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dTPStartTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPEndTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.clsAltoButton2 = new BusinessSystem.ClsAltoButton();
            this.clsAltoButton1 = new BusinessSystem.ClsAltoButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clsAltoButton4 = new BusinessSystem.ClsAltoButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.richTextBox1.Location = new System.Drawing.Point(136, 438);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(468, 74);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // dTPStartTime
            // 
            this.dTPStartTime.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dTPStartTime.Location = new System.Drawing.Point(136, 346);
            this.dTPStartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dTPStartTime.Name = "dTPStartTime";
            this.dTPStartTime.Size = new System.Drawing.Size(187, 30);
            this.dTPStartTime.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(33, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "借出時間 : ";
            // 
            // dTPEndTime
            // 
            this.dTPEndTime.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dTPEndTime.Location = new System.Drawing.Point(136, 389);
            this.dTPEndTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dTPEndTime.Name = "dTPEndTime";
            this.dTPEndTime.Size = new System.Drawing.Size(187, 30);
            this.dTPEndTime.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(33, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 32;
            this.label5.Text = "歸還時間 : ";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "上午",
            "下午"});
            this.comboBox1.Location = new System.Drawing.Point(344, 346);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 30);
            this.comboBox1.TabIndex = 33;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "上午",
            "下午"});
            this.comboBox2.Location = new System.Drawing.Point(344, 389);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(69, 30);
            this.comboBox2.TabIndex = 34;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(431, 346);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(145, 30);
            this.comboBox3.TabIndex = 35;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            this.comboBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox3_MouseClick);
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(431, 389);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(145, 30);
            this.comboBox4.TabIndex = 36;
            this.comboBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox4_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(37, 79);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(29, 0, 20, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(796, 133);
            this.flowLayoutPanel1.TabIndex = 38;
            // 
            // clsAltoButton2
            // 
            this.clsAltoButton2.Active1 = System.Drawing.Color.CornflowerBlue;
            this.clsAltoButton2.Active2 = System.Drawing.Color.CornflowerBlue;
            this.clsAltoButton2.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clsAltoButton2.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton2.Inactive1 = System.Drawing.Color.MediumPurple;
            this.clsAltoButton2.Inactive2 = System.Drawing.Color.MediumSlateBlue;
            this.clsAltoButton2.Location = new System.Drawing.Point(629, 481);
            this.clsAltoButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clsAltoButton2.Name = "clsAltoButton2";
            this.clsAltoButton2.Radius = 10;
            this.clsAltoButton2.Size = new System.Drawing.Size(207, 34);
            this.clsAltoButton2.Stroke = false;
            this.clsAltoButton2.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton2.TabIndex = 37;
            this.clsAltoButton2.Text = "修改租借時間";
            this.clsAltoButton2.Transparency = false;
            this.clsAltoButton2.Click += new System.EventHandler(this.clsAltoButton2_Click);
            // 
            // clsAltoButton1
            // 
            this.clsAltoButton1.Active1 = System.Drawing.Color.CornflowerBlue;
            this.clsAltoButton1.Active2 = System.Drawing.Color.CornflowerBlue;
            this.clsAltoButton1.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clsAltoButton1.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton1.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Location = new System.Drawing.Point(685, 351);
            this.clsAltoButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clsAltoButton1.Name = "clsAltoButton1";
            this.clsAltoButton1.Radius = 10;
            this.clsAltoButton1.Size = new System.Drawing.Size(149, 65);
            this.clsAltoButton1.Stroke = false;
            this.clsAltoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton1.TabIndex = 27;
            this.clsAltoButton1.Text = "完成";
            this.clsAltoButton1.Transparency = false;
            this.clsAltoButton1.Click += new System.EventHandler(this.clsAltoButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 235);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(797, 100);
            this.dataGridView1.TabIndex = 0;
            // 
            // clsAltoButton4
            // 
            this.clsAltoButton4.Active1 = System.Drawing.Color.CornflowerBlue;
            this.clsAltoButton4.Active2 = System.Drawing.Color.CornflowerBlue;
            this.clsAltoButton4.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton4.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clsAltoButton4.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton4.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton4.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton4.Location = new System.Drawing.Point(629, 435);
            this.clsAltoButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clsAltoButton4.Name = "clsAltoButton4";
            this.clsAltoButton4.Radius = 10;
            this.clsAltoButton4.Size = new System.Drawing.Size(207, 34);
            this.clsAltoButton4.Stroke = false;
            this.clsAltoButton4.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton4.TabIndex = 40;
            this.clsAltoButton4.Text = "新增公務車";
            this.clsAltoButton4.Transparency = false;
            this.clsAltoButton4.Click += new System.EventHandler(this.clsAltoButton4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(33, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 41;
            this.label1.Text = "借用事由 : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(597, 352);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CompanyVehicleBorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 579);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clsAltoButton4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clsAltoButton2);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dTPEndTime);
            this.Controls.Add(this.clsAltoButton1);
            this.Controls.Add(this.dTPStartTime);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CompanyVehicleBorrowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公務車租借申請";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DateTimePicker dTPStartTime;
        private ClsAltoButton clsAltoButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dTPEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private ClsAltoButton clsAltoButton2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ClsAltoButton clsAltoButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}