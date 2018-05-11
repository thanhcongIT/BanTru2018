namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    partial class FRSuaKhoanThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRSuaKhoanThu));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.txtDv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongthu = new System.Windows.Forms.TextBox();
            this.bntDoituongchinhsach = new DevExpress.XtraEditors.SimpleButton();
            this.cbDoituongchinhsach = new DevExpress.XtraEditors.CheckEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbKyhoc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbKhoihoc = new System.Windows.Forms.ComboBox();
            this.txtTanso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbDonViThoiGian = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMucThu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenKhoanThu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(215, 57);
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(100, 21);
            this.txtDv.TabIndex = 66;
            this.txtDv.Text = "Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Tổng thu";
            // 
            // txtTongthu
            // 
            this.txtTongthu.Enabled = false;
            this.txtTongthu.Location = new System.Drawing.Point(87, 84);
            this.txtTongthu.Name = "txtTongthu";
            this.txtTongthu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTongthu.Size = new System.Drawing.Size(228, 21);
            this.txtTongthu.TabIndex = 64;
            this.txtTongthu.Text = "0";
            // 
            // bntDoituongchinhsach
            // 
            this.bntDoituongchinhsach.Enabled = false;
            this.bntDoituongchinhsach.Location = new System.Drawing.Point(87, 186);
            this.bntDoituongchinhsach.Name = "bntDoituongchinhsach";
            this.bntDoituongchinhsach.Size = new System.Drawing.Size(228, 23);
            this.bntDoituongchinhsach.TabIndex = 63;
            this.bntDoituongchinhsach.Text = "Đối tượng chính sách";
            this.bntDoituongchinhsach.Click += new System.EventHandler(this.bntDoituongchinhsach_Click);
            // 
            // cbDoituongchinhsach
            // 
            this.cbDoituongchinhsach.Location = new System.Drawing.Point(8, 188);
            this.cbDoituongchinhsach.Name = "cbDoituongchinhsach";
            this.cbDoituongchinhsach.Properties.Caption = "Áp dụng";
            this.cbDoituongchinhsach.Size = new System.Drawing.Size(75, 19);
            this.cbDoituongchinhsach.TabIndex = 62;
            this.cbDoituongchinhsach.CheckedChanged += new System.EventHandler(this.cbDoituongchinhsach_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Kỳ học";
            // 
            // cbbKyhoc
            // 
            this.cbbKyhoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKyhoc.FormattingEnabled = true;
            this.cbbKyhoc.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Học kỳ",
            "Năm"});
            this.cbbKyhoc.Location = new System.Drawing.Point(87, 136);
            this.cbbKyhoc.Name = "cbbKyhoc";
            this.cbbKyhoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbKyhoc.Size = new System.Drawing.Size(228, 21);
            this.cbbKyhoc.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 59;
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
            this.cbbKhoihoc.Location = new System.Drawing.Point(87, 160);
            this.cbbKhoihoc.Name = "cbbKhoihoc";
            this.cbbKhoihoc.Size = new System.Drawing.Size(228, 21);
            this.cbbKhoihoc.TabIndex = 58;
            // 
            // txtTanso
            // 
            this.txtTanso.Location = new System.Drawing.Point(87, 57);
            this.txtTanso.Name = "txtTanso";
            this.txtTanso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTanso.Size = new System.Drawing.Size(100, 21);
            this.txtTanso.TabIndex = 57;
            this.txtTanso.Text = "1";
            this.txtTanso.TextChanged += new System.EventHandler(this.txtTanso_TextChanged);
            this.txtTanso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTanso_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Số ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 10);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // cbbDonViThoiGian
            // 
            this.cbbDonViThoiGian.FormattingEnabled = true;
            this.cbbDonViThoiGian.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Học kỳ",
            "Năm"});
            this.cbbDonViThoiGian.Location = new System.Drawing.Point(215, 30);
            this.cbbDonViThoiGian.Name = "cbbDonViThoiGian";
            this.cbbDonViThoiGian.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbDonViThoiGian.Size = new System.Drawing.Size(100, 21);
            this.cbbDonViThoiGian.TabIndex = 54;
            this.cbbDonViThoiGian.Text = "Ngày";
            this.cbbDonViThoiGian.TextChanged += new System.EventHandler(this.cbbDonViThoiGian_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "/";
            // 
            // txtMucThu
            // 
            this.txtMucThu.Location = new System.Drawing.Point(87, 30);
            this.txtMucThu.Name = "txtMucThu";
            this.txtMucThu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMucThu.Size = new System.Drawing.Size(100, 21);
            this.txtMucThu.TabIndex = 52;
            this.txtMucThu.Text = "0";
            this.txtMucThu.TextChanged += new System.EventHandler(this.txtMucThu_TextChanged);
            this.txtMucThu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMucThu_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Mức thu";
            // 
            // txtTenKhoanThu
            // 
            this.txtTenKhoanThu.Location = new System.Drawing.Point(87, 4);
            this.txtTenKhoanThu.Name = "txtTenKhoanThu";
            this.txtTenKhoanThu.Size = new System.Drawing.Size(228, 21);
            this.txtTenKhoanThu.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Tên khoản thu";
            // 
            // cbHoanLai
            // 
            this.cbHoanLai.AutoSize = true;
            this.cbHoanLai.Location = new System.Drawing.Point(87, 113);
            this.cbHoanLai.Name = "cbHoanLai";
            this.cbHoanLai.Size = new System.Drawing.Size(148, 17);
            this.cbHoanLai.TabIndex = 67;
            this.cbHoanLai.Text = "Hoàn lại những ngày nghỉ";
            this.cbHoanLai.UseVisualStyleBackColor = true;
            // 
            // bntHuy
            // 
            this.bntHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntHuy.ImageOptions.Image")));
            this.bntHuy.Location = new System.Drawing.Point(240, 232);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(75, 23);
            this.bntHuy.TabIndex = 50;
            this.bntHuy.Text = "Hủy";
            this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
            // 
            // bntLuu
            // 
            this.bntLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntLuu.ImageOptions.Image")));
            this.bntLuu.Location = new System.Drawing.Point(150, 232);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(75, 23);
            this.bntLuu.TabIndex = 49;
            this.bntLuu.Text = "Lưu";
            this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
            // 
            // FRSuaKhoanThu
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 258);
            this.Controls.Add(this.cbHoanLai);
            this.Controls.Add(this.txtDv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTongthu);
            this.Controls.Add(this.bntDoituongchinhsach);
            this.Controls.Add(this.cbDoituongchinhsach);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbKyhoc);
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
            this.Name = "FRSuaKhoanThu";
            this.Text = "Sửa thông tin khoản thu";
            this.Load += new System.EventHandler(this.FRSuaKhoanThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbDoituongchinhsach.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.TextBox txtDv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongthu;
        private DevExpress.XtraEditors.SimpleButton bntDoituongchinhsach;
        private DevExpress.XtraEditors.CheckEdit cbDoituongchinhsach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbKyhoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbKhoihoc;
        private System.Windows.Forms.TextBox txtTanso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbDonViThoiGian;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMucThu;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton bntHuy;
        private DevExpress.XtraEditors.SimpleButton bntLuu;
        private System.Windows.Forms.TextBox txtTenKhoanThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbHoanLai;
    }
}