using DataConnect.ViewModel;
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
        public DailyMenu GetDailyMenuDetail(int dailyMenuID)
        {
            try
            {
                dailyMenus = db.GetTable<DailyMenu>();
                return dailyMenus.FirstOrDefault(x => x.DailyMenuID.Equals(dailyMenuID));
            }
            catch
            {
                return null;
            }
        }
        public List<DailyMenuDetail> ListDailyMenuDetailByDailyMenuID(int dailyMenuID)
        {
            try
            {
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();
                return dailyMenuDetails.Where(x => x.DailyMenuID.Equals(dailyMenuID)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<DishViewModel> ListByMenuToViewModel(int dailyMenuID)
        {
            try
            {
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();

                var model = from dmd in dailyMenuDetails
                            where dmd.DailyMenuID.Equals(dailyMenuID)
                            select new DishViewModel
                            {
                                DishID = dmd.DishID,
                                DishName = dmd.Dish.Name,
                                MealID = dmd.Dish.MealID,
                                MealName = dmd.Dish.Meal.Name
                            };
                return model.ToList();
            }
            catch
            {
                return null;
            }
        }
        public int InsertDailyMenuDetail(DailyMenuDetail entity)
        {
            dailyMenuDetails = db.GetTable<DailyMenuDetail>();
            dailyMenuDetails.InsertOnSubmit(entity);
            db.SubmitChanges();
            return 1;
        }
        public bool InsertListDailyMenuDetail(List<DailyMenuDetail> listEntity)
        {
            try
            {
                DeleteAllDailyMenuDetailByDailyMenuID(listEntity[0].DailyMenuID);
                foreach (DailyMenuDetail item in listEntity)
                {
                    DailyMenuDetail entity = new DailyMenuDetail();
                    entity.DailyMenuID = item.DailyMenuID;
                    entity.DishID = item.DishID;
                    entity.Status = true;
                    if (InsertDailyMenuDetail(entity) <= 0)
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
        public bool InsertAllDailyMenuOfWeek(Week week)
        {
            try
            {
                foreach (var item in (new AgeGroupDAO().ListAll()))
                {
                    for (DateTime date = week.StartDate; date <= week.EndDate; date = date.AddDays(1))
                    {
                        DailyMenu entity = new DailyMenu();
                        entity.WeekID = week.WeekID;
                        entity.Date = date;
                        entity.AgeGroupID = item.AgeGroupID;
                        entity.IsForm = false;
                        entity.Status = false;

                        if (InsertDailyMenu(entity) <= 0)
                        {
                            return false;
                        }
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

        public bool DeleteAllDailyMenuDetailByDailyMenuID(int dailyMenuID)
        {
            try
            {
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();
                List<DailyMenuDetail> listDelete = dailyMenuDetails.Where(x => x.DailyMenuID.Equals(dailyMenuID)).ToList();
                foreach(var item in listDelete)
                {
                    if (!Delete(item))
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<WeeklyMenuFullViewModel> GetDailyMenu(int weekID, int weekID2, int weekID3, int weekID4, int weekID5, int ageGroupID)
        {
            dailyMenus = db.GetTable<DailyMenu>();
            dailyMenuDetails = db.GetTable<DailyMenuDetail>();
            var model = from dm in dailyMenus
                        where (dm.WeekID.Equals(weekID)||dm.WeekID.Equals(weekID2)
                        || dm.WeekID.Equals(weekID3)
                        || dm.WeekID.Equals(weekID4)
                        || dm.WeekID.Equals(weekID5)) 
                        && dm.AgeGroupID.Equals(ageGroupID)
                        select new WeeklyMenuFullViewModel
                        {
                            DailyMenuID = dm.DailyMenuID,
                            WeekID = dm.WeekID,
                            WeekIndex = dm.Week.WeekIndex,
                            DayOfWeek = "",
                            Date = dm.Date,
                            Breakfast = "(Hiện tại chưa có món ăn nào)",
                            Lunch = "(Hiện tại chưa có món ăn nào)",
                            AfterLunch = "(Hiện tại chưa có món ăn nào)",
                            Afternoon = "(Hiện tại chưa có món ăn nào)",
                            IsForm = dm.IsForm,
                            Status = dm.Status
                        };
            List<WeeklyMenuFullViewModel> model2 = model.ToList();
            for (int i = 0; i < model2.Count(); i++)
            {
                List<DailyMenuDetail> dailyMenuDetails = ListDailyMenuDetailByDailyMenuID(model2[i].DailyMenuID);

                if (dailyMenuDetails.Count > 0)
                {
                    string breakfast = "";
                    string lunch = "";
                    string afterLunch = "";
                    string afternoon = "";
                    foreach (DailyMenuDetail item in dailyMenuDetails)
                    {

                        if (item.Dish.MealID == 1)
                            breakfast = breakfast + item.Dish.Name + ", ";
                        else if (item.Dish.MealID == 2)
                            lunch = lunch + item.Dish.Name + ", ";
                        else if (item.Dish.MealID == 3)
                            afterLunch = afterLunch + item.Dish.Name + ", ";
                        else
                            afternoon = afternoon + item.Dish.Name + ", ";
                    }
                    if (breakfast.Length > 2)
                        model2[i].Breakfast = (breakfast.Substring(0, breakfast.Length - 2))!=""? breakfast.Substring(0, breakfast.Length - 2): "(Hiện tại chưa có món ăn nào)";
                    if (lunch.Length > 2)
                        model2[i].Lunch = (lunch.Substring(0, lunch.Length - 2)) != "" ? lunch.Substring(0, lunch.Length - 2) : "(Hiện tại chưa có món ăn nào)";
                    if (afterLunch.Length > 2)
                        model2[i].AfterLunch = (afterLunch.Substring(0, afterLunch.Length - 2)) != "" ? afterLunch.Substring(0, afterLunch.Length - 2) : "(Hiện tại chưa có món ăn nào)";
                    if (afternoon.Length > 2)
                        model2[i].Afternoon = (afternoon.Substring(0, afternoon.Length - 2)) != "" ? afternoon.Substring(0, afternoon.Length - 2) : "(Hiện tại chưa có món ăn nào)";
                }


                switch (model2[i].Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        model2[i].DayOfWeek = "Thứ 2";
                        break;
                    case DayOfWeek.Tuesday:
                        model2[i].DayOfWeek = "Thứ 3";
                        break;
                    case DayOfWeek.Wednesday:
                        model2[i].DayOfWeek = "Thứ 4";
                        break;
                    case DayOfWeek.Thursday:
                        model2[i].DayOfWeek = "Thứ 5";
                        break;
                    case DayOfWeek.Friday:
                        model2[i].DayOfWeek = "Thứ 6";
                        break;
                    case DayOfWeek.Saturday:
                        model2[i].DayOfWeek = "Thứ 7";
                        break;
                    default:
                        model2[i].DayOfWeek = "Chủ nhật";
                        break;
                }

            }

            return model2;
        }
        public bool HasDailyMenuOfWeek(int weekID)
        {
            try
            {
                dailyMenus = db.GetTable<DailyMenu>();
                WeekDAO weekDAO = new WeekDAO();
                Week week = weekDAO.GetByID(weekID);
                if (dailyMenus.Where(x => x.WeekID.Equals(weekID)).Count() < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public void InitDailyMenuOfWeek(int weekID)
        {
            WeekDAO weekDAO = new WeekDAO();
            Week week = weekDAO.GetByID(weekID);
            InsertAllDailyMenuOfWeek(week);
        }
    }
}
