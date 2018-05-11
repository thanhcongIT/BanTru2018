using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
   public class PhysicalAssessmentViewModel
    {
        public int PhysicalAssessmentID { get; set; }
        public DateTime? DatePhysicalAssessment { get; set; }
        public string NamePhysicalAssessment { get; set; }
        public string NotePhysicalAssessment { get; set; }
        public bool StatusPhysicalAssessment { get; set; }


        public int PhysicalAssessmentDetailID { get; set; }       
        public int Height { get; set; }
        public int Weight { get; set; }
        public string HeightRating { get; set; }
        public string WeightRating { get; set; }
        public string OtherRating { get; set; }
        public string NoteDetail { get; set; }
        public bool StatusPhysicalAssessmentDetail { get; set; }


        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }
}
