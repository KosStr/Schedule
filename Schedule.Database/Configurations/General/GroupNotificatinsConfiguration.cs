using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class GroupNotificationsConfiguration : Configuration<GroupNotifications>
    {
        public override void Configure(EntityTypeBuilder<GroupNotifications> builder)
        {
            builder
                .HasKey(x => new { x.GroupId, x.NotificationId });

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.GroupId);

            builder
                .HasOne(x => x.Notification)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.NotificationId);
        }
    }
}
