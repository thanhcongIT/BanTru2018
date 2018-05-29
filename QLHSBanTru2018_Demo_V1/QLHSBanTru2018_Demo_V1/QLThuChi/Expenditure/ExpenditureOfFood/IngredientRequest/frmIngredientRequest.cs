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
                grcYeuCau.DataSource = dt.listIngredienRequesByDate(dtNgayMua.Value);               
            }
            else
            {
                grcYeuCau.DataSource = dt.listIngredienRequesByCreatedDate(dtNgayKhoiTao.Value);             
            }

        }
        public void LoadIngredienRequestDetail(int InredientRequestID)
        {
            TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();   
            dt.listInredientRequestDetail1(InredientRequestID);
            grcChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
        }
        public void LoadIngredienRequesDetailBought(int InredientRequestID)
        {
            TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();
            dt.listInredientRequestDetail2(InredientRequestID);
            grcDaMua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
        }
        private void UsYeuCau_Load(object sender, EventArgs e)
        {
            try
            {
                LoadIngredienRequestByDate();
                LoadIngredienRequestDetail((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                LoadIngredienRequesDetailBought((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
            }
            catch
            {

                
            }
        }

        private void btnXuatYeuCau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +grYeuCau.FocusedRowHandle + "");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                IngredienRequesID = (int)grYeuCau.GetRowCellValue(e.FocusedRowHandle, "IngredientRequestID");
                LoadIngredienRequestDetail(IngredienRequesID);
                LoadIngredienRequesDetailBought(IngredienRequesID);
                //laod thông tin yêu cầu
                EmployeeDAO dt = new EmployeeDAO();
                TCIngredientRequestDAO.employeeReques = dt.GetByID((int)grYeuCau.GetRowCellValue(e.FocusedRowHandle, "CreatedBy"));
                txtNguoiYeuCau.Text = TCIngredientRequestDAO.employeeReques.FirstName +" "+ TCIngredientRequestDAO.employeeReques.LastName;
                dtYeuCau.EditValue = grYeuCau.GetRowCellValue(e.FocusedRowHandle, "Date");
                dtKhoiTao.EditValue = grYeuCau.GetRowCellValue(e.FocusedRowHandle, "CreatedDate");
                txtGhiChu.Text = grYeuCau.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
            }
            catch 
            {

                
            }
        }
        private void btnNguoiYeuCau_Click(object sender, EventArgs e)
        {
            if (txtNguoiYeuCau.Text!="")
            {
                TcFrNhanVien a = new TcFrNhanVien();
                a.ShowDialog();
            }
        }
        private void btnMua_Click(object sender, EventArgs e)
        {
                int a1 = grChiTietYeuCau.SelectedRowsCount;
                int[] a = grChiTietYeuCau.GetSelectedRows();
                for (int i = 0; i < a1; i++)
                {
                    TCIngredientRequestDetaiViewModle b = new TCIngredientRequestDetaiViewModle();
                    //IngredientRequestDetail b = new IngredientRequestDetail();
                    b.IngredientRequestID = IngredienRequesID;
                    b.IngredientID = (int)grChiTietYeuCau.GetRowCellValue(a[i], grChiTietYeuCau.Columns["IngredientID"]);
                    b.Quantity = (double)grChiTietYeuCau.GetRowCellValue(a[i], grChiTietYeuCau.Columns["Quantity"]);
                    b.Name = grChiTietYeuCau.GetRowCellValue(a[i], grChiTietYeuCau.Columns["Name"]).ToString();
                    b.Status = (bool)grChiTietYeuCau.GetRowCellValue(a[i], grChiTietYeuCau.Columns["Status"]);
                    b.Unit = grChiTietYeuCau.GetRowCellValue(a[i], grChiTietYeuCau.Columns["Unit"]).ToString();
                    TCIngredientRequestDetailDAO.ListInredientReques2.Add(b);
                    TCIngredientRequestDetailDAO.ListInredientReques.RemoveAt(a[i]);
                    for (int j = i + 1; j <= a1 - 1; j++)
                    {
                        a[j] += -1;
                    }
                }   
                grcDaMua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                grDaMua.RefreshData();
                grChiTietYeuCau.RefreshData();
        }

        private void btnHuyMua_Click(object sender, EventArgs e)
        {
            int a1 = grDaMua.SelectedRowsCount;
            int[] a = grDaMua.GetSelectedRows();
            for (int i = 0; i < a1; i++)
            {
                if ((bool)grDaMua.GetRowCellValue(a[i], grDaMua.Columns["Status"])==false)
                {
                    TCIngredientRequestDetaiViewModle b = new TCIngredientRequestDetaiViewModle();
                    b.IngredientRequestID = IngredienRequesID;
                    b.IngredientID = (int)grDaMua.GetRowCellValue(a[i], grDaMua.Columns["IngredientID"]);
                    b.Quantity = (double)grDaMua.GetRowCellValue(a[i], grDaMua.Columns["Quantity"]);
                    b.Name = grDaMua.GetRowCellValue(a[i], grDaMua.Columns["Name"]).ToString();
                    b.Status = (bool)grDaMua.GetRowCellValue(a[i], grDaMua.Columns["Status"]);
                    b.Unit = grDaMua.GetRowCellValue(a[i], grDaMua.Columns["Unit"]).ToString();
                    TCIngredientRequestDetailDAO.ListInredientReques.Add(b);
                    TCIngredientRequestDetailDAO.ListInredientReques2.RemoveAt(a[i]);
                    for (int j = i + 1; j <= a1 - 1; j++)
                    {
                        a[j] += -1;
                    }
                }              
            }
            grcChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
            grDaMua.RefreshData();
            grChiTietYeuCau.RefreshData();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

            if (grDaMua.RowCount!=0)
            {
                for (int i = 0; i < grDaMua.RowCount; i++)
                {
                    if ((bool)grDaMua.GetRowCellValue(i,grDaMua.Columns["Status"])==false)
                    {
                        break;
                    }
                    if (i==grDaMua.RowCount-1)
                    {
                        return;
                    }
                }
                try
                {
                    OrderDetailDAO dt = new OrderDetailDAO();
                    TCIngredientRequestDetailDAO dc = new TCIngredientRequestDetailDAO();
                    OrderDetailDAO.ListTCOrderDetailViewModle.Clear();
                    for (int i = 0; i < grDaMua.RowCount; i++)
                    {
                        if ((bool)grDaMua.GetRowCellValue(i,grDaMua.Columns["Status"])==false)
                        {
                            OrderDetail a = new OrderDetail();
                            TCOrderDetailViewModle b = new TCOrderDetailViewModle();
                            a.IngredientID = (int)grDaMua.GetRowCellValue(i, grDaMua.Columns["IngredientID"]);
                            a.QuantityOfUnit = (double)grDaMua.GetRowCellValue(i, grDaMua.Columns["Quantity"]);
                            b = dt.OrderDetailViewModle(a);
                            OrderDetailDAO.ListTCOrderDetailViewModle.Add(b);
                        }
                        
                    }
                    FrThanhToanThucPham c = new FrThanhToanThucPham();
                    c.ShowDialog();
                    if (OrderDetailDAO.ThanhToan== true)
                    {
                        for (int i = 0; i < grDaMua.RowCount; i++)
                        {
                            if ((bool)grDaMua.GetRowCellValue(i, grDaMua.Columns["Status"]) == false)
                            {
                                //loại bỏ yêu cầu khi đã thực hiện
                                IngredientRequestDetail a1 = new IngredientRequestDetail();
                                a1.IngredientID = (int)grDaMua.GetRowCellValue(i, grDaMua.Columns["IngredientID"]);
                                a1.IngredientRequestID = IngredienRequesID;
                                a1.Status = true;
                                dc.Edit(a1);
                            }

                        }
                        LoadIngredienRequesDetailBought(IngredienRequesID);
                    }
                    
                    
                    //nếu hoàn thành yêu cầu
                    if ((bool)grDaMua.GetRowCellValue((grDaMua.RowCount - 1), grDaMua.Columns["Status"]) == true&&grChiTietYeuCau.RowCount==0)
                    {
                        IngredientRequest a2 = new IngredientRequest();
                        a2.IngredientRequestID = IngredienRequesID;
                        a2.Status = true;
                        if (new TCIngredientRequestDAO().Edit(a2)==true)
                        {
                            MessageBox.Show("Đã hoàn thành yêu cầu");
                        }
                        else
                        {
                            MessageBox.Show("Chưa hoàn thành yêu cầu");
                        }
                    }


                }
                catch
                {


                }
            }
           
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            EmployeeDAO dt = new EmployeeDAO();
            Employee a = dt.GetByID((int)grYeuCau.GetRowCellValue(e.ListSourceRowIndex, "CreatedBy"));
            if (e.Column.FieldName != "NvYeuCau") return;
            e.Value = a.FirstName+" "+a.LastName;

        }

        private void cbNgayMua_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                
                dtNgayKhoiTao.Enabled = false;
                dtNgayMua.Enabled = true;
                LoadIngredienRequestByDate();
                if (grYeuCau.RowCount == 0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grcChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grcDaMua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    grDaMua.RefreshData();
                    grChiTietYeuCau.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                }                          
            }
            catch
            {


            }
        }
        private void cbNgayTao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtNgayMua.Enabled = false;
                dtNgayKhoiTao.Enabled = true;
                LoadIngredienRequestByDate();
                if (grYeuCau.RowCount == 0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grcChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grcDaMua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    grDaMua.RefreshData();
                    grChiTietYeuCau.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                }         
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
                if (grYeuCau.RowCount==0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grcChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grcDaMua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    grDaMua.RefreshData();
                    grChiTietYeuCau.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                }          
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
                if (grYeuCau.RowCount == 0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grcChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grcDaMua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    grDaMua.RefreshData();
                    grChiTietYeuCau.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)grYeuCau.GetRowCellValue(grYeuCau.FocusedRowHandle, "IngredientRequestID"));
                }
                
            }
            catch
            {


            }
        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "TinhTrang") return;
            if ((bool)grDaMua.GetRowCellValue(e.ListSourceRowIndex,"Status")==true)
            {
                e.Value = "Hoàn thành";
            }
            else
            {
                e.Value = "Chua Hoàn thành";
            }
            
        }
    }
}
