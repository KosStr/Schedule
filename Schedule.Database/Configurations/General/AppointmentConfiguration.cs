using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class AppointmentConfiguration : AuditEntityConfiguration<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder
                .Property(x => x.FromDate)
                .HasDefaultValue(System.DateTime.UtcNow);

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.SubjectId);

            builder
                .HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherAppointments)
                .HasForeignKey(x => x.TeacherId);

            base.Configure(builder);
        }
    }
}
