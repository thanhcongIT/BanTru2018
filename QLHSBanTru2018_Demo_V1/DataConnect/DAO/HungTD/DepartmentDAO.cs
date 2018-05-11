using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DepartmentDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Department> department;
        public DepartmentDAO()
        {
            db = new QLHSSmartKidsDataContext();
            department = db.GetTable<Department>();
        }
        public List<Department> ListAll()
        {

            var query = from d in department
                        select d;
            return query.ToList();
        }
        public Department GetByID(int departmentID)
        {
            return department.SingleOrDefault(x => x.DepartmentID == departmentID);
        }
        public bool Insert(Department entity)
        {
            try
            {
                department.InsertOnSubmit(entity);
                db.SubmitChanges();
                new HistoryDAO().Insert(QLHSBanTru2018_Demo_V1.Common.LoginDetail.LoginID, 5, "Thêm phòng ban " + entity.Name);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Department entity)
        {
            try
            {
                Department obj = department.Single(x => x.DepartmentID == entity.DepartmentID);
                obj.Name = entity.Name;
                obj.Status = entity.Status;
                db.SubmitChanges();
                new HistoryDAO().Insert(QLHSBanTru2018_Demo_V1.Common.LoginDetail.LoginID, 6, "Sửa phòng ban thành " + entity.Name);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int departmentID)
        {
            try
            {
                Department obj = department.Single(x => x.DepartmentID == departmentID);
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
