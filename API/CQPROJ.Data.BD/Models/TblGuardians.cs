namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblGuardians
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblGuardians()
        {
            TblStudents = new HashSet<TblStudents>();
        }

        public int Id { get; set; }

        [StringLength(9)]
        public string FiscalNumber { get; set; }

        [StringLength(9)]
        public string CitizenCard { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime? StartWorkTime { get; set; }

        public string NotContactHours { get; set; }

        public int UserFK { get; set; }

        public virtual TblUsers TblUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblStudents> TblStudents { get; set; }
    }
}
