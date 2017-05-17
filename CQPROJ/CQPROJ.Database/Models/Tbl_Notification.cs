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

        public int ID { get; set; }

        [Required]
        public DateTime Hour { get; set; }

        [Required]
        public string Description { get; set; }

        [DefaultValue(false)]
        public Boolean Urgency { get; set; }


        //*************************FOREIGN KEY**********************************
        [ForeignKey("Authorization")]
        public Tbl_Authorization Authorization { get; set; }
        [DefaultValue(null)]
        public int AuthorizationFK { get; set; }
    }
}