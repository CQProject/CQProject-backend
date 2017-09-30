using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblNotifications
    {
        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public bool? Urgency { get; set; }

        public bool? Approval { get; set; }

        public int? UserFK { get; set; }
    }
}
