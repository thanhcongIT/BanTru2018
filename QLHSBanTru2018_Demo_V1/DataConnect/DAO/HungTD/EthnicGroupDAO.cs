using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class EthnicGroupDAO
    {
        QLHSSmartKidsDataContext db;
        public EthnicGroupDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<EthnicGroup> ListAllEthnicGroup()
        {
            Table<EthnicGroup> ethnicTable = db.GetTable<EthnicGroup>();
            var ethnicGroup = from d in ethnicTable
                         where (d.Status.Equals(true))
                         orderby d.Name
                         select d;
            return ethnicGroup.ToList();
        }
    }
}
