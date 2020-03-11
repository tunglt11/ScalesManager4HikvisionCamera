namespace ScalesManager.Component
{
    partial class frmTapChat
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
            this.txtTapChat = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.lbThongBao = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbThongBao.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTapChat
            // 
            // 
            // 
            // 
            this.txtTapChat.Border.Class = "TextBoxBorder";
            this.txtTapChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTapChat.Location = new System.Drawing.Point(102, 25);
            this.txtTapChat.MaxLength = 30;
            this.txtTapChat.Name = "txtTapChat";
            this.txtTapChat.ShortcutsEnabled = false;
            this.txtTapChat.Size = new System.Drawing.Size(160, 22);
            this.txtTapChat.TabIndex = 63;
            this.txtTapChat.Text = "0";
            this.txtTapChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTapChat_KeyPress);
            // 
            // labelX16
            // 
            this.labelX16.BackColor = System.Drawing.Color.Transparent;
            this.labelX16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX16.Location = new System.Drawing.Point(20, 25);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(66, 20);
            this.labelX16.TabIndex = 62;
            this.labelX16.Text = "Khối lượng:";
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnLuu.Location = new System.Drawing.Point(102, 64);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(71, 29);
            this.btnLuu.TabIndex = 66;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnHuy.Location = new System.Drawing.Point(188, 64);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(71, 29);
            this.btnHuy.TabIndex = 67;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lbThongBao
            // 
            this.lbThongBao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.lbThongBao.Location = new System.Drawing.Point(0, 111);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(315, 22);
            this.lbThongBao.TabIndex = 68;
            this.lbThongBao.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = " ";
            // 
            // frmTapChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 133);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTapChat);
            this.Controls.Add(this.labelX16);
            this.DoubleBuffered = true;
            this.Name = "frmTapChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TẠP CHẤT";
            this.Load += new System.EventHandler(this.frmTapChat_Load);
            this.lbThongBao.ResumeLayout(false);
            this.lbThongBao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtTapChat;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private System.Windows.Forms.StatusStrip lbThongBao;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Label label1;
    }
}