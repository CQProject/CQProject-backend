using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    public class Lesson
    {
        public int ID { get; set; }

        public string Summary { get; set; }

        public string Homework { get; set; }

        public string Observations { get; set; }

        public DateTime Day { get; set; }

        public int ScheduleFK { get; set; }
    }
}
