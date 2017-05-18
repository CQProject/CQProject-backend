using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    // DESCRIPTION :
    // Refers to administrator that will costumize 
    //  layout pages, school descriptions, working hours...
    //  and supervise all activity by other users
    public class Tbl_Admin 
    {
        [Key]
        public int ID { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public String UserFK { get; set; }
        //*********************  FOREIGN KEY(S)  ********************************
    }
}