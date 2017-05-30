namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblLessons
    {
        public int ID { get; set; }

        public string Summary { get; set; }

        public string Homework { get; set; }

        public string Observations { get; set; }

        public int? ScheduleFK { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Day { get; set; }
    }
}
