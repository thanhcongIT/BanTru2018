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
using System.Data.OleDb;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmImportExcel : DevExpress.XtraEditors.XtraUserControl
    {
        public frmImportExcel()
        {
            InitializeComponent();
        }
        #region LoadInfo
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
        #endregion

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
        private void cmbLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void frmImportExcel_Load(object sender, EventArgs e)
        {
            LoadCourseInfor();
            cmbNamHoc_SelectedIndexChanged(sender, e);
            cmbHocKy_SelectedIndexChanged(sender, e);
            cmbKhoiHoc_SelectedIndexChanged(sender, e);
            cmbLopHoc_SelectedIndexChanged(sender, e);
        }
        private void btnThemmoi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int dong = bandedGridView1.FocusedRowHandle;
            frmAddStudent m_AddStudent = new frmAddStudent();
            m_AddStudent.iFunction = 2;
            m_AddStudent.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
            DataTable table = new DataTable();



            //m_AddStudent.FirstName = bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colFirstName"]).ToString();
            //m_AddStudent.LastName = bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colLastName"]).ToString();
            //m_AddStudent.HomeName = bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colHomeName"]).ToString();
            //m_AddStudent.Birthday = Convert.ToDateTime(bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colBirthday"]));
            //m_AddStudent.DateStudy = Convert.ToDateTime(bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colDateStudy"]));
            //m_AddStudent.AdressDetail = bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colAddress"]).ToString();
            //m_AddStudent.Note = bandedGridView1.GetRowCellDisplayText(dong, bandedGridView1.Columns["colNote"]).ToString();

            m_AddStudent.ShowDialog();
            if (m_AddStudent.DialogResult == DialogResult.OK)
            {
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bandedGridView1.AddNewRow();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            bandedGridView1.DeleteRow(bandedGridView1.FocusedRowHandle);
        }
        private bool ValidInput()
        {
            if (txtFilePath.Text.Trim() == "")
            {
                MessageBox.Show("Xin vui lòng chọn tập tin excel cần nhập");
                return false;
            }
            return true;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Sử dụng tệp dữ liệu mẫu để có được kết quả tốt nhất", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn tệp nguồn";
                ofd.Filter = "Mở File Excel .xls | *.xlsx";
                ofd.FilterIndex = 3;
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidInput())
                    return;

                string strConn = string.Empty;
                FileInfo file = new FileInfo(txtFilePath.Text);
                if (!file.Exists) { throw new Exception("tệp tin đã bị trùng!,Lỗi"); }
                string extension = file.Extension;
                switch (extension)
                {
                    case ".xls":
                        strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilePath.Text + "; Extended Properties= 'Excel 8.0; HDR = NO';";
                        break;
                    case ".xlsx":
                        strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilePath.Text + "; Extended Properties='Excel 12.0 Xml; HDR = NO; IMEX=1';";
                        break;
                    default:
                        strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtFilePath.Text + ";Extended Properties=Excel 8.0;";
                        break;
                }
                OleDbConnection cnnxls = new OleDbConnection(strConn);
                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", cnnxls);
                DataTable table = new DataTable();
                oda.Fill(table);
                dgvImportStudent.DataSource = table;
                foreach (DataRow r in table.Rows)
                {

                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi!");
            }
        }
        private void btnExcelMau_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm));
            Export();
            SplashScreenManager.CloseForm();
        }
        private void Export()
        {
            #region ============== Khởi tạo excel ==============
            // Khởi tạo excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // khởi tạo workbook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // khởi tạo worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            app.Visible = true; // Cho hiển thị excel
            #endregion ============== Khởi tạo excel ==============


            #region ========== Đổ dữ liệu vào Sheet ==========                       
            // worksheet.Cells[1, 1] = "DANH SÁCH HỌC SINH ";            
            worksheet.Cells[1, 1] = "TT";
            worksheet.Cells[1, 2] = "Mã học sinh";
            worksheet.Cells[1, 3] = "Họ đệm";
            worksheet.Cells[1, 4] = "Tên";
            worksheet.Cells[1, 5] = "Tên ở nhà";
            worksheet.Cells[1, 6] = "Ngày sinh";
            worksheet.Cells[1, 7] = "Giới tính";
            worksheet.Cells[1, 8] = "Địa chỉ";
            worksheet.Cells[1, 9] = "Ngày nhập học";
            worksheet.Cells[1, 10] = "Dân tộc";
            worksheet.Cells[1, 11] = "Tôn giáo";
            worksheet.Cells[1, 12] = "Ghi chú";



            int dongData = bandedGridView1.RowCount;

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
            worksheet.Range["H1"].ColumnWidth = 13;
            worksheet.Range["I1"].ColumnWidth = 11;
            worksheet.Range["J1"].ColumnWidth = 11;
            worksheet.Range["K1"].ColumnWidth = 11;
            worksheet.Range["L1"].ColumnWidth = 11;
            // Định dạng font chữ
            worksheet.Range["A1", "M100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "M100"].Font.Size = 12; // size cho font chữ
                                                     
            worksheet.Range["A1", "M1"].Font.Size = 12;
            //  worksheet.Range["A2", "K2"].Font.Size = 12;

            // worksheet.Range["A4", "K4"].MergeCells = true; // Nhập dòng tiêu đề
            // worksheet.Range["A5", "K5"].MergeCells = true;
            // worksheet.Range["A6", "K6"].MergeCells = true;
            // worksheet.Range["A1", "K1"].MergeCells = true;
            // worksheet.Range["A2", "K2"].MergeCells = true;

            // worksheet.Range["A4", "K4"].Font.Bold = true; // Tô đậm tiêu đề
            //  worksheet.Range["A5", "K5"].Font.Bold = true;
            //  worksheet.Range["A6", "K6"].Font.Bold = true;
            worksheet.Range["A1", "L1"].Font.Bold = true; // Tô đậm tên cột trong bảng

            worksheet.Range["A1", "L" + (dongData + 2)].Borders.LineStyle = 1;
            // Định dạng các cột các dòng text
            // worksheet.Range["A1", "A9"].HorizontalAlignment = 3; // Căn giữa tiêu đề bảng
            worksheet.Range["A1", "L1"].HorizontalAlignment = 3; // Tiêu đề cột bảng căn giữa

            worksheet.Range["A2", "A" + (dongData + 12)].HorizontalAlignment = 3; // 
            worksheet.Range["E2", "E" + (dongData + 12)].HorizontalAlignment = 3; //
            worksheet.Range["F2", "F" + (dongData + 12)].HorizontalAlignment = 3; // 
            worksheet.Range["I2", "I" + (dongData + 12)].HorizontalAlignment = 3; // 
            worksheet.Range["K2", "K" + (dongData + 12)].HorizontalAlignment = 3; //             
            #endregion ============= Căn chỉnh excel =============
        }
    }

}
