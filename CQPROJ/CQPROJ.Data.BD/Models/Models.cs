namespace CQPROJ.Data.BD.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Models : DbContext
    {
        public Models()
            : base("name=Models")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<TblActions> TblActions { get; set; }
        public virtual DbSet<TblClasses> TblClasses { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
        public virtual DbSet<TblEvaluations> TblEvaluations { get; set; }
        public virtual DbSet<TblEvaluationStudents> TblEvaluationStudents { get; set; }
        public virtual DbSet<TblGuardians> TblGuardians { get; set; }
        public virtual DbSet<TblLessons> TblLessons { get; set; }
        public virtual DbSet<TblLessonStudents> TblLessonStudents { get; set; }
        public virtual DbSet<TblNotifications> TblNotifications { get; set; }
        public virtual DbSet<TblRoles> TblRoles { get; set; }
        public virtual DbSet<TblSchAssistants> TblSchAssistants { get; set; }
        public virtual DbSet<TblSchedules> TblSchedules { get; set; }
        public virtual DbSet<TblSchoolLayout> TblSchoolLayout { get; set; }
        public virtual DbSet<TblSecretaries> TblSecretaries { get; set; }
        public virtual DbSet<TblStudents> TblStudents { get; set; }
        public virtual DbSet<TblTasks> TblTasks { get; set; }
        public virtual DbSet<TblTeachers> TblTeachers { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<TblValidations> TblValidations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblClasses>()
                .HasMany(e => e.TblDocuments)
                .WithOptional(e => e.TblClasses)
                .HasForeignKey(e => e.ClassFK);

            modelBuilder.Entity<TblClasses>()
                .HasMany(e => e.TblSchedules)
                .WithOptional(e => e.TblClasses)
                .HasForeignKey(e => e.ClassFK);

            modelBuilder.Entity<TblClasses>()
                .HasMany(e => e.TblStudents)
                .WithMany(e => e.TblClasses)
                .Map(m => m.ToTable("TblClassStudents").MapLeftKey("ClassFK").MapRightKey("StudentFK"));

            modelBuilder.Entity<TblEvaluations>()
                .HasMany(e => e.TblEvaluationStudents)
                .WithRequired(e => e.TblEvaluations)
                .HasForeignKey(e => e.EvaluationFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblGuardians>()
                .HasMany(e => e.TblStudents)
                .WithOptional(e => e.TblGuardians)
                .HasForeignKey(e => e.GuardianFK);

            modelBuilder.Entity<TblLessons>()
                .HasMany(e => e.TblLessonStudents)
                .WithRequired(e => e.TblLessons)
                .HasForeignKey(e => e.LessonFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblNotifications>()
                .HasMany(e => e.TblValidations)
                .WithRequired(e => e.TblNotifications)
                .HasForeignKey(e => e.NotificationFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblRoles>()
                .HasMany(e => e.TblUsers)
                .WithMany(e => e.TblRoles)
                .Map(m => m.ToTable("TblUserRoles").MapLeftKey("RoleID").MapRightKey("UserID"));

            modelBuilder.Entity<TblSchAssistants>()
                .HasMany(e => e.TblTasks)
                .WithOptional(e => e.TblSchAssistants)
                .HasForeignKey(e => e.SchAssistantFK);

            modelBuilder.Entity<TblSchedules>()
                .HasMany(e => e.TblEvaluations)
                .WithOptional(e => e.TblSchedules)
                .HasForeignKey(e => e.ScheduleFK);

            modelBuilder.Entity<TblSchedules>()
                .HasMany(e => e.TblLessons)
                .WithOptional(e => e.TblSchedules)
                .HasForeignKey(e => e.ScheduleFK);

            modelBuilder.Entity<TblSecretaries>()
                .HasMany(e => e.TblTasks)
                .WithOptional(e => e.TblSecretaries)
                .HasForeignKey(e => e.SecretaryFK);

            modelBuilder.Entity<TblStudents>()
                .HasMany(e => e.TblEvaluationStudents)
                .WithRequired(e => e.TblStudents)
                .HasForeignKey(e => e.StudentFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblStudents>()
                .HasMany(e => e.TblLessonStudents)
                .WithRequired(e => e.TblStudents)
                .HasForeignKey(e => e.StudentFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblTeachers>()
                .HasMany(e => e.TblSchedules)
                .WithOptional(e => e.TblTeachers)
                .HasForeignKey(e => e.TeacherFK);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblActions)
                .WithOptional(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblGuardians)
                .WithRequired(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblNotifications)
                .WithOptional(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblSchAssistants)
                .WithRequired(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblSecretaries)
                .WithRequired(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblStudents)
                .WithOptional(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblTeachers)
                .WithRequired(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblUsers>()
                .HasMany(e => e.TblValidations)
                .WithRequired(e => e.TblUsers)
                .HasForeignKey(e => e.UserFK)
                .WillCascadeOnDelete(false);
        }
    }
}
