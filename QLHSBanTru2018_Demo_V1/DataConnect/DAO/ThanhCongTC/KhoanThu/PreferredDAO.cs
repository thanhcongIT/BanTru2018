using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC
{
    public class PreferredDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public bool Insert(Preferred entity)
        {
            Preferred a = new Preferred();
            a.Name = entity.Name;
            a.Status = entity.Status;
            a.Percent = entity.Percent;
            dt.Preferreds.InsertOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public bool Edit(Preferred entity)
        {
            Preferred a = dt.Preferreds.Where(t => t.PreferredID == entity.PreferredID).FirstOrDefault();
            a.Name = entity.Name;
            a.Percent = entity.Percent;
            a.Status = entity.Status;
            dt.SubmitChanges();
            return true;
        }
        public bool Remove(Preferred entity)
        {
            Preferred a = dt.Preferreds.Where(t => t.PreferredID == entity.PreferredID).FirstOrDefault();
            dt.Preferreds.DeleteOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public List<Preferred> ListPreferred()
        {
            var a = dt.Preferreds;
            return a.ToList();
        }
        public Preferred listPreferredByID(int PrefrerredID)
        {
            Preferred a = dt.Preferreds.FirstOrDefault(t => t.PreferredID == PrefrerredID);
            return a;
        }
        public static List<Preferred> ListDemoPreferred = new List<Preferred>();
        public static string PreferredIDList = "";
        public float lookPreferredPercent(int perferredID)
        {
            if (perferredID==0)
            {
                return 100;
            }
            else
            {
                Preferred a = dt.Preferreds.FirstOrDefault(t => t.PreferredID == perferredID);
                return (float)a.Percent;
            }
            
        }
    }
}
