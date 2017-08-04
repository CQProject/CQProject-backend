using CQPROJ.Business.Entities.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    public class Student_Guardian
    {
        public User Student { get; set; }

        public User[] Guardian { get; set; }
    }
}
