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
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.TopicLesson
{
    public partial class frmTopicDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction = 0;
        public Topic topic;
        public void setFunction(int function)
        {
            this.iFunction = function;
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        public void setTopic(int lessonID)
        {
            int topicID = new LessonDAO().GetTopicID(lessonID);
            this.topic = new TopicDAO().GetByTopicID(topicID);
        }
        public frmTopicDetail()
        {
            InitializeComponent();
        }

        private void frmTopicDetail_Load(object sender, EventArgs e)
        {
            FillTopicTypeID();
            FillDisplayOrder();
            LoadDetail();
        }
        private void LoadDetail()
        {
            if (iFunction == 2)
            {
                txtName.Text = topic.Name;
                txtDescription.Text = topic.Description;
                cbbDisplayOrder.SelectedIndex = topic.DisplayOrder - 1;
                chkActive.Checked = topic.Status;
            }
        }
        private void FillTopicTypeID()
        {
            cbbTopicType.DataSource = new TopicTypeDAO().ListAll();
            cbbTopicType.DisplayMember = "Name";
            cbbTopicType.ValueMember = "TopicTypeID";
        }
        private void FillDisplayOrder()
        {
            string[] DisplayDescription = new string[] { "Dễ", "Trung Bình", "Khó" };
            cbbDisplayOrder.DataSource = DisplayDescription;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Topic entity = new Topic();
                entity.Name = txtName.Text;
                entity.TopicTypeID = int.Parse(cbbTopicType.SelectedValue.ToString());
                entity.Description = txtDescription.Text;
                entity.DisplayOrder = int.Parse(cbbDisplayOrder.SelectedIndex.ToString()) + 1;
                entity.Status = chkActive.Checked;
                if (iFunction == 1)
                {
                    if (new TopicDAO().Insert(entity) > 0)
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
                    entity.TopicID = topic.TopicID;
                    if (new TopicDAO().Edit(entity) == true)
                    {
                        MessageBox.Show("Cập nhật công!", "Thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
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