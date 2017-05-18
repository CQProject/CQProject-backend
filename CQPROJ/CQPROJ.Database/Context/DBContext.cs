using Microsoft.AspNet.Identity.EntityFramework;
using CQPROJ.Database.Models;
using CQPROJ.Database.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CQPROJ.Database.Context
{
    public class DBContext : IdentityDbContext<Tbl_User>
    {
        /**************************************************************************************************************************
         * especificar onde será criada a Base de dados
         * a localização é especificada no ficheiro Web.config
         * ----------------------------------------------------
         *  depois de definidas as configurações -> NuGet Console:
         *          PM> Enable-Migrations -EnableAutomaticMigrations
         *      para habilitar as migrações entre a base de dados definida e a aplicação
         *          PM> Update-Database
         *      para atualizar a base de dados tendo em conta as migrações definidas em Migrations/Configurations.cs
         ***************************************************************************************************************************/
        public DBContext(): base("Connection", throwIfV1Schema: false) { }

        public virtual DbSet<Tbl_User> User { get; set; }
        public virtual DbSet<Tbl_Admin> Admin { get; set; }
        public virtual DbSet<Tbl_Secretary> Secretary { get; set; }
        public virtual DbSet<Tbl_Functionary> unctionary { get; set; }
        public virtual DbSet<Tbl_Task> Task { get; set; }
        public virtual DbSet<Tbl_Teacher> eacher { get; set; }
        public virtual DbSet<Tbl_Class> Class { get; set; }
        public virtual DbSet<Tbl_Schedule> Schedule { get; set; }
        public virtual DbSet<Tbl_Guardian> Guardian { get; set; }
        public virtual DbSet<Tbl_Student> Student { get; set; }
        public virtual DbSet<Tbl_Lesson> Lesson { get; set; }
        public virtual DbSet<Tbl_Lesson_Student> Lesson_Student { get; set; }
        public virtual DbSet<Tbl_Notification> Notification { get; set; }
        public virtual DbSet<Tbl_Validation> Validation { get; set; }
        public virtual DbSet<Tbl_Action> Action { get; set; }
        public virtual DbSet<Tbl_School> School { get; set; }


        public static DBContext Create()
        {
            return new DBContext();
        }

    }
}