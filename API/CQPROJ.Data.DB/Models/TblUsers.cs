using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblUsers
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string FiscalNumber { get; set; }

        public string CitizenCard { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

        public string Curriculum { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Password { get; set; }

        public DateTime? RegisterDate { get; set; }

        public bool? IsActive { get; set; }

        public string Function { get; set; }
    }
}
