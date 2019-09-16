namespace BusinessSystem.ReportTimeSystem
{
    partial class FormUpdate
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
            this.clsAltoButton1 = new BusinessSystem.ClsAltoButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clsAltoButton1
            // 
            this.clsAltoButton1.Active1 = System.Drawing.Color.Blue;
            this.clsAltoButton1.Active2 = System.Drawing.Color.Blue;
            this.clsAltoButton1.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.clsAltoButton1.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton1.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Location = new System.Drawing.Point(558, 156);
            this.clsAltoButton1.Name = "clsAltoButton1";
            this.clsAltoButton1.Radius = 10;
            this.clsAltoButton1.Size = new System.Drawing.Size(145, 66);
            this.clsAltoButton1.Stroke = false;
            this.clsAltoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton1.TabIndex = 31;
            this.clsAltoButton1.Text = "送出";
            this.clsAltoButton1.Transparency = false;
            this.clsAltoButton1.Click += new System.EventHandler(this.clsAltoButton1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox2.Location = new System.Drawing.Point(216, 169);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(126, 23);
            this.comboBox2.TabIndex = 30;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(66, 242);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(637, 185);
            this.richTextBox1.TabIndex = 29;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "更改按鈕",
            "開會",
            "出差"});
            this.comboBox1.Location = new System.Drawing.Point(216, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 23);
            this.comboBox1.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "申請人";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "備註";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "所需時間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "申請專案";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "申請人";
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clsAltoButton1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUpdate";
            this.Text = "FormUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClsAltoButton clsAltoButton1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}