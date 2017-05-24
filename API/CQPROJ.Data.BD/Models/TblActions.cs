namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblActions
    {
        public int ID { get; set; }

        public DateTime Hour { get; set; }

        [Required]
        public string Description { get; set; }

        public int? UserFK { get; set; }

        public virtual TblUsers TblUsers { get; set; }
    }
}