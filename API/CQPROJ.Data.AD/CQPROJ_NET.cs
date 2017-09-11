using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Data.AD
{
    public class CQPROJ_NET
    {
        public static Principal GetUser(string SamAccountName)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.10.110", "CQPROJ\\Administrator", "PASS.queiroz2017"))
            {
                using(var searcher=new PrincipalSearcher(new UserPrincipal(context)))
                {
                    searcher.QueryFilter.SamAccountName = SamAccountName;
                    return searcher.FindOne();
                }
            }
        }

        public static Principal CreateUser(string SamAccountName, string Password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.1.124", "CQPROJ\\Administrator", "PASS.queiroz2017"))
            {
                using (var user = new UserPrincipal(context, SamAccountName, Password, true))
                {
                    user.Save();
                    return user;
                }
            }
        }

    }
}
