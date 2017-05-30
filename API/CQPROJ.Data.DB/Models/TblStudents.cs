namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblStudents
    {
        public int ID { get; set; }

        public string Photo { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public int? UserFK { get; set; }

        public int? GuardianFK { get; set; }
    }
}
