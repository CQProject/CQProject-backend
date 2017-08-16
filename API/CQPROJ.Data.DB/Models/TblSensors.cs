namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblSensors
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? XCoord { get; set; }

        public int? YCoord { get; set; }

        public int? FloorFK { get; set; }
    }
}
