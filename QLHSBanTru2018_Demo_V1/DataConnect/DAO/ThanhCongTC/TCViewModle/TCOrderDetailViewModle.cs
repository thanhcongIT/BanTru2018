using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.TCViewModle
{
    public class TCOrderDetailViewModle
    {
        public int OrderID { get; set; }
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public decimal PriceOfUnit { get; set; }
        public string Unit { get; set; }
        public int QuantityOfUnit { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}
