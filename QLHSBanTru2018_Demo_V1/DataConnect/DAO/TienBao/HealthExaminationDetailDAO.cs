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
   public class HealthExaminationDetailDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();

        Table<Student> StudentTable;
        Table<Student_Class> StudentClassTable;
        Table<Class> ClassTable;
        Table<HealthExamination> HealthExaminationTable;
        Table<HealthExaminationDetail> HealthExaminationDetailTable;

        public List<HealthExaminationDetailViewModel> ListHealthDetail(int ClassID, int HealthExaminationID)
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            HealthExaminationTable = db.GetTable<HealthExamination>();
            HealthExaminationDetailTable = db.GetTable<HealthExaminationDetail>();
            var query = from hd in HealthExaminationDetailTable
                        join s in StudentTable
                        on hd.StudentID equals s.StudentID
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        join he in HealthExaminationTable
                        on hd.HealthExaminationID equals he.HealthExaminationID    
                        where sc.ClassID == ClassID && hd.HealthExaminationID == HealthExaminationID
                        select new HealthExaminationDetailViewModel
                        {
                            HealthExaminationDetailID = hd.HealthExaminationDetailID,
                            HealthExaminationID = hd.HealthExaminationID,
                            StudentID = hd.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            HealthInsurance = hd.HealthInsurance,
                            Height = hd.Height,
                            Weight = (int)hd.Weight,
                            Eyes = hd.Eyes,
                            ENT = hd.ENT,
                            Oral = hd.Oral,
                            InternalMedicine = hd.InternalMedicine,
                            Surgery = hd.Surgery,
                            Dermatology = hd.Dermatology,
                            BoneMuscle = hd.BoneMuscle,
                            Nerve = hd.Nerve,
                            Endocrine = hd.Endocrine,
                            Other = hd.Other,
                            Note = hd.Note,
                            Rating = hd.Rating,
                            ClassID = sc.ClassID,
                            ClassName = c.Name,
                            Status = hd.Status
                        };
            List<HealthExaminationDetailViewModel> list = query.ToList();
            return list;
        }
        public List<HealthExaminationDetailViewModel> ListGridView(int ClassID, int HealthExaminationID)
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            HealthExaminationTable = db.GetTable<HealthExamination>();
            HealthExaminationDetailTable = db.GetTable<HealthExaminationDetail>();
            var query = from hd in HealthExaminationDetailTable
                        join s in StudentTable
                        on hd.StudentID equals s.StudentID
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        join he in HealthExaminationTable
                        on hd.HealthExaminationID equals he.HealthExaminationID
                        where sc.ClassID == ClassID && hd.HealthExaminationID == HealthExaminationID
                        select new HealthExaminationDetailViewModel
                        {
                            HealthExaminationDetailID = hd.HealthExaminationDetailID,
                            HealthExaminationID = hd.HealthExaminationID,
                            StudentID = s.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            HealthInsurance = hd.HealthInsurance,
                            Height = (int)hd.Height,
                            Weight = (int)hd.Weight,
                            Eyes = hd.Eyes,
                            ENT = hd.ENT,
                            Oral = hd.Oral,
                            InternalMedicine = hd.InternalMedicine,
                            Surgery = hd.Surgery,
                            Dermatology = hd.Dermatology,
                            BoneMuscle = hd.BoneMuscle,
                            Nerve = hd.Nerve,
                            Endocrine = hd.Endocrine,
                            Other = hd.Other,
                            Note = hd.Note,
                            Rating = hd.Rating,
                            ClassID = sc.ClassID,
                            ClassName = c.Name,
                            Status = hd.Status
                        };
            List<HealthExaminationDetailViewModel> list = query.ToList();
            return list;
        }
        public List<HealthExaminationDetailViewModel> ListStudent(int ClassID)
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();           
            var query = from s in StudentTable
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        where  sc.ClassID == ClassID && s.Status == true

                        select new HealthExaminationDetailViewModel
                        {
                            StudentID = s.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            ClassID = sc.ClassID,
                            ClassName = c.Name,
                        };
            List<HealthExaminationDetailViewModel> list = query.ToList();
            return list;
        }
        public List<HealthExaminationDetailViewModel> ListHealthExamination()
        {
           
            HealthExaminationTable = db.GetTable<HealthExamination>();
            var query = from he in HealthExaminationTable                        
                        where he.Status == true
                        select new HealthExaminationDetailViewModel
                        {
                            HealthExaminationID = he.HealthExaminationID,
                            HealthExaminationName = he.Name,                            
                        };
            List<HealthExaminationDetailViewModel> list = query.ToList();
            return list;
        }

        public bool HealthDetailInsert(HealthExaminationDetail entity)
        {
            try
            {
                HealthExaminationDetailTable = db.GetTable<HealthExaminationDetail>();
                HealthExaminationDetailTable.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HealthDetailUpdate(HealthExaminationDetail entity)
        {
            try
            {
                HealthExaminationDetailTable = db.GetTable<HealthExaminationDetail>();
                HealthExaminationDetail model = HealthExaminationDetailTable.SingleOrDefault(x => x.HealthExaminationDetailID.Equals(entity.HealthExaminationDetailID));
                model.HealthExaminationID = entity.HealthExaminationID;
                model.StudentID = entity.StudentID;
                model.HealthInsurance = entity.HealthInsurance;
                model.Height = entity.Height;
                model.Weight = entity.Weight;
                model.Eyes = entity.Eyes;
                model.ENT = entity.ENT;
                model.Oral = entity.Oral;
                model.InternalMedicine = entity.InternalMedicine;
                model.Surgery = entity.Surgery;
                model.Dermatology = entity.Dermatology;
                model.BoneMuscle = entity.BoneMuscle;
                model.Nerve = entity.Nerve;
                model.Endocrine = entity.Endocrine;
                model.Other = entity.Other;
                model.Note = entity.Note;
                model.Rating = entity.Rating;
                model.Status = entity.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HealthDetailDelete(int HealthExaminationDetailID)
        {
            try
            {
                HealthExaminationDetailTable = db.GetTable<HealthExaminationDetail>();
                HealthExaminationDetail model = HealthExaminationDetailTable.SingleOrDefault(x => x.HealthExaminationDetailID.Equals(HealthExaminationDetailID));
                model.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public HealthExaminationDetail GetByID(int HealthExaminationDetailID)
        {
            HealthExaminationDetailTable = db.GetTable<HealthExaminationDetail>();
            return db.HealthExaminationDetails.SingleOrDefault(x => x.HealthExaminationDetailID == HealthExaminationDetailID);
        }


    }
}
