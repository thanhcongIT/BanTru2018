using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class CourseDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Course> course;
        public CourseDAO()
        {
            db = new QLHSSmartKidsDataContext();
            course = db.GetTable<Course>();
        }
        public List<Course> ListAll()
        {
            var query = from c in course
                        select c;
            return query.ToList();
        }
        public Course GetByID(int courseID)
        {
            return course.SingleOrDefault(x => x.CourseID == courseID);
        }
        public int Insert(Course entity)
        {
            try
            {
                course.InsertOnSubmit(entity);
                db.SubmitChanges();
                //History
                return entity.CourseID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Course entity)
        {
            try
            {
                Course obj = course.Single(x => x.CourseID == entity.CourseID);
                obj.Name = entity.Name;
                obj.StartDate = entity.StartDate;
                obj.EndDate = entity.EndDate;
                obj.Status = entity.Status;
                db.SubmitChanges();
                //History
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int courseID)
        {
            try
            {
                Course obj = course.Single(x => x.CourseID == courseID);
                obj.Status = false;
                db.SubmitChanges();                

                Semester se1 = new SemesterDAO().ListByCourseID(courseID)[0];
                Semester se2 = new SemesterDAO().ListByCourseID(courseID)[1];

                new SemesterDAO().Delete(se1.SemesterID);
                new SemesterDAO().Delete(se2.SemesterID);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
