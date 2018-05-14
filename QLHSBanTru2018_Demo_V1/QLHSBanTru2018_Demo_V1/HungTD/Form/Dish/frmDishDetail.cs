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
using DataConnect;
using DataConnect.DAO.HungTD;
using DataConnect.ViewModel;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Dish
{
    public partial class frmDishDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFuntion = 0;
        public DataConnect.Dish dish;
        public List<DataConnect.DishDetail> dishDetails;
        public List<DishDetailViewModel> dishDetailViewModels;
        public void setFunction(int function)
        {
            this.iFuntion = function;
        }
        public void setDish(int dishID)
        {
            this.dish = new DishDAO().GetByID(dishID);
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        public frmDishDetail()
        {
            InitializeComponent();
        }

        private void frmDishDetail_Load(object sender, EventArgs e)
        {
            FillCombobox();
            dishDetails = new List<DataConnect.DishDetail>();
            dishDetailViewModels = new List<DishDetailViewModel>();
        }
        private void FillCombobox()
        {
            cbbIngredientType.DataSource = new IngredientTypeDAO().ListAllActive();
            cbbIngredientType.DisplayMember = "Name";
            cbbIngredientType.ValueMember = "IngredientTypeID";
            try
            {
                FillGridControls(int.Parse(cbbIngredientType.SelectedValue.ToString()));
            }
            catch
            {

            }
        }
        private void FillGridControls(int ingredientID)
        {
            gcLeft.DataSource = new IngredientDAO().ListAllActive(ingredientID);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Hoàn tất
            dish.MealID = int.Parse(cbbIngredientType.SelectedValue.ToString());
            dish.Name = txtName.Text;

            this.Close();
        }

        private void cbbIngredientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillGridControls(int.Parse(cbbIngredientType.SelectedValue.ToString()));
            }
            catch
            {

            }

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            tabInformation.SelectedTabPage = tabPage2;
            btnPrevious.Enabled = true;
            btnFinish.Enabled = true;
            btnNext.Enabled = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tabInformation.SelectedTabPage = tabPage1;
            btnNext.Enabled = true;
            btnPrevious.Enabled = false;
            btnFinish.Enabled = false;
        }

        private void btnAdd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmChangeQuantity frmCQ = new frmChangeQuantity();
            var rowHandle = gridView1.FocusedRowHandle;
            try
            {
                frmCQ.setIngredient(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "IngredientID").ToString()));
            }
            catch
            {

            }
            frmCQ.setTitle("Thêm Thực Phẩm");
            frmCQ.ShowDialog();
            if (frmCQ.DialogResult == DialogResult.OK)
            {
                DataConnect.DishDetail entity = new DishDetail();
                entity.DishID = 0;
                entity.IngredientID = frmCQ.getIngredient().IngredientID;
                entity.QuantiyOfUnit = frmCQ.getQuantity();
                entity.Status = true;
                dishDetails.Add(entity);

                DishDetailViewModel entity2 = new DishDetailViewModel();
                entity2.DishID = 0;
                entity2.IngredientID = frmCQ.getIngredient().IngredientID;
                entity2.IngredientName = frmCQ.getIngredient().Name;
                entity2.QuantityOfUnit = frmCQ.getQuantity();
                entity2.Status = true;
                dishDetailViewModels.Add(entity2);

                gcRight.DataSource = null;
                gcRight.DataSource = dishDetailViewModels;
            }
            frmCQ.Dispose();
        }

        private void btnNutritionCaculation_Click(object sender, EventArgs e)
        {
            frmDishNutritionCalculation frmDNC = new frmDishNutritionCalculation();
            frmDNC.setList(dishDetails);
            frmDNC.Text = "Chi Tiết Dinh Dưỡng";
            frmDNC.ShowDialog();
        }
    }
}