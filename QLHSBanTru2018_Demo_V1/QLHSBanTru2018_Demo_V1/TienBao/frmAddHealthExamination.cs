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
    public partial class frmAddHealthExamination : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.HealthExamination m_HealthExamTable;

        #region System
        public frmAddHealthExamination()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadDAO
        private void HealthExamInsert()
        {
            if (txtNameExam.Text != "" &&
             txtPlaceExam.Text != "" &&
             dtDateExam.Text != "" )
            {
                DataConnect.HealthExamination entity = new DataConnect.HealthExamination();
                entity.Date = DateTime.Parse(dtDateExam.EditValue.ToString());
                entity.Name = txtNameExam.Text;
                entity.Place = txtPlaceExam.Text;
                entity.Height = chbHeight.Checked ? true : false;
                entity.Weight = chbWeight.Checked ? true : false;
                entity.Eyes = chbEyes.Checked ? true : false;
                entity.ENT = chbENT.Checked ? true : false;
                entity.Oral = chbOral.Checked ? true : false;
                entity.InternalMedicine = chbInternalMedicine.Checked ? true : false;
                entity.Surgery = chbSurgery.Checked ? true : false;
                entity.Dermatology = chbDermatology.Checked ? true : false;
                entity.BoneMuscle = chbBoneMuscle.Checked ? true : false;
                entity.Nerve = chbNerve.Checked ? true : false;
                entity.Endocrine = chbEndocrine.Checked ? true : false;
                entity.Status = chbStatus.Checked ? true : false;

                HealthExaminationDAO m_HealthExamDAO = new HealthExaminationDAO();
                if (iFunction == 1)
                {
                    if (m_HealthExamDAO.HealthExamInsert(entity) == true)
                    {
                        XtraMessageBox.Show("Thêm đợt khám sức khỏe thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    entity.HealthExaminationID = m_HealthExamTable.HealthExaminationID;
                    if (m_HealthExamDAO.HealthExamUpdate(entity) == true)
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
        private void loadHealthExamination()
        {            
            txtNameExam.Text = m_HealthExamTable.Name;
            txtPlaceExam.Text = m_HealthExamTable.Place;
            dtDateExam.EditValue = m_HealthExamTable.Date;
            chbHeight.Checked = m_HealthExamTable.Height;
            chbWeight.Checked = m_HealthExamTable.Weight;
            chbEyes.Checked = m_HealthExamTable.Eyes;
            chbENT.Checked = m_HealthExamTable.ENT;
            chbOral.Checked = m_HealthExamTable.Oral;
            chbInternalMedicine.Checked = m_HealthExamTable.InternalMedicine;
            chbSurgery.Checked = m_HealthExamTable.Surgery;
            chbDermatology.Checked = m_HealthExamTable.Dermatology;
            chbBoneMuscle.Checked = m_HealthExamTable.BoneMuscle;
            chbNerve.Checked = m_HealthExamTable.Nerve;
            chbEndocrine.Checked = m_HealthExamTable.Endocrine;
            chbStatus.Checked = m_HealthExamTable.Status;
        }
        #endregion

        #region Event
        private void frmAddHealthExamination_Load(object sender, EventArgs e)
        {
            if (iFunction == 1)
            {
                this.Text = "Thêm mới đợt khám sức khỏe";
                dtDateExam.EditValue = DateTime.Now;
            }
            else if (iFunction == 2)
            {
                this.Text = "Cập nhật thông tin đợt khám sức khỏe";
                loadHealthExamination();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HealthExamInsert();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { this.Close(); }
        }
        #endregion
    }
}