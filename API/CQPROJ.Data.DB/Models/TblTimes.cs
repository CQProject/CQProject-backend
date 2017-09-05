namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
