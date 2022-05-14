using Microsoft.EntityFrameworkCore;
using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Communication;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Entities.Token;
using Schedule.Database.SeedData;

namespace Schedule.database
{
    public class SqlDatabase : DbContext
    {
        #region Constructor

        public SqlDatabase(DbContextOptions<SqlDatabase> options) : base(options)
        {

        }

        #endregion

        #region Overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }

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
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentGroup> AppointmentGroups { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChat> UserChats { get; set; }

        #endregion
    }
}
