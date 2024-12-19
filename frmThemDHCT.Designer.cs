namespace QuanLyBanHang
{
    partial class frmThemDHCT
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
            this.cbMDH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.cbMH = new System.Windows.Forms.ComboBox();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.lbLyDo = new System.Windows.Forms.Label();
            this.txtMDH = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bnSubmit = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMDH);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSL);
            this.panel1.Controls.Add(this.cbMH);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.txtTT);
            this.panel1.Controls.Add(this.lbLyDo);
            this.panel1.Controls.Add(this.txtMDH);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 2;
            // 
            // cbMDH
            // 
            this.cbMDH.FormattingEnabled = true;
            this.cbMDH.Location = new System.Drawing.Point(41, 81);
            this.cbMDH.Name = "cbMDH";
            this.cbMDH.Size = new System.Drawing.Size(126, 28);
            this.cbMDH.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Số Lượng";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(259, 81);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(126, 26);
            this.txtSL.TabIndex = 14;
            // 
            // cbMH
            // 
            this.cbMH.FormattingEnabled = true;
            this.cbMH.Location = new System.Drawing.Point(41, 255);
            this.cbMH.Name = "cbMH";
            this.cbMH.Size = new System.Drawing.Size(126, 28);
            this.cbMH.TabIndex = 13;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(37, 208);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(74, 20);
            this.lbTongTien.TabIndex = 10;
            this.lbTongTien.Text = "Mã Hàng";
            // 
            // txtTT
            // 
            this.txtTT.Location = new System.Drawing.Point(509, 81);
            this.txtTT.Name = "txtTT";
            this.txtTT.Size = new System.Drawing.Size(126, 26);
            this.txtTT.TabIndex = 6;
            // 
            // lbLyDo
            // 
            this.lbLyDo.AutoSize = true;
            this.lbLyDo.Location = new System.Drawing.Point(505, 45);
            this.lbLyDo.Name = "lbLyDo";
            this.lbLyDo.Size = new System.Drawing.Size(88, 20);
            this.lbLyDo.TabIndex = 5;
            this.lbLyDo.Text = "Thành Tiền";
            // 
            // txtMDH
            // 
            this.txtMDH.AutoSize = true;
            this.txtMDH.Location = new System.Drawing.Point(37, 45);
            this.txtMDH.Name = "txtMDH";
            this.txtMDH.Size = new System.Drawing.Size(108, 20);
            this.txtMDH.TabIndex = 1;
            this.txtMDH.Text = "Mã Đơn Hàng";
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
            // frmThemDHCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmThemDHCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn hàng chi tiết";
            this.Load += new System.EventHandler(this.ThemDHCT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMH;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.TextBox txtTT;
        private System.Windows.Forms.Label lbLyDo;
        private System.Windows.Forms.Label txtMDH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bnSubmit;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.ComboBox cbMDH;
    }
}