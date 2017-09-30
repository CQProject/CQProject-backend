using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblValidations
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiverFK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotificationFK { get; set; }

        public int? StudentFK { get; set; }

        public bool? Accepted { get; set; }

        public bool? Read { get; set; }
    }
}
