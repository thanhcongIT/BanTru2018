using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class SemesterDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Semester> semesters;
        Table<Course> courses;
        public SemesterDAO()
        {
            db = new QLHSSmartKidsDataContext();
            semesters = db.GetTable<Semester>();
            courses = db.GetTable<Course>();
        }
        public List<SemesterViewModel> ListAll(DateTime? startDate, DateTime? endDate, int courseID)
        {
            var model = db.Semesters.Where(x => x.Status == true);
            if (startDate != null)
            {
                model = model.Where(x => (DateTime.Compare(x.StartDate,(DateTime)startDate)<0));
            }
            if (endDate != null)
            {
                model = model.Where(x => (DateTime.Compare(x.EndDate, (DateTime)endDate) > 0));
            }
            if (courseID != 0)
            {
                model = model.Where(x => x.CourseID == courseID);
            }
            var res = from m in model
                      select new SemesterViewModel
                      {
                          SemesterID = m.SemesterID,
                          Name = m.Name,
                          CourseID = m.CourseID,
                          CourseName = m.Course.Name,
                          StartDate = m.StartDate,
                          EndDate = m.EndDate,
                          Status = m.Status
                      };
            return res.ToList();
        }
        public List<Semester> ListByCourseID(int courseID)
        {
            return (from s in semesters
                    where s.CourseID == courseID
                    select s).ToList();
        }
        public Semester GetBySemesterID(int semesterID)
        {
            return semesters.SingleOrDefault(x => x.SemesterID == semesterID);
        }
        public bool Insert(Semester entity)
        {
            try
            {
                semesters.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Semester entity)
        {
            try
            {
                Semester obj = semesters.Single(x => x.SemesterID == entity.SemesterID);
                obj.StartDate = entity.StartDate;
                obj.EndDate = entity.EndDate;
                obj.Status = entity.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int semesterID)
        {
            try
            {
                Semester obj = semesters.Single(x => x.SemesterID == semesterID);
                obj.Status = false;
                db.SubmitChanges();



                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteByCourse(int courseID)
        {
            try
            {
                var listDeleteSemester = semesters.Where(x => x.CourseID == courseID);
                foreach (var item in listDeleteSemester)
                {
                    Delete(item.SemesterID);
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
