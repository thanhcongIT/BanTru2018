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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Menu
{
    public partial class frmWeeklyMenu : DevExpress.XtraEditors.XtraUserControl
    {
        public frmWeeklyMenu()
        {
            InitializeComponent();
        }
        int weekID=0;
        int ageGroupID = 0;

        private void frmWeeklyMenu_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillCombobox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void FillCombobox()
        {
            cbbWeekID.DataSource = new WeekDAO().ListAll(5);
            cbbWeekID.DisplayMember = "WeekFullName";
            cbbWeekID.ValueMember = "WeekID";
            cbbWeekID.SelectedValue = new WeekDAO().GetWeekIDNow();

            cbbAgeGroup.DataSource = new AgeGroupDAO().ListAll();
            cbbAgeGroup.DisplayMember = "Name";
            cbbAgeGroup.ValueMember = "AgeGroupID";

            try
            {
                FillGridControl((int)cbbWeekID.SelectedValue, (int)cbbAgeGroup.SelectedValue);
            }
            catch
            {

            }
        }
        private void FillGridControl(int weekID, int ageGroupID)
        {
            SplashScreenManager.ShowForm(typeof(TienBao.WaitForm));
            gcMain.DataSource = new DailyMenuDAO().GetDailyMenu(weekID, ageGroupID);
            SplashScreenManager.CloseForm();
        }

        private void cbbAgeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillGridControl((int)cbbWeekID.SelectedValue, (int)cbbAgeGroup.SelectedValue);
            }
            catch
            {

            }
        }

        private void cbbWeekID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillGridControl((int)cbbWeekID.SelectedValue, (int)cbbAgeGroup.SelectedValue);
            }
            catch
            {

            }
        }
        private void InitDailyMenu()
        {
            DailyMenuDAO dailyMenuDAO = new DailyMenuDAO();
            WeekDAO weekDAO = new WeekDAO();

            int weekIndex = weekDAO.GetWeekIndexByID(int.Parse(cbbWeekID.SelectedValue.ToString()));

            if (dailyMenuDAO.HasDailyMenuOfWeek((int)cbbWeekID.SelectedValue))
            {
                if (MessageBox.Show("Phiếu thực đơn của 'TUẦN " + weekIndex + "' hiện chưa được khởi tạo. Bạn có đồng ý khởi tạo?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(TienBao.WaitForm));
                    dailyMenuDAO.InitDailyMenuOfWeek(int.Parse(cbbWeekID.SelectedValue.ToString()));
                    FillGridControl((int)cbbWeekID.SelectedValue, (int)cbbAgeGroup.SelectedValue);
                    SplashScreenManager.CloseForm();
                }
            }
            else
            {

            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitDailyMenu();
        }

        private void btnDailyMenuDetail_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = tileView1.FocusedRowHandle;

                frmDailyMenuDetail frmDMD = new frmDailyMenuDetail();
                frmDMD.setFunction(1);
                frmDMD.setTitle("Thêm mới thực đơn");
                frmDMD.setDailyMenu(int.Parse(tileView1.GetRowCellValue(rowHandle, "DailyMenuID").ToString()));
                frmDMD.setAgeGroupID((int)cbbAgeGroup.SelectedValue);
                frmDMD.ShowDialog();
                if (frmDMD.DialogResult == DialogResult.OK)
                    FillCombobox();
            }
            catch
            {

            }
        }
    }
}
