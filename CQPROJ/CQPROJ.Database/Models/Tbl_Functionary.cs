using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    // DESCRIPTION :
    // Refers to school assistant that will have tasks scheduled by secretariat
    public class Tbl_Functionary
    {
        public Tbl_Functionary()
        {
            Tasks = new HashSet<Tbl_Task>();
        }

        [Key]
        public int ID { get; set; }

        public DateTime StartWorkTime { get; set; }

        public DateTime EndWorkTime { get; set; }

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