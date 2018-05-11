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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Contract
{
    public partial class frmContractList : DevExpress.XtraEditors.XtraUserControl
    {
        public frmContractList()
        {
            InitializeComponent();
        }

        private void frmContractList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcMain.DataSource = new ContractDAO().ListAll();
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtContractID.DataBindings.Clear();
            txtContractID.DataBindings.Add(new Binding("Text", gcMain.DataSource, "ContractID"));
            txtEmployeeFullName.DataBindings.Clear();
            txtEmployeeFullName.DataBindings.Add(new Binding("Text", gcMain.DataSource, "EmployeeFullName"));
            txtContractType.DataBindings.Clear();
            txtContractType.DataBindings.Add(new Binding("Text", gcMain.DataSource, "ContractType"));
            txtTimeType.DataBindings.Clear();
            txtTimeType.DataBindings.Add(new Binding("Text", gcMain.DataSource, "TimeType"));
            txtPayRate.DataBindings.Clear();
            txtPayRate.DataBindings.Add(new Binding("Text", gcMain.DataSource, "PayRate"));
            dtStartDate.DataBindings.Clear();
            dtStartDate.DataBindings.Add(new Binding("EditValue", gcMain.DataSource, "StartDate"));
            dtEndDate.DataBindings.Clear();
            dtEndDate.DataBindings.Add(new Binding("EditValue", gcMain.DataSource, "EndDate"));
            txtCreatedBy.DataBindings.Clear();
            txtCreatedBy.DataBindings.Add(new Binding("Text", gcMain.DataSource, "CreatedByName"));
            dtCreatedDate.DataBindings.Clear();
            dtCreatedDate.DataBindings.Add(new Binding("EditValue", gcMain.DataSource, "CreatedDate"));
            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Note"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFindEmployee frmFE = new frmFindEmployee();
            frmFE.iFunction = 1;
            frmFE.ShowDialog();
            if (frmFE.DialogResult == DialogResult.OK)
                FillGridControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmContractDetail frmCD = new frmContractDetail();
            frmCD.iFunction = 2;
            frmCD.contract = new ContractDAO().GetByID(int.Parse(txtContractID.Text));
            frmCD.ShowDialog();
            if (frmCD.DialogResult == DialogResult.OK)
                FillGridControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
