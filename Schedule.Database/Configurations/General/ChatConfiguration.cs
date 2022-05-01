using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Communication;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class ChatConfiguration : AuditEntityConfiguration<Chat>
    {
        public override void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(Constants.MAX_CHAT_NAME_LENGHT)
                .IsRequired();

            builder
                .HasOne(x => x.Organizer)
                .WithMany(x => x.OrganizedChats)
                .HasForeignKey(x => x.OrganizerId);

            builder
                .HasMany(x => x.Participants)
                .WithMany(x => x.Chats)
                .UsingEntity<UserChat>(
                    ucBuilder =>
                        ucBuilder.HasOne(uc => uc.User)
                        .WithMany(u => u.UserChats)
                        .HasForeignKey(uc => uc.UserId),
                    ucBuilder =>
                        ucBuilder.HasOne(uc => uc.Chat)
                        .WithMany(c => c.ParticipantChats)
                        .HasForeignKey(uc => uc.ChatId),
                    ucBuilder =>
                    {
                        ucBuilder.HasKey(uc => new { uc.UserId, uc.ChatId });
                    });

            base.Configure(builder);
        }
    }
}
