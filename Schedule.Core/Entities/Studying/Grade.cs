using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.General
{
    public class Grade : AuditEntity
    {
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Guid StudentId { get; set; }
        public virtual User Student { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
