using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Base;

namespace Schedule.database.Configurations.Base
{
    internal abstract class EntityBaseConfiguration<T> : Configuration<T> where T : EntityBase
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("VARBINARY(16)")
                .ValueGeneratedOnAdd();
        }
    }
}
