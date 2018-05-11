using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC
{
    public class StudenGrade
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public Semester lookforSemester(int maky)
        {
            Semester a = dt.Semesters.FirstOrDefault(t => t.SemesterID == maky);
            return a;
        }
        public Grade lookforGrade(int makhoi)
        {
            Grade a = dt.Grades.FirstOrDefault(t => t.GradeID == makhoi);
            return a;
        }
        public List<Student_Class>lookStudenbyGradeID(int GradeId)
        {
            Class a = dt.Classes.FirstOrDefault(t => t.GradeID == GradeId);
            var b = dt.Student_Classes.Where(t => t.ClassID == a.ClassID);
            return b.ToList();
        }
    }
}
