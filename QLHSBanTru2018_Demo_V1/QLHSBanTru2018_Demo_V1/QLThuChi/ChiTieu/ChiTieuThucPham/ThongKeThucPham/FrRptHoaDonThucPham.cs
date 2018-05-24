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
using DataConnect.DAO.ThanhCongTC.ChiTieuThucPham;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class FrRptHoaDonThucPham : DevExpress.XtraEditors.XtraForm
    {
        public FrRptHoaDonThucPham()
        {
            InitializeComponent();
        }
        public void LoadThongKeThucPham(int IngredientID, DateTime Date)
        {
            StatisticalDAO dt = new StatisticalDAO();
            grThongKeThucPham.DataSource = dt.ListOrderOrderDetailViewModleByMonth(IngredientID, Date);
           
        }
        private void FrRptHoaDonThucPham_Load(object sender, EventArgs e)
        {
            LoadThongKeThucPham(2,dtTheoNgay.Value);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            int a = gridView1.SelectedRowsCount;
            int[] b = gridView1.GetSelectedRows();
            MessageBox.Show("" + a + "");
            for (int i = 0; i < a; i++)
            {
                //MessageBox.Show("" + b[i] + "");
                textBox1.Text += gridView1.GetRowCellValue(b[i], gridView1.Columns["OrderName"]);
            }
        }
    }
}