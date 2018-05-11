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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Employee
{
    public partial class frmEmployeeList : DevExpress.XtraEditors.XtraUserControl
    {
        public frmEmployeeList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeDetail employeeDetail = new frmEmployeeDetail();
            employeeDetail.iFunction = 1;
            employeeDetail.ShowDialog();
            if (employeeDetail.DialogResult == DialogResult.OK)
                FillGridControl();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcEmployeeList.DataSource = new EmployeeDAO().ListAllEmployee(null, null, null);
            BindingDetail();
        }
        private void BindingDetail()
        {
            picImage.DataBindings.Clear();
            picImage.DataBindings.Add(new Binding("image", gcEmployeeList.DataSource, "Image", true, DataSourceUpdateMode.OnPropertyChanged));

            txtFullName.DataBindings.Clear();
            txtFullName.DataBindings.Add(new Binding("text", gcEmployeeList.DataSource, "FullName"));

            dtBirthday.DataBindings.Clear();
            dtBirthday.DataBindings.Add(new Binding("EditValue", gcEmployeeList.DataSource, "Birthday", true, DataSourceUpdateMode.OnPropertyChanged));

            textEdit1.DataBindings.Clear();
            textEdit1.DataBindings.Add(new Binding("text", gcEmployeeList.DataSource, "Phone"));

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add(new Binding("text", gcEmployeeList.DataSource, "Email"));

            txtLocationDetail.DataBindings.Clear();
            txtLocationDetail.DataBindings.Add(new Binding("text", gcEmployeeList.DataSource, "LocationDetail"));

            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("text", gcEmployeeList.DataSource, "Note"));

            txtA.DataBindings.Clear();
            txtA.DataBindings.Add(new Binding("text", gcEmployeeList.DataSource, "EmployeeID"));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {  
             frmEmployeeDetail employeeDetail = new frmEmployeeDetail();
            employeeDetail.iFunction = 2;
            employeeDetail.employee = new EmployeeDAO().GetByID(int.Parse(txtA.Text));
            employeeDetail.ShowDialog();
            if (employeeDetail.DialogResult == DialogResult.OK)
                FillGridControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Thông báo","Bạn muốn xóa nhân viên " + txtFullName.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                new EmployeeDAO().Delete(int.Parse(txtA.Text));
                FillGridControl();
            }
        }

        private void gcEmployeeList_Click(object sender, EventArgs e)
        {

        }
    }
    
}
