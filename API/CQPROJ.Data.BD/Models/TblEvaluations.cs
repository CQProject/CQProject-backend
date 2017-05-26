namespace CQPROJ.Data.BD.Models
{
    using System;

    public partial class TblEvaluations
    {
        public int ID { get; set; }

        public string Purport { get; set; }

        public DateTime? EvaluationDate { get; set; }

        public int? ScheduleFK { get; set; }
    }
}
