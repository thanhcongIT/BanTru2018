using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class EmployeeFullViewModel
    {
        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public byte[] Image { get; set; }
        public int LocationID { get; set; }
        public string LocationDetail { get; set; }
        public int DegreeID { get; set; }
        public string DegreeName { get; set; }
        public string Note { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public String PlaceOfIssue { get; set; }
        public bool Status { get; set; }
    }
}
