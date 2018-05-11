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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Course
{
    public partial class frmCourseList : DevExpress.XtraEditors.XtraUserControl
    {
        public frmCourseList()
        {
            InitializeComponent();
        }

        private void frmCourseList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcCourseList.DataSource = new CourseDAO().ListAll();
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding("Text", gcCourseList.DataSource, "Name"));
            txtCourseID.DataBindings.Clear();
            txtCourseID.DataBindings.Add(new Binding("Text", gcCourseList.DataSource, "CourseID"));
            dtStartDate.DataBindings.Clear();
            dtStartDate.DataBindings.Add(new Binding("EditValue", gcCourseList.DataSource, "StartDate"));
            dtEndDate.DataBindings.Clear();
            dtEndDate.DataBindings.Add(new Binding("EditValue", gcCourseList.DataSource, "EndDate"));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCourseDetail courseDetail = new frmCourseDetail();
            courseDetail.Function = 1;
            courseDetail.ShowDialog();
            if (courseDetail.DialogResult == DialogResult.OK)
                FillGridControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCourseDetail courseDetail = new frmCourseDetail();
            courseDetail.Function = 2;
            courseDetail.course = new CourseDAO().GetByID(int.Parse(txtCourseID.Text));
            courseDetail.ShowDialog();
            if (courseDetail.DialogResult == DialogResult.OK)
                FillGridControl();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa " + txtName.Text, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (new CourseDAO().Delete(int.Parse(txtCourseID.Text)) == true)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xin lỗi, đã xảy ra lỗi!", "Thông báo");
                }
                FillGridControl();
            }
        }

    }
}
