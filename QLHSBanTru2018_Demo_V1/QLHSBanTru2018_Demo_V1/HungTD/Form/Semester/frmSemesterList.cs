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
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Semester
{
    public partial class frmSemesterList : DevExpress.XtraEditors.XtraUserControl
    {
        public frmSemesterList()
        {
            InitializeComponent();
        }
        private void frmSemesterList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            dtEndDate.EditValue = DateTime.Now;
            GetListCourse();
            FillGridControl();
        }
        private void FillGridControl()
        {
            int x = 0;
            try
            {
                x = int.Parse(cbbCourseList.SelectedValue.ToString());
            }
            catch
            {

            }
            gcMain.DataSource = new SemesterDAO().ListAll((DateTime?)dtStartDate.EditValue, (DateTime?)dtEndDate.EditValue, x);
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Name"));
            txtSemesterID.DataBindings.Clear();
            txtSemesterID.DataBindings.Add(new Binding("Text", gcMain.DataSource, "SemesterID"));
            dtStartDate.DataBindings.Clear();
            dtStartDate.DataBindings.Add(new Binding("EditValue", gcMain.DataSource, "StartDate"));
            dtEndDate.DataBindings.Clear();
            dtEndDate.DataBindings.Add(new Binding("EditValue", gcMain.DataSource, "EndDate"));
            txtCourseName.DataBindings.Clear();
            txtCourseName.DataBindings.Add(new Binding("Text", gcMain.DataSource, "CourseName"));
        }
        private void dtFilterStartDate_EditValueChanged(object sender, EventArgs e)
        {
            FillGridControl();
        }
        private void dtFilterEndDate_EditValueChanged(object sender, EventArgs e)
        {
            FillGridControl();
        }
        private void GetListCourse()
        {
            List<DataConnect.Course> listCourse = new CourseDAO().ListAll();
            listCourse.Add(new DataConnect.Course
            {
                CourseID = 0,
                Name = "Chọn năm học",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = true
            });
            cbbCourseList.DataSource = listCourse;
            cbbCourseList.DisplayMember = "Name";
            cbbCourseList.ValueMember = "CourseID";
            cbbCourseList.SelectedValue = 0;
        }
        private void cbbCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FillGridControl();
        }
    }
}
