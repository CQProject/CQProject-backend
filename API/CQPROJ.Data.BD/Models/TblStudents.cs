namespace CQPROJ.Data.BD.Models
{
    using System;

    public partial class TblStudents
    {
        public int ID { get; set; }

        public string Photo { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public int? UserFK { get; set; }

        public int? GuardianFK { get; set; }
    }
}
