using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Department;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Employee;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Position;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Course;
using QLHSBanTru2018_Demo_V1.QLThuChi;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Function;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Contract;
using QLHSBanTru2018_Demo_V1.TienBao;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Semester;
using QLHSBanTru2018_Demo_V1.HungTD.Form.TopicLession;
using QLHSBanTru2018_Demo_V1.HungTD.Form.WorkProgress;
using QLHSBanTru2018_Demo_V1.DAO.HungTD;
using QLHSBanTru2018_Demo_V1.Common;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Ingredient;
using QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu;
using QLHSBanTru2018_Demo_V1.HungTD.Form.Dish;

namespace QLHSBanTru2018_Demo_V1
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            labNameLogin.Caption = "Nhân Viên Đăng Nhập: " + LoginDetail.LoginName;
        }
        #region Trần Đức Hùng
        private void btnDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmDepartmentList());
            labTitle.Caption = "QUẢN LÝ PHÒNG BAN";
        }

        private void btnEmployeeManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmEmployeeList());
            labTitle.Caption = "QUẢN LÝ NHÂN VIÊN";
        }
        private void btnPosition_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmPositionList());
            labTitle.Caption = "QUẢN LÝ CHỨC VỤ";
        }

        private void btnCourse_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmCourseList());
            labTitle.Caption = "QUẢN LÝ NĂM HỌC";
        }

        private void btnAddFunction_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmFunctionList().ShowDialog();
        }

        private void btnContractManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmContractList());
            labTitle.Caption = "QUẢN LÝ HỢP ĐỒNG";
        }

        private void btnSemester_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmSemesterList());
            labTitle.Caption = "QUẢN LÝ KỲ HỌC";
        }
        private void btnTopicLesson_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmTopicLesson());
            labTitle.Caption = "QUẢN LÝ BÀI GIẢNG";
        }
        private void btnWorkProgress_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmWorkProgressList());
            labTitle.Caption = "QUẢN LÝ QUÁ TRÌNH CÔNG TÁC";
        }
        private void btnIngredientType_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmIngredientType());
            labTitle.Caption = "QUẢN LÝ LOẠI THỰC PHẨM";
        }
        private void btnIngredient_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmIngredient());
            labTitle.Caption = "QUẢN LÝ THỰC PHẨM";
        }

        private void btnDishManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(new frmDish());
            labTitle.Caption = "QUẢN LÝ MÓN ĂN";
        }
        #endregion

        #region s2s2s2s2 Nguyễn Kiều Thành Công s2s2s2
        private void bntDotThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            UsDotThuPhi a = new UsDotThuPhi();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(a);
            a.Dock = DockStyle.Fill;
        }

        private void bntThuTheoLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            USCacKhoanThuTheoLop a = new USCacKhoanThuTheoLop();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(a);
            a.Dock = DockStyle.Fill;
        }

        private void bntCackhoanchi_ItemClick(object sender, ItemClickEventArgs e)
        {
            UsKhoanChi a = new UsKhoanChi();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(a);
            a.Dock = DockStyle.Fill;
        }
        private void btnDanhMucChiTieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrLoaiChi a = new FrLoaiChi();
            a.ShowDialog();
        }
        private void btnLoaichi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrLoaiChi a = new FrLoaiChi();
            a.ShowDialog();
        }
        private void btnDoituongchinhsach_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRDienMienGiam a = new FRDienMienGiam();
            a.ShowDialog();
        }
        #endregion

        #region Nguyễn Tiến Bảo
        private void btnTTHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStudent m_Student = new frmStudent();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_Student);
            m_Student.Dock = DockStyle.Fill;
        }

        private void btnTKHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmStudentACC m_Studentacc = new frmStudentACC();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_Studentacc);
            m_Studentacc.Dock = DockStyle.Fill;
        }
        private void btnImportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImportExcel m_frmImportExcel = new frmImportExcel();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_frmImportExcel);
            m_frmImportExcel.Dock = DockStyle.Fill;
        }
        private void btnHealthProblem_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHealthProblem m_frmHealthProblem = new frmHealthProblem();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_frmHealthProblem);
            m_frmHealthProblem.Dock = DockStyle.Fill;
        }

        private void btnCanDo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhysicalAssessment m_frmPhysicalAssessment = new frmPhysicalAssessment();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_frmPhysicalAssessment);
            m_frmPhysicalAssessment.Dock = DockStyle.Fill;
        }

        private void btnHealthExam_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHealthExamination m_frmHealthExam = new frmHealthExamination();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_frmHealthExam);
            m_frmHealthExam.Dock = DockStyle.Fill;
        }
        private void btnHealthExaminationDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHealthExaminationDetail m_frmHealthExamDetail = new frmHealthExaminationDetail();
            pnControlsPanel.Controls.Clear();
            pnControlsPanel.Controls.Add(m_frmHealthExamDetail);
            m_frmHealthExamDetail.Dock = DockStyle.Fill;
        }




        #endregion

        #region Vũ Đức Thiện

        #endregion
    }
}