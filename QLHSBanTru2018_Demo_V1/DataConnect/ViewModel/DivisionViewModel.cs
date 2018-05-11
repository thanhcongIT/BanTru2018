using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class DivisionViewModel
    {
        public int DivisionID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeFullName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByFullName { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
    }
}
