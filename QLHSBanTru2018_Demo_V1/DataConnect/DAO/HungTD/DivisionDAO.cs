using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DivisionDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Division> divisions;
        public DivisionDAO()
        {
            db = new QLHSSmartKidsDataContext();
            divisions = db.GetTable<Division>();
        }
        public List<DivisionViewModel> ListAll()
        {
            var model = from d in divisions
                        where d.Status.Equals(true)
                        orderby d.DivisionID
                        select new DivisionViewModel
                        {
                            DivisionID = d.DivisionID,
                            EmployeeID = d.EmployeeID,
                            EmployeeFullName = d.Employee.FirstName + " " + d.Employee.LastName,
                            DepartmentID = d.DepartmentID,
                            DepartmentName = d.Department.Name,
                            PositionID = d.PositionID,
                            PositionName = d.Position.Name,
                            StartDate = d.StartDate,
                            EndDate = d.EndDate,
                            CreatedDate = d.CreatedDate,
                            CreatedBy = d.CreatedBy,
                            CreatedByFullName = d.Employee1.FirstName + " " + d.Employee1.LastName,
                            Note = d.Note,
                            Status = d.Status
                        };
            return model.ToList();
        }
        public Division GetByID(int divisionID)
        {
            return db.Divisions.SingleOrDefault(x => x.DivisionID == divisionID);
        }
        public int Insert(Division entity)
        {
            try
            {
                divisions.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.DivisionID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Division entity)
        {
            try
            {
                Division obj = divisions.SingleOrDefault(x => x.DivisionID.Equals(entity.DivisionID));
                obj.DepartmentID = entity.DepartmentID;
                obj.PositionID = entity.PositionID;
                obj.StartDate = entity.StartDate;
                obj.EndDate = entity.EndDate;
                obj.CreatedDate = entity.CreatedDate;
                obj.CreatedBy = entity.CreatedBy;
                obj.Note = entity.Note;
                obj.Status = entity.Status;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int divisionID)
        {
            try
            {
                Division obj = divisions.SingleOrDefault(x => x.DivisionID.Equals(divisionID));
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
