using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
   public class HealthExaminationViewModel
    {
        public int HealthExaminationID { get; set; }
        public DateTime? DateExamination { get; set; }       
        public string NameExamination { get; set; }
        public string PlaceExamination { get; set; }
        public bool Height { get; set; }
        public bool Weight { get; set; }
        public bool Eyes { get; set; }
        public bool ENT { get; set; }
        public bool Oral { get; set; }
        public bool InternalMedicine { get; set; }
        public bool Surgery { get; set; }
        public bool Dermatology { get; set; }
        public bool BoneMuscle { get; set; }
        public bool Nerve { get; set; }
        public bool Endocrine { get; set; }
        public bool Status { get; set; }
    }
}
