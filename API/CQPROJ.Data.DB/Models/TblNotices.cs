namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblNotices
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Image { get; set; }

        public int? SchoolFK { get; set; }
    }
}
