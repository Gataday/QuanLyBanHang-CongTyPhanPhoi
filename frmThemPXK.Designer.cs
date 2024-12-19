namespace QuanLyBanHang
{
    partial class frmThemPXK
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
            this.cbMaKho = new System.Windows.Forms.ComboBox();
            this.lbMaKho = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lbLyDo = new System.Windows.Forms.Label();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.lbNgayXuat = new System.Windows.Forms.Label();
            this.txtSoPXK = new System.Windows.Forms.TextBox();
            this.lbSoPXK = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMaKho);
            this.panel1.Controls.Add(this.lbMaKho);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.txtLyDo);
            this.panel1.Controls.Add(this.lbLyDo);
            this.panel1.Controls.Add(this.dtpNgayXuat);
            this.panel1.Controls.Add(this.lbNgayXuat);
            this.panel1.Controls.Add(this.txtSoPXK);
            this.panel1.Controls.Add(this.lbSoPXK);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // cbMaKho
            // 
            this.cbMaKho.FormattingEnabled = true;
            this.cbMaKho.Location = new System.Drawing.Point(233, 255);
            this.cbMaKho.Name = "cbMaKho";
            this.cbMaKho.Size = new System.Drawing.Size(126, 28);
            this.cbMaKho.TabIndex = 12;
            this.cbMaKho.SelectedIndexChanged += new System.EventHandler(this.cbMaKho_SelectedIndexChanged);
            // 
            // lbMaKho
            // 
            this.lbMaKho.AutoSize = true;
            this.lbMaKho.Location = new System.Drawing.Point(233, 208);
            this.lbMaKho.Name = "lbMaKho";
            this.lbMaKho.Size = new System.Drawing.Size(61, 20);
            this.lbMaKho.TabIndex = 11;
            this.lbMaKho.Text = "Mã kho";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(37, 208);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(75, 20);
            this.lbTongTien.TabIndex = 10;
            this.lbTongTien.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(41, 255);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(126, 26);
            this.txtTongTien.TabIndex = 7;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(509, 81);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(126, 26);
            this.txtLyDo.TabIndex = 6;
            // 
            // lbLyDo
            // 
            this.lbLyDo.AutoSize = true;
            this.lbLyDo.Location = new System.Drawing.Point(505, 45);
            this.lbLyDo.Name = "lbLyDo";
            this.lbLyDo.Size = new System.Drawing.Size(47, 20);
            this.lbLyDo.TabIndex = 5;
            this.lbLyDo.Text = "Lý do";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Location = new System.Drawing.Point(233, 81);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(200, 26);
            this.dtpNgayXuat.TabIndex = 4;
            // 
            // lbNgayXuat
            // 
            this.lbNgayXuat.AutoSize = true;
            this.lbNgayXuat.Location = new System.Drawing.Point(229, 45);
            this.lbNgayXuat.Name = "lbNgayXuat";
            this.lbNgayXuat.Size = new System.Drawing.Size(79, 20);
            this.lbNgayXuat.TabIndex = 3;
            this.lbNgayXuat.Text = "Ngày xuất";
            // 
            // txtSoPXK
            // 
            this.txtSoPXK.Location = new System.Drawing.Point(41, 81);
            this.txtSoPXK.Name = "txtSoPXK";
            this.txtSoPXK.Size = new System.Drawing.Size(126, 26);
            this.txtSoPXK.TabIndex = 2;
            // 
            // lbSoPXK
            // 
            this.lbSoPXK.AutoSize = true;
            this.lbSoPXK.Location = new System.Drawing.Point(37, 45);
            this.lbSoPXK.Name = "lbSoPXK";
            this.lbSoPXK.Size = new System.Drawing.Size(64, 20);
            this.lbSoPXK.TabIndex = 1;
            this.lbSoPXK.Text = "Số PXK";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bnSubmit);
            this.panel2.Controls.Add(this.bnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // bnSubmit
            // 
            this.bnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.bnSubmit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnSubmit.Location = new System.Drawing.Point(233, 39);
            this.bnSubmit.Name = "bnSubmit";
            this.bnSubmit.Size = new System.Drawing.Size(92, 32);
            this.bnSubmit.TabIndex = 1;
            this.bnSubmit.Text = "Submit";
            this.bnSubmit.UseVisualStyleBackColor = false;
            this.bnSubmit.Click += new System.EventHandler(this.bnSubmit_Click);
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
            // frmThemPXK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmThemPXK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phiếu xuất kho";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lbLyDo;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.Label lbNgayXuat;
        private System.Windows.Forms.TextBox txtSoPXK;
        private System.Windows.Forms.Label lbSoPXK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label lbMaKho;
        private System.Windows.Forms.Button bnSubmit;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox cbMaKho;
    }
}