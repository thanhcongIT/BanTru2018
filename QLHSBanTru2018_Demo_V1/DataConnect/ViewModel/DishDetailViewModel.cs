using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class DishDetailViewModel
    {
        public int DishID { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public double QuantityOfUnit { get; set; }
        public bool Status { get; set; }
    }
}
