using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class MarkConfiguration : AuditEntityConfiguration<Mark>
    {
        public override void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder
                .Property(x => x.Comment)
                .HasMaxLength(50);

            builder
               .HasOne(x => x.Lesson)
               .WithMany(x => x.Marks)
               .HasForeignKey(x => x.LessonId);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.StudentId);

            base.Configure(builder);
        }
    }
}
