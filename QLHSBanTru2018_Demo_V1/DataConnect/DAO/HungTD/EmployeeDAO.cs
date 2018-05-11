using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class EmployeeDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Employee> employee;
        Table<Contract> contract;
        Table<Department> department;
        Table<Position> position;
        Table<Degree> degree;
        Table<Location> location;
        Table<Division> division;
        public EmployeeDAO()
        {
            db = new QLHSSmartKidsDataContext();
        }
        public List<Employee> ListAll()
        {
            employee = db.GetTable<Employee>();
            var query = from e in employee
                        select e;
            return query.ToList();
        }
        public List<Department_EmployeeViewModel> ListAllByDepartment(int departmentID)
        {
            return null;
        }
        public List<EmployeeFullViewModel> ListAllEmployee(int? departmentID, int? degreeID, int? positionID)
        {
            try
            {
                employee = db.GetTable<Employee>();
                contract = db.GetTable<Contract>();
                department = db.GetTable<Department>();
                position = db.GetTable<Position>();
                degree = db.GetTable<Degree>();
                location = db.GetTable<Location>();
                var query = from e in employee
                            join de in degree
                            on e.DegreeID equals de.DegreeID
                            join l in location
                            on e.LocationID equals l.LocationID
                            where e.Status == true
                            select new EmployeeFullViewModel
                            {
                                EmployeeID = e.EmployeeID,
                                Username = e.Username,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                FullName = e.FirstName + " " + e.LastName,
                                Birthday = e.Birthday,
                                //Gender = e.Gender,
                                Image = e.Image == null ? null : e.Image.ToArray(),
                                Phone = e.Phone,
                                Email = e.Email,
                                LocationID = e.LocationID,
                                LocationDetail = new LocationDAO().GetFullNameLocaion(e.LocationID),
                                //DegreeID = e.DegreeID,
                                DegreeName = de.Name,
                                Note = e.Note,
                                IdentityNumber = e.IdentityNumber,
                                DateOfIssue = e.DateOfIssue,
                                PlaceOfIssue = e.PlaceOfIssue,
                                Status = e.Status
                            };
                if (degreeID != null)
                {
                    query = query.Where(x => x.DegreeID == degreeID);
                }
                List<EmployeeFullViewModel> list = query.ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }
        public List<DataConnect.Employee> LoadLeader()
        {
            employee = db.GetTable<Employee>();
            division = db.GetTable<Division>();
            position = db.GetTable<Position>();
            var divisionLeader = from d in division
                                 where d.PositionID == 1
                                 select d;
            var employeeLeader = from e in employee
                                 where (divisionLeader.Any(x => x.EmployeeID == e.EmployeeID))
                                 select e;
            return employeeLeader.ToList();
        }
        public Employee GetByID (int employeeID)
        {
            employee = db.GetTable<Employee>();
            return db.Employees.SingleOrDefault(x => x.EmployeeID == employeeID);
        }
        public bool Insert(Employee entity)
        {
            try
            {
                employee = db.GetTable<Employee>();
                employee.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Employee entity)
        {
            try
            {
                employee = db.GetTable<Employee>();
                Employee model = employee.SingleOrDefault(x => x.EmployeeID.Equals(entity.EmployeeID));
                model.Username = entity.Username;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
                model.Birthday = entity.Birthday;
                model.Gender = entity.Gender;
                model.Image = entity.Image;
                model.Email = entity.Email;
                model.Phone = entity.Phone;
                model.IdentityNumber = entity.IdentityNumber;
                model.PlaceOfIssue = entity.PlaceOfIssue;
                model.DateOfIssue = entity.DateOfIssue;
                model.EthnicGroupID = entity.EthnicGroupID;
                model.ReligionID = entity.ReligionID;
                model.DegreeID = entity.DegreeID;
                model.LocationID = entity.LocationID;
                model.AddressDetail = entity.AddressDetail;
                model.Note = entity.Note;
                model.Status = entity.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Employee entity)
        {
            try
            {
                employee = db.GetTable<Employee>();
                Employee obj = employee.Single(x => x.EmployeeID == entity.EmployeeID);
                obj.Username = entity.Username;
                obj.FirstName = entity.FirstName;
                obj.LastName = entity.LastName;
                obj.Birthday = entity.Birthday;
                obj.Gender = entity.Gender;
                obj.EthnicGroupID = entity.EthnicGroupID;
                obj.ReligionID = entity.ReligionID;
                obj.Image = entity.Image;
                obj.LocationID = entity.LocationID;
                obj.AddressDetail = entity.AddressDetail;
                obj.DegreeID = entity.DegreeID;
                obj.Email = entity.Email;
                obj.Phone = entity.Phone;
                obj.IdentityNumber = entity.IdentityNumber;
                obj.DateOfIssue = entity.DateOfIssue;
                obj.PlaceOfIssue = entity.PlaceOfIssue;
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
        public bool Delete(int employeeID)
        {
            try
            {
                employee = db.GetTable<Employee>();
                Employee model = employee.SingleOrDefault(x => x.EmployeeID.Equals(employeeID));
                model.Status = false;
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
