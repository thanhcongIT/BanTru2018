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
using DataConnect;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTraHocPhi
{
    public partial class UsChiTraHocPhi : DevExpress.XtraEditors.XtraUserControl
    {
        public UsChiTraHocPhi()
        {
            InitializeComponent();
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
        public void LoadKhoihoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbKhoihoc.DataSource = dt.ListGradeByID((int)cbbHocky.SelectedValue);
            cbbKhoihoc.ValueMember = "GradeID";
            cbbKhoihoc.DisplayMember = "Name";
        }
        public void LoadLophoc()
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            cbbLophoc.DataSource = dt.ListClassByID((int)cbbKhoihoc.SelectedValue);
            cbbLophoc.ValueMember = "ClassID";
            cbbLophoc.DisplayMember = "Name";
        }
        public void laodDotthu()
        {
            ReceivableIDAO dt = new ReceivableIDAO();
            cbbDotthu.DataSource = dt.ListReceivable((int)cbbNamhoc.SelectedValue, (int)cbbHocky.SelectedValue);
            cbbDotthu.ValueMember = "ReceivableID";
            cbbDotthu.DisplayMember = "Name";
        }
        public void LoadKhoanPhi(int MaDot)
        {
            ReceivableDetailDAO dt = new ReceivableDetailDAO();
            cbbKhoanThu.Properties.DataSource = dt.FeedbackReceivableDetail(MaDot);
            cbbKhoanThu.Properties.ValueMember = "ReceivableDetailID";
            cbbKhoanThu.Properties.DisplayMember = "Name";
        }
        private void UsChiTraHocPhi_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNamhoc();
                LoadHocky();
                laodDotthu();
                LoadKhoihoc();
                LoadLophoc();
                LoadKhoanPhi((int)cbbDotthu.SelectedValue);
            }
            catch 
            {

                
            }
        }

        private void cbbNamhoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadHocky();
                laodDotthu();
                LoadKhoihoc();
                LoadLophoc();
                LoadKhoanPhi((int)cbbDotthu.SelectedValue);
                cbbDotthu.Refresh();
            }
            catch
            {


            }
        }

        private void cbbHocky_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                laodDotthu();
                LoadKhoihoc();
                LoadLophoc();
                LoadKhoanPhi((int)cbbDotthu.SelectedValue);
            }
            catch
            {


            }
        }

        private void cbbKhoihoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadKhoihoc();
                LoadLophoc();               
            }
            catch
            {
                
            }
        }

        private void cbbDotthu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadKhoanPhi((int)cbbDotthu.SelectedValue);
            }
            catch 
            {

               
            }
        }

        private void cbbKhoanThu_EditValueChanged(object sender, EventArgs e)
        {
            txtNgayBatDau.Text = cbbKhoanThu.GetColumnValue("StartDay").ToString();
            txtNgayKetThuc.Text = cbbKhoanThu.GetColumnValue("EndDay").ToString();
        }
    }
}
