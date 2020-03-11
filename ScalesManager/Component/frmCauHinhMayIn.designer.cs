namespace ScalesManager.Component
{
    partial class frmCauHinhMayIn
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.txtSoPhieu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbb_COMPort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 167);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(435, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.cbb_COMPort);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 167);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(226, 118);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 31);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(108, 118);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 31);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtSoPhieu
            // 
            // 
            // 
            // 
            this.txtSoPhieu.Border.Class = "TextBoxBorder";
            this.txtSoPhieu.Location = new System.Drawing.Point(108, 66);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(51, 21);
            this.txtSoPhieu.TabIndex = 12;
            this.txtSoPhieu.TextChanged += new System.EventHandler(this.txtSoPhieu_TextChanged);
            this.txtSoPhieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoPhieu_KeyPress);
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(11, 64);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(89, 25);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "Số phiếu in:";
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(11, 14);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(89, 27);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "Chọn máy in:";
            // 
            // cbb_COMPort
            // 
            this.cbb_COMPort.DisplayMember = "Text";
            this.cbb_COMPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_COMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_COMPort.FormattingEnabled = true;
            this.cbb_COMPort.ItemHeight = 15;
            this.cbb_COMPort.Location = new System.Drawing.Point(108, 19);
            this.cbb_COMPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbb_COMPort.Name = "cbb_COMPort";
            this.cbb_COMPort.Size = new System.Drawing.Size(315, 21);
            this.cbb_COMPort.TabIndex = 9;
            // 
            // frmCauHinhMayIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 189);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCauHinhMayIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẤU HÌNH MÁY IN";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoPhieu;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbb_COMPort;
    }
}