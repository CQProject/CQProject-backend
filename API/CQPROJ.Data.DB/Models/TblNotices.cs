using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblNotices
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Image { get; set; }

        public int? SchoolFK { get; set; }
    }
}
