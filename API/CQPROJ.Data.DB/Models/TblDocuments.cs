namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblDocuments
    {
        public int ID { get; set; }

        public string File { get; set; }

        public bool? IsVisible { get; set; }

        public DateTime? SubmitedIn { get; set; }

        public int? ClassFK { get; set; }

        public int? UserFK { get; set; }

        public int? SubjectFK { get; set; }
    }
}
