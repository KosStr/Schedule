using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Studying;
using Schedule.database.Configurations.Base;

namespace Schedule.Database.Configurations.General
{
    internal class FileConfiguration : AuditEntityConfiguration<File>
    {
        public override void Configure(EntityTypeBuilder<File> builder)
        {
            builder
                .Property(x => x.Path)
                .IsRequired();

            builder
                .Property(x => x.Extension)
                .IsRequired();

            builder
                .HasOne(x => x.Assignment)
                .WithMany(x => x.Files)
                .HasForeignKey(x => x.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Attachment)
                .WithMany(x => x.Files)
                .HasForeignKey(x => x.AttachmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Uploader)
                .WithMany(x => x.UploadedFiles)
                .HasForeignKey(x => x.UploaderId);

            base.Configure(builder);
        }
    }
}
