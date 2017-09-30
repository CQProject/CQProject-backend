using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblActions
    {
        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public string Description { get; set; }

        public int? UserFK { get; set; }
    }
}
