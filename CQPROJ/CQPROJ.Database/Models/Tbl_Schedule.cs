using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    //DESCRIPTION:
    //Refers to the Classes schedule
    public class Tbl_Schedule
    {
        public Tbl_Schedule()
        {
            Lesssons = new HashSet<Tbl_Lesson>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public DateTime StartingTime { get; set; }

        [Required]
        public DateTime EndingTime { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_Teacher Teacher { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public String TeacherFK { get; set; }

        public virtual Tbl_Class Class { get; set; }
        [Required]
        [ForeignKey("Class")]
        public String ClassFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************

        //***********************  RELATIONSHIP(S)  *****************************
        public ICollection<Tbl_Lesson> Lesssons { get; set; }
        //********************* END RELATIONSHIP(S)  ****************************
    }
}