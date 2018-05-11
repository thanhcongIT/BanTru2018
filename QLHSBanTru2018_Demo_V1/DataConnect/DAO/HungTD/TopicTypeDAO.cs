using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class TopicTypeDAO
    {
        QLHSSmartKidsDataContext db;
        Table<TopicType> topicTypes;
        public TopicTypeDAO()
        {
            db = new QLHSSmartKidsDataContext();
            topicTypes = db.GetTable<TopicType>();
        }
        public List<TopicType> ListAll()
        {
            return topicTypes.Where(x => x.Status.Equals(true)).ToList();
        }
        public List<TopicType> ListAllDeleted()
        {
            return topicTypes.Where(x => x.Status.Equals(false)).ToList();
        }
        public int Insert(TopicType entity)
        {
            try
            {
                topicTypes.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.TopicTypeID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(TopicType entity)
        {
            try
            {
                TopicType obj = topicTypes.Single(x => x.TopicTypeID == entity.TopicTypeID);
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
        public bool Delete(int topicTypeID)
        {
            try
            {
                TopicType obj = topicTypes.Single(x => x.TopicTypeID == topicTypeID);
                obj.Status = false;
                db.SubmitChanges();
                new TopicDAO().DeleteByTopicType(topicTypeID);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Restore(int topicTypeID)
        {
            try
            {
                TopicType obj = topicTypes.Single(x => x.TopicTypeID == topicTypeID && x.Status == false);
                obj.Status = true;
                db.SubmitChanges();
                new TopicDAO().RestoreByTopicType(topicTypeID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
