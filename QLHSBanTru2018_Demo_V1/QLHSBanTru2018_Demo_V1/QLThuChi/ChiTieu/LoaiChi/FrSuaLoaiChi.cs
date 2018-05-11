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
using DataConnect.DAO.ThanhCongTC.ChiTieu;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.LoaiChi
{
    public partial class FrSuaLoaiChi : DevExpress.XtraEditors.XtraForm
    {
        public FrSuaLoaiChi()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrSuaLoaiChi_Load(object sender, EventArgs e)
        {
            txtTenDanhMuc.Text = SpendSpeciesDAO.spend.Name;
            dtNgayKhoiTao.EditValue = SpendSpeciesDAO.spend.CreatedDate;
            txtGhichu.Text = SpendSpeciesDAO.spend.Note;
            if (SpendSpeciesDAO.spend.Status==true)
            {
                cbTinhtrang.Checked = true;
            }
            else
            {
                cbTinhtrang.Checked = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SpendSpeciesDAO dt = new SpendSpeciesDAO();
            SpendSpeciesDAO.spend.Name = txtTenDanhMuc.Text;
            SpendSpeciesDAO.spend.Note = txtGhichu.Text;
            if (cbTinhtrang.Checked == true)
            {
                SpendSpeciesDAO.spend.Status = true;

            }
            else
            {
                SpendSpeciesDAO.spend.Status = false;
            }
            if (dt.Edit(SpendSpeciesDAO.spend)==true)
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu không thành công");
            }
            this.Close();
        }
        public void tinhtrang()
        {
            if (cbTinhtrang.Checked == true)
            {
                cbTinhtrang.Text = "Đang hoạt động";
            }
            else
            {
                cbTinhtrang.Text = "Không hoạt động";
            }
        }
        private void cbTinhtrang_CheckedChanged(object sender, EventArgs e)
        {
            tinhtrang();
        }
    }
}