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

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu
{
    public partial class FrChiTietHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public FrChiTietHoaDon()
        {
            InitializeComponent();
        }
        #region hàm đính kèm
        public void TinhThanhTien()
        {
            txtThanhtien.Text = (decimal.Parse(txtDongia.Text) * (int)nudSoluong.Value).ToString();
        }
        #endregion
        private void FrChiTietHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            InvoiceDetail dt = new InvoiceDetail();
            dt.NameInvoiceDetail = txtTenchitiet.Text;
            dt.Price = decimal.Parse(txtDongia.Text);
            dt.Unit = txtDonvi.Text;
            dt.Amount = (int)nudSoluong.Value;
            dt.TotalPriceDetail = decimal.Parse(txtThanhtien.Text);
            dt.Note = txtGhichu.Text;
            dt.Status = false;
            InvoiceDetailDAO.listDemoInvoiceDetail.Add(dt);
            this.Close();
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void nudSoluong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }
    }
}