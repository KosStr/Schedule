using System;

namespace Schedule.Core.Entities.General
{
    public class GroupLessons
    {
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid GroupId { get; set; }
        public Guid LessonId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
