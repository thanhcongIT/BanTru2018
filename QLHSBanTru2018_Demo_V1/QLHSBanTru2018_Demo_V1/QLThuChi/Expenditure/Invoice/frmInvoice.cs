﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataConnect.DAO.ThanhCongTC;
using DataConnect.DAO.ThanhCongTC.ChiTieu;
using DataConnect.DAO.HungTD;
using DataConnect;
using QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.LoaiChi;
using DataConnect.DAO.ThanhCongTC.ChiTieuThucPham;
using QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham;
using DevExpress.XtraSplashScreen;
using DataConnect.DAO.ThanhCongTC.Report;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu
{
    public partial class UsKhoanChi : DevExpress.XtraEditors.XtraUserControl
    {
        public UsKhoanChi()
        {
            InitializeComponent();
        }
        public void LoadNamhoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbNamhoc.DataSource = dt.ListCourse();
            cbbNamhoc.ValueMember = "CourseID";
            cbbNamhoc.DisplayMember = "Name";
        }
        public void LoadHocky()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbHocky.DataSource = dt.ListSemesterByID((int)cbbNamhoc.SelectedValue);
            cbbHocky.ValueMember = "SemesterID";
            cbbHocky.DisplayMember = "Name";
        }
        public void LoadHoaDon()
        {
            try
            {
                InvoiceDAO dt = new InvoiceDAO();
                grcKhoanChi.DataSource = dt.ListInvoice((int)cbbNamhoc.SelectedValue, (int)cbbHocky.SelectedValue);
            }
            catch 
            {

               
            }
        }
        public void LoadChiTietHoaDon(System.Guid a)
        {
            InvoiceDetailDAO dt = new InvoiceDetailDAO();
            grcChiTietKhoanChi.DataSource = dt.ListInvoiceDetail(a);
        }

        private void UsKhoanChi_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNamhoc();
                LoadHocky();
                LoadHoaDon();
                LoadChiTietHoaDon((System.Guid)grKhoanChi.GetRowCellValue(grKhoanChi.FocusedRowHandle, "InvoiceID"));
            }
            catch
            {

                
            }
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            FrThemkhoanchi a = new FrThemkhoanchi();
            a.ShowDialog();
            LoadHoaDon();
        }

        private void cbbNamhoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadHocky();
                LoadHoaDon();
                if (grChiTietKhoanChi.RowCount==0)
                {
                    grcChiTietKhoanChi.DataSource = "";
                }
                else
                {
                    LoadChiTietHoaDon((System.Guid)grKhoanChi.GetRowCellValue(grKhoanChi.FocusedRowHandle, "InvoiceID"));
                }               
            }
            catch 
            {

               
            }
        }

        private void cbbHocky_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadHoaDon();
                if (grKhoanChi.RowCount==0)
                {
                    
                    grcChiTietKhoanChi.DataSource = "";
                    
                }
                else
                {
                    LoadChiTietHoaDon((System.Guid)grKhoanChi.GetRowCellValue(grKhoanChi.FocusedRowHandle, "InvoiceID"));
                }
                
                
               
            }
            catch 
            {

               
            }
        }

        private void bntXuathoadon_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            rptHoaDonChiTieu a = new rptHoaDonChiTieu();
            a.FilterString = "[InvoiceID]='" + grKhoanChi.GetRowCellValue(grKhoanChi.FocusedRowHandle, grKhoanChi.Columns["InvoiceID"]) + "'";
            a.CreateDocument();
            rptOrder b = new rptOrder();
            b.documentViewer1.DocumentSource = a;
            b.ShowDialog();
            SplashScreenManager.CloseForm();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //load thong tin hóa đơn
                txtMaHoaDon.Text = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "InvoiceID").ToString();
                dtNgayTao.EditValue = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "CreatedDate");
                txtTongTien.Text = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "TotalPrice").ToString();
                txtHoTen.Text = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "NameMoneyReceive").ToString();
                txtDiaChi.Text = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "AdressDetail").ToString();
                txtSDT.Text = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "PhoneNumber").ToString();
                txtGhichu.Text = grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
                EmployeeDAO dt = new EmployeeDAO();
                Employee a = dt.GetByID((int)grKhoanChi.GetRowCellValue(e.FocusedRowHandle, "EmployeeID"));
                TCIngredientRequestDAO.employeeReques = a;
                txtNguoiTao.Text = a.FirstName.ToString()+a.LastName.ToString();
                //laod chi tiết hóa đơn
                LoadChiTietHoaDon((System.Guid)grKhoanChi.GetRowCellValue(grKhoanChi.FocusedRowHandle, "InvoiceID"));
            }
            catch 
            {

                
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                InvoiceDetailDAO.DemoInvoiceDetail.InvoiceDetailID = (int)grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "InvoiceDetailID");
                InvoiceDetailDAO.DemoInvoiceDetail.InvoiceID = System.Guid.Parse(txtMaHoaDon.Text);
                InvoiceDetailDAO.DemoInvoiceDetail.NameInvoiceDetail = grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "NameInvoiceDetail").ToString();
                InvoiceDetailDAO.DemoInvoiceDetail.Price = (decimal)grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "Price");
                InvoiceDetailDAO.DemoInvoiceDetail.Unit = grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "Unit").ToString();
                InvoiceDetailDAO.DemoInvoiceDetail.Amount = (int)grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "Amount");
                InvoiceDetailDAO.DemoInvoiceDetail.TotalPriceDetail = (decimal)grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "TotalPriceDetail");
                InvoiceDetailDAO.DemoInvoiceDetail.Note = grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
                InvoiceDetailDAO.DemoInvoiceDetail.Status = (bool)grChiTietKhoanChi.GetRowCellValue(e.FocusedRowHandle, "Status");
            }
            catch 
            {

             
            }
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrViewInvoiceDetail a = new FrViewInvoiceDetail();
            a.ShowDialog();
        }

        private void btnChiTietNhanVien_Click(object sender, EventArgs e)
        {
            if (txtNguoiTao.Text!="")
            {
                TcFrNhanVien a = new TcFrNhanVien();
                a.ShowDialog();
            }
        }
    }
}
