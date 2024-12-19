namespace QuanLyBanHang
{
    partial class frmThemPNK
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
            this.cbMaKho = new System.Windows.Forms.ComboBox();
            this.lbMaKho = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lbMaNCC = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lbNgayNhap = new System.Windows.Forms.Label();
            this.txtSoPNK = new System.Windows.Forms.TextBox();
            this.lbSoPNK = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMaNCC);
            this.panel1.Controls.Add(this.cbMaKho);
            this.panel1.Controls.Add(this.lbMaKho);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.lbMaNCC);
            this.panel1.Controls.Add(this.dtpNgayNhap);
            this.panel1.Controls.Add(this.lbNgayNhap);
            this.panel1.Controls.Add(this.txtSoPNK);
            this.panel1.Controls.Add(this.lbSoPNK);
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
            this.cbMaNCC.Location = new System.Drawing.Point(452, 65);
            this.cbMaNCC.Name = "cbMaNCC";
            this.cbMaNCC.Size = new System.Drawing.Size(121, 24);
            this.cbMaNCC.TabIndex = 0;
            this.cbMaNCC.SelectedIndexChanged += new System.EventHandler(this.cbMaNCC_SelectedIndexChanged);
            // 
            // cbMaKho
            // 
            this.cbMaKho.FormattingEnabled = true;
            this.cbMaKho.Location = new System.Drawing.Point(207, 204);
            this.cbMaKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaKho.Name = "cbMaKho";
            this.cbMaKho.Size = new System.Drawing.Size(112, 24);
            this.cbMaKho.TabIndex = 12;
            this.cbMaKho.SelectedIndexChanged += new System.EventHandler(this.cbMaKho_SelectedIndexChanged);
            // 
            // lbMaKho
            // 
            this.lbMaKho.AutoSize = true;
            this.lbMaKho.Location = new System.Drawing.Point(207, 166);
            this.lbMaKho.Name = "lbMaKho";
            this.lbMaKho.Size = new System.Drawing.Size(51, 16);
            this.lbMaKho.TabIndex = 11;
            this.lbMaKho.Text = "Mã kho";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(33, 166);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(63, 16);
            this.lbTongTien.TabIndex = 10;
            this.lbTongTien.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(36, 204);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(112, 22);
            this.txtTongTien.TabIndex = 7;
            // 
            // lbMaNCC
            // 
            this.lbMaNCC.AutoSize = true;
            this.lbMaNCC.Location = new System.Drawing.Point(449, 36);
            this.lbMaNCC.Name = "lbMaNCC";
            this.lbMaNCC.Size = new System.Drawing.Size(57, 16);
            this.lbMaNCC.TabIndex = 5;
            this.lbMaNCC.Text = "Mã NCC";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Location = new System.Drawing.Point(207, 65);
            this.dtpNgayNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(178, 22);
            this.dtpNgayNhap.TabIndex = 4;
            // 
            // lbNgayNhap
            // 
            this.lbNgayNhap.AutoSize = true;
            this.lbNgayNhap.Location = new System.Drawing.Point(204, 36);
            this.lbNgayNhap.Name = "lbNgayNhap";
            this.lbNgayNhap.Size = new System.Drawing.Size(73, 16);
            this.lbNgayNhap.TabIndex = 3;
            this.lbNgayNhap.Text = "Ngày nhập";
            // 
            // txtSoPNK
            // 
            this.txtSoPNK.Location = new System.Drawing.Point(36, 65);
            this.txtSoPNK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoPNK.Name = "txtSoPNK";
            this.txtSoPNK.Size = new System.Drawing.Size(112, 22);
            this.txtSoPNK.TabIndex = 2;
            // 
            // lbSoPNK
            // 
            this.lbSoPNK.AutoSize = true;
            this.lbSoPNK.Location = new System.Drawing.Point(33, 36);
            this.lbSoPNK.Name = "lbSoPNK";
            this.lbSoPNK.Size = new System.Drawing.Size(54, 16);
            this.lbSoPNK.TabIndex = 1;
            this.lbSoPNK.Text = "Số PNK";
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
            this.bnSubmit.TabIndex = 2;
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
            // frmThemPNK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.panel1);
            this.Name = "frmThemPNK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phiếu nhập kho";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMaKho;
        private System.Windows.Forms.Label lbMaKho;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lbMaNCC;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lbNgayNhap;
        private System.Windows.Forms.TextBox txtSoPNK;
        private System.Windows.Forms.Label lbSoPNK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox cbMaNCC;
        private System.Windows.Forms.Button bnSubmit;
    }
}