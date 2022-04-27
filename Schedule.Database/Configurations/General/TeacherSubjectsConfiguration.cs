using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class TeacherSubjectsConfiguration : Configuration<TeacherSubjects>
    {
        public override void Configure(EntityTypeBuilder<TeacherSubjects> builder)
        {
            builder
                .HasKey(x => new { x.TeacherId, x.LessonId });

            builder
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.TeacherId);

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.LessonId);
        }
    }
}
