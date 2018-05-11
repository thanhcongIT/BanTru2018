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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.WorkProgress
{
    public partial class frmWorkProgressList : DevExpress.XtraEditors.XtraUserControl
    {
        public frmWorkProgressList()
        {
            InitializeComponent();
        }

        private void frmWorkProgressList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControls();
        }
        private void FillGridControls()
        {
            gcMain.DataSource = new DivisionDAO().ListAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFindEmployee frmFE = new frmFindEmployee();
            frmFE.ShowDialog();
            if (frmFE.DialogResult == DialogResult.OK)
            {
                FillGridControls();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmDivisionDetail frmDD = new frmDivisionDetail();
            frmDD.setFunction(2);
            var rowHandle = gridView1.FocusedRowHandle;
            try
            {
                frmDD.setEmployee(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "EmployeeID").ToString()));
                frmDD.setDivision(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DivisionID").ToString()));
            }
            catch
            {
                var rowChild = gridView1.GetChildRowHandle(rowHandle, 0);
                frmDD.setEmployee(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "EmployeeID").ToString()));
                frmDD.setDivision(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "DivisionID").ToString()));
            }
            frmDD.ShowDialog();
            if(frmDD.DialogResult == DialogResult.OK)
            {
                FillGridControls();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            if (MessageBox.Show("Bạn có muốn xóa quá trình hoạt động này?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    new DivisionDAO().Delete(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DivisionID").ToString()));
                }
                catch
                {

                }
                finally
                {
                    FillGridControls();
                }
            }
        }
        private void btnViewDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuAdd_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void btnMenuEdit_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnMenuDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void btnMenuViewDetail_Click(object sender, EventArgs e)
        {
            btnViewDetail_Click(sender, e);
        }

    }
}
