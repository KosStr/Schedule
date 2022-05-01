using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class TaskConfiguration : AuditEntityConfiguration<Task>
    {
        public override void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .Property(x => x.Title)
                .HasMaxLength(Constants.MAX_TASK_TITLE_LENGHT)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(Constants.MAX_TASK_DESCRIPTION_LENGHT)
                .IsRequired();

            builder
                .HasOne(x => x.Appointment)
                .WithOne(x => x.Task)
                .HasForeignKey<Task>(x => x.AppointmentId);

            base.Configure(builder);
        }
    }
}
