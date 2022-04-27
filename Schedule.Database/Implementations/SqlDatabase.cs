using Microsoft.EntityFrameworkCore;
using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Chat;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Entities.Token;

namespace Schedule.database
{
    public class SqlDatabase : DbContext
    {
        #region Constructor

        public SqlDatabase(DbContextOptions<SqlDatabase> options) : base(options)
        {
            this.Database.Migrate();
        }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var type = GetType();
            modelBuilder.ApplyConfigurationsFromAssembly(type.Assembly);
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region DbSets

        public DbSet<User> Users { get; set; }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubjects> TeacherSubjects { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotifications> UserNotifications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentGroups> AppointmentGroups { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChats> UserChats { get; set; }

        #endregion
    }
}
