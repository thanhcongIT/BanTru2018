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
                            StringStatus = d.Status == true ? "Kích hoạt" : "Khóa",
                            Status = d.Status
                        };
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

        public bool Update(Dish dishEntity, List<DishDetail> listDishDetailEntity)
        {
            try
            {
                Dish obj = dishes.SingleOrDefault(x => x.DishID.Equals(dishEntity.DishID));
                obj.MealID = dishEntity.MealID;
                obj.AgeGroupID = dishEntity.AgeGroupID;
                obj.Name = dishEntity.Name;
                obj.CreatedBy = dishEntity.CreatedBy;
                obj.CreatedDate = dishEntity.CreatedDate;
                obj.Status = dishEntity.Status;
                db.SubmitChanges();

                List<DishDetail> dishDetails = new DishDetailDAO().GetByDishID(dishEntity.DishID);
                foreach(DishDetail item in listDishDetailEntity)
                {
                    bool exist = false;
                    foreach(DishDetail item2 in dishDetails)
                    {
                        if (item.DishID == item2.DishID)
                        {
                            exist = true;
                        }
                    }
                    if (exist)
                    {
                        new DishDetailDAO().Update(item);
                    }
                    else
                    {
                        new DishDetailDAO().Insert(item, dishEntity.DishID);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int dishID)
        {
            try
            {
                new DishDetailDAO().DeleteListByDish(dishID);

                Dish entity = dishes.SingleOrDefault(x => x.DishID.Equals(dishID));
                dishes.DeleteOnSubmit(entity);
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