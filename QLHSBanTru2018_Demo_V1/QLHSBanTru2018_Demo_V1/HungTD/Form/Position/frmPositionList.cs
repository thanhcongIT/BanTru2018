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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Position
{
    public partial class frmPositionList : DevExpress.XtraEditors.XtraUserControl
    {
        public frmPositionList()
        {
            InitializeComponent();
        }

        private void frmPositionList_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcPositionList.DataSource = new PositionDAO().ListAll();
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding("text", gcPositionList.DataSource, "Name"));
            txtPositionID.DataBindings.Clear();
            txtPositionID.DataBindings.Add(new Binding("text", gcPositionList.DataSource, "PositionID"));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPositionDetail positionDetail = new frmPositionDetail();
            positionDetail.Function = 1;
            positionDetail.ShowDialog();
            if (positionDetail.DialogResult == DialogResult.OK)
                FillGridControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmPositionDetail positionDetail = new frmPositionDetail();
            positionDetail.Function = 2;
            positionDetail.position = new PositionDAO().GetByID(int.Parse(txtPositionID.Text));
            positionDetail.ShowDialog();
            if (positionDetail.DialogResult == DialogResult.OK)
                FillGridControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa " + txtName.Text, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (new PositionDAO().Delete(int.Parse(txtPositionID.Text)) == true)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xin lỗi, đã xảy ra lỗi!", "Thông báo");
                }
                FillGridControl();
            }
        }
    }
}
