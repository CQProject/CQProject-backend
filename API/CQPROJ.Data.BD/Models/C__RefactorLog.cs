namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("__RefactorLog")]
    public partial class C__RefactorLog
    {
        [Key]
        public Guid OperationKey { get; set; }
    }
}
