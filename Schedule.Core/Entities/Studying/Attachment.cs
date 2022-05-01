using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Studying
{
    public class Attachment : AuditEntity
    {
        public string Text { get; set; }
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public Guid? GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public Guid AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
        
        public virtual ICollection<File> Files { get; set; } = new List<File>();
    }
}
