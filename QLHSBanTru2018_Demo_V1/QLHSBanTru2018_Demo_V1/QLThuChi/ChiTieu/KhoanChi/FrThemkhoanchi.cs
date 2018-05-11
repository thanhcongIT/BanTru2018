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
using DataConnect.DAO.ThanhCongTC;
using DataConnect.DAO.ThanhCongTC.ChiTieu;
using DataConnect;
using QLHSBanTru2018_Demo_V1.Common;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu
{
    public partial class FrThemkhoanchi : DevExpress.XtraEditors.XtraForm
    {
        public FrThemkhoanchi()
        {
            InitializeComponent();
        }
        #region hàm đi kèm
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
        public void LoadLoaiChi()
        {
            SpendSpeciesDAO dt = new SpendSpeciesDAO();
            cbbLoaichi.DataSource = dt.ListSpendSpecy();
            cbbLoaichi.ValueMember = "SpendSpeciesID";
            cbbLoaichi.DisplayMember = "Name";
        }
        public void loadChiTietHoaDon()
        {
            grChitiethoadon.DataSource = InvoiceDetailDAO.listDemoInvoiceDetail;
        }
        #endregion

        private void FrThemkhoanchi_Load(object sender, EventArgs e)
        {
            LoadNamhoc();
            LoadHocky();
            LoadLoaiChi();
            dtNgaykhoitao.EditValue = DateTime.Now;
            InvoiceDetailDAO.listDemoInvoiceDetail.Clear();
        }
        public void MinMaxForm()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Normal;
                }

            }
        }
        public void TinhTongTien()
        {
            decimal tong = 0;
            if (gridView1.RowCount>0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    tong +=(decimal)gridView1.GetRowCellValue(i, gridView1.Columns["TotalPriceDetail"]);
                }
            }
            txtTongchi.Text = tong.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrChiTietHoaDon a = new FrChiTietHoaDon();
            a.ShowDialog();
            loadChiTietHoaDon();
            MinMaxForm();
            float Tong = 0;
            TinhTongTien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceDAO dt = new InvoiceDAO();
                InvoiceDetailDAO dc = new InvoiceDetailDAO();
                Invoice a = new Invoice();
                a.CourseID = (int)cbbNamhoc.SelectedValue;
                a.SemesterID = (int)cbbHocky.SelectedValue;
                a.CreatedDate = DateTime.Now;
                a.EmployeeID = LoginDetail.LoginID;
                a.NameMoneyReceive = txtHoten.Text;
                a.PhoneNumber = txtSDT.Text;
                a.AdressDetail = txtDiachi.Text;
                a.TotalPrice = decimal.Parse(txtTongchi.Text);
                a.SpendSpeciesID = (int)cbbLoaichi.SelectedValue;
                a.Note = txtGhichu.Text;
                System.Guid a1= dt.Insert(a);
                if (a1!=null)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        InvoiceDetail b = new InvoiceDetail();
                        b.InvoiceID = a1;
                        b.NameInvoiceDetail = gridView1.GetRowCellValue(i, gridView1.Columns["NameInvoiceDetail"]).ToString();
                        b.Price = (decimal)gridView1.GetRowCellValue(i, gridView1.Columns["Price"]);
                        b.Unit = gridView1.GetRowCellValue(i, gridView1.Columns["Unit"]).ToString();
                        b.Amount = (int)gridView1.GetRowCellValue(i, gridView1.Columns["Amount"]);
                        b.TotalPriceDetail = (decimal)gridView1.GetRowCellValue(i, gridView1.Columns["TotalPriceDetail"]);
                        b.Note = gridView1.GetRowCellValue(i, gridView1.Columns["Note"]).ToString();
                        b.Status = false;
                        if (dc.Insert(b)==true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Bản ghi " + i + " bị lỗi");
                            break;
                        }
                    }
                    MessageBox.Show("Lưu thành công");
                    this.Close();
                }
            }
            catch
            {

               
            }
        }
        private void cbbNamhoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
             LoadHocky();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                InvoiceDetailDAO.Therowfocust = e.FocusedRowHandle;
                InvoiceDetailDAO.DemoInvoiceDetail.NameInvoiceDetail = gridView1.GetRowCellValue(e.FocusedRowHandle, "NameInvoiceDetail").ToString();
                InvoiceDetailDAO.DemoInvoiceDetail.Price = (decimal)gridView1.GetRowCellValue(e.FocusedRowHandle, "Price");
                InvoiceDetailDAO.DemoInvoiceDetail.Unit = gridView1.GetRowCellValue(e.FocusedRowHandle, "Unit").ToString();
                InvoiceDetailDAO.DemoInvoiceDetail.Amount = (int)gridView1.GetRowCellValue(e.FocusedRowHandle, "Amount");
                InvoiceDetailDAO.DemoInvoiceDetail.TotalPriceDetail = (decimal)gridView1.GetRowCellValue(e.FocusedRowHandle, "TotalPriceDetail");
                InvoiceDetailDAO.DemoInvoiceDetail.Note = gridView1.GetRowCellValue(e.FocusedRowHandle, "Note").ToString();
                InvoiceDetailDAO.DemoInvoiceDetail.Status = (bool)gridView1.GetRowCellValue(e.FocusedRowHandle, "Status");
                // load dữ liệu lên view
                txtTenChiTiet.Text= gridView1.GetRowCellValue(e.FocusedRowHandle, "NameInvoiceDetail").ToString();
                txtDonGia.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "Price").ToString();
                txtDonvi.Text= gridView1.GetRowCellValue(e.FocusedRowHandle, "Unit").ToString();
                txtSoLuong.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "Amount").ToString();
                txtThanhTien.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "TotalPriceDetail").ToString();
            }
            catch 
            {
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount==0)
            {
                MessageBox.Show("Danh sách rỗng");
            }
            else
            {
                FrSuaChiTietHoaDon a = new FrSuaChiTietHoaDon();
                a.ShowDialog();
                MinMaxForm();
                TinhTongTien();
            }            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount==0)
            {
                MessageBox.Show("Danh sách rỗng");
            }
            else
            {
                InvoiceDetailDAO.listDemoInvoiceDetail.RemoveAt(InvoiceDetailDAO.Therowfocust);
                loadChiTietHoaDon();
                MinMaxForm();
                TinhTongTien();
            }
        }
    }
}