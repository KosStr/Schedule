using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.General
{
    public class TeacherSubject: ISqlEntity
    {
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
