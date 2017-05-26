namespace CQPROJ.Data.BD.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TblPictures
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public bool? IsVisible { get; set; }

        public string Name { get; set; }

        public byte? Type { get; set; }
    }
}
