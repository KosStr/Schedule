using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class GroupConfiguration : AuditEntityConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(Constants.MAX_GROUP_NAME_LENGHT)
                .IsRequired();

            builder
                .Property(x => x.Faculty)
                .IsRequired();

            builder
                .HasMany(x => x.Appointments)
                .WithMany(x => x.Groups)
                .UsingEntity<AppointmentGroup>(
                    agBuilder =>
                        agBuilder.HasOne(ag => ag.Appointment)
                        .WithMany(a => a.AppointmentGroups)
                        .HasForeignKey(ag => ag.AppointmentId),
                    agBuilder =>
                        agBuilder.HasOne(ag => ag.Group)
                        .WithMany(a => a.AppointmentGroups)
                        .HasForeignKey(ag => ag.GroupId),
                    agBuilder =>
                    {
                        agBuilder.HasKey(ag => new { ag.GroupId, ag.AppointmentId });
                    });

            base.Configure(builder);
        }
    }
}
