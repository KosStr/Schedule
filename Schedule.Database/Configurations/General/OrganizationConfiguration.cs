using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class OrganizationConfiguration : AuditEntityConfiguration<Organization>
    {
        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
