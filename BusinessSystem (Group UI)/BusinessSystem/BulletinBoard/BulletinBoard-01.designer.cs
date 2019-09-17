﻿namespace BusinessSystem
{
    partial class BulletinBoard
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.CBGroup = new BusinessSystem.CheckedComboBox();
            this.CBDepartment = new BusinessSystem.CheckedComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Location = new System.Drawing.Point(0, 140);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 360);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "部門";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "組別";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "內容";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "張貼時間";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CBGroup);
            this.panel2.Controls.Add(this.CBDepartment);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 70);
            this.panel2.TabIndex = 3;
            // 
            // CBGroup
            // 
            this.CBGroup.CheckOnClick = true;
            this.CBGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CBGroup.DropDownHeight = 1;
            this.CBGroup.FormattingEnabled = true;
            this.CBGroup.IntegralHeight = false;
            this.CBGroup.Location = new System.Drawing.Point(450, 27);
            this.CBGroup.Name = "CBGroup";
            this.CBGroup.Size = new System.Drawing.Size(208, 26);
            this.CBGroup.TabIndex = 9;
            this.CBGroup.ValueSeparator = ", ";
            // 
            // CBDepartment
            // 
            this.CBDepartment.CheckOnClick = true;
            this.CBDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CBDepartment.DropDownHeight = 1;
            this.CBDepartment.FormattingEnabled = true;
            this.CBDepartment.IntegralHeight = false;
            this.CBDepartment.Location = new System.Drawing.Point(93, 27);
            this.CBDepartment.Name = "CBDepartment";
            this.CBDepartment.Size = new System.Drawing.Size(278, 26);
            this.CBDepartment.TabIndex = 8;
            this.CBDepartment.ValueSeparator = ", ";
            this.CBDepartment.SelectedIndexChanged += new System.EventHandler(this.CBDepartment_SelectedIndexChanged);
            this.CBDepartment.DropDownClosed += new System.EventHandler(this.CBDepartment_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "組別:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "部門:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(800, 360);
            this.dataGridView1.TabIndex = 4;
            // 
            // BulletinBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listView1);
            this.Name = "BulletinBoard";
            this.Text = "BulletinBoard";
            this.Load += new System.EventHandler(this.BulletinBoard_Load);
            this.Resize += new System.EventHandler(this.BulletinBoard_Resize);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CheckedComboBox CBGroup;
        private CheckedComboBox CBDepartment;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}