namespace CQPROJ.Data.BD.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class TblTeachers
    {
        public int ID { get; set; }

        [StringLength(9)]
        public string FiscalNumber { get; set; }

        [StringLength(9)]
        public string CitizenCard { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

        public string Curriculum { get; set; }

        public int UserFK { get; set; }
    }
}
