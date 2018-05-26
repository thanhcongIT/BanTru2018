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
                foreach (DailyMenuDetail item in listEntity)
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
        public List<WeeklyMenuFullViewModel> GetDailyMenu(int weekID, int ageGroupID)
        {
            try
            {
                dailyMenus = db.GetTable<DailyMenu>();
                dailyMenuDetails = db.GetTable<DailyMenuDetail>();
                var model = from dm in dailyMenus
                            where dm.WeekID.Equals(weekID) && dm.AgeGroupID.Equals(ageGroupID)
                            select new WeeklyMenuFullViewModel
                            {
                                DailyMenuID = dm.DailyMenuID,
                                WeekID = dm.WeekID,
                                WeekIndex = dm.Week.WeekIndex,
                                DayOfWeek = "",
                                Date = dm.Date,
                                Breakfast = "",
                                Lunch = "",
                                AfterLunch = "",
                                Afternoon = "",
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
                                breakfast += item.Dish.Name + ", ";
                            else if (item.Dish.MealID == 2)
                                lunch += item.Dish.Name + ", ";
                            else if (item.Dish.MealID == 3)
                                afterLunch += item.Dish.Name + ", ";
                            else
                                afternoon += item.Dish.Name + ", ";

                            model2[i].Breakfast = breakfast.Substring(0, breakfast.Length - 1);
                            model2[i].Lunch = lunch.Substring(0, breakfast.Length - 1);
                            model2[i].AfterLunch = afterLunch.Substring(0, breakfast.Length - 1);
                            model2[i].Afternoon = afternoon.Substring(0, breakfast.Length - 1);
                        }
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
            catch
            {
                return null;
            }
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
