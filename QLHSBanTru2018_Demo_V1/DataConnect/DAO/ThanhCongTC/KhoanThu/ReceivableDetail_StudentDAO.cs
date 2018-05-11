using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC
{
    public class ReceivableDetail_StudentDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public bool Insert(ReceivableDetail_Student entity)
        {
            ReceivableDetail_Student a = new ReceivableDetail_Student();
            a.ReceivableDetailID = entity.ReceivableDetailID;
            a.StudentID = entity.StudentID;
            a.Status = entity.Status;
            dt.ReceivableDetail_Students.InsertOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public bool Edit(ReceivableDetail_Student entity)
        {
            ReceivableDetail_Student a = dt.ReceivableDetail_Students.Where(t => t.ReceivableDetailID == entity.ReceivableDetailID && t.StudentID == entity.StudentID).FirstOrDefault();
            a.ReceivableDetailID = entity.ReceivableDetailID;
            a.StudentID = entity.StudentID;
            a.Status = entity.Status;
            dt.SubmitChanges();
            return true;
        }
        public bool Remove(ReceivableDetail_Student entity)
        {
            ReceivableDetail_Student a = dt.ReceivableDetail_Students.Where(t => t.ReceivableDetailID == entity.ReceivableDetailID && t.StudentID == entity.StudentID).FirstOrDefault();
            dt.ReceivableDetail_Students.DeleteOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }

        public List<ReceivableDetail_Student> ListReceivableDetail_Student(int StudenID)
        {
            var a = dt.ReceivableDetail_Students.Where(t => t.StudentID == StudenID);
            return a.ToList();
        }
        public ReceivableDetail_Student loockReceivableDEtail_StudentByID(ReceivableDetail_Student a)
        {
            ReceivableDetail_Student b = dt.ReceivableDetail_Students.FirstOrDefault(t => t.StudentID == a.StudentID && t.ReceivableDetailID == a.ReceivableDetailID);
            return a;
        }
    }
}
