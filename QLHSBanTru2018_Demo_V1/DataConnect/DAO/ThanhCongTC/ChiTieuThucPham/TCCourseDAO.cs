using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class TCCourseDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public DateTime StartDateCourse(int CourseID)
        {
            Course a = dt.Courses.FirstOrDefault(t => t.CourseID == CourseID);
            return a.StartDate;
        }
        public DateTime EndDateCourse(int CourseID)
        {
            Course a = dt.Courses.FirstOrDefault(t => t.CourseID == CourseID);
            return a.EndDate;
        }
    }
}
