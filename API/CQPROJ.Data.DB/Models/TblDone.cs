namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblDone")]
    public partial class TblDone
    {
        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public int? TaskFK { get; set; }
    }
}
