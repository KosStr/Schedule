using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Chat;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{

    internal class UserChatsConfiguration : Configuration<UserChats>
    {
        public override void Configure(EntityTypeBuilder<UserChats> builder)
        {
            builder
                .HasKey(x => new { x.UserId, x.ChatId });

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Chats)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Chat)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ChatId);
        }
    }
}
