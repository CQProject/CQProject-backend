namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblSchAssistants
    {
        public int ID { get; set; }

        [StringLength(9)]
        public string FiscalNumber { get; set; }

        [StringLength(9)]
        public string CitizenCard { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

        public string Curriculum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartWorkTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndWorkTime { get; set; }

        public int UserFK { get; set; }
    }
}
