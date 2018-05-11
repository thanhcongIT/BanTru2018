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
using DataConnect;
using DataConnect.DAO.ThanhCongTC;
using QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.MienGiam;

namespace QLHSBanTru2018_Demo_V1.QLThuChi
{
    public partial class FRDienMienGiam : DevExpress.XtraEditors.XtraForm
    {
        public FRDienMienGiam()
        {
            InitializeComponent();
        }
        public void loadMiengiam()
        {
            PreferredDAO dt = new PreferredDAO();
            grMiengiam.DataSource = dt.ListPreferred();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRDienMienGiam_Load(object sender, EventArgs e)
        {
            loadMiengiam();
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            FRThemDoiTuong a = new FRThemDoiTuong();
            a.ShowDialog();
            loadMiengiam();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            FRSuaDoiTuong a = new FRSuaDoiTuong();
            a.ShowDialog();
            loadMiengiam();
        }
        public string preferredName = "";
        public int prID = 0;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                preferredName = gridView1.GetRowCellValue(e.FocusedRowHandle, "Name").ToString();
                prID = int.Parse(gridView1.GetRowCellValue(e.FocusedRowHandle, "PreferredI").ToString());
            }
            catch 
            {

                
            }
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ban co muon xoa doi tuong:"+preferredName+"","Thong bao",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==DialogResult.Yes)
            {
                PreferredDAO dt = new PreferredDAO();
                try
                {
                    Preferred a = new Preferred();
                    a.PreferredID = prID;
                    if (dt.Remove(a)==true)
                    {
                        MessageBox.Show("Xoa thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Xoa khong thanh cong");
                    }

                }
                catch 
                {

                    
                }
            }
            loadMiengiam();
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