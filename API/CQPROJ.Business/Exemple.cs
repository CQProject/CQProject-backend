using CQPROJ.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business
{
    public class Exemple
    {
        public static User GetUserTeste() {
            var user = CQPROJ.Data.AD.CQPROJ_NET.GetUser("teste");
            return new User { Name = user.DisplayName };
        }
    }
}
