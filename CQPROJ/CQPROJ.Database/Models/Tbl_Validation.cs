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
    //Refers to an validation from the receiver of a notification
    public class Tbl_Validation
    {
        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_User User { get; set; } 
        [Column(Order = 0), Key, ForeignKey("User")]
        public String UserFK { get; set; } 

        public virtual Tbl_Notification Notification { get; set; } 
        [Column(Order = 1), Key, ForeignKey("Notification")]
        public int NotificationFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************

        [DefaultValue(false)]
        public Boolean Accepted { get; set; }
    }
}