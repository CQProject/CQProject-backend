namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblStudents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblStudents()
        {
            TblEvaluationStudents = new HashSet<TblEvaluationStudents>();
            TblLessonStudents = new HashSet<TblLessonStudents>();
            TblClasses = new HashSet<TblClasses>();
        }

        public int ID { get; set; }

        public string Photo { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public int? UserFK { get; set; }

        public int? GuardianFK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEvaluationStudents> TblEvaluationStudents { get; set; }

        public virtual TblGuardians TblGuardians { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblLessonStudents> TblLessonStudents { get; set; }

        public virtual TblUsers TblUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblClasses> TblClasses { get; set; }
    }
}
