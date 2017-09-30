namespace CQPROJ.Data.DB.Models
{
    public partial class TblFloors
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int? SchoolFK { get; set; }
    }
}
