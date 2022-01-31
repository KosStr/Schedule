using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class GroupLessonsConfiguration : Configuration<GroupLessons>
    {
        public override void Configure(EntityTypeBuilder<GroupLessons> builder)
        {
            builder
                .HasKey(x => new { x.GroupId, x.LessonId });

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.GroupId);

            builder
                .HasOne(x => x.Lesson)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.LessonId);
        }
    }
}
