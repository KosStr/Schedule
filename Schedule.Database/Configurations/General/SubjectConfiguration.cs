using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class SubjectConfiguration : AuditEntityConfiguration<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(Constants.MAX_SUBJECT_NAME_LENGHT)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(Constants.MAX_SUBJECT_DESCRIPTION_LENGHT);

            builder
               .HasMany(x => x.Teachers)
               .WithMany(x => x.Subjects)
               .UsingEntity<TeacherSubject>(
                    tsBuilder =>
                       tsBuilder.HasOne(ts => ts.Teacher)
                       .WithMany(s => s.TeacherSubjects)
                       .HasForeignKey(ts => ts.TeacherId),
                   tsBuilder =>
                       tsBuilder.HasOne(ts => ts.Subject)
                       .WithMany(t => t.TeacherSubjects)
                       .HasForeignKey(ts => ts.SubjectId),
                   tsBuilder =>
                   {
                       tsBuilder.HasKey(us => new { us.SubjectId, us.TeacherId });
                   });

            base.Configure(builder);
        }
    }
}
