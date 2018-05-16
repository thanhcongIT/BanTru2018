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

        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Glucose { get; set; }
        public double Fiber { get; set; }
        public double Canxi { get; set; }
        public double Iron { get; set; }
        public double Photpho { get; set; }
        public double Kali { get; set; }
        public double Natri { get; set; }
        public double VitaminA { get; set; }
        public double VitaminB1 { get; set; }
        public double VitaminC { get; set; }
        public double AxitFolic { get; set; }
        public double Cholesterol { get; set; }

        public bool Status { get; set; }
    }
}
