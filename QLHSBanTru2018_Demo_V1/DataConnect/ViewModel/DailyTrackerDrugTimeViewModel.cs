using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class DailyTrackerDrugTimeViewModel
    {
        public int DailyTrackerDrugTimeID { get; set; }
        public int DailyTrackerID { get; set; }
        public int StudentID { get; set; }
        public string StudentFullName { get; set; }
        public string StudentHomeName { get; set; }
        public string DrugName { get; set; }
        public int DrugQuantity { get; set; }
        public TimeSpan DrugTime { get; set; }
        public TimeSpan RemainingTime { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public string StringStatus { get; set; }
    }
}
