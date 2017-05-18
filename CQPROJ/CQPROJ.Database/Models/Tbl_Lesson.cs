using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to one Class Lesson
    public class Tbl_Lesson
    {
        public Tbl_Lesson()
        {
            Students = new HashSet<Tbl_Lesson_Student>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Homework { get; set; }

        [Required]
        public string Observations { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        [Required]
        [ForeignKey("Schedule")]
        public virtual Tbl_Schedule Schedule { get; set; }
        public int ScheduleFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************

        //***********************  RELATIONSHIP(S)  *****************************
        public ICollection<Tbl_Lesson_Student> Students { get; set; }
        //********************* END RELATIONSHIP(S)  ****************************
    }
}