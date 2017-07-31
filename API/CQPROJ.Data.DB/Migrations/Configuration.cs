namespace CQPROJ.Data.DB.Migrations
{
    using CQPROJ.Data.DB.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CQPROJ.Data.DB.Models.DBContextModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CQPROJ.Data.DB.Models.DBContextModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roles = new List<TblRoles>{
                new TblRoles { ID=1, Name="student"},
                new TblRoles { ID=2, Name="teacher"},
                new TblRoles { ID=3,Name="secretary"},
                new TblRoles { ID=4,Name="assistant"},
                new TblRoles { ID=5,Name="guardian"},
                new TblRoles { ID=6,Name="admin"},
            };
            roles.ForEach(rr => context.TblRoles.AddOrUpdate(r => r.ID, rr));
            context.SaveChanges();
        }
    }
}
