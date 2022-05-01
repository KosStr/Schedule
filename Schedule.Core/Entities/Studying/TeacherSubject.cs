using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Core.Entities.General
{
    public class TeacherSubject
    {
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
