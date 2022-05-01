using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.Studying;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Grade : AuditEntity
    {
        public double Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Guid StudentId { get; set; }
        public virtual User Student { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
