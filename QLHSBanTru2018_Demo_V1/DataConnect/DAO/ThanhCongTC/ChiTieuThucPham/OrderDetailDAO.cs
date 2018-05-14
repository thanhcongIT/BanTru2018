using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class OrderDetailDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
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
    }
}
