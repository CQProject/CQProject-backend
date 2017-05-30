namespace CQPROJ.Data.DB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContextModel : DbContext
    {
        public DBContextModel()
            : base("name=DBContextModel")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<TblActions> TblActions { get; set; }
        public virtual DbSet<TblClasses> TblClasses { get; set; }
        public virtual DbSet<TblClassStudents> TblClassStudents { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
        public virtual DbSet<TblEvaluations> TblEvaluations { get; set; }
        public virtual DbSet<TblEvaluationStudents> TblEvaluationStudents { get; set; }
        public virtual DbSet<TblGuardians> TblGuardians { get; set; }
        public virtual DbSet<TblLessons> TblLessons { get; set; }
        public virtual DbSet<TblLessonStudents> TblLessonStudents { get; set; }
        public virtual DbSet<TblNotifications> TblNotifications { get; set; }
        public virtual DbSet<TblPictures> TblPictures { get; set; }
        public virtual DbSet<TblRoles> TblRoles { get; set; }
        public virtual DbSet<TblSchAssistants> TblSchAssistants { get; set; }
        public virtual DbSet<TblSchedules> TblSchedules { get; set; }
        public virtual DbSet<TblSchoolLayout> TblSchoolLayout { get; set; }
        public virtual DbSet<TblSecretaries> TblSecretaries { get; set; }
        public virtual DbSet<TblStudents> TblStudents { get; set; }
        public virtual DbSet<TblTasks> TblTasks { get; set; }
        public virtual DbSet<TblTeachers> TblTeachers { get; set; }
        public virtual DbSet<TblUserRoles> TblUserRoles { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<TblValidations> TblValidations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
