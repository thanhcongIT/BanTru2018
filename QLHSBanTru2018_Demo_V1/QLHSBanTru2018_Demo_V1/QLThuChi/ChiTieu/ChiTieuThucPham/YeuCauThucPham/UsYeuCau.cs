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
            dt.listInredientRequestDetail1(InredientRequestID);
            grChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
        }
        public void LoadIngredienRequesDetailBought(int InredientRequestID)
        {
            TCIngredientRequestDetailDAO dt = new TCIngredientRequestDetailDAO();
            dt.listInredientRequestDetail2(InredientRequestID);
            grDamua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
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
        private void btnNguoiYeuCau_Click(object sender, EventArgs e)
        {
            TcFrNhanVien a = new TcFrNhanVien();
            a.ShowDialog();
        }
        private void btnMua_Click(object sender, EventArgs e)
        {
                int a1 = gridView2.SelectedRowsCount;
                int[] a = gridView2.GetSelectedRows();
                for (int i = 0; i < a1; i++)
                {
                    TCIngredientRequestDetaiViewModle b = new TCIngredientRequestDetaiViewModle();
                    //IngredientRequestDetail b = new IngredientRequestDetail();
                    b.IngredientRequestID = IngredienRequesID;
                    b.IngredientID = (int)gridView2.GetRowCellValue(a[i], gridView2.Columns["IngredientID"]);
                    b.Quantity = (double)gridView2.GetRowCellValue(a[i], gridView2.Columns["Quantity"]);
                    b.Name = gridView2.GetRowCellValue(a[i], gridView2.Columns["Name"]).ToString();
                    b.Status = (bool)gridView2.GetRowCellValue(a[i], gridView2.Columns["Status"]);
                    b.Unit = gridView2.GetRowCellValue(a[i], gridView2.Columns["Unit"]).ToString();
                    TCIngredientRequestDetailDAO.ListInredientReques2.Add(b);
                    TCIngredientRequestDetailDAO.ListInredientReques.RemoveAt(a[i]);
                    for (int j = i + 1; j <= a1 - 1; j++)
                    {
                        a[j] += -1;
                    }
                }   
                grDamua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                gridView3.RefreshData();
                gridView2.RefreshData();
        }

        private void btnHuyMua_Click(object sender, EventArgs e)
        {
            int a1 = gridView3.SelectedRowsCount;
            int[] a = gridView3.GetSelectedRows();
            for (int i = 0; i < a1; i++)
            {
                if ((bool)gridView3.GetRowCellValue(a[i], gridView3.Columns["Status"])==false)
                {
                    TCIngredientRequestDetaiViewModle b = new TCIngredientRequestDetaiViewModle();
                    b.IngredientRequestID = IngredienRequesID;
                    b.IngredientID = (int)gridView3.GetRowCellValue(a[i], gridView3.Columns["IngredientID"]);
                    b.Quantity = (double)gridView3.GetRowCellValue(a[i], gridView3.Columns["Quantity"]);
                    b.Name = gridView3.GetRowCellValue(a[i], gridView3.Columns["Name"]).ToString();
                    b.Status = (bool)gridView3.GetRowCellValue(a[i], gridView3.Columns["Status"]);
                    b.Unit = gridView3.GetRowCellValue(a[i], gridView3.Columns["Unit"]).ToString();
                    TCIngredientRequestDetailDAO.ListInredientReques.Add(b);
                    TCIngredientRequestDetailDAO.ListInredientReques2.RemoveAt(a[i]);
                    for (int j = i + 1; j <= a1 - 1; j++)
                    {
                        a[j] += -1;
                    }
                }              
            }
            grChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
            gridView3.RefreshData();
            gridView2.RefreshData();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

            if (gridView3.RowCount!=0)
            {
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    if ((bool)gridView3.GetRowCellValue(i,gridView3.Columns["Status"])==false)
                    {
                        break;
                    }
                    if (i==gridView3.RowCount-1)
                    {
                        return;
                    }
                }
                try
                {
                    OrderDetailDAO dt = new OrderDetailDAO();
                    TCIngredientRequestDetailDAO dc = new TCIngredientRequestDetailDAO();
                    OrderDetailDAO.ListTCOrderDetailViewModle.Clear();
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if ((bool)gridView3.GetRowCellValue(i,gridView3.Columns["Status"])==false)
                        {
                            OrderDetail a = new OrderDetail();
                            TCOrderDetailViewModle b = new TCOrderDetailViewModle();
                            a.IngredientID = (int)gridView3.GetRowCellValue(i, gridView3.Columns["IngredientID"]);
                            a.QuantityOfUnit = (double)gridView3.GetRowCellValue(i, gridView3.Columns["Quantity"]);
                            b = dt.OrderDetailViewModle(a);
                            OrderDetailDAO.ListTCOrderDetailViewModle.Add(b);
                        }
                        
                    }
                    FrThanhToanThucPham c = new FrThanhToanThucPham();
                    c.ShowDialog();
                    if (OrderDetailDAO.ThanhToan== true)
                    {
                        for (int i = 0; i < gridView3.RowCount; i++)
                        {
                            if ((bool)gridView3.GetRowCellValue(i, gridView3.Columns["Status"]) == false)
                            {
                                //loại bỏ yêu cầu khi đã thực hiện
                                IngredientRequestDetail a1 = new IngredientRequestDetail();
                                a1.IngredientID = (int)gridView3.GetRowCellValue(i, gridView3.Columns["IngredientID"]);
                                a1.IngredientRequestID = IngredienRequesID;
                                a1.Status = true;
                                dc.Edit(a1);
                            }

                        }
                        LoadIngredienRequesDetailBought(IngredienRequesID);
                    }
                    
                    
                    //nếu hoàn thành yêu cầu
                    if ((bool)gridView3.GetRowCellValue((gridView3.RowCount - 1), gridView3.Columns["Status"]) == true&&gridView2.RowCount==0)
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
            Employee a = dt.GetByID((int)gridView1.GetRowCellValue(e.ListSourceRowIndex, "CreatedBy"));
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
                if (gridView1.RowCount == 0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grDamua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    gridView3.RefreshData();
                    gridView2.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
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
                if (gridView1.RowCount == 0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grDamua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    gridView3.RefreshData();
                    gridView2.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
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
                if (gridView1.RowCount==0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grDamua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    gridView3.RefreshData();
                    gridView2.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
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
                if (gridView1.RowCount == 0)
                {
                    TCIngredientRequestDetailDAO.ListInredientReques.Clear();
                    grChiTietYeuCau.DataSource = TCIngredientRequestDetailDAO.ListInredientReques;
                    TCIngredientRequestDetailDAO.ListInredientReques2.Clear();
                    grDamua.DataSource = TCIngredientRequestDetailDAO.ListInredientReques2;
                    gridView3.RefreshData();
                    gridView2.RefreshData();
                }
                else
                {
                    LoadIngredienRequestDetail((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                    LoadIngredienRequesDetailBought((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientRequestID"));
                }
                
            }
            catch
            {


            }
        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "TinhTrang") return;
            if ((bool)gridView3.GetRowCellValue(e.ListSourceRowIndex,"Status")==true)
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
