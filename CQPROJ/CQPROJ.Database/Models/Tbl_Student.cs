using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Models
{
    // 
    public class Tbl_Student
    {
        public Tbl_Student()
        {
            Classes = new HashSet<Tbl_Class>();
            Lessons = new HashSet<Tbl_Lesson_Student>();
        }

        [Key]
        public int ID { get; set; }

        //*********************  FOREIGN KEY(S)  ********************************
        public virtual Tbl_User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public String UserFK { get; set; }

        public virtual Tbl_Guardian Guardian { get; set; }
        [Required]
        [ForeignKey("Guardian")]
        public String GuardianFK { get; set; }
        //********************* END FOREIGN KEY(S)  *****************************

        //***********************  RELATIONSHIP(S)  *****************************
        public ICollection<Tbl_Class> Classes { get; set; }
        public ICollection<Tbl_Lesson_Student> Lessons { get; set; }
        //********************* END RELATIONSHIP(S)  ****************************
    }
}