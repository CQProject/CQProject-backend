namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblNotifications
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblNotifications()
        {
            TblValidations = new HashSet<TblValidations>();
        }

        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public string Description { get; set; }

        public bool? Urgency { get; set; }

        public int? UserFK { get; set; }

        public virtual TblUsers TblUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblValidations> TblValidations { get; set; }
    }
}
