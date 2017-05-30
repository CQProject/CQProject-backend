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
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Teacher2",Password="123qwe", Function = "Teacher", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Teacher3",Password="123qwe", Function = "Teacher", IsActive=true },
                new TblUsers {CreatedDate=DateTime.Now,Email="mandostestes@ipt.pt",Name="Teacher4",Password="123qwe", Function = "Teacher", IsActive=true }
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
                new TblTeachers {Address = "Rua dos heróis Nº56 Troia 2345-543 Atlantida", FiscalNumber="123456789", CitizenCard="123456789", Curriculum="Curriculum1", PhoneNumber = "123456789", Photo = "exemple.png", UserFK=users[30].ID},
                new TblTeachers {Address = "Rua alecrim Nº59 Romar 2345-543 Flotra", CitizenCard="123456789", Curriculum="Curriculum2", PhoneNumber = "092139102", Photo = "exemple.png" ,UserFK=users[31].ID},
                new TblTeachers {Address = "Rua dos heróis Nº59 Troia 2345-543 Atlantida", CitizenCard="123456789", Curriculum="Curriculum3", PhoneNumber = "092139102", Photo = "exemple.png" ,UserFK=users[32].ID},
                new TblTeachers {Address = "Rua alecrim Nº59 Romar 2345-543 Flotra", CitizenCard="123456789", Curriculum="Curriculum4", PhoneNumber = "092139102", Photo = "exemple.png" ,UserFK=users[33].ID}
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

            var schedules = new List<TblSchedules>
            {
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Lingua Portuguesa", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Educação Física", TeacherFK=teachers[2].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Lingua Portuguesa", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Música", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[2].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Inglês", TeacherFK=teachers[3].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Língua Portuguesa", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Inglês", TeacherFK=teachers[3].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Educação Física", TeacherFK=teachers[2].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Lingua Portuguesa", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Fri"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Fri"},
                new TblSchedules{Subject="Música", TeacherFK=teachers[0].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Fri"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[2].ID, ClassFK=classes[0].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Fri"},

                new TblSchedules{Subject="Matemática", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Lingua Portuguesa", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Mon"},
                new TblSchedules{Subject="Educação Física", TeacherFK=teachers[2].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Mon" },
                new TblSchedules{Subject="Lingua Portuguesa", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Música", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[2].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Tue"},
                new TblSchedules{Subject="Inglês", TeacherFK=teachers[3].ID, ClassFK=classes[1].ID,StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Wed" },
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID,  StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Língua Portuguesa", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Wed"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID,  StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Inglês", TeacherFK=teachers[3].ID, ClassFK=classes[1].ID,  StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Educação Física", TeacherFK=teachers[2].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Thu"},
                new TblSchedules{Subject="Lingua Portuguesa", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,9,0,0), EndingTime=new DateTime(2017,1,1,10,30,0),DayOfTheWeek="Fri"},
                new TblSchedules{Subject="Matemática", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID, StartingTime=new DateTime(2017,1,1,10,30,0), EndingTime=new DateTime(2017,1,1,12,0,0),DayOfTheWeek="Fri"},
                new TblSchedules{Subject="Música", TeacherFK=teachers[1].ID, ClassFK=classes[1].ID,  StartingTime=new DateTime(2017,1,1,15,0,0), EndingTime=new DateTime(2017,1,1,16,0,0),DayOfTheWeek="Fri"},
                new TblSchedules{Subject="Ciências da Natureza", TeacherFK=teachers[2].ID, ClassFK=classes[1].ID,StartingTime=new DateTime(2017,1,1,13,30,0), EndingTime=new DateTime(2017,1,1,15,0,0),DayOfTheWeek="Fri"},
            };
            schedules.ForEach(sche => context.TblSchedules.AddOrUpdate(sch => sch.ID, sche));
            context.SaveChanges();

            var evaluations = new List<TblEvaluations>
            {
                new TblEvaluations{EvaluationDate= new DateTime(2017, 9, 26), Purport="Somas e Subtrações", ScheduleFK=schedules[5].ID},
                new TblEvaluations{EvaluationDate= new DateTime(2017, 9, 29), Purport="Alfabeto", ScheduleFK=schedules[16].ID},
                new TblEvaluations{EvaluationDate= new DateTime(2017, 9, 25), Purport="Somas e Subtrações", ScheduleFK=schedules[21].ID},
                new TblEvaluations{EvaluationDate= new DateTime(2017, 9, 27), Purport="Alfabeto", ScheduleFK=schedules[29].ID}
            };
            evaluations.ForEach(eva => context.TblEvaluations.AddOrUpdate(eval => eval.ID, eva));
            context.SaveChanges();

            var evalStudents = new List<TblEvaluationStudents>
            {
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[0].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[1].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[2].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[3].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[4].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[5].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[0].ID, StudentFK=students[6].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[0].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[1].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[2].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[3].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[4].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[5].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[1].ID, StudentFK=students[6].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[7].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[8].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[9].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[10].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[11].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[12].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[2].ID, StudentFK=students[13].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[7].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[8].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[9].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[10].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[11].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[12].ID},
                new TblEvaluationStudents{EvaluationFK=evaluations[3].ID, StudentFK=students[13].ID}
            };
            evalStudents.ForEach(eva => context.TblEvaluationStudents.AddOrUpdate(eval => eval.EvaluationFK, eva));
            context.SaveChanges();

            var lessons = new List<TblLessons>
            {
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[1].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[2].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[3].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[4].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[5].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[6].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[7].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[8].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[9].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[10].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[11].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[12].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[13].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[14].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[15].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[16].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[17].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[18].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[19].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[20].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[21].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[22].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[23].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[24].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[25].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[26].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[27].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[28].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[29].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[30].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[31].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[32].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[33].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[34].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[35].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[36].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[37].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[38].ID, Day=DateTime.Now},
                new TblLessons{Summary="Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário Um Sumário ", Observations="Uma Observação Uma Observação Uma Observação Uma Observação ", Homework="Algum Trabalho de casa Algum Trabalho de casa ", ScheduleFK=schedules[39].ID, Day=DateTime.Now},
            };
            lessons.ForEach(les => context.TblLessons.AddOrUpdate(less => less.ID, les));
            context.SaveChanges();

            var lessStudent = new List<TblLessonStudents>();
            foreach(var lesson in lessons.Take(20))
            {
                for(int i = 0; i < 7; i++)
                {
                    lessStudent.Add(new TblLessonStudents {
                        Behavior = (5 % (i+1)) + 1,
                        LessonFK =lesson.ID,
                        StudentFK=students[i].ID,
                        Material=true,
                        Presence=true
                    });
                }
            }
            foreach (var lesson in lessons.Where(x=>x.ID>6))
            {
                for (int i = 7; i < students.Count; i++)
                {
                    lessStudent.Add(new TblLessonStudents
                    {
                        Behavior = (5 % i)+1,
                        LessonFK = lesson.ID,
                        StudentFK = students[i].ID,
                        Material = true,
                        Presence = true
                    });
                }
            }
            lessStudent.ForEach(les => context.TblLessonStudents.AddOrUpdate(less => less.StudentFK, les));
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
                new TblActions { UserFK = users[32].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[29].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[33].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[30].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[31].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[21].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[22].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[33].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[32].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[24].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[25].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[1].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[33].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[4].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[5].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[6].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[32].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[8].ID, Description="An Action exemple", Hour = DateTime.Now},
                new TblActions { UserFK = users[9].ID, Description="An Action exemple", Hour = DateTime.Now},
            };
            actions.ForEach(aa => context.TblActions.AddOrUpdate(a => a.ID, aa));
            context.SaveChanges();
            
        }
    }
    
}
