using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Core.Entities.General
{
    public class TeacherLessons
    {
        public Guid TeacherId { get; set; }
        public Guid LessonId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
