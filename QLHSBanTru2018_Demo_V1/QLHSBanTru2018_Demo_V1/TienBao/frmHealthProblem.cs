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
    public partial class frmHealthProblem : DevExpress.XtraEditors.XtraUserControl
    {
        #region System
        public frmHealthProblem()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadInfo
        private void FillGridControl()
        {
            try
            {
                dgvHealthProblem.DataSource = new HealthProblemDAO().ListHealthProblem();
            }
            catch
            { }
        }
        #endregion

        #region Event
        private void frmHealthProblem_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            
            try
            {
                FillGridControl();
            }
            catch
            { }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmHealthProblemDetail m_frmHealthProblem = new frmHealthProblemDetail();
            m_frmHealthProblem.iFunction = 1;
            m_frmHealthProblem.ShowDialog();
            if (m_frmHealthProblem.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue("HealthProblemID") == null)
            {
                XtraMessageBox.Show("Vui lòng chọn sự cố cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
            else
            {
                int dong = gridView1.FocusedRowHandle;
                string HealthProblemID = gridView1.GetRowCellValue(dong, gridView1.Columns["HealthProblemID"]).ToString();
                frmHealthProblemDetail m_frmHealthProblem = new frmHealthProblemDetail();
                m_frmHealthProblem.iFunction = 2;
                m_frmHealthProblem.m_HealthProblem = new HealthProblemDAO().GetByID(int.Parse(HealthProblemID.ToString()));
                m_frmHealthProblem.ShowDialog();
                if (m_frmHealthProblem.DialogResult == DialogResult.OK)
                {
                    FillGridControl();
                }
            }
          
        }
        private void btnUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int dong = gridView1.FocusedRowHandle;
            string HealthProblemID = gridView1.GetRowCellValue(dong, gridView1.Columns["HealthProblemID"]).ToString();
            frmHealthProblemDetail m_frmHealthProblem = new frmHealthProblemDetail();
            m_frmHealthProblem.iFunction = 2;
            m_frmHealthProblem.m_HealthProblem = new HealthProblemDAO().GetByID(int.Parse(HealthProblemID.ToString()));
            m_frmHealthProblem.ShowDialog();
            if (m_frmHealthProblem.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("HealthProblemID") == null)
            {
                XtraMessageBox.Show("Vui lòng chọn sự cố cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show("Bạn muốn xóa sự cố y tế ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int dong = gridView1.FocusedRowHandle;
                    string HealthProblemID = gridView1.GetRowCellValue(dong, gridView1.Columns["HealthProblemID"]).ToString();
                    new HealthProblemDAO().HealthProblemDelete(int.Parse(HealthProblemID.ToString()));
                    if (XtraMessageBox.Show(" Xóa sự cố thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        FillGridControl();
                    }
                }
            }
           
        }
        #endregion

       
    }
}
