namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblLessons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblLessons()
        {
            TblLessonStudents = new HashSet<TblLessonStudents>();
        }

        public int ID { get; set; }

        public string Summary { get; set; }

        public string Homework { get; set; }

        public string Observations { get; set; }

        public int? ScheduleFK { get; set; }

        public virtual TblSchedules TblSchedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblLessonStudents> TblLessonStudents { get; set; }
    }
}
