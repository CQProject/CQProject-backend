namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblSchools
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public string ProfilePicture { get; set; }

        public string Acronym { get; set; }
    }
}
