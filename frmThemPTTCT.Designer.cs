namespace QuanLyBanHang
{
    partial class frmThemPTTCT
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
            this.lbThanhTien = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.lbMaHang = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbSoPTT = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPTTCT = new System.Windows.Forms.ComboBox();
            this.cbMH = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbThanhTien
            // 
            this.lbThanhTien.AutoSize = true;
            this.lbThanhTien.Location = new System.Drawing.Point(230, 208);
            this.lbThanhTien.Name = "lbThanhTien";
            this.lbThanhTien.Size = new System.Drawing.Size(88, 20);
            this.lbThanhTien.TabIndex = 16;
            this.lbThanhTien.Text = "Thành Tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(233, 258);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(126, 26);
            this.txtThanhTien.TabIndex = 15;
            // 
            // lbMaHang
            // 
            this.lbMaHang.AutoSize = true;
            this.lbMaHang.Location = new System.Drawing.Point(230, 45);
            this.lbMaHang.Name = "lbMaHang";
            this.lbMaHang.Size = new System.Drawing.Size(74, 20);
            this.lbMaHang.TabIndex = 13;
            this.lbMaHang.Text = "Mã Hàng";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Location = new System.Drawing.Point(37, 208);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(78, 20);
            this.lbSoLuong.TabIndex = 10;
            this.lbSoLuong.Text = "Số Lượng";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(40, 258);
            this.txtSL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(126, 26);
            this.txtSL.TabIndex = 7;
            // 
            // bnCancel
            // 
            this.bnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnCancel.Location = new System.Drawing.Point(40, 39);
            this.bnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(92, 32);
            this.bnCancel.TabIndex = 0;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = false;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // lbSoPTT
            // 
            this.lbSoPTT.AutoSize = true;
            this.lbSoPTT.Location = new System.Drawing.Point(37, 45);
            this.lbSoPTT.Name = "lbSoPTT";
            this.lbSoPTT.Size = new System.Drawing.Size(61, 20);
            this.lbSoPTT.TabIndex = 1;
            this.lbSoPTT.Text = "Số PTT";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bnSubmit);
            this.panel2.Controls.Add(this.bnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // bnSubmit
            // 
            this.bnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.bnSubmit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnSubmit.Location = new System.Drawing.Point(233, 39);
            this.bnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnSubmit.Name = "bnSubmit";
            this.bnSubmit.Size = new System.Drawing.Size(92, 32);
            this.bnSubmit.TabIndex = 1;
            this.bnSubmit.Text = "Submit";
            this.bnSubmit.UseVisualStyleBackColor = false;
            this.bnSubmit.Click += new System.EventHandler(this.bnSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPTTCT);
            this.panel1.Controls.Add(this.cbMH);
            this.panel1.Controls.Add(this.lbThanhTien);
            this.panel1.Controls.Add(this.txtThanhTien);
            this.panel1.Controls.Add(this.lbMaHang);
            this.panel1.Controls.Add(this.lbSoLuong);
            this.panel1.Controls.Add(this.txtSL);
            this.panel1.Controls.Add(this.lbSoPTT);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbPTTCT
            // 
            this.cbPTTCT.FormattingEnabled = true;
            this.cbPTTCT.Location = new System.Drawing.Point(30, 79);
            this.cbPTTCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPTTCT.Name = "cbPTTCT";
            this.cbPTTCT.Size = new System.Drawing.Size(136, 28);
            this.cbPTTCT.TabIndex = 18;
            // 
            // cbMH
            // 
            this.cbMH.FormattingEnabled = true;
            this.cbMH.Location = new System.Drawing.Point(233, 79);
            this.cbMH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMH.Name = "cbMH";
            this.cbMH.Size = new System.Drawing.Size(136, 28);
            this.cbMH.TabIndex = 17;
            this.cbMH.SelectedIndexChanged += new System.EventHandler(this.cbMH_SelectedIndexChanged);
            // 
            // frmThemPTTCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmThemPTTCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phiếu thanh toán chi tiết";
            this.Load += new System.EventHandler(this.frmThemPTTCT_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label lbMaHang;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbSoPTT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bnSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMH;
        private System.Windows.Forms.ComboBox cbPTTCT;
    }
}