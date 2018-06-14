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
using DataConnect.DAO.ThanhCongTC.DataSet;
using DevExpress.XtraSplashScreen;
using QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu;

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
            grcLoaiThucPham.DataSource = dt.ListAll();
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
                grcLoaiThucPham.DataSource = dt.ListAllActive(IngredientTypeID);
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
                grcThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModelByDay(IngredientID, Date);
            }
            else
            {
                if (cbTheoThang.Checked==true)
                {
                    grcThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModleByMonth(IngredientID, Date);
                }
                else
                {
                    TCCourseDAO dc = new TCCourseDAO();
                    DateTime StartDate = dc.StartDateCourse((int)cbbNamHoc.SelectedValue);
                    DateTime EndDate = dc.EndDateCourse((int)cbbNamHoc.SelectedValue);
                    grcThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModleByYear(IngredientID, StartDate, EndDate);
                }
            }
        }
        public void TinhTong()
        {
            decimal TongTien = 0;
            double TongSoLuong = 0;
            for (int i = 0; i < grThongKeThucPham.RowCount; i++)
            {
                TongTien += (decimal)grThongKeThucPham.GetRowCellValue(i, "TotalPrice");
                TongSoLuong += (double)grThongKeThucPham.GetRowCellValue(i, "QuantityOfUnit");
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
            groupControl2.DataBindings.Add(new Binding("text", grcLoaiThucPham.DataSource, "Name"));
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(e.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
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
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
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
                a = dt.GetByID((int)grThongKeThucPham.GetRowCellValue(e.FocusedRowHandle, "EmployeeID"));
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
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
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
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
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
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
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
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
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
                LoadThongKeThucPham((int)grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle, "IngredientID"), dtTheoNgay.Value);
                TinhTong();
            }
            catch
            {


            }
        }
        private void export()
        {
            try
            {
                #region===========khởi tạo excel=====
                //khởi tạo excell
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                //khởi tạo workbook
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                //khởi tọa worksheet
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Thống kê chi tiêu thực phẩm";
                app.Visible = true;//cho hiển thị excel
                #endregion===========khởi tạo excel==========
                #region ===========đổ dữ liệu vào sheet======
                worksheet.Cells[1, 1] = "SỞ GIÁO DỤC VÀ ĐÀO TẠO HÀ NỘI";
                worksheet.Cells[2, 1] = "TRƯỜNG MẦM NON HOA LINH";
                worksheet.Cells[3, 8] = "Ngày " + DateTime.Today.Day + " tháng " + DateTime.Today.Month + " năm " + DateTime.Today.Year + "";

                worksheet.Cells[4, 1] = "THỐNG KÊ CHI TIÊU THỰC PHẨM";
                if (cbTheoNgay.Checked)
                {
                    worksheet.Cells[5, 1] = "Ngày:" + dtTheoNgay.Text;
                }
                else
                {
                    if (cbTheoThang.Checked)
                    {
                        worksheet.Cells[5, 1] = "Trong tháng:" +dtTheoThang.Text;
                    }
                    else
                    {
                        worksheet.Cells[5, 1] = "Năm học:" + cbbNamHoc.Text;
                    }
                }               
                worksheet.Cells[6, 1] = "Nhóm thực phẩm:" + cbbLoaithucPham.Text;
                worksheet.Cells[7, 1] = "Tên thực phẩm:" + grLoaiThucPham.GetRowCellValue(grLoaiThucPham.FocusedRowHandle,grLoaiThucPham.Columns["Name"]);

                worksheet.Cells[9, 1] = "STT";
                worksheet.Cells[9, 2] = "Tên hóa đơn";
                worksheet.Cells[9, 4] = "Giá bán";
                worksheet.Cells[9, 5] = "Đơn vị";
                worksheet.Cells[9, 6] = "Số lượng";
                worksheet.Cells[9, 7] = "Thành tiền";
                worksheet.Cells[9, 8] = "Nhân viên";
                worksheet.Cells[9, 9] = "Ngày mua";

                //duyệt dết các dòng trong trong gridcontrol
                EmployeeDAO dt = new EmployeeDAO();
                for (int i = 0; i < grThongKeThucPham.RowCount; i++)
                {
                    worksheet.Cells[10 + i, 1] = i + 1;
                    worksheet.Cells[10 + i, 2] = grThongKeThucPham.GetRowCellValue(i,grThongKeThucPham.Columns["OrderName"]);
                    worksheet.Range["B" + 10 + i + "", "C" + 10 + i + ""].MergeCells = true;//nhập 2 cột liền kề nhau
                    worksheet.Cells[10 + i, 4] = grThongKeThucPham.GetRowCellValue(i, grThongKeThucPham.Columns["PriceOfUnit"]);
                    worksheet.Cells[10 + i, 5] = grThongKeThucPham.GetRowCellValue(i, grThongKeThucPham.Columns["Unit"]);
                    worksheet.Cells[10 + i, 6] = grThongKeThucPham.GetRowCellValue(i, grThongKeThucPham.Columns["QuantityOfUnit"]).ToString();
                    worksheet.Cells[10 + i, 7] = grThongKeThucPham.GetRowCellValue(i, grThongKeThucPham.Columns["TotalPrice"]);
                    //nhân viên lập hóa đơn
                    Employee a = new Employee();
                    a = dt.GetByID((int)grThongKeThucPham.GetRowCellValue(i, grThongKeThucPham.Columns["EmployeeID"]));
                    worksheet.Cells[10 + i, 8] = a.FirstName + " " + a.LastName;
                    worksheet.Cells[10 + i, 9] = grThongKeThucPham.GetRowCellValue(i, grThongKeThucPham.Columns["Date"]);
                }
                int dongData = grThongKeThucPham.RowCount;
                worksheet.Cells[dongData + 10, 1] = "Tổng ";
                worksheet.Range["A"+ (dongData + 10) + "", "E" + (dongData + 10)+ ""].MergeCells = true;
                worksheet.Cells[dongData + 10, 6] = txtSoLuong.Text;
                worksheet.Cells[dongData + 10, 7] = txtTongTien.Text;
                worksheet.Range["A"+(dongData + 10)+"", "G" + (dongData + 10)].Borders.LineStyle = 1;//ke vien bang
                worksheet.Cells[dongData + 13, 8] = "Hà Nội, ngày          tháng           năm            . ";
                worksheet.Cells[dongData + 14, 8] = "HIỆU TRƯỞNG. ";
                #endregion============đổ dữ liệu vào sheet=======
                #region=====căn chỉnh======
                //định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape; // Giấy dọc
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // Loại giấy A4
                worksheet.PageSetup.LeftMargin = 0;//can le trai
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;
                worksheet.PageSetup.CenterHorizontally = true;//can giua theo chieu ngang
                                                              //dinh dang cot
                worksheet.Range["A1"].ColumnWidth = 3;
                worksheet.Range["B1"].ColumnWidth = 20;
                worksheet.Range["C1"].ColumnWidth = 13;
                worksheet.Range["D1"].ColumnWidth = 8;
                worksheet.Range["E1"].ColumnWidth = 13;
                worksheet.Range["F1"].ColumnWidth = 10;
                worksheet.Range["G1"].ColumnWidth = 10;
                worksheet.Range["H1"].ColumnWidth = 28;
                worksheet.Range["I1"].ColumnWidth = 11;
                worksheet.Range["J1"].ColumnWidth = 14;
                worksheet.Range["K1"].ColumnWidth = 11;
                //dinh dang font chu
                worksheet.Range["A1", "K100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "K100"].Font.Size = 10; // size cho font chữ
                worksheet.Range["A4", "K4"].Font.Size = 12; // Size tiêu đề lớn hơn chút
                worksheet.Range["A1", "K2"].Font.Size = 16; // Size tiêu đề lớn hơn chút
                worksheet.Range["A5", "K7"].Font.Size = 12;

                worksheet.Range["A1", "I1"].MergeCells = true; // Nhập dòng tiêu đề
                worksheet.Range["A2", "I2"].MergeCells = true;
                worksheet.Range["H3", "I3"].MergeCells = true;
                worksheet.Range["A4", "I4"].MergeCells = true;
                worksheet.Range["A5", "I5"].MergeCells = true;
                worksheet.Range["A6", "I6"].MergeCells = true;
                worksheet.Range["A7", "I7"].MergeCells = true;
                worksheet.Range["B9", "C9"].MergeCells = true;

                worksheet.Range["A1", "K7"].Font.Bold = true;//to dam tieu de
                worksheet.Range["A9", "K9"].Font.Bold = true;//to dam ten cot

                worksheet.Range["A9", "I" + (dongData + 9)].Borders.LineStyle = 1;//ke vien bang

                worksheet.Range["A3", "A9"].HorizontalAlignment = 3; // Căn giữa tiêu đề bảng
                worksheet.Range["A8", "K8"].HorizontalAlignment = 3; // Tiêu đề cột bảng căn giữa
                worksheet.Range["A4", "K4"].HorizontalAlignment = 3;
                worksheet.Range["A5", "K5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "K6"].HorizontalAlignment = 3;


                #endregion====căn chỉnh=====
            }
            catch
            {
              
            }
        }

        private void btnXuatDuLieu_Click(object sender, EventArgs e)
        {

            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            export();
            SplashScreenManager.CloseForm();
        }
    }
}
