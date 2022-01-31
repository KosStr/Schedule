using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class TeacherLessonsConfiguration : Configuration<TeacherLessons>
    {
        public override void Configure(EntityTypeBuilder<TeacherLessons> builder)
        {
            builder
                .HasKey(x => new { x.TeacherId, x.LessonId });

            builder
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.TeacherId);

            builder
                .HasOne(x => x.Lesson)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.LessonId);
        }
    }
}
