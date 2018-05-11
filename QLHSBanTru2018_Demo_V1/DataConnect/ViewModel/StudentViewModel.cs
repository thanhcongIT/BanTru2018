using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
   public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? DateStudy { get; set; }
        public bool? Gender { get; set; }
        public byte[] Image { get; set; }
        public string Hobby { get; set; }
        public string Talen { get; set; }
        public string AdressDetail { get; set; }
        public string Note { get; set; }
        public bool? Status { get; set; }

        public string Password { get; set; }
        public string FatherName { get; set; }
        public DateTime? FatherBirthday { get; set; }
        public string FatherJob { get; set; }
        public string FatherPhone { get; set; }
        public string MotherName { get; set; }
        public DateTime? MotherBirthday { get; set; }
        public string MotherJob { get; set; }
        public string MotherPhone { get; set; }
        public string ParentsNote { get; set; }


        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string StudentClassNote { get; set; }
        public int LocationID { get; set; }
        public string LocationDetail { get; set; }
        public int EthnicGroupID { get; set; }
        public string EthnicGroupName { get; set; }
        public int ReligionID { get; set; }
        public string ReligionName { get; set; }
        public int BirthPlaceID { get; set; }
        public int PreferredID { get; set; }
        public string PreferredName { get; set; }

    }
}
