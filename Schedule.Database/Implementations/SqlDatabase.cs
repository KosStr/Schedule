using Microsoft.EntityFrameworkCore;
using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.General;

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
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupLessons> GroupLessons { get; set; }
        public DbSet<GroupNotifications> GroupNotifications { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TeacherLessons> TeacherLessons { get; set; }

        #endregion
    }
}
