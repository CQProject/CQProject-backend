namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblEvaluations
    {
        public int ID { get; set; }

        public string Purport { get; set; }

        public DateTime? EvaluationDate { get; set; }

        public int? ScheduleFK { get; set; }
    }
}
