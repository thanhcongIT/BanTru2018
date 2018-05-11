using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC
{
    public class ReceivableIDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public static int ReceivableID = 0;
        public int Insert(Receivable entity)
        {
            Receivable a = new Receivable();
            a.Name = entity.Name;
            a.SemesterID = entity.SemesterID;
            a.StartDate = entity.StartDate;
            a.EndDate = entity.EndDate;
            a.CreatedDate = entity.CreatedDate;
            a.Status = entity.Status;
            a.CourseID = entity.CourseID;
            a.Note = entity.Note;
            dt.Receivables.InsertOnSubmit(a);
            dt.SubmitChanges();
            return a.ReceivableID;
        }
        public bool Edit(Receivable entity)
        {
            Receivable a = dt.Receivables.Where(t => t.ReceivableID == entity.ReceivableID).FirstOrDefault();
            a.Name = entity.Name;
            a.SemesterID = entity.SemesterID;
            a.StartDate = entity.StartDate;
            a.EndDate = entity.EndDate;
            a.CreatedDate = entity.CreatedDate;
            a.Status = entity.Status;
            a.CourseID = entity.CourseID;
            dt.SubmitChanges();
            return true;
        }
        public bool Remove(Receivable entity)
        {
            Receivable a = dt.Receivables.Where(t => t.ReceivableID == entity.ReceivableID).FirstOrDefault();
            dt.Receivables.DeleteOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public List<Receivable> ListReceivable(int courseId,int semesterID)
        {
            var a = dt.Receivables.Where(t=>t.CourseID==courseId&&t.SemesterID==semesterID).OrderByDescending(t=>t.ReceivableID);
            return a.ToList();
        }
    }
}
