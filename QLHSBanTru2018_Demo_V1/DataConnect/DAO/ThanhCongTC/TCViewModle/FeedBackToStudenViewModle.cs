using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.TCViewModle
{
    public class FeedBackToStudenViewModle
    {
        public int StudentID { get; set; }
        public string StudenCode { get; set; }
        public String FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int? PreferredID { get; set; }
        public int Total { get; set; }
        public int AbsentNumber { get; set; }
        public decimal MoneyFeedBack { get; set; }


    }
}
