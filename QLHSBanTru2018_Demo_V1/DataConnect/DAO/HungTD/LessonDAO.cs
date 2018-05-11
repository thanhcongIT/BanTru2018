using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class LessonDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Lesson> lessons;
        public LessonDAO()
        {
            db = new QLHSSmartKidsDataContext();
            lessons = db.GetTable<Lesson>();
        }
        public List<Lesson> ListAll()
        {
            return lessons.Where(x => x.Status.Equals(true)).ToList();
        }
        public List<LessonViewModel> FilterByTopicType(int topicTypeID)
        {
            var model = from l in lessons
                        where l.Status.Equals(true) && l.Topic.TopicTypeID.Equals(topicTypeID)
                        orderby l.TopicID, l.LessonID
                        select new LessonViewModel
                        {
                            LessonID = l.LessonID,
                            Name = l.Name,
                            TopicID = l.TopicID,
                            TopicName = l.Topic.Name,
                            Description = l.Description,
                            TopicDescription = l.Topic.Description,
                            Status = l.Status
                        };
            return model.ToList();

        }
        public List<Lesson> FilterByTopic(int topicID)
        {
            return lessons.Where(x => x.Status.Equals(true) && x.TopicID.Equals(topicID)).ToList();
        }
        public List<Lesson> ListDeleted()
        {
            return lessons.Where(x => x.Status.Equals(false)).ToList();
        }
        public Lesson GetByID(int lessonID)
        {
            return lessons.Where(x => x.LessonID.Equals(lessonID)).FirstOrDefault();
        }
        public int GetTopicID(int lessonID)
        {
            return lessons.Where(x => x.LessonID.Equals(lessonID)).FirstOrDefault().TopicID;
        }
        public int Insert(Lesson entity)
        {
            try
            {
                lessons.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.LessonID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Lesson entity)
        {
            try
            {
                Lesson obj = lessons.Single(x => x.LessonID == entity.LessonID);
                obj.Name = entity.Name;
                obj.TopicID = entity.TopicID;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int lessonID)
        {
            try
            {
                Lesson obj = lessons.Single(x => x.LessonID == lessonID);
                obj.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteByTopic(int topicID)
        {
            try
            {
                var listDeleteLesson = lessons.Where(x => x.TopicID.Equals(topicID));
                foreach(var item in listDeleteLesson)
                {
                    Delete(item.LessonID);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Restore(int lessonID)
        {
            try
            {
                Lesson obj = lessons.Single(x => x.LessonID == lessonID && x.Status == false);
                obj.Status = true;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RestoreByTopic(int topicID)
        {
            try
            {
                var listRestoreLesson = lessons.Where(x => x.TopicID.Equals(topicID) && x.Status == false);
                foreach(var item in listRestoreLesson)
                {
                    Restore(item.LessonID);
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
