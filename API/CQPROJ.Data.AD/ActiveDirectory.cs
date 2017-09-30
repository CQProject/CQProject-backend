using System;
using System.DirectoryServices.AccountManagement;

namespace CQPROJ.Data.AD
{
    public class ActiveDirectory
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

        public static Object CreateUser(string SamAccountName, string Password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.1.124", "CQPROJ\\Administrator", "PASS.queiroz2017"))
            {
                try
                {
                    using (var user = new UserPrincipal(context, SamAccountName, Password, true))
                    {
                        user.Save();
                        return user;
                    }
                }
                catch (Exception)
                {
                    return new { result = false, data = "Password demasiado curta" };
                }
            }
        }
    }
}
