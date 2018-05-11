using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class LocationDAO
    {
        QLHSSmartKidsDataContext db;
        public LocationDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<Location> ListAllProvince()
        {
            Table<Location> provinceTable = db.GetTable<Location>();
            var province = from p in provinceTable
                           where (p.Status.Equals(true) && p.LocationParent.Equals(0))
                           orderby p.LocationName
                           select p;
            return province.ToList();
        }

        public List<Location> ListLocationFromParent(int locationParentID)
        {
            Table<Location> child = db.GetTable<Location>();
            var query = from c in child
                        where (c.Status.Equals(true) && c.LocationParent.Equals(locationParentID))
                        orderby c.LocationName
                        select c;
            return query.ToList();
        }
        public int GetLocationParent(int locationID)
        {
            Table<Location> locationTable = db.GetTable<Location>();
            var location = from l in locationTable
                           where l.LocationID.Equals(locationID)
                           select l;
            return (int)location.FirstOrDefault().LocationParent;

        }
        public string GetFullNameLocaion(int locationID)
        {
            try
            {

                Location ward = db.Locations.SingleOrDefault(x => x.LocationID == locationID);
                Location district = db.Locations.SingleOrDefault(x => x.LocationID == ward.LocationParent);
                Location prince = db.Locations.SingleOrDefault(x => x.LocationID == district.LocationParent);
                return ward.LocationName + " - " + district.LocationName + " - " + prince.LocationName;
            }
            catch { return ""; }
        }
    }
}
