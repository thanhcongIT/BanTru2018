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
    public partial class frmCustomTime : DevExpress.XtraEditors.XtraForm
    {
        TimeSpan timeSpan=DateTime.Now.TimeOfDay;
        public TimeSpan GetTimeSpan()
        {
            return this.timeSpan;
        }
        public frmCustomTime()
        {
            InitializeComponent();
        }

        private void frmCustomTime_Load(object sender, EventArgs e)
        {
            tspTimeSpan.TimeSpan = timeSpan;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            timeSpan = tspTimeSpan.TimeSpan;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}