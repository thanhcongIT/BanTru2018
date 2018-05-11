using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class LessonViewModel
    {
        public int LessonID { get; set; }
        public string Name { get; set; }
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string TopicDescription { get; set; }
        public bool Status { get; set; }
    }
}
