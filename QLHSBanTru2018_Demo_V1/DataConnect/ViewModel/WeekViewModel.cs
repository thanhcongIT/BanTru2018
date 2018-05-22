using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class WeekViewModel
    {
        public int WeekID { get; set; }
        public int WeekIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WeekFullName { get; set; }
    }
}
