using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Base;

namespace Schedule.database.Configurations.Base
{
    internal abstract class AuditEntityConfiguration<T> : EntityBaseConfiguration<T> where T : AuditEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .Property(i => i.CreatedAt)
                .HasColumnType("DATETIME")
                .ValueGeneratedOnAdd();

            builder.Property(i => i.ModifiedAt)
                .HasColumnType("DATETIME")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(i => i.CreatedBy)
                .HasColumnType("VARBINARY(16)");

            builder.Property(i => i.ModifiedBy)
                .HasColumnType("VARBINARY(16)");

            base.Configure(builder);
        }
    }
}
