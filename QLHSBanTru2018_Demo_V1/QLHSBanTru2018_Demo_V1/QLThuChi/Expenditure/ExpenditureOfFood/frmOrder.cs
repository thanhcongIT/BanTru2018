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
using DataConnect;
using DataConnect.DAO.HungTD;
using System.IO;
using DataConnect.DAO.ThanhCongTC.Report;
using DevExpress.XtraSplashScreen;

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
            try
            {
                LoadOrder();
                LoadOrderDetail((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OrderID"));
            }
            catch 
            {

                
            }            
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
        public void LoadOrderDetail(int a)
        {
            OrderDetailDAO dt = new OrderDetailDAO();
            grChiTietPhieuChi.DataSource = dt.listModel(a);
        }
        private void cbTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtTheoThang.Enabled = false;
                dtTheoNgay.Enabled = true;
                LoadOrder();
            }
            catch 
            {

                
            }
            
        }

        private void cbTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtTheoNgay.Enabled = false;
                dtTheoThang.Enabled = true;
                LoadOrder();
            }
            catch 
            {

                
            }
            
        }

        private void dtTheoNgay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOrder();
                LoadOrderDetail((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OrderID"));
            }
            catch 
            {

            
            }
        }

        private void dtTheoThang_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOrder();
                LoadOrderDetail((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OrderID"));
            }
            catch 
            {

                
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadOrderDetail((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "OrderID"));
                txtTongTien.Text =gridView1.GetRowCellValue(e.FocusedRowHandle, "TotalPrice").ToString();
                EmployeeDAO employeeDAO = new EmployeeDAO();
                Employee a = employeeDAO.GetByID((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "EmployeeID"));
                txtHoTen.Text = a.FirstName + a.LastName;
                txtNgaySinh.Text = a.Birthday.ToString().Substring(0, 10);
                txtSDT.Text = a.Phone.ToString();
                txtEmail.Text = a.Email;
                txtNoiSinh.Text = a.AddressDetail;
                txtGhichu.Text = a.Note;
                MemoryStream mom = new MemoryStream(a.Image.ToArray());
                pcAnh.Image = Image.FromStream(mom);
            }
            catch 
            {

                
            }
        }

        private void bntIn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount!=0)
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                rptHoaDonThucPham a = new rptHoaDonThucPham();
                a.FilterString = "[OrderID]='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["OrderID"]) + "'";
                a.CreateDocument();
                rptOrder b = new rptOrder();
                b.documentViewer1.DocumentSource = a;
                b.ShowDialog();
                SplashScreenManager.CloseForm();
            }
            
        }
    }
}
