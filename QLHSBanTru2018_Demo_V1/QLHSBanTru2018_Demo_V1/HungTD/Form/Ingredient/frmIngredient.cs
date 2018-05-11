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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Ingredient
{
    public partial class frmIngredient : DevExpress.XtraEditors.XtraUserControl
    {
        public frmIngredient()
        {
            InitializeComponent();
        }

        private void frmIngredient_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControl();
        }
        private void FillGridControl()
        {
            gcMain.DataSource = new IngredientDAO().ListAll();
            BindingDetail();
        }
        public void BindingDetail()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Name"));
            txtIngredientType.DataBindings.Clear();
            txtIngredientType.DataBindings.Add(new Binding("Text", gcMain.DataSource, "IngredientTypeName"));
            txtUnit.DataBindings.Clear();
            txtUnit.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Unit"));
            chkStatus.DataBindings.Clear();
            chkStatus.DataBindings.Add(new Binding("Checked", gcMain.DataSource, "Status"));
            txtKcal.DataBindings.Clear();
            txtKcal.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Kcal"));
            txtProtein.DataBindings.Clear();
            txtProtein.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Protein"));
            txtFat.DataBindings.Clear();
            txtFat.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Fat"));
            txtGlucose.DataBindings.Clear();
            txtGlucose.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Glucose"));
            txtFiber.DataBindings.Clear();
            txtFiber.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Fiber"));
            txtCanxi.DataBindings.Clear();
            txtCanxi.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Canxi"));
            txtIron.DataBindings.Clear();
            txtIron.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Iron"));
            txtPhotpho.DataBindings.Clear();
            txtPhotpho.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Photpho"));
            txtKali.DataBindings.Clear();
            txtKali.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Kali"));
            txtNatri.DataBindings.Clear();
            txtNatri.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Natri"));
            txtVitaminA.DataBindings.Clear();
            txtVitaminA.DataBindings.Add(new Binding("Text", gcMain.DataSource, "VitaminA"));
            txtVitaminB1.DataBindings.Clear();
            txtVitaminB1.DataBindings.Add(new Binding("Text", gcMain.DataSource, "VitaminB1"));
            txtVitaminC.DataBindings.Clear();
            txtVitaminC.DataBindings.Add(new Binding("Text", gcMain.DataSource, "VitaminC"));
            txtAxitFolic.DataBindings.Clear();
            txtAxitFolic.DataBindings.Add(new Binding("Text", gcMain.DataSource, "AxitFolic"));
            txtCholesterol.DataBindings.Clear();
            txtCholesterol.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Cholesterol"));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIngredientDetail frmID = new frmIngredientDetail();
            frmID.setFunction(1);
            frmID.ShowDialog();
            frmID.setTitle("Thêm Mới Thực Phẩm");
            if (frmID.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmIngredientDetail frmID = new frmIngredientDetail();
            var rowHandle = gridView1.FocusedRowHandle;
            try
            {
                frmID.setIngredient(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "IngredientID").ToString()));
            }
            catch
            {
                var rowChildHand = gridView1.GetChildRowHandle(rowHandle, 0);
                frmID.setIngredient(Convert.ToInt32(gridView1.GetRowCellValue(rowChildHand, "IngredientID").ToString()));
            }
            frmID.setFunction(2);
            frmID.setTitle("Cập Nhật Thực Phẩm");
            frmID.ShowDialog();
            if (frmID.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {

        }

        private void btnReduction_Click(object sender, EventArgs e)
        {

        }

        private void txtUnit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nguyên liệu " + txtName.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var rowHandle = gridView1.FocusedRowHandle;
                    new IngredientDAO().Delete(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "IngredientID").ToString()));
                    FillGridControl();
                }
                catch
                {

                }
            }
        }
    }
}
