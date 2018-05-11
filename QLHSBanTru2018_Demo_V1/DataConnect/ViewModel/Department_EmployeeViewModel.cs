using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class Department_EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public byte[] Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int LocationID { get; set; }
        public string LocationDetail { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? PositionID { get; set; }
        public string PositionName { get; set; }
        public int? DegreeID { get; set; }
        public string DegreeName { get; set; }
        public bool? Status { get; set; }
    }
}
