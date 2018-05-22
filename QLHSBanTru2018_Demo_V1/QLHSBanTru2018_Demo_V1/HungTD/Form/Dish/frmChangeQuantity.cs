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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Dish
{
    public partial class frmChangeQuantity : DevExpress.XtraEditors.XtraForm
    {
        DataConnect.Ingredient ingredient;
        public double quantity = 0;
        public double getQuantity()
        {
            return this.quantity;
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        public void setIngredient(int ingredientID)
        {
            this.ingredient = new IngredientDAO().GetByID(ingredientID);
        }
        public DataConnect.Ingredient getIngredient()
        {
            return this.ingredient;
        }
        public frmChangeQuantity()
        {
            InitializeComponent();
        }

        private void frmChangeQuantity_Load(object sender, EventArgs e)
        {
            txtName.Text = ingredient.Name;
            labUnit.Text = "(" + ingredient.Unit + ")";
            txtQuantity.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtQuantity.Text) > 0)
            {
                this.quantity = double.Parse(txtQuantity.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                errorProvider1.SetError(txtQuantity, "Lượng sản phẩm phải lớn hơn 0");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}