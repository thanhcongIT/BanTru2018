using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class FunctionDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Function> function;
        public FunctionDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<FunctionViewModel> ListAll()
        {
            function = db.GetTable<Function>();
            var model = from f in function
                        where f.Status == true
                        select new FunctionViewModel
                        {
                            FunctionID = f.FunctionID,
                            FunctionGroupName = f.FunctionGroup.Name,
                            FunctionName = f.Name,
                            Note = f.Note,
                            Status = f.Status
                        };
            return model.ToList();
        }
        public int Insert(Function entity)
        {
            try
            {
                function = db.GetTable<Function>();
                function.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.FunctionID;
            }
            catch
            {
                return 0;
            }
        }
    }
}
