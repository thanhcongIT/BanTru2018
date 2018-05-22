using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class DailyTrackerFullViewModel
    {
        public int DailyTrackerID { get; set; }
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentHomeName { get; set; }
        public int WeekID { get; set; }
        public DateTime Date { get; set; }
        public int Present { get; set; }
        public string PresentString { get; set; }
        public string Reason { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public string DrugTime { get; set; }
        public int? Eating { get; set; }
        public int? Sleep { get; set; }
        public int? Health { get; set; }
        public int? Study { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }

        public int? Monday { get; set; }
        public int? Tuesday { get; set; }
        public int? Wednesday { get; set; }
        public int? Thursday { get; set; }
        public int? Friday { get; set; }
        public int? Saturday { get; set; }
        public int? Sunday { get; set; }
    }
}
