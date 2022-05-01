using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Helpers;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class AttachmentConfiguration : AuditEntityConfiguration<Attachment>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder
                .Property(x => x.Text)
                .HasMaxLength(Constants.MAX_TEXT_LENGHT);

            builder
                .HasOne(x => x.Owner)
                .WithMany(x => x.StudentAttachments)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Grade)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.GradeId);

            builder
                .HasOne(x => x.Assignment)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.AssignmentId);

            base.Configure(builder);
        }
    }
}
