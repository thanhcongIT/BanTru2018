using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataConnect.ViewModel;
using DataConnect.DAO.HungTD;

namespace DataConnect.DAO.TienBao
{
   public class HealthProblemDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();

        Table<Student> StudentTable;
        Table<Student_Class> StudentClassTable;
        Table<Class> ClassTable;
        Table<HealthProblem> HealthProblemTable;
        Table<Employee> EmployeeTable;

        public List<HealthProblemViewModel> ListHealthProblem()
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            HealthProblemTable = db.GetTable<HealthProblem>();
            EmployeeTable = db.GetTable<Employee>();
            var query = from hp in HealthProblemTable
                        join s in StudentTable
                        on hp.StudentID equals s.StudentID
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        join e in EmployeeTable
                        on hp.EmployeeID equals e.EmployeeID
                        where hp.Status == true
                        select new HealthProblemViewModel
                        {
                            HealthProblemID = hp.HealthProblemID,
                            StudentID = hp.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            StartDate = hp.StartDate,
                            EndDate = hp.EndDate,
                            Signal = hp.Signal,
                            Diagnosed = hp.Diagnosed,
                            Measure = hp.Measure,
                            Serverity = hp.Serverity,
                            EmployeeName = e.FirstName + " " + e.LastName,
                            ClassID = sc.ClassID,
                            ClassName = c.Name,
                            Status = hp.Status
                        };
            List<HealthProblemViewModel> list = query.ToList();
            return list;
        }
        public List<HealthProblemViewModel> ListStudent()
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            HealthProblemTable = db.GetTable<HealthProblem>();
            var query = from s in StudentTable
                        join sc in StudentClassTable
                        on s.StudentID equals sc.StudentID
                        join c in ClassTable
                        on sc.ClassID equals c.ClassID
                        where s.Status == true
                        orderby c.Name
                        select new HealthProblemViewModel
                        {
                            StudentID = s.StudentID,
                            StudentCode = s.StudentCode,
                            FullName = s.FirstName + " " + s.LastName,
                            ClassID = sc.ClassID,
                            ClassName = c.Name,
                        };
            List<HealthProblemViewModel> list = query.ToList();
            return list;
        }
        public List<HealthProblemViewModel> ListEmPloyee()
        {
            StudentTable = db.GetTable<Student>();
            StudentClassTable = db.GetTable<Student_Class>();
            ClassTable = db.GetTable<Class>();
            HealthProblemTable = db.GetTable<HealthProblem>();
            EmployeeTable = db.GetTable<Employee>();
            var query = from e in EmployeeTable
                        where e.Status == true
                        select new HealthProblemViewModel
                        {
                            EmployeeID = e.EmployeeID,
                            EmployeeName = e.FirstName + " " + e.LastName,
                        };
            List<HealthProblemViewModel> list = query.ToList();
            return list;
        }
       
        public bool HealthProblemInsert(HealthProblem entity)
        {
            try
            {
                HealthProblemTable = db.GetTable<HealthProblem>();
                HealthProblemTable.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HealthProblemUpdate(HealthProblem entity)
        {
            try
            {
                HealthProblemTable = db.GetTable<HealthProblem>();
                HealthProblem model = HealthProblemTable.SingleOrDefault(x => x.HealthProblemID.Equals(entity.HealthProblemID));
                model.StudentID = entity.StudentID;
                model.StartDate = entity.StartDate;
                model.EndDate = entity.EndDate;
                model.Signal = entity.Signal;
                model.Diagnosed = entity.Diagnosed;
                model.Measure = entity.Measure;
                model.Serverity = entity.Serverity;
                model.EmployeeID = entity.EmployeeID;
                model.Status = entity.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HealthProblemDelete(int HealthProblemID)
        {
            try
            {
                HealthProblemTable = db.GetTable<HealthProblem>();
                HealthProblem model = HealthProblemTable.SingleOrDefault(x => x.HealthProblemID.Equals(HealthProblemID));
                model.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public HealthProblem GetByID(int HealthProblemID)
        {
            HealthProblemTable = db.GetTable<HealthProblem>();
            return db.HealthProblems.SingleOrDefault(x => x.HealthProblemID == HealthProblemID);
        }
    }
}
