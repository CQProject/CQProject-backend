using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    // DESCRIPTION :
    // Refers to school assistant that will have tasks scheduled by secretariat
    public class Tbl_Functionary
    {
        [Key]
        public int ID { get; set; }

        public DateTime StartWorkTime { get; set; }

        public DateTime EndWorkTime { get; set; }

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