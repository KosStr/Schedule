using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class LessonConfiguration : AuditEntityConfiguration<Lesson>
    {
        public override void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.IsCompulsory)
                .HasDefaultValue(true);

            builder
                .Property(i => i.Type)
                .HasColumnType("TINYINT")
                .HasDefaultValue(LessonType.Practice);

            builder
                .HasMany(x => x.Marks)
                .WithOne(x => x.Lesson);

            builder
                .HasMany(x => x.Teachers)
                .WithOne(x => x.Lesson);

            builder
                .HasMany(x => x.Groups)
                .WithOne(x => x.Lesson);

            base.Configure(builder);
        }
    }
}
