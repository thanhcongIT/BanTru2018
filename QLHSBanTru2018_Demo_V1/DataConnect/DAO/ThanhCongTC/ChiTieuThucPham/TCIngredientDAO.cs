using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.ViewModel;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class TCIngredientDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        Table<Ingredient> ingredients;
        
        public List<IngredientViewModel> ListAllActive(int ingredientTypeID)
        {
            ingredients = dt.GetTable<Ingredient>();
            var model = from i in ingredients
                        where i.IngredientTypeID == ingredientTypeID
                        select new IngredientViewModel
                        {
                            IngredientID = i.IngredientID,
                            Name = i.Name,
                            IngredientTypeID = i.IngredientTypeID,
                            IngredientTypeName = i.IngredientType.Name,
                            Unit = i.Unit,
                            Kcal = i.Kcal,
                            Protein = i.Protein,
                            Fat = i.Fat,
                            Glucose = i.Glucose,
                            Fiber = i.Fiber,
                            Canxi = i.Canxi,
                            Iron = i.Iron,
                            Photpho = i.Photpho,
                            Kali = i.Kali,
                            Natri = i.Natri,
                            VitaminA = i.VitaminA,
                            VitaminB1 = i.VitaminB1,
                            VitaminC = i.VitaminC,
                            AxitFolic = i.AxitFolic,
                            Cholesterol = i.Cholesterol,
                            Status = i.Status,
                            StringStatus = i.Status == true ? "Kích Hoạt" : "Khóa",
                        };
            return model.ToList();
        }
    }
}
