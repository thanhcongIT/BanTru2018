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
using QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.LoaiChi;
using DataConnect.DAO.ThanhCongTC.ChiTieu;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu
{
    public partial class FrLoaiChi : DevExpress.XtraEditors.XtraForm
    {
        public FrLoaiChi()
        {
            InitializeComponent();
        }
        #region hàm-------
        public void laodCacloaichi()
        {
            try
            {
                SpendSpeciesDAO dt = new SpendSpeciesDAO();
                grcCacLoaiChi.DataSource = dt.ListSpendSpecy();
            }
            catch 
            {

               
            }
        }
        #endregion
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAddSpendSpecy a = new frmAddSpendSpecy();
            a.ShowDialog();
            laodCacloaichi();
        }

        private void FrLoaiChi_Load(object sender, EventArgs e)
        {
            laodCacloaichi();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SpendSpeciesDAO.spend.SpendSpeciesID = (int)grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "SpendSpeciesID");
                SpendSpeciesDAO.spend.Name = grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
                SpendSpeciesDAO.spend.CreatedDate = (DateTime)grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "CreatedDate");
                SpendSpeciesDAO.spend.Note = grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
                SpendSpeciesDAO.spend.Status = (bool)grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "Status");
                txtGhiChu.Text = grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
                groupControl1.Text="Ghi chú"+" "+ grCacLoaiChi.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
            }
            catch 
            {

                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmEditSpendSpecy a = new frmEditSpendSpecy();
            a.ShowDialog();
            laodCacloaichi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SpendSpeciesDAO dt = new SpendSpeciesDAO();
            if (MessageBox.Show("Bạn có muốn xóa danh mục " + SpendSpeciesDAO.spend.Name + "","Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error)==DialogResult.Yes)
            {
                if (dt.Remove(SpendSpeciesDAO.spend)==true)
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Không thể xóa ");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "TinhTrang") return;
            if ((bool)grCacLoaiChi.GetRowCellValue(e.ListSourceRowIndex, "Status")==true)
            {
                e.Value = "Kích hoạt";
            }
            else
            {
                e.Value = "Khóa";
            }
           
        }
    }
}