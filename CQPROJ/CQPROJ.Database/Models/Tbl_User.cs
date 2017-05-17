using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace CQPROJ.Database.Models
{
    // DESCRIPTION :
    // Refers to a IdentityUser that allow access to the information system
    public class Tbl_User : IdentityUser
    {
        [Required]
        public String Name { get; set; }

        public String NIF { get; set; }

        public String CitizenCard { get; set; }

        public String Address { get; set; }

        public String Photo { get; set; }
    }
}