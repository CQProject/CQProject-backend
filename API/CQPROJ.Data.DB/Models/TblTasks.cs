namespace CQPROJ.Data.DB.Models
{
    public partial class TblTasks
    {
        public int ID { get; set; }

        public int? DayOfWeek { get; set; }

        public string Description { get; set; }

        public int? UserFK { get; set; }
    }
}
