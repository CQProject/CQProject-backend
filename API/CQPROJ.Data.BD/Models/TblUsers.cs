namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class TblUsers
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? IsActive { get; set; }

        public string Function { get; set; }
    }
}
