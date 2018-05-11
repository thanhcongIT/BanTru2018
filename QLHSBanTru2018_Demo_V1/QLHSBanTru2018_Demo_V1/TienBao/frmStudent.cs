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
    public partial class frmStudent : DevExpress.XtraEditors.XtraUserControl
    {
        public frmStudent()
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
                dgvHocSinh.DataSource = new StudentDAO().ListStudentByClass(ClassID);
                BindingDetail();
            }
            catch
            { }
        }
        private void FillStudentLock(int ClassID)
        {
            try
            {
                dgvHocSinh.DataSource = new StudentDAO().ListStudentLockByClass(ClassID);
                BindingDetail();
            }
            catch
            { }
        }
        private void BindingDetail()
        {
            txtStudentCode.DataBindings.Clear();
            txtStudentCode.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "StudentCode"));
            txtStudentID.DataBindings.Clear();
            txtStudentID.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "StudentID"));
            txtFirstName.DataBindings.Clear();
            txtFirstName.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "FirstName"));
            txtLastName.DataBindings.Clear();
            txtLastName.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "LastName"));
            dtBirthday.DataBindings.Clear();
            dtBirthday.DataBindings.Add(new Binding("EditValue", dgvHocSinh.DataSource, "Birthday", true, DataSourceUpdateMode.OnPropertyChanged));
            radMale.DataBindings.Clear();
            radMale.DataBindings.Add(new Binding("Checked", dgvHocSinh.DataSource, "Gender", true, DataSourceUpdateMode.OnPropertyChanged));
            picImage.DataBindings.Clear();
            picImage.DataBindings.Add(new Binding("image", dgvHocSinh.DataSource, "Image", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAddressDetail.DataBindings.Clear();
            txtAddressDetail.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "AdressDetail"));
            //txtAddress.DataBindings.Clear();
            //txtAddress.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "LocationDetail"));
            //radActive.DataBindings.Clear();
            //radActive.DataBindings.Add(new Binding("Checked", dgvHocSinh.DataSource, "Status", true, DataSourceUpdateMode.OnPropertyChanged));
            txtFatherName.DataBindings.Clear();
            txtFatherName.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "FatherName"));
            txtFatherJob.DataBindings.Clear();
            txtFatherJob.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "FatherJob"));
            txtMotherName.DataBindings.Clear();
            txtMotherName.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "MotherName"));
            txtMotherJob.DataBindings.Clear();
            txtMotherJob.DataBindings.Add(new Binding("text", dgvHocSinh.DataSource, "MotherJob"));
        }
        
        
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 2)
            {
                if (radMale.Checked == false)
                    radFemale.Checked = true;
                //if (radActive.Checked == false)
                //    radLock.Checked = true;   
                timer1.Stop();
                i = 0;
            }
        }
        #endregion


        #region Event
        

        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
           
        }
        private void dgvHocSinh_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (txtFatherName.Text == "" || txtFatherJob.Text == "" || txtMotherName.Text == "" || txtMotherJob.Text == "")
            {
                labError.Text = "Vui lòng cập nhật thêm thông tin học sinh";
            }
            else
            {
                labError.Text = "";
            }
        }
        private void cmbNamHoc_Click(object sender, EventArgs e)
        {
            LoadCourseInfor();
           
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
            try
            {
                FillGridControl(0);
            }
            catch
            { }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cmbLopHoc.SelectedValue  == null)
            {
                XtraMessageBox.Show("Vui lòng chọn lớp học ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
                                            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn lớp học ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);               
            }
            else
            {
                frmAddStudent m_AddStudent = new frmAddStudent();
                m_AddStudent.iFunction = 1;
                m_AddStudent.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_AddStudent.ShowDialog();
                if (m_AddStudent.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
            
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == null)
            {
                XtraMessageBox.Show("Vui lòng chọn học sinh cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmStudentDetail m_StudentDetail = new frmStudentDetail();
                m_StudentDetail.iFunction = 2;
                m_StudentDetail.Student = new StudentDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.StudentParents = new StudentParentsDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_StudentDetail.ShowDialog();
                if (m_StudentDetail.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
            
        }   
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
          
            if (txtStudentID.Text.Length == 0 )
            {
                XtraMessageBox.Show("Vui lòng chọn học sinh cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmStudentDetail m_StudentDetail = new frmStudentDetail();
                m_StudentDetail.iFunction = 3;
                m_StudentDetail.Student = new StudentDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.StudentParents = new StudentParentsDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_StudentDetail.ShowDialog();
                if (m_StudentDetail.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
           
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text.Length == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn học sinh cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show("Bạn muốn xóa học sinh ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new StudentDAO().StudentDelete(int.Parse(txtStudentID.Text));
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
          
        }
        #endregion


        #region ========== ContextMenu ============
        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == null)
            {
                XtraMessageBox.Show("Vui lòng chọn học sinh cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmStudentDetail m_StudentDetail = new frmStudentDetail();
                m_StudentDetail.iFunction = 3;
                m_StudentDetail.Student = new StudentDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.StudentParents = new StudentParentsDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_StudentDetail.ShowDialog();
                if (m_StudentDetail.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
        }
        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn lớp học ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmAddStudent m_AddStudent = new frmAddStudent();
                m_AddStudent.iFunction = 1;
                m_AddStudent.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_AddStudent.ShowDialog();
                if (m_AddStudent.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == null)
            {
                XtraMessageBox.Show("Vui lòng chọn học sinh cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmStudentDetail m_StudentDetail = new frmStudentDetail();
                m_StudentDetail.iFunction = 2;
                m_StudentDetail.Student = new StudentDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.StudentParents = new StudentParentsDAO().GetByID(int.Parse(txtStudentID.Text));
                m_StudentDetail.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_StudentDetail.ShowDialog();
                if (m_StudentDetail.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }

        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text.Length == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn học sinh cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show("Bạn muốn xóa học sinh ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new StudentDAO().StudentDelete(int.Parse(txtStudentID.Text));
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                }
            }
        }
        #endregion ========== ContextMenu ============


        #region ======== Export =========
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
            worksheet.Name = "Danh sách học sinh";
            app.Visible = true; // Cho hiển thị excel
            #endregion ============== Khởi tạo excel ==============


            #region ========== Đổ dữ liệu vào Sheet ==========           

            worksheet.Cells[1, 1] = "SỞ GIÁO DỤC VÀ ĐÀO TẠO HÀ NỘI ";
            worksheet.Cells[2, 1] = " TRƯỜNG MẦM NON HOA LINH ";

            worksheet.Cells[4, 1] = "DANH SÁCH HỌC SINH ";
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
                worksheet.Cells[dong + 9, 3] = gridView1.GetRowCellValue(dong, gridView1.Columns["FirstName"]);
                worksheet.Cells[dong + 9, 4] = gridView1.GetRowCellValue(dong, gridView1.Columns["LastName"]);
                worksheet.Cells[dong + 9, 5] = gridView1.GetRowCellValue(dong, gridView1.Columns["Birthday"]);
                if (gridView1.GetRowCellValue(dong, gridView1.Columns["Gender"]).ToString()=="True")
                {
                    worksheet.Cells[dong + 9, 6] = "Nam";
                }
                else
                {
                    worksheet.Cells[dong + 9, 6] = "Nữ";
                }
                //worksheet.Cells[dong + 9, 6] = gridView1.GetRowCellValue(dong, gridView1.Columns["Gender"]);
                worksheet.Cells[dong + 9, 7] = gridView1.GetRowCellValue(dong, gridView1.Columns["LocationDetail"]);
                worksheet.Cells[dong + 9, 8] = gridView1.GetRowCellValue(dong, gridView1.Columns["FatherName"]);
                worksheet.Cells[dong + 9, 9] = gridView1.GetRowCellValue(dong, gridView1.Columns["FatherJob"]);
                worksheet.Cells[dong + 9, 10] = gridView1.GetRowCellValue(dong, gridView1.Columns["MotherName"]);
                worksheet.Cells[dong + 9, 11] = gridView1.GetRowCellValue(dong, gridView1.Columns["MotherJob"]);
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
            worksheet.Range["E9", "E" + (dongData + 12)].HorizontalAlignment = 3; //
            worksheet.Range["F9", "F" + (dongData + 12)].HorizontalAlignment = 3; // 
            worksheet.Range["I9", "I" + (dongData + 12)].HorizontalAlignment = 3; // 
            worksheet.Range["K9", "K" + (dongData + 12)].HorizontalAlignment = 3; //             
            #endregion ============= Căn chỉnh excel =============
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn lớp học ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SplashScreenManager.ShowForm(typeof(WaitForm));
                Export();
                SplashScreenManager.CloseForm();
            }
       
        }
        #endregion ======== Export =========
    }
}
