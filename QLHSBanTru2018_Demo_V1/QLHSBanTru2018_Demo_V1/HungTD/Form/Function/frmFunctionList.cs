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
    public partial class frmFunctionList : DevExpress.XtraEditors.XtraForm
    {
        public frmFunctionList()
        {
            InitializeComponent();
        }

        private void frmFunctionList_Load(object sender, EventArgs e)
        {
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcFunctionList.DataSource = new FunctionDAO().ListAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFunctionDetail frmFD = new frmFunctionDetail();
            frmFD.ShowDialog();
            if(frmFD.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }
    }
}