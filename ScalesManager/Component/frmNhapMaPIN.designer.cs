namespace ScalesManager.Component
{
    partial class frmNhapMaPIN
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtMaPIN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 15);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(81, 28);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Mã PIN";
            // 
            // txtMaPIN
            // 
            // 
            // 
            // 
            this.txtMaPIN.Border.Class = "TextBoxBorder";
            this.txtMaPIN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaPIN.Location = new System.Drawing.Point(107, 18);
            this.txtMaPIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaPIN.Name = "txtMaPIN";
            this.txtMaPIN.PasswordChar = '●';
            this.txtMaPIN.Size = new System.Drawing.Size(179, 22);
            this.txtMaPIN.TabIndex = 2;
            this.txtMaPIN.WatermarkText = "Mã PIN";
            this.txtMaPIN.Enter += new System.EventHandler(this.txtMaPIN_Enter);
            this.txtMaPIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaPIN_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(107, 48);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmNhapMaPIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 84);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtMaPIN);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNhapMaPIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHẬP MÃ PIN";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPIN;
        private DevComponents.DotNetBar.ButtonX btnOK;
    }
}