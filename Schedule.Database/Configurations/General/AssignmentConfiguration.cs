using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class AssignmentConfiguration : AuditEntityConfiguration<Assignment>
    {
        public override void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder
                .Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.MAX_TEXT_LENGHT);

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.SubjectId);

            builder
                .HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherAssignments)
                .HasForeignKey(x => x.TeacherId);

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.GroupId);

            base.Configure(builder);
        }
    }
}
