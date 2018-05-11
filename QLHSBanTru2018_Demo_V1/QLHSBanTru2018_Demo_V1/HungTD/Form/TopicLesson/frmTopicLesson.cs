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
using DataConnect.ViewModel;
using QLHSBanTru2018_Demo_V1.HungTD.Form.TopicLesson;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.TopicLession
{
    public partial class frmTopicLesson : DevExpress.XtraEditors.XtraUserControl
    {
        public frmTopicLesson()
        {
            InitializeComponent();
        }
        int lessonID=0;
        private void frmTopicLesson_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillCombobox();
        }
        private void FillGridControls(int topicTypeID)
        {
            gcTopicLesson.DataSource = new LessonDAO().FilterByTopicType(topicTypeID);            
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding("Text", gcTopicLesson.DataSource, "Name"));
            txtDescription.DataBindings.Clear();
            txtDescription.DataBindings.Add(new Binding("Text", gcTopicLesson.DataSource, "Description"));
            txtTopicDescription.DataBindings.Clear();
            txtTopicDescription.DataBindings.Add(new Binding("Text", gcTopicLesson.DataSource, "TopicDescription"));
        }
        private void FillCombobox()
        {
            cbbTopicType.DataSource = new TopicTypeDAO().ListAll();
            cbbTopicType.DisplayMember = "Name";
            cbbTopicType.ValueMember = "TopicTypeID";

            try
            {
                FillGridControls(int.Parse(cbbTopicType.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void cbbTopicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillGridControls(int.Parse(cbbTopicType.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void btnMenuAdd_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void btnMenuEdit_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnMenuDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTopicLessonDetail frmTLD = new frmTopicLessonDetail();
            var rowHandle = view.FocusedRowHandle;
            try
            {
                frmTLD.setLesson(lessonID = Convert.ToInt32(view.GetRowCellValue(rowHandle, "LessonID").ToString()));
            }
            catch
            {
                var rowChild = view.GetChildRowHandle(rowHandle, 0);
                frmTLD.setLesson(lessonID = Convert.ToInt32(view.GetRowCellValue(rowChild, "LessonID").ToString()));
            }
            frmTLD.setFunction(1);
            frmTLD.setTitle("Thêm Mới Bài Giảng");
            frmTLD.ShowDialog();
            if (frmTLD.DialogResult == DialogResult.OK)
                FillCombobox();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTopicLessonDetail frmTLD = new frmTopicLessonDetail();
            var rowHandle = view.FocusedRowHandle;
            try
            {
                frmTLD.setLesson(Convert.ToInt32(view.GetRowCellValue(rowHandle, "LessonID").ToString()));
            }
            catch
            {
                var rowChild = view.GetChildRowHandle(rowHandle,0);
                frmTLD.setLesson(lessonID = Convert.ToInt32(view.GetRowCellValue(rowChild, "LessonID").ToString()));
            }
            frmTLD.setFunction(2);
            frmTLD.setTitle("Chỉnh Sửa Bài Giảng");
            frmTLD.ShowDialog();
            if (frmTLD.DialogResult == DialogResult.OK)
                FillCombobox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa bài giảng " + txtName.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var rowHandle = view.FocusedRowHandle;
                    new LessonDAO().Delete(Convert.ToInt32(view.GetRowCellValue(rowHandle, "LessonID").ToString()));
                }
                catch
                {

                }
                finally
                {
                    FillCombobox();
                }
            }
        }

        private void gcTopicLesson_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            frmTopicDetail frmTD = new frmTopicDetail();
            frmTD.setFunction(1);
            frmTD.setTitle("Thêm Mới Chủ Đề");
            frmTD.ShowDialog();
            if (frmTD.DialogResult == DialogResult.OK)
                FillCombobox();
        }

        private void btnMenuAddTopic_Click(object sender, EventArgs e)
        {
            btnAddTopic_Click(sender, e);
        }

        private void btnEditTopic_Click(object sender, EventArgs e)
        {
            frmTopicDetail frmTD = new frmTopicDetail();
            frmTD.setFunction(2);
            frmTD.setTitle("Cập Nhật Chủ Đề");
            var rowHandle = view.FocusedRowHandle;
            try
            {
                frmTD.setTopic(Convert.ToInt32(view.GetRowCellValue(rowHandle, "LessonID").ToString()));
            }
            catch
            {
                var rowChild = view.GetChildRowHandle(rowHandle, 0);
                frmTD.setTopic(lessonID = Convert.ToInt32(view.GetRowCellValue(rowChild, "LessonID").ToString()));
            }
            frmTD.ShowDialog();
            if (frmTD.DialogResult == DialogResult.OK)
                FillCombobox();
        }
    }
}
