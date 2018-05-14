using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class TopicDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Topic> topics;
        public TopicDAO()
        {
            db = new QLHSSmartKidsDataContext();
            topics = db.GetTable<Topic>();
        }
        public List<Topic> ListAll()
        {
            return topics.Where(x => x.Status.Equals(true)).ToList();
        }
        public List<Topic> ListByAgeGroupID(int ageGroupID)
        {
            return topics.Where(x => x.Status.Equals(true) && x.AgeGroupID.Equals(ageGroupID)).ToList();
        }
        public List<Topic> ListDeleted()
        {
            return topics.Where(x => x.Status.Equals(false)).ToList();
        }
        public int GetAgeGroupID(int topicID)
        {
            return topics.Where(x => x.TopicID.Equals(topicID)).FirstOrDefault().AgeGroupID;
        }
        public Topic GetByTopicID(int topicID)
        {
            return topics.Where(x => x.TopicID.Equals(topicID)).FirstOrDefault();
        }
        public int Insert(Topic entity)
        {
            try
            {
                topics.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.TopicID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Topic entity)
        {
            try
            {
                Topic obj = topics.Single(x => x.TopicID == entity.TopicID);
                obj.Name = entity.Name;
                obj.AgeGroupID = entity.AgeGroupID;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int topicID)
        {
            try
            {
                Topic obj = topics.Single(x => x.TopicID == topicID);
                obj.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteByAgeGroup(int ageGroupID)
        {
            try
            {
                var listDeleteTopic = topics.Where(x => x.AgeGroupID.Equals(ageGroupID));
                foreach(var item in listDeleteTopic)
                {
                    Delete(item.TopicID);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Restore(int topicID)
        {
            try
            {
                Topic obj = topics.Single(x => x.TopicID == topicID && x.Status == false);
                obj.Status = true;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RestoreByAgeGroup(int ageGroupID)
        {
            try
            {
                var listRestoreTopic = topics.Where(x => x.AgeGroupID.Equals(ageGroupID));
                foreach(var item in listRestoreTopic)
                {
                    Restore(item.TopicID);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
