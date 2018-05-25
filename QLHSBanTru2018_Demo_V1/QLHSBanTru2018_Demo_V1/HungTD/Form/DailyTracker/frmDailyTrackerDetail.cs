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
using DataConnect.DAO.TienBao;
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.DailyTracker
{
    public partial class frmDailyTrackerDetail : DevExpress.XtraEditors.XtraForm
    {
        public int dailyTrackerID = 0;
        public int studentID = 0;
        public string className = "";
        public string weekName = "";
        public string dayName = "";
        public DataConnect.Student student;
        public DataConnect.DailyTracker dailyTracker;
        public void setDailyTrackerID(int id)
        {
            this.dailyTrackerID = id;
        }
        public void setStudentID(int id)
        {
            this.studentID = id;
        }
        public void setClassName(string name)
        {
            this.className = name;
        }
        public void setWeekName(string name)
        {
            this.weekName = name;
        }
        public void setDayName(string name)
        {
            this.dayName = name;
        }

        public frmDailyTrackerDetail()
        {
            InitializeComponent();
        }

        private void frmDailyTrackerDetail_Load(object sender, EventArgs e)
        {
            FillCombobox();
            student = new StudentDAO().GetByID(studentID);
            dailyTracker = new DailyTrackerDAO().GetByID(dailyTrackerID);
            LoadDetail();

        }
        private void FillCombobox()
        {
            //For cbbPresent
            List<Present> presents = new List<Present>();
            presents.Add(new Present
            {
                present = 0,
                stringPresent = "Vắng"
            });
            presents.Add(new Present
            {
                present = 1,
                stringPresent = "Có mặt"
            });
            presents.Add(new Present
            {
                present = 2,
                stringPresent = "Muộn"
            });

            cbbPresent.DataSource = presents;
            cbbPresent.DisplayMember = "stringPresent";
            cbbPresent.ValueMember = "present";

        }
        private void LoadDetail()
        {
            try
            {
                txtName.Text = student.FirstName + " " + student.LastName;
                txtHomeName.Text = student.HomeName;
                txtClassName.Text = className;
                txtWeek.Text = weekName;
                txtDay.Text = dayName;

                cbbPresent.SelectedValue = dailyTracker.Present;

                txtReason.Text = dailyTracker.Reason;
                if (dailyTracker.Eating != null)
                    cbbEating.SelectedIndex = int.Parse(dailyTracker.Eating.ToString());
                if (dailyTracker.Sleep != null)
                    cbbSleep.SelectedIndex = int.Parse(dailyTracker.Sleep.ToString());
                if (dailyTracker.Health != null)
                    cbbHealth.SelectedIndex = int.Parse(dailyTracker.Health.ToString());
                if (dailyTracker.Study != null)
                    cbbStudy.SelectedIndex = int.Parse(dailyTracker.Study.ToString());
                txtNote.Text = dailyTracker.Note;
                TimeSpan timeIn = new TimeSpan(8, 00, 00);
                TimeSpan timeOut = new TimeSpan(17, 00, 00);
                if (dailyTracker.TimeIn.HasValue)
                {
                    timeIn = dailyTracker.TimeIn.Value;
                }
                if (dailyTracker.TimeOut.HasValue)
                {
                    timeOut = dailyTracker.TimeOut.Value;
                }
                tspTimeIn.TimeSpan = timeIn;
                tspTimeOut.TimeSpan = timeOut;
            }
            catch
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (true)
            {
                dailyTracker.Present = int.Parse(cbbPresent.SelectedValue.ToString());
                dailyTracker.Reason = txtReason.Text;
                dailyTracker.TimeIn = tspTimeIn.TimeSpan;
                dailyTracker.TimeOut = tspTimeOut.TimeSpan;
                dailyTracker.Eating = cbbEating.SelectedIndex;
                dailyTracker.Sleep = cbbSleep.SelectedIndex;
                dailyTracker.Health = cbbHealth.SelectedIndex;
                dailyTracker.Study = cbbStudy.SelectedIndex;
                dailyTracker.Note = txtNote.Text;
                dailyTracker.Status = true;

                if (new DailyTrackerDAO().Edit(dailyTracker))
                {
                    MessageBox.Show("Cập nhật đánhh giá thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi!", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi!", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Present
    {
        public int present { get; set; }
        public string stringPresent { get; set; }
    }
}