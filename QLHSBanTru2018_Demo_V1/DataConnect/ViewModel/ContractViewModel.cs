using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class ContractViewModel
    {
        public int ContractID { get; set; }
        public String ContractType { get; set; }
        public String TimeType { get; set; }
        public int EmployeeID { get; set; }
        public String EmployeeFullName { get; set; }
        public double PayRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CreatedBy { get; set; }
        public String CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] AttachedFile { get; set; }
        public String Note { get; set; }
        public bool Status { get; set; }
    }
}
