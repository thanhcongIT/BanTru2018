using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class WeekDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Week> weeks;
        public WeekDAO()
        {
            db = new QLHSSmartKidsDataContext();
            weeks = db.GetTable<Week>();
        }
        public List<WeekViewModel> ListAll(int courseID)
        {
            try
            {
                var model = from w in weeks
                            where w.CourseID.Equals(courseID)
                            select new WeekViewModel
                            {
                                WeekID = w.WeekID,
                                WeekIndex = w.WeekIndex,
                                StartDate = w.StartDate,
                                EndDate = w.EndDate,
                                WeekFullName = ""
                            };
                List<WeekViewModel> model2 = model.ToList();
                for (int i = 0; i < model2.Count(); i++)
                {
                    model2[i].WeekFullName = "Tuần " + model2[i].WeekIndex + " (" + model2[i].StartDate.ToString("dd/MM/yy") + " đến " + model2[i].EndDate.ToString("dd/MM/yy") + ")";
                }
                return model2;
            }
            catch
            {
                return null;
            }
        }
        public int GetWeekIDNow()
        {
            try
            {
                DateTime now = DateTime.Now;

                return weeks.FirstOrDefault(x => x.StartDate.Date < now && x.EndDate.Date > now).WeekID;
            }
            catch
            {
                return 0;
            }
        }
        public int Insert(Week entity)
        {
            try
            {
                weeks.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.WeekID;
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertAllWeekOfCourse(Course course)
        {
            try
            {
                int iWeekIndex = 2;
                Week w = new Week();
                w.CourseID = course.CourseID;
                w.WeekIndex = 1;
                w.StartDate = course.StartDate;
                for (DateTime d = course.StartDate; d < d.AddDays(7); d = d.AddDays(1))
                {
                    if (d.DayOfWeek == DayOfWeek.Sunday)
                    {
                        w.EndDate = d;
                        break;
                    }
                }
                w.Status = true;
                Insert(w);

                for (DateTime date = course.StartDate; date.Date <= course.EndDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Monday)
                    {
                        Week week = new Week();
                        week.CourseID = course.CourseID;
                        week.WeekIndex = iWeekIndex;
                        week.StartDate = date;
                        week.EndDate = date.AddDays(6);
                        week.Status = true;
                        iWeekIndex += 1;

                        if (Insert(week) <= 0)
                        {
                            break;
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
    }
}
