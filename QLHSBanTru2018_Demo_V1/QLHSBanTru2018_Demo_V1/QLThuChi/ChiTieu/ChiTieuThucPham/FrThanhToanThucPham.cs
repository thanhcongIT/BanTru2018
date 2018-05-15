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
using QLHSBanTru2018_Demo_V1.Common;
using DataConnect;
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.ChiTieu.ChiTieuThucPham
{
    public partial class FrThanhToanThucPham : DevExpress.XtraEditors.XtraForm
    {
        public FrThanhToanThucPham()
        {
            InitializeComponent();
        }
       
        public void LoadChiTietThanhToan()
        {
            grChiTiet.DataSource = OrderDetailDAO.ListTCOrderDetailViewModle;
        }
        private void FrThanhToanThucPham_Load(object sender, EventArgs e)
        {
            EmployeeDAO dt = new EmployeeDAO();
            LoadChiTietThanhToan();
            Employee a = dt.GetByID(LoginDetail.LoginID);
            txtHoTen.Text = a.FirstName + " " + a.LastName;
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            decimal tong = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                decimal a = (decimal)gridView1.GetRowCellValue(i, "PriceOfUnit");
                int b = (int)gridView1.GetRowCellValue(i, "QuantityOfUnit");
                gridView1.SetRowCellValue(i, gridView1.Columns["TotalPrice"], a * b);
                tong += (a * b);
            }
            txtTongTien.Text = tong.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //decimal tong = decimal.Parse(txtTongTien.Text);
            //decimal a = (decimal)gridView1.GetRowCellValue(e.RowHandle, "PriceOfUnit");
            //int b = (int)gridView1.GetRowCellValue(e.RowHandle, "QuantityOfUnit");
            //tong += (a * b);
            //txtTongTien.Text = tong.ToString();
            //MessageBox.Show("â");
        }
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDAO dt = new OrderDAO();
                OrderDetailDAO dc = new OrderDetailDAO();
                Order a = new Order();
                a.OrderName = txtTenHoaDon.Text;
                a.TotalPrice = decimal.Parse(txtTongTien.Text);
                a.Date = DateTime.Today;
                a.EmployeeID = LoginDetail.LoginID;
                a.Status = false;
                int b = dt.Insert(a);
                if (b!=0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        OrderDetail c = new OrderDetail();
                        c.OrderID = b;
                        c.IngredientID = (int)gridView1.GetRowCellValue(i, gridView1.Columns["IngredientID"]);
                        c.PriceOfUnit = (decimal)gridView1.GetRowCellValue(i, gridView1.Columns["PriceOfUnit"]);
                        c.QuantityOfUnit = (int)gridView1.GetRowCellValue(i, "QuantityOfUnit");
                        c.TotalPrice = decimal.Parse(txtTongTien.Text);
                        c.Status = false;
                        if (dc.Insert(c) == true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Bản ghi thứ " + i + " không được lưu lại");
                            break;
                        }
                    }
                    MessageBox.Show("Lưu thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Khởi tạo thất bại");
                }
               
            }
            catch 
            {

                
            }  
        }
    }
}