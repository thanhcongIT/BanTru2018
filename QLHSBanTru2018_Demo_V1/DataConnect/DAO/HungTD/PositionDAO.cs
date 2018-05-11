using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class PositionDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Position> position;
        public PositionDAO()
        {
            db = new QLHSSmartKidsDataContext();
            position = db.GetTable<Position>();
        }
        public List<Position> ListAll()
        {
            var query = from p in position
                        select p;
            return query.ToList();
        }
        public Position GetByID(int positionID)
        {
            return position.SingleOrDefault(x => x.PositionID == positionID);
        }
        public bool Insert(Position entity)
        {
            try
            {
                position.InsertOnSubmit(entity);
                db.SubmitChanges();
                //History
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Position entity)
        {
            try
            {
                Position obj = position.Single(x => x.PositionID == entity.PositionID);
                obj.Name = entity.Name;
                obj.Status = entity.Status;
                db.SubmitChanges();
                //History
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int positionID)
        {
            try
            {
                Position obj = position.Single(x => x.PositionID == positionID);
                obj.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
