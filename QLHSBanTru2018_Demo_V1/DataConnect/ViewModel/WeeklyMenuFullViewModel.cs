﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class WeeklyMenuFullViewModel
    {
        public int DailyMenuID { get; set; }
        public int WeekID { get; set; }
        public int WeekIndex { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string AfterLunch { get; set; }
        public string Afternoon { get; set; }
        public bool IsForm { get; set; }
        public bool Status { get; set; }
    }
}
