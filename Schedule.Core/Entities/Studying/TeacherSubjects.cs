using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Core.Entities.General
{
    public class TeacherSubjects
    {
        public Guid TeacherId { get; set; }
        public Guid LessonId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
