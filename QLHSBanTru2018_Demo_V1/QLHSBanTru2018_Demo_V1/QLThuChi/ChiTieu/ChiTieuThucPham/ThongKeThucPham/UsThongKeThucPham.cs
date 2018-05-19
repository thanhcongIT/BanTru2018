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
        public void LoadDanhSachThucPham(int IngredientTypeID)
        {
            IngredientDAO dt = new IngredientDAO();
            grDanhSachThucPham.DataSource = dt.ListAllActive(IngredientTypeID);
        }
        public void LoadThongKeThucPham(int IngredientID,DateTime Date)
        {
            StatisticalDAO dt = new StatisticalDAO();
            grThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModelByDay(IngredientID, Date);
        }
        private void UsThongKeThucPham_Load(object sender, EventArgs e)
        {
            LoadLoaiThucPham();
            LoadDanhSachThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientTypeID"));
            LoadThongKeThucPham((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDanhSachThucPham((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "IngredientTypeID"));
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            groupControl2.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
            LoadThongKeThucPham((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
            MessageBox.Show("" + (int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IngredientID") + "");
        }

        private void dtTheoNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadThongKeThucPham((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
        }
    }
}
