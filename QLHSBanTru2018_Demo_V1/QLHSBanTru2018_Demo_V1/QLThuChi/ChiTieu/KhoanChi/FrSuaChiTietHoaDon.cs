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
using DataConnect;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu
{
    public partial class FrSuaChiTietHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public FrSuaChiTietHoaDon()
        {
            InitializeComponent();
        }
        #region hàm đính kèm
        public void TinhThanhTien()
        {
            txtThanhtien.Text = (decimal.Parse(txtDongia.Text) * (int)nudSoluong.Value).ToString();
        }
        #endregion

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenchitiet_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void nudSoluong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void FrSuaChiTietHoaDon_Load(object sender, EventArgs e)
        {
            txtTenchitiet.Text = InvoiceDetailDAO.DemoInvoiceDetail.NameInvoiceDetail;
            txtDongia.Text = InvoiceDetailDAO.DemoInvoiceDetail.Price.ToString();
            txtDonvi.Text = InvoiceDetailDAO.DemoInvoiceDetail.Unit;
            nudSoluong.Value = (int)InvoiceDetailDAO.DemoInvoiceDetail.Amount;
            txtThanhtien.Text = InvoiceDetailDAO.DemoInvoiceDetail.TotalPriceDetail.ToString();
            txtGhichu.Text = InvoiceDetailDAO.DemoInvoiceDetail.Note;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            InvoiceDetailDAO.listDemoInvoiceDetail.RemoveAt(InvoiceDetailDAO.Therowfocust);
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
    }
}