using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class FacultyConfiguration : AuditEntityConfiguration<Faculty>
    {
        public override void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(x => x.Organization)
                .WithMany(x => x.Faculties)
                .HasForeignKey(x => x.OrganizationId);

            base.Configure(builder);
        }
    }
}