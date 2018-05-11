using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class IngredientViewModel
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public int IngredientTypeID { get; set; }
        public string IngredientTypeName { get; set; }
        public string Unit { get; set; }
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
        public string StringStatus { get; set; }
    }
}
