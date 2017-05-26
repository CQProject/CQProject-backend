namespace CQPROJ.Data.BD.Models
{
    using System;

    public partial class TblNotifications
    {
        public int ID { get; set; }

        public DateTime? Hour { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public bool? Urgency { get; set; }

        public int? UserFK { get; set; }
    }
}
