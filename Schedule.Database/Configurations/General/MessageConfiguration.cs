using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Communication;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class MessageConfiguration : AuditEntityConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .Property(x => x.Text)
                .HasMaxLength(Constants.MAX_TEXT_LENGHT)
                .IsRequired();

            builder
                .HasOne(x => x.Sender)
                .WithMany(x => x.SentMessages)
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Chat)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.ChatId);

            base.Configure(builder);
        }
    }
}
