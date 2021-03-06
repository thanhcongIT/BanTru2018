﻿using System;
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
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;

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
            grcChiTiet.DataSource = OrderDetailDAO.ListTCOrderDetailViewModle;
        }
        private void FrThanhToanThucPham_Load(object sender, EventArgs e)
        {
            OrderDetailDAO.ThanhToan = false;
             EmployeeDAO dt = new EmployeeDAO();
            LoadChiTietThanhToan();
            Employee a = dt.GetByID(LoginDetail.LoginID);
            txtHoTen.Text = a.FirstName + " " + a.LastName;
            txtNgaySinh.Text = a.Birthday.Value.ToShortDateString();
            txtSDT.Text = a.Phone;
            txtDiaChi.Text = a.AddressDetail;
            MemoryStream mom = new MemoryStream(a.Image.ToArray());
            Image img = Image.FromStream(mom);
            pcAnh.Image = img;
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //decimal tong = 0;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    decimal a = (decimal)gridView1.GetRowCellValue(i, "PriceOfUnit");
            //    int b = (int)gridView1.GetRowCellValue(i, "QuantityOfUnit");
            //    gridView1.SetRowCellValue(i, gridView1.Columns["TotalPrice"], a * b);
            //    tong += (a * b);
            //}
            //txtTongTien.Text = tong.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            OrderDetailDAO.ThanhToan = false;
            this.Close();
        }
        public void viethoadon(int dong,decimal value)
        {
            grChiTiet.SetRowCellValue(dong, grChiTiet.Columns["TotalPrice"], value);
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            ////MessageBox.Show("" + e.RowHandle + "");
            //viethoadon(e.RowHandle);
            //BandedGridView view = sender as BandedGridView;
            //decimal a = 1000;
            //view.Columns["TotalPrice"]
            

        }
        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            double a = double.Parse(grChiTiet.GetRowCellValue(e.RowHandle, "QuantityOfUnit").ToString());
            grChiTiet.SetFocusedRowCellValue("TotalPrice", e.Value);
            decimal b = (decimal)grChiTiet.GetRowCellValue(e.RowHandle, "TotalPrice");
            decimal c = (decimal)a * b;
            grChiTiet.SetFocusedRowCellValue("TotalPrice", c);
            decimal tong = 0;
            for (int i = 0; i < grChiTiet.RowCount; i++)
            {
                tong += decimal.Parse(grChiTiet.GetRowCellValue(i, "TotalPrice").ToString());

            }
            txtTongTien.Text = tong.ToString();
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
                    for (int i = 0; i < grChiTiet.RowCount; i++)
                    {
                        OrderDetail c = new OrderDetail();
                        c.OrderID = b;
                        c.IngredientID = (int)grChiTiet.GetRowCellValue(i, grChiTiet.Columns["IngredientID"]);
                        c.PriceOfUnit = (decimal)grChiTiet.GetRowCellValue(i, grChiTiet.Columns["PriceOfUnit"]);
                        c.QuantityOfUnit = (int)grChiTiet.GetRowCellValue(i, "QuantityOfUnit");
                        c.TotalPrice = (decimal)grChiTiet.GetRowCellValue(i, "TotalPrice");
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
                    OrderDetailDAO.ThanhToan = true;
                    this.Close();
                    // in hóa đơn 
                 
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