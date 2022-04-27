using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class AppointmentGroupsConfiguration : Configuration<AppointmentGroups>
    {
        public override void Configure(EntityTypeBuilder<AppointmentGroups> builder)
        {
            builder
                .HasKey(x => new { x.AppointmentId, x.GroupId });

            builder
                .HasOne(x => x.Appointment)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.AppointmentId);

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.AppointmentId);
        }
    }
}

