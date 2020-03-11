namespace ScalesManager.Component
{
    partial class frmExpirationDate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeys = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXacNhan = new DevComponents.DotNetBar.ButtonX();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(-2, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiên bản sử dụng hiện tại của bạn đã hết hạn.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(33, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vui lòng nhập mã sử dụng hoặc liên hệ nhà cũng cấp để được mở khóa.";
            // 
            // txtKeys
            // 
            this.txtKeys.Location = new System.Drawing.Point(41, 162);
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.PasswordChar = '●';
            this.txtKeys.Size = new System.Drawing.Size(420, 20);
            this.txtKeys.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã sử dụng:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXacNhan.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnXacNhan.Location = new System.Drawing.Point(147, 201);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 31);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(41, 186);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(55, 13);
            this.lbThongBao.TabIndex = 6;
            this.lbThongBao.Text = "            ";
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnThoat.Location = new System.Drawing.Point(261, 201);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 31);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmExpirationDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 244);
            this.ControlBox = false;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExpirationDate";
            this.Text = "HẠN SỬ DỤNG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExpirationDate_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExpirationDate_FormClosed);
            this.Load += new System.EventHandler(this.frmExpirationDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeys;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnXacNhan;
        private System.Windows.Forms.Label lbThongBao;
        private DevComponents.DotNetBar.ButtonX btnThoat;
    }
}