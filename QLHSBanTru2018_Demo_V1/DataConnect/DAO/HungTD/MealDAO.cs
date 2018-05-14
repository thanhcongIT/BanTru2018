using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class MealDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Meal> meals;
        public MealDAO()
        {
            db = new QLHSSmartKidsDataContext();
            meals = db.GetTable<Meal>();
        }
        public List<Meal> ListAll()
        {
            return meals.Where(x => x.Status.Equals(true)).ToList();
        }
        public int Insert(Meal entity)
        {
            try
            {
                meals.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MealID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Meal entity)
        {
            try
            {
                Meal obj = meals.SingleOrDefault(x => x.MealID.Equals(entity.MealID));
                obj.Name = entity.Name;
                obj.Time = entity.Time;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int mealID)
        {
            try
            {
                Meal obj = meals.SingleOrDefault(x => x.MealID.Equals(mealID));
                obj.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Restore(int mealID)
        {
            try
            {
                Meal obj = meals.SingleOrDefault(x => x.MealID.Equals(mealID) && x.Status.Equals(false));
                obj.Status = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
