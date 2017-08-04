using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities.ISchedule
{
    public class Schedule
    {
        public string Subject { get; set; }

        public int? StartingTime { get; set; }

        public int? Duration { get; set; }

        public int? DayOfWeek { get; set; }

        public int? TeacherFK { get; set; }

        public int? ClassFK { get; set; }

        public int? RoomFK { get; set; }

    }
}
