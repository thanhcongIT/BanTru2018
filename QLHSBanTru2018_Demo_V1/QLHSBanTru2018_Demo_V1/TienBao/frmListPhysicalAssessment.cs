using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataConnect.DAO.HungTD;
using DataConnect.DAO.TienBao;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmListPhysicalAssessment : UserControl
    {
        public frmListPhysicalAssessment()
        {
            InitializeComponent();
        }

        #region load info
        private void FillGridControl()
        {
            try
            {
                dgvListphysical.DataSource = new PhysicalAssessmentDAO().ListPhysicalAssessment();
                BindingDetail();
            }
            catch
            { }
        }
        private void BindingDetail()
        {
            txtPhysicalName.DataBindings.Clear();
            txtPhysicalName.DataBindings.Add(new Binding("text", dgvListphysical.DataSource, "NamePhysicalAssessment"));
            txtNotePhysical.DataBindings.Clear();
            txtNotePhysical.DataBindings.Add(new Binding("text", dgvListphysical.DataSource, "NotePhysicalAssessment"));
            
            dtPhysicalDate.DataBindings.Clear();
            dtPhysicalDate.DataBindings.Add(new Binding("EditValue", dgvListphysical.DataSource, "DatePhysicalAssessment", true, DataSourceUpdateMode.OnPropertyChanged));
        }
        #endregion


        #region Event
        private void frmListPhysicalAssessment_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            FillGridControl();
        }
        private void btnthemdotcando_Click(object sender, EventArgs e)
        {
            int dong = gridView1.FocusedRowHandle;
            string PhysicalID = gridView1.GetRowCellValue(dong, gridView1.Columns["PhysicalAssessmentID"]).ToString();
            frmAddPhysicalAssessment m_frmAdd = new frmAddPhysicalAssessment();
            m_frmAdd.iFunction = 1;
            m_frmAdd.physicalAssessment = new PhysicalAssessmentDAO().GetByID(int.Parse(PhysicalID.ToString()));
            m_frmAdd.ShowDialog();
            if (m_frmAdd.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dong = gridView1.FocusedRowHandle;
            string PhysicalID = gridView1.GetRowCellValue(dong, gridView1.Columns["PhysicalAssessmentID"]).ToString();
            frmAddPhysicalAssessment m_frmAdd = new frmAddPhysicalAssessment();
            m_frmAdd.iFunction = 2;
            m_frmAdd.physicalAssessment = new PhysicalAssessmentDAO().GetByID(int.Parse(PhysicalID.ToString()));
            m_frmAdd.ShowDialog();
            if (m_frmAdd.DialogResult == DialogResult.OK)
            {
                FillGridControl();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa đợt cân đo này và dữ liệu của đợt cân đo?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int dong = gridView1.FocusedRowHandle;
                string PhysicalID = gridView1.GetRowCellValue(dong, gridView1.Columns["PhysicalAssessmentID"]).ToString();
                new PhysicalAssessmentDAO().PhysicalDelete(int.Parse(PhysicalID.ToString()));
                if (XtraMessageBox.Show(" Xóa đợt cân đo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    FillGridControl();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region STT
        private void bandedGridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = sText;
                }
                //if (!indicatorIcon)
                //    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 13;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "";

                }
            }
            catch
            {
            }
        }
        private void bandedGridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;

        }

        #endregion

    }
}
