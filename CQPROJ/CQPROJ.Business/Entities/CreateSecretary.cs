using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CQPROJ.Business.Entities
{
    public class CreateSecretary
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(9)]
        public string FiscalNumber { get; set; }

        [StringLength(9)]
        public string CitizenCard { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }

        public string Curriculum { get; set; }

        /* public DateTime? StartWorkTime { get; set; }

        public DateTime? EndWorkTime { get; set; }*/
    }
}