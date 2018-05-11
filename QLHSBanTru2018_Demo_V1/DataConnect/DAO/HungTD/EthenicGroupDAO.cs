using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class EthenicGroupDAO
    {
        QLHSSmartKidsDataContext db;
        Table<EthnicGroup> ethnicGroup;
        public EthenicGroupDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<EthnicGroup> ListAll()
        {
            ethnicGroup = db.GetTable<EthnicGroup>();
            var query = from e in ethnicGroup
                        where e.Status.Equals(true)
                        select e;
            return query.ToList();
        }
        public EthnicGroup GetByID(int ethnicGroupID)
        {
            ethnicGroup = db.GetTable<EthnicGroup>();
            return ethnicGroup.SingleOrDefault(x => x.EthnicGroupID == ethnicGroupID);
        }        
    }
}
