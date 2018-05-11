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
    public partial class frmFunctionGroupDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmFunctionGroupDetail()
        {
            InitializeComponent();
        }

        private void frmFunctionGroupDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataConnect.FunctionGroup functionGroup = new DataConnect.FunctionGroup();
            functionGroup.Name = txtName.Text;
            functionGroup.Status = chbStatus.Checked == true ? true : false;
            if(new FunctionGroupDAO().Insert(functionGroup) > 0)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}