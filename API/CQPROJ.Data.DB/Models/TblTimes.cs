namespace CQPROJ.Data.DB.Models
{
    public partial class TblTimes
    {
        public int ID { get; set; }

        public int? Order { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public bool? IsKindergarten { get; set; }

        public int? SchoolFK { get; set; }
    }
}
