using System;

namespace CQPROJ.Data.DB.Models
{
    public partial class TblDocuments
    {
        public int ID { get; set; }

        public string File { get; set; }

        public bool? IsVisible { get; set; }

        public DateTime? SubmitedIn { get; set; }

        public int? ClassFK { get; set; }

        public int? UserFK { get; set; }

        public int? SubjectFK { get; set; }
    }
}
