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

namespace QLHSBanTru2018_Demo_V1.TienBao
{
    public partial class frmStudentDetail : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.StudentParent StudentParents;
        public DataConnect.Class Class;
        public DataConnect.Student_Class StudentClass;

        #region System
        public frmStudentDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadInfo
        private void LoadEthnicGroupInfor()
        {
            List<DataConnect.EthnicGroup> listEthnicGroup = new EthnicGroupDAO().ListAllEthnicGroup();
            cbbEthnicGroup.DataSource = listEthnicGroup;
            cbbEthnicGroup.DisplayMember = "Name";
            cbbEthnicGroup.ValueMember = "EthnicGroupID";
        }
        private void LoadReligionInfor()
        {
            List<DataConnect.Religion> listReligion = new ReligionDAO().ListAllReligion();
            cbbReligion.DataSource = listReligion;
            cbbReligion.DisplayMember = "Name";
            cbbReligion.ValueMember = "ReligionID";
        }
        private void LoadProvinceInfor()
        {
            List<DataConnect.Location> province = new LocationDAO().ListAllProvince();
            cbbProvince.DataSource = province;
            cbbProvince.DisplayMember = "LocationName";
            cbbProvince.ValueMember = "LocationID";
            cbbProvince.SelectedIndex = 0;
        }
        private void LoadDistrictInfor(int provinceID)
        {
            List<DataConnect.Location> district = new LocationDAO().ListLocationFromParent(provinceID);
            cbbDistrict.DataSource = district;
            cbbDistrict.DisplayMember = "LocationName";
            cbbDistrict.ValueMember = "LocationID";
        }
        private void LoadWardInfor(int districtID)
        {
            List<DataConnect.Location> ward = new LocationDAO().ListLocationFromParent(districtID);
            cbbWard.DataSource = ward;
            cbbWard.DisplayMember = "LocationName";
            cbbWard.ValueMember = "LocationID";
        }
        #endregion

