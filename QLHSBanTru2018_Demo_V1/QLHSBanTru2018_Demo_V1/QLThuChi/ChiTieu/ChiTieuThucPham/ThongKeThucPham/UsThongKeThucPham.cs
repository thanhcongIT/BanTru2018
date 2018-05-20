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
using DataConnect.DAO.HungTD;
using DataConnect.DAO.ThanhCongTC.ChiTieuThucPham;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham.ThongKeThucPham
{
    public partial class UsThongKeThucPham : DevExpress.XtraEditors.XtraUserControl
    {
        public UsThongKeThucPham()
        {
            InitializeComponent();
        }
        public void LoadLoaiThucPham()
        {
            IngredientTypeDAO dt = new IngredientTypeDAO();
            grLoaiThucPham.DataSource = dt.ListAll();
        }
        public void loadLoaiTP()
        {
            IngredientTypeDAO dt = new IngredientTypeDAO();
            cbbLoaithucPham.DataSource = dt.ListAll();
            cbbLoaithucPham.ValueMember = "IngredientTypeID";
            cbbLoaithucPham.DisplayMember = "Name";
        }
        public void LoadDanhSachThucPham(int IngredientTypeID)
        {
            IngredientDAO dt = new IngredientDAO();
            grLoaiThucPham.DataSource = dt.ListAllActive(IngredientTypeID);
        }
        public void LoadThongKeThucPham(int IngredientID,DateTime Date)
        {
            StatisticalDAO dt = new StatisticalDAO();
            grThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModelByDay(IngredientID, Date);
        }
        public void TinhTong()
        {
            decimal TongTien = 0;
            double TongSoLuong = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                TongTien += (decimal)gridView3.GetRowCellValue(i, "TotalPrice");
                TongSoLuong += (double)gridView3.GetRowCellValue(i, "QuantityOfUnit");
            }
            txtSoLuong.Text = TongSoLuong.ToString();
            txtTongTien.Text = TongTien.ToString();
        }
        private void UsThongKeThucPham_Load(object sender, EventArgs e)
        {
            loadLoaiTP();
            cbbLoaithucPham_SelectedIndexChanged(sender, e);
            LoadDanhSachThucPham((int)cbbLoaithucPham.SelectedValue);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadThongKeThucPham((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
            TinhTong();
        }
        private void dtTheoNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
            TinhTong();           
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //MessageBox.Show("" + gridView3.GetRowCellValue(e.FocusedRowHandle, "QuantityOfUnit") + "");
        }

        private void cbTheoNgay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbTheoThang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbTheoNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbbLoaithucPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = (int)cbbLoaithucPham.SelectedValue;
                LoadDanhSachThucPham(a);
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch 
            {

                
            }
        }
    }
}
