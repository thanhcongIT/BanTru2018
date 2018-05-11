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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Ingredient
{
    public partial class frmIngredientDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction = 0;
        public DataConnect.Ingredient ingredient;
        public void setFunction(int function)
        {
            this.iFunction = function;
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        public void setIngredient(int ingredientID)
        {
            this.ingredient = new IngredientDAO().GetByID(ingredientID);
        }
        public frmIngredientDetail()
        {
            InitializeComponent();
        }

        private void frmIngredientDetail_Load(object sender, EventArgs e)
        {
            FillCombobox();
            LoadDetail();
        }
        private void LoadDetail()
        {
            if (iFunction == 2)
            {
                try
                {
                    txtName.Text = ingredient.Name;
                    cbbIngredientTypeID.SelectedValue = ingredient.IngredientTypeID;
                    txtUnit.Text = ingredient.Unit;
                    chkStatus.Checked = ingredient.Status;

                    txtKcal.Text = ingredient.Kcal.ToString();
                    txtProtein.Text = ingredient.Protein.ToString();
                    txtFat.Text = ingredient.Fat.ToString();
                    txtGlucose.Text = ingredient.Glucose.ToString();
                    txtFiber.Text = ingredient.Fiber.ToString();
                    txtCanxi.Text = ingredient.Canxi.ToString();
                    txtIron.Text = ingredient.Iron.ToString();
                    txtPhotpho.Text = ingredient.Photpho.ToString();
                    txtKali.Text = ingredient.Kali.ToString();
                    txtVitaminA.Text = ingredient.VitaminA.ToString();
                    txtVitaminB1.Text = ingredient.VitaminB1.ToString();
                    txtVitaminC.Text = ingredient.VitaminC.ToString();
                    txtAxitFolic.Text = ingredient.AxitFolic.ToString();
                    txtCholesterol.Text = ingredient.Cholesterol.ToString();
                }
                catch
                {

                }
            }
        }
        private void FillCombobox()
        {
            cbbIngredientTypeID.DataSource = new IngredientTypeDAO().ListAllActive();
            cbbIngredientTypeID.DisplayMember = "Name";
            cbbIngredientTypeID.ValueMember = "IngredientTypeID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                try
                {
                    DataConnect.Ingredient entity = new DataConnect.Ingredient();
                    entity.Name = txtName.Text;
                    entity.IngredientTypeID = int.Parse(cbbIngredientTypeID.SelectedValue.ToString());
                    entity.Unit = txtUnit.Text;
                    entity.Status = chkStatus.Checked;

                    entity.Kcal = float.Parse(txtKcal.Text);
                    entity.Protein = float.Parse(txtProtein.Text);
                    entity.Fat = float.Parse(txtFat.Text);
                    entity.Glucose = float.Parse(txtGlucose.Text);
                    entity.Fiber = float.Parse(txtFiber.Text);
                    entity.Canxi = float.Parse(txtCanxi.Text);
                    entity.Iron = float.Parse(txtIron.Text);
                    entity.Photpho = float.Parse(txtPhotpho.Text);
                    entity.Kali = float.Parse(txtKali.Text);
                    entity.Natri = float.Parse(txtNatri.Text);
                    entity.VitaminA = float.Parse(txtVitaminA.Text);
                    entity.VitaminB1 = float.Parse(txtVitaminB1.Text);
                    entity.VitaminC = float.Parse(txtVitaminC.Text);
                    entity.AxitFolic = float.Parse(txtAxitFolic.Text);
                    entity.Cholesterol = float.Parse(txtCholesterol.Text);
                    if (iFunction == 1)
                    {
                        if (new IngredientDAO().Insert(entity) > 0)
                        {
                            MessageBox.Show("Thêm thành công!", "Thành công!");
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
                        }
                    }
                    else if (iFunction == 2)
                    {
                        entity.IngredientID = ingredient.IngredientID;
                        if (new IngredientDAO().Edit(entity) == true)
                        {
                            MessageBox.Show("Cập nhật công!", "Thành công!");
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Hệ thống đã xảy ra lỗi", "Xin lỗi!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình nhập số liện!", "Xin Lỗi!");
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Xin Lỗi!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUnit_EditValueChanged(object sender, EventArgs e)
        {
            labUnit.Text = "vnđ/" + txtUnit.Text;
            labUnit2.Text = txtUnit.Text;
        }
        private void functionUpdateQuantity()
        {

        }
    }
}