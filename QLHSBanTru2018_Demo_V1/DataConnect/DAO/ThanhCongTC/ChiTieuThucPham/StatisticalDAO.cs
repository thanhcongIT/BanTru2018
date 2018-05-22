using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.DAO.ThanhCongTC.TCViewModle;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class StatisticalDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public List<OrderOrderDetailViewModle> ListOrderOrderDetailViewModelByDay(int? IngredientID,DateTime dateTime)
        {
            var a = dt.Orders.Where(t => t.Date == dateTime);
            a.ToList();
            List<OrderOrderDetailViewModle> b = new List<OrderOrderDetailViewModle>();
            
                foreach (var i in a)
                {
                    OrderDetail c = dt.OrderDetails.FirstOrDefault(t => t.IngredientID == IngredientID && t.OrderID == i.OrderID);
                    OrderOrderDetailViewModle c1 = new OrderOrderDetailViewModle();
                    if (c != null)
                    {
                        c1.OrderID = i.OrderID;
                        c1.OrderName = i.OrderName;
                        c1.Date = i.Date;
                        c1.EmployeeID = i.EmployeeID;
                        c1.IngredientID = c.IngredientID;
                        c1.Name = c.Ingredient.Name;
                        c1.PriceOfUnit = c.PriceOfUnit;
                        c1.Unit = c.Ingredient.Unit;
                        c1.QuantityOfUnit = c.QuantityOfUnit;
                        c1.TotalPrice = c.TotalPrice;
                        b.Add(c1);
                    }

                }
                return b;          
        }
        public List<OrderOrderDetailViewModle> ListOrderOrderDetailViewModleByMonth(int? IngredientID, DateTime dateTime)
        {
            var a = dt.Orders.Where(t => t.Date.Month == dateTime.Month&&t.Date.Year==dateTime.Year);
            a.ToList();
            List<OrderOrderDetailViewModle> b = new List<OrderOrderDetailViewModle>();

            foreach (var i in a)
            {
                OrderDetail c = dt.OrderDetails.FirstOrDefault(t => t.IngredientID == IngredientID && t.OrderID == i.OrderID);
                OrderOrderDetailViewModle c1 = new OrderOrderDetailViewModle();
                if (c != null)
                {
                    c1.OrderID = i.OrderID;
                    c1.OrderName = i.OrderName;
                    c1.Date = i.Date;
                    c1.EmployeeID = i.EmployeeID;
                    c1.IngredientID = c.IngredientID;
                    c1.Name = c.Ingredient.Name;
                    c1.PriceOfUnit = c.PriceOfUnit;
                    c1.Unit = c.Ingredient.Unit;
                    c1.QuantityOfUnit = c.QuantityOfUnit;
                    c1.TotalPrice = c.TotalPrice;
                    b.Add(c1);
                }

            }
            return b;
        }
        public List<OrderOrderDetailViewModle> ListOrderOrderDetailViewModleByYear(int? IngredientID, DateTime StareDate,DateTime EndDate)
        {
            var a = dt.Orders.Where(t => t.Date>=StareDate && t.Date<=EndDate);
            a.ToList();
            List<OrderOrderDetailViewModle> b = new List<OrderOrderDetailViewModle>();

            foreach (var i in a)
            {
                OrderDetail c = dt.OrderDetails.FirstOrDefault(t => t.IngredientID == IngredientID && t.OrderID == i.OrderID);
                OrderOrderDetailViewModle c1 = new OrderOrderDetailViewModle();
                if (c != null)
                {
                    c1.OrderID = i.OrderID;
                    c1.OrderName = i.OrderName;
                    c1.Date = i.Date;
                    c1.EmployeeID = i.EmployeeID;
                    c1.IngredientID = c.IngredientID;
                    c1.Name = c.Ingredient.Name;
                    c1.PriceOfUnit = c.PriceOfUnit;
                    c1.Unit = c.Ingredient.Unit;
                    c1.QuantityOfUnit = c.QuantityOfUnit;
                    c1.TotalPrice = c.TotalPrice;
                    b.Add(c1);
                }

            }
            return b;
        }
    }
}
