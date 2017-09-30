using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblRecords
    {
        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public int? Temperature { get; set; }

        public int? Luminosity { get; set; }

        public int? Energy { get; set; }

        public double? Humidity { get; set; }

        public int? SensorFK { get; set; }
    }
}
