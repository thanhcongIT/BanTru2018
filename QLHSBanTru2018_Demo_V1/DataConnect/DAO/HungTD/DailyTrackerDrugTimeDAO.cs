using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DailyTrackerDrugTimeDAO
    {
        public QLHSSmartKidsDataContext db;
        public Table<DailyTrackerDrugTime> dailyTrackerDrugTimes;
        public DailyTrackerDrugTimeDAO()
        {
            db = new QLHSSmartKidsDataContext();
            dailyTrackerDrugTimes = db.GetTable<DailyTrackerDrugTime>();
        }
        public int InsertDailyTrackerDrugTime(DailyTrackerDrugTime entity)
        {
            try
            {
                dailyTrackerDrugTimes.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.DailyTrackerDrugTimeID;
            }
            catch
            {
                return 0;
            }
        }
        public bool InsertListDTDT(List<DailyTrackerDrugTime> list)
        {
            try
            {
                foreach (DailyTrackerDrugTime item in list)
                {
                    if (InsertDailyTrackerDrugTime(item) < 1)
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DailyTrackerDrugTimeViewModel> ListDTDT(DateTime day, int? classID, bool done)
        {
            try
            {
                var model = from dtdt in dailyTrackerDrugTimes
                            where dtdt.DailyTracker.Date.Equals(day) && dtdt.DailyTracker.Student.Student_Classes.FirstOrDefault(x => x.Status.Equals(true)).ClassID.Equals(classID)
                            orderby dtdt.DrugTime, dtdt.DailyTrackerID
                            select new DailyTrackerDrugTimeViewModel
                            {
                                DailyTrackerDrugTimeID = dtdt.DailyTrackerDrugTimeID,
                                DailyTrackerID = dtdt.DailyTrackerID,
                                StudentID = dtdt.DailyTracker.StudentID,
                                StudentFullName = dtdt.DailyTracker.Student.FirstName + " " + dtdt.DailyTracker.Student.LastName,
                                StudentHomeName = dtdt.DailyTracker.Student.HomeName,
                                DrugName = dtdt.DrugName,
                                DrugQuantity = dtdt.DrugQuantity,
                                DrugTime = dtdt.DrugTime,
                                RemainingTime = dtdt.DrugTime,
                                Note = dtdt.Note,
                                Status = dtdt.Status,
                                StringStatus = dtdt.Status == true ? "Hoàn thành" : "Chưa hoàn thành"
                            };
                if (done)
                    model = model.Where(x => x.Status.Equals(false));
                List<DailyTrackerDrugTimeViewModel> model2 = model.ToList();
                for (int i = 0; i < model2.Count(); i++)
                {
                    model2[i].RemainingTime = DateTime.Compare(DateTime.Now.Date, day) == 1 ? (new TimeSpan(0, 0, 0)) : (TimeSpan.Compare(model2[i].DrugTime, DateTime.Now.TimeOfDay) == 1 ? (model2[i].DrugTime - DateTime.Now.TimeOfDay) : (new TimeSpan(0, 0, 0)));
                }
                return model2;
            }
            catch
            {
                return null;
            }
        }
        public bool ChangeStatus(int dtdtID)
        {
            try
            {
                DailyTrackerDrugTime entity = dailyTrackerDrugTimes.FirstOrDefault(x => x.DailyTrackerDrugTimeID.Equals(dtdtID));
                entity.Status = true;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int dtdtID)
        {
            try
            {
                DailyTrackerDrugTime entity = dailyTrackerDrugTimes.FirstOrDefault(x => x.DailyTrackerDrugTimeID.Equals(dtdtID));
                dailyTrackerDrugTimes.DeleteOnSubmit(entity);
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
