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
using DataConnect.DAO.TienBao;
using DataConnect.DAO.HungTD;
using DataConnect.ViewModel;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmAddHealthExaminationDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.HealthExamination healthExamination;
        public DataConnect.HealthExaminationDetail m_HealthExaminationDetail;
        public DataConnect.Class Class;
        public DataConnect.Student_Class StudentClass;

        public frmAddHealthExaminationDetail()
        {
            InitializeComponent();
        }

        #region LoadDao
        private void frmAddHealthDetailInsert()
        {
            if (lblStudentName.Text != "" 
             //txtStudentCode.Text != "" &&
            // txtStudentID.Text != "" 
            )
            {
                DataConnect.HealthExaminationDetail entity = new DataConnect.HealthExaminationDetail();
                entity.StudentID = int.Parse(Student.StudentID.ToString());                
                entity.HealthExaminationID = int.Parse(healthExamination.HealthExaminationID.ToString());
                entity.HealthInsurance = 1;
                entity.Height = int.Parse(txtHeight.Text);
                entity.Weight = int.Parse(txtWeight.Text);
                entity.Eyes = cmbEyesRating.Text;
                entity.ENT = cmbENTRating.Text;
                entity.Oral = cmbOralRating.Text;
                entity.InternalMedicine = cmbInternalMedicineRating.Text;
                entity.Surgery = cmbSurgeryRating.Text;
                entity.Dermatology = cmbDermatologyRating.Text;
                entity.BoneMuscle = cmbBoneMuscleRating.Text;
                entity.Nerve = cmbNerveRating.Text;
                entity.Endocrine = cmbEndocrineRating.Text;
                entity.Other =txtOtherRating.Text;
                entity.Rating = double.Parse(cmbRating.Text);
                entity.Note = txtNote.Text;
                entity.Status = chbStatus.Checked ? true : false;

                HealthExaminationDetailDAO m_HealthExamDAO = new HealthExaminationDetailDAO();
                if (iFunction == 1)
                {
                    if (m_HealthExamDAO.HealthDetailInsert(entity) == true)
                    {
                        XtraMessageBox.Show("Thêm kết quả khám sức khỏe thành công!", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else if (iFunction == 2)
                {
                    entity.HealthExaminationDetailID = m_HealthExaminationDetail.HealthExaminationDetailID;
                    if (m_HealthExamDAO.HealthDetailUpdate(entity) == true)
                    {
                        XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Mời bạn nhập đầy đủ thông tin!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void loadfrmAddHealthDetail()
        {
            if (iFunction == 1)
            {
                this.Text = "Nhập kết quả khám sức khỏe";
                lblHealthExamName.Text = healthExamination.Name;           
                lblStudentName.Text = Student.StudentCode + " " + "-" + " " + Student.FirstName + " " + Student.LastName;
                if(healthExamination.Height == true  )
                { txtHeight.Enabled = true; }
                else {txtHeight.Enabled = false;}
                if (healthExamination.Weight == true)
                { txtWeight.Enabled = true;}
                else { txtWeight.Enabled = false; }
                if (healthExamination.Eyes == true)
                { cmbEyesRating.Enabled = true; }
                else { cmbEyesRating.Enabled = false; }
                if (healthExamination.ENT == true)
                { cmbENTRating.Enabled = true; }
                else { cmbENTRating.Enabled = false; }
                if (healthExamination.Oral == true)
                { cmbOralRating.Enabled = true; }
                else { cmbOralRating.Enabled = false; }
                if (healthExamination.InternalMedicine == true)
                { cmbInternalMedicineRating.Enabled = true; }
                else { cmbInternalMedicineRating.Enabled = false; }
                if (healthExamination.Surgery == true)
                { cmbSurgeryRating.Enabled = true; }
                else { cmbSurgeryRating.Enabled = false; }
                if (healthExamination.Dermatology == true)
                { cmbDermatologyRating.Enabled = true; }
                else { cmbDermatologyRating.Enabled = false; }
                if (healthExamination.BoneMuscle == true)
                { cmbBoneMuscleRating.Enabled = true; }
                else { cmbBoneMuscleRating.Enabled = false; }
                if (healthExamination.Nerve == true)
                { cmbNerveRating.Enabled = true; }
                else { cmbNerveRating.Enabled = false; }
                if (healthExamination.Endocrine == true)
                { cmbEndocrineRating.Enabled = true; }
                else { cmbEndocrineRating.Enabled = false; }

            }
        }        
        #endregion

        #region Event
        private void frmAddHealthExaminationDetail_Load(object sender, EventArgs e)
        {
            loadfrmAddHealthDetail();
        }

        #endregion
    }
}