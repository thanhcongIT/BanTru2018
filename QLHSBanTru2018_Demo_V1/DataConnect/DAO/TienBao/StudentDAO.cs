using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataConnect.ViewModel;
using DataConnect.DAO.HungTD;

namespace DataConnect.DAO.TienBao
{
   public class StudentDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();

        Table<Student> StudentTable;
        Table<StudentParent> StudentParentTable;
        Table<Student_Class> StudentClassTable;
        Table<Class> ClassTable;
        Table<EthnicGroup> EthnicGroupTable;
        Table<Location> LocationTable;
        Table<Religion> ReligionTable;
        Table<Preferred> PreferredTable;


        public List<Student> ListAll()
        {
            StudentTable = db.GetTable<Student>();
            var query = from e in StudentTable
                        select e;
            return query.ToList();
        }
        public void StudentCount()
        {
            StudentTable = db.GetTable<Student>();
            var query = (from e in StudentTable
                         select e).Count();
        }
        public List<StudentViewModel> ListStudentByClass(int ClassID)
        {
            StudentTable = db.GetTable<Student>();
            StudentParentTable = db.GetTable<StudentParent>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            EthnicGroupTable = db.GetTable<EthnicGroup>();
            LocationTable = db.GetTable<Location>();
            ReligionTable = db.GetTable<Religion>();
            PreferredTable = db.GetTable<Preferred>();
            var query = from S in StudentTable
                        join SP in StudentParentTable
                        on S.StudentID equals SP.StudentID
                        into OD
                        from SP in OD.DefaultIfEmpty()
                        join SC in StudentClassTable
                        on S.StudentID equals SC.StudentID
                        join C in ClassTable
                        on SC.ClassID equals C.ClassID
                        join L in LocationTable
                        on S.LocationID equals L.LocationID
                        where SC.ClassID == ClassID && S.Status == true
                        select new StudentViewModel
                        {
                            StudentID = S.StudentID,
                            StudentCode = S.StudentCode,
                            FirstName = S.FirstName,
                            LastName = S.LastName,
                            HomeName = S.HomeName,
                            Birthday = S.Birthday,
                            DateStudy = S.DateStudy,
                            Gender = S.Gender,
                            AdressDetail = S.AdressDetail,
                            Hobby = S.Hobby,
                            Talen = S.Talent,
                            FatherName = SP.FatherName,
                            FatherJob = SP.FatherJob,
                            MotherName = SP.MotherName,
                            MotherJob = SP.MotherJob,
                            Password = SP.Password,
                            Image = S.Image == null ? null : S.Image.ToArray(),
                            Note = S.Note,
                            StudentClassNote = SC.Note,
                            Status = S.Status,
                            LocationID = S.LocationID,
                            LocationDetail = new LocationDAO().GetFullNameLocaion(S.LocationID),
                            ClassID = SC.ClassID,
                            ClassName = C.Name
                        };
            List<StudentViewModel> list = query.ToList();
            return list;
        }
        public List<StudentViewModel> ListStudentLockByClass(int ClassID)
        {
            StudentTable = db.GetTable<Student>();
            StudentParentTable = db.GetTable<StudentParent>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            EthnicGroupTable = db.GetTable<EthnicGroup>();
            LocationTable = db.GetTable<Location>();
            ReligionTable = db.GetTable<Religion>();
            PreferredTable = db.GetTable<Preferred>();
            var query = from S in StudentTable
                        join SP in StudentParentTable
                        on S.StudentID equals SP.StudentID
                        into OD
                        from SP in OD.DefaultIfEmpty()
                        join SC in StudentClassTable
                        on S.StudentID equals SC.StudentID
                        join C in ClassTable
                        on SC.ClassID equals C.ClassID
                        join L in LocationTable
                        on S.LocationID equals L.LocationID
                        where SC.ClassID == ClassID && S.Status == false
                        select new StudentViewModel
                        {
                            StudentID = S.StudentID,
                            StudentCode = S.StudentCode,
                            FirstName = S.FirstName,
                            LastName = S.LastName,
                            HomeName = S.HomeName,
                            Birthday = S.Birthday,
                            DateStudy = S.DateStudy,
                            Gender = S.Gender,
                            AdressDetail = S.AdressDetail,
                            Hobby = S.Hobby,
                            Talen = S.Talent,
                            FatherName = SP.FatherName,
                            FatherJob = SP.FatherJob,
                            MotherName = SP.MotherName,
                            MotherJob = SP.MotherJob,
                            Password = SP.Password,
                            Image = S.Image == null ? null : S.Image.ToArray(),
                            Note = S.Note,
                            StudentClassNote = SC.Note,
                            Status = S.Status,
                            LocationID = S.LocationID,
                            LocationDetail = new LocationDAO().GetFullNameLocaion(S.LocationID),
                            ClassID = SC.ClassID,
                            ClassName = C.Name
                        };
            List<StudentViewModel> list = query.ToList();
            return list;
        }
        public int StudentInsert(Student entity)
        {
            try
            {
                StudentTable = db.GetTable<Student>();
                StudentTable.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.StudentID;
            }
            catch
            {
                return 0;
            }
        }

        public bool StudentUpdate(Student entity)
        {
            try
            {
                StudentTable = db.GetTable<Student>();
                Student model = StudentTable.SingleOrDefault(x => x.StudentID.Equals(entity.StudentID));
                model.StudentCode = entity.StudentCode;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
                model.HomeName = entity.HomeName;
                model.Birthday = entity.Birthday;
                model.DateStudy = entity.DateStudy;
                model.Gender = entity.Gender;
                model.Image = entity.Image;
                model.Hobby = entity.Hobby;
                model.Talent = entity.Talent;
                model.AdressDetail = entity.AdressDetail;
                model.EthnicGroupID = entity.EthnicGroupID;
                model.ReligionID = entity.ReligionID;
                model.PreferredID = entity.PreferredID;
                model.LocationID = entity.LocationID;
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
        public bool StudentDelete(int StudentID)
        {
            try
            {
                StudentTable = db.GetTable<Student>();
                Student model = StudentTable.SingleOrDefault(x => x.StudentID.Equals(StudentID));
                model.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Student GetByID(int StudentID)
        {
            StudentTable = db.GetTable<Student>();
            return db.Students.SingleOrDefault(x => x.StudentID == StudentID);
        }
    }
}
