using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DataConnect.DAO.TienBao
{
   public class StudentClassDao
   {
        QLHSSmartKidsDataContext db;
        Table<Student_Class> StudentClassTable;
        public StudentClassDao()
        {
            db = new QLHSSmartKidsDataContext();
            StudentClassTable = db.GetTable<Student_Class>();
        }
        public Student_Class GetByID(int StudentID)
        {
            StudentClassTable = db.GetTable<Student_Class>();
            return db.Student_Classes.SingleOrDefault(x => x.StudentID == StudentID);
        }
        public bool StudentClassInsert(Student_Class entity)
        {
            try
            {
                StudentClassTable = db.GetTable<Student_Class>();
                StudentClassTable.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool StudentClassUpdate(Student_Class entity)
        {
            try
            {
                StudentClassTable = db.GetTable<Student_Class>();
                Student_Class model = StudentClassTable.SingleOrDefault(x => x.StudentID.Equals(entity.StudentID));
                model.StudentID = entity.StudentID;
                model.ClassID = entity.ClassID;
                model.Note = entity.Note;
                model.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool StudentClassDelete(int StudentID)
        {
            try
            {
                StudentClassTable = db.GetTable<Student_Class>();
                Student_Class model = StudentClassTable.SingleOrDefault(x => x.StudentID.Equals(StudentID));
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
