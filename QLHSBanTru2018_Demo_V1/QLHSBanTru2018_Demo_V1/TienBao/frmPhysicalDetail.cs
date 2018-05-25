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
using DataConnect.DAO.TienBao;
using DataConnect.DAO.HungTD;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmPhysicalDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.Class Class;
        public DataConnect.Course Coursetable;
        public DataConnect.PhysicalAssessmentDetail m_PhysicalDetailTable;
        public DataConnect.PhysicalAssessment m_PhysicalTable;
        PhysicalAssessmentDAO m_PhysicalDAO = new PhysicalAssessmentDAO();
        PhysicalAssessmentDetailDAO m_PhysicalDetailDAO = new PhysicalAssessmentDetailDAO();

        public frmPhysicalDetail()
        {
            InitializeComponent();
        }

        #region LoadInfor
        private void FillGridControl(int ClassID, int PhysicalAssessmentID)
        {
            try
            {
                dgvPhysicalDetail.DataSource = new PhysicalAssessmentDetailDAO().ListPhysicalDetail(ClassID, PhysicalAssessmentID);

            }
            catch
            { }
        }
        #endregion

        #region LoadDAO
        private void PhysicalInsert()
        {
                DataConnect.PhysicalAssessment entity = new DataConnect.PhysicalAssessment();
                DataConnect.PhysicalAssessmentDetail entity2 = new DataConnect.PhysicalAssessmentDetail();

                if (iFunction == 1)
                {
                /*
                    int NewPhysicalID = m_PhysicalDAO.PhysicalInsert(entity);
                    if (NewPhysicalID > 0)
                    {
                        for (int i = 0; i < bandedGridView1.RowCount; i++)
                        {
                            entity2.PhysicalAssessmentID = NewPhysicalID;
                            entity2.StudentID = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["StudentID"]).ToString());
                            entity2.Height = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Height"]).ToString());
                            entity2.Weight = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Weight"]).ToString());
                            entity2.HeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["HeightRating"]).ToString();
                            entity2.WeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["WeightRating"]).ToString();
                            entity2.Note = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["NoteDetail"]).ToString();
                            entity2.Status = true;
                            if (m_PhysicalDetailDAO.PhysicalDetailInsert(entity2) == true)
                            {

                            }
                            else
                            {
                                XtraMessageBox.Show("Bản ghi " + i + "bị lỗi");
                                break;
                            }
                        }
                        XtraMessageBox.Show("Thêm kết quả cân đo thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                */
                }
                else if (iFunction == 2)
                {
                    for (int i = 0; i < bandedGridView1.RowCount; i++)
                    {
                        entity.PhysicalAssessmentID = m_PhysicalTable.PhysicalAssessmentID;
                        entity2.PhysicalAssessmentDeailID = (int)(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["PhysicalAssessmentDetailID"]));
                        entity2.PhysicalAssessmentID = m_PhysicalTable.PhysicalAssessmentID;
                        entity2.StudentID = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["StudentID"]).ToString());
                        entity2.Height = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Height"]).ToString());
                        entity2.Weight = int.Parse(bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["Weight"]).ToString());
                        entity2.HeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["HeightRating"]).ToString();
                        entity2.WeightRating = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["WeightRating"]).ToString();
                        entity2.Note = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns["NoteDetail"]).ToString();
                        entity2.Status = true;
                        if ( m_PhysicalDetailDAO.PhysicalDetailUpdate(entity2) == true)
                        {

                        }
                        else
                        {
                            XtraMessageBox.Show("Bản ghi " + i + "bị lỗi");
                            break;
                        }
                    }
                    XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        
        private void loadPhysicalDetail()
        {
            FillGridControl(Class.ClassID, m_PhysicalTable.PhysicalAssessmentID);
        }
        #endregion

        #region Event
        private void frmPhysicalDetail_Load(object sender, EventArgs e)
        {
            if (iFunction == 1)
            {
                this.Text = "Thêm mới đợt cân đo";

            }
            else if (iFunction == 2)
            {
                this.Text = "Cập nhật kết quả cân đo";
                
                loadPhysicalDetail();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            PhysicalInsert();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { this.Close(); }
           
        }

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (tabbedControlGroup1.TabPages.Count > tabbedControlGroup1.SelectedTabPageIndex + 1)
                tabbedControlGroup1.SelectedTabPageIndex += 1;
        }
        
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            if (0 <= tabbedControlGroup1.SelectedTabPageIndex - 1)
                tabbedControlGroup1.SelectedTabPageIndex -= 1;
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