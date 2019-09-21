namespace BusinessSystem
{
    partial class FrmRequisition1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtProcductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnEnterToChangeDelete = new BusinessSystem.ClsAltoButton();
            this.btnShow = new BusinessSystem.ClsAltoButton();
            this.btnSubmit = new BusinessSystem.ClsAltoButton();
            this.btnClear = new BusinessSystem.ClsAltoButton();
            this.btnDEMO = new BusinessSystem.ClsAltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(242, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(650, 344);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // txtProcductName
            // 
            this.txtProcductName.Location = new System.Drawing.Point(107, 83);
            this.txtProcductName.Name = "txtProcductName";
            this.txtProcductName.Size = new System.Drawing.Size(100, 22);
            this.txtProcductName.TabIndex = 0;
            this.txtProcductName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtProcductName_MouseClick);
            this.txtProcductName.TextChanged += new System.EventHandler(this.txtProcductName_TextChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblProductName.Location = new System.Drawing.Point(23, 86);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(73, 17);
            this.lblProductName.TabIndex = 7;
            this.lblProductName.Text = "產品名稱：";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUnitPrice.Location = new System.Drawing.Point(23, 125);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(47, 17);
            this.lblUnitPrice.TabIndex = 8;
            this.lblUnitPrice.Text = "單價：";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(107, 122);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 22);
            this.txtUnitPrice.TabIndex = 1;
            this.txtUnitPrice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUnitPrice_MouseClick);
            this.txtUnitPrice.TextChanged += new System.EventHandler(this.txtUnitPrice_TextChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQuantity.Location = new System.Drawing.Point(23, 164);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(47, 17);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "數量：";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(107, 161);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 22);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtQuantity_MouseClick);
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNote.Location = new System.Drawing.Point(23, 202);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(73, 17);
            this.lblNote.TabIndex = 10;
            this.lblNote.Text = "請購原由：";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(26, 234);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(181, 69);
            this.txtNote.TabIndex = 3;
            this.txtNote.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNote_MouseClick);
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            // 
            // btnEnterToChangeDelete
            // 
            this.btnEnterToChangeDelete.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnEnterToChangeDelete.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnEnterToChangeDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnEnterToChangeDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnterToChangeDelete.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterToChangeDelete.ForeColor = System.Drawing.Color.White;
            this.btnEnterToChangeDelete.Inactive1 = System.Drawing.Color.MediumPurple;
            this.btnEnterToChangeDelete.Inactive2 = System.Drawing.Color.MediumSlateBlue;
            this.btnEnterToChangeDelete.Location = new System.Drawing.Point(11, 388);
            this.btnEnterToChangeDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnterToChangeDelete.Name = "btnEnterToChangeDelete";
            this.btnEnterToChangeDelete.Radius = 10;
            this.btnEnterToChangeDelete.Size = new System.Drawing.Size(204, 24);
            this.btnEnterToChangeDelete.Stroke = false;
            this.btnEnterToChangeDelete.StrokeColor = System.Drawing.Color.Gray;
            this.btnEnterToChangeDelete.TabIndex = 6;
            this.btnEnterToChangeDelete.Text = "進入修改、刪除頁面";
            this.btnEnterToChangeDelete.Transparency = false;
            this.btnEnterToChangeDelete.Click += new System.EventHandler(this.btnEnterToChangeDelete_Click);
            // 
            // btnShow
            // 
            this.btnShow.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnShow.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnShow.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnShow.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnShow.Location = new System.Drawing.Point(11, 353);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Radius = 10;
            this.btnShow.Size = new System.Drawing.Size(88, 24);
            this.btnShow.Stroke = false;
            this.btnShow.StrokeColor = System.Drawing.Color.Gray;
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "展示";
            this.btnShow.Transparency = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnSubmit.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.btnSubmit.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.btnSubmit.Location = new System.Drawing.Point(11, 318);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 10;
            this.btnSubmit.Size = new System.Drawing.Size(88, 24);
            this.btnSubmit.Stroke = false;
            this.btnSubmit.StrokeColor = System.Drawing.Color.Gray;
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "新增";
            this.btnSubmit.Transparency = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            this.btnClear.Location = new System.Drawing.Point(127, 353);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 10;
            this.btnClear.Size = new System.Drawing.Size(88, 24);
            this.btnClear.Stroke = false;
            this.btnClear.StrokeColor = System.Drawing.Color.Gray;
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "清除";
            this.btnClear.Transparency = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDEMO
            // 
            this.btnDEMO.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btnDEMO.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btnDEMO.BackColor = System.Drawing.Color.Transparent;
            this.btnDEMO.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDEMO.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnDEMO.ForeColor = System.Drawing.Color.White;
            this.btnDEMO.Inactive1 = System.Drawing.Color.CornflowerBlue;
            this.btnDEMO.Inactive2 = System.Drawing.Color.CornflowerBlue;
            this.btnDEMO.Location = new System.Drawing.Point(127, 318);
            this.btnDEMO.Name = "btnDEMO";
            this.btnDEMO.Radius = 10;
            this.btnDEMO.Size = new System.Drawing.Size(88, 24);
            this.btnDEMO.Stroke = false;
            this.btnDEMO.StrokeColor = System.Drawing.Color.Gray;
            this.btnDEMO.TabIndex = 13;
            this.btnDEMO.Text = "DEMO";
            this.btnDEMO.Transparency = false;
            this.btnDEMO.Click += new System.EventHandler(this.btnDEMO_Click);
            // 
            // FrmRequisition1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 454);
            this.Controls.Add(this.btnDEMO);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEnterToChangeDelete);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProcductName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmRequisition1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisition";
            this.Load += new System.EventHandler(this.FrmRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ClsAltoButton btnSubmit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProcductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private ClsAltoButton btnShow;
        private ClsAltoButton btnEnterToChangeDelete;
        private ClsAltoButton btnClear;
        private ClsAltoButton btnDEMO;
    }
}