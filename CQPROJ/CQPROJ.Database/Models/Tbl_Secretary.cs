using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    // DESCRIPTION :
    // Refers to a Secretary that stipules tasks to school assistants, 
    //  register students and guardians 
    //  and may send notifications to guardians
    public class Tbl_Secretary
    {
        public Tbl_Secretary()
        {
            Tasks = new HashSet<Tbl_Task>();
        }

        [Key]
        public int ID { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public String UserFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************

        //***********************  RELATIONSHIP(S)  *****************************
        public ICollection<Tbl_Task> Tasks { get; set; }
        //********************* END RELATIONSHIP(S)  ****************************
    }
}