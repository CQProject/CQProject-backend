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
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.10.110", "CQPROJ\\teste", "zaq1\"WSX"))
            {
                using(var searcher=new PrincipalSearcher(new UserPrincipal(context)))
                {
                    searcher.QueryFilter.SamAccountName = SamAccountName;
                    return searcher.FindOne();
                }
            }
        }
    }
}
