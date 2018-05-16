using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.ViewModel;

namespace DataConnect.DAO.HungTD
{
    public class DishDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Dish> dishes;
        public DishDAO()
        {
            db = new QLHSSmartKidsDataContext();
            dishes = db.GetTable<Dish>();
        }
        public List<DishFullViewModel> ListAll()
        {
            var model = from d in dishes
                        where d.Status.Equals(true)
                        select new DishFullViewModel
                        {
                            DishID = d.DishID,
                            MealID = d.MealID,
                            MealName = d.Meal.Name,
                            AgeGroupID = d.AgeGroupID,
                            AgeGroupName = d.AgeGroup.Name,
                            Name = d.Name,
                            CreatedDate = d.CreatedDate,
                            CreatedBy = d.CreatedBy,
                            CreatedByName = d.Employee.FirstName + " " + d.Employee.LastName,
                            Status = d.Status,

                            Kcal = 0,
                            Protein = 0,
                            Fat = 0,
                            Glucose = 0,
                            Fiber = 0,
                            Canxi = 0,
                            Iron = 0,
                            Photpho = 0,
                            Kali = 0,
                            Natri = 0,
                            VitaminA = 0,
                            VitaminB1 = 0,
                            VitaminC = 0,
                            AxitFolic = 0,
                            Cholesterol = 0,
                        };
            foreach(var item in dishes)
            {
                
            }
            return model.ToList();
        }

        public Dish GetByID(int dishID)
        {
            return dishes.FirstOrDefault(x => x.DishID.Equals(dishID));
        }
        public int Insert(Dish dishEntity, List<DishDetail> listDishDetailEntity)
        {
            try
            {
                dishes.InsertOnSubmit(dishEntity);
                db.SubmitChanges();
                int a = dishEntity.DishID;
                if (new DishDetailDAO().InsertList(listDishDetailEntity, dishEntity.DishID))
                {
                    return dishEntity.DishID;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool Delete(int dishID)
        {
            try
            {
                Dish obj = dishes.FirstOrDefault(x => x.DishID.Equals(dishID));
                dishes.DeleteOnSubmit(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}