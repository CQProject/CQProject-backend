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
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblActions]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblClasses]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblClassUsers]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblDocuments]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblDones]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblEvaluations]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblEvaluationStudents]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblFloors]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblLessons]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblLessonStudents]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblParenting]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblRecords]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblRoles]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblRooms]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSchedules]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSchools]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSensors]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblSubjects]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblTasks]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblTimes]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblUserRoles]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblUsers]");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TblValidations]");

            TblUsers admin = new TblUsers
            {
                Email = "admin@a.a",
                IsActive = true,
                Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==",
                RegisterDate = DateTime.Now,
                Name = "Administrador",
            };
            if (!context.TblUsers.Any(x => x.Email == admin.Email))
            {
                context.TblUsers.Add(admin);
                context.SaveChanges();
            }
            
            List<TblUsers> students = new List<TblUsers>()
            {
                new TblUsers{ Name="Diogo Mendes",      Email="dmendes@a.a",    Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.dmendes.jpg",       IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Ricardo António",   Email="ricardma@a.a",   Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.ricardma.jpg",      IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="David Bernardo",    Email="ravageiro@a.a",  Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.ravageiro.jpg",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="André Santos",      Email="asantos@a.a",    Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.asantos.jpg",       IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Henrique Bernado",  Email="hbernardo@a.a",  Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.hbernardo.jpg",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Pedro Vitorino",    Email="pedrov@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.pedrov.jpg",        IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Miguel Silva",      Email="msilva@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.msilva.jpg",        IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Pedro Tapadas",     Email="pedrot@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.pedrot.jpg",        IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Pedro Nunes",       Email="pedron@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.pedron.jpg",        IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="João Bandarra",     Email="joaob@a.a",      Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.joaob.jpg",         IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Hernâni Diniz",     Email="hdiniz@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.hdiniz.jpg",        IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Claudio Velez",     Email="cvelez@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.cvelez.jpg",        IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Rui Barcelos",      Email="ruib@a.a",       Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.ruib.jpg",          IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Rafael Escudeiro",  Email="rafaele@a.a",    Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.rafaele.jpg",       IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="João Canoso",       Email="joaoc@a.a",      Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.joaoc.jpg",         IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1994,1996), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
            };
            students.ForEach(x => context.TblUsers.AddOrUpdate(x));
            context.SaveChanges();
            
            List<TblUsers> teachers = new List<TblUsers>()
            {
                new TblUsers{ Name="Carlos Queiroz",    Email="cqueiroz@a.a",   Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.cqueiroz.jpg",  IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1991, new Random().Next(1,13), new Random().Next(1,28)), Function="Professor" },
                new TblUsers{ Name="Nuno Madeira",      Email="nunom@a.a",      Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.nunom.jpg",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Professor" },
                new TblUsers{ Name="Luís Oliveira",     Email="luiso@a.a",      Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.luiso.jpg",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Professor" },
                new TblUsers{ Name="Renato Panda",      Email="rpanda@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.rpanda.jpg",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Professor" },
                new TblUsers{ Name="Rui Silva",         Email="ruis@a.a",       Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.ruis.jpg",      IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1991, new Random().Next(1,13), new Random().Next(1,28)), Function="Professor" },
            };
            teachers.ForEach(x => context.TblUsers.AddOrUpdate(x));
            context.SaveChanges();

            List<TblUsers> secretary = new List<TblUsers>()
            {
                new TblUsers{ Name="Luís Vieira",       Email="lfilipe@a.a",    Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.lfilipe.jpg",   IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1991, new Random().Next(1,13), new Random().Next(1,28)), Function="Secretário" },
                new TblUsers{ Name="Pinto da Costa",    Email="pintoc@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.pintoc.jpg",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Secretário" },
                new TblUsers{ Name="Bruno Carvalho",    Email="brunoc@a.a",     Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.brunoc.jpeg",   IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Secretário" },
            };
            secretary.ForEach(x => context.TblUsers.AddOrUpdate(x));
            context.SaveChanges();

            List<TblUsers> assistants = new List<TblUsers>()
            {
                new TblUsers{ Name="Tatiane Zaqui", Email="tati@a.a",   Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.tati.jpg",      IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1991, new Random().Next(1,13), new Random().Next(1,28)), Function="Auxiliar de Educação" },
                new TblUsers{ Name="Anna Bullock",  Email="annab@a.a",  Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.annab.jpg",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Auxiliar de Educação" },
                new TblUsers{ Name="Elton John",    Email="eltonj@a.a", Photo="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.eltonj.jpg",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(1987, new Random().Next(1,13), new Random().Next(1,28)), Function="Auxiliar de Educação" },
            };
            assistants.ForEach(x => context.TblUsers.AddOrUpdate(x));
            context.SaveChanges();

            List<TblUsers> guardians = new List<TblUsers>()
            {
                new TblUsers{ Name="Maria Amélia",      Email="mariam@a.a",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="José António",      Email="josea@a.a",      IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Maria Josefa",      Email="mariaj@a.a",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Judite Andrade",    Email="juditea@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Antónia Bernado",   Email="antb@a.a",       IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Pedro Vitorino",    Email="pedrov2@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Carolina Silva",    Email="csilva@a.a",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Tapadas",    Email="josefat@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Nunes",      Email="josefan@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Bandarra",   Email="josefab@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Diniz",      Email="josefad@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Velez",      Email="josefav@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Barcelos",   Email="josefb@a.a",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Escudeiro",  Email="josefae@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="José António",      Email="josea@a.a",      IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Maria Josefa",      Email="mariaj@a.a",     IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
                new TblUsers{ Name="Josefa Canoso",     Email="josefac@a.a",    IsActive = true, Password = "AA+T6brv4/CM1npsCj9pDnVogMH39sHiilT5w1yv8yX5XGoUIlNrPvhnU66qw1vpAg==", RegisterDate = DateTime.Now, Address="Rua da Alberga nº12 Tristana", PhoneNumber="789456123", CitizenCard="141258963", FiscalNumber="225698741", DateOfBirth=new DateTime(new Random().Next(1960,1975), new Random().Next(1,13), new Random().Next(1,28)), Function="Estudante" },
            };
            guardians.ForEach(x => context.TblUsers.AddOrUpdate(x));
            context.SaveChanges();
            
            String[] roles = { "student", "teacher", "secretary", "assistant", "guardian", "admin" };
            Array.ForEach(roles, role =>
            {
                if (!context.TblRoles.Any(x => x.Name == role))
                {
                    var newRole = new TblRoles { Name = role };
                    context.TblRoles.Add(newRole);
                    context.SaveChanges();

                    switch (role)
                    {
                        case "admin":
                            context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = admin.ID });
                            context.SaveChanges();
                            break;
                        case "student":
                            students.ForEach(user => context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = user.ID }));
                            context.SaveChanges();
                            break;
                        case "teacher":
                            teachers.ForEach(user => context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = user.ID }));
                            context.SaveChanges();
                            break;
                        case "secretary":
                            secretary.ForEach(user => context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = user.ID }));
                            context.SaveChanges();
                            break;
                        case "assistant":
                            assistants.ForEach(user => context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = user.ID }));
                            context.SaveChanges();
                            break;
                        case "guardian":
                            guardians.ForEach(user => context.TblUserRoles.Add(new TblUserRoles { RoleFK = newRole.ID, UserFK = user.ID }));
                            context.SaveChanges();
                            break;
                        default: break;
                    }
                }
            });
            
            for (int i = 0; i < guardians.Count(); i++)
            {
                if (i < students.Count())
                {
                    context.TblParenting.Add(new TblParenting { GuardianFK = guardians.Skip(i).First().ID, StudentFK = students.Skip(i).First().ID });
                    context.SaveChanges();
                }
                else
                {
                    context.TblParenting.Add(new TblParenting { GuardianFK = guardians.Skip(i).First().ID, StudentFK = students.Skip(i - students.Count()).First().ID });
                    context.SaveChanges();
                }
            }
            
            List<TblSchools> schools = new List<TblSchools>()
            {
                new TblSchools{Logo="f7da0f29-cc33-4d59-b40e-1d49429cdeb9.logoExemple.png", Acronym="CEM", Name="Centro Escolar de Morotitos", ProfilePicture="bcb4d218-f48a-40c5-991f-840bed27cb49.profileExemple.png", About="<p style=\"margin: 0px 0px 15px; padding: 0px; font-family: 'Open Sans', Arial, sans-serif; text-align: center;\"><strong>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lectus justo, dapibus eget euismod vitae, posuere eu nunc. Sed nec dui enim. Vestibulum consectetur turpis convallis ex lobortis, nec ornare massa suscipit. Nulla sodales dolor in nunc vulputate, nec condimentum elit elementum. Vestibulum nec ultrices turpis. </strong></p><ul><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Praesent accumsan finibus dignissim. Morbi accumsan aliquam ex quis blandit.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Vestibulum eleifend ante tortor, sit amet varius purus faucibus vel. Nulla facilisi.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Pellentesque faucibus diam nisl, quis fermentum ligula faucibus eu.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Maecenas non tristique est. Pellentesque pulvinar urna a semper efficitur.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Donec lobortis dolor justo, et dapibus enim iaculis ac.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\"></li></ul><p style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Duis rhoncus augue diam, ut fermentum enim pretium sit amet.</p><p style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Nam tempus quam eu lacus ultricies, a consequat lectus finibus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur consequat maximus laoreet. Morbi in mollis leo. Sed neque leo, porta sit amet nisi non, consectetur lacinia massa. Aliquam maximus arcu vel enim iaculis viverra. Aenean sagittis, sem vel egestas finibus, lectus eros venenatis diam, non sollicitudin felis quam id nisl.</p>"},
                new TblSchools{Logo="10bf90a6-6ee7-46a5-9f8e-3cba73ea417e.logo.png", Acronym="IPT", Name="Instituto Politécnico de Tomar", ProfilePicture="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.ipt.png", About="<p style=\"margin: 0px 0px 15px; padding: 0px; font-family: 'Open Sans', Arial, sans-serif; text-align: center;\"><strong>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lectus justo, dapibus eget euismod vitae, posuere eu nunc. Sed nec dui enim. Vestibulum consectetur turpis convallis ex lobortis, nec ornare massa suscipit. Nulla sodales dolor in nunc vulputate, nec condimentum elit elementum. Vestibulum nec ultrices turpis. </strong></p><ul><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Praesent accumsan finibus dignissim. Morbi accumsan aliquam ex quis blandit.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Vestibulum eleifend ante tortor, sit amet varius purus faucibus vel. Nulla facilisi.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Pellentesque faucibus diam nisl, quis fermentum ligula faucibus eu.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Maecenas non tristique est. Pellentesque pulvinar urna a semper efficitur.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Donec lobortis dolor justo, et dapibus enim iaculis ac.</li><li style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\"></li></ul><p style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Duis rhoncus augue diam, ut fermentum enim pretium sit amet.</p><p style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif;\">Nam tempus quam eu lacus ultricies, a consequat lectus finibus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur consequat maximus laoreet. Morbi in mollis leo. Sed neque leo, porta sit amet nisi non, consectetur lacinia massa. Aliquam maximus arcu vel enim iaculis viverra. Aenean sagittis, sem vel egestas finibus, lectus eros venenatis diam, non sollicitudin felis quam id nisl.</p>"},
            };
            schools.ForEach(x => context.TblSchools.AddOrUpdate(x));
            context.SaveChanges();

            List<TblFloors> floors = new List<TblFloors>()
            {
                new TblFloors{Image="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.plan0.jpg", Name="Piso 0", SchoolFK=schools.First().ID },
                new TblFloors{Image="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.plan1.png", Name="Piso 1", SchoolFK=schools.First().ID },
            };
            floors.ForEach(x => context.TblFloors.AddOrUpdate(x));
            context.SaveChanges();

            List<TblSensors> sensors = new List<TblSensors>()
            {
                new TblSensors{ Name="Sensor 1", RoomFK=1},
                new TblSensors{ Name="Sensor 2", RoomFK=1},
                new TblSensors{ Name="Sensor 3", RoomFK=2},
                new TblSensors{ Name="Sensor 4", RoomFK=3},
            };
            sensors.ForEach(x => context.TblSensors.AddOrUpdate(x));
            context.SaveChanges();
            
            List<TblRecords> records = new List<TblRecords>()
            {
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=1 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=2 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=3 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
                new TblRecords{ SensorFK=4 , Energy=new Random().Next(150, 400), Luminosity=new Random().Next(250, 600), Hour=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28), new Random().Next(7, 20), new Random().Next(1, 59), new Random().Next(1, 59)), Humidity=Math.Round(new Random().NextDouble(),3), Temperature=new Random().Next(5,30)},
            };
            records.ForEach(x => context.TblRecords.AddOrUpdate(x));
            context.SaveChanges();
            
            List<TblNotices> notices = new List<TblNotices>()
            {
                new TblNotices{ Title="Aulas de musica", Image="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.music.jpg", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ornare velit vitae vulputate placerat. Vestibulum non nunc nec odio tincidunt varius et quis odio. Integer scelerisque, massa ac aliquam venenatis, elit lorem euismod massa, sit amet lacinia nunc tellus sit amet orci. Fusce sed metus mauris. Nullam egestas eu sem vel luctus. Morbi mattis sollicitudin eros eu vestibulum. In volutpat, arcu et scelerisque facilisis, nibh odio commodo neque, vel interdum purus tortor a risus. ", CreatedDate=DateTime.Now, SchoolFK=1 },
                new TblNotices{ Title="Carnaval 2018", Image="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.carnival.jpg", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ornare velit vitae vulputate placerat. Vestibulum non nunc nec odio tincidunt varius et quis odio. Integer scelerisque, massa ac aliquam venenatis, elit lorem euismod massa, sit amet lacinia nunc tellus sit amet orci. Fusce sed metus mauris. Nullam egestas eu sem vel luctus. Morbi mattis sollicitudin eros eu vestibulum. In volutpat, arcu et scelerisque facilisis, nibh odio commodo neque, vel interdum purus tortor a risus. ", CreatedDate=DateTime.Now, SchoolFK=1 },
                new TblNotices{ Title="Visita ao museu do Picasso", Image="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.museu.jpg", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ornare velit vitae vulputate placerat. Vestibulum non nunc nec odio tincidunt varius et quis odio. Integer scelerisque, massa ac aliquam venenatis, elit lorem euismod massa, sit amet lacinia nunc tellus sit amet orci. Fusce sed metus mauris. Nullam egestas eu sem vel luctus. Morbi mattis sollicitudin eros eu vestibulum. In volutpat, arcu et scelerisque facilisis, nibh odio commodo neque, vel interdum purus tortor a risus. ", CreatedDate=DateTime.Now, SchoolFK=1 },
                new TblNotices{ Title="Encontro nacional de atletismo", Image="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.atletismo.jpg", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ornare velit vitae vulputate placerat. Vestibulum non nunc nec odio tincidunt varius et quis odio. Integer scelerisque, massa ac aliquam venenatis, elit lorem euismod massa, sit amet lacinia nunc tellus sit amet orci. Fusce sed metus mauris. Nullam egestas eu sem vel luctus. Morbi mattis sollicitudin eros eu vestibulum. In volutpat, arcu et scelerisque facilisis, nibh odio commodo neque, vel interdum purus tortor a risus. ", CreatedDate=DateTime.Now, SchoolFK=1 },
                new TblNotices{ Title="Semana do desporto", Image="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.swimming-lessons.jpg", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ornare velit vitae vulputate placerat. Vestibulum non nunc nec odio tincidunt varius et quis odio. Integer scelerisque, massa ac aliquam venenatis, elit lorem euismod massa, sit amet lacinia nunc tellus sit amet orci. Fusce sed metus mauris. Nullam egestas eu sem vel luctus. Morbi mattis sollicitudin eros eu vestibulum. In volutpat, arcu et scelerisque facilisis, nibh odio commodo neque, vel interdum purus tortor a risus. ", CreatedDate=DateTime.Now, SchoolFK=1 },
                new TblNotices{ Title="Visita de estudo ao aterro", Image="882b4871-f8ce-4d39-bdaa-8e59a736fa1a.visitaestudo.jpg", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ornare velit vitae vulputate placerat. Vestibulum non nunc nec odio tincidunt varius et quis odio. Integer scelerisque, massa ac aliquam venenatis, elit lorem euismod massa, sit amet lacinia nunc tellus sit amet orci. Fusce sed metus mauris. Nullam egestas eu sem vel luctus. Morbi mattis sollicitudin eros eu vestibulum. In volutpat, arcu et scelerisque facilisis, nibh odio commodo neque, vel interdum purus tortor a risus. ", CreatedDate=DateTime.Now, SchoolFK=1 },
            };
            notices.ForEach(x => context.TblNotices.AddOrUpdate(x));
            context.SaveChanges();

            List<TblClasses> classes = new List<TblClasses>()
            {
                new TblClasses{Year="1º" , ClassDesc="A" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="1º" , ClassDesc="B" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="1º" , ClassDesc="C" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="2º" , ClassDesc="A" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="2º" , ClassDesc="B" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="2º" , ClassDesc="C" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="3º" , ClassDesc="A" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="3º" , ClassDesc="B" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="3º" , ClassDesc="C" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="4º" , ClassDesc="A" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="4º" , ClassDesc="B" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
                new TblClasses{Year="4º" , ClassDesc="C" , SchoolFK=1, IsActive=true, SchoolYear="2016/2017"},
            };
            classes.ForEach(x => context.TblClasses.AddOrUpdate(x));
            context.SaveChanges();
            
            students.ForEach(student =>
            {
                context.TblClassUsers.AddOrUpdate(new TblClassUsers { UserFK = student.ID, ClassFK = 1 });
                context.SaveChanges();
            });

            teachers.ForEach(teacher =>
            {
                context.TblClassUsers.AddOrUpdate(new TblClassUsers { UserFK = teacher.ID, ClassFK = 1 });
                context.SaveChanges();
            });
            
            List<TblTimes> times = new List<TblTimes>()
            {
                new TblTimes{ Order=1, StartTime="09h00", EndTime="10h00", IsKindergarten=false, SchoolFK=schools.First().ID },
                new TblTimes{ Order=2, StartTime="10h10", EndTime="11h10", IsKindergarten=false, SchoolFK=schools.First().ID },
                new TblTimes{ Order=3, StartTime="11h30", EndTime="12h30", IsKindergarten=false, SchoolFK=schools.First().ID },
                new TblTimes{ Order=4, StartTime="14h00", EndTime="15h00", IsKindergarten=false, SchoolFK=schools.First().ID },
                new TblTimes{ Order=5, StartTime="15h10", EndTime="16h10", IsKindergarten=false, SchoolFK=schools.First().ID },
                new TblTimes{ Order=6, StartTime="16h30", EndTime="17h30", IsKindergarten=false, SchoolFK=schools.First().ID },
            };
            times.ForEach(x => context.TblTimes.AddOrUpdate(x));
            context.SaveChanges();

            List<TblSubjects> subjects = new List<TblSubjects>()
            {
                new TblSubjects{Name="Matemática"},
                new TblSubjects{Name="Língua Portuguesa"},
                new TblSubjects{Name="Estudo do Meio"},
                new TblSubjects{Name="Inglês"},
                new TblSubjects{Name="Educação Física"}
            };
            subjects.ForEach(x => context.TblSubjects.AddOrUpdate(x));
            context.SaveChanges();

            List<TblDocuments> documents = new List<TblDocuments>()
            {
                new TblDocuments{ File="64bebba0-662a-439f-81f9-e512f784a8f8.documento pdf exemplo.pdf", ClassFK=1, IsVisible= true, SubmitedIn=DateTime.Now, UserFK= teachers.First().ID, SubjectFK=subjects.First().ID},
                new TblDocuments{ File="64bebba0-662a-439f-81f9-e512f784a8f8.documento pdf exemplo.pdf", ClassFK=1, IsVisible= false, SubmitedIn=DateTime.Now, UserFK= teachers.First().ID, SubjectFK=subjects.First().ID},
                new TblDocuments{ File="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.documento word exemplo.docx", ClassFK=1, IsVisible= true, SubmitedIn=DateTime.Now, UserFK= teachers.Last().ID, SubjectFK=subjects.Last().ID},
                new TblDocuments{ File="b28d6a0b-ced6-44d7-975e-7e81ffb5b02b.documento word exemplo.docx", ClassFK=1, IsVisible= false, SubmitedIn=DateTime.Now, UserFK= teachers.Last().ID, SubjectFK=subjects.Last().ID},
            };
            documents.ForEach(x => context.TblDocuments.AddOrUpdate(x));
            context.SaveChanges();

            List<TblEvaluations> evaluations = new List<TblEvaluations>()
            {
                new TblEvaluations{ Purport="<p>contar até 100</p><p>fazer contas de somar</p><p>fazer contas de subtrair</p>", TeacherFK=teachers.First().ID, SubjectFK=1, ClassFK=1, EvaluationDate=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28))},
                new TblEvaluations{ Purport="<p>Escrever um ditado</p><p>completar palavras com letras do alfabeto em falta</p>", TeacherFK=teachers.Skip(1).First().ID, SubjectFK=2, ClassFK=1, EvaluationDate=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28))},
                new TblEvaluations{ Purport="<p>Saber descrever o ciclo da água</p><p>Saber o significado de condensação</p>", TeacherFK=teachers.Skip(2).First().ID, SubjectFK=3, ClassFK=1, EvaluationDate=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28))},
                new TblEvaluations{ Purport="<p>Saber apresentar-se em inglês</p>", TeacherFK=teachers.Skip(3).First().ID, SubjectFK=4, ClassFK=1, EvaluationDate=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28))},
                new TblEvaluations{ Purport="<p>fazer contas de multiplicar</p>", TeacherFK=teachers.First().ID, SubjectFK=1, ClassFK=1, EvaluationDate=new DateTime(2017, new Random().Next(1, 9), new Random().Next(1, 28))},
            };
            evaluations.ForEach(x => context.TblEvaluations.AddOrUpdate(x));
            context.SaveChanges();
            
            evaluations.Take(3).ToList().ForEach(x =>
                students.ForEach(y => {
                    context.TblEvaluationStudents.AddOrUpdate(new TblEvaluationStudents {EvaluationFK=x.ID, StudentFK=y.ID, Value=new Random().Next(1,6) });
                    context.SaveChanges();
                })
            );
            evaluations.Skip(3).ToList().ForEach(x =>
                students.ForEach(y => {
                    context.TblEvaluationStudents.AddOrUpdate(new TblEvaluationStudents { EvaluationFK = x.ID, StudentFK = y.ID });
                    context.SaveChanges();
                })
            );
            
            for(int i=1; i <= 5; i++)
            {
                times.ForEach(x => {
                    context.TblSchedules.AddOrUpdate(
                        new TblSchedules {
                            ClassFK = 1,
                            DayOfWeek = i,
                            Duration = 1,
                            TimeFK = x.ID,
                            SubjectFK =subjects.ElementAt(i-1).ID,
                            TeacherFK =teachers.ElementAt(i-1).ID,
                            RoomFK =new Random().Next(1,3)
                    });
                    context.SaveChanges();
                });
            }
            
            List<TblLessons> lessons = new List<TblLessons>()
            {
                new TblLessons{ Day=new DateTime(2017, 9, 4), ScheduleFK=1, Summary="Definição de números ímpares. Realização de exercícios de contas de sutrair", Homework="Realizar as contas disponíveis na ficha 2 disponível nos documentos da turma", Observations="Os alunos demonstraram especial dificuldade nas contas de subtrair"},
                new TblLessons{ Day=new DateTime(2017, 9, 11), ScheduleFK=1, Summary="Conclusão dos esxercícios da aula anterior. Iniciação às contas de dividir", Homework="Realizar as contas disponíveis na ficha 2 disponível nos documentos da turma", Observations="Os alunos demonstraram especial dificuldade nas contas de subtrair"},
                new TblLessons{ Day=new DateTime(2017, 9, 18), ScheduleFK=1, Summary="Realização de exercícios de contas de dividir", Homework="Realizar as contas disponíveis na ficha 2 disponível nos documentos da turma", Observations="Os alunos demonstraram especial dificuldade nas contas de subtrair"},
                new TblLessons{ Day=new DateTime(2017, 9, 25), ScheduleFK=1, Summary="Conclusão dos esxercícios da aula anterior. Iniciação às contas de dividir", Observations="Os alunos demonstraram especial dificuldade nas contas de subtrair"},
                new TblLessons{ Day=new DateTime(2017, 10, 2), ScheduleFK=1, Summary="Definição de números ímpares. Realização de exercícios de contas de sutrair", Homework="Realizar as contas disponíveis na ficha 2 disponível nos documentos da turma", Observations="Os alunos demonstraram especial dificuldade nas contas de subtrair"},
            };
            lessons.ForEach(x => context.TblLessons.AddOrUpdate(x));
            context.SaveChanges();

            lessons.ForEach(x => {
                students.ForEach(y =>
                {
                    context.TblLessonStudents.AddOrUpdate( 
                        new TblLessonStudents { LessonFK=x.ID, StudentFK=y.ID, Material=(new Random().Next() %2 ==0)?true:false, Presence = (new Random().Next() % 2 == 0) ? true : false, Behavior = new Random().Next(1,6) }    
                    );
                    context.SaveChanges();
                });
            });

            List<TblRooms> rooms = new List<TblRooms>()
            {
                new TblRooms{ FloorFK=1, HasSensor=true, XCoord=226, YCoord=454, Name="Sala A1"},
                new TblRooms{ FloorFK=1, HasSensor=true, XCoord=268, YCoord=455, Name="Sala A2"},
                new TblRooms{ FloorFK=2, HasSensor=true, XCoord=268, YCoord=455, Name="Sala B2"},
                new TblRooms{ FloorFK=1, HasSensor=false, XCoord=226, YCoord=337, Name="Sala A3"},
                new TblRooms{ FloorFK=2, HasSensor=false, XCoord=226, YCoord=454, Name="Sala B1"},
                new TblRooms{ FloorFK=2, HasSensor=false, XCoord=226, YCoord=337, Name="Sala B3"},
            };
            rooms.ForEach(x => context.TblRooms.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}
