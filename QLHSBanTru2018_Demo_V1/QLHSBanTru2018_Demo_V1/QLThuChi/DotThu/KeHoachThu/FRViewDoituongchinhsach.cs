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

namespace QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu
{
    public partial class FRViewDoituongchinhsach : DevExpress.XtraEditors.XtraForm
    {
        public FRViewDoituongchinhsach()
        {
            InitializeComponent();
        }
        public void laodPreferred()
        {
            List<string> b = new List<string>();
            for (int i = 0; i < (studentReceivableDAO.PreferredID.Length - 1); i+=2)
            {
                
                string a = studentReceivableDAO.PreferredID.Substring(i,1);
                b.Add(a);
                
            }
            PreferredDAO dt = new PreferredDAO();
            List<Preferred> c = new List<Preferred>();
            foreach (var i in b )
            {
                Preferred e = dt.listPreferredByID(int.Parse(i));
                if (e!=null)
                {
                    c.Add(e);
                }
            }
            grDanhsachmiengian.DataSource = c;
        }
        private void FRViewDoituongchinhsach_Load(object sender, EventArgs e)
        {
            laodPreferred();
        }

        private void bntDong_Click(object sender, EventArgs e)
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