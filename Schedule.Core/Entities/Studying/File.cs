using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.Studying
{
    public class File : AuditEntity
    {
        public string Path { get; set; }
        public string FileType { get; set; }
        public Guid AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
        public Guid UploaderId { get; set; }
        public virtual User Uploader { get; set; }
    }
}
