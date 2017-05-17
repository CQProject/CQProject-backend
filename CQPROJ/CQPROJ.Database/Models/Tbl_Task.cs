using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}