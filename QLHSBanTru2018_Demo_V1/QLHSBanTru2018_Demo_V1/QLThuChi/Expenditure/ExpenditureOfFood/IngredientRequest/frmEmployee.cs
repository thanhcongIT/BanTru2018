﻿using System;
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
using System.IO;
using DataConnect.DAO.ThanhCongTC.ChiTieuThucPham;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class TcFrNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public TcFrNhanVien()
        {
            InitializeComponent();
        }
        private void TcFrNhanVien_Load(object sender, EventArgs e)
        {
                txtFirstName.Text = TCIngredientRequestDAO.employeeReques.FirstName;
                txtLastName.Text = TCIngredientRequestDAO.employeeReques.LastName;
                dtBirthday.EditValue = TCIngredientRequestDAO.employeeReques.Birthday;
                cbbGender.Text = TCIngredientRequestDAO.employeeReques.Gender == true? "Nam" : "Nữ";
                txtEmail.Text = TCIngredientRequestDAO.employeeReques.Email;
                txtPhone.Text = TCIngredientRequestDAO.employeeReques.Phone;
                txtIdentityNumber.Text = TCIngredientRequestDAO.employeeReques.IdentityNumber;
                txtPlaceOfIssue.Text = TCIngredientRequestDAO.employeeReques.PlaceOfIssue;
                dtDateOfIssue.EditValue = TCIngredientRequestDAO.employeeReques.DateOfIssue;
                txtNote.Text = TCIngredientRequestDAO.employeeReques.Note;
                MemoryStream mom = new MemoryStream(TCIngredientRequestDAO.employeeReques.Image.ToArray());
                picImage.Image = Image.FromStream(mom);
                txtDanToc.Text = TCIngredientRequestDAO.employeeReques.EthnicGroup.Name;
                txtTonGiao.Text = TCIngredientRequestDAO.employeeReques.Religion.Name;
                txtHocVan.Text = TCIngredientRequestDAO.employeeReques.Degree.Name;
                txtDiaChi.Text = TCIngredientRequestDAO.employeeReques.AddressDetail;
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}