namespace CQPROJ.Data.DB.Models
{
    public partial class TblRooms
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? XCoord { get; set; }

        public int? YCoord { get; set; }

        public int? FloorFK { get; set; }

        public bool? HasSensor { get; set; }
    }
}
