using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DataConnect.DAO.TienBao
{
   public class ClassDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Class> ClassTable;
        public ClassDAO()
        {
            db = new QLHSSmartKidsDataContext();
            ClassTable = db.GetTable<Class>();
        }

        public List<Class> ListAllClass()
        {
            return (from c in ClassTable
                    select c).ToList();
        }

        public List<Class> ListClassByGrade(int GradeID)
        {
            return (from c in ClassTable
                    where c.GradeID == GradeID
                    select c).ToList();
        }

        public Class GetByClassID(int ClassID)
        {
            return ClassTable.SingleOrDefault(x => x.ClassID == ClassID);
        }
        public bool InsertClass(Class entity)
        {
            try
            {
                ClassTable.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditClass(Class entity)
        {
            try
            {
                Class obj = ClassTable.Single(x => x.ClassID == entity.ClassID);
                obj.Name = entity.Name;
                //obj.Amount = entity.Amount;
                obj.Status = entity.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int ClassID)
        {
            try
            {
                Class obj = ClassTable.Single(x => x.ClassID == ClassID);
                obj.Status = false;
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
