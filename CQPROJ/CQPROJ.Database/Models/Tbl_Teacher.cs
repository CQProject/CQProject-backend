using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    public class Tbl_Teacher
    {
        public Tbl_Teacher()
        {
            Schedules = new HashSet<Tbl_Schedule>();
        }

        [Key]
        public int ID { get; set; }

        public String Curriculum { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public String UserFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************

        //***********************  RELATIONSHIP(S)  *****************************
        public ICollection<Tbl_Schedule> Schedules { get; set; }
        //********************* END RELATIONSHIP(S)  ****************************
    }
}