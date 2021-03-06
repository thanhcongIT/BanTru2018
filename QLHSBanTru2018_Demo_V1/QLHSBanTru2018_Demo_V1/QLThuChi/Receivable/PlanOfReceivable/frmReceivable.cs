﻿using System;
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
            try
            {
                ReceivableIDAO db = new ReceivableIDAO();
                grcDotThu.DataSource = db.ListReceivable((int)cbbNamhoc.SelectedValue, (int)cbbHocky.SelectedValue);
            }
            catch 
            {

                
            }
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
                txtTendotthu.Text = grDotThu.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
                // txtTongthu.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "TotalPrice").ToString();
                txtNgaybatdau.Text = grDotThu.GetRowCellValue(e.FocusedRowHandle, "StartDate").ToString().Substring(0, 10);
                txtNgayketthuc.Text = grDotThu.GetRowCellValue(e.FocusedRowHandle, "EndDate").ToString().Substring(0, 10);
                txtNgaykhoitao.Text = grDotThu.GetRowCellValue(e.FocusedRowHandle, "CreatedDate").ToString().Substring(0, 10);
                ReceivableDetailDAO dt = new ReceivableDetailDAO();
                grcChiTietDotThu.DataSource = dt.ListReceivableDetail((int)grDotThu.GetRowCellValue(e.FocusedRowHandle, "ReceivableID"));
            }
            catch 
            {

            }
           
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            studentReceivableDAO.PreferredID = grChiTietMienGiam.GetRowCellValue(e.FocusedRowHandle, "PreferredID").ToString();
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
