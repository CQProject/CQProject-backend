using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblLessons
    {
        public int ID { get; set; }

        public string Summary { get; set; }

        public string Homework { get; set; }

        public string Observations { get; set; }

        public DateTime? Day { get; set; }

        public int? ScheduleFK { get; set; }
    }
}
