namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblSchedules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblSchedules()
        {
            TblEvaluations = new HashSet<TblEvaluations>();
            TblLessons = new HashSet<TblLessons>();
        }

        public int ID { get; set; }

        public string Subject { get; set; }

        public DateTime? StartingTime { get; set; }

        public DateTime? EndingTime { get; set; }

        public int? TeacherFK { get; set; }

        public int? ClassFK { get; set; }

        public virtual TblClasses TblClasses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEvaluations> TblEvaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblLessons> TblLessons { get; set; }

        public virtual TblTeachers TblTeachers { get; set; }
    }
}
