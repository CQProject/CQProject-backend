using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    public class Tbl_Teacher
    {
        [Key]
        public int ID { get; set; }

        public String Curriculum { get; set; }

        //****************************************************************
        // FOREIGN KEYS

        // Foreign key to User
        public Tbl_User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public String UserFK { get; set; }

        //****************************************************************
    }
}