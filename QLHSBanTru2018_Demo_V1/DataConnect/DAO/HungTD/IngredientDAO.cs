using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class IngredientDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Ingredient> ingredients;
        public IngredientDAO()
        {
            db = new QLHSSmartKidsDataContext();
            ingredients = db.GetTable<Ingredient>();
        }
        public List<IngredientViewModel> ListAll()
        {
            var model = from i in ingredients
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
        public List<IngredientViewModel> ListAllActive(int ingredientTypeID)
        {
            var model = from i in ingredients
                        where i.Status == true && i.IngredientTypeID == ingredientTypeID
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
        public Ingredient GetByID(int ingredientID)
        {
            return ingredients.SingleOrDefault(x => x.IngredientID == ingredientID);
        }
        public int Insert(Ingredient entity)
        {
            try
            {
                ingredients.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.IngredientID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Ingredient entity)
        {
            try
            {
                Ingredient obj = ingredients.SingleOrDefault(x => x.IngredientID == entity.IngredientID);
                obj.Name = entity.Name;
                obj.IngredientTypeID = entity.IngredientTypeID;
                obj.Unit = entity.Unit;
                obj.Kcal = entity.Kcal;
                obj.Protein = entity.Protein;
                obj.Fat = entity.Fat;
                obj.Glucose = entity.Glucose;
                obj.Fiber = entity.Fiber;
                obj.Canxi = entity.Canxi;
                obj.Iron = entity.Iron;
                obj.Photpho = entity.Photpho;
                obj.Kali = entity.Kali;
                obj.Natri = entity.Natri;
                obj.VitaminA = entity.VitaminA;
                obj.VitaminB1 = entity.VitaminB1;
                obj.VitaminC = entity.VitaminC;
                obj.AxitFolic = entity.AxitFolic;
                obj.Cholesterol = entity.Cholesterol;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateQuantity(int ingredientID, double value, int iFunction = 0)
        {
            try
            {
                Ingredient obj = ingredients.SingleOrDefault(x => x.IngredientID == ingredientID);
                if (iFunction == 1)
                {

                }
                else if (iFunction == 2)
                {

                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int ingredientID)
        {
            try
            {
                Ingredient obj = ingredients.SingleOrDefault(x => x.IngredientID == ingredientID);
                obj.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
