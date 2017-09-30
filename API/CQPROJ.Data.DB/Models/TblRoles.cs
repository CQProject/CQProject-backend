using System.ComponentModel.DataAnnotations;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblRoles
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
