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

namespace QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu
{
    public partial class FrDoiTuongchinhsach : DevExpress.XtraEditors.XtraForm
    {
        public FrDoiTuongchinhsach()
        {
            InitializeComponent();
        }
        public void loadDoituongchinhsach()
        {
            PreferredDAO dt = new PreferredDAO();
            grcDoiTuongChinhSach.DataSource = dt.ListPreferred();
        }
        public void loadDTdachon()
        {
            if (PreferredDAO.PreferredIDList!="")
            {
                for (int i = 0; i <grDoiTuongChinhSach.RowCount; i++)
                {
                    string a = grDoiTuongChinhSach.GetRowCellValue(i, grDoiTuongChinhSach.Columns["PreferredID"]).ToString();
                    //MessageBox.Show("" + a.Contains(PreferredDAO.PreferredIDList).ToString() + "");
                    if (PreferredDAO.PreferredIDList.Contains(a)==true)
                    {
                       
                        grDoiTuongChinhSach.SetRowCellValue(i, grDoiTuongChinhSach.Columns["Status"], true);
                    }
                }
            }
        }
        private void FrDoiTuongchinhsach_Load(object sender, EventArgs e)
        {
            loadDoituongchinhsach();
            loadDTdachon();
            
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            PreferredDAO.PreferredIDList = "";
            try
            {
                for (int i = 0; i < grDoiTuongChinhSach.RowCount; i++)
                {
                    if (grDoiTuongChinhSach.GetRowCellValue(i, grDoiTuongChinhSach.Columns["Status"]).ToString() == "True")
                    {
                        PreferredDAO.PreferredIDList += grDoiTuongChinhSach.GetRowCellValue(i, grDoiTuongChinhSach.Columns["PreferredID"]).ToString() + ";";
                    }
                }
            }
            catch
            {


            }
            //MessageBox.Show("" + PreferredDAO.PreferredIDList + "");
            this.Close();
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();
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