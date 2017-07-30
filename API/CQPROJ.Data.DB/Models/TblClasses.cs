namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblClasses
    {
        public int ID { get; set; }

        public string SchoolYear { get; set; }

        public string Year { get; set; }

        public string ClassDesc { get; set; }

        public int? SchoolFK { get; set; }

        public int? TeacherFK { get; set; }
    }
}
