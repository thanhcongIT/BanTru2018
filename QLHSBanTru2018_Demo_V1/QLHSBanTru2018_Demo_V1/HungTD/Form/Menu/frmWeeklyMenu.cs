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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Menu
{
    public partial class frmWeeklyMenu : DevExpress.XtraEditors.XtraUserControl
    {
        public frmWeeklyMenu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDailyMenuDetail frmDMD = new frmDailyMenuDetail();
            frmDMD.setFunction(1);
            frmDMD.setAgeGroupID(1);
            frmDMD.setTitle("Thêm mới thực đơn");
            frmDMD.ShowDialog();
            if (frmDMD.DialogResult == DialogResult.OK)
                FillCombobox();
        }
        private void FillCombobox()
        {

        }
    }
}
