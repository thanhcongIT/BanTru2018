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
    public partial class FrViewInvoiceDetail : DevExpress.XtraEditors.XtraForm
    {
        public FrViewInvoiceDetail()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrViewInvoiceDetail_Load(object sender, EventArgs e)
        {
            try
            {
                txtTenChiTiet.Text = InvoiceDetailDAO.DemoInvoiceDetail.NameInvoiceDetail;
                txtDonGia.Text = InvoiceDetailDAO.DemoInvoiceDetail.Price.ToString();
                txtDonVi.Text = InvoiceDetailDAO.DemoInvoiceDetail.Unit.ToString();
                nbSoluong.Value = (int)InvoiceDetailDAO.DemoInvoiceDetail.Amount;
                txtThanhTien.Text = InvoiceDetailDAO.DemoInvoiceDetail.TotalPriceDetail.ToString();
                txtGhichu.Text = InvoiceDetailDAO.DemoInvoiceDetail.Note;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}