namespace QuanLyBanHang
{
    partial class frmEditKho
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lbThanhTien = new System.Windows.Forms.Label();
            this.lbSoPNK = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMaKho);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.lbThanhTien);
            this.panel2.Controls.Add(this.lbSoPNK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 293);
            this.panel2.TabIndex = 7;
            // 
            // txtMaKho
            // 
            this.txtMaKho.Location = new System.Drawing.Point(36, 65);
            this.txtMaKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(89, 22);
            this.txtMaKho.TabIndex = 10;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(36, 204);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(342, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // lbThanhTien
            // 
            this.lbThanhTien.AutoSize = true;
            this.lbThanhTien.Location = new System.Drawing.Point(33, 166);
            this.lbThanhTien.Name = "lbThanhTien";
            this.lbThanhTien.Size = new System.Drawing.Size(50, 16);
            this.lbThanhTien.TabIndex = 6;
            this.lbThanhTien.Text = "Địa chỉ ";
            // 
            // lbSoPNK
            // 
            this.lbSoPNK.AutoSize = true;
            this.lbSoPNK.Location = new System.Drawing.Point(33, 36);
            this.lbSoPNK.Name = "lbSoPNK";
            this.lbSoPNK.Size = new System.Drawing.Size(51, 16);
            this.lbSoPNK.TabIndex = 0;
            this.lbSoPNK.Text = "Mã kho";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bnSubmit);
            this.panel1.Controls.Add(this.bnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 293);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 67);
            this.panel1.TabIndex = 6;
            // 
            // bnSubmit
            // 
            this.bnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.bnSubmit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnSubmit.Location = new System.Drawing.Point(207, 31);
            this.bnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnSubmit.Name = "bnSubmit";
            this.bnSubmit.Size = new System.Drawing.Size(82, 26);
            this.bnSubmit.TabIndex = 1;
            this.bnSubmit.Text = "Submit";
            this.bnSubmit.UseVisualStyleBackColor = false;
            this.bnSubmit.Click += new System.EventHandler(this.bnSubmit_Click);
            // 
            // bnCancel
            // 
            this.bnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnCancel.Location = new System.Drawing.Point(36, 31);
            this.bnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(82, 26);
            this.bnCancel.TabIndex = 0;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // frmEditKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmEditKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa thông tin kho";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lbThanhTien;
        private System.Windows.Forms.Label lbSoPNK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bnSubmit;
        private System.Windows.Forms.Button bnCancel;
    }
}