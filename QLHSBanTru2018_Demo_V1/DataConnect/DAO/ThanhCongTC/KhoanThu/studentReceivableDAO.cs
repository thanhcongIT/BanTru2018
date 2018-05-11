using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect;
using DataConnect.DAO.ThanhCongTC.TCViewModle;

namespace DataConnect.DAO.ThanhCongTC
{
    public class studentReceivableDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public static int CourseID = 0;
        public static int SemesterID = 0;
        public static int GradeID = 0;
        public static int ClassID = 0;
        public static int TherowFocust = 0;
        public static string PreferredID = "";
        public List<Course> ListCourse()
        {
            var a = dt.Courses.OrderByDescending(t=>t.CourseID);
            return a.ToList();
        }
        public List<Semester> ListSemester()
        {
            var a = dt.Semesters.Where(t => t.CourseID == CourseID).OrderByDescending(j => j.SemesterID);
            return a.ToList();
        }
        public List<Semester>ListSemesterByID(int CourseID)
        {
            var a = dt.Semesters.Where(t => t.CourseID == CourseID).OrderByDescending(t => t.SemesterID);
            return a.ToList();
        }
        public List<Grade> ListGradeByID(int Mahocky)
        {
            var a = dt.Grades.Where(t => t.SemesterID == Mahocky);
            return a.ToList();
        }
        public List<Class> ListClassByID(int Makhoi)
        {
            var a = dt.Classes.Where(t => t.GradeID == Makhoi);
            return a.ToList();
        }
        
       
        
        
        //public Link<TCStudenViewModle> listStudenReceivable()
        //{
        //    classs = dt.GetTable<Class>();

        
        //}
        public int lookforPreferredID(int StudenID)
        {
            Student a = dt.Students.FirstOrDefault(t => t.StudentID == StudenID);
            if (a.PreferredID==null)
            {
                return 0;
            }
            else
            {
                return (int)a.PreferredID;
            }
            
        }
        
    }
}
