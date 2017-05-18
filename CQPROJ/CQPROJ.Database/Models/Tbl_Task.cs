using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to the tasks that the School Assistants will do
    public class Tbl_Task
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string DayOfTheWeek { get; set; }

        [Required]
        public DateTime Hour { get; set; }

        [Required]
        public Boolean Weekly { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_Secretary Secretary { get; set; }
        [Required]
        [ForeignKey("Secretary")]
        public String SecretaryFK { get; set; }

        public virtual Tbl_Functionary Functionary { get; set; }
        [Required]
        [ForeignKey("Functionary")]
        public String FunctionaryFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************
    }
}