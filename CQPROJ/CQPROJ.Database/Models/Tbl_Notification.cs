using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to the Notification sent to the Guardians
    public class Tbl_Notification
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Hour { get; set; }

        [Required]
        public string Description { get; set; }

        [DefaultValue(false)]
        public Boolean Urgency { get; set; }


        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_User Sender { get; set; }
        [ForeignKey("Sender")]
        public int SenderFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************
    }
}