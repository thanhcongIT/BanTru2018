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
using DataConnect.DAO.ThanhCongTC;
using QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu;

namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    public partial class UsDotThuPhi : DevExpress.XtraEditors.XtraUserControl
    {
        public UsDotThuPhi()
        {
            InitializeComponent();
        }
        public void LoadDataDotThu()
        {
            ReceivableIDAO db = new ReceivableIDAO();
            grDotThu.DataSource = db.ListReceivable((int)cbbHocky.SelectedValue, (int)cbbHocky.SelectedValue);
        }
        public void LoadDataChitietdotthu()
        {
            
        }
        public void LoadNamhoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbNamhoc.DataSource = dt.ListCourse();
            cbbNamhoc.ValueMember = "CourseID";
            cbbNamhoc.DisplayMember = "Name";
        }
        public void LoadHocky()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbHocky.DataSource = dt.ListSemesterByID((int)cbbNamhoc.SelectedValue);
            cbbHocky.ValueMember = "SemesterID";
            cbbHocky.DisplayMember = "Name";
        }
        private void UsDotThuPhi_Load(object sender, EventArgs e)
        {
            //LoadDataDotThu();
            LoadNamhoc();
            LoadHocky();
            LoadDataDotThu();
        }

        private void bntThietLapKeHoachThu_Click(object sender, EventArgs e)
        {
            ReceivableDetailDAO.ListDemoReceivableDetail.Clear();
            FrThietLapKeHoachThu a = new FrThietLapKeHoachThu();
            a.ShowDialog();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMadotthu.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "ReceivableID").ToString();
                txtTendotthu.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
               // txtTongthu.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "TotalPrice").ToString();
                dtNgaybatdau.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "StartDate").ToString();
                dtNgayketthuc.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "EndDate").ToString();
                dtNgaykhoitao.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "CreatedDate").ToString();
                ReceivableDetailDAO dt = new ReceivableDetailDAO();
                grChiTietDotThu.DataSource = dt.ListReceivableDetail(int.Parse(txtMadotthu.Text));
            }
            catch 
            {

            }
           
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            studentReceivableDAO.PreferredID = gridView2.GetRowCellValue(e.FocusedRowHandle, "PreferredID").ToString();
        }

        private void danhSáchĐốiTượngMiễnGiảmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRViewDoituongchinhsach a = new FRViewDoituongchinhsach();
            a.ShowDialog();
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(245, 245, 245);
            }
            
        }

        private void cbbNamhoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadHocky();
            LoadDataDotThu();
        }

        private void cbbHocky_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataDotThu();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(245, 245, 245);
            }
        }
    }
}
