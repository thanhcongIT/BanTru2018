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
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class UsYeuCau : DevExpress.XtraEditors.XtraUserControl
    {
        public UsYeuCau()
        {
            InitializeComponent();
        }
        public void LoadIngredienRequestByDate()
        {
            TCIngredientRequestDAO dt = new TCIngredientRequestDAO();
            if (cbNgayMua.Checked == true)
            {
                grYeuCau.DataSource = dt.listIngredienRequesByDate(dtNgayMua.Value);
            }
            else
            {
                grYeuCau.DataSource = dt.listIngredienRequesByCreatedDate(dtNgayKhoiTao.Value);
            }

        }
        public void LoadIngredienRequestDetail(int InredientRequestID)
        {
            TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();
            grChiTietYeuCau.DataSource = dt.listInredientRequestDetail(InredientRequestID);
        }
        private void UsYeuCau_Load(object sender, EventArgs e)
        {
            try
            {
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));

            }
            catch
            {

                
            }
        }

        private void cbNgayMua_CheckedChanged(object sender, EventArgs e)
        {
            cbNgayTao.Checked = false;
            dtNgayKhoiTao.Enabled = false;
            dtNgayMua.Enabled = true;
            LoadIngredienRequestByDate();
            LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
        }

        private void cbNgayTao_CheckedChanged(object sender, EventArgs e)
        {
            cbNgayMua.Checked = false;
            dtNgayMua.Enabled = false;
            dtNgayKhoiTao.Enabled = true;
            LoadIngredienRequestByDate();
            LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
        }

        private void btnXuatYeuCau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +gridView1.FocusedRowHandle + "");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "IngredientRequestID"));
                //laod thông tin yêu cầu
                EmployeeDAO dt = new EmployeeDAO();
                TCIngredientRequestDAO.employeeReques = dt.GetByID((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "CreatedBy"));
                txtNguoiYeuCau.Text = TCIngredientRequestDAO.employeeReques.FirstName +" "+ TCIngredientRequestDAO.employeeReques.LastName;
                dtYeuCau.EditValue = gridView1.GetRowCellValue(e.FocusedRowHandle, "Date");
                dtKhoiTao.EditValue = gridView1.GetRowCellValue(e.FocusedRowHandle, "CreatedDate");
                txtGhiChu.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
            }
            catch 
            {

                
            }
        }

        private void dtNgayMua_ValueChanged(object sender, EventArgs e)
        {
            LoadIngredienRequestByDate();
        }

        private void dtNgayKhoiTao_ValueChanged(object sender, EventArgs e)
        {
            LoadIngredienRequestByDate();
        }

        private void btnNguoiYeuCau_Click(object sender, EventArgs e)
        {
            TcFrNhanVien a = new TcFrNhanVien();
            a.ShowDialog();
        }
    }
}
