using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataConnect.DAO.ThanhCongTC.ChiTieuThucPham;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class UsChiThucPham : DevExpress.XtraEditors.XtraUserControl
    {
        public UsChiThucPham()
        {
            InitializeComponent();
        }

        private void UsChiThucPham_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }
        public void LoadOrder()
        {
            OrderDAO dt = new OrderDAO();
            if (cbTheoNgay.Checked==true)
            {
                grPhieuChi.DataSource = dt.ListOrderByDay(dtTheoNgay.Value);
            }
            else
            {
                grPhieuChi.DataSource = dt.listOrderByMonth(dtTheoThang.Value);
            }
        }

        private void cbTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtTheoThang.Enabled = false;
            dtTheoNgay.Enabled = true;
        }

        private void cbTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            dtTheoNgay.Enabled = false;
            dtTheoThang.Enabled = true;
        }

        private void dtTheoNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dtTheoThang_ValueChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
