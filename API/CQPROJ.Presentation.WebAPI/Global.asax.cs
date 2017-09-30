using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace CQPROJ.Presentation.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Startup();
        }

        private void Startup()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContextModel>());
            DBContextModel context = new DBContextModel();


            TblUsers admin = new TblUsers
            {
                Email = "admin@a.a",
                IsActive = true,
                Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==",
                RegisterDate = DateTime.Now
            };
            if (!context.TblUsers.Any(x => x.Email == admin.Email))
            {
                context.TblUsers.Add(admin);
                context.SaveChanges();
            }

            String[] roles = { "admin", "student", "teacher", "secretary", "assistant", "guardian" };
            Array.ForEach(roles, role =>
            {
                if (!context.TblRoles.Any(x => x.Name == role))
                {
                    var newRole = new TblRoles { Name = role };
                    context.TblRoles.Add(newRole);
                    context.SaveChanges();
                    if (role == "admin")
                    {
                        context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = admin.ID });
                        context.SaveChanges();
                    }
                }
            });
        }
    }
}
