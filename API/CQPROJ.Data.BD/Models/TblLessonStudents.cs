namespace CQPROJ.Data.BD.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TblLessonStudents
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LessonFK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentFK { get; set; }

        public bool? Presence { get; set; }

        public bool? Material { get; set; }

        public int? Behavior { get; set; }
    }
}
