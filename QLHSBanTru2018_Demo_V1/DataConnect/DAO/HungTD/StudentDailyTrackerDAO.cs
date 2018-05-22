using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class StudentDailyTrackerDAO
    {
        public QLHSSmartKidsDataContext db;
        Table<Student> students;
        public StudentDailyTrackerDAO()
        {
            db = new QLHSSmartKidsDataContext();
            students = db.GetTable<Student>();
        }
        public List<Student> ListAllByClassID(int classID)
        {
            var model = from s in students
                        where s.Student_Classes.FirstOrDefault(x => x.Status.Equals(true)).ClassID.Equals(classID)
                        select s;
            return model.ToList();

        }
    }
}
