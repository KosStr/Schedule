using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class GroupNotificationsConfiguration : Configuration<UserNotifications>
    {
        public override void Configure(EntityTypeBuilder<UserNotifications> builder)
        {
            builder
                .HasKey(x => new { x.UsertId, x.NotificationId });

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.UsertId);

            builder
                .HasOne(x => x.Notification)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.NotificationId);
        }
    }
}
