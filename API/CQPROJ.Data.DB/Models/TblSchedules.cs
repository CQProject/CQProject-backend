namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblSchedules
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartingTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndingTime { get; set; }

        public string DayOfTheWeek { get; set; }

        public int? TeacherFK { get; set; }

        public int? ClassFK { get; set; }
    }
}
