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
using DataConnect.DAO.TienBao;
using DataConnect.DAO.HungTD;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmHealthExamination : DevExpress.XtraEditors.XtraUserControl
    {
        #region System
        public frmHealthExamination()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadInfo
        private void FillGridControl()
        {
            try
            {
                dgvHealthExamination.DataSource = new HealthExaminationDAO().ListHealthExamination();
                BindingDetail();
            }
            catch
            { }
        }
        private void BindingDetail()
        {
            txtHealthExamID.DataBindings.Clear();
            txtHealthExamID.DataBindings.Add(new Binding("text", dgvHealthExamination.DataSource, "HealthExaminationID"));
            txtNameExam.DataBindings.Clear();
            txtNameExam.DataBindings.Add(new Binding("text", dgvHealthExamination.DataSource, "NameExamination"));
            txtPlaceExam.DataBindings.Clear();
            txtPlaceExam.DataBindings.Add(new Binding("text", dgvHealthExamination.DataSource, "PlaceExamination"));           
            dtDateExam.DataBindings.Clear();
            dtDateExam.DataBindings.Add(new Binding("EditValue", dgvHealthExamination.DataSource, "DateExamination", true, DataSourceUpdateMode.OnPropertyChanged));
            chbStatusTrue.DataBindings.Clear();
            chbStatusTrue.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Status", true, DataSourceUpdateMode.OnPropertyChanged));

            chbHeight.DataBindings.Clear();
            chbHeight.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Height", true, DataSourceUpdateMode.OnPropertyChanged));
            chbWeight.DataBindings.Clear();
            chbWeight.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Weight", true, DataSourceUpdateMode.OnPropertyChanged));
            chbEyes.DataBindings.Clear();
            chbEyes.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Eyes", true, DataSourceUpdateMode.OnPropertyChanged));
            chbENT.DataBindings.Clear();
            chbENT.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "ENT", true, DataSourceUpdateMode.OnPropertyChanged));
            chbOral.DataBindings.Clear();
            chbOral.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Oral", true, DataSourceUpdateMode.OnPropertyChanged));
            chbInternalMedicine.DataBindings.Clear();
            chbInternalMedicine.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "InternalMedicine", true, DataSourceUpdateMode.OnPropertyChanged));
            chbSurgery.DataBindings.Clear();
            chbSurgery.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Surgery", true, DataSourceUpdateMode.OnPropertyChanged));
            chbDermatology.DataBindings.Clear();
            chbDermatology.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Dermatology", true, DataSourceUpdateMode.OnPropertyChanged));
            chbBoneMuscle.DataBindings.Clear();
            chbBoneMuscle.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "BoneMuscle", true, DataSourceUpdateMode.OnPropertyChanged));
            chbNerve.DataBindings.Clear();
            chbNerve.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Nerve", true, DataSourceUpdateMode.OnPropertyChanged));
            chbEndocrine.DataBindings.Clear();
            chbEndocrine.DataBindings.Add(new Binding("Checked", dgvHealthExamination.DataSource, "Endocrine", true, DataSourceUpdateMode.OnPropertyChanged));

        }
        #endregion

        #region Event
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 2)
            {
                if (chbStatusTrue.Checked == false)
                {
                    chbStatusFalse.Checked = true;
                }             
                timer1.Stop();
                i = 0;
            }
        }
        private void frmHealthExamination_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;           
            FillGridControl();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAddHealthExamination m_frmAddHealthExamination = new frmAddHealthExamination();
            m_frmAddHealthExamination.iFunction = 1;
            m_frmAddHealthExamination.ShowDialog();
            if (m_frmAddHealthExamination.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtHealthExamID.Text.Length == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn đợt khám cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmAddHealthExamination m_frmAddHealthExamination = new frmAddHealthExamination();
                m_frmAddHealthExamination.iFunction = 2;
                m_frmAddHealthExamination.m_HealthExamTable = new HealthExaminationDAO().GetByID(int.Parse(txtHealthExamID.Text));
                m_frmAddHealthExamination.ShowDialog();
                if (m_frmAddHealthExamination.DialogResult == DialogResult.OK)
                {
                    FillGridControl();
                }
            }
            
        }
        private void btnupdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmAddHealthExamination m_frmAddHealthExamination = new frmAddHealthExamination();
            m_frmAddHealthExamination.iFunction = 2;
            m_frmAddHealthExamination.m_HealthExamTable = new HealthExaminationDAO().GetByID(int.Parse(txtHealthExamID.Text));
            m_frmAddHealthExamination.ShowDialog();
            if (m_frmAddHealthExamination.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtHealthExamID.Text.Length == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn đợt khám cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show("Bạn muốn ngừng sử dụng đợt khám sức khỏe này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new HealthExaminationDAO().HealthExamDelete(int.Parse(txtHealthExamID.Text));
                    if (XtraMessageBox.Show(" Khóa đợt khám sức khỏe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        FillGridControl();
                    }
                }
            }
            
        }

        #endregion
    }
}
