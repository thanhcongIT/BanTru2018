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
            btnThoat.Hide();
            try
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
                cbbEthnicGroup.Text = TCIngredientRequestDAO.employeeReques.EthnicGroup.Name;
                cbbReligion.Text = TCIngredientRequestDAO.employeeReques.Religion.Name;
                cbbDegree.Text = TCIngredientRequestDAO.employeeReques.Degree.Name;
                txtNote.Text = TCIngredientRequestDAO.employeeReques.Note;
            }
            catch 
            {

                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}