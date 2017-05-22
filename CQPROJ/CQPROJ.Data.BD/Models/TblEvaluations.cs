namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblEvaluations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblEvaluations()
        {
            TblEvaluationStudents = new HashSet<TblEvaluationStudents>();
        }

        public int ID { get; set; }

        public string Purport { get; set; }

        public DateTime? EvaluationDate { get; set; }

        public int? ScheduleFK { get; set; }

        public virtual TblSchedules TblSchedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEvaluationStudents> TblEvaluationStudents { get; set; }
    }
}
