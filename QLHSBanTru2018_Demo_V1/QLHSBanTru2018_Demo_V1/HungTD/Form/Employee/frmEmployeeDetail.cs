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
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Drawing.Imaging;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Employee
{
    public partial class frmEmployeeDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmEmployeeDetail()
        {
            InitializeComponent();
        }
        public int iFunction;
        public DataConnect.Employee employee;
        private void employeeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void LoadDegreeInfor()
        {
            List<DataConnect.Degree> listDegree = new DegreeDAO().ListAllDegree();
            cbbDegree.DataSource = listDegree;
            cbbDegree.DisplayMember = "Name";
            cbbDegree.ValueMember = "DegreeID";
        }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" &&
                (txtPassword.Text != "" || iFunction!=1)&&
                txtFirstName.Text != "" &&
                txtLastName.Text != "" &&
                dtBirthday.Text != "" &&
                txtEmail.Text != "" &&
                phone.Text != "" &&
                txtIdentityNumber.Text != "" &&
                placeOfIssue.Text != "" &&
                dtDateOfIssue.Text != "")
            {
                DataConnect.Employee entity = new DataConnect.Employee();
                entity.Username = txtUsername.Text;
                entity.Password = MD5Hash.PasswordEncryptor.MD5Hash(txtPassword.Text);
                entity.FirstName = txtFirstName.Text;
                entity.LastName = txtLastName.Text;
                entity.Birthday = DateTime.Parse(dtBirthday.EditValue.ToString());
                entity.Gender = cbbGender.Text == "Nữ" ? false : true;
                if (Stream() != null)
                {
                    entity.Image = Stream().ToArray();
                }
                entity.Email = txtEmail.Text;
                entity.Phone = txtPhone.Text;
                entity.IdentityNumber = txtIdentityNumber.Text;
                entity.PlaceOfIssue = placeOfIssue.Text;
                entity.DateOfIssue = DateTime.Parse(dtDateOfIssue.EditValue.ToString());
                entity.EthnicGroupID = int.Parse(cbbEthnicGroup.SelectedValue.ToString());
                entity.ReligionID = int.Parse(cbbReligion.SelectedValue.ToString());
                entity.DegreeID = int.Parse(cbbDegree.SelectedValue.ToString());
                entity.LocationID = int.Parse(cbbWard.SelectedValue.ToString());
                entity.AddressDetail = "";
                entity.Note = txtNote.Text;
                entity.Status = chbStatus.Checked ? true : false;
                if (iFunction == 1)
                {
                    if(new EmployeeDAO().Insert(entity) == true)
                    {
                        MessageBox.Show("Thành công!", "Thêm thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi!", "Hệ thống đã xảy ra lỗi");
                    }
                }
                else if (iFunction == 2)
                {
                    entity.EmployeeID = employee.EmployeeID;
                    if (new EmployeeDAO().Update(entity) == true)
                    {
                        MessageBox.Show("Thành công!", "Cập nhật thành công!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi!", "Hệ thống đã xảy ra lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
            }
        }

        private void frmEmployeeDetail_Load(object sender, EventArgs e)
        {            
            LoadDegreeInfor();
            LoadEthnicGroupInfor();
            LoadReligionInfor();
            LoadProvinceInfor();
            cbbProvince_SelectedIndexChanged(sender, e);
            cbbDistrict_SelectedIndexChanged(sender, e);
            if (iFunction == 1)
            {
                this.Text = "Thêm mới nhân viên";
            }
            else if (iFunction == 2)
            {
                this.Text = "Chỉnh sửa nhân viên";
                txtPassword.Enabled = false;
                txtUsername.Text = employee.Username;
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                dtBirthday.EditValue = employee.Birthday;
                cbbGender.SelectedIndex = employee.Gender == true ? 0 : 1;
                txtEmail.Text = employee.Email;
                txtPhone.Text = employee.Phone;
                txtIdentityNumber.Text = employee.IdentityNumber;
                txtPlaceOfIssue.Text = employee.PlaceOfIssue;
                dtDateOfIssue.EditValue = employee.DateOfIssue;
                cbbEthnicGroup.SelectedValue = employee.EthnicGroupID;
                cbbReligion.SelectedValue = employee.ReligionID;
                cbbDegree.SelectedValue = employee.DegreeID;

                cbbProvince.SelectedValue = new LocationDAO().GetLocationParent(new LocationDAO().GetLocationParent(employee.LocationID));
                cbbDistrict.SelectedValue = new LocationDAO().GetLocationParent(employee.LocationID);
                cbbWard.SelectedValue = employee.LocationID;

                txtNote.Text = employee.Note;
                chbStatus.Checked = employee.Status;
                try
                {
                    picImage.Image = ToImage(employee.Image.ToArray());
                }
                catch
                {

                }
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
        private void cbbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDistrictInfor(int.Parse(cbbProvince.SelectedValue.ToString()));
                cbbDistrict.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void cbbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadWardInfor(int.Parse(cbbDistrict.SelectedValue.ToString()));
                cbbWard.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void ImagePictureEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh đại diện";
            ofd.Filter = "Image|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
            }
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
    }
}