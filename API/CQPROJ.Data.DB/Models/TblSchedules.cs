namespace CQPROJ.Data.DB.Models
{
    public partial class TblSchedules
    {
        public int ID { get; set; }

        public int? TimeFK { get; set; }

        public int? Duration { get; set; }

        public int? DayOfWeek { get; set; }

        public int? SubjectFK { get; set; }

        public int? TeacherFK { get; set; }

        public int? ClassFK { get; set; }

        public int? RoomFK { get; set; }
    }
}
