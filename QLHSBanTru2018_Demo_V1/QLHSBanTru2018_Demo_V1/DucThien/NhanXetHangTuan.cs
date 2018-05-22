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

namespace QLHSBanTru2018_Demo_V1.DucThien
{
    public partial class NhanXetHangTuan : DevExpress.XtraEditors.XtraForm
    {
        public NhanXetHangTuan()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void NhanXetHangTuan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet13.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet13.Class);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet12.WeekYear' table. You can move, or remove it, as needed.
            this.weekYearTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet12.WeekYear);

        }
    }
}