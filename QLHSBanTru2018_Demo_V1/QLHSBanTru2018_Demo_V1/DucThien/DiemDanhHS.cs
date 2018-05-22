using DataConnect;
using System;
using System.Linq;

namespace QLHSBanTru2018_Demo_V1.DucThien
{
    public partial class DiemDanhHS : DevExpress.XtraEditors.XtraForm
    {
        public DiemDanhHS()
        {
            InitializeComponent();
        }
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();

        private void btnSua_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.BangDiemDanh_UPDATE(Convert.ToInt32(txtMaHS.Text), dateTimePicker1.Text, cboDiemDanh.Text, txtLyDo.Text);
            dateTimePicker2_ValueChanged(sender, e);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");

            cboDiemDanh.DataBindings.Clear();
            cboDiemDanh.DataBindings.Add("Text", gridControl1.DataSource, "Present");

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", gridControl1.DataSource, "Reason");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.BangDiemDanh_DELETE(Convert.ToInt32(txtMaHS.Text), dateTimePicker1.Text);
        }

        private void DiemDanhHS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet8.DateOfEntry' table. You can move, or remove it, as needed.
            this.dateOfEntryTableAdapter2.Fill(this.cPITQLHSBanTru2018DataSet8.DateOfEntry);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet7.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.cPITQLHSBanTru2018DataSet7.Class);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet6.DailyTask' table. You can move, or remove it, as needed.
            this.dailyTaskTableAdapter1.Fill(this.cPITQLHSBanTru2018DataSet6.DailyTask);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet4.DateOfEntry' table. You can move, or remove it, as needed.
            this.dateOfEntryTableAdapter1.Fill(this.cPITQLHSBanTru2018DataSet4.DateOfEntry);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet3.DailyTask' table. You can move, or remove it, as needed.
            this.dailyTaskTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet3.DailyTask);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet2.DateOfEntry' table. You can move, or remove it, as needed.
            this.dateOfEntryTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet2.DateOfEntry);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet.Class);

        }

        private void cboNgayTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.BangDiemDanh_SEARCH(cboLopTK.Text, dateTimePicker2.Text);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");

            cboDiemDanh.DataBindings.Clear();
            cboDiemDanh.DataBindings.Add("Text", gridControl1.DataSource, "Present");

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", gridControl1.DataSource, "Reason");
        }

        private void cboLopTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.BangDiemDanh_SEARCH(cboLopTK.Text, dateTimePicker2.Text);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");

            cboDiemDanh.DataBindings.Clear();
            cboDiemDanh.DataBindings.Add("Text", gridControl1.DataSource, "Present");

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", gridControl1.DataSource, "Reason");
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            try
            {
                dt.DailyOfEntry_INSERT(dateTimePicker2.Text);
              
            }
            catch (Exception)
            {
                
            }

            gridControl1.DataSource = dt.ABCDEFGH();
            dateTimePicker2_ValueChanged(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.BangDiemDanh_SEARCH(cboLopTK.Text, dateTimePicker2.Text);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");

            cboDiemDanh.DataBindings.Clear();
            cboDiemDanh.DataBindings.Add("Text", gridControl1.DataSource, "Present");

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", gridControl1.DataSource, "Reason");
        }
    }
}