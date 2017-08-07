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

        public int? StartingTime { get; set; }

        public int? Duration { get; set; }

        public int? DayOfWeek { get; set; }

        public int? SubjectFK { get; set; }

        public int? TeacherFK { get; set; }

        public int? ClassFK { get; set; }

        public int? RoomFK { get; set; }
    }
}
