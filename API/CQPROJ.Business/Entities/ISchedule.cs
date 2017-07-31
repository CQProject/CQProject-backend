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

        public DateTime? StartingTime { get; set; }

        public DateTime? EndingTime { get; set; }

    }
}
