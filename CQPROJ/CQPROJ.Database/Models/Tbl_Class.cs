using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to the Classes that have Professors and Students
    public class Tbl_Class
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(9,ErrorMessage = "Follow the Convection: Year/Year. Ex.: 2015/2016")]
        [RegularExpression("[0-9]{4}/[0-9]{4}")]
        public string SchoolYear { get; set; }

        [Required]
        public int Year { get; set; }

        public string ClassDesc { get; set; }


    }
}