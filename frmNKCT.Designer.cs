﻿namespace QuanLyBanHang
{
    partial class frmNKCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNKCT));
            this.FooterPXK = new System.Windows.Forms.Panel();
            this.bnDelete = new System.Windows.Forms.Button();
            this.bnEdit = new System.Windows.Forms.Button();
            this.bnCreate = new System.Windows.Forms.Button();
            this.HeaderPXK = new System.Windows.Forms.Panel();
            this.bnSearch = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.bnClear = new System.Windows.Forms.Button();
            this.cbPNKCT = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.quảnLýĐặtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhậpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýXuấtKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đặtHàngChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtKhoChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DSPhieuNKCT = new System.Windows.Forms.DataGridView();
            this.FooterPXK.SuspendLayout();
            this.HeaderPXK.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSPhieuNKCT)).BeginInit();
            this.SuspendLayout();
            // 
            // FooterPXK
            // 
            this.FooterPXK.Controls.Add(this.bnDelete);
            this.FooterPXK.Controls.Add(this.bnEdit);
            this.FooterPXK.Controls.Add(this.bnCreate);
            this.FooterPXK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPXK.Location = new System.Drawing.Point(0, 392);
            this.FooterPXK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FooterPXK.Name = "FooterPXK";
            this.FooterPXK.Size = new System.Drawing.Size(800, 58);
            this.FooterPXK.TabIndex = 8;
            // 
            // bnDelete
            // 
            this.bnDelete.BackColor = System.Drawing.Color.Crimson;
            this.bnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnDelete.Location = new System.Drawing.Point(252, 14);
            this.bnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnDelete.Name = "bnDelete";
            this.bnDelete.Size = new System.Drawing.Size(75, 31);
            this.bnDelete.TabIndex = 2;
            this.bnDelete.Text = "Delete";
            this.bnDelete.UseVisualStyleBackColor = false;
            this.bnDelete.Click += new System.EventHandler(this.bnDelete_Click);
            // 
            // bnEdit
            // 
            this.bnEdit.BackColor = System.Drawing.Color.ForestGreen;
            this.bnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnEdit.Location = new System.Drawing.Point(150, 14);
            this.bnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnEdit.Name = "bnEdit";
            this.bnEdit.Size = new System.Drawing.Size(75, 31);
            this.bnEdit.TabIndex = 1;
            this.bnEdit.Text = "Edit";
            this.bnEdit.UseVisualStyleBackColor = false;
            this.bnEdit.Click += new System.EventHandler(this.bnEdit_Click);
            // 
            // bnCreate
            // 
            this.bnCreate.BackColor = System.Drawing.Color.ForestGreen;
            this.bnCreate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnCreate.Location = new System.Drawing.Point(52, 14);
            this.bnCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnCreate.Name = "bnCreate";
            this.bnCreate.Size = new System.Drawing.Size(75, 31);
            this.bnCreate.TabIndex = 0;
            this.bnCreate.Text = "Create";
            this.bnCreate.UseVisualStyleBackColor = false;
            this.bnCreate.Click += new System.EventHandler(this.bnCreate_Click);
            // 
            // HeaderPXK
            // 
            this.HeaderPXK.Controls.Add(this.bnSearch);
            this.HeaderPXK.Controls.Add(this.txtTimKiem);
            this.HeaderPXK.Controls.Add(this.bnClear);
            this.HeaderPXK.Controls.Add(this.cbPNKCT);
            this.HeaderPXK.Controls.Add(this.toolStrip1);
            this.HeaderPXK.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPXK.Location = new System.Drawing.Point(0, 0);
            this.HeaderPXK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HeaderPXK.Name = "HeaderPXK";
            this.HeaderPXK.Size = new System.Drawing.Size(800, 62);
            this.HeaderPXK.TabIndex = 7;
            // 
            // bnSearch
            // 
            this.bnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.bnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnSearch.Location = new System.Drawing.Point(511, 21);
            this.bnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(107, 32);
            this.bnSearch.TabIndex = 5;
            this.bnSearch.Text = "Search";
            this.bnSearch.UseVisualStyleBackColor = false;
            this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click_1);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(227, 24);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(260, 26);
            this.txtTimKiem.TabIndex = 2;
            // 
            // bnClear
            // 
            this.bnClear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bnClear.Location = new System.Drawing.Point(640, 22);
            this.bnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnClear.Name = "bnClear";
            this.bnClear.Size = new System.Drawing.Size(107, 31);
            this.bnClear.TabIndex = 0;
            this.bnClear.Text = "Clear";
            this.bnClear.UseVisualStyleBackColor = false;
            this.bnClear.Click += new System.EventHandler(this.bnClear_Click);
            // 
            // cbPNKCT
            // 
            this.cbPNKCT.Location = new System.Drawing.Point(66, 21);
            this.cbPNKCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPNKCT.Name = "cbPNKCT";
            this.cbPNKCT.Size = new System.Drawing.Size(136, 28);
            this.cbPNKCT.TabIndex = 4;
            this.cbPNKCT.SelectedIndexChanged += new System.EventHandler(this.cbPNKCT_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýĐặtHàngToolStripMenuItem,
            this.quảnLýHàngHóaToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýKhoToolStripMenuItem,
            this.quảnLýNhàCungCấpToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýNhậpKhoToolStripMenuItem,
            this.quảnLýThanhToánToolStripMenuItem,
            this.quảnLýXuấtKhoToolStripMenuItem,
            this.đặtHàngChiTiếtToolStripMenuItem,
            this.nhậpKhoChiTiếtToolStripMenuItem,
            this.xuấtKhoChiTiếtToolStripMenuItem,
            this.thanhToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(42, 28);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // quảnLýĐặtHàngToolStripMenuItem
            // 
            this.quảnLýĐặtHàngToolStripMenuItem.Name = "quảnLýĐặtHàngToolStripMenuItem";
            this.quảnLýĐặtHàngToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýĐặtHàngToolStripMenuItem.Text = "Quản lý đặt hàng";
            this.quảnLýĐặtHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐặtHàngToolStripMenuItem_Click);
            // 
            // quảnLýHàngHóaToolStripMenuItem
            // 
            this.quảnLýHàngHóaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hàngHóaNhậpToolStripMenuItem,
            this.hàngHóaXuấtToolStripMenuItem});
            this.quảnLýHàngHóaToolStripMenuItem.Name = "quảnLýHàngHóaToolStripMenuItem";
            this.quảnLýHàngHóaToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýHàngHóaToolStripMenuItem.Text = "Quản lý hàng hóa";
            // 
            // hàngHóaNhậpToolStripMenuItem
            // 
            this.hàngHóaNhậpToolStripMenuItem.Name = "hàngHóaNhậpToolStripMenuItem";
            this.hàngHóaNhậpToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.hàngHóaNhậpToolStripMenuItem.Text = "Hàng hóa nhập";
            this.hàngHóaNhậpToolStripMenuItem.Click += new System.EventHandler(this.hàngHóaNhậpToolStripMenuItem_Click);
            // 
            // hàngHóaXuấtToolStripMenuItem
            // 
            this.hàngHóaXuấtToolStripMenuItem.Name = "hàngHóaXuấtToolStripMenuItem";
            this.hàngHóaXuấtToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.hàngHóaXuấtToolStripMenuItem.Text = "Hàng hóa xuất";
            this.hàngHóaXuấtToolStripMenuItem.Click += new System.EventHandler(this.hàngHóaXuấtToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýKhoToolStripMenuItem
            // 
            this.quảnLýKhoToolStripMenuItem.Name = "quảnLýKhoToolStripMenuItem";
            this.quảnLýKhoToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýKhoToolStripMenuItem.Text = "Quản lý kho";
            this.quảnLýKhoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKhoToolStripMenuItem_Click);
            // 
            // quảnLýNhàCungCấpToolStripMenuItem
            // 
            this.quảnLýNhàCungCấpToolStripMenuItem.Name = "quảnLýNhàCungCấpToolStripMenuItem";
            this.quảnLýNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýNhàCungCấpToolStripMenuItem.Text = "Quản lý nhà cung cấp";
            this.quảnLýNhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhàCungCấpToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýNhậpKhoToolStripMenuItem
            // 
            this.quảnLýNhậpKhoToolStripMenuItem.Name = "quảnLýNhậpKhoToolStripMenuItem";
            this.quảnLýNhậpKhoToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýNhậpKhoToolStripMenuItem.Text = "Quản lý nhập kho";
            this.quảnLýNhậpKhoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhậpKhoToolStripMenuItem_Click);
            // 
            // quảnLýThanhToánToolStripMenuItem
            // 
            this.quảnLýThanhToánToolStripMenuItem.Name = "quảnLýThanhToánToolStripMenuItem";
            this.quảnLýThanhToánToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýThanhToánToolStripMenuItem.Text = "Quản lý thanh toán";
            this.quảnLýThanhToánToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThanhToánToolStripMenuItem_Click);
            // 
            // quảnLýXuấtKhoToolStripMenuItem
            // 
            this.quảnLýXuấtKhoToolStripMenuItem.Name = "quảnLýXuấtKhoToolStripMenuItem";
            this.quảnLýXuấtKhoToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.quảnLýXuấtKhoToolStripMenuItem.Text = "Quản lý xuất kho";
            this.quảnLýXuấtKhoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýXuấtKhoToolStripMenuItem_Click);
            // 
            // đặtHàngChiTiếtToolStripMenuItem
            // 
            this.đặtHàngChiTiếtToolStripMenuItem.Name = "đặtHàngChiTiếtToolStripMenuItem";
            this.đặtHàngChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.đặtHàngChiTiếtToolStripMenuItem.Text = "Đặt hàng chi tiết";
            this.đặtHàngChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.đặtHàngChiTiếtToolStripMenuItem_Click);
            // 
            // nhậpKhoChiTiếtToolStripMenuItem
            // 
            this.nhậpKhoChiTiếtToolStripMenuItem.Name = "nhậpKhoChiTiếtToolStripMenuItem";
            this.nhậpKhoChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.nhậpKhoChiTiếtToolStripMenuItem.Text = "Nhập kho chi tiết";
            this.nhậpKhoChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.nhậpKhoChiTiếtToolStripMenuItem_Click);
            // 
            // xuấtKhoChiTiếtToolStripMenuItem
            // 
            this.xuấtKhoChiTiếtToolStripMenuItem.Name = "xuấtKhoChiTiếtToolStripMenuItem";
            this.xuấtKhoChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.xuấtKhoChiTiếtToolStripMenuItem.Text = "Xuất kho chi tiết";
            this.xuấtKhoChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.xuấtKhoChiTiếtToolStripMenuItem_Click);
            // 
            // thanhToolStripMenuItem
            // 
            this.thanhToolStripMenuItem.Name = "thanhToolStripMenuItem";
            this.thanhToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.thanhToolStripMenuItem.Text = "Thanh toán chi tiết";
            this.thanhToolStripMenuItem.Click += new System.EventHandler(this.thanhToolStripMenuItem_Click);
            // 
            // DSPhieuNKCT
            // 
            this.DSPhieuNKCT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DSPhieuNKCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DSPhieuNKCT.Location = new System.Drawing.Point(0, 59);
            this.DSPhieuNKCT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DSPhieuNKCT.Name = "DSPhieuNKCT";
            this.DSPhieuNKCT.RowHeadersWidth = 62;
            this.DSPhieuNKCT.RowTemplate.Height = 28;
            this.DSPhieuNKCT.Size = new System.Drawing.Size(820, 509);
            this.DSPhieuNKCT.TabIndex = 6;
            // 
            // frmNKCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FooterPXK);
            this.Controls.Add(this.HeaderPXK);
            this.Controls.Add(this.DSPhieuNKCT);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNKCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhập kho chi tiết";
            this.Load += new System.EventHandler(this.frmNKCT_Load);
            this.FooterPXK.ResumeLayout(false);
            this.HeaderPXK.ResumeLayout(false);
            this.HeaderPXK.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSPhieuNKCT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FooterPXK;
        private System.Windows.Forms.Button bnDelete;
        private System.Windows.Forms.Button bnEdit;
        private System.Windows.Forms.Button bnCreate;
        private System.Windows.Forms.Panel HeaderPXK;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button bnClear;
        private System.Windows.Forms.ComboBox cbPNKCT;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐặtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhậpKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýThanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýXuấtKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtKhoChiTiếtToolStripMenuItem;
        private System.Windows.Forms.DataGridView DSPhieuNKCT;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.ToolStripMenuItem đặtHàngChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToolStripMenuItem;
    }
}