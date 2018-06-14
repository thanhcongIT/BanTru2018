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
using QLHSBanTru2018_Demo_V1.Common;
using DataConnect.DAO.HungTD;
using DataConnect.ViewModel;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Menu
{
    public partial class frmDailyMenuDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction = 0;
        public int ageGroupID = 0;
        public DataConnect.DailyMenu dailyMenu;
        public List<DataConnect.DailyMenuDetail> dailyMenuDetails;
        public List<DishViewModel> notSelectedDish;
        public List<DishViewModel> selectedDish;
        public void setFunction(int function)
        {
            this.iFunction = function;
        }
        public void setAgeGroupID(int ageGroupID)
        {
            this.ageGroupID = ageGroupID;
        }
        public void setTitle(string title)
        {
            this.Text = title;
        }
        public void setDailyMenu(int dailyMenuID)
        {
            this.dailyMenu = new DailyMenuDAO().GetDailyMenuDetail(dailyMenuID);
        }
        public frmDailyMenuDetail()
        {
            InitializeComponent();
        }

        private void frmDailyMenuDetail_Load(object sender, EventArgs e)
        {
            notSelectedDish = new DishDAO().ListAllForMenu(ageGroupID);
            dailyMenuDetails = new DailyMenuDAO().ListDailyMenuDetailByDailyMenuID(dailyMenu.DailyMenuID);
            selectedDish = new DailyMenuDAO().ListByMenuToViewModel(dailyMenu.DailyMenuID);
            foreach(var item in selectedDish)
            {
                notSelectedDish.RemoveAll(x => x.DishID.Equals(item.DishID));
            }
            FillCombobox();
        }
        private void FillCombobox()
        {
            cbbMealID.DataSource = new MealDAO().ListAll();
            cbbMealID.DisplayMember = "Name";
            cbbMealID.ValueMember = "MealID";
            try
            {
                FillGridControl(int.Parse(cbbMealID.SelectedValue.ToString()));
                FillGridControlRight();
            }
            catch
            {

            }
        }
        private void LoadDetail()
        {

        }
        private void FillGridControl(int mealID)
        {
            gcLeft.DataSource = null;
            gcLeft.DataSource = notSelectedDish.Where(x => x.MealID.Equals(mealID));
        }
        private void FillGridControlRight()
        {
            gcRight.DataSource = null;
            gcRight.DataSource = selectedDish;
        }

        private void cbbMealID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillGridControl(int.Parse(cbbMealID.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataConnect.DailyMenuDetail entity = new DataConnect.DailyMenuDetail();
            entity.DailyMenuID = 0;
            var rowHandle = gridView2.FocusedRowHandle;
            try
            {
                entity.DailyMenuID = dailyMenu.DailyMenuID;
                entity.DishID = Convert.ToInt32(gridView2.GetRowCellValue(rowHandle, "DishID").ToString());
            }
            catch
            {

            }
            entity.Status = true;
            dailyMenuDetails.Add(entity);

            DishViewModel entity2 = new DishViewModel();
            try
            {
                entity2.DishID = Convert.ToInt32(gridView2.GetRowCellValue(rowHandle, "DishID").ToString());
                entity2.DishName = gridView2.GetRowCellValue(rowHandle, "DishName").ToString();
                entity2.MealID = int.Parse(cbbMealID.SelectedValue.ToString());
                entity2.MealName = gridView2.GetRowCellValue(rowHandle, "MealName").ToString();

                selectedDish.Add(entity2);
                notSelectedDish.RemoveAll(x => x.DishID.Equals(entity2.DishID));

                cbbMealID_SelectedIndexChanged(sender, e);
                FillGridControlRight();
            }
            catch
            {

            }

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var rowHandle = gridView1.FocusedRowHandle;


                DishViewModel entity = new DishViewModel();
                entity.DishID = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DishID").ToString());
                entity.DishName = gridView1.GetRowCellValue(rowHandle, "DishName").ToString();
                entity.MealID = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "MealID").ToString());
                entity.MealName = gridView1.GetRowCellValue(rowHandle, "MealName").ToString();

                notSelectedDish.Add(entity);

                selectedDish.RemoveAll(x => x.DishID.Equals(entity.DishID));
                dailyMenuDetails.RemoveAll(x => x.DishID.Equals(entity.DishID));

                cbbMealID_SelectedIndexChanged(sender, e);
                FillGridControlRight();
            }
            catch
            {

            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (new DailyMenuDAO().InsertListDailyMenuDetail(dailyMenuDetails))
            {
                MessageBox.Show("Cập nhật món ăn ngày " + dailyMenu.Date.ToString("dd/MM/yyyy") + " thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật món ăn ngày " + dailyMenu.Date.ToString("dd/MM/yyyy") + " không thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}