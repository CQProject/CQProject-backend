using CQPROJ.Data.DB.Models;
using Microsoft.Owin;
using Owin;
using System;
using System.Data.Entity;
using System.Linq;

[assembly: OwinStartup(typeof(CQPROJ.Presentation.WebAPI.Startup))]

namespace CQPROJ.Presentation.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
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

            String[] roles = { "student", "teacher", "secretary", "assistant", "guardian", "admin" };
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
