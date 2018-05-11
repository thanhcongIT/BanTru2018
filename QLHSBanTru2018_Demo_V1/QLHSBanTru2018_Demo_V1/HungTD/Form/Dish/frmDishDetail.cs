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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Dish
{
    public partial class frmDishDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFuntion = 0;
        public DataConnect.Dish dish;
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
            tabInformation.SelectedTabPage = tabPage2;
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
    }
}