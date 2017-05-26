namespace CQPROJ.Data.BD.Models
{
    public partial class TblDocuments
    {
        public int ID { get; set; }

        public string Document { get; set; }

        public bool? IsVisible { get; set; }

        public int? ClassFK { get; set; }
    }
}
