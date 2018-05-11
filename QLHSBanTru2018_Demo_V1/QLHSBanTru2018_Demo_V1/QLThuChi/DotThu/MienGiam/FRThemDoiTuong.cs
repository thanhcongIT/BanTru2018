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
using DataConnect.DAO.ThanhCongTC;
using DataConnect;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.MienGiam
{
    public partial class FRThemDoiTuong : DevExpress.XtraEditors.XtraForm
    {
        public FRThemDoiTuong()
        {
            InitializeComponent();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PreferredDAO st = new PreferredDAO();
                Preferred dt = new Preferred();
                dt.Name = txtTemdienmiengiam.Text;
                dt.Percent = float.Parse(txtTilemiengiam.Text);
                dt.Status = true;
                if (st.Insert(dt) == true)
                {
                    MessageBox.Show("Them thanh cong");
                }
                else
                {
                    MessageBox.Show("Them khong thanh cong");
                }
            }
            catch 
            {
                MessageBox.Show("Da co loi");
            }
        }
    }
}