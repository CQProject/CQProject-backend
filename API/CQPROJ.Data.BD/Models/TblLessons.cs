namespace CQPROJ.Data.BD.Models
{
    public partial class TblLessons
    {
        public int ID { get; set; }

        public string Summary { get; set; }

        public string Homework { get; set; }

        public string Observations { get; set; }

        public int? ScheduleFK { get; set; }
    }
}
