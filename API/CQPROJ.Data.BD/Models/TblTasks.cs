namespace CQPROJ.Data.BD.Models
{
    using System;

    public partial class TblTasks
    {
        public int ID { get; set; }

        public string DayOfWeek { get; set; }

        public TimeSpan? Hour { get; set; }

        public bool? Weekly { get; set; }

        public string Description { get; set; }

        public int? SecretaryFK { get; set; }

        public int? SchAssistantFK { get; set; }
    }
}
