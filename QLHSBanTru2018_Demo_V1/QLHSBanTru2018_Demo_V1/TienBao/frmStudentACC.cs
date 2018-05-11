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
using DataConnect.DAO.TienBao;
using DataConnect.DAO.HungTD;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmStudentACC : DevExpress.XtraEditors.XtraUserControl
    {
        public frmStudentACC()
        {
            InitializeComponent();
        }
        #region LoadInfor
        private void LoadClassInfor(int GradeID)
        {
            List<DataConnect.Class> listClass = new ClassDAO().ListClassByGrade(GradeID);
            cmbLopHoc.DisplayMember = "Name";
            cmbLopHoc.ValueMember = "ClassID";
            cmbLopHoc.DataSource = listClass;
        }
        private void LoadGradeInfor(int SemesterID)
        {
            List<DataConnect.Grade> ListGrade = new DataConnect.DAO.HungTD.GradeDAO().ListBySemester(SemesterID);
            cmbKhoiLop.DisplayMember = "Name";
            cmbKhoiLop.ValueMember = "GradeID";
            cmbKhoiLop.DataSource = ListGrade;
        }
        private void LoadSemesterInfor(int CourseID)
        {
            List<DataConnect.Semester> ListSemester = new SemesterDAO().ListByCourseID(CourseID);
            cmbHocKy.DisplayMember = "Name";
            cmbHocKy.ValueMember = "SemesterID";
            cmbHocKy.DataSource = ListSemester;
        }
        private void LoadCourseInfor()
        {
            List<DataConnect.Course> ListCourse = new CourseDAO().ListAll();
            cmbNamHoc.DataSource = ListCourse;
            cmbNamHoc.DisplayMember = "Name";
            cmbNamHoc.ValueMember = "CourseID";
        }
        private void FillGridControl(int ClassID)
        {
            try
            {
                dgvAcc.DataSource = new StudentDAO().ListStudentByClass(ClassID);
            }
            catch
            { }
        }
        private void FillStudentLock(int ClassID)
        {
            try
            {
                dgvAcc.DataSource = new StudentDAO().ListStudentLockByClass(ClassID);
            }
            catch
            { }
        }
       private void Binding()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add(new Binding("text", dgvAcc.DataSource, "StudentID"));
        }
        void Defaule()
        {
            cmbNamHoc.Text = "";
            cmbHocKy.Text = "";
            cmbKhoiLop.Text = "";
            cmbLopHoc.Text = "";
            btnXem.Enabled = false;            
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = false;           
        }
        void Enable()
        {
            btnXem.Enabled = true;           
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXuatExcel.Enabled = true;
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Event
        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            Defaule();
        }
        private void dgvHocSinh_Click(object sender, EventArgs e)
        {            
        }
        private void cmbNamHoc_Click(object sender, EventArgs e)
        {
            LoadCourseInfor();
            Enable();
        }
        private void cmbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSemesterInfor(int.Parse(cmbNamHoc.SelectedValue.ToString()));
            }
            catch
            { }
        }
        private void cmbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadGradeInfor(int.Parse(cmbHocKy.SelectedValue.ToString()));

            }
            catch
            { }
        }
        private void cmbKhoiHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadClassInfor(int.Parse(cmbKhoiLop.SelectedValue.ToString()));

            }
            catch
            { }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            Defaule();
            try
            {
                FillGridControl(0);
            }
            catch
            { }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            if (radDangHoc.Checked == true)
            {
                try
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
                catch
                { }
            }
            else
            {
                try
                {
                    FillStudentLock(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
                catch
                { }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn khóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
            }
        }
        #endregion


        #region ======== Export =========
        private void Export()
        {
            #region ============== Tạo đối tượng lưu tệp tin ==============           
            #endregion ============== Tạo đối tượng lưu tệp tin ==============


            #region ============== Khởi tạo excel ==============
            // Khởi tạo excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // khởi tạo workbook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // khởi tạo worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Tài khoản học sinh";
            app.Visible = true; // Cho hiển thị excel
            #endregion ============== Khởi tạo excel ==============


            #region ========== Đổ dữ liệu vào Sheet ==========           

            worksheet.Cells[1, 1] = "SỞ GIÁO DỤC VÀ ĐÀO TẠO HÀ NỘI ";
            worksheet.Cells[2, 1] = " TRƯỜNG MẦM NON HOA LINH ";

            worksheet.Cells[4, 1] = "THÔNG TIN TÀI KHOẢN HỌC SINH ";
            worksheet.Cells[5, 1] = "Lớp:" + " " + cmbLopHoc.Text;
            worksheet.Cells[6, 1] = "Học kỳ:" + " " + cmbHocKy.Text + " - " + "Năm học:" + " " + cmbNamHoc.Text;

            worksheet.Cells[8, 1] = "TT";
            worksheet.Cells[8, 2] = "Mã học sinh";
            worksheet.Cells[8, 3] = "Họ đệm";
            worksheet.Cells[8, 4] = "Tên";
            worksheet.Cells[8, 5] = "Ngày sinh";
            worksheet.Cells[8, 6] = "Giới tính";
            worksheet.Cells[8, 7] = "Địa chỉ";
            worksheet.Cells[8, 8] = "Họ tên cha";
            worksheet.Cells[8, 9] = "Nghề nghiệp";
            worksheet.Cells[8, 10] = "Họ tên mẹ";
            worksheet.Cells[8, 11] = "Nghề nghiệp";

            // Duyệt hết các dòng trong datagridview
            for (int dong = 0; dong < gridView1.RowCount; dong++)
            {
                worksheet.Cells[dong + 9, 1] = dong + 1; // Số thứ tự
                worksheet.Cells[dong + 9, 2] = gridView1.GetRowCellValue(dong, gridView1.Columns["StudentCode"]);
                worksheet.Cells[dong + 9, 3] = gridView1.GetRowCellValue(dong, gridView1.Columns["Password"]);
                worksheet.Cells[dong + 9, 4] = gridView1.GetRowCellValue(dong, gridView1.Columns["FirstName"]);
                worksheet.Cells[dong + 9, 5] = gridView1.GetRowCellValue(dong, gridView1.Columns["LastName"]);
                worksheet.Cells[dong + 9, 6] = gridView1.GetRowCellValue(dong, gridView1.Columns["Birthday"]);
                if (gridView1.GetRowCellValue(dong, gridView1.Columns["Gender"]).ToString() == "True")
                {
                    worksheet.Cells[dong + 9, 6] = "Nam";
                }
                else
                {
                    worksheet.Cells[dong + 9, 6] = "Nữ";
                }
               // worksheet.Cells[dong + 9, 7] = gridView1.GetRowCellValue(dong, gridView1.Columns["Gender"]);
                worksheet.Cells[dong + 9, 8] = gridView1.GetRowCellValue(dong, gridView1.Columns["ClassName"]);
                worksheet.Cells[dong + 9, 9] = gridView1.GetRowCellValue(dong, gridView1.Columns["Note"]);
            }

            int dongData = gridView1.RowCount;
            worksheet.Cells[dongData + 13, 9] = "Hà Nội, ngày          tháng           năm            . ";
            worksheet.Cells[dongData + 14, 9] = "HIỆU TRƯỞNG. ";
            #endregion ========== Đổ dữ liệu vào Sheet ==========


            #region ============= Căn chỉnh excel =============
            // Đinh dạng trang
            worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait; // Giấy dọc
            worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // Loại giấy A4
            worksheet.PageSetup.LeftMargin = 0; // Căn lề trái
            worksheet.PageSetup.TopMargin = 0; // Căn lề trên
            worksheet.PageSetup.RightMargin = 0; // Căn lề phải
            worksheet.PageSetup.BottomMargin = 0; // Căn lề dưới
            worksheet.PageSetup.CenterHorizontally = true; // Căn giữa theo chiều ngang
            // Định dạng cột
            worksheet.Range["A1"].ColumnWidth = 3;
            worksheet.Range["B1"].ColumnWidth = 13;
            worksheet.Range["C1"].ColumnWidth = 13;
            worksheet.Range["D1"].ColumnWidth = 8;
            worksheet.Range["E1"].ColumnWidth = 13;
            worksheet.Range["F1"].ColumnWidth = 10;
            worksheet.Range["G1"].ColumnWidth = 28;
            worksheet.Range["H1"].ColumnWidth = 14;
            worksheet.Range["I1"].ColumnWidth = 11;
            worksheet.Range["J1"].ColumnWidth = 14;
            worksheet.Range["K1"].ColumnWidth = 11;
            // Định dạng font chữ
            worksheet.Range["A1", "K100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "K100"].Font.Size = 10; // size cho font chữ
            worksheet.Range["A4", "K4"].Font.Size = 12; // Size tiêu đề lớn hơn chút
            worksheet.Range["A5", "K5"].Font.Size = 12;
            worksheet.Range["A6", "K6"].Font.Size = 12;
            worksheet.Range["A1", "K1"].Font.Size = 12;
            worksheet.Range["A2", "K2"].Font.Size = 12;

            worksheet.Range["A4", "K4"].MergeCells = true; // Nhập dòng tiêu đề
            worksheet.Range["A5", "K5"].MergeCells = true;
            worksheet.Range["A6", "K6"].MergeCells = true;
            worksheet.Range["A1", "D1"].MergeCells = true;
            worksheet.Range["A2", "D2"].MergeCells = true;

            worksheet.Range["A4", "K4"].Font.Bold = true; // Tô đậm tiêu đề
            worksheet.Range["A5", "K5"].Font.Bold = true;
            worksheet.Range["A6", "K6"].Font.Bold = true;
            worksheet.Range["A2", "K2"].Font.Bold = true;
            worksheet.Range["A8", "K8"].Font.Bold = true; // Tô đậm tên cột trong bảng
            worksheet.Range["G" + (dongData + 13), "K" + (dongData + 13)].Font.Italic = true; //in nghiêng ngày tháng năm
            worksheet.Range["G" + (dongData + 14), "K" + (dongData + 14)].Font.Bold = true; // Tô đậm tên cột trong bảng

            // Kẻ bảng điểm
            worksheet.Range["A8", "K" + (dongData + 9)].Borders.LineStyle = 1;
            // Định dạng các cột các dòng text
            worksheet.Range["A1", "A9"].HorizontalAlignment = 3; // Căn giữa tiêu đề bảng
            worksheet.Range["A8", "K8"].HorizontalAlignment = 3; // Tiêu đề cột bảng căn giữa
            worksheet.Range["A4", "K4"].HorizontalAlignment = 3;
            worksheet.Range["A5", "K5"].HorizontalAlignment = 3;
            worksheet.Range["A6", "K6"].HorizontalAlignment = 3;

            worksheet.Range["A9", "A" + (dongData + 12)].HorizontalAlignment = 3; // 
            //worksheet.Range["E9", "E" + (dongData + 12)].HorizontalAlignment = 3; //
            //worksheet.Range["F9", "F" + (dongData + 12)].HorizontalAlignment = 3; // 
            //worksheet.Range["I9", "I" + (dongData + 12)].HorizontalAlignment = 3; // 
            //worksheet.Range["K9", "K" + (dongData + 12)].HorizontalAlignment = 3; //             
            #endregion ============= Căn chỉnh excel =============
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm));
            Export();
            SplashScreenManager.CloseForm();
        }
        #endregion ======== Export =========
    }
}
