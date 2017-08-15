namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblTasks
    {
        public int ID { get; set; }

        public int? DayOfWeek { get; set; }

        public string Description { get; set; }

        public int? UserFK { get; set; }
    }
}
