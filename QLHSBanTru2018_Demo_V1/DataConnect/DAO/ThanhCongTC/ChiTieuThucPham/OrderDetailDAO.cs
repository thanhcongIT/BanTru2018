﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.DAO.ThanhCongTC.TCViewModle;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class OrderDetailDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public static bool ThanhToan = false;
        public bool Insert(OrderDetail orderDetail)
        {
            OrderDetail a = new OrderDetail();
            a.OrderID = orderDetail.OrderID;
            a.IngredientID = orderDetail.IngredientID;
            a.PriceOfUnit = orderDetail.PriceOfUnit;
            a.QuantityOfUnit = orderDetail.QuantityOfUnit;
            a.TotalPrice = orderDetail.TotalPrice;
            a.Status = orderDetail.Status;
            dt.OrderDetails.InsertOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public bool Edit(OrderDetail orderDetail)
        {
            OrderDetail a = dt.OrderDetails.FirstOrDefault(t => t.OrderID == orderDetail.OrderID && t.IngredientID == orderDetail.IngredientID);
            a.Status = orderDetail.Status;
            return true;
        }
        public List<OrderDetail> ListOrderDetailByID(int OrderID)
        {
            var a = dt.OrderDetails.Where(t => t.OrderID == OrderID);
            return a.ToList();
        }
        public static List<TCOrderDetailViewModle> ListTCOrderDetailViewModle = new List<TCOrderDetailViewModle>();
        public TCOrderDetailViewModle OrderDetailViewModle(OrderDetail O)
        {
            Ingredient a = dt.Ingredients.FirstOrDefault(t => t.IngredientID == O.IngredientID);
            TCOrderDetailViewModle b = new TCOrderDetailViewModle();
            b.IngredientID = O.IngredientID;
            b.OrderID = O.OrderID;
            b.Name = a.Name;
            b.PriceOfUnit = O.PriceOfUnit;
            b.Unit = a.Unit;
            b.QuantityOfUnit = (int)O.QuantityOfUnit;
            b.TotalPrice = O.TotalPrice;
            b.Status = O.Status;
            return b;
        }
        public List<TCOrderDetailViewModle> listModel(int o)
        {
            List<TCOrderDetailViewModle> a1 = new List<TCOrderDetailViewModle>();
            var a = dt.OrderDetails.Where(t => t.OrderID == o);
            a.ToList();
            foreach (var i in a)
            {
                Ingredient y = dt.Ingredients.FirstOrDefault(t => t.IngredientID ==i.IngredientID);
                TCOrderDetailViewModle b = new TCOrderDetailViewModle();
                b.IngredientID = i.IngredientID;
                b.OrderID = i.OrderID;
                b.Name = y.Name;
                b.PriceOfUnit = i.PriceOfUnit;
                b.Unit = y.Unit;
                b.QuantityOfUnit = (int)i.QuantityOfUnit;
                b.TotalPrice = i.TotalPrice;
                b.Status = i.Status;
                a1.Add(b);
            }
            return a1;
        }
    }
}
