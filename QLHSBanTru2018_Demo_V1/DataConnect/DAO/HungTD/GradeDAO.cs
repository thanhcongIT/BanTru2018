using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class GradeDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Grade> grade;
        public GradeDAO()
        {
            db = new QLHSSmartKidsDataContext();
            grade = db.GetTable<Grade>();
        }
        public List<Grade> ListAllGrade()
        {
            var query = from g in grade
                        where g.Status.Equals(true)
                        select g;
            return query.ToList();
        }
        public List<Grade> ListBySemester(int SemesterID)
        {
            return (from g in grade
                    where g.SemesterID == SemesterID
                    select g).ToList();
        }
        public Grade GetByGradeID(int gradeID)
        {
            return grade.SingleOrDefault(x => x.GradeID == gradeID);
        }
        public int Insert(Grade entity)
        {
            try
            {
                grade.InsertOnSubmit(entity);
                db.SubmitChanges();
                //Insert History
                return entity.GradeID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Grade entity)
        {
            try
            {
                Grade obj = grade.Single(x => x.GradeID == entity.GradeID);
                obj.SemesterID = entity.SemesterID;
                obj.Name = entity.Name;
                obj.Note = entity.Note;
                obj.Status = entity.Status;
                db.SubmitChanges();
                //Insert History
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public bool Delete(int gradeID)
        {
            try
            {
                Grade obj = grade.Single(x => x.GradeID == gradeID);
                obj.Status = false;
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBySemester(int semesterID)
        {
            try
            {
                var listDeleteGrade = grade.Where(x => x.SemesterID == semesterID);
                foreach(var item in listDeleteGrade)
                {
                    Delete(item.GradeID);
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
