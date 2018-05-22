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
using DataConnect;


namespace QLHSBanTru2018_Demo_V1.DucThien
{
    public partial class TheoDoiDenMuonHS : DevExpress.XtraEditors.XtraForm
    {
        public TheoDoiDenMuonHS()
        {
            InitializeComponent();
        }

        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

            gridControl1.DataSource = dt.TheoDoiDenMuon_SEARCH(cboLopTK.Text, dateTimePicker5.Text);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.TheoDoiDenMuon_SEARCH(cboLopTK.Text, dateTimePicker5.Text);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dt.DailyOfEntry_INSERT(dateTimePicker5.Text);
            }
            catch (Exception)
            {

            }
            gridControl1.DataSource = dt.ThemNgayNhanXet_INSERT();
            cboLop_SelectedIndexChanged(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.TheoDoiDenMuon_UPDATE(Convert.ToInt32(txtMaHS.Text), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, dateTimePicker4.Text, txtNXAnUong.Text, txtNXNguNghi.Text, txtNXSucKhoe.Text, txtNXHocTap.Text
               , txtNXChung.Text);
            cboLop_SelectedIndexChanged(sender, e);

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.TheoDoiDenMuon_DELETE(Convert.ToInt32(txtMaHS.Text), dateTimePicker1.Text);
            cboLop_SelectedIndexChanged(sender, e);
        }

        private void TheoDoiDenMuonHS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet14.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet14.Class);

        }
    }
}