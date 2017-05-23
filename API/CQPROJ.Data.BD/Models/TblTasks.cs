namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblTasks
    {
        public int ID { get; set; }

        public DateTime? DayOfWeek { get; set; }

        public DateTime? Hour { get; set; }

        public bool? Weekly { get; set; }

        public string Description { get; set; }

        public int? SecretaryFK { get; set; }

        public int? SchAssistantFK { get; set; }

        public virtual TblSchAssistants TblSchAssistants { get; set; }

        public virtual TblSecretaries TblSecretaries { get; set; }
    }
}