        #region Load DAO
        private void UpdateHocSinh()
        {
            if (txtStudentCode.Text != "" &&
             txtFirstName.Text != "" &&
             txtLastName.Text != "" &&             
             dtBirthday.Text != "" &&
             dtDateStudy.Text != "" &&
             txtHobby.Text != "" &&
             txtTalen.Text != "" &&
             txtAddressDetail.Text != "" &&
             txtFatherName.Text != "" &&
             dtFatherBirthday.Text != "" &&
             txtFatherPhone.Text != "" &&
             txtFatherJob.Text != "" &&
             txtMotherName.Text != "" &&
             txtMotherJob.Text != "" &&
             txtMotherPhone.Text != "" &&
             dtMotherBirthday.Text != "")
            {
                DataConnect.Student entity = new DataConnect.Student();
                DataConnect.StudentParent entity2 = new DataConnect.StudentParent();
                entity.StudentCode = txtStudentCode.Text;
                entity.FirstName = txtFirstName.Text;
                entity.LastName = txtLastName.Text;
                entity.HomeName = txtHomeName.Text;
                entity.Birthday = DateTime.Parse(dtBirthday.EditValue.ToString());
                entity.DateStudy = DateTime.Parse(dtDateStudy.EditValue.ToString());
                entity.Gender = cbbGender.Text == "Nữ" ? false : true;
                entity.Hobby = txtHobby.Text;
                entity.Talent = txtTalen.Text;
                if (Stream() != null)
                {
                    entity.Image = Stream().ToArray();
                }
                entity.EthnicGroupID = int.Parse(cbbEthnicGroup.SelectedValue.ToString());
                entity.ReligionID = int.Parse(cbbReligion.SelectedValue.ToString());
                entity.LocationID = int.Parse(cbbWard.SelectedValue.ToString());
                entity.AdressDetail = txtAddressDetail.Text;
                entity.Note = txtNote.Text;
                entity.Status = chbStatus.Checked ? true : false;

                entity2.FatherName = txtFatherName.Text;
                entity2.FatherBirthday = DateTime.Parse(dtFatherBirthday.EditValue.ToString());
                entity2.FatherJob = txtFatherJob.Text;
                entity2.FatherPhone = txtFatherPhone.Text;
                entity2.MotherName = txtMotherName.Text;
                entity2.MotherBirthday = DateTime.Parse(dtMotherBirthday.EditValue.ToString());
                entity2.MotherJob = txtMotherJob.Text;
                entity2.MotherPhone = txtMotherPhone.Text;

                StudentDAO m_StudentDAO = new StudentDAO();
                StudentParentsDAO m_StudentParentsDAO = new StudentParentsDAO();

                if (iFunction == 2)
                {
                    entity.StudentID = Student.StudentID;
                    entity2.StudentParentsID = StudentParents.StudentParentsID;
                    if (m_StudentDAO.StudentUpdate(entity) == true && m_StudentParentsDAO.ParentsUpdate(entity2) == true )
                    {
                        
                        XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
            }
        }
        private void loadHocSinh()
        {
            txtStudentID.Text = Convert.ToString(Student.StudentID);
            txtStudentCode.Text = Student.StudentCode;
            txtFirstName.Text = Student.FirstName;
            txtLastName.Text = Student.LastName;
            txtHomeName.Text = Student.HomeName;
            dtBirthday.EditValue = Student.Birthday;
            dtDateStudy.EditValue = Student.DateStudy;
            cbbGender.SelectedIndex = Student.Gender == true ? 0 : 1;
            txtHobby.Text = Student.Hobby;
            txtTalen.Text = Student.Talent;
            txtAddressDetail.Text = Student.AdressDetail;
            cbbEthnicGroup.SelectedValue = Student.EthnicGroupID;
            cbbReligion.SelectedValue = Student.ReligionID;
            txtFatherName.Text = StudentParents.FatherName;
            txtFatherJob.Text = StudentParents.FatherJob;
            txtFatherPhone.Text = StudentParents.FatherPhone;
            dtFatherBirthday.EditValue = StudentParents.FatherBirthday;
            txtMotherName.Text = StudentParents.MotherName;
            txtMotherJob.Text = StudentParents.MotherJob;
            txtMotherPhone.Text = StudentParents.MotherPhone;
            dtMotherBirthday.EditValue = StudentParents.MotherBirthday;
            txtClassName.Text = Class.Name;
            cbbProvince.SelectedValue = new LocationDAO().GetLocationParent(new LocationDAO().GetLocationParent(Student.LocationID));
            cbbDistrict.SelectedValue = new LocationDAO().GetLocationParent(Student.LocationID);
            cbbWard.SelectedValue = Student.LocationID;
            txtNote.Text = Student.Note;
            chbStatus.Checked = Student.Status;
            try
            {
                picImage.Image = ToImage(Student.Image.ToArray());
            }
            catch
            { }
        }
        #endregion


        #region Event
        private void frmStudentDetail_Load(object sender, EventArgs e)
        {
            LoadEthnicGroupInfor();
            LoadReligionInfor();
            LoadProvinceInfor();
            cbbProvince_SelectedIndexChanged(sender, e);
            cbbDistrict_SelectedIndexChanged(sender, e);
            if (iFunction == 2)
            {
                this.Text = "Cập nhật thông tin học sinh";
                txtStudentID.Enabled = false;
                txtClassName.Enabled = false;
                loadHocSinh();
            }
            else if (iFunction == 3)
            {
                this.Text = "Xem thông tin học sinh";
                txtStudentID.Enabled = false;
                txtClassName.Enabled = false;
                btnLuu.Enabled = false;
               
                loadHocSinh();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { this.Close(); }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            UpdateHocSinh();
        }
        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa học sinh ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                new StudentDAO().StudentDelete(int.Parse(txtStudentID.Text));
                this.Close();
            }
        }
        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void MenuThayAnh_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void cbbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDistrictInfor(int.Parse(cbbProvince.SelectedValue.ToString()));
                cbbDistrict.SelectedIndex = 0;
            }
            catch
            { }
        }
        private void cbbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadWardInfor(int.Parse(cbbDistrict.SelectedValue.ToString()));
                cbbWard.SelectedIndex = 0;
            }
            catch
            { }
        }
        #endregion


        #region Image
        private void LoadImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh đại diện";
            ofd.Filter = "Image|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
            }
        }
        private Bitmap ToImage(byte[] img)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] image = img;
            mStream.Write(image, 0, Convert.ToInt32(image.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private MemoryStream Stream()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                picImage.Image.Save(stream, ImageFormat.Jpeg);
                return stream;
            }
            catch
            {
                return null;
            }
        }
        #endregion


    }
}