using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DegreeDAO
    {
        QLHSSmartKidsDataContext db;
        public DegreeDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<Degree> ListAllDegree()
        {
            Table<Degree> degreeTable = db.GetTable<Degree>();
            var degree = from d in degreeTable
                         where (d.Status.Equals(true))
                         orderby d.Name
                         select d;
            return degree.ToList();
        }
        public int Insert(Degree entity)
        {
            return 1;
        }
    }
}
