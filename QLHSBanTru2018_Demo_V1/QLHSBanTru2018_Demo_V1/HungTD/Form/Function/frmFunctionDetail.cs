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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Function
{
    public partial class frmFunctionDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmFunctionDetail()
        {
            InitializeComponent();
        }

        private void frmFunctionDetail_Load(object sender, EventArgs e)
        {
            FillCombobox();
        }

        private void FillCombobox()
        {
            cbbFunctionGroup.DataSource = new FunctionGroupDAO().ListAll();
            cbbFunctionGroup.DisplayMember = "Name";
            cbbFunctionGroup.ValueMember = "FunctionGroupID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                DataConnect.Function function = new DataConnect.Function();
                function.FunctionGroupID = int.Parse(cbbFunctionGroup.SelectedValue.ToString());
                function.Name = txtName.Text;
                function.Note = txtNote.Text;
                function.Status = chbStatus.Checked;
                if(new FunctionDAO().Insert(function) > 0)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFunctionGroupDetail frmFGD = new frmFunctionGroupDetail();
            frmFGD.ShowDialog();
            if(frmFGD.DialogResult == DialogResult.OK)
            {
                FillCombobox();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}