using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class IngredientTypeViewModel
    {
        public int IngredientTypeID { get; set; }
        public String Name { get; set; }
        public bool Status { get; set; }
        public String StatusString { get; set; }
        public int CountChild { get; set; }
    }
}
