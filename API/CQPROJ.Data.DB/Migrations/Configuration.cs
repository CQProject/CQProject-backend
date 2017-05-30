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
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSecretaries]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblActions]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblClasses]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblClassStudents]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblDocuments]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblEvaluations]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblEvaluationStudents]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblGuardians]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblLessons]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblLessonStudents]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblNotifications]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblPictures]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblRoles]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSchAssistants]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSchedules]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSchoolLayout]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSecretaries]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblStudents]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblTasks]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblTeachers]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblUserRoles]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblUsers]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblValidations]");


            var users = new List<TblUsers>
            {
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student1",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student2",Password="123qwe", Function="Student",IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary1",Password="123qwe", Function = "Secretary", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary2",Password="123qwe", Function = "Secretary", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian1",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian2",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant1",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant2",Password="123qwe", Function = "Assistant", IsActive=true }

            };
            users.ForEach(uu => context.TblUsers.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            //***************************************** SECRETARIES ***************************************************************
            var secretary = new List<TblSecretaries>
            {
                new TblSecretaries {Address="secretary1@ipt.pt", FiscalNumber="123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "123456789", Photo = "asda", UserFK=users[2].ID, StartWorkTime=new DateTime(2017, 1, 1, 8, 0, 0), EndWorkTime=new DateTime(2017, 1, 1, 18, 30, 0) },
                new TblSecretaries {Address="secretary2@ipt.pt",FiscalNumber = "123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "092139102", Photo = "asdasda" ,UserFK=users[3].ID, StartWorkTime=new DateTime(2017, 1, 1, 7, 30, 0), EndWorkTime=new DateTime(2017, 1, 1, 18, 0, 0)}
            };
            secretary.ForEach(se => context.TblSecretaries.AddOrUpdate(sec => sec.ID, se));
            context.SaveChanges();

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
        }
    }
}
