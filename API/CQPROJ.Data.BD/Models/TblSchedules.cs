namespace CQPROJ.Data.BD.Models
{
    using System;

    public partial class TblSchedules
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        public TimeSpan? StartingTime { get; set; }

        public TimeSpan? EndingTime { get; set; }

        public string DayOfTheWeek { get; set; }

        public int? TeacherFK { get; set; }

        public int? ClassFK { get; set; }
    }
}
