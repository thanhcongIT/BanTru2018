using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class IngredientTypeDAO
    {
        QLHSSmartKidsDataContext db;
        Table<IngredientType> ingredientTypes;
        Table<Ingredient> ingredients;
        public IngredientTypeDAO()
        {
            db = new QLHSSmartKidsDataContext();
            ingredientTypes = db.GetTable<IngredientType>();
        }
        public List<IngredientTypeViewModel> ListAll()
        {
            ingredients = db.GetTable<Ingredient>();
            var model = from it in ingredientTypes
                        select new IngredientTypeViewModel
                        {
                            IngredientTypeID = it.IngredientTypeID,
                            Name = it.Name,
                            Status = it.Status,
                            StatusString = it.Status == true ? "Kích Hoạt" : "Khóa",
                            CountChild = 0
                        };
            List<IngredientTypeViewModel> listModel = model.ToList();
            for(int i = 0; i < listModel.Count(); i++)
            {
                listModel[i].CountChild = ingredients.Where(x => x.IngredientTypeID.Equals(listModel[i].IngredientTypeID)).Count();
            }
            return listModel;
        }
        private void countChild(IngredientTypeViewModel obj, int count)
        {
            obj.CountChild = count;
        }
        public List<IngredientType> ListAllActive()
        {
            return ingredientTypes.Where(x => x.Status.Equals(true)).ToList();
        }
        public IngredientType GetByID(int ingredientTypeID)
        {
            return db.IngredientTypes.SingleOrDefault(x => x.IngredientTypeID == ingredientTypeID);
        }
        public int Insert(IngredientType entity)
        {
            try
            {
                ingredientTypes.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.IngredientTypeID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(IngredientType entity)
        {
            try
            {
                IngredientType obj = ingredientTypes.SingleOrDefault(x => x.IngredientTypeID == entity.IngredientTypeID);
                obj.Name = entity.Name;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int ingredientTypeID)
        {
            try
            {
                IngredientType obj = ingredientTypes.SingleOrDefault(x => x.IngredientTypeID == ingredientTypeID);
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
