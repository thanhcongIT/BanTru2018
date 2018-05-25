using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataConnect.DAO.HungTD;
using DataConnect.DAO.TienBao;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmPhysicalAssessment : DevExpress.XtraEditors.XtraUserControl
    {
        public frmPhysicalAssessment()
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
        private void LoadPhysicalAssessmentInfor()
        {
            cmbPhysicalAssessment.Properties.DataSource = new PhysicalAssessmentDAO().ListPhysicalAssessment(); ;
            cmbPhysicalAssessment.Properties.DisplayMember = "NamePhysicalAssessment";
            cmbPhysicalAssessment.Properties.ValueMember = "PhysicalAssessmentID";
        }
        private void FillGridControl(int ClassID, int PhysicalAssessmentID)
        {
            try
            {
                dgvPhysicalAssessment.DataSource = new PhysicalAssessmentDetailDAO().ListPhysicalDetail(ClassID, PhysicalAssessmentID);

            }
            catch
            { }
        }

        #endregion

        #region EventClass
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

        #endregion

        #region Event
        private void frmPhysicalAssessment_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadPhysicalAssessmentInfor();
        }
        private void cmbPhysicalAssessment_EditValueChanged(object sender, EventArgs e)
        {         
             txtPhysicalNote.Text = cmbPhysicalAssessment.GetColumnValue("NotePhysicalAssessment").ToString();
             dtPhysicalDate.Text = cmbPhysicalAssessment.GetColumnValue("DatePhysicalAssessment").ToString();
        }
        
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (cmbPhysicalAssessment.EditValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn đợt cân đo", "Thông báo");
            }
            else if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn lớp học", "Thông báo");
            }
            else
            {
                FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbPhysicalAssessment.EditValue.ToString()));
            }
        }
        
        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (cmbPhysicalAssessment.EditValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn đợt khám cân đo", "Thông báo");
            }
            else if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn lớp học", "Thông báo");
            }
            else
            {
                frmListStudentPhysicalDetail m_frmListStudent = new frmListStudentPhysicalDetail();
                m_frmListStudent.iFunction = 1;
                m_frmListStudent.physicalAssessment = new PhysicalAssessmentDAO().GetByID(int.Parse(cmbPhysicalAssessment.EditValue.ToString()));
                m_frmListStudent.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_frmListStudent.ShowDialog();
                if (m_frmListStudent.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbPhysicalAssessment.EditValue.ToString()));
                }
            }
        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (cmbPhysicalAssessment.EditValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn đợt cân đo", "Thông báo");

            }
            else if (cmbLopHoc.SelectedValue == null)
            {
                XtraMessageBox.Show("Mời bạn chọn lớp học", "Thông báo");
            }
            else
            {
                frmPhysicalDetail m_frmPhysicalDetail = new frmPhysicalDetail();
                m_frmPhysicalDetail.iFunction = 2;
                m_frmPhysicalDetail.m_PhysicalTable = new PhysicalAssessmentDAO().GetByID(int.Parse(cmbPhysicalAssessment.EditValue.ToString()));             
                m_frmPhysicalDetail.Class = new ClassDAO().GetByClassID(int.Parse(cmbLopHoc.SelectedValue.ToString()));
                m_frmPhysicalDetail.ShowDialog();
                if (m_frmPhysicalDetail.DialogResult == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbPhysicalAssessment.EditValue.ToString()));
                }
            }
        }
        private void btnXoaDotCanDo_Click(object sender, EventArgs e)
        {

        }
        private void btnXoahocsinh_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa học sinh này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int dong = bandedGridView1.FocusedRowHandle;
                string PhysicalDetailID = bandedGridView1.GetRowCellValue(dong, bandedGridView1.Columns["PhysicalAssessmentDetailID"]).ToString();
                new PhysicalAssessmentDetailDAO().PhysicalDetailDelete(int.Parse(PhysicalDetailID.ToString()));
                if (XtraMessageBox.Show(" Xóa học sinh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    FillGridControl(int.Parse(cmbLopHoc.SelectedValue.ToString()), int.Parse(cmbPhysicalAssessment.EditValue.ToString()));
                }
            }
        }
        #endregion

        #region STT
        private void bandedGridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
        private void bandedGridView1_RowCountChanged(object sender, EventArgs e)
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
