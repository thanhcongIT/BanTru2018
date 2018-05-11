using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
   public class HealthProblemViewModel
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string HomeName { get; set; }
        public DateTime? Birthday { get; set; }

        public int HealthProblemID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Signal { get; set; }
        public string Diagnosed { get; set; }
        public string Measure { get; set; }
        public string Serverity { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public bool? Status { get; set; }

        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }
}
