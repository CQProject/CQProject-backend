namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblSchoolLayout")]
    public partial class TblSchoolLayout
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public string ProfilePicture { get; set; }

        [StringLength(50)]
        public string Acronym { get; set; }

        public DateTime? OpeningTime { get; set; }

        public DateTime? ClosingTime { get; set; }
    }
}
