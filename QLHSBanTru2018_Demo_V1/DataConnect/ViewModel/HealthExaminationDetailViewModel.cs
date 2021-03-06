﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
   public class HealthExaminationDetailViewModel
    {
        public int HealthExaminationDetailID { get; set; }
        public int HealthExaminationID { get; set; }
        public string HealthExaminationName { get; set; }
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string StringGender { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string HealthInsurance { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Eyes { get; set; }
        public string ENT { get; set; }
        public string Oral { get; set; }
        public string InternalMedicine { get; set; }
        public string Surgery { get; set; }
        public string Dermatology { get; set; }
        public string BoneMuscle { get; set; }
        public string Nerve { get; set; }
        public string Endocrine { get; set; }
        public string Other { get; set; }
        public string Note { get; set; }
        public string Rating { get; set; }
        public bool Status { get; set; }

    }
}
