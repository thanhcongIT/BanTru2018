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
   public class PhysicalAssessmentDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();

        Table<PhysicalAssessment> PhysicalTable;


        public List<PhysicalAssessmentViewModel> ListPhysicalAssessment()
        {

            PhysicalTable = db.GetTable<PhysicalAssessment>();

            var query = from ph in PhysicalTable
                        where ph.Status == true
                        select new PhysicalAssessmentViewModel
                        {
                            PhysicalAssessmentID = ph.PhysicalAssessmentID,
                            DatePhysicalAssessment = ph.Date,
                            NamePhysicalAssessment = ph.Name,
                            NotePhysicalAssessment = ph.Note,
                            StatusPhysicalAssessment = ph.Status,
                            StringStatus = ph.Status == true ? "Đang sử dụng" : "Không sử dụng"
                        };
            List<PhysicalAssessmentViewModel> list = query.ToList();
            return list;
        }
        public bool PhysicalInsert(PhysicalAssessment entity)
        {
            PhysicalAssessment a = new PhysicalAssessment();
            a.Date = entity.Date;
            a.Status = entity.Status;
            a.Name = entity.Name;
            a.Note = entity.Note;
            db.PhysicalAssessments.InsertOnSubmit(a);
            db.SubmitChanges();
            return true;
            
        }
        public bool PhysicalUpdate(PhysicalAssessment entity)
        {
            try
            {
                PhysicalTable = db.GetTable<PhysicalAssessment>();
                PhysicalAssessment model = PhysicalTable.SingleOrDefault(x => x.PhysicalAssessmentID.Equals(entity.PhysicalAssessmentID));
                model.Date = entity.Date;
                model.Name = entity.Name;
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
        public bool PhysicalDelete(int PhysicalAssessmentID)
        {
            try
            {
                PhysicalTable = db.GetTable<PhysicalAssessment>();
                PhysicalAssessment model = PhysicalTable.SingleOrDefault(x => x.PhysicalAssessmentID.Equals(PhysicalAssessmentID));
                db.PhysicalAssessments.DeleteOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PhysicalAssessment GetByID(int PhysicalAssessmentID)
        {
            PhysicalTable = db.GetTable<PhysicalAssessment>();
            return db.PhysicalAssessments.SingleOrDefault(x => x.PhysicalAssessmentID == PhysicalAssessmentID);
        }

    }
}
