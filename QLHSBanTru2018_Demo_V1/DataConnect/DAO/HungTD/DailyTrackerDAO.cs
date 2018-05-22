using DataConnect.DAO.TienBao;
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
        public List<DailyTrackerFullViewModel> ListByDayAndClass(DateTime day, int? ClassID)
        {
            try
            {
                var model = from dt in dailyTrackers
                            where dt.Date.Equals(day) && dt.Student.Student_Classes.FirstOrDefault(x => x.Status.Equals(true)).ClassID.Equals(ClassID)
                            select new DailyTrackerFullViewModel
                            {
                                StudentID = dt.StudentID,
                                StudentFirstName = dt.Student.FirstName,
                                StudentLastName = dt.Student.LastName,
                                StudentHomeName = dt.Student.HomeName,
                                Date = dt.Date,
                                Present = dt.Present,
                                PresentString = dt.Status == false ? "" : (dt.Present == 0 ? "Vắng" : (dt.Present == 1 ? "Có mặt" : "Muộn")),
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
                                StringStatus = dt.Status == true ? "Đã ĐD" : "Chưa ĐD",
                                Gender = dt.Student.Gender,
                                BirthDay = dt.Student.Birthday,
                                StringGender = dt.Student.Gender == true ? "Nam" : "Nữ"
                            };
                return model.ToList();
            }catch
            {
                return null;
            }
        }
        public void InitDailyTrackerOfWeek(int classID)
        {
            int weekID = new WeekDAO().GetWeekIDNow();
            Week week = new WeekDAO().GetByID(weekID);
            if (dailyTrackers.Where(x=>x.WeekID.Equals(weekID)).Count() < 1)
            {
                InsertAllDailyTrackerOfWeek(week, new StudentDailyTrackerDAO().ListAllByClassID(classID));
            }
        }
    }
}
