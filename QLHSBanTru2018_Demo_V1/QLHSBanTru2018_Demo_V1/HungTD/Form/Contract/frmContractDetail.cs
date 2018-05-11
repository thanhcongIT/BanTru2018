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
using QLHSBanTru2018_Demo_V1.HungTD.Form.Employee;
using DataConnect.ViewModel;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Contract
{
    public partial class frmContractDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmContractDetail()
        {
            InitializeComponent();
        }
        public int iFunction;
        public DataConnect.Contract contract;
        private void frmContractDetail_Load(object sender, EventArgs e)
        {
            FillGridControl();
            Prepared();
            if (iFunction == 1)
            {
                this.Text = "Thêm mới hợp đồng";
            }else if (iFunction == 2)
            {
                this.Text = "Chỉnh sửa hợp đồng";
                txtContractType.Text = contract.ContractType;
                cbbTimeType.Text = contract.TimeType == 1 ? "Có thời hạn" : "Không thời hạn";
                txtPayRate.Text = contract.PayRate.ToString();
                dtStartDate.EditValue = contract.StartDate;
                dtEndDate.EditValue = contract.EndDate;
                cbbCreatedBy.SelectedValue = contract.CreatedBy;
                dtCreatedDate.EditValue = contract.CreatedDate;
                txtNote.Text = contract.Note;
            }
        }
        private void FillGridControl()
        {
            gcListEmployee.DataSource = new EmployeeDAO().ListAllEmployee(null, null, null);
            BindingDetail();
        }
        private void Prepared()
        {
            cbbTimeType.SelectedIndex = 0;
            dtStartDate.EditValue = DateTime.Now;
            dtEndDate.Enabled = true;
            dtEndDate.EditValue = DateTime.Now;
            dtCreatedDate.EditValue = DateTime.Now;

            cbbCreatedBy.DataSource = new EmployeeDAO().LoadLeader();
            cbbCreatedBy.DisplayMember = "LastName";
            cbbCreatedBy.ValueMember = "EmployeeID";
        }
        private void BindingDetail()
        {
            txtEmployeeID.DataBindings.Clear();
            txtEmployeeID.DataBindings.Add(new Binding("Text", gcListEmployee.DataSource, "EmployeeID"));
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

        private void cbbTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTimeType.SelectedIndex == 0)
            {
                dtEndDate.Enabled = true;
            }
            else
            {
                dtEndDate.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeDetail frmED = new frmEmployeeDetail();
            frmED.ShowDialog();
            frmED.iFunction = 1;
            frmED.ShowDialog();
            if (frmED.DialogResult == DialogResult.OK)
                FillGridControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == ""
                || txtContractType.Text == ""
                || txtPayRate.Text == ""
                || dtStartDate.EditValue == null
                )
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
            }
            else
            {
                DataConnect.Contract entity = new DataConnect.Contract();
                entity.ContractType = txtContractType.Text;
                entity.TimeType = cbbTimeType.Text == "Có thời hạn" ? 1 : 0;
                entity.EmployeeID = int.Parse(txtEmployeeID.Text);
                entity.PayRate = double.Parse(txtPayRate.Text);
                entity.StartDate = DateTime.Parse(dtStartDate.EditValue.ToString());
                entity.EndDate = DateTime.Parse(dtEndDate.EditValue.ToString());
                entity.CreatedBy = int.Parse(cbbCreatedBy.SelectedValue.ToString());
                entity.CreatedDate = DateTime.Parse(dtCreatedDate.EditValue.ToString());
                entity.Note = txtNote.Text;
                entity.Status = true;
                if (iFunction == 1)
                {
                    if (new ContractDAO().Insert(entity) > 0)
                    {
                        MessageBox.Show("Thành công!", "Thêm thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi!", "Hệ thống đã xảy ra lỗi");
                    }
                }
                else if (iFunction == 2)
                {
                    entity.ContractID = contract.ContractID;
                    if(new ContractDAO().Edit(entity) == true)
                    {
                        MessageBox.Show("Thành công!", "Cập nhật thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi!", "Hệ thống đã xảy ra lỗi");
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (contract != null)
            {

                frmPrintContract frmPC = new frmPrintContract();
                ContractReportViewModel contractView = new ContractDAO().GetForReport(contract.ContractID);
                frmPC.InitContract(contractView);
                frmPC.ShowDialog();
            }   
        }
    }
}