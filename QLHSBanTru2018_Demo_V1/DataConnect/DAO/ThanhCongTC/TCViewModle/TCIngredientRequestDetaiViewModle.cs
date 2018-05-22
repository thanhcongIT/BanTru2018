using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.TCViewModle
{
    public class TCIngredientRequestDetaiViewModle
    {
        public int IngredientID { get; set; }
        public int IngredientRequestID { get; set; }
        public double? Quantity { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public bool Status { get; set; }
    }
}
