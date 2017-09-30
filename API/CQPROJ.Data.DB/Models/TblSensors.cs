namespace CQPROJ.Data.DB.Models
{
    public partial class TblSensors
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? RoomFK { get; set; }
    }
}
