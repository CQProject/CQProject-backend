namespace CQPROJ.Data.DB.Models
{
    public partial class TblClasses
    {
        public int ID { get; set; }

        public string SchoolYear { get; set; }

        public string Year { get; set; }

        public string ClassDesc { get; set; }

        public int? SchoolFK { get; set; }
    }
}
