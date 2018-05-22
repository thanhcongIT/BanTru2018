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
    public partial class TheoDoiDenMuon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TheoDoiDenMuon()
        {
            InitializeComponent();
        }

        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        private void TheoDoiDenMuon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet11.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter2.Fill(this.cPITQLHSBanTru2018DataSet11.Class);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet10.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.cPITQLHSBanTru2018DataSet10.Class);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet9.DateOfEntry' table. You can move, or remove it, as needed.
            this.dateOfEntryTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet9.DateOfEntry);
            // TODO: This line of code loads data into the 'cPITQLHSBanTru2018DataSet1.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.cPITQLHSBanTru2018DataSet1.Class);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.TheoDoiDenMuon_SELECT();

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.TheoDoiDenMuon_UPDATE(Convert.ToInt32(txtMaHS.Text), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, dateTimePicker4.Text, txtNXAnUong.Text, txtNXNguNghi.Text, txtNXSucKhoe.Text, txtNXHocTap.Text
               , txtNXChung.Text);

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
            gridControl1.DataSource = dt.TheoDoiDenMuon_INSERT(Convert.ToInt32(gridColumn1.SummaryText), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, dateTimePicker4.Text, txtNXAnUong.Text, txtNXNguNghi.Text, txtNXSucKhoe.Text, txtNXHocTap.Text
                , txtNXChung.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt.TheoDoiDenMuon_DELETE(Convert.ToInt32(txtMaHS.Text), dateTimePicker1.Text);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNhanXet_Click(object sender, EventArgs e)
        {

            gridControl1.DataSource = dt.NXHangTuan_INSERT();
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            dt.DailyOfEntry_INSERT(dateTimePicker5.Text);
        }

        private void cbNgayTK_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtMaHS.DataBindings.Clear();
            txtMaHS.DataBindings.Add("Text", gridControl1.DataSource, "StudentID");

            txtHoHS.DataBindings.Clear();
            txtHoHS.DataBindings.Add("Text", gridControl1.DataSource, "FirstName");

            txtTenHS.DataBindings.Clear();
            txtTenHS.DataBindings.Add("Text", gridControl1.DataSource, "LastName");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", gridControl1.DataSource, "DateTask");
        }

        private void Thêm_Click(object sender, EventArgs e)
        {
            try
            {
                dt.DailyOfEntry_INSERT(dateTimePicker5.Text);
            }
            catch (Exception)
            {

            }
            gridControl1.DataSource = dt.ThemNgayNhanXet_INSERT();
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dateTimePicker5_ValueChanged_2(object sender, EventArgs e)
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    
}