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
        public List<DailyTrackerFullViewModel> GetDailyTrackersOfWeek(Week week, DayOfWeek day, int? ClassID)
        {
            try
            {
                var model = from dt in dailyTrackers
                            where dt.WeekID.Equals(week.WeekID) && dt.Date.DayOfWeek.Equals(day)
                            && dt.Student.Student_Classes.FirstOrDefault().ClassID.Equals(ClassID)
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
                                PresentString = dt.Reason.Equals(0) ? "Chưa điểm danh" : (dt.Reason.Equals(1) ? "Có mặt" : "Vắng mặt"),
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

                                Monday = 2,
                                Tuesday = 2,
                                Wednesday = 2,
                                Thursday = 2,
                                Friday = 2,
                                Saturday = 2,
                                Sunday = 2
                            };
                
                foreach(var item in model)
                {
                    var model2 = from dt in dailyTrackers
                                 where dt.WeekID.Equals(week.WeekID) && dt.StudentID.Equals(item.StudentID)
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

                                     Monday = null,
                                     Tuesday = null,
                                     Wednesday = null,
                                     Thursday = null,
                                     Friday = null,
                                     Saturday = null,
                                     Sunday = null
                                 };
                    item.Monday = model2.ToList()[0].Present;
                    item.Tuesday = model2.ToList()[1].Present;
                    item.Wednesday = model2.ToList()[2].Present;
                    item.Thursday = model2.ToList()[3].Present;
                    item.Friday = model2.ToList()[4].Present;
                    item.Saturday = model2.ToList()[5].Present;
                    item.Sunday = model2.ToList()[6].Present;
                }

                return model.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
