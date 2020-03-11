namespace ScalesManager.Component
{
    partial class frmCauHinhCanTD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtKhoiLuong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.txtThoiGian = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.txtKhoiLuong);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.txtThoiGian);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 192);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(272, 22);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(65, 25);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "Kg";
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(272, 66);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 25);
            this.labelX3.TabIndex = 16;
            this.labelX3.Text = "Giây";
            // 
            // txtKhoiLuong
            // 
            // 
            // 
            // 
            this.txtKhoiLuong.Border.Class = "TextBoxBorder";
            this.txtKhoiLuong.Location = new System.Drawing.Point(160, 26);
            this.txtKhoiLuong.Name = "txtKhoiLuong";
            this.txtKhoiLuong.Size = new System.Drawing.Size(105, 20);
            this.txtKhoiLuong.TabIndex = 15;
            this.txtKhoiLuong.TextChanged += new System.EventHandler(this.txtKhoiLuong_TextChanged);
            this.txtKhoiLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKhoiLuong_KeyPress);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(183, 124);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(65, 124);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 30);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtThoiGian
            // 
            // 
            // 
            // 
            this.txtThoiGian.Border.Class = "TextBoxBorder";
            this.txtThoiGian.Location = new System.Drawing.Point(160, 71);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(105, 20);
            this.txtThoiGian.TabIndex = 12;
            this.txtThoiGian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiGian_KeyPress);
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(63, 69);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(89, 25);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "Thời gian:";
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(63, 19);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(89, 27);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "Khối lượng:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 192);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(393, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmCauHinhCanTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 214);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "frmCauHinhCanTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẤU HÌNH CÂN TỰ ĐỘNG";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtThoiGian;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKhoiLuong;
    }
}