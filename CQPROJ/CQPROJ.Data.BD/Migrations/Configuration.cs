namespace CQPROJ.Data.BD.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CQPROJ.Data.BD.Models.ModelsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CQPROJ.Data.BD.Models.ModelsDbContext context)
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
            var users = new List<TblUsers>
            {
                new TblUsers {ID=1,CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student1",Password="123qwe" },
                new TblUsers {ID=1,CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student2",Password="123qwe" },
                new TblUsers {ID=1,CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary1",Password="123qwe" },
                new TblUsers {ID=1,CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary2",Password="123qwe" }
            };
            users.ForEach(uu => context.TblUsers.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            var students = new List<TblStudents>
            {
                new TblStudents {ID=1,DataOfBirth=DateTime.Now,Photo="Kappa",UserFK=1 },
                new TblStudents {ID=2,DataOfBirth=DateTime.Now,Photo="Pride",UserFK=2 }
            };
            students.ForEach(ss => context.TblStudents.AddOrUpdate(s => s.ID, ss));
            context.SaveChanges();

            var schools = new List<TblSchoolLayout>
            {
                new TblSchoolLayout {ID=1, Acronym="Escola Teste", Logo="AnyLogo", Name="NameSchool", ProfilePicture="ProfileTeste", OpeningTime=DateTime.Now, ClosingTime=DateTime.Now},
                new TblSchoolLayout {ID=2, Acronym="Escola Teste2", Logo="AnyLogo2", Name="NameSchool2", ProfilePicture="ProfileTeste2", OpeningTime=DateTime.Now, ClosingTime=DateTime.Now}
            };
            schools.ForEach(dd => context.TblSchoolLayout.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();

        }
    }
}
