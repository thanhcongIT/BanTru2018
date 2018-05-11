using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC
{
    public class SemesterDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        
        public List<Semester> ListSemester()
        {
            Table<Semester> tableSemester;
            tableSemester = dt.GetTable<Semester>();
            var c = (from a in tableSemester select a).OrderByDescending(t => t.SemesterID).Take(1);
            return c.ToList();
        }
    }
}
