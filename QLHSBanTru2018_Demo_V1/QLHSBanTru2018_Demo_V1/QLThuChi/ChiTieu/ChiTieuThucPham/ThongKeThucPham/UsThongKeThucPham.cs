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
using DataConnect;
using System.IO;
using DataConnect.DAO.ThanhCongTC;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham.ThongKeThucPham
{
    public partial class UsThongKeThucPham : DevExpress.XtraEditors.XtraUserControl
    {
        public void LoadNamhoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbNamHoc.DataSource = dt.ListCourse();
            cbbNamHoc.ValueMember = "CourseID";
            cbbNamHoc.DisplayMember = "Name";
        }
        public UsThongKeThucPham()
        {
            InitializeComponent();
        }
        public void LoadLoaiThucPham()
        {
            IngredientTypeDAO dt = new IngredientTypeDAO();
            grLoaiThucPham.DataSource = dt.ListAll();
        }
        public void loadLoaiTP()
        {
            IngredientTypeDAO dt = new IngredientTypeDAO();
            cbbLoaithucPham.DataSource = dt.ListAll();
            cbbLoaithucPham.ValueMember = "IngredientTypeID";
            cbbLoaithucPham.DisplayMember = "Name";
        }
        public void LoadDanhSachThucPham(int IngredientTypeID)
        {
            try
            {
                //IngredientDAO dt = new IngredientDAO();
                TCIngredientDAO dt = new TCIngredientDAO();
                grLoaiThucPham.DataSource = dt.ListAllActive(IngredientTypeID);
                BindingDetail();
            }
            catch 
            {

                
            }
            
        }
        public void LoadThongKeThucPham(int IngredientID,DateTime Date)
        {
            StatisticalDAO dt = new StatisticalDAO();
            if (cbTheoNgay.Checked==true)
            {
                grThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModelByDay(IngredientID, Date);
            }
            else
            {
                if (cbTheoThang.Checked==true)
                {
                    grThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModleByMonth(IngredientID, Date);
                }
                else
                {
                    TCCourseDAO dc = new TCCourseDAO();
                    DateTime StartDate = dc.StartDateCourse((int)cbbNamHoc.SelectedValue);
                    DateTime EndDate = dc.EndDateCourse((int)cbbNamHoc.SelectedValue);
                    grThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModleByYear(IngredientID, StartDate, EndDate);
                }
            }
        }
        public void TinhTong()
        {
            decimal TongTien = 0;
            double TongSoLuong = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                TongTien += (decimal)gridView3.GetRowCellValue(i, "TotalPrice");
                TongSoLuong += (double)gridView3.GetRowCellValue(i, "QuantityOfUnit");
            }
            txtSoLuong.Text = TongSoLuong.ToString();
            txtTongTien.Text = TongTien.ToString();
        }
        private void UsThongKeThucPham_Load(object sender, EventArgs e)
        {
            LoadNamhoc();
            loadLoaiTP();
            cbbLoaithucPham_SelectedIndexChanged(sender, e);
            LoadDanhSachThucPham((int)cbbLoaithucPham.SelectedValue);
            
        }
        private void BindingDetail()
        {
            groupControl2.DataBindings.Clear();
            groupControl2.DataBindings.Add(new Binding("text", grLoaiThucPham.DataSource, "Name"));
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch 
            {

                
            }
        }
        private void dtTheoNgay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch 
            {

                
            }          
        }
       
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                EmployeeDAO dt = new EmployeeDAO();
                Employee a = new Employee();
                a = dt.GetByID((int)gridView3.GetRowCellValue(e.FocusedRowHandle, "EmployeeID"));
                txtHoTen.Text = a.FirstName + " " + a.LastName;
                txtCMT.Text = a.IdentityNumber;
                txtNgaySinh.Text = a.AddressDetail;
                txtSDT.Text = a.Phone;
                txtEmail.Text = a.Email;
                txtNgaySinh.Text = a.Birthday.ToString().Substring(0, 10);
                txtGhiChu.Text = a.Note;
                MemoryStream mom = new MemoryStream(a.Image.ToArray());
                pcAnh.Image = Image.FromStream(mom);
                txtNoiSinh.Text = new LocationDAO().GetFullNameLocaion(a.LocationID);
            }
            catch 
            {

              
            }

        }

        private void cbTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtTheoNgay.Enabled = true;
            dtTheoThang.Enabled = false;
            cbbNamHoc.Enabled = false;
            try
            {
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch
            {


            }
        }

        private void cbTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            dtTheoNgay.Enabled = false;
            dtTheoThang.Enabled = true;
            cbbNamHoc.Enabled = false;
            try
            {
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch
            {


            }
        }

        private void cbTheoNam_CheckedChanged(object sender, EventArgs e)
        {
            dtTheoNgay.Enabled = false;
            dtTheoThang.Enabled = false;
            cbbNamHoc.Enabled = true;
            try
            {
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch
            {


            }
        }

        private void cbbLoaithucPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = (int)cbbLoaithucPham.SelectedValue;
                LoadDanhSachThucPham(a);
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch 
            {

                
            }
        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadThongKeThucPham((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch
            {


            }
        }

        private void btnXuatDuLieu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
