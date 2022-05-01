using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Studying
{
    public class Assignment : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public double? Grade { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid TeacherId { get; set; }
        public virtual User Teacher { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
        public virtual ICollection<File> Files { get; set; } = new List<File>();
    }
}
