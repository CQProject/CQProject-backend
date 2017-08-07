namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblFloors
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int? SchoolFK { get; set; }
    }
}
