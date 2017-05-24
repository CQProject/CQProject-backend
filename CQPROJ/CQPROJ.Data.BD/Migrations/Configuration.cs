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
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student1",Password="123qwe" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student2",Password="123qwe" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary1",Password="123qwe" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary2",Password="123qwe" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian1",Password="123qwe" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian2",Password="123qwe" }

            };
            users.ForEach(uu => context.TblUsers.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            var secretary = new List<TblSecretaries>
            {
                new TblSecretaries {Address="secretary1@ipt.pt", FiscalNumber="123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "123456789", Photo =
                "asda", UserFK=users[2].ID},
                new TblSecretaries {Address="secretary2@ipt.pt",FiscalNumber = "123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "092139102", Photo = "asdasda" ,UserFK=users[3].ID}
            };
            secretary.ForEach(se => context.TblSecretaries.AddOrUpdate(sec => sec.Id, se));
            context.SaveChanges();

            var guardians = new List<TblGuardians>
            {
                new TblGuardians { Address = "asdasd", CitizenCard="jasidasd", FiscalNumber="jasdjasd", NotContactHours="asdasd", PhoneNumber="jasdjasd",
                StartWorkTime=DateTime.Now, UserFK = users[4].ID},
                new TblGuardians { Address = "asdasd2", CitizenCard="jasidasd", FiscalNumber="jasdjasd", NotContactHours="asdasd", PhoneNumber="jasdjasd",
                StartWorkTime=DateTime.Now, UserFK = users[5].ID}
            };
            guardians.ForEach(gg => context.TblGuardians.AddOrUpdate(g => g.Id, gg));
            context.SaveChanges();

            var students = new List<TblStudents>
            {
                new TblStudents {DataOfBirth=DateTime.Now,Photo="Kappa",UserFK=users[0].ID },
                new TblStudents {DataOfBirth=DateTime.Now,Photo="Pride",UserFK=users[1].ID }
            };
            students.ForEach(ss => context.TblStudents.AddOrUpdate(s => s.ID, ss));
            context.SaveChanges();

            var schools = new List<TblSchoolLayout>
            {
                new TblSchoolLayout {Acronym="Escola Teste", Logo="AnyLogo", Name="NameSchool", ProfilePicture="ProfileTeste", OpeningTime=DateTime.Now, ClosingTime=DateTime.Now}
            };
            schools.ForEach(dd => context.TblSchoolLayout.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();
            
        }
    }
}
