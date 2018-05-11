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
using DataConnect;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.TopicLesson
{
    public partial class frmTopicLessonDetail : DevExpress.XtraEditors.XtraForm
    {
        Lesson lesson;
        int iFunction = 0;
        public void setLesson(int lessonID)
        {
            lesson = new LessonDAO().GetByID(lessonID);
        }
        public void setFunction(int iFunction)
        {
            this.iFunction = iFunction;
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        public frmTopicLessonDetail()
        {
            InitializeComponent();
        }

        private void frmTopicLessonDetail_Load(object sender, EventArgs e)
        {
            FillTopicTypeID();
            FillDisplayOrder();
            LoadDetail();
        }
        private void LoadDetail()
        {
            cbbTopicTypeID.SelectedValue = new TopicDAO().GetTopicTypeID(new LessonDAO().GetTopicID(lesson.LessonID));
            cbbTopicID.SelectedValue = new LessonDAO().GetTopicID(lesson.LessonID);
            if (iFunction == 2)
            {
                txtName.Text = lesson.Name;
                txtDescription.Text = lesson.Name;
                cbbDisplayOrder.SelectedIndex = lesson.DisplayOrder - 1;
                chkActive.Checked = lesson.Status;
            }
        }
        private void FillTopicTypeID()
        {
            //Lứa tuổi
            cbbTopicTypeID.DataSource = new TopicTypeDAO().ListAll();
            cbbTopicTypeID.DisplayMember = "Name";
            cbbTopicTypeID.ValueMember = "TopicTypeID";

            try
            {
                FillTopicID(int.Parse(cbbTopicTypeID.SelectedValue.ToString()));
            }
            catch
            {

            }
        }
        private void FillTopicID(int topicTypeID)
        {
            cbbTopicID.DataSource = new TopicDAO().ListByTopicTypeID(topicTypeID);
            cbbTopicID.DisplayMember = "Name";
            cbbTopicID.ValueMember = "TopicID";
        }
        private void FillDisplayOrder()
        {
            string[] DisplayDescription = new string[] { "Dễ", "Trung Bình", "Khó" };
            cbbDisplayOrder.DataSource = DisplayDescription;
        }

        private void cbbTopicTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillTopicID(int.Parse(cbbTopicTypeID.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Lesson entity = new Lesson();
                entity.Name = txtName.Text;
                entity.TopicID = int.Parse(cbbTopicID.SelectedValue.ToString());
                entity.Description = txtDescription.Text;
                entity.DisplayOrder = int.Parse(cbbDisplayOrder.SelectedIndex.ToString()) + 1;
                entity.Status = chkActive.Checked;
                if (iFunction == 1)
                {
                    if (new LessonDAO().Insert(entity) > 0)
                    {
                        MessageBox.Show("Thêm thành công!", "Thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
                    }
                }
                else
                {
                    entity.LessonID = lesson.LessonID;
                    if (new LessonDAO().Edit(entity) == true)
                    {
                        MessageBox.Show("Cập nhật công!", "Thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin Lỗi!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Xin Lỗi!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}