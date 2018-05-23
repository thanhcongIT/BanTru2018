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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.DailyTracker
{
    public partial class frmDrugTime : DevExpress.XtraEditors.XtraForm
    {
        public int DailyTrackerID = 0;
        public string StudentFullName = "";
        public string Gender = "";
        public void setDailyTrackerID(int dailyTrackerID)
        {
            this.DailyTrackerID = dailyTrackerID;
        }
        public void setStudentFullName(string studentFullName)
        {
            this.StudentFullName = studentFullName;
        }
        public void setGender(string gender)
        {
            this.Gender = gender;
        }
        public frmDrugTime()
        {
            InitializeComponent();
        }

        private void frmDrugTime_Load(object sender, EventArgs e)
        {
            LoadStudentDetail();
        }
        public void LoadStudentDetail()
        {
            txtStudentFullName.Text = StudentFullName;
            txtGender.Text = Gender;
        }
    }
}