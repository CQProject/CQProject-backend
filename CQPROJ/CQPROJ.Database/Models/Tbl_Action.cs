using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    public class Tbl_Action
    {
        [Key]
        public int ID { get; set; }

        public String Description { get; set; }

        public DateTime Hour { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public Tbl_User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public String UserFK { get; set; }
        //*********************  FOREIGN KEY(S)  ********************************
    }
}