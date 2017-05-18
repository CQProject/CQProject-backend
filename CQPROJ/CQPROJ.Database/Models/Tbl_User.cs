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
        public Tbl_User()
        {
            Notifications = new HashSet<Tbl_Notification>();
            Validations = new HashSet<Tbl_Validation>();
        }

        [Required]
        public String Name { get; set; }

        public String NIF { get; set; }

        public String CitizenCard { get; set; }

        public String Address { get; set; }

        public String Photo { get; set; }

        //***********************  RELATIONSHIP(S)  *****************************
        public virtual Tbl_Admin Admin { get; set; }
        public virtual Tbl_Teacher Teacher { get; set; }
        public virtual Tbl_Secretary Secretary { get; set; }
        public virtual Tbl_Functionary Functionary { get; set; }
        public virtual Tbl_Guardian Guardian { get; set; }
        public virtual Tbl_Student Student { get; set; }

        public ICollection<Tbl_Notification> Notifications { get; set; }
        public ICollection<Tbl_Validation> Validations { get; set; }
        //********************* END RELATIONSHIP(S)  ****************************
    }
}