namespace BusinessSystem
{
    partial class MainForm
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
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.mainControls4 = new MainControls.MainControls();
            this.mainControls1 = new MainControls.MainControls();
            this.mainControls3 = new MainControls.MainControls();
            this.mainControls2 = new MainControls.MainControls();
            this.mainControls8 = new MainControls.MainControls();
            this.mainControls5 = new MainControls.MainControls();
            this.mainControls9 = new MainControls.MainControls();
            this.mainControls7 = new MainControls.MainControls();
            this.rectangleShape_date = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label4 = new System.Windows.Forms.Label();
            this.mainControls6 = new MainControls.MainControls();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainControls4
            // 
            this.mainControls4.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls4.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls4.image = global::BusinessSystem.Properties.Resources.edit_property_128;
            this.mainControls4.Location = new System.Drawing.Point(10, 218);
            this.mainControls4.Name = "mainControls4";
            this.mainControls4.Size = new System.Drawing.Size(411, 200);
            this.mainControls4.TabIndex = 50;
            this.mainControls4.Title = "佈告欄";
            this.mainControls4.TitleColor = System.Drawing.Color.White;
            this.mainControls4.Click += new System.EventHandler(this.mainControls4_Click);
            // 
            // mainControls1
            // 
            this.mainControls1.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls1.ButtonColor = System.Drawing.Color.SlateGray;
            this.mainControls1.image = global::BusinessSystem.Properties.Resources.chair_2_128;
            this.mainControls1.Location = new System.Drawing.Point(428, 424);
            this.mainControls1.Name = "mainControls1";
            this.mainControls1.Size = new System.Drawing.Size(200, 200);
            this.mainControls1.TabIndex = 49;
            this.mainControls1.Title = "會議室租借";
            this.mainControls1.TitleColor = System.Drawing.Color.White;
            // 
            // mainControls3
            // 
            this.mainControls3.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls3.ButtonColor = System.Drawing.Color.SlateGray;
            this.mainControls3.image = global::BusinessSystem.Properties.Resources.briefcase_128;
            this.mainControls3.Location = new System.Drawing.Point(634, 215);
            this.mainControls3.Name = "mainControls3";
            this.mainControls3.Size = new System.Drawing.Size(200, 200);
            this.mainControls3.TabIndex = 48;
            this.mainControls3.Title = "工時回報";
            this.mainControls3.TitleColor = System.Drawing.Color.White;
            this.mainControls3.Click += new System.EventHandler(this.mainControls3_Click);
            // 
            // mainControls2
            // 
            this.mainControls2.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls2.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.mainControls2.image = global::BusinessSystem.Properties.Resources.car_128;
            this.mainControls2.Location = new System.Drawing.Point(221, 427);
            this.mainControls2.Name = "mainControls2";
            this.mainControls2.Size = new System.Drawing.Size(200, 200);
            this.mainControls2.TabIndex = 47;
            this.mainControls2.Title = "公務車租借";
            this.mainControls2.TitleColor = System.Drawing.Color.White;
            this.mainControls2.Click += new System.EventHandler(this.mainControls2_Click);
            // 
            // mainControls8
            // 
            this.mainControls8.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls8.ButtonColor = System.Drawing.Color.DarkSlateBlue;
            this.mainControls8.image = global::BusinessSystem.Properties.Resources.time_8_128;
            this.mainControls8.Location = new System.Drawing.Point(428, 218);
            this.mainControls8.Name = "mainControls8";
            this.mainControls8.Size = new System.Drawing.Size(200, 200);
            this.mainControls8.TabIndex = 46;
            this.mainControls8.Title = "請假";
            this.mainControls8.TitleColor = System.Drawing.Color.White;
            // 
            // mainControls5
            // 
            this.mainControls5.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls5.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls5.image = global::BusinessSystem.Properties.Resources.calendar_3_128;
            this.mainControls5.Location = new System.Drawing.Point(428, 9);
            this.mainControls5.Name = "mainControls5";
            this.mainControls5.Size = new System.Drawing.Size(200, 200);
            this.mainControls5.TabIndex = 44;
            this.mainControls5.Title = "行事曆";
            this.mainControls5.TitleColor = System.Drawing.Color.White;
            // 
            // mainControls9
            // 
            this.mainControls9.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls9.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls9.image = global::BusinessSystem.Properties.Resources.cart_5_128;
            this.mainControls9.Location = new System.Drawing.Point(634, 421);
            this.mainControls9.Name = "mainControls9";
            this.mainControls9.Size = new System.Drawing.Size(200, 200);
            this.mainControls9.TabIndex = 43;
            this.mainControls9.Title = "請購系統";
            this.mainControls9.TitleColor = System.Drawing.Color.White;
            this.mainControls9.Click += new System.EventHandler(this.mainControls9_Click);
            this.mainControls9.MouseEnter += new System.EventHandler(this.mainControls9_MouseEnter);
            this.mainControls9.MouseLeave += new System.EventHandler(this.mainControls9_MouseLeave);
            // 
            // mainControls7
            // 
            this.mainControls7.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls7.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.mainControls7.ForeColor = System.Drawing.Color.White;
            this.mainControls7.image = global::BusinessSystem.Properties.Resources.report_3_128;
            this.mainControls7.Location = new System.Drawing.Point(10, 427);
            this.mainControls7.Name = "mainControls7";
            this.mainControls7.Size = new System.Drawing.Size(200, 200);
            this.mainControls7.TabIndex = 41;
            this.mainControls7.Title = "文件上傳";
            this.mainControls7.TitleColor = System.Drawing.Color.Empty;
            // 
            // rectangleShape_date
            // 
            this.rectangleShape_date.BackColor = System.Drawing.Color.Gray;
            this.rectangleShape_date.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape_date.BorderColor = System.Drawing.Color.Transparent;
            this.rectangleShape_date.CornerRadius = 10;
            this.rectangleShape_date.Location = new System.Drawing.Point(12, 8);
            this.rectangleShape_date.Name = "rectangleShape_date";
            this.rectangleShape_date.Size = new System.Drawing.Size(410, 200);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(179, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 35);
            this.label4.TabIndex = 14;
            this.label4.Text = "日期";
            // 
            // mainControls6
            // 
            this.mainControls6.BackgroundColor = System.Drawing.Color.Empty;
            this.mainControls6.ButtonColor = System.Drawing.Color.SteelBlue;
            this.mainControls6.image = global::BusinessSystem.Properties.Resources.neutral_dicision_128;
            this.mainControls6.Location = new System.Drawing.Point(634, 9);
            this.mainControls6.Name = "mainControls6";
            this.mainControls6.Size = new System.Drawing.Size(200, 200);
            this.mainControls6.TabIndex = 45;
            this.mainControls6.Title = "行事曆";
            this.mainControls6.TitleColor = System.Drawing.Color.White;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainControls4);
            this.panel1.Controls.Add(this.mainControls1);
            this.panel1.Controls.Add(this.mainControls3);
            this.panel1.Controls.Add(this.mainControls2);
            this.panel1.Controls.Add(this.mainControls8);
            this.panel1.Controls.Add(this.mainControls6);
            this.panel1.Controls.Add(this.mainControls5);
            this.panel1.Controls.Add(this.mainControls9);
            this.panel1.Controls.Add(this.mainControls7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.shapeContainer2);
            this.panel1.Location = new System.Drawing.Point(22, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 641);
            this.panel1.TabIndex = 51;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape_date});
            this.shapeContainer2.Size = new System.Drawing.Size(850, 641);
            this.shapeContainer2.TabIndex = 51;
            this.shapeContainer2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 709);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private MainControls.MainControls mainControls7;
        private MainControls.MainControls mainControls9;
        private MainControls.MainControls mainControls5;
        private MainControls.MainControls mainControls8;
        private MainControls.MainControls mainControls2;
        private MainControls.MainControls mainControls3;
        private MainControls.MainControls mainControls1;
        private MainControls.MainControls mainControls4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape_date;
        private System.Windows.Forms.Label label4;
        private MainControls.MainControls mainControls6;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
    }
}