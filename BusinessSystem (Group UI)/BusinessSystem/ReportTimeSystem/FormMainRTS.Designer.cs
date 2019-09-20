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
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.clsAltoButton4 = new Controls.ClsAltoButton();
            this.clsAltoButton3 = new Controls.ClsAltoButton();
            this.clsAltoButton2 = new Controls.ClsAltoButton();
            this.clsAltoButton1 = new Controls.ClsAltoButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 489);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.clsAltoButton4);
            this.splitContainer1.Panel1.Controls.Add(this.clsAltoButton3);
            this.splitContainer1.Panel1.Controls.Add(this.clsAltoButton2);
            this.splitContainer1.Panel1.Controls.Add(this.clsAltoButton1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(869, 489);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 3;
            // 
            // clsAltoButton4
            // 
            this.clsAltoButton4.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton4.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton4.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton4.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton4.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton4.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.clsAltoButton4.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.clsAltoButton4.Location = new System.Drawing.Point(33, 282);
            this.clsAltoButton4.Name = "clsAltoButton4";
            this.clsAltoButton4.Radius = 10;
            this.clsAltoButton4.Size = new System.Drawing.Size(155, 61);
            this.clsAltoButton4.Stroke = false;
            this.clsAltoButton4.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton4.TabIndex = 6;
            this.clsAltoButton4.Text = "分析";
            this.clsAltoButton4.Transparency = false;
            // 
            // clsAltoButton3
            // 
            this.clsAltoButton3.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton3.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton3.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton3.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton3.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton3.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.clsAltoButton3.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.clsAltoButton3.Location = new System.Drawing.Point(33, 200);
            this.clsAltoButton3.Name = "clsAltoButton3";
            this.clsAltoButton3.Radius = 10;
            this.clsAltoButton3.Size = new System.Drawing.Size(155, 61);
            this.clsAltoButton3.Stroke = false;
            this.clsAltoButton3.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton3.TabIndex = 5;
            this.clsAltoButton3.Text = "刪除報表";
            this.clsAltoButton3.Transparency = false;
            this.clsAltoButton3.Click += new System.EventHandler(this.clsAltoButton3_Click);
            // 
            // clsAltoButton2
            // 
            this.clsAltoButton2.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton2.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton2.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton2.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton2.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton2.Location = new System.Drawing.Point(33, 118);
            this.clsAltoButton2.Name = "clsAltoButton2";
            this.clsAltoButton2.Radius = 10;
            this.clsAltoButton2.Size = new System.Drawing.Size(155, 61);
            this.clsAltoButton2.Stroke = false;
            this.clsAltoButton2.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton2.TabIndex = 4;
            this.clsAltoButton2.Text = "修改報表";
            this.clsAltoButton2.Transparency = false;
            this.clsAltoButton2.Click += new System.EventHandler(this.clsAltoButton2_Click);
            // 
            // clsAltoButton1
            // 
            this.clsAltoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.clsAltoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.clsAltoButton1.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsAltoButton1.ForeColor = System.Drawing.Color.White;
            this.clsAltoButton1.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.clsAltoButton1.Location = new System.Drawing.Point(33, 36);
            this.clsAltoButton1.Name = "clsAltoButton1";
            this.clsAltoButton1.Radius = 10;
            this.clsAltoButton1.Size = new System.Drawing.Size(155, 61);
            this.clsAltoButton1.Stroke = false;
            this.clsAltoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton1.TabIndex = 3;
            this.clsAltoButton1.Text = "工時報表";
            this.clsAltoButton1.Transparency = false;
            this.clsAltoButton1.Click += new System.EventHandler(this.clsAltoButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(617, 489);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // FormMainRTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 489);
            this.Controls.Add(this.panel2);
            this.Name = "FormMainRTS";
            this.Text = "FormMainRTS";
            this.Load += new System.EventHandler(this.FormMainRTS_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ClsAltoButton clsAltoButton4;
        private Controls.ClsAltoButton clsAltoButton3;
        private Controls.ClsAltoButton clsAltoButton2;
        private Controls.ClsAltoButton clsAltoButton1;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}