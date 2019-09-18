namespace MainControls
{
    partial class MainControls
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clsAltoButton1 = new Controls.ClsAltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "label";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(27, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // clsAltoButton1
            // 
            this.clsAltoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.clsAltoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.clsAltoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clsAltoButton1.BackColor = System.Drawing.Color.Transparent;
            this.clsAltoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.clsAltoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.clsAltoButton1.ForeColor = System.Drawing.Color.Black;
            this.clsAltoButton1.Inactive1 = System.Drawing.Color.SteelBlue;
            this.clsAltoButton1.Inactive2 = System.Drawing.Color.SteelBlue;
            this.clsAltoButton1.Location = new System.Drawing.Point(0, 0);
            this.clsAltoButton1.Name = "clsAltoButton1";
            this.clsAltoButton1.Radius = 10;
            this.clsAltoButton1.Size = new System.Drawing.Size(200, 200);
            this.clsAltoButton1.Stroke = false;
            this.clsAltoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.clsAltoButton1.TabIndex = 9;
            this.clsAltoButton1.Transparency = false;
            this.clsAltoButton1.Click += new System.EventHandler(this.clsAltoButton1_Click);
            this.clsAltoButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clsAltoButton1_MouseDown);
            this.clsAltoButton1.MouseEnter += new System.EventHandler(this.clsAltoButton1_MouseEnter);
            this.clsAltoButton1.MouseLeave += new System.EventHandler(this.clsAltoButton1_MouseLeave);
            this.clsAltoButton1.MouseHover += new System.EventHandler(this.clsAltoButton1_MouseHover);
            this.clsAltoButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clsAltoButton1_MouseUp);
            // 
            // MainControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clsAltoButton1);
            this.Name = "MainControls";
            this.Size = new System.Drawing.Size(200, 200);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.ClsAltoButton clsAltoButton1;
    }
}
