namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblSchAssistants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblSchAssistants()
        {
            TblTasks = new HashSet<TblTasks>();
        }

        public int Id { get; set; }

        [StringLength(9)]
        public string FiscalNumber { get; set; }

        [StringLength(9)]
        public string CitizenCard { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

        public string Curriculum { get; set; }

        public DateTime? StartWorkTime { get; set; }

        public DateTime? EndWorkTime { get; set; }

        public int UserFK { get; set; }

        public virtual TblUsers TblUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblTasks> TblTasks { get; set; }
    }
}
