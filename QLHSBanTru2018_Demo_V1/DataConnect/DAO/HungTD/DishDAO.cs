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
        public List<DishViewModel> ListAll()
        {
            return null;
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
                if (new DishDetailDAO().InsertList(listDishDetailEntity))
                {
                    return dishEntity.DishID; ;
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