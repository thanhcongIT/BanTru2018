﻿using System;
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
            this.Dock = DockStyle.Fill;
        }

        private void frmDailyTracker_Load(object sender, EventArgs e)
        {
            FillCombobox();
            InitDailyTracker();
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
        private void InitDailyTracker()
        {
            DailyTrackerDAO dailyTrackerDAO = new DailyTrackerDAO();
            WeekDAO weekDAO = new WeekDAO();

            int weekIndex = weekDAO.GetWeekIndexByID(weekDAO.GetWeekIDNow());
            if (dailyTrackerDAO.HasDailyTrackerOfWeek())
            {
                if (MessageBox.Show("Phiếu điểm danh của 'TUẦN " + weekIndex + "' hiện chưa được khởi tạo. Bạn có đồng ý khởi tạo?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(TienBao.WaitForm));
                    dailyTrackerDAO.InitDailyTrackerOfWeek(ClassID);
                    FillGridControl();
                    SplashScreenManager.CloseForm();
                }
            }
            else
            {
                MessageBox.Show("Tải về thông tin điểm danh của 'TUẦN " + weekIndex + "' thành công!", "Thông Báo!");
            }
        }
        private void FillGridControl()
        {
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

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitDailyTracker();
        }

        private void btnPresent1_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            new DailyTrackerDAO().ChangePresent(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()),1);
            FillGridControl();
        }

        private void btnPresent0_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            new DailyTrackerDAO().ChangePresent(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), 0);
            FillGridControl();
        }

        private void btnPresent2_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            new DailyTrackerDAO().ChangePresent(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), 2);
            FillGridControl();
        }

        private void btnSetTimeInNow_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            if (DateTime.Now.TimeOfDay<new TimeSpan(8,00,00))
            {
                new DailyTrackerDAO().ChangeTimeIn(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), DateTime.Now.TimeOfDay, 1);
            }
            else
            {
                new DailyTrackerDAO().ChangeTimeIn(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), DateTime.Now.TimeOfDay, 2);
            }
            FillGridControl();
        }

        private void btnSetTimeInCustom_Click(object sender, EventArgs e)
        {
            frmCustomTime frmCT = new frmCustomTime();
            frmCT.ShowDialog();
            if (frmCT.DialogResult == DialogResult.OK)
            {
                TimeSpan timeSpan = frmCT.GetTimeSpan();
                var rowHandle = gridView1.FocusedRowHandle;
                if(timeSpan<new TimeSpan(8, 00, 00))
                {
                    new DailyTrackerDAO().ChangeTimeIn(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), timeSpan, 1);
                }
                else
                {
                    new DailyTrackerDAO().ChangeTimeIn(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), timeSpan, 2);
                }
                FillGridControl();
            }


        }

        private void btnSetTimeOutNow_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;

            new DailyTrackerDAO().ChangeTimeOut(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), DateTime.Now.TimeOfDay);
            FillGridControl();
        }

        private void btnSetTimeOutCustom_Click(object sender, EventArgs e)
        {
            frmCustomTime frmCT = new frmCustomTime();
            frmCT.ShowDialog();
            if (frmCT.DialogResult == DialogResult.OK)
            {
                TimeSpan timeSpan = frmCT.GetTimeSpan();
                var rowHandle = gridView1.FocusedRowHandle;
                new DailyTrackerDAO().ChangeTimeOut(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()), timeSpan);
                FillGridControl();
            }
        }

        private void btnDrugTime_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;

            frmDrugTime frmDT = new frmDrugTime();
            frmDT.setDailyTrackerID(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerID").ToString()));
            frmDT.setStudentFullName(gridView1.GetRowCellValue(rowHandle, "StudentFullName").ToString());
            frmDT.setGender(gridView1.GetRowCellValue(rowHandle, "StringGender").ToString());
            frmDT.ShowDialog();
        }
    }
}
