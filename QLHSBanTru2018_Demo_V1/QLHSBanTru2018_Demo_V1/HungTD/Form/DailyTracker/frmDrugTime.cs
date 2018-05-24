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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.DailyTracker
{
    public partial class frmDrugTime : DevExpress.XtraEditors.XtraForm
    {
        public int DailyTrackerID = 0;
        public string StudentFullName = "";
        public string Gender = "";

        public List<DataConnect.DailyTrackerDrugTime> listDrugTimes;

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
            listDrugTimes = new List<DataConnect.DailyTrackerDrugTime>();
        }
        public void LoadStudentDetail()
        {
            txtStudentFullName.Text = StudentFullName;
            txtGender.Text = Gender;
            tspDrugTime.TimeSpan = new TimeSpan(11, 00, 00);
        }

        private void FillGridControl()
        {
            gcMain.DataSource = null;
            gcMain.DataSource = listDrugTimes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDrugName.Text==""||txtQuantity.Text=="")
                {
                    MessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Thông Báo!");
                }
                else
                {
                    DataConnect.DailyTrackerDrugTime item = new DataConnect.DailyTrackerDrugTime();
                    item.DailyTrackerID = DailyTrackerID;
                    item.DrugTime = tspDrugTime.TimeSpan;
                    item.DrugName = txtDrugName.Text;
                    item.DrugQuantity = int.Parse(txtQuantity.Text);
                    item.Note = txtNote.Text;
                    item.Status = false;

                    listDrugTimes.Add(item);
                }
            }
            catch
            {

            }

            txtDrugName.ResetText();
            tspDrugTime.TimeSpan = new TimeSpan(11, 00, 00);
            txtQuantity.ResetText();
            txtNote.ResetText();

            FillGridControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listDrugTimes.Count() > 0)
            {
                if (new DailyTrackerDrugTimeDAO().InsertListDTDT(listDrugTimes))
                {
                    MessageBox.Show("Đã thêm vào danh sách nhắc thuốc trong ngày", "Thông Báo!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình nhắc thuốc", "Thông Báo!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}