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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DeleteRTSButton = new Controls.ClsAltoButton();
            this.AddRTSButton = new Controls.ClsAltoButton();
            this.ChartRTSButton = new Controls.ClsAltoButton();
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
            this.panel2.Size = new System.Drawing.Size(869, 576);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DeleteRTSButton);
            this.splitContainer1.Panel2.Controls.Add(this.AddRTSButton);
            this.splitContainer1.Panel2.Controls.Add(this.ChartRTSButton);
            this.splitContainer1.Size = new System.Drawing.Size(869, 517);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(869, 392);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // DeleteRTSButton
            // 
            this.DeleteRTSButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.DeleteRTSButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.DeleteRTSButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteRTSButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DeleteRTSButton.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteRTSButton.ForeColor = System.Drawing.Color.White;
            this.DeleteRTSButton.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.DeleteRTSButton.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.DeleteRTSButton.Location = new System.Drawing.Point(234, 13);
            this.DeleteRTSButton.Name = "DeleteRTSButton";
            this.DeleteRTSButton.Radius = 10;
            this.DeleteRTSButton.Size = new System.Drawing.Size(184, 61);
            this.DeleteRTSButton.Stroke = false;
            this.DeleteRTSButton.StrokeColor = System.Drawing.Color.Gray;
            this.DeleteRTSButton.TabIndex = 7;
            this.DeleteRTSButton.Text = "刪除選取資料";
            this.DeleteRTSButton.Transparency = false;
            this.DeleteRTSButton.Click += new System.EventHandler(this.DeleteRTSButton_Click);
            // 
            // AddRTSButton
            // 
            this.AddRTSButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.AddRTSButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.AddRTSButton.BackColor = System.Drawing.Color.Transparent;
            this.AddRTSButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddRTSButton.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRTSButton.ForeColor = System.Drawing.Color.White;
            this.AddRTSButton.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.AddRTSButton.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.AddRTSButton.Location = new System.Drawing.Point(73, 13);
            this.AddRTSButton.Name = "AddRTSButton";
            this.AddRTSButton.Radius = 10;
            this.AddRTSButton.Size = new System.Drawing.Size(155, 61);
            this.AddRTSButton.Stroke = false;
            this.AddRTSButton.StrokeColor = System.Drawing.Color.Gray;
            this.AddRTSButton.TabIndex = 3;
            this.AddRTSButton.Text = "工時報表";
            this.AddRTSButton.Transparency = false;
            this.AddRTSButton.Click += new System.EventHandler(this.AddRTSButton_Click);
            // 
            // ChartRTSButton
            // 
            this.ChartRTSButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.ChartRTSButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.ChartRTSButton.BackColor = System.Drawing.Color.Transparent;
            this.ChartRTSButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ChartRTSButton.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartRTSButton.ForeColor = System.Drawing.Color.White;
            this.ChartRTSButton.Inactive1 = System.Drawing.Color.DarkSlateBlue;
            this.ChartRTSButton.Inactive2 = System.Drawing.Color.DarkSlateBlue;
            this.ChartRTSButton.Location = new System.Drawing.Point(615, 13);
            this.ChartRTSButton.Name = "ChartRTSButton";
            this.ChartRTSButton.Radius = 10;
            this.ChartRTSButton.Size = new System.Drawing.Size(155, 61);
            this.ChartRTSButton.Stroke = false;
            this.ChartRTSButton.StrokeColor = System.Drawing.Color.Gray;
            this.ChartRTSButton.TabIndex = 6;
            this.ChartRTSButton.Text = "分析";
            this.ChartRTSButton.Transparency = false;
            this.ChartRTSButton.Click += new System.EventHandler(this.ChartRTSButton_Click);
            // 
            // FormMainRTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 576);
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
        private Controls.ClsAltoButton AddRTSButton;
        public System.Windows.Forms.DataGridView dataGridView1;
        private Controls.ClsAltoButton ChartRTSButton;
        private Controls.ClsAltoButton DeleteRTSButton;
    }
}