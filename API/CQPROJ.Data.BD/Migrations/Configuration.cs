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
            
            //***************************************** USERS ***************************************************************
            var users = new List<TblUsers>
            {
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student1",Password="123qwe", Function="Student" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student2",Password="123qwe", Function="Student" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary1",Password="123qwe", Function = "Secretary" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary2",Password="123qwe", Function = "Secretary" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian1",Password="123qwe", Function = "Guardian" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian2",Password="123qwe", Function = "Guardian" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant1",Password="123qwe", Function = "Assistant" },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant2",Password="123qwe", Function = "Assistant" }

            };
            users.ForEach(uu => context.TblUsers.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            //***************************************** STUDENTS ***************************************************************
            var students = new List<TblStudents>
            {
                new TblStudents {DataOfBirth=DateTime.Now,Photo="Kappa",UserFK=users[0].ID },
                new TblStudents {DataOfBirth=DateTime.Now,Photo="Pride",UserFK=users[1].ID }
            };
            students.ForEach(ss => context.TblStudents.AddOrUpdate(s => s.ID, ss));
            context.SaveChanges();

            //***************************************** SECRETARIES ***************************************************************
            var secretary = new List<TblSecretaries>
            {
                new TblSecretaries {Address="secretary1@ipt.pt", FiscalNumber="123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "123456789", Photo =
                "asda", UserFK=users[2].ID},
                new TblSecretaries {Address="secretary2@ipt.pt",FiscalNumber = "123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "092139102", Photo = "asdasda" ,UserFK=users[3].ID}
            };
            secretary.ForEach(se => context.TblSecretaries.AddOrUpdate(sec => sec.Id, se));
            context.SaveChanges();

            //***************************************** GUARDIANS ***************************************************************
            var guardians = new List<TblGuardians>
            {
                new TblGuardians { Address = "asdasd", CitizenCard="jasidasd", FiscalNumber="jasdjasd", NotContactHours="asdasd", PhoneNumber="jasdjasd",
                StartWorkTime=DateTime.Now, UserFK = users[4].ID},
                new TblGuardians { Address = "asdasd2", CitizenCard="jasidasd", FiscalNumber="jasdjasd", NotContactHours="asdasd", PhoneNumber="jasdjasd",
                StartWorkTime=DateTime.Now, UserFK = users[5].ID}
            };
            guardians.ForEach(gg => context.TblGuardians.AddOrUpdate(g => g.Id, gg));
            context.SaveChanges();

            //***************************************** SCHOOL ASSISTANTS ***************************************************************
            var assistant = new List<TblSchAssistants>
            {
                new TblSchAssistants { Address="Address1", CitizenCard="123456789", Curriculum = "Curriculum1", FiscalNumber="123456789", PhoneNumber = "123456789",
                Photo="Photo", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[6].ID},
                new TblSchAssistants { Address="Address2", CitizenCard="123456789", Curriculum = "Curriculum2", FiscalNumber="123456789", PhoneNumber = "123456789",
                Photo="Photo2", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[7].ID},
            };
            assistant.ForEach(aa => context.TblSchAssistants.AddOrUpdate(a => a.Id, aa));
            context.SaveChanges();

            //***************************************** SCHOOL LAYOUTS ***************************************************************
            var schools = new List<TblSchoolLayout>
            {
                new TblSchoolLayout {Acronym="Escola Teste", Logo="AnyLogo", Name="NameSchool", ProfilePicture="ProfileTeste", OpeningTime=DateTime.Now, ClosingTime=DateTime.Now}
            };
            schools.ForEach(dd => context.TblSchoolLayout.AddOrUpdate(d => d.ID, dd));
            context.SaveChanges();

            //***************************************** ACTIONS ***************************************************************
            var actions = new List<TblActions>
            {
                new TblActions { UserFK = users[0].ID, Description="First Action", Hour = DateTime.Now},
                new TblActions { UserFK = users[1].ID, Description="First Action", Hour = DateTime.Now},
                new TblActions { UserFK = users[2].ID, Description="Third Action", Hour = DateTime.Now},
                new TblActions { UserFK = users[3].ID, Description="Forth Action1", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="Fifth Action", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="Sixth Action", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="seventh Action", Hour = DateTime.Now}
            };
            actions.ForEach(aa => context.TblActions.AddOrUpdate(a => a.ID, aa));
            context.SaveChanges();

            //***************************************** CLASSES ***************************************************************
            var classes = new List<TblClasses>
            {
                new TblClasses { Year="1º", ClassDesc="A", SchoolYear="2016/17" },
                new TblClasses { Year="1º", ClassDesc="B", SchoolYear="2016/17" },
                new TblClasses { Year="2º", ClassDesc="A", SchoolYear="2016/17" },
                new TblClasses { Year="3º", ClassDesc="A", SchoolYear="2016/17" },
                new TblClasses { Year="4º", ClassDesc="A", SchoolYear="2016/17" }
            };
            classes.ForEach(cc => context.TblClasses.AddOrUpdate(c => c.ID, cc));
            context.SaveChanges();
        }
    }
}
