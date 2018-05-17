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
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Dish
{
    public partial class frmDish : DevExpress.XtraEditors.XtraUserControl
    {
        public frmDish()
        {
            InitializeComponent();
        }
        private void frmDish_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(TienBao.WaitForm));
            this.Dock = DockStyle.Fill;
            FillCombobox();
            SplashScreenManager.CloseForm();
        }

        private void FillCombobox()
        {
            string[] DisplayDescription = new string[] { "Lứa tuổi", "Bữa Ăn", "Người tạo" };
            cbbFilter.DataSource = DisplayDescription;
            FillGridControls();
        }
        private void FillGridControls()
        {
            gcMain.DataSource = new DishDAO().ListAll();
            BindingDetail();
        }
        private void BindingDetail()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Name"));
            txtMeal.DataBindings.Clear();
            txtMeal.DataBindings.Add(new Binding("Text", gcMain.DataSource, "MealName"));
            txtAgeGroup.DataBindings.Clear();
            txtAgeGroup.DataBindings.Add(new Binding("Text", gcMain.DataSource, "AgeGroupName"));
            txtCreatedDate.DataBindings.Clear();
            txtCreatedDate.DataBindings.Add(new Binding("Text", gcMain.DataSource, "CreatedDate"));
            txtCreatedBy.DataBindings.Clear();
            txtCreatedBy.DataBindings.Add(new Binding("Text", gcMain.DataSource, "CreatedByName"));
            chkStatus.DataBindings.Clear();
            chkStatus.DataBindings.Add(new Binding("Checked", gcMain.DataSource, "Status"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDishDetail frmDD = new frmDishDetail();
            //var rowHandle = gridView1.FocusedRowHandle;
            //try
            //{
            //    frmDD.setDish(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString()));
            //}
            //catch
            //{
            //    var rowChild = gridView1.GetChildRowHandle(rowHandle, 0);
            //    frmDD.setDish(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "DishID").ToString()));
            //}
            frmDD.setFunction(1);
            frmDD.setTitle("Thêm Mới Món Ăn");
            frmDD.ShowDialog();
            if (frmDD.DialogResult == DialogResult.OK)
                FillCombobox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmDishDetail frmDD = new frmDishDetail();
            var rowHandle = gridView1.FocusedRowHandle;
            try
            {
                frmDD.setDish(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString()));
                frmDD.setDishDetail(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString()));
                frmDD.setDishDetailViewModels(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString()));
            }
            catch
            {
                var rowChild = gridView1.GetChildRowHandle(rowHandle, 0);
                frmDD.setDish(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "DishID").ToString()));
                frmDD.setDishDetail(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "DishID").ToString()));
                frmDD.setDishDetailViewModels(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "DishID").ToString()));
            }
            frmDD.setFunction(2);
            frmDD.setTitle("Chỉnh Sửa Món Ăn");
            frmDD.ShowDialog();
            if (frmDD.DialogResult == DialogResult.OK)
                FillCombobox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            if (MessageBox.Show("Bạn có muốn xóa món ăn " + gridView1.GetRowCellValue(rowHandle, "Name").ToString(), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    new DishDAO().Delete(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString()));
                    FillGridControls();
                }
                catch
                {

                }
            }
        }

        private void btnContextAdd_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void btnContextEdit_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnContexDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFilter.Text == "Lứa tuổi")
            {
                gridView1.ClearGrouping();
                colAgeGroupName.GroupIndex = 0;
            }
            else if (cbbFilter.Text == "Bữa Ăn")
            {
                gridView1.ClearGrouping();
                colMealName.GroupIndex = 0;
            }
            else
            {
                gridView1.ClearGrouping();
                colCreatedByName.GroupIndex = 0;
            }
        }
    }
}
