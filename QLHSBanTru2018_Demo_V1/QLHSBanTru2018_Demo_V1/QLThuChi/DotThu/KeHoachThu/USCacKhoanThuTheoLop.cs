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
using DataConnect.DAO.ThanhCongTC;
using System.IO;
using DataConnect;
using QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu;
using DevExpress.XtraSplashScreen;

namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    public partial class USCacKhoanThuTheoLop : DevExpress.XtraEditors.XtraUserControl
    {
        public USCacKhoanThuTheoLop()
        {
            InitializeComponent();
        }
        #region ----------------danhsach---------------
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
        public void LoadKhoihoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbKhoihoc.DataSource = dt.ListGradeByID((int)cbbHocky.SelectedValue);
            cbbKhoihoc.ValueMember = "GradeID";
            cbbKhoihoc.DisplayMember = "Name";
        }
        public void LoadLophoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbLophoc.DataSource = dt.ListClassByID((int)cbbKhoihoc.SelectedValue);
            cbbLophoc.ValueMember = "ClassID";
            cbbLophoc.DisplayMember = "Name";
        }
        public void laodDotthu()
        {
            ReceivableIDAO dt = new ReceivableIDAO();
            cbbDotthu.DataSource = dt.ListReceivable((int)cbbHocky.SelectedValue, (int)cbbHocky.SelectedValue);
            cbbDotthu.ValueMember = "ReceivableID";
            cbbDotthu.DisplayMember = "Name";
        }
        public void loadDSHS()
        {
            ClassStudentDAO dt = new ClassStudentDAO();
            grDanhSachHocSinh.DataSource = dt.listviewSD((int)cbbLophoc.SelectedValue,(int)cbbDotthu.SelectedValue);
        }

        private void USCacKhoanThuTheoLop_Load(object sender, EventArgs e)
        {
            try
            {
                
                LoadNamhoc();                
                LoadHocky();
                laodDotthu();
                LoadKhoihoc();             
                LoadLophoc();
                loadDSHS();
                ReceivableIDAO.ReceivableID = (int)cbbDotthu.SelectedValue;
            }
            catch 
            {

               
            }
        }
        

        private void cbbNamhoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadHocky();
                laodDotthu();
                LoadKhoihoc();
                LoadLophoc();
                loadDSHS();
            }
            catch 
            {

                
            }
        }

        private void cbbHocky_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                laodDotthu();
                LoadKhoihoc();
                LoadLophoc();
                loadDSHS();
            }
            catch 
            {

                
            }
        }

        private void cbbKhoihoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadKhoihoc();
                LoadLophoc();
                loadDSHS();
                this.Refresh();
            }
            catch 
            {

                
            }
        }
       
        private void cbbLophoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //studentReceivableDAO.ClassID = (int)cbbDotthu.SelectedValue;
            loadDSHS();
            this.Refresh();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ClassStudentDAO dt = new ClassStudentDAO();
                ClassStudentDAO.StudentID = (int)gridView1.GetRowCellValue(e.FocusedRowHandle, "StudentID");
                Student a = dt.lookForStuden(ClassStudentDAO.StudentID);
                txtTenhocsinh.Text = a.FirstName + " " + a.LastName;
                txtNgaySinh.Text = a.Birthday.ToShortDateString();
                txtDiachi.Text = a.AdressDetail;
                MemoryStream mom = new MemoryStream(a.Image.ToArray());
                Image b = Image.FromStream(mom);
                pcAnhhocsinh.Image = b;
            }
            catch 
            {

                
            }
        }

        private void cbbDotthu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ReceivableIDAO.ReceivableID = (int)cbbDotthu.SelectedValue;
            loadDSHS();
            
        }

        private void bntThanhToan_Click(object sender, EventArgs e)
        {
            FrThanhToan a = new FrThanhToan();
            a.ShowDialog();
            this.Refresh();
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                ReceivableDetail_StudentDAO dt = new ReceivableDetail_StudentDAO();
                ReceivableDetailDAO dc = new ReceivableDetailDAO();
                List<ReceivableDetail_Student> a = new List<ReceivableDetail_Student>();
                List<ReceivableDetail> b = new List<ReceivableDetail>();
                List<ReceivableDetail_Student> f = new List<ReceivableDetail_Student>();
                int rowindex = e.ListSourceRowIndex;
                a = dt.ListReceivableDetail_Student((int)gridView1.GetListSourceRowCellValue(rowindex, "StudentID"));
                b = dc.ListReceivableDetail((int)cbbDotthu.SelectedValue);
                foreach (var i in b)
                {
                    foreach (var j in a)
                    {
                        if (i.ReceivableDetailID == j.ReceivableDetailID)
                        {
                            f.Add(j);
                        }
                    }
                }
                if (e.Column.FieldName != "tinhtrang") return;
                foreach (var i in f)
                {
                    if (i.Status == false)
                    {
                        e.Value = "Chưa hoàn thành";
                        break;
                    }
                    e.Value = "Đã hoàn thành";
                }
                
                
            }
            catch 
            {

                
            }
        }
        #endregion danhsach
        #region =======excell============
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
                worksheet.Name = "Danh sách hoc sinh";
                app.Visible = true;//cho hiển thị excel
                #endregion===========khởi tạo excel==========
                #region ===========đổ dữ liệu vào sheet======
                worksheet.Cells[1, 1] = "SỞ GIÁO DỤC VÀ ĐÀO TẠO HÀ NỘI";
                worksheet.Cells[2, 1] = "TRƯỜNG MẦM NON HOA LINH";


                worksheet.Cells[4, 1] = "DANH SÁCH HỌC SINH";
                worksheet.Cells[5, 1] = "Năm học:" + cbbNamhoc.Text;
                worksheet.Cells[6, 1] = "Khối:" + cbbKhoihoc.Text;
                worksheet.Cells[7, 1] = "Lớp:" + cbbLophoc.Text;

                worksheet.Cells[9, 1] = "STT";
                worksheet.Cells[9, 2] = "Mã học sinh";
                worksheet.Cells[9, 3] = "Họ";
                worksheet.Cells[9, 4] = "Tên";
                worksheet.Cells[9, 5] = "Ngày sinh";
                worksheet.Cells[9, 6] = "Giới tính";
                worksheet.Cells[9, 7] = "Địa chỉ";
                worksheet.Cells[9, 8] = "Tình trạng";
                worksheet.Cells[9, 9] = "Tổng thu";

                //duyệt dết các dòng trong trong gridcontrol
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    #region ==== tinh tien hoc tung hoc sinh======
                    ReceivableDetail_StudentDAO dt = new ReceivableDetail_StudentDAO();
                    ReceivableDetailDAO dc = new ReceivableDetailDAO();
                    List<ReceivableDetail_Student> a = new List<ReceivableDetail_Student>();
                    List<ReceivableDetail> b = new List<ReceivableDetail>();
                    decimal tong = 0;
                    a = dt.ListReceivableDetail_Student((int)gridView1.GetRowCellValue(i, gridView1.Columns["StudentID"]));
                    foreach (var j in a)
                    {
                        ReceivableDetail c = new ReceivableDetail();
                        c = dc.ReceivableDetaiByStudenID(j.ReceivableDetailID, (int)cbbDotthu.SelectedValue);
                        if (c != null)
                        {
                            tong += (decimal)c.TotalPriceDetail;
                            b.Add(c);
                        }

                    }


                    foreach (var j in b)
                    {
                        string mg = j.PreferredID;
                        List<string> b1 = new List<string>();
                        int perferredID = (int)gridView1.GetRowCellValue(i, gridView1.Columns["PreferredID"]);
                        for (int sj = 0; sj < (mg.Length - 1); sj += 2)
                        {

                            string c = mg.Substring(sj, 1);
                            b1.Add(c);
                        }
                        if (b1.Count == 0)
                        {
                            worksheet.Cells[10 + i, 9] = tong;
                        }
                        else
                        {
                            foreach (var k in b1)
                            {
                                if (int.Parse(k) == perferredID)
                                {
                                    PreferredDAO dv = new PreferredDAO();
                                    float pr = dv.lookPreferredPercent(perferredID);
                                    tong = tong - (((decimal)j.TotalPriceDetail * (decimal)pr) / 100);
                                    worksheet.Cells[10 + i, 9] = tong;
                                    break;
                                }
                                worksheet.Cells[10 + i, 9] = tong;
                            }
                        }
                    }

                    //  grDanhsachkhoanthu.DataSource = b;
                    #endregion ==== tinh tien hoc tung hoc sinh====
                    #region---- thong tin hoc sinh----
                    worksheet.Cells[10 + i, 1] = i + 1;
                    worksheet.Cells[10 + i, 2] = gridView1.GetRowCellValue(i, gridView1.Columns["StudentCode"]);
                    worksheet.Cells[10 + i, 3] = gridView1.GetRowCellValue(i, gridView1.Columns["FirstName"]);
                    worksheet.Cells[10 + i, 4] = gridView1.GetRowCellValue(i, gridView1.Columns["LastName"]);
                    worksheet.Cells[10 + i, 5] = gridView1.GetRowCellValue(i, gridView1.Columns["Birthday"]);
                    if ((bool)gridView1.GetRowCellValue(i, gridView1.Columns["Gender"]) == true)
                    {
                        worksheet.Cells[10 + i, 6] = "Nam";
                    }
                    else
                    {
                        worksheet.Cells[10 + i, 6] = "Nữ";
                    }
                    //worksheet.Cells[10 + i, 6] = gridView1.GetRowCellValue(i, gridView1.Columns["Gender"]);
                    worksheet.Cells[10 + i, 7] = gridView1.GetRowCellValue(i, gridView1.Columns["AdressDetail"]);
                    worksheet.Cells[10 + i, 8] = gridView1.GetRowCellValue(i, gridView1.Columns["tinhtrang"]);
                    #endregion---thong tin hoc sinh------
                }
                int dongData = gridView1.RowCount;
                worksheet.Cells[dongData + 13, 8] = "Hà Nội, ngày          tháng           năm            . ";
                worksheet.Cells[dongData + 14, 8] = "HIỆU TRƯỞNG. ";
                #endregion============đổ dữ liệu vào sheet=======
                #region=====căn chỉnh======
                //định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait; // Giấy dọc
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // Loại giấy A4
                worksheet.PageSetup.LeftMargin = 0;//can le trai
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;
                worksheet.PageSetup.CenterHorizontally = true;//can giua theo chieu ngang
                                                              //dinh dang cot
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
                //dinh dang font chu
                worksheet.Range["A1", "K100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "K100"].Font.Size = 10; // size cho font chữ
                worksheet.Range["A4", "K4"].Font.Size = 12; // Size tiêu đề lớn hơn chút
                worksheet.Range["A1", "K2"].Font.Size = 16; // Size tiêu đề lớn hơn chút
                worksheet.Range["A5", "K7"].Font.Size = 12;

                worksheet.Range["A1", "I1"].MergeCells = true; // Nhập dòng tiêu đề
                worksheet.Range["A2", "I2"].MergeCells = true;
                worksheet.Range["A4", "I4"].MergeCells = true;
                worksheet.Range["A5", "I5"].MergeCells = true;
                worksheet.Range["A6", "I6"].MergeCells = true;
                worksheet.Range["A7", "I7"].MergeCells = true;

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

        #endregion======excell===========

        private void bntXuatdanhsach_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            export();
            SplashScreenManager.CloseForm();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle%2==0)
            {
                e.Appearance.BackColor = Color.FromArgb(245, 245, 245);
            }
        }
    }
}
