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
using DataConnect.ViewModel;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.Drawing;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmHealthExaminationDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region System
        public frmHealthExaminationDetail()
        {
            InitializeComponent();
        }
        #endregion

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
        private void LoadHealthExaminationInfor()
        {            
            cmbHealthExam.DataSource = new HealthExaminationDetailDAO().ListHealthExamination(); ;
            cmbHealthExam.DisplayMember = "HealthExaminationName";
            cmbHealthExam.ValueMember = "HealthExaminationID";
        }
        private void FillGridControl(int ClassID, int HealthExaminationID)
        {
            try
            {
                dgvHealthDetail.DataSource = new HealthExaminationDetailDAO().ListHealthDetail(ClassID, HealthExaminationID);

            }
            catch
            { }
        }
        private void Danhsach(int ClassID)
        {
            try
            {
                dgvHealthDetail.DataSource = new HealthExaminationDetailDAO().ListStudent(ClassID);

            }
            catch
            { }
        }
        private void ListGridView(int ClassID, int HealthExaminationID)
        {
            try
            {
                dgvHealthDetail.DataSource = new HealthExaminationDetailDAO().ListGridView(ClassID, HealthExaminationID);

            }
            catch
            { }
        }


        #endregion

        #region EvenClass
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


        #endregion

        #region Event

        private void frmHealthExaminationDetail_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            
        }
        private void cmbHealthExam_Click(object sender, EventArgs e)
        {
            LoadHealthExaminationInfor();
        }

        private void cmbNamHoc_Click(object sender, EventArgs e)
        {
            LoadCourseInfor();
        }
        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            if (cmbHealthExam.SelectedValue == null )
            {
                XtraMessageBox.Show("Mời bạn chọn đợt khám sức khỏe", "Thông báo");
               
            }
            else if(cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn lớp học", "Thông báo" );
            }
            else
            {
                FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbHealthExam.SelectedValue.ToString()));
            }
        }
        private void cmbHealthExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn lớp học", "Thông báo");
            }
            else
            {
                try
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbHealthExam.SelectedValue.ToString()));
                }
                catch
                { }
            }
            
        }
        private void btnNhapds_Click(object sender, EventArgs e)
        {
            if (cmbHealthExam.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn đợt khám sức khỏe", "Thông báo");

            }
            else if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn lớp học", "Thông báo");
            }
            else
            {
                frmNewHealthExamDetail m_frmNewHealth = new frmNewHealthExamDetail();

                m_frmNewHealth.iFunction = 1;
                m_frmNewHealth.healthExamination = new HealthExaminationDAO().GetByID(int.Parse(cmbHealthExam.SelectedValue.ToString()));
                m_frmNewHealth.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_frmNewHealth.ShowDialog();
                if (m_frmNewHealth.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbHealthExam.SelectedValue.ToString()));
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dong = gridView1.FocusedRowHandle;
            string StudentID = gridView1.GetRowCellValue(dong, gridView1.Columns["StudentID"]).ToString();
            string DetailID = gridView1.GetRowCellValue(dong, gridView1.Columns["HealthExaminationDetailID"]).ToString();
            frmAddHealthExaminationDetail m_addHealthDetail = new frmAddHealthExaminationDetail();
            m_addHealthDetail.iFunction = 2;
            m_addHealthDetail.healthExamination = new HealthExaminationDAO().GetByID(int.Parse(cmbHealthExam.SelectedValue.ToString()));
            m_addHealthDetail.m_HealthExaminationDetail = new HealthExaminationDetailDAO().GetByID(int.Parse(DetailID.ToString()));
            m_addHealthDetail.Student = new StudentDAO().GetByID(int.Parse(StudentID.ToString()));
            m_addHealthDetail.ShowDialog();
            if (m_addHealthDetail.DialogResult == DialogResult.OK)
            {
                FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbHealthExam.SelectedValue.ToString()));
            }
        }

       

        //------------------Gridview_Button------------------
        private void btnchinhsua_Click(object sender, EventArgs e)
        {
            int dong = gridView1.FocusedRowHandle;
            string StudentID = gridView1.GetRowCellValue(dong, gridView1.Columns["StudentID"]).ToString();
            string DetailID = gridView1.GetRowCellValue(dong, gridView1.Columns["HealthExaminationDetailID"]).ToString();
            frmAddHealthExaminationDetail m_addHealthDetail = new frmAddHealthExaminationDetail();
            m_addHealthDetail.iFunction = 2;
            m_addHealthDetail.healthExamination = new HealthExaminationDAO().GetByID(int.Parse(cmbHealthExam.SelectedValue.ToString()));
            m_addHealthDetail.m_HealthExaminationDetail = new HealthExaminationDetailDAO().GetByID(int.Parse(DetailID.ToString()));
            m_addHealthDetail.Student = new StudentDAO().GetByID(int.Parse(StudentID.ToString()));
            m_addHealthDetail.ShowDialog();
            if (m_addHealthDetail.DialogResult == DialogResult.OK)
            {
                FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbHealthExam.SelectedValue.ToString()));
            }
        }
        private void btnXoahs_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa học sinh này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int dong = gridView1.FocusedRowHandle;
                string HealthDetailID = gridView1.GetRowCellValue(dong, gridView1.Columns["HealthExaminationDetailID"]).ToString();
                new HealthExaminationDetailDAO().HealthDetailDelete(int.Parse(HealthDetailID.ToString()));
                if (XtraMessageBox.Show(" Xóa học sinh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbHealthExam.SelectedValue.ToString()));
                }
            }
        }
        //------------------Gridview_Button------------------


        #endregion

        #region STT
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = sText;
                }
                //if (!indicatorIcon)
                //    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 13;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "";

                }
            }
            catch 
            {
            }
        }
        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }



        #endregion

       
    }
}
