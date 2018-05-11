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

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Department
{
    public partial class frmDepartmentDetail : DevExpress.XtraEditors.XtraForm
    {
        public int Function = 0;
        public DataConnect.Department department;
        public frmDepartmentDetail()
        {
            InitializeComponent();
        }

        private void frmDepartmentDetail_Load(object sender, EventArgs e)
        {
            if (Function == 2)
            {
                try
                {
                    txtName.Text = department.Name;
                    chbStatus.Checked = department.Status == true ? true : false;
                }
                catch
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="")
            {
                DataConnect.Department entity = new DataConnect.Department();
                entity.Name = txtName.Text;
                entity.Status = chbStatus.Checked == true ? true : false;
                if (Function == 1)
                {
                    if (new DepartmentDAO().Insert(entity) == true)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thực hiện chức năng!", "Thông Báo");
                    }
                }
                else if (Function == 2)
                {
                    entity.DepartmentID = department.DepartmentID;
                    if (new DepartmentDAO().Edit(entity) == true)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thực hiện chức năng!", "Thông Báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!", "Thông Báo");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}