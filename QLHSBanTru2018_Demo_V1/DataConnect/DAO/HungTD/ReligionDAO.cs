using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class ReligionDAO
    {
        QLHSSmartKidsDataContext db;
        public ReligionDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<Religion> ListAllReligion()
        {
            Table<Religion> religionTable = db.GetTable<Religion>();
            var religion = from r in religionTable
                           where r.Status.Equals(true)
                           orderby r.Name
                           select r;
            return religion.ToList();
        }
    }
}
