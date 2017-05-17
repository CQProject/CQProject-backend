using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Presentation
{
    //DESCRIPTION:
    //Refers to the configuration of Layout Pages
    public class Tbl_School
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public int ProfilePicture { get; set; }

        [Required]
        public string Acronym { get; set; }

        [Required]
        public DateTime OpeningTime { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }
    }
}