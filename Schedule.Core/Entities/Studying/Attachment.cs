using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using System;

namespace Schedule.Core.Entities.Studying
{
    public class Attachment : AuditEntity
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public Guid AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
