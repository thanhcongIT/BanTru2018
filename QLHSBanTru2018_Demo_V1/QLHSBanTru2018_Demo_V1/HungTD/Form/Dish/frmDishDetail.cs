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
using QLHSBanTru2018_Demo_V1.Common;
using System.IO;
using System.Drawing.Imaging;

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
        public void setDishDetail(int dishID)
        {
            this.dishDetails = new DishDetailDAO().GetByDishID(dishID);
        }
        public void setDishDetailViewModels(int dishID)
        {
            this.dishDetailViewModels = new DishDetailDAO().GetDishDetailViewModels(dishID);
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
            if (iFuntion == 2)
            {
                LoadDetail();
            }
            else
            {
                txtCreatedBy.Text = LoginDetail.LoginName;
                dishDetails = new List<DataConnect.DishDetail>();
                dishDetailViewModels = new List<DishDetailViewModel>();
                dish = new DataConnect.Dish();
            }
        }
        private void LoadDetail()
        {
            gcRight.DataSource = null;
            gcRight.DataSource = dishDetailViewModels;

            txtName.Text = dish.Name;
            txtCreatedBy.Text = dish.Employee.FirstName + " " + dish.Employee.LastName;
            cbbAgeGroup.SelectedValue = dish.AgeGroupID;
            cbbMeal.SelectedValue = dish.MealID;
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

            cbbAgeGroup.DataSource = new AgeGroupDAO().ListAll();
            cbbAgeGroup.DisplayMember = "Name";
            cbbAgeGroup.ValueMember = "AgeGroupID";

            cbbMeal.DataSource = new MealDAO().ListAll();
            cbbMeal.DisplayMember = "Name";
            cbbMeal.ValueMember = "MealID";
        }
        private void FillGridControls(int ingredientID)
        {
            gcLeft.DataSource = new IngredientDAO().ListAllActive(ingredientID);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dishDetails != null && dishDetails.Count() > 0 && txtName.Text != "")
            {
                //Hoàn tất
                dish.Name = txtName.Text;
                dish.MealID = int.Parse(cbbMeal.SelectedValue.ToString());
                dish.AgeGroupID = int.Parse(cbbAgeGroup.SelectedValue.ToString());
                dish.CreatedBy = LoginDetail.LoginID;
                dish.CreatedDate = DateTime.Now;
                dish.Status = chkStatus.Checked;

                if (iFuntion == 1)
                {
                    if (new DishDAO().Insert(dish, dishDetails) > 0)
                    {
                        MessageBox.Show("Thành công!", "Thêm món ăn thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi!", "Hệ thống đã xảy ra lỗi");
                    }
                }
                else if (iFuntion == 2)
                {
                    dish.DishID = dish.DishID;
                    if(new DishDAO().Update(dish, dishDetails))
                    {
                        MessageBox.Show("Thành công!", "Chỉnh sửa món ăn thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi!", "Hệ thống đã xảy ra lỗi");
                    }

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Xin lỗi!", "Mời bạn nhập đầy đủ thông tin!");
            }
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
                entity.Status = true;
                entity.QuantiyOfUnit = frmCQ.getQuantity();

                if (dishDetails.FindAll(x => x.IngredientID.Equals(entity.IngredientID)).Count > 0)
                {
                    dishDetails.FindLast(x => x.IngredientID.Equals(entity.IngredientID)).QuantiyOfUnit += entity.QuantiyOfUnit;
                }
                else
                {
                    dishDetails.Add(entity);
                }

                DishDetailViewModel entity2 = new DishDetailViewModel();
                entity2.DishID = 0;
                entity2.IngredientID = frmCQ.getIngredient().IngredientID;
                entity2.IngredientName = frmCQ.getIngredient().Name;
                entity2.Status = true;
                entity2.QuantityOfUnit = frmCQ.getQuantity();

                if (dishDetailViewModels.FindAll(x => x.IngredientID.Equals(entity2.IngredientID)).Count > 0)
                {
                    dishDetailViewModels.FindLast(x => x.IngredientID.Equals(entity2.IngredientID)).QuantityOfUnit += entity2.QuantityOfUnit;
                }
                else
                {
                    dishDetailViewModels.Add(entity2);
                }

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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh đại diện";
            ofd.Filter = "Image|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picDescription.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}