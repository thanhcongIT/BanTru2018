using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class AgeGroupDAO
    {
        QLHSSmartKidsDataContext db;
        Table<AgeGroup> AgeGroups;
        public AgeGroupDAO()
        {
            db = new QLHSSmartKidsDataContext();
            AgeGroups = db.GetTable<AgeGroup>();
        }
        public List<AgeGroup> ListAll()
        {
            return AgeGroups.Where(x => x.Status.Equals(true)).ToList();
        }
        public List<AgeGroup> ListAllDeleted()
        {
            return AgeGroups.Where(x => x.Status.Equals(false)).ToList();
        }
        public int Insert(AgeGroup entity)
        {
            try
            {
                AgeGroups.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.AgeGroupID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(AgeGroup entity)
        {
            try
            {
                AgeGroup obj = AgeGroups.Single(x => x.AgeGroupID == entity.AgeGroupID);
                obj.Name = entity.Name;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int AgeGroupID)
        {
            try
            {
                AgeGroup obj = AgeGroups.Single(x => x.AgeGroupID == AgeGroupID);
                obj.Status = false;
                db.SubmitChanges();
                new TopicDAO().DeleteByAgeGroup(AgeGroupID);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Restore(int AgeGroupID)
        {
            try
            {
                AgeGroup obj = AgeGroups.Single(x => x.AgeGroupID == AgeGroupID && x.Status == false);
                obj.Status = true;
                db.SubmitChanges();
                new TopicDAO().RestoreByAgeGroup(AgeGroupID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
