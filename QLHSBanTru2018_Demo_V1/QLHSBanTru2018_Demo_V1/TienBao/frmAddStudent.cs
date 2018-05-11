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
    public partial class frmAddStudent : DevExpress.XtraEditors.XtraForm
    {
        public int iFunction;
        public DataConnect.Student Student;
        public DataConnect.Class Class;
        public DataConnect.Student_Class StudentClass;
        public DataConnect.StudentParent studentparents;
        StudentDAO m_StudentDAO = new StudentDAO();
        StudentParentsDAO m_StudentParentsDAO = new StudentParentsDAO();
        StudentClassDao m_StudentClassDAO = new StudentClassDao();

        #region System
        public frmAddStudent()
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
        private void ThemHocSinh()
        {
            if (txtStudentCode.Text != "" &&
             txtFirstName.Text != "" &&
             txtLastName.Text != "" &&
             dtBirthday.Text != "" &&
             txtAddressDetail.Text != "" &&
             txtClassName.Text != "" &&
             txtClassID.Text != "" &&
             dtDateStudy.Text != "")
            {
                DataConnect.Student entity = new DataConnect.Student();
                DataConnect.StudentParent entity2 = new DataConnect.StudentParent();
                DataConnect.Student_Class entity3 = new DataConnect.Student_Class();

                entity.StudentCode = txtStudentCode.Text;
                entity.FirstName = txtFirstName.Text;
                entity.LastName = txtLastName.Text;
                entity.HomeName = txtHomeName.Text;
                entity.Birthday = DateTime.Parse(dtBirthday.EditValue.ToString());
                entity.DateStudy = DateTime.Parse(dtDateStudy.EditValue.ToString());
                entity.Gender = cbbGender.Text == "Nữ" ? false : true;
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

                if (iFunction == 1)
                {
                    int NewstudentID = m_StudentDAO.StudentInsert(entity);

                    if (NewstudentID > 0)
                    {
                        entity2.StudentID = NewstudentID;
                        entity2.Password = MD5Hash.PasswordEncryptor.MD5Hash("12345");
                        entity3.ClassID = int.Parse(txtClassID.Text);
                        entity3.StudentID = NewstudentID;
                        entity3.Status = chbStatus.Checked ? true : false;
                        m_StudentParentsDAO.ParentsInsert(entity2);
                        m_StudentClassDAO.StudentClassInsert(entity3);
                        if (XtraMessageBox.Show("Bạn có muốn thêm thông tin khác ngay bây giờ? ", "Thêm học sinh thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmStudentDetail m_StudentDetail = new frmStudentDetail();
                            m_StudentDetail.iFunction = 2;
                            m_StudentDetail.Student = new StudentDAO().GetByID(NewstudentID);
                            m_StudentDetail.StudentParents = new StudentParentsDAO().GetByID(NewstudentID);
                            m_StudentDetail.Class = new ClassDAO().GetByClassID(int.Parse(txtClassID.Text));

                            m_StudentDetail.ShowDialog();
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Hệ thống đã xảy ra lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Event
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? DateStudy { get; set; }
        public bool? Gender { get; set; }
        public string AdressDetail { get; set; }
        public string Note { get; set; }
        private void frmAddStudent_Load(object sender, EventArgs e)
        {
            LoadEthnicGroupInfor();
            LoadReligionInfor();
            LoadProvinceInfor();
            cbbProvince_SelectedIndexChanged(sender, e);
            cbbDistrict_SelectedIndexChanged(sender, e);
            if (iFunction == 1)
            {
                this.Text = "Thêm mới học sinh";
                txtClassName.Text = Class.Name;
                txtClassID.Text = (Class.ClassID).ToString();
                txtClassID.Enabled = false;
                txtClassName.Enabled = false;
                txtStudentCode.Focus();
            }
            else if (iFunction == 2)
            {
                this.Text = "Thêm mới học sinh";
                txtClassName.Text = Class.Name;
                txtClassID.Text = (Class.ClassID).ToString();
                txtClassID.Enabled = false;
                txtClassName.Enabled = false;
                txtStudentCode.Focus();
                txtStudentCode.Text = StudentCode;
                txtFirstName.Text = FirstName;
                txtLastName.Text = LastName;
                txtHomeName.Text = HomeName;
                //Birthday = DateTime.Parse(dtBirthday.EditValue.ToString());
                //DateStudy = DateTime.Parse(dtDateStudy.EditValue.ToString());
                txtAddressDetail.Text = AdressDetail;
                txtNote.Text = Note;
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đóng trang này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { this.Close(); }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThemHocSinh();
            txtStudentCode.Focus();
            txtStudentCode.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtHomeName.Text = "";
            dtBirthday.Text = "";
            txtAddressDetail.Text = "";
            dtDateStudy.Text = "";
            txtNote.Text = "";
        }
        private void cbbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDistrictInfor(int.Parse(cbbProvince.SelectedValue.ToString()));
                
            }
            catch
            { }
        }
        private void cbbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadWardInfor(int.Parse(cbbDistrict.SelectedValue.ToString()));
                
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