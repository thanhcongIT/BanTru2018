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
using DataConnect.DAO.ThanhCongTC.ChiTieuThucPham;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class UsYeuCau : DevExpress.XtraEditors.XtraUserControl
    {
        public UsYeuCau()
        {
            InitializeComponent();
        }
        public void LoadIngredienRequestByDate()
        {
            TCIngredientRequestDAO dt = new TCIngredientRequestDAO();
            if (cbNgayMua.Checked==true)
            {
                grYeuCau.DataSource = dt.listIngredienRequesByDate(dtNgayMua.Value);
            }
            else
            {
                grYeuCau.DataSource = dt.lítIngredienRequesByCreatedDate(dtNgayKhoiTao.Value);
            }
            
        }
        private void UsYeuCau_Load(object sender, EventArgs e)
        {
            
        }

        private void cbNgayMua_CheckedChanged(object sender, EventArgs e)
        {
            cbNgayTao.Checked = false;
            dtNgayKhoiTao.Enabled = false;
            LoadIngredienRequestByDate();
        }

        private void cbNgayTao_CheckedChanged(object sender, EventArgs e)
        {
            cbNgayMua.Checked = false;
            dtNgayMua.Enabled = false;
            LoadIngredienRequestByDate();
        }
    }
}
