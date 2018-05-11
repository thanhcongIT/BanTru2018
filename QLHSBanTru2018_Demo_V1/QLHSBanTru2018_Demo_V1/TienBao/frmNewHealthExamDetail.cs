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
    public partial class frmNewHealthExamDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.Class Class;
        public DataConnect.HealthExamination healthExamination;
        public DataConnect.StudentParent studentparents;
        StudentDAO m_StudentDAO = new StudentDAO();
        StudentParentsDAO m_StudentParentsDAO = new StudentParentsDAO();
        StudentClassDao m_StudentClassDAO = new StudentClassDao();

        public frmNewHealthExamDetail()
        {
            InitializeComponent();
        }

        #region LoadInfo
        private void Danhsach(int ClassID)
        {
            try
            {
                dgvHealthDetail.DataSource = new HealthExaminationDetailDAO().ListStudent(ClassID);

            }
            catch
            { }
        }
        #endregion

        #region Event
        bool indicatorIcon = true;
        private void frmNewHealthExamDetail_Load(object sender, EventArgs e)
        {
            if (iFunction == 1)
            {
                this.Text = "Thêm mới kết quả khám";
                txtClassName.Text = Class.Name;
                txtHealthExamName.Text = healthExamination.Name;
                Danhsach(int.Parse(Class.ClassID.ToString()));
                
            }
        }
        private void btnNhapketquakham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
              int dong = gridView1.FocusedRowHandle;
              string StudentID = gridView1.GetRowCellValue(dong, gridView1.Columns["StudentID"]).ToString();
            frmAddHealthExaminationDetail m_addHealthDetail = new frmAddHealthExaminationDetail();
            m_addHealthDetail.iFunction = 1;
            m_addHealthDetail.healthExamination = new HealthExaminationDAO().GetByID(int.Parse(healthExamination.HealthExaminationID.ToString()));
          //  m_addHealthDetail.m_HealthExaminationDetail = new HealthExaminationDetailDAO().GetByID(int.Parse(healthExamination.HealthExaminationID.ToString()));
            m_addHealthDetail.Student = new StudentDAO().GetByID(int.Parse(StudentID.ToString()));
            m_addHealthDetail.ShowDialog();
            if (m_addHealthDetail.DialogResult == DialogResult.OK)
            {
                Danhsach(int.Parse(Class.ClassID.ToString()));
               
            }
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

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
            catch (Exception ex)
            {
            }
        }
        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        #endregion

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }
    }
}