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
            this.Dock = DockStyle.Fill;
            FillCombobox();
        }

        private void FillCombobox()
        {

        }
        private void FillGridControls()
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDishDetail frmDD = new frmDishDetail();
            var rowHandle = gridView1.FocusedRowHandle;
            try
            {
                frmDD.setDish(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString()));
            }
            catch
            {
                //var rowChild = gridView1.GetChildRowHandle(rowHandle, 0);
                //frmDD.setDish(Convert.ToInt32(gridView1.GetRowCellValue(rowChild, "DishID").ToString()));
            }
            frmDD.setFunction(1);
            frmDD.setTitle("Thêm Mới Món Ăn");
            frmDD.ShowDialog();
            if (frmDD.DialogResult == DialogResult.OK)
                FillCombobox();
        }

    }
}
