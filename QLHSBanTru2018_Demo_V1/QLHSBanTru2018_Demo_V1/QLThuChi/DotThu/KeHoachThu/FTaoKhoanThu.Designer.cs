namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    partial class FTaoKhoanThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTaoKhoanThu));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenKhoanThu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMucThu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbDonViThoiGian = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTanso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bntDoituongchinhsach = new DevExpress.XtraEditors.SimpleButton();
            this.cbDoituongchinhsach = new DevExpress.XtraEditors.CheckEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbNamhoc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbKhoihoc = new System.Windows.Forms.ComboBox();
            this.txtTongthu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDv = new System.Windows.Forms.TextBox();
            this.cbHoanLai = new System.Windows.Forms.CheckBox();
            this.bntHuy = new DevExpress.XtraEditors.SimpleButton();
            this.bntLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoituongchinhsach.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khoản thu";
            // 
            // txtTenKhoanThu
            // 
            this.txtTenKhoanThu.Location = new System.Drawing.Point(94, 12);
            this.txtTenKhoanThu.Name = "txtTenKhoanThu";
            this.txtTenKhoanThu.Size = new System.Drawing.Size(228, 21);
            this.txtTenKhoanThu.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mức thu";
            // 
            // txtMucThu
            // 
            this.txtMucThu.Location = new System.Drawing.Point(94, 38);
            this.txtMucThu.Name = "txtMucThu";
            this.txtMucThu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMucThu.Size = new System.Drawing.Size(100, 21);
            this.txtMucThu.TabIndex = 14;
            this.txtMucThu.Text = "0";
            this.txtMucThu.TextChanged += new System.EventHandler(this.txtMucThu_TextChanged);
            this.txtMucThu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMucThu_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "/";
            // 
            // cbbDonViThoiGian
            // 
            this.cbbDonViThoiGian.FormattingEnabled = true;
            this.cbbDonViThoiGian.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Học kỳ",
            "Năm"});
            this.cbbDonViThoiGian.Location = new System.Drawing.Point(222, 38);
            this.cbbDonViThoiGian.Name = "cbbDonViThoiGian";
            this.cbbDonViThoiGian.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbDonViThoiGian.Size = new System.Drawing.Size(100, 21);
            this.cbbDonViThoiGian.TabIndex = 20;
            this.cbbDonViThoiGian.Text = "Ngày";
            this.cbbDonViThoiGian.TextChanged += new System.EventHandler(this.cbbDonViThoiGian_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 10);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // txtTanso
            // 
            this.txtTanso.Location = new System.Drawing.Point(94, 65);
            this.txtTanso.Name = "txtTanso";
            this.txtTanso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTanso.Size = new System.Drawing.Size(100, 21);
            this.txtTanso.TabIndex = 29;
            this.txtTanso.Text = "1";
            this.txtTanso.TextChanged += new System.EventHandler(this.txtTanso_TextChanged);
            this.txtTanso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTanso_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Số ngày";
            // 
            // bntDoituongchinhsach
            // 
            this.bntDoituongchinhsach.Enabled = false;
            this.bntDoituongchinhsach.Location = new System.Drawing.Point(94, 194);
            this.bntDoituongchinhsach.Name = "bntDoituongchinhsach";
            this.bntDoituongchinhsach.Size = new System.Drawing.Size(228, 23);
            this.bntDoituongchinhsach.TabIndex = 43;
            this.bntDoituongchinhsach.Text = "Đối tượng chính sách";
            this.bntDoituongchinhsach.Click += new System.EventHandler(this.bntDoituongchinhsach_Click);
            // 
            // cbDoituongchinhsach
            // 
            this.cbDoituongchinhsach.Location = new System.Drawing.Point(15, 196);
            this.cbDoituongchinhsach.Name = "cbDoituongchinhsach";
            this.cbDoituongchinhsach.Properties.Caption = "Áp dụng";
            this.cbDoituongchinhsach.Size = new System.Drawing.Size(75, 19);
            this.cbDoituongchinhsach.TabIndex = 42;
            this.cbDoituongchinhsach.CheckedChanged += new System.EventHandler(this.cbDoituongchinhsach_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Năm học";
            // 
            // cbbNamhoc
            // 
            this.cbbNamhoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNamhoc.FormattingEnabled = true;
            this.cbbNamhoc.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Học kỳ",
            "Năm"});
            this.cbbNamhoc.Location = new System.Drawing.Point(94, 144);
            this.cbbNamhoc.Name = "cbbNamhoc";
            this.cbbNamhoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbNamhoc.Size = new System.Drawing.Size(228, 21);
            this.cbbNamhoc.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Khối";
            // 
            // cbbKhoihoc
            // 
            this.cbbKhoihoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoihoc.FormattingEnabled = true;
            this.cbbKhoihoc.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Học kỳ",
            "Năm"});
            this.cbbKhoihoc.Location = new System.Drawing.Point(94, 168);
            this.cbbKhoihoc.Name = "cbbKhoihoc";
            this.cbbKhoihoc.Size = new System.Drawing.Size(228, 21);
            this.cbbKhoihoc.TabIndex = 38;
            // 
            // txtTongthu
            // 
            this.txtTongthu.Enabled = false;
            this.txtTongthu.Location = new System.Drawing.Point(94, 92);
            this.txtTongthu.Name = "txtTongthu";
            this.txtTongthu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTongthu.Size = new System.Drawing.Size(228, 21);
            this.txtTongthu.TabIndex = 44;
            this.txtTongthu.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tổng thu";
            // 
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(222, 65);
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(100, 21);
            this.txtDv.TabIndex = 46;
            this.txtDv.Text = "Ngày";
            // 
            // cbHoanLai
            // 
            this.cbHoanLai.AutoSize = true;
            this.cbHoanLai.Location = new System.Drawing.Point(94, 120);
            this.cbHoanLai.Name = "cbHoanLai";
            this.cbHoanLai.Size = new System.Drawing.Size(148, 17);
            this.cbHoanLai.TabIndex = 47;
            this.cbHoanLai.Text = "Hoàn lại những ngày nghỉ";
            this.cbHoanLai.UseVisualStyleBackColor = true;
            // 
            // bntHuy
            // 
            this.bntHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntHuy.ImageOptions.Image")));
            this.bntHuy.Location = new System.Drawing.Point(247, 240);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(75, 23);
            this.bntHuy.TabIndex = 4;
            this.bntHuy.Text = "Hủy";
            this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
            // 
            // bntLuu
            // 
            this.bntLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntLuu.ImageOptions.Image")));
            this.bntLuu.Location = new System.Drawing.Point(157, 240);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(75, 23);
            this.bntLuu.TabIndex = 2;
            this.bntLuu.Text = "Lưu";
            this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
            // 
            // FTaoKhoanThu
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 267);
            this.Controls.Add(this.cbHoanLai);
            this.Controls.Add(this.txtDv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTongthu);
            this.Controls.Add(this.bntDoituongchinhsach);
            this.Controls.Add(this.cbDoituongchinhsach);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbNamhoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbKhoihoc);
            this.Controls.Add(this.txtTanso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbbDonViThoiGian);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMucThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bntHuy);
            this.Controls.Add(this.bntLuu);
            this.Controls.Add(this.txtTenKhoanThu);
            this.Controls.Add(this.label1);
            this.Name = "FTaoKhoanThu";
            this.Text = "Tạo khoản thu";
            this.Load += new System.EventHandler(this.FTaoKhoanThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbDoituongchinhsach.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenKhoanThu;
        private DevExpress.XtraEditors.SimpleButton bntLuu;
        private DevExpress.XtraEditors.SimpleButton bntHuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMucThu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbDonViThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTanso;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton bntDoituongchinhsach;
        private DevExpress.XtraEditors.CheckEdit cbDoituongchinhsach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbNamhoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbKhoihoc;
        private System.Windows.Forms.TextBox txtTongthu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDv;
        private System.Windows.Forms.CheckBox cbHoanLai;
    }
}