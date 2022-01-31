using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.General
{
    internal class GroupConfiguration : AuditEntityConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {

            builder
                .Property(x => x.Grade)
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .HasMany(x => x.Lessons)
                .WithOne(x => x.Group);

            builder
                .HasMany(x => x.Users)
                .WithOne(x => x.Group);

            builder
                .HasMany(x => x.Notifications)
                .WithOne(x => x.Group);

            base.Configure(builder);
        }
    }
}
