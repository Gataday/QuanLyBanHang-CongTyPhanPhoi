namespace QuanLyBanHang
{
    partial class frmThemPTT
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMaNCC = new System.Windows.Forms.ComboBox();
            this.lbMaNCC = new System.Windows.Forms.Label();
            this.lbVAT = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.txtPayMT = new System.Windows.Forms.TextBox();
            this.lbPayMT = new System.Windows.Forms.Label();
            this.dtpNgayTT = new System.Windows.Forms.DateTimePicker();
            this.lbNgayTT = new System.Windows.Forms.Label();
            this.txtSoPTT = new System.Windows.Forms.TextBox();
            this.lbSoPTT = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbMaNV = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.cbMaNV);
            this.panel1.Controls.Add(this.lbMaNV);
            this.panel1.Controls.Add(this.cbMaNCC);
            this.panel1.Controls.Add(this.lbMaNCC);
            this.panel1.Controls.Add(this.lbVAT);
            this.panel1.Controls.Add(this.txtVAT);
            this.panel1.Controls.Add(this.txtPayMT);
            this.panel1.Controls.Add(this.lbPayMT);
            this.panel1.Controls.Add(this.dtpNgayTT);
            this.panel1.Controls.Add(this.lbNgayTT);
            this.panel1.Controls.Add(this.txtSoPTT);
            this.panel1.Controls.Add(this.lbSoPTT);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 360);
            this.panel1.TabIndex = 1;
            // 
            // cbMaNCC
            // 
            this.cbMaNCC.FormattingEnabled = true;
            this.cbMaNCC.Location = new System.Drawing.Point(573, 204);
            this.cbMaNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaNCC.Name = "cbMaNCC";
            this.cbMaNCC.Size = new System.Drawing.Size(112, 24);
            this.cbMaNCC.TabIndex = 12;
            // 
            // lbMaNCC
            // 
            this.lbMaNCC.AutoSize = true;
            this.lbMaNCC.Location = new System.Drawing.Point(570, 166);
            this.lbMaNCC.Name = "lbMaNCC";
            this.lbMaNCC.Size = new System.Drawing.Size(57, 16);
            this.lbMaNCC.TabIndex = 11;
            this.lbMaNCC.Text = "Mã NCC";
            // 
            // lbVAT
            // 
            this.lbVAT.AutoSize = true;
            this.lbVAT.Location = new System.Drawing.Point(204, 166);
            this.lbVAT.Name = "lbVAT";
            this.lbVAT.Size = new System.Drawing.Size(34, 16);
            this.lbVAT.TabIndex = 10;
            this.lbVAT.Text = "VAT";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(207, 206);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(112, 22);
            this.txtVAT.TabIndex = 7;
            // 
            // txtPayMT
            // 
            this.txtPayMT.Location = new System.Drawing.Point(36, 206);
            this.txtPayMT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPayMT.Name = "txtPayMT";
            this.txtPayMT.Size = new System.Drawing.Size(112, 22);
            this.txtPayMT.TabIndex = 6;
            // 
            // lbPayMT
            // 
            this.lbPayMT.AutoSize = true;
            this.lbPayMT.Location = new System.Drawing.Point(33, 166);
            this.lbPayMT.Name = "lbPayMT";
            this.lbPayMT.Size = new System.Drawing.Size(79, 16);
            this.lbPayMT.TabIndex = 5;
            this.lbPayMT.Text = "Pay Method";
            // 
            // dtpNgayTT
            // 
            this.dtpNgayTT.Location = new System.Drawing.Point(381, 65);
            this.dtpNgayTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayTT.Name = "dtpNgayTT";
            this.dtpNgayTT.Size = new System.Drawing.Size(178, 22);
            this.dtpNgayTT.TabIndex = 4;
            // 
            // lbNgayTT
            // 
            this.lbNgayTT.AutoSize = true;
            this.lbNgayTT.Location = new System.Drawing.Point(378, 36);
            this.lbNgayTT.Name = "lbNgayTT";
            this.lbNgayTT.Size = new System.Drawing.Size(104, 16);
            this.lbNgayTT.TabIndex = 3;
            this.lbNgayTT.Text = "Ngày thanh toán";
            // 
            // txtSoPTT
            // 
            this.txtSoPTT.Location = new System.Drawing.Point(36, 65);
            this.txtSoPTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoPTT.Name = "txtSoPTT";
            this.txtSoPTT.Size = new System.Drawing.Size(112, 22);
            this.txtSoPTT.TabIndex = 2;
            // 
            // lbSoPTT
            // 
            this.lbSoPTT.AutoSize = true;
            this.lbSoPTT.Location = new System.Drawing.Point(33, 36);
            this.lbSoPTT.Name = "lbSoPTT";
            this.lbSoPTT.Size = new System.Drawing.Size(54, 16);
            this.lbSoPTT.TabIndex = 1;
            this.lbSoPTT.Text = "Số PTT";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bnSubmit);
            this.panel2.Controls.Add(this.bnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 280);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 80);
            this.panel2.TabIndex = 0;
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
            // lbMaNV
            // 
            this.lbMaNV.AutoSize = true;
            this.lbMaNV.Location = new System.Drawing.Point(204, 36);
            this.lbMaNV.Name = "lbMaNV";
            this.lbMaNV.Size = new System.Drawing.Size(48, 16);
            this.lbMaNV.TabIndex = 13;
            this.lbMaNV.Text = "Mã NV";
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(207, 63);
            this.cbMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(112, 24);
            this.cbMaNV.TabIndex = 14;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(381, 206);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(112, 22);
            this.txtTongTien.TabIndex = 15;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(378, 166);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(63, 16);
            this.lbTongTien.TabIndex = 16;
            this.lbTongTien.Text = "Tổng tiền";
            // 
            // frmThemPTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.panel1);
            this.Name = "frmThemPTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phiếu thanh toán";
            this.Load += new System.EventHandler(this.frmThemPTT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMaNCC;
        private System.Windows.Forms.Label lbMaNCC;
        private System.Windows.Forms.Label lbVAT;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.TextBox txtPayMT;
        private System.Windows.Forms.Label lbPayMT;
        private System.Windows.Forms.DateTimePicker dtpNgayTT;
        private System.Windows.Forms.Label lbNgayTT;
        private System.Windows.Forms.TextBox txtSoPTT;
        private System.Windows.Forms.Label lbSoPTT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bnSubmit;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}