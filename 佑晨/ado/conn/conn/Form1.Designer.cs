namespace conn
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
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.lvCustomers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SmalimageList = new System.Windows.Forms.ImageList(this.components);
            this.LargeimageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.大型圖示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小型圖示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.詳細資料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.並排ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "國家:";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(49, 21);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(161, 20);
            this.cbCountry.TabIndex = 1;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // lvCustomers
            // 
            this.lvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvCustomers.ContextMenuStrip = this.contextMenuStrip1;
            this.lvCustomers.LargeImageList = this.LargeimageList;
            this.lvCustomers.Location = new System.Drawing.Point(12, 47);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(776, 391);
            this.lvCustomers.SmallImageList = this.SmalimageList;
            this.lvCustomers.TabIndex = 2;
            this.lvCustomers.UseCompatibleStateImageBehavior = false;
            this.lvCustomers.View = System.Windows.Forms.View.Details;
            this.lvCustomers.Resize += new System.EventHandler(this.lvCustomers_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "客戶別";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "客戶名稱";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "訂單名稱";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "城市";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "地區";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "國家";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "電話";
            // 
            // SmalimageList
            // 
            this.SmalimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmalimageList.ImageStream")));
            this.SmalimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SmalimageList.Images.SetKeyName(0, "Afghanistan.png");
            this.SmalimageList.Images.SetKeyName(1, "African Union(OAS).png");
            this.SmalimageList.Images.SetKeyName(2, "Albania.png");
            this.SmalimageList.Images.SetKeyName(3, "Algeria.png");
            this.SmalimageList.Images.SetKeyName(4, "American Samoa.png");
            this.SmalimageList.Images.SetKeyName(5, "Andorra.png");
            this.SmalimageList.Images.SetKeyName(6, "Angola.png");
            this.SmalimageList.Images.SetKeyName(7, "Anguilla.png");
            this.SmalimageList.Images.SetKeyName(8, "Antarctica.png");
            this.SmalimageList.Images.SetKeyName(9, "Antigua & Barbuda.png");
            this.SmalimageList.Images.SetKeyName(10, "Arab League.png");
            this.SmalimageList.Images.SetKeyName(11, "Argentina.png");
            this.SmalimageList.Images.SetKeyName(12, "Armenia.png");
            this.SmalimageList.Images.SetKeyName(13, "Aruba.png");
            this.SmalimageList.Images.SetKeyName(14, "ASEAN.png");
            this.SmalimageList.Images.SetKeyName(15, "Australia.png");
            this.SmalimageList.Images.SetKeyName(16, "Austria.png");
            this.SmalimageList.Images.SetKeyName(17, "Azerbaijan.png");
            this.SmalimageList.Images.SetKeyName(18, "Bahamas.png");
            this.SmalimageList.Images.SetKeyName(19, "Bahrain.png");
            this.SmalimageList.Images.SetKeyName(20, "Bangladesh.png");
            // 
            // LargeimageList
            // 
            this.LargeimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeimageList.ImageStream")));
            this.LargeimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeimageList.Images.SetKeyName(0, "Afghanistan.png");
            this.LargeimageList.Images.SetKeyName(1, "African Union.png");
            this.LargeimageList.Images.SetKeyName(2, "Albania.png");
            this.LargeimageList.Images.SetKeyName(3, "Algeria.png");
            this.LargeimageList.Images.SetKeyName(4, "American Samoa.png");
            this.LargeimageList.Images.SetKeyName(5, "Andorra.png");
            this.LargeimageList.Images.SetKeyName(6, "Angola.png");
            this.LargeimageList.Images.SetKeyName(7, "Anguilla.png");
            this.LargeimageList.Images.SetKeyName(8, "Antarctica.png");
            this.LargeimageList.Images.SetKeyName(9, "Antigua & Barbuda.png");
            this.LargeimageList.Images.SetKeyName(10, "Arab League.png");
            this.LargeimageList.Images.SetKeyName(11, "Argentina.png");
            this.LargeimageList.Images.SetKeyName(12, "Armenia.png");
            this.LargeimageList.Images.SetKeyName(13, "Aruba.png");
            this.LargeimageList.Images.SetKeyName(14, "ASEAN.png");
            this.LargeimageList.Images.SetKeyName(15, "Australia.png");
            this.LargeimageList.Images.SetKeyName(16, "Austria.png");
            this.LargeimageList.Images.SetKeyName(17, "Azerbaijan.png");
            this.LargeimageList.Images.SetKeyName(18, "Bahamas.png");
            this.LargeimageList.Images.SetKeyName(19, "Bahrain.png");
            this.LargeimageList.Images.SetKeyName(20, "Bangladesh.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大型圖示ToolStripMenuItem,
            this.小型圖示ToolStripMenuItem,
            this.清單ToolStripMenuItem,
            this.詳細資料ToolStripMenuItem,
            this.並排ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 114);
            // 
            // 大型圖示ToolStripMenuItem
            // 
            this.大型圖示ToolStripMenuItem.Name = "大型圖示ToolStripMenuItem";
            this.大型圖示ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.大型圖示ToolStripMenuItem.Text = "大型圖示";
            this.大型圖示ToolStripMenuItem.Click += new System.EventHandler(this.大型圖示ToolStripMenuItem_Click);
            // 
            // 小型圖示ToolStripMenuItem
            // 
            this.小型圖示ToolStripMenuItem.Name = "小型圖示ToolStripMenuItem";
            this.小型圖示ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.小型圖示ToolStripMenuItem.Text = "小型圖示";
            this.小型圖示ToolStripMenuItem.Click += new System.EventHandler(this.小型圖示ToolStripMenuItem_Click);
            // 
            // 清單ToolStripMenuItem
            // 
            this.清單ToolStripMenuItem.Name = "清單ToolStripMenuItem";
            this.清單ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.清單ToolStripMenuItem.Text = "清單";
            this.清單ToolStripMenuItem.Click += new System.EventHandler(this.清單ToolStripMenuItem_Click);
            // 
            // 詳細資料ToolStripMenuItem
            // 
            this.詳細資料ToolStripMenuItem.Name = "詳細資料ToolStripMenuItem";
            this.詳細資料ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.詳細資料ToolStripMenuItem.Text = "詳細資料";
            this.詳細資料ToolStripMenuItem.Click += new System.EventHandler(this.詳細資料ToolStripMenuItem_Click);
            // 
            // 並排ToolStripMenuItem
            // 
            this.並排ToolStripMenuItem.Name = "並排ToolStripMenuItem";
            this.並排ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.並排ToolStripMenuItem.Text = "並排";
            this.並排ToolStripMenuItem.Click += new System.EventHandler(this.並排ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvCustomers);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.ListView lvCustomers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ImageList LargeimageList;
        private System.Windows.Forms.ImageList SmalimageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 大型圖示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小型圖示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清單ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 詳細資料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 並排ToolStripMenuItem;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
    }
}

