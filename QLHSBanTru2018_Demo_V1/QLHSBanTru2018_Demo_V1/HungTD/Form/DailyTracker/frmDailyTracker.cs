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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.DailyTracker
{
    public partial class frmDailyTracker : DevExpress.XtraEditors.XtraUserControl
    {
        int ClassID = 0;
        public void SetClassID(int classID)
        {
            this.ClassID = classID;
        }
        public frmDailyTracker()
        {
            InitializeComponent();
        }

        private void frmDailyTracker_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillCombobox();
        }
        private void FillCombobox()
        {
            cbbWeekID.DataSource = new WeekDAO().ListAll(5); //Đang test với mã khóa học 5 (2018-2019)
            cbbWeekID.DisplayMember = "WeekFullName";
            cbbWeekID.ValueMember = "WeekID";
            cbbWeekID.SelectedValue = new WeekDAO().GetWeekIDNow();
            try
            {
                cbbDayOfWeek.DataSource = new WeekDAO().ListDayOfWeek(int.Parse(cbbWeekID.SelectedValue.ToString()));
                cbbDayOfWeek.DisplayMember = "FullName";
                cbbDayOfWeek.ValueMember = "Date";

                if (int.Parse(cbbWeekID.SelectedValue.ToString()) == new WeekDAO().GetWeekIDNow())
                {
                    cbbDayOfWeek.SelectedValue = DateTime.Now.Date;
                }
                else
                {
                    cbbDayOfWeek.SelectedIndex = 0;
                }
            }
            catch
            {

            }

            FillGridControl();
        }
        private void FillGridControl()
        {

            new DailyTrackerDAO().InitDailyTrackerOfWeek(ClassID);

            try
            {
                gcMain.DataSource = new DailyTrackerDAO().ListByDayAndClass(DateTime.Parse(cbbDayOfWeek.SelectedValue.ToString()), ClassID);
            }
            catch
            {

            }
        }

        private void cbbWeekID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbDayOfWeek.DataSource = new WeekDAO().ListDayOfWeek(int.Parse(cbbWeekID.SelectedValue.ToString()));
                cbbDayOfWeek.DisplayMember = "FullName";
                cbbDayOfWeek.ValueMember = "Date";

                cbbDayOfWeek.SelectedValue = DateTime.UtcNow.Date;
                if (int.Parse(cbbWeekID.SelectedValue.ToString()) == new WeekDAO().GetWeekIDNow())
                {
                    cbbDayOfWeek.SelectedValue = DateTime.Now.Date;
                }
                else
                {
                    cbbDayOfWeek.SelectedIndex = 0;
                }
            }
            catch
            {

            }
        }

        private void cbbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridControl();
        }
    }
}
