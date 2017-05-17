using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to an authorization sent to a guardian
    public class Tbl_Authorization
    {
        public int ID { get; set; }

        [Required]
        public string Matter { get; set; }

        [DefaultValue(false)]
        public Boolean Accepted { get; set; }
    }
}