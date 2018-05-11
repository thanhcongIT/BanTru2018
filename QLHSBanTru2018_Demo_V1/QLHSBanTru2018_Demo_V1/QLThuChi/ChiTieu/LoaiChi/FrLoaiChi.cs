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
                grCacLoaiChi.DataSource = dt.ListSpendSpecy();
            }
            catch 
            {

               
            }
        }
        #endregion
        private void btnThem_Click(object sender, EventArgs e)
        {
            FrThemLoaiChi a = new FrThemLoaiChi();
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
                SpendSpeciesDAO.spend.SpendSpeciesID = (int)gridView1.GetRowCellValue(e.FocusedRowHandle, "SpendSpeciesID");
                SpendSpeciesDAO.spend.Name = gridView1.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
                SpendSpeciesDAO.spend.CreatedDate = (DateTime)gridView1.GetRowCellValue(e.FocusedRowHandle, "CreatedDate");
                SpendSpeciesDAO.spend.Note = gridView1.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
                SpendSpeciesDAO.spend.Status = (bool)gridView1.GetRowCellValue(e.FocusedRowHandle, "Status");
            }
            catch 
            {

                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrSuaLoaiChi a = new FrSuaLoaiChi();
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
    }
}