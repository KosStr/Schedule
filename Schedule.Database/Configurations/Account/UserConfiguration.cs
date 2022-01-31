using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Account;
using Schedule.Core.Enums;
using Schedule.database.Configurations.Base;

namespace Schedule.database.Configurations.Account
{
    internal class UserConfiguration : AuditEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasIndex(x => x.Email)
                .IsUnique();

            builder
                .Property(x => x.Phone)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .HasIndex(x => x.Phone)
                .IsUnique();

            builder
                .Property(i => i.Role)
                .HasColumnType("TINYINT")
                .HasDefaultValue(Role.Student)
                .IsRequired();

            builder
                .Property(i => i.PasswordHash)
                .IsRequired();

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Users)
                .HasForeignKey(i => i.GroupId);

            builder
                .HasMany(x => x.Marks)
                .WithOne(x => x.Student);

            builder
                .HasMany(x => x.Lessons)
                .WithOne(x => x.Teacher);

            base.Configure(builder);
        }
    }
}
