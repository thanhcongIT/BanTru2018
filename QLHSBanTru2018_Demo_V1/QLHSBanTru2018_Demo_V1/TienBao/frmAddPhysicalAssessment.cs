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
    public partial class frmAddPhysicalAssessment : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.PhysicalAssessment physicalAssessment;
        public frmAddPhysicalAssessment()
        {
            InitializeComponent();
        }

        #region LoadDAO
        private void PhysicalInsert()
        {

            if (txtPhysicalName.Text != "" &&
             txtNotePhysical.Text != "" &&
             dtPhysicalDate.Text != "")
            {
                DataConnect.PhysicalAssessment entity = new DataConnect.PhysicalAssessment();
                entity.Date = DateTime.Parse(dtPhysicalDate.EditValue.ToString());
                entity.Name = txtPhysicalName.Text;
                entity.Note = txtNotePhysical.Text;
        
                entity.Status =  true;

                PhysicalAssessmentDAO m_PhysicalDAO = new PhysicalAssessmentDAO();
                if (iFunction == 1)
                {
                    if (m_PhysicalDAO.PhysicalInsert(entity) == true)
                    {
                        XtraMessageBox.Show("Thêm đợt cân đo thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    entity.PhysicalAssessmentID = physicalAssessment.PhysicalAssessmentID;
                    if (m_PhysicalDAO.PhysicalUpdate(entity) == true)
                    {
                        XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadPhysical()
        {
            txtPhysicalName.Text = physicalAssessment.Name;
            txtNotePhysical.Text = physicalAssessment.Note;
            dtPhysicalDate.EditValue = physicalAssessment.Date;
        }
        #endregion

        #region Event
        private void frmAddPhysicalAssessment_Load(object sender, EventArgs e)
        {

            if (iFunction == 1)
            {
                this.Text = "Thêm mới đợt cân đo";

            }
            else if (iFunction == 2)
            {
                this.Text = "Cập nhật kết quả cân đo";

                loadPhysical();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            PhysicalInsert();
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { this.Close(); }
        }
        #endregion

    }
}