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
    public partial class frmPhysicalDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.Class Class;
        public DataConnect.Course Coursetable;
        public DataConnect.PhysicalAssessmentDetail m_PhysicalDetailTable;
        public DataConnect.PhysicalAssessment m_PhysicalTable;
        PhysicalAssessmentDAO m_PhysicalDAO = new PhysicalAssessmentDAO();
        PhysicalAssessmentDetailDAO m_PhysicalDetailDAO = new PhysicalAssessmentDetailDAO();

        public frmPhysicalDetail()
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

        private void Danhsach(int ClassID)
        {
            try
            {
                dgvPhysicalDetail.DataSource = new PhysicalAssessmentDetailDAO().ListStudent(ClassID);
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
        private void cmbLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Danhsach(int.Parse(cmbLopHoc.SelectedValue.ToString()));

            }
            catch
            { }
        }

        #endregion

        #region LoadDAO
        private void PhysicalInsert()
        {
            if (txtPhysicalName.Text != "" &&
             txtNotePhysical.Text != "" &&
             dtPhysicalDate.Text != "")
            {
                DataConnect.PhysicalAssessment entity = new DataConnect.PhysicalAssessment();
                DataConnect.PhysicalAssessmentDetail entity2 = new DataConnect.PhysicalAssessmentDetail();

                entity.Date = DateTime.Parse(dtPhysicalDate.EditValue.ToString());
                entity.Name = txtPhysicalName.Text;
                entity.Note = txtNotePhysical.Text;
                entity.Status = true; //chbStatus.Checked ? true : false;

                if (iFunction == 1)
                {
                    int NewPhysicalID = m_PhysicalDAO.PhysicalInsert(entity);
                    if (NewPhysicalID > 0)
                    {
                        for (int i = 0; i < bandedGridView1.RowCount; i++)
                        {
                            entity2.PhysicalAssessmentID = NewPhysicalID;
                            entity2.StudentID = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["StudentID"]).ToString());
                            entity2.Height = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Height"]).ToString());
                            entity2.Weight = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Weight"]).ToString());
                            entity2.HeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["HeightRating"]).ToString();
                            entity2.WeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["WeightRating"]).ToString();
                            entity2.Note = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["NoteDetail"]).ToString();
                            entity2.Status = true;
                            if (m_PhysicalDetailDAO.PhysicalDetailInsert(entity2) == true)
                            {

                            }
                            else
                            {
                                XtraMessageBox.Show("Bản ghi " + i + "bị lỗi");
                                break;
                            }
                        }
                        XtraMessageBox.Show("Thêm kết quả cân đo thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (iFunction == 2)
                {
                    for (int i = 0; i < bandedGridView1.RowCount; i++)
                    {
                        entity.PhysicalAssessmentID = m_PhysicalTable.PhysicalAssessmentID;
                        entity2.PhysicalAssessmentDeailID = (int)(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["PhysicalAssessmentDetailID"]));
                        entity2.PhysicalAssessmentID = m_PhysicalTable.PhysicalAssessmentID;
                        entity2.StudentID = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["StudentID"]).ToString());
                        entity2.Height = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Height"]).ToString());
                        entity2.Weight = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Weight"]).ToString());
                        entity2.HeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["HeightRating"]).ToString();
                        entity2.WeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["WeightRating"]).ToString();
                        entity2.Note = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["NoteDetail"]).ToString();
                        entity2.Status = true;
                        if (m_PhysicalDAO.PhysicalUpdate(entity) == true && m_PhysicalDetailDAO.PhysicalDetailUpdate(entity2) == true)
                        {

                        }
                        else
                        {
                            XtraMessageBox.Show("Bản ghi " + i + "bị lỗi");
                            break;
                        }
                    }
                    XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void FillGridControl(int ClassID, int PhysicalAssessmentID)
        {
            try
            {
                dgvPhysicalDetail.DataSource = new PhysicalAssessmentDetailDAO().ListPhysicalDetail(ClassID, PhysicalAssessmentID);

            }
            catch
            { }
        }
        private void loadPhysicalDetail()
        {

            txtPhysicalName.Text = m_PhysicalTable.Name;
            txtNotePhysical.Text = m_PhysicalTable.Note;
            dtPhysicalDate.EditValue = m_PhysicalTable.Date;
            FillGridControl(Class.ClassID, m_PhysicalTable.PhysicalAssessmentID);
        }
        #endregion

        #region Event
        private void frmPhysicalDetail_Load(object sender, EventArgs e)
        {
            if (iFunction == 1)
            {
                this.Text = "Thêm mới đợt cân đo";

            }
            else if (iFunction == 2)
            {
                this.Text = "Cập nhật kết quả cân đo";
                cmbLopHoc.Enabled = false;
                cmbKhoiLop.Enabled = false;
                cmbHocKy.Enabled = false;
                cmbNamHoc.Enabled = false;
                loadPhysicalDetail();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            PhysicalInsert();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { this.Close(); }
           
        }

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (tabbedControlGroup1.TabPages.Count > tabbedControlGroup1.SelectedTabPageIndex + 1)
                tabbedControlGroup1.SelectedTabPageIndex += 1;
        }
        
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            if (0 <= tabbedControlGroup1.SelectedTabPageIndex - 1)
                tabbedControlGroup1.SelectedTabPageIndex -= 1;
        }
        #endregion

        private void bandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
           
        }
    }
}