using DataConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class ContractDAO
    {
        QLHSSmartKidsDataContext db;
        Table<Contract> contract;
        Table<Employee> employee;

        public ContractDAO()
        {
            db = new QLHSSmartKidsDataContext();
            contract = db.GetTable<Contract>();
            employee = db.GetTable<Employee>();
        }
        public List<ContractViewModel> ListAll()
        {
            contract = db.GetTable<Contract>();
            employee = db.GetTable<Employee>();
            var query = from c in contract
                        join e in employee
                        on c.EmployeeID equals e.EmployeeID
                        join e2 in employee
                        on c.CreatedBy equals e2.EmployeeID
                        where c.Status == true
                        select new ContractViewModel
                        {
                            ContractID = c.ContractID,
                            ContractType = c.ContractType,
                            TimeType = c.TimeType == 0 ? "Không thời hạn" : "Có thời hạn",
                            EmployeeID = e.EmployeeID,
                            EmployeeFullName = e.FirstName + " " + e.LastName,
                            PayRate = c.PayRate,
                            StartDate = c.StartDate,
                            EndDate = c.EndDate,
                            CreatedBy = c.CreatedBy,
                            CreatedByName = e2.FirstName + " " + e2.LastName,
                            CreatedDate = c.CreatedDate,
                            AttachedFile = null,
                            Note = c.Note,
                            Status = c.Status
                        };
            return query.ToList();
        }
        public int Insert(Contract entity)
        {
            try
            {
                contract = db.GetTable<Contract>();
                contract.InsertOnSubmit(entity);
                db.SubmitChanges();
                //History;
                return entity.ContractID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(Contract entity)
        {
            try
            {
                contract = db.GetTable<Contract>();
                Contract obj = contract.Single(x => x.ContractID == entity.ContractID);
                obj.ContractType = entity.ContractType;
                obj.EmployeeID = entity.EmployeeID;
                obj.PayRate = entity.PayRate;
                obj.StartDate = entity.StartDate;
                obj.Note = entity.Note;
                obj.CreatedDate = entity.CreatedDate;
                obj.CreatedBy = entity.CreatedBy;
                obj.EndDate = entity.EndDate;
                obj.TimeType = entity.TimeType;
                obj.Status = entity.Status;
                db.SubmitChanges();
                //Insert History
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int contractID)
        {
            try
            {
                Contract obj = contract.Single(x => x.ContractID == contractID);
                obj.Status = false;
                db.SubmitChanges();
                //Insert History
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Contract GetByID(int contractID)
        {
            contract = db.GetTable<Contract>();
            return db.Contracts.SingleOrDefault(x => x.ContractID == contractID);
        }
        public ContractReportViewModel GetForReport(int contractID)
        {
            try
            {
                var model = from c in contract
                            where c.ContractID == contractID
                            select new ContractReportViewModel
                            {
                                ContractID = c.ContractID,
                                ContractType = c.ContractType,
                                TimeType = c.TimeType,
                                StringTimeType = c.TimeType.ToString(),
                                EmployeeID = c.EmployeeID,
                                EmployeeFullName = c.Employee.FirstName + " " + c.Employee.LastName,
                                PayRate = c.PayRate,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                CreatedBy = c.CreatedBy,
                                CreatedByFullName = c.Employee1.FirstName + " " + c.Employee1.LastName,
                                CreatedDate = c.CreatedDate
                            };
                return model.FirstOrDefault();
            }
            catch(Exception ex)
            {
                Console.WriteLine("LỖI ĐÂY NÀY:........."+ex.ToString());
                return null;
            }
        }
    }
}
