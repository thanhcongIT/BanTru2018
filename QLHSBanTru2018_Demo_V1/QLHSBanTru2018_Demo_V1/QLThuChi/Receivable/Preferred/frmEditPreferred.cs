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

namespace QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.MienGiam
{
    public partial class FRSuaDoiTuong : DevExpress.XtraEditors.XtraForm
    {
        public FRSuaDoiTuong()
        {
            InitializeComponent();
        }
        public void laoddataDoituong()
        {
            PreferredDAO dt = new PreferredDAO();
            grcMiengiam.DataSource = dt.ListPreferred();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRSuaDoiTuong_Load(object sender, EventArgs e)
        {
            laoddataDoituong();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PreferredDAO dt = new PreferredDAO();
            for (int i = 0; i <grMienGiam.RowCount ; i++)
            {
                try
                {
                    Preferred a = new Preferred();
                    a.PreferredID=(int)grMienGiam.GetRowCellValue(i, grMienGiam.Columns["PreferredID"]);
                    a.Name = grMienGiam.GetRowCellValue(i, grMienGiam.Columns["Name"]).ToString();
                    a.Status =bool.Parse(grMienGiam.GetRowCellValue(i, grMienGiam.Columns["Status"]).ToString());
                    a.Percent = float.Parse(grMienGiam.GetRowCellValue(i, grMienGiam.Columns["Percent"]).ToString());
                    if (dt.Edit(a)==true)
                    {
                       
                        
                    }
                    else
                    {
                        MessageBox.Show("Bản ghi "+i+" lỗi");
                        break;
                        
                    }
                }
                catch 
                {

                    
                }
               
            }
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