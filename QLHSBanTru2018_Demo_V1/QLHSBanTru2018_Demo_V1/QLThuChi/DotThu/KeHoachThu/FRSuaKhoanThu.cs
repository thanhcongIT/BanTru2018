using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DataConnect;
using DataConnect.DAO.ThanhCongTC;
using QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu;


namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    public partial class FRSuaKhoanThu : DevExpress.XtraEditors.XtraForm
    {
        public FRSuaKhoanThu()
        {
            InitializeComponent();
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void loadKhoanthu()
        {
            StudenGrade dt = new StudenGrade();
            txtTenKhoanThu.Text = ReceivableDetailDAO.DemoReceibavleDetail.Name;
            txtMucThu.Text = ReceivableDetailDAO.DemoReceibavleDetail.Price.ToString();
            txtTanso.Text = ReceivableDetailDAO.DemoReceibavleDetail.Frequency.ToString();
            cbbDonViThoiGian.Text = ReceivableDetailDAO.DemoReceibavleDetail.TimeUnits;
            txtDv.Text = cbbDonViThoiGian.Text;
            txtTongthu.Text = ReceivableDetailDAO.DemoReceibavleDetail.TotalPriceDetail.ToString();
            cbHoanLai.Checked = (bool)ReceivableDetailDAO.DemoReceibavleDetail.Feedback;
            int a = (int)ReceivableDetailDAO.DemoReceibavleDetail.GradeID;
            cbbKhoihoc.Text = dt.lookforGrade(a).Name;
            if (ReceivableDetailDAO.DemoReceibavleDetail.PreferredID=="")
            {
                cbDoituongchinhsach.Checked = true;
            }
            
        }
        public void loadHocKy()
        {
            SemesterDAO dt = new SemesterDAO();
            cbbKyhoc.DataSource = dt.ListSemester();
            cbbKyhoc.ValueMember = "SemesterID";
            cbbKyhoc.DisplayMember = "Name";
        }
        public void loadKhoi()
        {
            GradeDAO dt = new GradeDAO();
            cbbKhoihoc.DataSource = dt.listGrade(int.Parse(cbbKyhoc.SelectedValue.ToString()));
            cbbKhoihoc.ValueMember = "GradeID";
            cbbKhoihoc.DisplayMember = "Name";
        }
        private void FRSuaKhoanThu_Load(object sender, EventArgs e)
        {
            loadKhoanthu();
            loadHocKy();
            loadKhoi();
        }

        private void bntDoituongchinhsach_Click(object sender, EventArgs e)
        {
            FrDoiTuongchinhsach a = new FrDoiTuongchinhsach();
            a.ShowDialog();
        }

        private void cbDoituongchinhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (bntDoituongchinhsach.Enabled == false)
            {
                bntDoituongchinhsach.Enabled = true;
            }
            else
            {
                bntDoituongchinhsach.Enabled = false;
            }
        }

        private void txtMucThu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal a = new decimal();
                a = decimal.Parse(txtMucThu.Text) * int.Parse(txtTanso.Text);
                txtTongthu.Text = a.ToString();
            }
            catch
            {


            }
        }

        private void txtTanso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal a = new decimal();
                a = decimal.Parse(txtMucThu.Text) * int.Parse(txtTanso.Text);
                txtTongthu.Text = a.ToString();
            }
            catch
            {


            }
        }

        private void txtMucThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTanso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbDonViThoiGian_TextChanged(object sender, EventArgs e)
        {
            txtDv.Text = cbbDonViThoiGian.Text;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
           
            try
            {
                ReceivableDetailDAO.ListDemoReceivableDetail.RemoveAt(studentReceivableDAO.TherowFocust);
                ReceivableDetail a = new ReceivableDetail();
                a.Name = txtTenKhoanThu.Text;
                a.Price = decimal.Parse(txtMucThu.Text);
                a.Status = true;
                a.TimeUnits = cbbDonViThoiGian.Text;
                a.Frequency = int.Parse(txtTanso.Text);
                a.TotalPriceDetail = decimal.Parse(txtTongthu.Text);
                a.GradeID = (int)cbbKhoihoc.SelectedValue;
                a.Feedback = cbHoanLai.Checked == true ? true : false;
                if (cbDoituongchinhsach.Checked == true)
                {
                    a.PreferredID = PreferredDAO.PreferredIDList;
                }
                else
                {
                    a.PreferredID = "";
                }
                ReceivableDetailDAO.ListDemoReceivableDetail.Add(a);
                
                this.Close();
            }
            catch
            {


            }
        }
    }
}