namespace OO_Draw_Simple_AbstractMember_CS
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.Button1 = new System.Windows.Forms.Button();
            this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBar1 = new System.Windows.Forms.ToolBar();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Button4);
            this.GroupBox1.Controls.Add(this.Button3);
            this.GroupBox1.Controls.Add(this.Button5);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox1.Location = new System.Drawing.Point(0, 338);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(595, 74);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Serialization";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(16, 37);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(62, 23);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Save";
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(96, 37);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(60, 24);
            this.Button4.TabIndex = 4;
            this.Button4.Text = "Reload";
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(176, 37);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(63, 23);
            this.Button3.TabIndex = 3;
            this.Button3.Text = "Redraw";
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(256, 37);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(62, 22);
            this.Button5.TabIndex = 5;
            this.Button5.Text = "Clear";
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // ToolBarButton1
            // 
            this.ToolBarButton1.ImageIndex = 0;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.ToolTipText = "Line";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(367, 8);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(62, 23);
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Color";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ToolBarButton2
            // 
            this.ToolBarButton2.ImageIndex = 1;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.ToolTipText = "Rectangle";
            // 
            // ToolBar1
            // 
            this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarButton1,
            this.ToolBarButton2,
            this.toolBarButton3});
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.ImageList = this.ImageList1;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(595, 41);
            this.ToolBar1.TabIndex = 7;
            this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "");
            this.ImageList1.Images.SetKeyName(1, "");
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Text = "Elipse";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 412);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ToolBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.ToolBarButton ToolBarButton1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.ToolBarButton ToolBarButton2;
        internal System.Windows.Forms.ToolBar ToolBar1;
        internal System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
    }
}

