using DataConnect.DAO.TienBao;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmHealthProblemDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.HealthProblem m_HealthProblem;
        public DataConnect.Class Class;
        public DataConnect.Student_Class StudentClass;

        #region System
        public frmHealthProblemDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadInfo
        private void LoadStudent()
        {
            cbbStudentName.Properties.DataSource = new HealthProblemDAO().ListStudent(); ;
            cbbStudentName.Properties.DisplayMember = "FullName";
            cbbStudentName.Properties.ValueMember = "StudentID";
            
        }
        private void LoadEmployee()
        {
            cbbEmployee.Properties.DataSource = new HealthProblemDAO().ListEmPloyee(); ;
            cbbEmployee.Properties.DisplayMember = "EmployeeName";
            cbbEmployee.Properties.ValueMember = "EmployeeID";
        }
        #endregion

        #region LoadDAO
        private void HealthProblemInsert()
        {
            if (cbbStudentName.Text != "" &&
             txtStudentCode.Text != "" &&
             txtClassName.Text != "" &&
             dtDateProblem.Text != "" &&
             cbbSignal.Text != "" &&
             txtDiagnosed.Text != "" &&
             txtMeasure.Text != "" &&
             cbbServerity.Text != "" &&
             cbbEmployee.Text != "")
            {
                DataConnect.HealthProblem entity = new DataConnect.HealthProblem();
                entity.StudentID = int.Parse(cbbStudentName.EditValue.ToString());
                entity.StartDate = DateTime.Parse(dtDateProblem.EditValue.ToString());
                entity.Signal = cbbSignal.Text;
                entity.Diagnosed = txtDiagnosed.Text;
                entity.Measure = txtMeasure.Text;
                entity.Serverity = cbbServerity.Text;
                entity.EmployeeID = int.Parse(cbbEmployee.EditValue.ToString());
                entity.Status = chbStatus.Checked ? true : false;

                HealthProblemDAO m_HealthProblemDAO = new HealthProblemDAO();
                if (iFunction == 1)
                {
                    if (m_HealthProblemDAO.HealthProblemInsert(entity) == true)
                    {
                        XtraMessageBox.Show("Thêm sự cố thành công!", "Thông Báo");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo");
                    }
                }
                else if (iFunction == 2)
                {
                    entity.HealthProblemID = m_HealthProblem.HealthProblemID;
                    if (m_HealthProblemDAO.HealthProblemUpdate(entity) == true)
                    {
                        XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
            }
        }
        private void loadHealthProblem()
        {
            cbbStudentName.EditValue = m_HealthProblem.StudentID;
            cbbEmployee.EditValue = m_HealthProblem.EmployeeID;
            cbbSignal.Text = m_HealthProblem.Signal;
            txtDiagnosed.Text = m_HealthProblem.Diagnosed;
            txtMeasure.Text = m_HealthProblem.Measure;
            dtDateProblem.EditValue = m_HealthProblem.StartDate;
            cbbServerity.SelectedText = m_HealthProblem.Serverity;
          //  chbStatus.Checked = m_HealthProblem.Status;

        }
        #endregion

        #region Event
        private void cbbStudentName_EditValueChanged(object sender, EventArgs e)
        {
            txtStudentCode.Text = cbbStudentName.GetColumnValue("StudentCode").ToString();
            txtClassName.Text = cbbStudentName.GetColumnValue("ClassName").ToString();
        }
        private void frmHealthProblemDetail_Load(object sender, EventArgs e)
        {

            LoadStudent();
            LoadEmployee();
            if (iFunction == 1)
            {
                this.Text = "Thêm mới sự cố y tế";
                dtDateProblem.EditValue = DateTime.Now;                
            }
            else if (iFunction == 2)
            {
                this.Text = "Cập nhật thông tin sự cố";
                loadHealthProblem();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HealthProblemInsert();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { this.Close(); }
        }
        #endregion
    }
}