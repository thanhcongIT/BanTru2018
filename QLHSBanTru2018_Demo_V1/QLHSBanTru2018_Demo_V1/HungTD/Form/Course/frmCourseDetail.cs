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
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Course
{
    public partial class frmCourseDetail : DevExpress.XtraEditors.XtraForm
    {
        public int Function = 0;
        public DataConnect.Course course;
        public DataConnect.Semester semester1;
        public DataConnect.Semester semester2;
        public frmCourseDetail()
        {
            InitializeComponent();
        }

        private void frmCourseDetail_Load(object sender, EventArgs e)
        {
            if (Function == 2)
            {
                try
                {
                    txtName.Text = course.Name;
                    dtStartDate.EditValue = course.StartDate;
                    dtEndDate.EditValue = course.EndDate;
                    chbStatus.Checked = course.Status == true ? true : false;

                    semester1 = new SemesterDAO().ListByCourseID(course.CourseID)[0];
                    semester2 = new SemesterDAO().ListByCourseID(course.CourseID)[1];

                    txtKy1.Text = semester1.Name;
                    txtKy2.Text = semester2.Name;

                    dtKy1StartDate.EditValue = semester1.StartDate;
                    dtKy1EndDate.EditValue = semester1.EndDate;

                    dtKy2StartDate.EditValue = semester2.StartDate;
                    dtKy2EndDate.EditValue = semester2.EndDate;
                }
                catch
                {

                }
            }
            else
            {
                dtStartDate.EditValue = DateTime.Now;
                dtEndDate.EditValue = DateTime.Now;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" ||
                dtStartDate.EditValue != null ||
                dtEndDate.EditValue != null)
            {
                DataConnect.Course entity = new DataConnect.Course();
                entity.Name = txtName.Text;
                entity.StartDate = DateTime.Parse(dtStartDate.EditValue.ToString());
                entity.EndDate = DateTime.Parse(dtEndDate.EditValue.ToString());
                entity.Status = chbStatus.Checked == true ? true : false;
                if (Function == 1)
                {
                    int result = new CourseDAO().Insert(entity);
                    if (result > 0)
                    {
                        DataConnect.Semester se1 = new DataConnect.Semester();
                        se1.Name = txtKy1.Text;
                        se1.CourseID = result;
                        se1.StartDate = DateTime.Parse(dtKy1StartDate.EditValue.ToString());
                        se1.EndDate = DateTime.Parse(dtKy1EndDate.EditValue.ToString());
                        se1.Status = entity.Status;

                        DataConnect.Semester se2 = new DataConnect.Semester();
                        se2.Name = txtKy2.Text;
                        se2.CourseID = result;
                        se2.StartDate = DateTime.Parse(dtKy2StartDate.EditValue.ToString());
                        se2.EndDate = DateTime.Parse(dtKy2EndDate.EditValue.ToString());
                        se2.Status = entity.Status;

                        if (new SemesterDAO().Insert(se1) == true && new SemesterDAO().Insert(se2) == true)
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else if (Function == 2)
                {
                    entity.CourseID = course.CourseID;
                    if (new CourseDAO().Edit(entity) == true)
                    {
                        DataConnect.Semester se1 = new SemesterDAO().ListByCourseID(entity.CourseID)[0];

                        se1.Name = txtKy1.Text;
                        se1.CourseID = entity.CourseID;
                        se1.StartDate = DateTime.Parse(dtKy1StartDate.EditValue.ToString());
                        se1.EndDate = DateTime.Parse(dtKy1EndDate.EditValue.ToString());
                        se1.Status = entity.Status;

                        DataConnect.Semester se2 = new SemesterDAO().ListByCourseID(entity.CourseID)[1];
                        se2.Name = txtKy2.Text;
                        se2.CourseID = entity.CourseID;
                        se2.StartDate = DateTime.Parse(dtKy2StartDate.EditValue.ToString());
                        se2.EndDate = DateTime.Parse(dtKy2EndDate.EditValue.ToString());
                        se2.Status = entity.Status;

                        if (new SemesterDAO().Edit(se1) == true && new SemesterDAO().Edit(se2) == true)
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (Function == 1)
            {
                txtKy1.Text = "Kỳ 1 năm học " + txtName.Text;
                txtKy2.Text = "Kỳ 2 năm học " + txtName.Text;
            }
        }

        private void dtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Function == 1)
            {
                dtKy1StartDate.EditValue = dtStartDate.EditValue;
                dtKy1EndDate.EditValue = dtStartDate.EditValue;
                dtKy2StartDate.EditValue = dtKy1EndDate.EditValue;
            }
        }

        private void dtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Function == 1)
                dtKy2EndDate.EditValue = dtEndDate.EditValue;
        }

        private void dtKy1EndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (Function == 1)
                dtKy2StartDate.EditValue = dtKy1EndDate.EditValue;
        }
    }
}