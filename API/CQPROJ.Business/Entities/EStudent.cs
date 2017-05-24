using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities.EStudent
{
    public class Student
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Photo { get; set; }

        public string GuardianName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
