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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Ingredient
{
    public partial class frmIngredientTypeDetail : DevExpress.XtraEditors.XtraForm
    {
        int iFunction = 0;
        IngredientType ingredientType;
        public void setFunction(int iFunction)
        {
            this.iFunction = iFunction;
        }
        public void setIngredientType(int ingredientTypeID)
        {
            this.ingredientType = new IngredientTypeDAO().GetByID(ingredientTypeID);
        }
        public frmIngredientTypeDetail()
        {
            InitializeComponent();
        }

        private void frmIngredientTypeDetail_Load(object sender, EventArgs e)
        {
            if (iFunction == 2)
            {
                try
                {
                    txtName.Text = ingredientType.Name;
                    chkActive.Checked = ingredientType.Status;
                }
                catch
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                IngredientType entity = new IngredientType();
                entity.Name = txtName.Text;
                entity.Status = chkActive.Checked;
                if (iFunction == 1)
                {
                    if(new IngredientTypeDAO().Insert(entity) > 0)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thực hiện chức năng!", "Thông Báo");
                    }
                }else if (iFunction == 2)
                {
                    entity.IngredientTypeID = ingredientType.IngredientTypeID;
                    if(new IngredientTypeDAO().Edit(entity) == true)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thực hiện chức năng!", "Thông Báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!","Thông Báo");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}