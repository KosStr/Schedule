using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Token;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.Token
{
    internal class RefreshTokenConfiguration : EntityBaseConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {

            builder
                .Property(x => x.Token)
                .IsRequired();

            builder
                .HasIndex(x => x.Token)
                .IsUnique();

            builder
                .Property(x => x.ExpiryTime)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Token)
                .HasForeignKey<RefreshToken>(i => i.UserId);

            base.Configure(builder);
        }
    }
}
