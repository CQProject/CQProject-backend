using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblEvaluations
    {
        public int ID { get; set; }

        public string Purport { get; set; }

        public DateTime? EvaluationDate { get; set; }

        public int? ClassFK { get; set; }

        public int? SubjectFK { get; set; }

        public int? TeacherFK { get; set; }
    }
}
