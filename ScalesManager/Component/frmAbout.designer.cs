namespace ScalesManager
{
    partial class frmAbout
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
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lbl01 = new System.Windows.Forms.Label();
            this.lbl03 = new System.Windows.Forms.Label();
            this.lbl02 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(378, 167);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTitle.Location = new System.Drawing.Point(129, 24);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(214, 34);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "SCALES MANAGER";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.DimGray;
            this.pnlLine.Location = new System.Drawing.Point(16, 135);
            this.pnlLine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(462, 10);
            this.pnlLine.TabIndex = 4;
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Location = new System.Drawing.Point(179, 62);
            this.lbl01.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(60, 17);
            this.lbl01.TabIndex = 2;
            this.lbl01.Text = "Version:";
            // 
            // lbl03
            // 
            this.lbl03.AutoSize = true;
            this.lbl03.Location = new System.Drawing.Point(165, 97);
            this.lbl03.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl03.Name = "lbl03";
            this.lbl03.Size = new System.Drawing.Size(118, 17);
            this.lbl03.TabIndex = 3;
            this.lbl03.Text = "@Copyright 2018";
            // 
            // lbl02
            // 
            this.lbl02.AutoSize = true;
            this.lbl02.Location = new System.Drawing.Point(236, 62);
            this.lbl02.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl02.Name = "lbl02";
            this.lbl02.Size = new System.Drawing.Size(28, 17);
            this.lbl02.TabIndex = 2;
            this.lbl02.Text = "1.0";
            // 
            // frmAbout
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 208);
            this.Controls.Add(this.lbl03);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÔNG TIN PHẦN MỀM";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.Label lbl03;
    }
}