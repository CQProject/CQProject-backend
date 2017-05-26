namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TblSchoolLayout")]
    public partial class TblSchoolLayout
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public string BackgroundPicture { get; set; }

        [StringLength(50)]
        public string Acronym { get; set; }

        public TimeSpan? OpeningTime { get; set; }

        public TimeSpan? ClosingTime { get; set; }
    }
}
