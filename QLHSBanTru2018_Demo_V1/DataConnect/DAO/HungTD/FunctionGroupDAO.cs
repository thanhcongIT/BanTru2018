using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class FunctionGroupDAO
    {
        QLHSSmartKidsDataContext db;
        Table<FunctionGroup> functionGroup;
        public FunctionGroupDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<FunctionGroup> ListAll()
        {
            functionGroup = db.GetTable<FunctionGroup>();
            var model = functionGroup.Where(x => x.Status.Equals(true));
            return model.ToList();
        }
        public int Insert(FunctionGroup entity)
        {
            try
            {
                functionGroup = db.GetTable<FunctionGroup>();
                functionGroup.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.FunctionGroupID;
            }
            catch
            {
                return 0;
            }
        }
    }
}
