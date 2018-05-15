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
using DataConnect;
using DataConnect.DAO.ThanhCongTC.TCViewModle;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class UsYeuCau : DevExpress.XtraEditors.XtraUserControl
    {
        public UsYeuCau()
        {
            InitializeComponent();
        }
        public static int IngredienRequesID = new int();
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
            grChiTietYeuCau.DataSource = dt.listInredientRequestDetail1(InredientRequestID);
        }
        public void LoadIngredienRequesDetailBought(int InredientRequestID)
        {
            TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();
            grDamua.DataSource = dt.listInredientRequestDetail2(InredientRequestID);
        }
        private void UsYeuCau_Load(object sender, EventArgs e)
        {
            try
            {
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                LoadIngredienRequesDetailBought((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
            }
            catch
            {

                
            }
        }

        private void cbNgayMua_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbNgayTao.Checked = false;
                dtNgayKhoiTao.Enabled = false;
                dtNgayMua.Enabled = true;
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                LoadIngredienRequesDetailBought(IngredienRequesID);
            }
            catch 
            {

               
            }
        }

        private void cbNgayTao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbNgayMua.Checked = false;
                dtNgayMua.Enabled = false;
                dtNgayKhoiTao.Enabled = true;
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                LoadIngredienRequesDetailBought(IngredienRequesID);
            }
            catch 
            {

              
            }
        }

        private void btnXuatYeuCau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +gridView1.FocusedRowHandle + "");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                IngredienRequesID = (int)gridView1.GetRowCellValue(e.FocusedRowHandle, "IngredientRequestID");
                LoadIngredienRequestDetail(IngredienRequesID);
                LoadIngredienRequesDetailBought(IngredienRequesID);
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
            try
            {
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail(IngredienRequesID);
                LoadIngredienRequesDetailBought(IngredienRequesID);
            }
            catch
            {

                
            }
        }

        private void dtNgayKhoiTao_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail(IngredienRequesID);
                LoadIngredienRequesDetailBought(IngredienRequesID);
            }
            catch 
            {

                throw;
            }
        }

        private void btnNguoiYeuCau_Click(object sender, EventArgs e)
        {
            TcFrNhanVien a = new TcFrNhanVien();
            a.ShowDialog();
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IngredientDAO dt = new IngredientDAO();
            TCIngredientRequestDAO.Ingredient = dt.GetByID((int)gridView2.GetRowCellValue(e.FocusedRowHandle, "IngredientID"));
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            try
            {
                TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if ((bool)gridView2.GetRowCellValue(i,gridView2.Columns["Status"])==true)
                    {
                        IngredientRequestDetail a = new IngredientRequestDetail();
                        a.IngredientRequestID= IngredienRequesID;
                        a.IngredientID = (int)gridView2.GetRowCellValue(i, gridView2.Columns["IngredientID"]);
                        a.Status = true;
                        if (dt.Edit(a)==true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Lỗi bản ghi thữ " + i + "");
                            break;
                        }
                    }
                }
                LoadIngredienRequesDetailBought(IngredienRequesID);
                LoadIngredienRequestDetail(IngredienRequesID);
            }
            catch 
            {

                
            }
        }

        private void btnHuyMua_Click(object sender, EventArgs e)
        {
            try
            {
                TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    if ((bool)gridView3.GetRowCellValue(i, gridView3.Columns["Status"]) == false)
                    {
                        IngredientRequestDetail a = new IngredientRequestDetail();
                        a.IngredientRequestID = IngredienRequesID;
                        a.IngredientID = (int)gridView3.GetRowCellValue(i, gridView3.Columns["IngredientID"]);
                        a.Status = false;
                        if (dt.Edit(a) == true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Lỗi bản ghi thữ " + i + "");
                            break;
                        }
                    }
                }
                LoadIngredienRequestDetail(IngredienRequesID);
                LoadIngredienRequesDetailBought(IngredienRequesID);
            }
            catch
            {


            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDetailDAO dt = new OrderDetailDAO();
                OrderDetailDAO.ListTCOrderDetailViewModle.Clear();
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    OrderDetail a = new OrderDetail();
                    TCOrderDetailViewModle b = new TCOrderDetailViewModle();
                    a.IngredientID = (int)gridView3.GetRowCellValue(i, gridView3.Columns["IngredientID"]);
                    a.QuantityOfUnit = (double)gridView3.GetRowCellValue(i, gridView3.Columns["Quantity"]);
                    b = dt.OrderDetailViewModle(a);
                    OrderDetailDAO.ListTCOrderDetailViewModle.Add(b);
                }
                FrThanhToanThucPham c = new FrThanhToanThucPham();
                c.ShowDialog();
            }
            catch 
            {

              
            }
        }
    }
}
