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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.WorkProgress
{
    public partial class frmDivisionDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Employee employee;
        public Division division;
        public void setFunction(int function)
        {
            this.iFunction = function;
        }
        public void setEmployee(int employeeID)
        {
            this.employee = new EmployeeDAO().GetByID(employeeID);
        }
        public void setDivision(int divisionID)
        {
            this.division = new DivisionDAO().GetByID(divisionID);
        }
        public frmDivisionDetail()
        {
            InitializeComponent();
        }

        private void frmDivisionDetail_Load(object sender, EventArgs e)
        {
            FillDepartment();
            FillLocation();
            FillDate();
            LoadDetail();
        }
        private void LoadDetail()
        {
            txtName.Text = employee.FirstName + " " + employee.LastName;
            if (iFunction == 2 && division != null)
            {
                cbbDepartment.SelectedValue = division.DepartmentID;
                cbbPosition.SelectedValue = division.PositionID;
                dtStartDate.EditValue = division.StartDate;
                dtEndDate.EditValue = division.EndDate;
                dtCreatedDate.EditValue = division.CreatedDate;
                txtNote.Text = division.Note;
                chkActive.Checked = division.Status;
            }
        }
        private void FillDepartment()
        {
            cbbDepartment.DataSource = new DepartmentDAO().ListAll();
            cbbDepartment.ValueMember = "DepartmentID";
            cbbDepartment.DisplayMember = "Name";
        }
        private void FillLocation()
        {
            cbbPosition.DataSource = new PositionDAO().ListAll();
            cbbPosition.ValueMember = "PositionID";
            cbbPosition.DisplayMember = "Name";
        }
        private void FillDate()
        {
            dtStartDate.EditValue = DateTime.Now;
            dtEndDate.EditValue = DateTime.Now;
            dtCreatedDate.EditValue = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Division entity = new Division();
                entity.EmployeeID = employee.EmployeeID;
                entity.DepartmentID = int.Parse(cbbDepartment.SelectedValue.ToString());
                entity.PositionID = int.Parse(cbbPosition.SelectedValue.ToString());
                entity.StartDate = (DateTime)dtStartDate.EditValue;
                entity.EndDate = (DateTime)dtEndDate.EditValue;
                entity.CreatedDate = (DateTime)dtCreatedDate.EditValue;
                entity.CreatedBy = 1;
                entity.Note = txtNote.Text;
                entity.Status = chkActive.Checked;
                if (iFunction == 1)
                {
                    if (new DivisionDAO().Insert(entity) > 0)
                    {
                        MessageBox.Show("Thêm thành công quá trình làm việc!", "Thông Báo");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
                    }
                }
                else if (iFunction == 2)
                {
                    entity.DivisionID = division.DivisionID;
                    if (new DivisionDAO().Edit(entity) == true)
                    {
                        MessageBox.Show("Cập nhật thành công quá trình làm việc", "Thông Báo");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}