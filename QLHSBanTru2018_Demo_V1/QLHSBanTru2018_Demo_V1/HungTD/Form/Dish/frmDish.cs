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
            FillGridControls();
        }
        private void FillGridControls()
        {
            gcMain.DataSource = new DishDAO().ListAll();
            BindingDetail();
        }
        private void BindingDetail()
        {
            //BindingDetail();
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
    }
}
