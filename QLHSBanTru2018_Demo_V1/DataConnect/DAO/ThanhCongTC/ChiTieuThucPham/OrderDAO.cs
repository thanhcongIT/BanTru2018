using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.DAO.ThanhCongTC.TCViewModle;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class OrderDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public int Insert(Order order)
        {
            Order a = new Order();
            a.OrderName = order.OrderName;
            a.Date = order.Date;
            a.EmployeeID = order.EmployeeID;
            a.Status = order.Status;
            dt.Orders.InsertOnSubmit(a);
            dt.SubmitChanges();
            return a.OrderID;
        }
        public bool Edit(Order order)
        {
            Order a = dt.Orders.FirstOrDefault(t => t.OrderID == order.OrderID);
            a.Status = order.Status;
            dt.SubmitChanges();
            return true;
        }
        public List<Order> listOrderByMonth(DateTime dateTime)
        {
            var a = dt.Orders.Where(t => t.Date.Month == dateTime.Month && t.Date.Year == dateTime.Year);
            return a.ToList();
        }
       
    }
}
