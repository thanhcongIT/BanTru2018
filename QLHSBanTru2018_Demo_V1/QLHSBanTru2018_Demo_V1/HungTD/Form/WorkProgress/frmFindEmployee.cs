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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.WorkProgress
{
    public partial class frmFindEmployee : DevExpress.XtraEditors.XtraForm
    {
        public frmFindEmployee()
        {
            InitializeComponent();
        }

        private void frmFindEmployee_Load(object sender, EventArgs e)
        {
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcListEmployee.DataSource = new EmployeeDAO().ListAllEmployee(null, null, null);
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtFullName.DataBindings.Clear();
            txtFullName.DataBindings.Add(new Binding("Text", gcListEmployee.DataSource, "FullName"));
            txtUsername.DataBindings.Clear();
            txtUsername.DataBindings.Add(new Binding("Text", gcListEmployee.DataSource, "Username"));
            dtBirthday.DataBindings.Clear();
            dtBirthday.DataBindings.Add(new Binding("EditValue", gcListEmployee.DataSource, "Birthday"));
            txtIdentityNumber.DataBindings.Clear();
            txtIdentityNumber.DataBindings.Add(new Binding("Text", gcListEmployee.DataSource, "IdentityNumber"));
            dtDateOfIssue.DataBindings.Clear();
            dtDateOfIssue.DataBindings.Add(new Binding("EditValue", gcListEmployee.DataSource, "DateOfIssue"));
            txtPlaceOfIssue.DataBindings.Clear();
            txtPlaceOfIssue.DataBindings.Add(new Binding("Text", gcListEmployee.DataSource, "PlaceOfIssue"));
            picImage.DataBindings.Clear();
            picImage.DataBindings.Add(new Binding("image", gcListEmployee.DataSource, "Image", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEmployeeDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click_1(object sender, EventArgs e)
        {
            frmDivisionDetail frmDD = new frmDivisionDetail();
            frmDD.setFunction(1);
            var rowHandle = gridView1.FocusedRowHandle;
            frmDD.setEmployee(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "EmployeeID").ToString()));
            frmDD.ShowDialog();
            if (frmDD.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}