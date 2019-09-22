namespace BusinessSystem.Requisition
{
    partial class FrmRequisition2
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
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProcductName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOnlyShow = new BusinessSystem.ClsAltoButton();
            this.btnChange = new BusinessSystem.ClsAltoButton();
            this.btnClear = new BusinessSystem.ClsAltoButton();
            this.btnAllShow = new BusinessSystem.ClsAltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtReportID
            // 
            this.txtReportID.Location = new System.Drawing.Point(98, 69);
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.Size = new System.Drawing.Size(100, 22);
            this.txtReportID.TabIndex = 36;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(670, 113);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(100, 22);
            this.txtNote.TabIndex = 35;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNote.Location = new System.Drawing.Point(622, 116);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 17);
            this.lblNote.TabIndex = 34;
            this.lblNote.Text = "備註：";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQuantity.Location = new System.Drawing.Point(431, 116);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(47, 17);
            this.lblQuantity.TabIndex = 33;
            this.lblQuantity.Text = "數量：";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(480, 113);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 22);
            this.txtQuantity.TabIndex = 32;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUnitPrice.Location = new System.Drawing.Point(240, 116);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(47, 17);
            this.lblUnitPrice.TabIndex = 31;
            this.lblUnitPrice.Text = "單價：";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(288, 113);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 22);
            this.txtUnitPrice.TabIndex = 30;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblProductName.Location = new System.Drawing.Point(23, 116);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(73, 17);
            this.lblProductName.TabIndex = 29;
            this.lblProductName.Text = "產品名稱：";
            // 
            // txtProcductName
            // 
            this.txtProcductName.Location = new System.Drawing.Point(98, 113);
            this.txtProcductName.Name = "txtProcductName";
            this.txtProcductName.Size = new System.Drawing.Size(100, 22);
            this.txtProcductName.TabIndex = 28;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(744, 143);
            this.dataGridView1.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "訂單編號：";
            // 
            // btnOnlyShow
            // 
            this.btnOnlyShow.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnOnlyShow.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnOnlyShow.BackColor = System.Drawing.Color.Transparent;
            this.btnOnlyShow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOnlyShow.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnlyShow.ForeColor = System.Drawing.Color.White;
            this.btnOnlyShow.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnOnlyShow.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnOnlyShow.Location = new System.Drawing.Point(243, 67);
            this.btnOnlyShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnOnlyShow.Name = "btnOnlyShow";
            this.btnOnlyShow.Radius = 10;
            this.btnOnlyShow.Size = new System.Drawing.Size(145, 24);
            this.btnOnlyShow.Stroke = false;
            this.btnOnlyShow.StrokeColor = System.Drawing.Color.Gray;
            this.btnOnlyShow.TabIndex = 39;
            this.btnOnlyShow.Text = "展示單筆請購單";
            this.btnOnlyShow.Transparency = false;
            this.btnOnlyShow.Click += new System.EventHandler(this.btnOnlyShow_Click);
            // 
            // btnChange
            // 
            this.btnChange.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnChange.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnChange.BackColor = System.Drawing.Color.Transparent;
            this.btnChange.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChange.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnChange.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnChange.Location = new System.Drawing.Point(532, 301);
            this.btnChange.Margin = new System.Windows.Forms.Padding(2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Radius = 10;
            this.btnChange.Size = new System.Drawing.Size(84, 24);
            this.btnChange.Stroke = false;
            this.btnChange.StrokeColor = System.Drawing.Color.Gray;
            this.btnChange.TabIndex = 37;
            this.btnChange.Text = "修改";
            this.btnChange.Transparency = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClear
            // 
            this.btnClear.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnClear.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.Location = new System.Drawing.Point(677, 301);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 10;
            this.btnClear.Size = new System.Drawing.Size(88, 24);
            this.btnClear.Stroke = false;
            this.btnClear.StrokeColor = System.Drawing.Color.Gray;
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "刪除";
            this.btnClear.Transparency = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAllShow
            // 
            this.btnAllShow.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnAllShow.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnAllShow.BackColor = System.Drawing.Color.Transparent;
            this.btnAllShow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAllShow.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllShow.ForeColor = System.Drawing.Color.White;
            this.btnAllShow.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnAllShow.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnAllShow.Location = new System.Drawing.Point(26, 301);
            this.btnAllShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllShow.Name = "btnAllShow";
            this.btnAllShow.Radius = 10;
            this.btnAllShow.Size = new System.Drawing.Size(145, 24);
            this.btnAllShow.Stroke = false;
            this.btnAllShow.StrokeColor = System.Drawing.Color.Gray;
            this.btnAllShow.TabIndex = 42;
            this.btnAllShow.Text = "顯示所有請購單";
            this.btnAllShow.Transparency = false;
            this.btnAllShow.Click += new System.EventHandler(this.btnAllShow_Click);
            // 
            // FrmRequisition2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.btnAllShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOnlyShow);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtReportID);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProcductName);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmRequisition2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改、刪除請購單";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClsAltoButton btnOnlyShow;
        private ClsAltoButton btnChange;
        private System.Windows.Forms.TextBox txtReportID;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProcductName;
        private ClsAltoButton btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private ClsAltoButton btnAllShow;
    }
}