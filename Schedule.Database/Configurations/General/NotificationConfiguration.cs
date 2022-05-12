using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class NotificationConfiguration : AuditEntityConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                .Property(x => x.FromDate)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .Property(x => x.DueDate)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .Property(i => i.Message)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(x => x.Priority)
                .HasColumnType("TINYINT")
                .HasDefaultValue(NotificationPriority.Low);

            builder
                .Property(x => x.Type)
                .HasColumnType("TINYINT");

            builder
                .HasMany(x => x.Users)
                .WithMany(x => x.Notifications)
                .UsingEntity<UserNotification>(
                    unBuilder =>
                        unBuilder.HasOne(un => un.User)
                        .WithMany(u => u.UserNotifications)
                        .HasForeignKey(un => un.UserId),
                    unBuilder =>
                        unBuilder.HasOne(un => un.Notification)
                        .WithMany(u => u.UserNotifications)
                        .HasForeignKey(un => un.NotificationId),
                    unBuilder =>
                    {
                        unBuilder.HasKey(us => new { us.UserId, us.NotificationId });
                    });

            base.Configure(builder);
        }
    }
}
