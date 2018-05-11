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
using DataConnect;
using DataConnect.DAO.ThanhCongTC;

namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    public partial class FrThietLapKeHoachThu : DevExpress.XtraEditors.XtraForm
    {
        public FrThietLapKeHoachThu()
        {
            InitializeComponent();
        }

        private void bntDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadDataKeHoachThu()
        {
            grCacKhoanThu.DataSource = ReceivableDetailDAO.ListDemoReceivableDetail;
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            PreferredDAO.PreferredIDList = "";
            FTaoKhoanThu a = new FTaoKhoanThu();
            a.ShowDialog();
            //LoadDataKeHoachThu();
            grCacKhoanThu.DataSource = ReceivableDetailDAO.ListDemoReceivableDetail;

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

        private void bntSua_Click(object sender, EventArgs e)
        {
            if (ReceivableDetailDAO.DemoReceibavleDetail is null)
            {

            }
            else
            {
                FRSuaKhoanThu a = new FRSuaKhoanThu();
                a.ShowDialog();
            }
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
            // đưa trỏ chuột về dòng đầu tiên
            try
            {
                ReceivableDetail a = new ReceivableDetail();
                a.Name = gridView1.GetRowCellValue(0, "Name").ToString();
                a.Price = decimal.Parse(gridView1.GetRowCellValue(0, "Price").ToString());
                a.Status = true;
                a.TimeUnits = gridView1.GetRowCellValue(0, "TimeUnits").ToString();
                a.Frequency = int.Parse(gridView1.GetRowCellValue(0, "Frequency").ToString());
                a.TotalPriceDetail = decimal.Parse(gridView1.GetRowCellValue(0, "TotalPriceDetail").ToString());
                a.GradeID = (int)gridView1.GetRowCellValue(0, "GradeID");
                a.Feedback = (bool)gridView1.GetRowCellValue(0, "Feedback");
                a.PreferredID = gridView1.GetRowCellValue(0, "PreferredID").ToString();
                PreferredDAO.PreferredIDList = gridView1.GetRowCellValue(0, "PreferredID").ToString();
                ReceivableDetailDAO.DemoReceibavleDetail = a;
            }
            catch 
            {

                
            }
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
        private void FrThietLapKeHoachThu_Load(object sender, EventArgs e)
        {
            LoadNamhoc();
            //LoadHocky();
        }

        private void bntKhoitao_Click(object sender, EventArgs e)
        {
            if (txtTendotthu.Text=="")
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin đợt thu");
            }
            else
            {
                if (cbbHocky.Text!="")
                {
                    try
                    {
                        // thêm đợt thu
                        ReceivableIDAO rb = new ReceivableIDAO();
                        ReceivableDetailDAO rbd = new ReceivableDetailDAO();
                        Receivable rbdt = new Receivable();
                        rbdt.Name = txtTendotthu.Text;
                        rbdt.CourseID = (int)cbbNamhoc.SelectedValue;
                        rbdt.SemesterID = (int)cbbHocky.SelectedValue;
                        rbdt.StartDate = dtNgaybatdau.Value;
                        rbdt.EndDate = dtNgayketthuc.Value;
                        rbdt.CreatedDate = dtNgaykhoitao.Value;
                        rbdt.Note = txtGhiChu.Text;
                        rbdt.Status = false;
                        int c = rb.Insert(rbdt);
                        // thêm khoản thu
                        if (c != 0)
                        {
                            ReceivableDetail detail = new ReceivableDetail();
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                detail.Name = gridView1.GetRowCellValue(i, gridView1.Columns["Name"]).ToString();
                                detail.ReceivableID = c;
                                detail.Price = (decimal)gridView1.GetRowCellValue(i, gridView1.Columns["Price"]);
                                detail.Status = false;
                                detail.TimeUnits = gridView1.GetRowCellValue(i, gridView1.Columns["TimeUnits"]).ToString();
                                detail.Frequency = (int)gridView1.GetRowCellValue(i, gridView1.Columns["Frequency"]);
                                detail.TotalPriceDetail = (decimal)gridView1.GetRowCellValue(i, gridView1.Columns["TotalPriceDetail"]);
                                detail.GradeID = (int)gridView1.GetRowCellValue(i, gridView1.Columns["GradeID"]);
                                detail.Feedback = (bool)gridView1.GetRowCellValue(i, gridView1.Columns["Feedback"]);
                                detail.PreferredID = gridView1.GetRowCellValue(i, gridView1.Columns["PreferredID"]).ToString();
                                int d = rbd.Insert(detail);
                                if (d != 0)
                                {
                                    //thêm khoản thu học cho học sinh theo lớp hiện hành
                                    StudenGrade gr = new StudenGrade();
                                    ReceivableDetail_StudentDAO st = new ReceivableDetail_StudentDAO();
                                    List<Student_Class> listClassID = gr.lookStudenbyGradeID((int)detail.GradeID);
                                    foreach (var j in listClassID)
                                    {
                                        if (j.Status==true)
                                        {
                                            ReceivableDetail_Student dt = new ReceivableDetail_Student();
                                            dt.ReceivableDetailID = d;
                                            dt.StudentID = j.StudentID;
                                            dt.Status = false;
                                            if (st.Insert(dt) == true)
                                            {

                                            }
                                            else
                                            {
                                                MessageBox.Show("ban gi bi loi");
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Ban ghi " + i + " bi loi");
                                }
                            }
                            MessageBox.Show("Khoi tao hoan tat");
                            this.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Loi");

                    }
                }
            }
        }

        private void bntDoituongchinhsach_Click(object sender, EventArgs e)
        {
            FRDienMienGiam a = new FRDienMienGiam();
            a.ShowDialog();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ReceivableDetail a = new ReceivableDetail();
                a.Name = gridView1.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
                a.Price = decimal.Parse(gridView1.GetRowCellValue(e.FocusedRowHandle, "Price").ToString());
                a.Status = true;
                a.TimeUnits = gridView1.GetRowCellValue(e.FocusedRowHandle, "TimeUnits").ToString();
                a.Frequency = int.Parse(gridView1.GetRowCellValue(e.FocusedRowHandle, "Frequency").ToString());
                a.TotalPriceDetail = decimal.Parse(gridView1.GetRowCellValue(e.FocusedRowHandle, "TotalPriceDetail").ToString());
                a.GradeID = (int)gridView1.GetRowCellValue(e.FocusedRowHandle, "GradeID");
                a.Feedback = (bool)gridView1.GetRowCellValue(e.FocusedRowHandle, "Feedback");
                a.PreferredID = gridView1.GetRowCellValue(e.FocusedRowHandle, "PreferredID").ToString();
                PreferredDAO.PreferredIDList = gridView1.GetRowCellValue(e.FocusedRowHandle, "PreferredID").ToString();
                ReceivableDetailDAO.DemoReceibavleDetail = a;
                studentReceivableDAO.TherowFocust = gridView1.FocusedRowHandle;
            }
            catch 
            {

                
            }
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + gridView1.FocusedRowHandle + "");
            ReceivableDetailDAO.ListDemoReceivableDetail.RemoveAt(gridView1.FocusedRowHandle);
            
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

        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void cbbNamhoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadHocky();
        }
    }
}