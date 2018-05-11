using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC
{
   public class GradeDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public List<Grade> listGrade(int semesterid)
        {
            var a = dt.Grades.Where(t => t.SemesterID == semesterid);
            return a.ToList();
        }
    }
}
