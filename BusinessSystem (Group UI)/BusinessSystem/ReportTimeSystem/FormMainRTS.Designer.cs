namespace BusinessSystem.ReportTimeSystem
{
    partial class FormMainRTS
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
            this.clsAltoButton2 = new BusinessSystem.ClsAltoButton();
            this.clsAltoButton3 = new BusinessSystem.ClsAltoButton();
            this.SuspendLayout();
            // 
            // clsAltoButton1
            // 
            this.clsAltoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton1.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton1.ForeColor = System.Drawing.Color.Black;
            this.clsAltoButton1.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.clsAltoButton1.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.clsAltoButton1.Location = new System.Drawing.Point(57, 84);
            this.clsAltoButton1.Name = "clsAltoButton1";
            this.clsAltoButton1.Radius = 10;
            this.clsAltoButton1.Size = new System.Drawing.Size(241, 98);
            this.clsAltoButton1.Stroke = false;
            this.clsAltoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton1.TabIndex = 1;
            this.clsAltoButton1.Text = "工時回報";
            this.clsAltoButton1.Transparency = false;
            // 
            // clsAltoButton2
            // 
            this.clsAltoButton2.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton2.ForeColor = System.Drawing.Color.Black;
            this.clsAltoButton2.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.clsAltoButton2.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.clsAltoButton2.Location = new System.Drawing.Point(57, 199);
            this.clsAltoButton2.Name = "clsAltoButton2";
            this.clsAltoButton2.Radius = 10;
            this.clsAltoButton2.Size = new System.Drawing.Size(241, 98);
            this.clsAltoButton2.Stroke = false;
            this.clsAltoButton2.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton2.TabIndex = 2;
            this.clsAltoButton2.Text = "修改回報";
            this.clsAltoButton2.Transparency = false;
            // 
            // clsAltoButton3
            // 
            this.clsAltoButton3.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton3.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton3.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton3.ForeColor = System.Drawing.Color.Black;
            this.clsAltoButton3.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.clsAltoButton3.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.clsAltoButton3.Location = new System.Drawing.Point(57, 314);
            this.clsAltoButton3.Name = "clsAltoButton3";
            this.clsAltoButton3.Radius = 10;
            this.clsAltoButton3.Size = new System.Drawing.Size(241, 98);
            this.clsAltoButton3.Stroke = false;
            this.clsAltoButton3.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton3.TabIndex = 3;
            this.clsAltoButton3.Text = "刪除回報";
            this.clsAltoButton3.Transparency = false;
            // 
            // FormMainRTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clsAltoButton3);
            this.Controls.Add(this.clsAltoButton2);
            this.Controls.Add(this.clsAltoButton1);
            this.Name = "FormMainRTS";
            this.Text = "FormMainRTS";
            this.Load += new System.EventHandler(this.FormMainRTS_Load);
            this.Controls.SetChildIndex(this.clsAltoButton1, 0);
            this.Controls.SetChildIndex(this.clsAltoButton2, 0);
            this.Controls.SetChildIndex(this.clsAltoButton3, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ClsAltoButton clsAltoButton1;
        private ClsAltoButton clsAltoButton2;
        private ClsAltoButton clsAltoButton3;
    }
}