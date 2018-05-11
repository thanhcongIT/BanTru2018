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
using DataConnect;
using DataConnect.DAO.ThanhCongTC.ChiTieu;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.LoaiChi
{
    public partial class FrThemLoaiChi : DevExpress.XtraEditors.XtraForm
    {
        public FrThemLoaiChi()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SpendSpeciesDAO dt = new SpendSpeciesDAO();
            SpendSpecy a = new SpendSpecy();
            a.Name = txtTenDanhMuc.Text;
            a.CreatedDate = DateTime.Now;
            a.Note = txtGhichu.Text;
            if (dt.Insert(a)==true)
            {
                MessageBox.Show("Lưu thành công");
                //btnThoat.PerformClick();
                this.Close();
            }
        }

        private void FrThemLoaiChi_Load(object sender, EventArgs e)
        {
            dtNgayKhoiTao.EditValue = DateTime.Now;
        }
    }
}