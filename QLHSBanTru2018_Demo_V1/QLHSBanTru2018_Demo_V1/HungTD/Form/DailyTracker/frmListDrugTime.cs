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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.DailyTracker
{
    public partial class frmListDrugTime : DevExpress.XtraEditors.XtraForm
    {
        DateTime day = new DateTime();
        int classID = 0;
        public void setDay(DateTime day)
        {
            this.day = day;
        }
        public void setClassID(int classID)
        {
            this.classID = classID;
        }

        public frmListDrugTime()
        {
            InitializeComponent();
        }

        private void frmListDrugTime_Load(object sender, EventArgs e)
        {
            FillCombobox();
        }
        private void FillCombobox()
        {
            FillGridControl(true);
            BindingDetail();
        }
        private void FillGridControl(bool done)
        {
            gcMain.DataSource = null;
            gcMain.DataSource = new DailyTrackerDrugTimeDAO().ListDTDT(day, classID, done);
        }
        private void BindingDetail()
        {
            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("Text", gcMain.DataSource, "Note"));
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            FillGridControl(!checkEdit1.Checked);
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Now.Date, day) == 0)
            {
                var rowHandle = gridView1.FocusedRowHandle;
                new DailyTrackerDrugTimeDAO().ChangeStatus(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerDrugTimeID").ToString()));

                FillCombobox();
                checkEdit1.Checked = false;
            }
            else
            {
                MessageBox.Show("Bạn chỉ có thể chỉnh sửa thông tin của ngày hiện tại!", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Now.Date, day) == 0)
            {
                var rowHandle = gridView1.FocusedRowHandle;
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    if (new DailyTrackerDrugTimeDAO().Delete(Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "DailyTrackerDrugTimeID").ToString())))
                    {
                        FillCombobox();
                        checkEdit1.Checked = false;

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chỉ có thể chỉnh sửa thông tin của ngày hiện tại!", "Xin lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}