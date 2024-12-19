namespace QuanLyBanHang
{
    partial class frmEditHHNhap
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
            this.cbMH = new System.Windows.Forms.ComboBox();
            this.lbMaKho = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.txtDGN = new System.Windows.Forms.TextBox();
            this.txtTH = new System.Windows.Forms.TextBox();
            this.TH = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lbSoPXK = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnSave = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMH);
            this.panel1.Controls.Add(this.lbMaKho);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.txtDGN);
            this.panel1.Controls.Add(this.txtTH);
            this.panel1.Controls.Add(this.TH);
            this.panel1.Controls.Add(this.txtDVT);
            this.panel1.Controls.Add(this.lbSoPXK);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 3;
            // 
            // cbMH
            // 
            this.cbMH.FormattingEnabled = true;
            this.cbMH.Location = new System.Drawing.Point(41, 246);
            this.cbMH.Name = "cbMH";
            this.cbMH.Size = new System.Drawing.Size(126, 28);
            this.cbMH.TabIndex = 12;
            // 
            // lbMaKho
            // 
            this.lbMaKho.AutoSize = true;
            this.lbMaKho.Location = new System.Drawing.Point(247, 208);
            this.lbMaKho.Name = "lbMaKho";
            this.lbMaKho.Size = new System.Drawing.Size(110, 20);
            this.lbMaKho.TabIndex = 11;
            this.lbMaKho.Text = "Đơn Giá Nhập";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(37, 208);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(41, 20);
            this.lbTongTien.TabIndex = 10;
            this.lbTongTien.Text = "DVT";
            // 
            // txtDGN
            // 
            this.txtDGN.Location = new System.Drawing.Point(246, 248);
            this.txtDGN.Name = "txtDGN";
            this.txtDGN.Size = new System.Drawing.Size(126, 26);
            this.txtDGN.TabIndex = 7;
            // 
            // txtTH
            // 
            this.txtTH.Location = new System.Drawing.Point(246, 81);
            this.txtTH.Name = "txtTH";
            this.txtTH.Size = new System.Drawing.Size(126, 26);
            this.txtTH.TabIndex = 6;
            // 
            // TH
            // 
            this.TH.AutoSize = true;
            this.TH.Location = new System.Drawing.Point(247, 45);
            this.TH.Name = "TH";
            this.TH.Size = new System.Drawing.Size(79, 20);
            this.TH.TabIndex = 5;
            this.TH.Text = "Tên Hàng";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(41, 81);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(126, 26);
            this.txtDVT.TabIndex = 2;
            // 
            // lbSoPXK
            // 
            this.lbSoPXK.AutoSize = true;
            this.lbSoPXK.Location = new System.Drawing.Point(37, 45);
            this.lbSoPXK.Name = "lbSoPXK";
            this.lbSoPXK.Size = new System.Drawing.Size(74, 20);
            this.lbSoPXK.TabIndex = 1;
            this.lbSoPXK.Text = "Mã Hàng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bnSave);
            this.panel2.Controls.Add(this.bnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // bnSave
            // 
            this.bnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.bnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnSave.Location = new System.Drawing.Point(233, 39);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(92, 32);
            this.bnSave.TabIndex = 1;
            this.bnSave.Text = "Save";
            this.bnSave.UseVisualStyleBackColor = false;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnCancel
            // 
            this.bnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnCancel.Location = new System.Drawing.Point(41, 39);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(92, 32);
            this.bnCancel.TabIndex = 0;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // frmEditHHNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmEditHHNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa hàng hóa nhập";
            this.Load += new System.EventHandler(this.frmEditHHNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMH;
        private System.Windows.Forms.Label lbMaKho;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.TextBox txtDGN;
        private System.Windows.Forms.TextBox txtTH;
        private System.Windows.Forms.Label TH;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lbSoPXK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Button bnCancel;
    }
}