using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataConnect.DAO.ThanhCongTC.TCViewModle
{
    public class TCStudentViewModle
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
       // public  Image?  fd { get; set; }
        public string Hobby { get; set; }
        public string Talent { get; set; }
        public DateTime DateStudy { get; set; }
        public int EthnicGroupID { get; set; }
        public int ReligionID { get; set; }
        public int BirthPlaceID { get; set; }
        public int LocationID { get; set; }
        public string AdressDetail { get; set; }
        public int PreferredID { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }

    }
}
