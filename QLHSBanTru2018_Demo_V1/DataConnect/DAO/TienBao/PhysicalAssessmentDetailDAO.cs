﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataConnect.ViewModel;
using DataConnect.DAO.HungTD;

namespace DataConnect.DAO.TienBao
{
   public class PhysicalAssessmentDetailDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();

        Table<Student> StudentTable;
        Table<Student_Class> StudentClassTable;
        Table<Class> ClassTable;
        Table<PhysicalAssessment> PhysicalTable;
        Table<PhysicalAssessmentDetail> PhysicalDetailTable;

        public List<PhysicalAssessmentViewModel> ListPhysicalDetail(int ClassID, int PhysicalAssessmentID)
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            PhysicalTable = db.GetTable<PhysicalAssessment>();
            PhysicalDetailTable = db.GetTable<PhysicalAssessmentDetail>();
            var query = from phd in PhysicalDetailTable
                        join s in StudentTable
                        on phd.StudentID equals s.StudentID
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        join ph in PhysicalTable
                        on phd.PhysicalAssessmentID equals ph.PhysicalAssessmentID
                        where sc.ClassID == ClassID && phd.PhysicalAssessmentID == PhysicalAssessmentID
                        select new PhysicalAssessmentViewModel
                        {
                            PhysicalAssessmentDetailID = phd.PhysicalAssessmentDeailID,
                            PhysicalAssessmentID = phd.PhysicalAssessmentID,

                            StudentID = phd.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            Birthday = s.Birthday,
                            Gender = s.Gender,
                            StringGender = s.Gender == true ? "Nam" : "Nữ",
                            ClassID = sc.ClassID,
                            ClassName = c.Name,

                            Height = phd.Height,
                            Weight = phd.Weight,
                            HeightRating = phd.HeightRating,
                            WeightRating = phd.WeightRating,

                            NoteDetail = phd.Note,
                            StatusPhysicalAssessmentDetail = phd.Status
                        };
            List<PhysicalAssessmentViewModel> list = query.ToList();
            return list;
        }
       
        public List<PhysicalAssessmentViewModel> ListStudent(int ClassID)
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            var query = from s in StudentTable
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        where sc.ClassID == ClassID && s.Status == true

                        select new PhysicalAssessmentViewModel
                        {
                            StudentID = s.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            Birthday = s.Birthday,
                            Gender = s.Gender,
                            StringGender = s.Gender == true ? "Nam" : "Nữ",
                            ClassID = sc.ClassID,
                            ClassName = c.Name,
                        };
            List<PhysicalAssessmentViewModel> list = query.ToList();
            return list;
        }       

        public bool PhysicalDetailInsert(PhysicalAssessmentDetail entity)
        {
            PhysicalAssessmentDetail a = new PhysicalAssessmentDetail();
            a.PhysicalAssessmentID = entity.PhysicalAssessmentID;
            a.StudentID = entity.StudentID;
            a.Status = false;
            a.Height = entity.Height;
            a.Weight = entity.Weight;
            a.HeightRating = entity.HeightRating;
            a.WeightRating = entity.WeightRating;
            a.Note = entity.Note;
            db.PhysicalAssessmentDetails.InsertOnSubmit(a);
            db.SubmitChanges();
            return true;
        }
        public bool PhysicalDetailUpdate(PhysicalAssessmentDetail entity)
        {
            try
            {
                PhysicalDetailTable = db.GetTable<PhysicalAssessmentDetail>();
                PhysicalAssessmentDetail model = PhysicalDetailTable.SingleOrDefault(x => x.PhysicalAssessmentID==entity.PhysicalAssessmentID&&x.PhysicalAssessmentDeailID==entity.PhysicalAssessmentDeailID);
                //model.PhysicalAssessmentID = entity.PhysicalAssessmentID;
                //model.StudentID = entity.StudentID;
                model.Height = entity.Height;
                model.Weight = entity.Weight;
                model.HeightRating = entity.HeightRating;
                model.WeightRating = entity.WeightRating;
                //model.OtherRating = entity.OtherRating;
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
        public bool PhysicalDetailDelete(int PhysicalAssessmentDetailID)
        {
            try
            {
                PhysicalDetailTable = db.GetTable<PhysicalAssessmentDetail>();
                PhysicalAssessmentDetail model = PhysicalDetailTable.SingleOrDefault(x => x.PhysicalAssessmentDeailID.Equals(PhysicalAssessmentDetailID));
                db.PhysicalAssessmentDetails.DeleteOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PhysicalAssessmentDetail GetByID(int PhysicalAssessmentDetailID)
        {
            PhysicalDetailTable = db.GetTable<PhysicalAssessmentDetail>();
            return db.PhysicalAssessmentDetails.SingleOrDefault(x => x.PhysicalAssessmentDeailID == PhysicalAssessmentDetailID);
        }

    }
}
