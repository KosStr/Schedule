using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;
using System;

namespace Schedule.database.Configurations.General
{
    internal class GradeConfiguration : AuditEntityConfiguration<Grade>
    {
        public override void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
                .Property(x => x.Value)
                .IsRequired();

            builder
                .Property(x => x.Comment)
                .HasMaxLength(Constants.MAX_COMMENT_LENGHT);

            builder
                .Property(x => x.Date)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentId);

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.SubjectId);

            base.Configure(builder);
        }
    }
}
