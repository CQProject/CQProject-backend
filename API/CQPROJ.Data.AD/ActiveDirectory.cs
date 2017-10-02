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

                        return true;
                    }
                }
                catch (Exception)
                {
                    return new { result = false, data = "Password demasiado curta" };
                }
            }
        }

        public static Object AddRole(string SamAccountName, int Group)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.1.124", "CQPROJ\\Administrator", "PASS.queiroz2017"))
            {
                try
                {
                    using (var user = UserPrincipal.FindByIdentity(context, SamAccountName))
                    {
                        string groupName = "";
                        switch (Group)
                        {
                            case 1:
                                groupName = "Student";
                                break;
                            case 2:
                                groupName = "Teacher";
                                break;
                            case 3:
                                groupName = "Secretary";
                                break;
                            case 4:
                                groupName = "Assistant";
                                break;
                            case 5:
                                groupName = "Guardian";
                                break;
                            case 6:
                                groupName = "Admin";
                                break;
                            default:
                                break;
                        }

                        GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);
                        group.Members.Add(user);
                        group.Save();

                        return true;
                    }
                }
                catch (Exception)
                {
                    return new { result = false, info = "Não foi possível adicionar um role ao utilizador." };
                }
            }
        }

        public static Object RemoveRole(string SamAccountName, int Group)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.1.124", "CQPROJ\\Administrator", "PASS.queiroz2017"))
            {
                try
                {
                    using (var user = UserPrincipal.FindByIdentity(context, SamAccountName))
                    {
                        string groupName = "";
                        switch (Group)
                        {
                            case 1:
                                groupName = "Student";
                                break;
                            case 2:
                                groupName = "Teacher";
                                break;
                            case 3:
                                groupName = "Secretary";
                                break;
                            case 4:
                                groupName = "Assistant";
                                break;
                            case 5:
                                groupName = "Guardian";
                                break;
                            case 6:
                                groupName = "Admin";
                                break;
                            default:
                                break;
                        }

                        GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);
                        group.Members.Remove(user);
                        group.Save();

                        return true;
                    }
                }
                catch (Exception)
                {
                    return new { result = false, info = "Não foi possível remover o role do utilizador." };
                }
            }
        }

        public static Object DisableOrEnableUser(string SamAccountName)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "192.168.1.124", "CQPROJ\\Administrator", "PASS.queiroz2017"))
            {
                try
                {
                    using (var user = UserPrincipal.FindByIdentity(context, SamAccountName))
                    {
                        if (user.Enabled == true)
                        {
                            user.Enabled = false;
                        }
                        else
                        {
                            user.Enabled = true;
                        }

                        return true;
                    }
                }
                catch (Exception)
                {
                    return new { result = false, info = "Não foi possível ativar ou desativar o utilizador." };
                }
            }
        }
    }
}
