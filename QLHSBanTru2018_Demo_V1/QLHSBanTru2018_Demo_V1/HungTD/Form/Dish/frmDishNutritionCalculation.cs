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
using DataConnect.ViewModel;
using DataConnect.DAO.HungTD;
using DevExpress.XtraCharts;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Dish
{
    public partial class frmDishNutritionCalculation : DevExpress.XtraEditors.XtraForm
    {
        List<DataConnect.DishDetail> dishDetails;
        DataConnect.Ingredient ingredient = new DataConnect.Ingredient();
        public void setList(List<DataConnect.DishDetail> list)
        {
            this.dishDetails = list;
        }
        public frmDishNutritionCalculation()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmDishNutritionCalculation_Load(object sender, EventArgs e)
        {
            if (dishDetails == null || dishDetails.Count() <= 0)
            {
            }
            else
            {
                labError.Text = "";
                ingredient.IngredientID = 0;
                ingredient.Name = "ingredientTotal";
                ingredient.IngredientTypeID = 0;
                ingredient.Unit = "";
                ingredient.Kcal = 0;
                ingredient.Protein = 0;
                ingredient.Fat = 0;
                ingredient.Glucose = 0;
                ingredient.Fiber = 0;
                ingredient.Canxi = 0;
                ingredient.Iron = 0;
                ingredient.Photpho = 0;
                ingredient.Kali = 0;
                ingredient.Natri = 0;
                ingredient.VitaminA = 0;
                ingredient.VitaminB1 = 0;
                ingredient.VitaminC = 0;
                ingredient.AxitFolic = 0;
                ingredient.Cholesterol = 0;
                ingredient.Status = true;

                foreach (DataConnect.DishDetail item in dishDetails)
                {
                    DataConnect.Ingredient res = new IngredientDAO().GetByID(item.IngredientID);

                    ingredient.Unit = "";
                    ingredient.Kcal += res.Kcal * item.QuantiyOfUnit;
                    ingredient.Protein += res.Protein * item.QuantiyOfUnit;
                    ingredient.Fat += res.Fat * item.QuantiyOfUnit;
                    ingredient.Glucose += res.Glucose * item.QuantiyOfUnit;
                    ingredient.Fiber += res.Fiber * item.QuantiyOfUnit;
                    ingredient.Canxi += res.Canxi * item.QuantiyOfUnit;
                    ingredient.Iron += res.Iron * item.QuantiyOfUnit;
                    ingredient.Photpho += res.Photpho * item.QuantiyOfUnit;
                    ingredient.Kali += res.Kali * item.QuantiyOfUnit;
                    ingredient.Natri += res.Natri * item.QuantiyOfUnit;
                    ingredient.VitaminA += res.VitaminA * item.QuantiyOfUnit;
                    ingredient.VitaminB1 += res.VitaminB1 * item.QuantiyOfUnit;
                    ingredient.VitaminC += res.VitaminC * item.QuantiyOfUnit;
                    ingredient.AxitFolic += res.AxitFolic * item.QuantiyOfUnit;
                    ingredient.Cholesterol += res.Cholesterol * item.QuantiyOfUnit;
                }

                txtKcal.Text = ingredient.Kcal.ToString();
                txtProtein.Text = ingredient.Protein.ToString();
                txtFat.Text = ingredient.Fat.ToString();
                txtGlucose.Text = ingredient.Glucose.ToString();
                txtFiber.Text = ingredient.Fiber.ToString();
                txtCanxi.Text = ingredient.Canxi.ToString();
                txtIron.Text = ingredient.Iron.ToString();
                txtPhotpho.Text = ingredient.Photpho.ToString();
                txtKali.Text = ingredient.Kali.ToString();
                txtNatri.Text = ingredient.Natri.ToString();
                txtVitaminA.Text = ingredient.VitaminA.ToString();
                txtVitaminB1.Text = ingredient.VitaminB1.ToString();
                txtVitaminC.Text = ingredient.VitaminC.ToString();
                txtAxitFolic.Text = ingredient.AxitFolic.ToString();
                txtCholesterol.Text = ingredient.Cholesterol.ToString();

                SetChartNutrition();
            }
        }
        private void SetChartNutrition()
        {

        }
    }
}