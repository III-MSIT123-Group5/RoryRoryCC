namespace BusinessSystem.DocumentManagement
{
    partial class FrmFileBrowsing
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clsAltoButton2 = new BusinessSystem.ClsAltoButton();
            this.clsAltoButton3 = new BusinessSystem.ClsAltoButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // clsAltoButton1
            // 
            this.clsAltoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton1.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clsAltoButton1.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton1.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Location = new System.Drawing.Point(25, 92);
            this.clsAltoButton1.Name = "clsAltoButton1";
            this.clsAltoButton1.Radius = 10;
            this.clsAltoButton1.Size = new System.Drawing.Size(105, 31);
            this.clsAltoButton1.Stroke = false;
            this.clsAltoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton1.TabIndex = 1;
            this.clsAltoButton1.Text = "文件上傳";
            this.clsAltoButton1.Transparency = false;
            this.clsAltoButton1.Click += new System.EventHandler(this.clsAltoButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(163, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(637, 399);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // clsAltoButton2
            // 
            this.clsAltoButton2.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clsAltoButton2.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton2.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton2.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton2.Location = new System.Drawing.Point(25, 155);
            this.clsAltoButton2.Name = "clsAltoButton2";
            this.clsAltoButton2.Radius = 10;
            this.clsAltoButton2.Size = new System.Drawing.Size(105, 31);
            this.clsAltoButton2.Stroke = false;
            this.clsAltoButton2.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton2.TabIndex = 3;
            this.clsAltoButton2.Text = "文件下載";
            this.clsAltoButton2.Transparency = false;
            this.clsAltoButton2.Click += new System.EventHandler(this.clsAltoButton2_Click);
            // 
            // clsAltoButton3
            // 
            this.clsAltoButton3.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton3.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton3.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clsAltoButton3.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton3.Inactive1 = System.Drawing.Color.DarkGray;
            this.clsAltoButton3.Inactive2 = System.Drawing.Color.DarkGray;
            this.clsAltoButton3.Location = new System.Drawing.Point(25, 280);
            this.clsAltoButton3.Name = "clsAltoButton3";
            this.clsAltoButton3.Radius = 10;
            this.clsAltoButton3.Size = new System.Drawing.Size(105, 31);
            this.clsAltoButton3.Stroke = false;
            this.clsAltoButton3.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton3.TabIndex = 4;
            this.clsAltoButton3.Text = "文件刪除";
            this.clsAltoButton3.Transparency = false;
            this.clsAltoButton3.Click += new System.EventHandler(this.clsAltoButton3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmFileBrowsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clsAltoButton3);
            this.Controls.Add(this.clsAltoButton2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.clsAltoButton1);
            this.MaximizeBox = false;
            this.Name = "FrmFileBrowsing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClsAltoButton clsAltoButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ClsAltoButton clsAltoButton2;
        private ClsAltoButton clsAltoButton3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}