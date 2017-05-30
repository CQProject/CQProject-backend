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
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student2",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student3",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student4",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student5",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student6",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student7",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student8",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student9",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student10",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student11",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student12",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student13",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Student14",Password="123qwe", Function="Student", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary1",Password="123qwe", Function = "Secretary", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Secretary2",Password="123qwe", Function = "Secretary", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian1",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian2",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian3",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian4",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian5",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian6",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian7",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Guardian8",Password="123qwe", Function = "Guardian", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant1",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant2",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant3",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant4",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant5",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Assistant6",Password="123qwe", Function = "Assistant", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Teacher1",Password="123qwe", Function = "Teacher", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Teacher2",Password="123qwe", Function = "Teacher", IsActive=true }

            };
            users.ForEach(uu => context.TblUsers.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            //***************************************** SECRETARIES ***************************************************************
            var secretaries = new List<TblSecretaries>
            {
                new TblSecretaries {Address="secretary1@ipt.pt", FiscalNumber="123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "123456789", Photo = "exemple.png", UserFK=users[14].ID, StartWorkTime=new DateTime(2017, 1, 1, 8, 0, 0), EndWorkTime=new DateTime(2017, 1, 1, 18, 30, 0) },
                new TblSecretaries {Address="secretary2@ipt.pt",FiscalNumber = "123456789", CitizenCard="123456789", Curriculum="nane", PhoneNumber = "092139102", Photo = "exemple.png" ,UserFK=users[15].ID, StartWorkTime=new DateTime(2017, 1, 1, 7, 30, 0), EndWorkTime=new DateTime(2017, 1, 1, 18, 0, 0)}
            };
            secretaries.ForEach(se => context.TblSecretaries.AddOrUpdate(sec => sec.ID, se));
            context.SaveChanges();

            var guardians = new List<TblGuardians>
            {
                new TblGuardians { Address = "Rua das couves Nº56 Alberga 3245-543 Maior", CitizenCard="785412369", FiscalNumber="145698723", NotContactHours="10:00-17:00", PhoneNumber="123654789", UserFK = users[16].ID},
                new TblGuardians { Address = "Rua das Alfaces Nº56 Alberga 3245-543 Menor", CitizenCard="569874123", FiscalNumber="965874123", NotContactHours="11:00-15:00", PhoneNumber="147852369", UserFK = users[17].ID},
                new TblGuardians { Address = "Rua das couves Nº56 Alberga 3245-543 Maior", CitizenCard="785412369", FiscalNumber="145698723", NotContactHours="10:00-17:00", PhoneNumber="123654789", UserFK = users[18].ID},
                new TblGuardians { Address = "Rua das Alfaces Nº56 Alberga 3245-543 Menor", CitizenCard="569874123", FiscalNumber="965874123", NotContactHours="11:00-15:00", PhoneNumber="147852369", UserFK = users[19].ID},
                new TblGuardians { Address = "Rua das couves Nº56 Alberga 3245-543 Maior", CitizenCard="785412369", FiscalNumber="145698723", NotContactHours="10:00-17:00", PhoneNumber="123654789", UserFK = users[20].ID},
                new TblGuardians { Address = "Rua das Alfaces Nº56 Alberga 3245-543 Menor", CitizenCard="569874123", FiscalNumber="965874123", NotContactHours="11:00-15:00", PhoneNumber="147852369", UserFK = users[21].ID},
                new TblGuardians { Address = "Rua das couves Nº56 Alberga 3245-543 Maior", CitizenCard="785412369", FiscalNumber="145698723", NotContactHours="10:00-17:00", PhoneNumber="123654789", UserFK = users[22].ID},
                new TblGuardians { Address = "Rua das Alfaces Nº56 Alberga 3245-543 Menor", CitizenCard="569874123", FiscalNumber="965874123", NotContactHours="11:00-15:00", PhoneNumber="147852369", UserFK = users[23].ID}
            };
            guardians.ForEach(gg => context.TblGuardians.AddOrUpdate(g => g.ID, gg));
            context.SaveChanges();

            var students = new List<TblStudents>
            {
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[0].ID , GuardianFK=guardians[0].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[1].ID , GuardianFK=guardians[0].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[2].ID , GuardianFK=guardians[1].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[3].ID , GuardianFK=guardians[2].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[4].ID , GuardianFK=guardians[3].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[5].ID , GuardianFK=guardians[4].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[6].ID , GuardianFK=guardians[4].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[7].ID , GuardianFK=guardians[5].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[8].ID , GuardianFK=guardians[6].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[9].ID , GuardianFK=guardians[7].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[10].ID , GuardianFK=guardians[7].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[11].ID , GuardianFK=guardians[2].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[12].ID , GuardianFK=guardians[3].ID},
                new TblStudents {DataOfBirth=DateTime.Now,Photo="exemple.png",UserFK=users[13].ID , GuardianFK=guardians[0].ID}
            };
            students.ForEach(ss => context.TblStudents.AddOrUpdate(s => s.ID, ss));
            context.SaveChanges();

            var assistants = new List<TblSchAssistants>
            {
                new TblSchAssistants { Address = "Rua das alfaces Nº56 Espargo 2345-543 Quintelho", CitizenCard="123456789", Curriculum = "Curriculum1", FiscalNumber="123456789", PhoneNumber = "123456789", Photo="exemple.png", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[24].ID},
                new TblSchAssistants { Address = "Rua dos torresmos Nº56 Romã 2398-213 Testo", CitizenCard="123456789", Curriculum = "Curriculum2", FiscalNumber="123456789", PhoneNumber = "123456789", Photo="exemple.png", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[25].ID},
                new TblSchAssistants { Address = "Rua das alfaces Nº56 Espargo 2345-543 Quintelho", CitizenCard="123456789", Curriculum = "Curriculum3", FiscalNumber="123456789", PhoneNumber = "123456789", Photo="exemple.png", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[26].ID},
                new TblSchAssistants { Address = "Rua dos torresmos Nº56 Romã 2398-213 Testo", CitizenCard="123456789", Curriculum = "Curriculum4", FiscalNumber="123456789", PhoneNumber = "123456789", Photo="exemple.png", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[27].ID},
                new TblSchAssistants { Address = "Rua das alfaces Nº56 Espargo 2345-543 Quintelho", CitizenCard="123456789", Curriculum = "Curriculum5", FiscalNumber="123456789", PhoneNumber = "123456789", Photo="exemple.png", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[28].ID},
                new TblSchAssistants { Address = "Rua dos torresmos Nº56 Romã 2398-213 Testo", CitizenCard="123456789", Curriculum = "Curriculum6", FiscalNumber="123456789", PhoneNumber = "123456789", Photo="exemple.png", StartWorkTime = DateTime.Now, EndWorkTime = DateTime.Now.AddHours(8.0), UserFK = users[29].ID},
            };
            assistants.ForEach(aa => context.TblSchAssistants.AddOrUpdate(a => a.ID, aa));
            context.SaveChanges();

            var teachers = new List<TblTeachers>
            {
                new TblTeachers {Address="teacher1@ipt.pt", FiscalNumber="123456789", CitizenCard="123456789", Curriculum="Curriculum1", PhoneNumber = "123456789", Photo = "exemple.png", UserFK=users[30].ID},
                new TblTeachers {Address="teacher2@ipt.pt",FiscalNumber = "123456789", CitizenCard="123456789", Curriculum="Curriculum2", PhoneNumber = "092139102", Photo = "exemple.png" ,UserFK=users[31].ID}
            };
            teachers.ForEach(te => context.TblTeachers.AddOrUpdate(tea => tea.ID, te));
            context.SaveChanges();

            var classes = new List<TblClasses>
            {
                new TblClasses{SchoolYear="2017", Year="1º", ClassDesc="A"},
                new TblClasses{SchoolYear="2017", Year="1º", ClassDesc="B"},
            };
            classes.ForEach(cl => context.TblClasses.AddOrUpdate(cla => cla.ID, cl));
            context.SaveChanges();

            var classStudent = new List<TblClassStudents>
            {
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[0].ID},
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[1].ID},
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[2].ID},
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[3].ID},
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[4].ID},
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[5].ID},
                new TblClassStudents{ClassFK=classes[0].ID, StudentFK=students[6].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[7].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[8].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[9].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[10].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[11].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[12].ID},
                new TblClassStudents{ClassFK=classes[1].ID, StudentFK=students[13].ID}
            };
            classStudent.ForEach(cls => context.TblClassStudents.AddOrUpdate(claS => claS.ClassFK, cls));
            context.SaveChanges();

            var documents = new List<TblDocuments>
            {
                new TblDocuments{Document="exemple.pdf", IsVisible=true, SubmitedIn=DateTime.Now, ClassFK=classes[0].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=false, SubmitedIn=DateTime.Now, ClassFK=classes[0].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=false, SubmitedIn=DateTime.Now, ClassFK=classes[0].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=true, SubmitedIn=DateTime.Now, ClassFK=classes[0].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=true, SubmitedIn=DateTime.Now, ClassFK=classes[0].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=true, SubmitedIn=DateTime.Now, ClassFK=classes[0].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=false, SubmitedIn=DateTime.Now, ClassFK=classes[1].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=false, SubmitedIn=DateTime.Now, ClassFK=classes[1].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=true, SubmitedIn=DateTime.Now, ClassFK=classes[1].ID},
                new TblDocuments{Document="exemple.pdf", IsVisible=true, SubmitedIn=DateTime.Now, ClassFK=classes[1].ID},
            };
            documents.ForEach(doc => context.TblDocuments.AddOrUpdate(docs => docs.ID, doc));
            context.SaveChanges();
            

            var actions = new List<TblActions>
            {
                new TblActions { UserFK = users[0].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[1].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[2].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[3].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[7].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[8].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[9].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[10].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[11].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[12].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[13].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[14].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[15].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[16].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[17].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[18].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[19].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[20].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[21].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[22].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[23].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[24].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[25].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[20].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[21].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[22].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[23].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[14].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[24].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[25].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[1].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[3].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[7].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[8].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[9].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[0].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[19].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[20].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[21].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[22].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[23].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[24].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[25].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[20].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[21].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[22].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[23].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[14].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[24].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[25].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[1].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[3].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[7].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[8].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[9].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[0].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[3].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[7].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[8].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[9].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[10].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[11].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[12].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[13].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[14].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[15].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[16].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[17].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[18].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[3].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[7].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[8].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[9].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[10].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[11].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[12].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[13].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[14].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[15].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[16].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[17].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[18].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[26].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[27].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[28].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[29].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[26].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[27].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[28].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[29].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[26].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[27].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[28].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[29].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[26].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[27].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[28].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[29].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now}
            };
            actions.ForEach(aa => context.TblActions.AddOrUpdate(a => a.ID, aa));
            context.SaveChanges();


        }
    }
}
