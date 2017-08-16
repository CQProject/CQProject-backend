namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
