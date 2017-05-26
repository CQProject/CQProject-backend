namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class TblActions
    {
        public int ID { get; set; }

        public DateTime Hour { get; set; }

        [Required]
        public string Description { get; set; }

        public int? UserFK { get; set; }
    }
}
