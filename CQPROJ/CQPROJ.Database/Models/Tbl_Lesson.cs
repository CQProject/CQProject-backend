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
        public int ID { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Homework { get; set; }

        [Required]
        public string Observations { get; set; }

        [Required]
        [ForeignKey("Lesson_Schedule")]
        public Tbl_Lesson_Schedule Lesson_Schedule { get; set; }
        public int Lesson_ScheduleFK { get; set; }
    }
}