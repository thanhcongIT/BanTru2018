using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DailyTrackerDAO
    {
        QLHSSmartKidsDataContext db;
        Table<DailyTracker> dailyTrackers;
        public DailyTrackerDAO()
        {
            db = new QLHSSmartKidsDataContext();
            dailyTrackers = db.GetTable<DailyTracker>();
        }
        public int Insert(DailyTracker entity)
        {
            try
            {
                dailyTrackers.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.DailyTrackerID;
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertAllDailyTrackerOfWeek(Week week, List<Student> students)
        {
            try
            {
                for(DateTime date = week.StartDate; date<= week.EndDate; date = date.AddDays(1))
                {
                    foreach(Student itemStudent in students)
                    {
                        DailyTracker entity = new DailyTracker();
                        entity.StudentID = itemStudent.StudentID;
                        entity.WeekID = week.WeekID;
                        entity.Date = date;
                        entity.Present = 0;
                        entity.Reason = "";
                        entity.TimeIn = null;
                        entity.TimeOut = null;
                        entity.DrugTime = null;
                        entity.Eating = null;
                        entity.Sleep = null;
                        entity.Health = null;
                        entity.Study = null;
                        entity.Note = null;
                        entity.Status = false;

                        if (Insert(entity) <= 0)
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
        public List<DailyTrackerFullViewModel> GetDailyTrackersOfWeek(Week week, DayOfWeek day)
        {
            try
            {
                var model = from dt in dailyTrackers
                            where dt.WeekID.Equals(week.WeekID) && dt.Date.DayOfWeek.Equals(day)
                            select new DailyTrackerFullViewModel
                            {
                                DailyTrackerID = dt.DailyTrackerID,
                                StudentID = dt.StudentID,
                                StudentFirstName = dt.Student.FirstName,
                                StudentLastName = dt.Student.LastName,
                                StudentHomeName = dt.Student.HomeName,
                                WeekID = dt.WeekID,
                                Date = dt.Date,
                                Present = dt.Present,
                                PresentString = dt.Reason.Equals(1) ? "Có mặt" : (dt.Reason.Equals(0) ? "Vắng mặt" : "Đến muộn"),
                                Reason = dt.Reason,
                                TimeIn = dt.TimeIn,
                                TimeOut = dt.TimeOut,
                                DrugTime = dt.DrugTime,
                                Eating = dt.Eating,
                                Sleep = dt.Sleep,
                                Health = dt.Health,
                                Study = dt.Study,
                                Note = dt.Note,
                                Status = dt.Status,

                                Monday = false,
                                Tuesday = false,
                                Wednesday = false,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = false
                            };

                foreach(var item in model)
                {

                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
