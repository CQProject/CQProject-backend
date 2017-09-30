using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblDone
    {
        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public int? TaskFK { get; set; }
    }
}
