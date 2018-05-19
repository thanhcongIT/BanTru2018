using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DailyMenuDAO
    {
        public QLHSSmartKidsDataContext db;
        public Table<Week> weeks;
        public Table<Dish> dishes;
        public Table<DailyMenuDetail> dailyMenuDetails;
        public Table<DailyMenu> dailyMenus;
        public DailyMenuDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public int InsertDailyMenuDetail(DailyMenuDetail entity)
        {
            try
            {
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();
                dailyMenuDetails.InsertOnSubmit(entity);
                db.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertListDailyMenuDetail(List<DailyMenuDetail> listEntity)
        {
            try
            {
                foreach(DailyMenuDetail item in listEntity)
                {
                    if (InsertDailyMenuDetail(item) <= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int InsertDailyMenu(DailyMenu entity)
        {
            try
            {
                dailyMenus = db.GetTable<DailyMenu>();
                dailyMenus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertDailyMenuOfWeek(List<DailyMenu> entityDailyMenu)
        {
            try
            {
                foreach(var item in entityDailyMenu)
                {
                    if (InsertDailyMenu(item) <= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool Delete(DailyMenuDetail entity)
        {
            try
            {
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();
                DailyMenuDetail obj = dailyMenuDetails.SingleOrDefault(x => x.DailyMenuID.Equals(entity.DailyMenuID) && x.DishID.Equals(entity.DishID));
                dailyMenuDetails.DeleteOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DailyMenuDetail> GetDailyMenuDetail(int DailyMenuID)
        {
            try
            {
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();

                var model = from dmd in dailyMenuDetails
                            where dmd.DailyMenuID.Equals(DailyMenuID)
                            select dmd;
                return model.ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}
