using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.General
{
    public class Mark : AuditEntity
    {
        public int Value { get; set; }
        public string Comment { get; set; }
        public Guid StudentId { get; set; }
        public Guid LessonId { get; set; }
        public virtual User Student { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
