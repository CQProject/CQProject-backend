namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblDocuments
    {
        public int ID { get; set; }

        public string Document { get; set; }

        public bool? IsVisible { get; set; }

        public int? ClassFK { get; set; }

        public virtual TblClasses TblClasses { get; set; }
    }
}
