using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class DishFullViewModel
    {
        public int DishID { get; set; }
        public int MealID { get; set; }
        public string MealName { get; set; }
        public int AgeGroupID { get; set; }
        public string AgeGroupName { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public byte[] Image { get; set; }

        public bool Status { get; set; }
    }
}
